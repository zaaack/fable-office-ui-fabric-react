#r "packages/build/FAKE/tools/FakeLib.dll"
#r "System.IO.Compression.FileSystem"

open System
open System.IO
open System.Collections
open System.Text.RegularExpressions
open System.Collections.Generic
open Fake
open Fake.AssemblyInfoFile
open Fake.Git
open Fake.ReleaseNotesHelper
open System.ComponentModel
open System.Diagnostics
open System.Threading
open System.Text
open System.Collections.Generic
open System.Collections.Concurrent

let packages = [
    "src/Fable.Import.OfficeUIFabricReact"
]

#if MONO
// prevent incorrect output encoding (e.g. https://github.com/fsharp/FAKE/issues/1196)
System.Console.OutputEncoding <- System.Text.Encoding.UTF8
#endif

let exec file args =
    async {
        let info = ProcessStartInfo (file, args)
        info.RedirectStandardOutput <- true
        info.RedirectStandardError <- true
        info.UseShellExecute <- false
        info.CreateNoWindow <- true
        info.ErrorDialog <- false
        info.LoadUserProfile <- true
        use proc = Process.Start info
        proc.WaitForExit ()
        return if proc.ExitCode <> 0 
            then Result.Error (proc.StandardError.ReadToEndAsync ())
            else Result.Ok (proc.StandardOutput.ReadToEndAsync ())
    }

// Work around for stdout not complete sometimes
let runTs2Fable file =
    async {
        let output = "./.ts2fable" @@ file
        let mutable hasError = false
        let mutable message = ""
        if not (File.Exists output) then
            ensureDirectory (directory output)
            let! result = exec "/bin/sh" (sprintf "-c \"./node_modules/.bin/ts2fable %s > %s\"" file output)
            let! content = 
                match result with
                | Ok(content) -> Async.AwaitTask content
                | Result.Error(message) -> 
                    hasError <- true
                    Async.AwaitTask message
            if hasError then
                message <- content
        if hasError then
            return Result.Error(message)
        else
            return Ok(ReadFileAsString output)
    }

let replaceReFn pattern evalutor str = 
    (Regex pattern).Replace (str, (MatchEvaluator evalutor))

let replaceRe pattern (replacement: string) str = 
    (Regex pattern).Replace (str, replacement)

let capitalize = String.mapi (fun i c -> 
    match i with
    | 0 -> Char.ToUpper c
    | _ -> c)

let lowerFirst =  String.mapi  (fun i c -> 
    match i with
    | 0 -> Char.ToLower c
    | _ -> c) 

let mutable typeMap = Map<string, string array> Seq.empty

let HeaderTpl = trim """
module Fable.Helpers.OfficeUIFabricReact

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

type IRenderFunction<'P> = 'P option -> ('P -> React.ReactElement) option -> string option

let inline makeHTMLProp (b:IHTMLProp list) = keyValueList CaseRules.LowerFirst b |> unbox
let inline makeEl<[<Pojo>]'P when 'P :> IHTMLProp> (a: React.ComponentClass<'P>) (b:IHTMLProp list) c = Fable.Helpers.React.from a (makeHTMLProp b) c

type IFabricProp = inherit IHTMLProp

"""

let EnumMap = Map<string, string> (seq { 
    yield ("Persona", """
        export declare enum PersonaSize {
            tiny = 0,
            extraExtraSmall = 1,
            extraSmall = 2,
            small = 3,
            regular = 4,
            large = 5,
            extraLarge = 6,
            size28 = 7,
            size16 = 8,
        }
        export declare enum PersonaPresence {
            none = 0,
            offline = 1,
            online = 2,
            away = 3,
            dnd = 4,
            blocked = 5,
            busy = 6,
        }
        export declare enum PersonaInitialsColor {
            lightBlue = 0,
            blue = 1,
            darkBlue = 2,
            teal = 3,
            lightGreen = 4,
            green = 5,
            darkGreen = 6,
            lightPink = 7,
            pink = 8,
            magenta = 9,
            purple = 10,
            black = 11,
            orange = 12,
            red = 13,
            darkRed = 14,
        }
        """)
})

