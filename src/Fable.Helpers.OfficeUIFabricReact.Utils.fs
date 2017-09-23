module Fable.Helpers.OfficeUIFabricReact.Utils

open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React.Props



[<Erase>]
type IPersonaSize =
    [<Emit("0")>]
    abstract aa: IPersonaSize with get

[<Global>]
let PersonaSize: IPersonaSize = jsNative
// PersonaSizeEnum.aa
// type PersonaSize =
//     tiny = 0,
//     extraExtraSmall = 1,
//     extraSmall = 2,
//     small = 3,
//     regular = 4,
//     large = 5,
//     extraLarge = 6,
//     size28 = 7,
//     size16 = 8,
// }
