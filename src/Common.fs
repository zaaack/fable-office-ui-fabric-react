module Fable.Helpers.OfficeUIFabricReact.Common

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.JS
open Fable.Import.Browser
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Helpers.OfficeUIFabricReact.IconName



type IRenderFunction<'P> = 'P option -> ('P -> React.ReactElement) option -> string option

type IFabricProp = inherit IHTMLProp

let inline makeEl<[<Pojo>]'P when 'P :> IFabricProp> (a: React.ComponentClass<'P>) (b:'P list) c = Fable.Helpers.React.from a (keyValueList CaseRules.LowerFirst b |> unbox) c

let inline makeArrayProps<'A, 'B> (key: string) (options: 'A list list): 'B =
    options 
    |> List.map 
        (fun list -> 
            !!(key, keyValueList CaseRules.LowerFirst list))
    |> (fun arr -> new ResizeArray<'A>(arr) :> obj :?> 'B)


type DirectionalHint =
    /// Appear above the target element with the left edges of the callout and target aligning.
    | TopLeftEdge = 0
    /// Appear above the target element with the centers of the callout and target aligning.
    | TopCenter = 1
    /// Appear above the target element with the right edges of the callout and target aligning.
    | TopRightEdge = 2
    /// Appear above the target element aligning with the target element such that the callout tends toward the center of the screen.
    | TopAutoEdge = 3
    /// Appear below the target element with the left edges of the callout and target aligning.
    | BottomLeftEdge = 4
    /// Appear below the target element with the centers of the callout and target aligning.
    | BottomCenter = 5
    /// Appear below the target element with the right edges of the callout and target aligning.
    | BottomRightEdge = 6
    /// Appear below the target element aligning with the target element such that the callout tends toward the center of the screen.
    | BottomAutoEdge = 7
    /// Appear to the left of the target element with the top edges of the callout and target aligning.
    | LeftTopEdge = 8
    /// Appear to the left of the target element with the centers of the callout and target aligning.
    | LeftCenter = 9
    /// Appear to the left of the target element with the bottom edges of the callout and target aligning.
    | LeftBottomEdge = 10
    /// Appear to the right of the target element with the top edges of the callout and target aligning.
    | RightTopEdge = 11
    /// Appear to the right of the target element with the centers of the callout and target aligning.
    | RightCenter = 12
    /// Appear to the right of the target element with the bottom edges of the callout and target aligning.
    | RightBottomEdge = 13

type IRectangle = {
    left: int;
    top: int;
    width: int;
    height: int;
    right: int option;
    bottom: int option;
}

type IPoint = {
    x: int;
    y: int;
}

type DayOfWeek =
    | Sunday = 0
    | Monday = 1
    | Tuesday = 2
    | Wednesday = 3
    | Thursday = 4
    | Friday = 5
    | Saturday = 6
// The supported date range types
type DateRangeType =
    | Day = 0
    | Week = 1
    | Month = 2

type SelectableOptionMenuItemType =
    | Normal = 0
    | Divider = 1
    | Header = 2