let enumToFable = 
    replace "/**" "" 
    >> replace "*/" ""
    >> replace "*" "///"
    >> replaceReFn 
        @"export\s+declare\s+enum\s+(\w+)\s+\{([\w\W]+?)\}\s+" 
        (fun m ->
            printfn "match: %A" m
            let type' = m.Groups.[1].Value
            let content = m.Groups.[2].Value
            let fields = 
                content 
                    |> replace "," "" 
                    |> split '\n' 
                    |> List.map (
                        trim >> 
                        (split '=') >> 
                        (fun l -> l |> List.map trim) >> 
                        (fun item -> 
                            if item.Length = 1 then
                                "    " + item.[0]
                            elif item.Length <> 2 then
                                ""
                            else
                                (sprintf "\n    | %s = %s\n"                            (capitalize item.[0]) item.[1])))
                    |> (fun l -> String.Join("", l))

            (sprintf """
    type %s =
%s

                """ type' fields))

let printEnums _ =
     """
        export declare enum DirectionalHint {
    /**
     * Appear above the target element, with the left edges of the callout and target aligning.
     */
    topLeftEdge = 0,
    /**
     * Appear above the target element, with the centers of the callout and target aligning.
     */
    topCenter = 1,
    /**
     * Appear above the target element, with the right edges of the callout and target aligning.
     */
    topRightEdge = 2,
    /**
     * Appear above the target element, aligning with the target element such that the callout tends toward the center of the screen.
     */
    topAutoEdge = 3,
    /**
     * Appear below the target element, with the left edges of the callout and target aligning.
     */
    bottomLeftEdge = 4,
    /**
     * Appear below the target element, with the centers of the callout and target aligning.
     */
    bottomCenter = 5,
    /**
     * Appear below the target element, with the right edges of the callout and target aligning.
     */
    bottomRightEdge = 6,
    /**
     * Appear below the target element, aligning with the target element such that the callout tends toward the center of the screen.
     */
    bottomAutoEdge = 7,
    /**
     * Appear to the left of the target element, with the top edges of the callout and target aligning.
     */
    leftTopEdge = 8,
    /**
     * Appear to the left of the target element, with the centers of the callout and target aligning.
     */
    leftCenter = 9,
    /**
     * Appear to the left of the target element, with the bottom edges of the callout and target aligning.
     */
    leftBottomEdge = 10,
    /**
     * Appear to the right of the target element, with the top edges of the callout and target aligning.
     */
    rightTopEdge = 11,
    /**
     * Appear to the right of the target element, with the centers of the callout and target aligning.
     */
    rightCenter = 12,
    /**
     * Appear to the right of the target element, with the bottom edges of the callout and target aligning.
     */
    rightBottomEdge = 13,
}
        """
    |> enumToFable

Target "PrintEnums" (fun _ -> printEnums () |> printfn "%s")



let mem2du =  replaceReFn @"abstract\s+([`\w]+)\s*:\s*(.+?)\s+with\s+get,\s+set" (fun m ->
    sprintf 
        "| %s of %s" 
        (capitalize (m.Groups.[1].Value |> trimChars [|'`'|])) 
        (m.Groups.[2].Value.Replace (" option", ""))
    )
let genPropsComp file =
    async {
        let! result = runTs2Fable file
        let relativePath = file |> replace currentDirectory ""
        let dir = if relativePath.Contains "components" then "components" else "utilities"
        let content = 
            match result with
                | Ok(content) -> content
                | Result.Error(message) -> 
                    printf "parse %s failed" file
                    sprintf "(* %s *)" message
        let compName = file |> filename |> replace ".Props.ts" ""
        let enums = Map.tryFind compName EnumMap |> Option.defaultValue "" |> enumToFable
        // printfn "before:\n%s" content
        let mutable curType = ""
        let mutable footerTpl = ""
        let lines = 
            content 
            |> replaceFirst (trim """
namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS""") ""
            |> replace "[<AllowNullLiteral>] " ""
            |> replace @"[<AllowNullLiteral>] " ""
            |> replace @"IStyle" "Fable.Helpers.React.Props.HTMLAttr"
            |> replace @"React.CSSProperties" "HTMLAttr"
            |> replace @"React.ReactNode" "React.ReactElement"
            // |> replaceRe @"([\s<])I([A-Z]\w+)" "$1$2"
            |> replaceRe @"\s+inherit React.\w+<[<>\s\w,']+>" ""
            |> replaceRe @"React.HTMLAttributes<\w+>" "Fable.Helpers.React.Props.HTMLAttr"
            |> replaceRe @"React.(\w+Event\w*)<[\w., ]+>" "Fable.Import.React.$1" //React.FocusEvent React.SyntheticEvent React.HTMLAttributes<HTMLDivElement>  React.KeyboardEvent React.FocusEventHandler
            |> mem2du
            |> split '\n'
        
        let isTypeEnd line i =
            line <> "" && 
                (lines.Length = i || 
                    (lines.Length - 1 > i && lines.[i+1] = ""))
        return lines
            |> List.mapi (fun i line -> 
                let m = (getRegEx "(?:type|and)\s+(\w+) =").Match(line)
                if m.Success then 
                    curType <- m.Groups.[1].Value
                    typeMap <- typeMap |> Map.add curType Array.empty
                else 
                    let newList = match Map.tryFind curType typeMap with
                                    | Some list -> list |> (fun a -> Array.append a [|line|])
                                    | _ -> Array.empty
                    typeMap <- 
                        typeMap 
                        |> Map.add curType newList
                            
                line
                |> (fun line ->
                    if isTypeEnd line i && (curType.Contains "Props" || curType.Contains "Styles") then 
                        let lowerComp = lowerFirst compName
                        if curType.Contains "Props" then
                            footerTpl <- footerTpl + (sprintf """
// makeHTMLProp
let %s = importMember<Fable.Import.React.ComponentClass<%s>> "office-ui-fabric-react"
let inline %s b c = makeEl %s b c
                        """ compName (compName + "Props." + curType) lowerComp compName)
                            sprintf "%s\n        interface IFabricProp" line
                        elif curType.Contains "Styles" then
                            footerTpl <- footerTpl + (sprintf """
let inline %sStyle (css: %s list): HTMLAttr =
    !!("styles", keyValueList CaseRules.LowerFirst css)
                        """ compName (compName + "Props." + curType))
                            line
                        else
                            line
                    else
                        line)
            )
            |> List.map 
                (replaceReFn @"inherit (\w+)(<[\w., ]+>)?" (fun m -> 
                    match typeMap.TryFind m.Groups.[1].Value with
                    | Some list -> 
                        list 
                        |> Array.filter (fun line -> (Regex @"^\s*|\s+").IsMatch line)
                        |> (fun list -> String.Join("\n", list))
                    | None -> "") 
                >> (fun line -> "    " + line))
            |> (fun list -> String.Join ("\n", list)) 
            |> (fun s -> (sprintf 
                    """

module %sProps =%s
    
    %s
    
%s
"""                 compName (enums |> trim |> (fun s -> if s <> "" then "\n" + s else s)) (s |> trim) (footerTpl |> trim)))
        // printfn "after:%s" content
    }

let generateAll _ =
    failwith "Not support"
    printfn "Generate start"
    // match exec "/bin/cat" "./LICENSE" with
    // | Ok(content) -> Console.WriteLine content
    // | Result.Error(message) -> Console.WriteLine message
    // printfn "Generate end"
    ensureDirectory "src/components"
    ensureDirectory ".ts2fable"
    let tasks = 
        !! "node_modules/office-ui-fabric-react/src/**/*.Props.ts"
            // |> Seq.take 1
            |> Seq.toList
            |> List.map genPropsComp
    Async.RunSynchronously (Async.Parallel tasks)
    // |> Array.mapi (fun i line -> if i = 0 then line else replaceRe @"\s+type" "and" line)
    |> (fun list -> String.Join("", list))
    |> (fun c -> HeaderTpl + c)
    |> WriteStringToFile false "./src/Fable.Helpers.OfficeUIFabricReact.fs"
    

module Util =
    open System.Net

    let retryIfFails maxRetries f =
        let rec loop retriesRemaining =
            try
                f ()
            with _ when retriesRemaining > 0 ->
                loop (retriesRemaining - 1)
        loop maxRetries

    let (|RegexReplace|_|) =
        let cache = new Dictionary<string, Regex>()
        fun pattern (replacement: string) input ->
            let regex =
                match cache.TryGetValue(pattern) with
                | true, regex -> regex
                | false, _ ->
                    let regex = Regex pattern
                    cache.Add(pattern, regex)
                    regex
            let m = regex.Match(input)
            if m.Success
            then regex.Replace(input, replacement) |> Some
            else None

    let join pathParts =
        Path.Combine(Array.ofSeq pathParts)

    let run workingDir fileName args =
        printfn "CWD: %s" workingDir
        let fileName, args =
            if EnvironmentHelper.isUnix
            then fileName, args else "cmd", ("/C " + fileName + " " + args)
        let ok =
            execProcess (fun info ->
                info.FileName <- fileName
                info.WorkingDirectory <- workingDir
                info.Arguments <- args) TimeSpan.MaxValue
        if not ok then failwith (sprintf "'%s> %s %s' task failed" workingDir fileName args)

    let start workingDir fileName args =
        let p = new System.Diagnostics.Process()
        p.StartInfo.FileName <- fileName
        p.StartInfo.WorkingDirectory <- workingDir
        p.StartInfo.Arguments <- args
        p.Start() |> ignore
        p

    let runAndReturn workingDir fileName args =
        printfn "CWD: %s" workingDir
        let fileName, args =
            if EnvironmentHelper.isUnix
            then fileName, args else "cmd", ("/C " + args)
        ExecProcessAndReturnMessages (fun info ->
            info.FileName <- fileName
            info.WorkingDirectory <- workingDir
            info.Arguments <- args) TimeSpan.MaxValue
        |> fun p -> p.Messages |> String.concat "\n"

    let visitFile (visitor: string->string) (fileName : string) =
        File.ReadAllLines(fileName)
        |> Array.map (visitor)
        |> fun lines -> File.WriteAllLines(fileName, lines)

        // This code is supposed to prevent OutOfMemory exceptions but it outputs wrong BOM
        // use reader = new StreamReader(fileName, encoding)
        // let tempFileName = Path.GetTempFileName()
        // use writer = new StreamWriter(tempFileName, false, encoding)
        // while not reader.EndOfStream do
        //     reader.ReadLine() |> visitor |> writer.WriteLine
        // reader.Close()
        // writer.Close()
        // File.Delete(fileName)
        // File.Move(tempFileName, fileName)

    let replaceLines (replacer: string->Match->string option) (reg: Regex) (fileName: string) =
        fileName |> visitFile (fun line ->
            let m = reg.Match(line)
            if not m.Success
            then line
            else
                match replacer line m with
                | None -> line
                | Some newLine -> newLine)

    let rec findFileUpwards fileName dir =
        let fullPath = dir </> fileName
        if File.Exists(fullPath)
        then fullPath
        else
            let parent = Directory.GetParent(dir)
            if isNull parent then
                failwithf "Couldn't find %s directory" fileName
            findFileUpwards fileName parent.FullName

let gitOwner = "zaaack"
let gitHome = "https://github.com/" + gitOwner

let dotnetcliVersion = "2.0.0"
let mutable dotnetExePath = environVarOrDefault "DOTNET" "dotnet"

// Targets
let installDotnetSdk () =
    dotnetExePath <- DotNetCli.InstallDotNetSDK dotnetcliVersion

let clean () =
    !! "**/bin" |> CleanDirs
    // Don't delete whole obj folder to leave Paket cache
    !! "**/obj/*.nuspec" ++ "**/obj/*.nuspec" |> DeleteFiles

let needsPublishing (versionRegex: Regex) (releaseNotes: ReleaseNotes) projFile =
    printfn "Project: %s" projFile
    if releaseNotes.NugetVersion.ToUpper().EndsWith("NEXT")
    then
        printfn "Version in Release Notes ends with NEXT, don't publish yet."
        false
    else
        File.ReadLines(projFile)
        |> Seq.tryPick (fun line ->
            let m = versionRegex.Match(line)
            if m.Success then Some m else None)
        |> function
            | None -> failwith "Couldn't find version in project file"
            | Some m ->
                let sameVersion = m.Groups.[1].Value = releaseNotes.NugetVersion
                if sameVersion then
                    printfn "Already version %s, no need to publish." releaseNotes.NugetVersion
                not sameVersion

let pushNuget (releaseNotes: ReleaseNotes) (projFiles: string list) =
    let versionRegex = Regex("<Version>(.*?)</Version>", RegexOptions.IgnoreCase)
    projFiles
    |> Seq.map (fun projFile -> __SOURCE_DIRECTORY__ </> projFile)
    |> Seq.filter (needsPublishing versionRegex releaseNotes)
    |> Seq.iter (fun projFile ->
        let projDir = Path.GetDirectoryName(projFile)
        let nugetKey =
            match environVarOrNone "NUGET_KEY" with
            | Some nugetKey -> nugetKey
            | None -> failwith "The Nuget API key must be set in a NUGET_KEY environmental variable"
        // Restore dependencies here so they're updated to latest project versions
        Util.run projDir dotnetExePath "restore"
        // Update the project file
        (versionRegex, projFile) ||> Util.replaceLines (fun line _ ->
            versionRegex.Replace(line, "<Version>"+releaseNotes.NugetVersion+"</Version>") |> Some)
        try
            Util.run projDir dotnetExePath "pack -c Release"
            Paket.Push (fun p ->
                { p with
                    ApiKey = nugetKey
                    WorkingDir = projDir </> "bin" </> "Release" })
        with _ ->
            Path.GetFileNameWithoutExtension(projFile)
            |> printfn "There's been an error when pushing project: %s"
            printfn "Please revert the version change in .fsproj"
            reraise()
    )

Target "Generate" generateAll

Target "Clean" clean

Target "Build" (fun () ->
    installDotnetSdk ()
    clean ()
    for pkg in packages do
        let projFile = __SOURCE_DIRECTORY__ </> (pkg + ".fsproj")
        let projDir = Path.GetDirectoryName(projFile)
        Util.run projDir dotnetExePath "restore"
        Util.run projDir dotnetExePath "build"
)

let publishPackages () =
    installDotnetSdk ()
    clean ()
    for pkg in packages do
        let projFile = __SOURCE_DIRECTORY__ </> (pkg + ".fsproj")
        let projDir = Path.GetDirectoryName(projFile)
        let release =
            Util.findFileUpwards "RELEASE_NOTES.md" projDir
            |> ReleaseNotesHelper.LoadReleaseNotes
        pushNuget release [projFile]

Target "PublishPackages" publishPackages

// Start build
RunTargetOrDefault "Build"
