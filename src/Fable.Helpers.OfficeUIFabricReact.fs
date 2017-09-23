module Fable.Helpers.OfficeUIFabricReact.Components

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Fable.Helpers.React
open Fable.Helpers.React.Props

type IRenderFunction<'P> = 'P option -> ('P -> React.ReactElement) option -> string option

let inline makeHTMLProp (b:IHTMLProp list) = keyValueList CaseRules.LowerFirst b |> unbox
let inline makeEl<[<Pojo>]'P when 'P :> IHTMLProp> (a: React.ComponentClass<'P>) (b:IHTMLProp list) c = Fable.Helpers.React.from a (makeHTMLProp b) c

type IFabricProp = inherit IHTMLProp


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

module PersonaProps =
    type PersonaSize =
        | Tiny = 0
        | ExtraExtraSmall = 1
        | ExtraSmall = 2
        | Small = 3
        | Regular = 4
        | Large = 5
        | ExtraLarge = 6
        | Size28 = 7
        | Size16 = 8

    type PersonaPresence =
        | None = 0
        | Offline = 1
        | Online = 2
        | Away = 3
        | Dnd = 4
        | Blocked = 5
        | Busy = 6

    type PersonaInitialsColor =
        | LightBlue = 0
        | Blue = 1
        | DarkBlue = 2
        | Teal = 3
        | LightGreen = 4
        | Green = 5
        | DarkGreen = 6
        | LightPink = 7
        | Pink = 8
        | Magenta = 9
        | Purple = 10
        | Black = 11
        | Orange = 12
        | Red = 13
        | DarkRed = 14
    
    type IPersona =
        interface end
    
    and IPersonaProps =
        | ComponentRef of Func<IPersona, unit>
        | PrimaryText of string
        | OnRenderPrimaryText of IRenderFunction<IPersonaProps>
        | Size of PersonaSize
        | ImageShouldFadeIn of bool
        | ImageShouldStartVisible of bool
        | ImageUrl of string
        | ImageAlt of string
        | ImageInitials of string
        | OnRenderInitials of IRenderFunction<IPersonaProps>
        | InitialsColor of PersonaInitialsColor
        | Presence of PersonaPresence
        | SecondaryText of string
        | OnRenderSecondaryText of IRenderFunction<IPersonaProps>
        | TertiaryText of string
        | OnRenderTertiaryText of IRenderFunction<IPersonaProps>
        | OptionalText of string
        | OnRenderOptionalText of IRenderFunction<IPersonaProps>
        | HidePersonaDetails of bool
        | ClassName of string
        | ShowSecondaryText of bool
        interface IFabricProp
    
// makeHTMLProp
let Persona = importMember<Fable.Import.React.ComponentClass<PersonaProps.IPersonaProps>> "office-ui-fabric-react"
let inline persona b c = makeEl Persona b c




module ImageProps =
    type ImageFit =
     /// The image is not scaled. The image is centered and cropped within the content box.
    | Center = 0
    /// The image is scaled to maintain its aspect ratio while being fully contained within the frame. The image will
    /// be centered horizontally and vertically within the frame. The space in the top and bottom or in the sides of
    /// the frame will be empty depending on the difference in aspect ratio between the image and the frame.
    | Contain = 1
    /// The image is scaled to maintain its aspect ratio while filling the frame. Portions of the image will be cropped from
    /// the top and bottom, or from the sides, depending on the difference in aspect ratio between the image and the frame.
    | Cover = 2
    /// Neither the image nor the frame are scaled. If their sizes do not match, the image will either be cropped or the
    /// frame will have empty space.
    | None = 3

    /// The cover style to be used on the image
    type ImageCoverStyle =
    /// The image will be shown at 100% height of container and the width will be scaled accordingly
    | Landscape = 0
    /// The image will be shown at 100% width of container and the height will be scaled accordingly
    | Portrait = 1
 
    type ImageLoadState =
    /// The image has not yet been loaded, and there is no error yet.
    | NotLoaded = 0
    /// The image has been loaded successfully.
    | Loaded = 1
    /// An error has been encountered while loading the image.
    | Error = 2
    
    type IImage =
        interface end
    
    and IImageProps =
        | ComponentRef of Func<IImage, unit>
        | ShouldFadeIn of bool
        | ShouldStartVisible of bool
        | ClassName of string
        | ImageFit of ImageFit
        | ErrorSrc of string
        | MaximizeFrame of bool
        | OnLoadingStateChange of Func<ImageLoadState, unit>
        | CoverStyle of ImageCoverStyle
        interface IFabricProp
    
// makeHTMLProp
let Image = importMember<Fable.Import.React.ComponentClass<ImageProps.IImageProps>> "office-ui-fabric-react"
let inline image b c = makeEl Image b c



module IconProps =
    type IconType =
    | Default = 0
    | Image = 1
    
    type IIconStyles =
        | Root of Fable.Helpers.React.Props.HTMLAttr
        | ImageContainer of Fable.Helpers.React.Props.HTMLAttr
    
    and IIconProps =
        | IconName of U2<string, obj>
        | Null of obj
        | Styles of IIconStyles
        | AriaLabel of string
        | IconType of IconType
        | ImageProps of ImageProps.IImageProps
        | OnClicked of Func<Fable.Import.React.MouseEvent, unit>
        interface IFabricProp
    
let inline IconStyle (css: IconProps.IIconStyles list): HTMLAttr =
    !!("styles", keyValueList CaseRules.LowerFirst css)
                        
// makeHTMLProp
let Icon = importMember<Fable.Import.React.ComponentClass<IconProps.IIconProps>> "office-ui-fabric-react"
let inline icon b c = makeEl Icon b c

module ActivityItemProps =
    
    type IActivityItemProps =
        | ActivityDescriptionText of string
        | ActivityPersonas of ResizeArray<PersonaProps.IPersonaProps>
        | CommentText of string
        | ComponentRef of Func<unit, unit>
        | IsCompact of bool
        | OnRenderActivityDescription of IRenderFunction<IActivityItemProps>
        | OnRenderComments of IRenderFunction<IActivityItemProps>
        | OnRenderIcon of IRenderFunction<IActivityItemProps>
        | OnRenderTimeStamp of IRenderFunction<IActivityItemProps>
        | Styles of IActivityItemStyles
        | TimeStamp of string
        interface IFabricProp
    
    and IActivityItemStyles =
        | Root of Fable.Helpers.React.Props.HTMLAttr
        | ActivityContent of Fable.Helpers.React.Props.HTMLAttr
        | ActivityPersona of Fable.Helpers.React.Props.HTMLAttr
        | ActivityText of Fable.Helpers.React.Props.HTMLAttr
        | ActivityTypeIcon of Fable.Helpers.React.Props.HTMLAttr
        | CommentText of Fable.Helpers.React.Props.HTMLAttr
        | DoublePersona of Fable.Helpers.React.Props.HTMLAttr
        | IsCompactRoot of Fable.Helpers.React.Props.HTMLAttr
        | IsCompactIcon of Fable.Helpers.React.Props.HTMLAttr
        | IsCompactContent of Fable.Helpers.React.Props.HTMLAttr
        | IsCompactPersona of Fable.Helpers.React.Props.HTMLAttr
        | IsCompactPersonaContainer of Fable.Helpers.React.Props.HTMLAttr
        | PersonaContainer of Fable.Helpers.React.Props.HTMLAttr
        | TimeStamp of Fable.Helpers.React.Props.HTMLAttr
    
// makeHTMLProp
let ActivityItem = importMember<Fable.Import.React.ComponentClass<ActivityItemProps.IActivityItemProps>> "office-ui-fabric-react"
let inline activityItem b c = makeEl ActivityItem b c
                        
let inline ActivityItemStyle (css: ActivityItemProps.IActivityItemStyles list): HTMLAttr =
    !!("styles", keyValueList CaseRules.LowerFirst css)


module FocusZoneProps =

    type FocusZoneDirection =
    /// Only react to up/down arrows.
    | Vertical = 0
    /// Only react to left/right arrows.
    | Horizontal = 1
    /// React to all arrows.
    | Bidirectional = 2
    
    type IFocusZone =
        abstract focus: unit -> bool
        abstract focusElement: ?childElement: HTMLElement -> bool
    
    and IFocusZoneProps =
        | ComponentRef of Func<IFocusZone, unit>
        | ClassName of string
        | Direction of FocusZoneDirection
        | DefaultActiveElement of string
        | Disabled of bool
        | ElementType of string
        interface IFabricProp
    
// makeHTMLProp
let FocusZone = importMember<Fable.Import.React.ComponentClass<FocusZoneProps.IFocusZoneProps>> "office-ui-fabric-react"
let inline focusZone b c = makeEl FocusZone b c

module CalloutProps =
    
    type ICallout =
        interface end
    
    and ICalloutProps =
        | ComponentRef of Func<ICallout, unit>
        | Target of U3<HTMLElement, string, MouseEvent>
        | DirectionalHint of DirectionalHint
        | DirectionalHintForRTL of DirectionalHint
        | GapSpace of float
        | BeakWidth of float
        | CalloutWidth of float
        | BackgroundColor of string
        | Bounds of IRectangle
        | MinPagePadding of float
        | UseTargetPoint of bool
        | TargetPoint of IPoint
        | IsBeakVisible of bool
        | PreventDismissOnScroll of bool
        | CoverTarget of bool
        | Role of string
        | AriaLabel of string
        | AriaLabelledBy of string
        | AriaDescribedBy of string
        | ClassName of string
        | OnLayerMounted of Func<unit, unit>
        | OnPositioned of Func<unit, unit>
        | OnDismiss of Func<obj, unit>
        | DoNotLayer of bool
        | DirectionalHintFixed of bool
        | FinalHeight of float
        | SetInitialFocus of bool
        | BeakStyle of string
        | TargetElement of HTMLElement
        interface IFabricProp
    
// makeHTMLProp
let Callout = importMember<Fable.Import.React.ComponentClass<CalloutProps.ICalloutProps>> "office-ui-fabric-react"
let inline callout b c = makeEl Callout b c


module ContextualMenuProps =
    
    type IContextualMenu =
        interface end
    
    and IContextualMenuProps =
        
        | ComponentRef of Func<IContextualMenu, unit>
        | Target of U3<HTMLElement, string, MouseEvent>
        | TargetElement of HTMLElement
        | DirectionalHint of DirectionalHint
        | DirectionalHintForRTL of DirectionalHint
        | GapSpace of float
        | BeakWidth of float
        | UseTargetWidth of bool
        | Bounds of IRectangle
        | UseTargetPoint of bool
        | TargetPoint of IPoint
        | IsBeakVisible of bool
        | CoverTarget of bool
        | Items of ResizeArray<IContextualMenuItem>
        | LabelElementId of string
        | ShouldFocusOnMount of bool
        | OnDismiss of Func<obj, bool, unit>
        | OnItemClick of Func<Fable.Import.React.MouseEvent, IContextualMenuItem, unit>
        | ClassName of string
        | IsSubMenu of bool
        | Id of string
        | AriaLabel of string
        | DoNotLayer of bool
        | ArrowDirection of FocusZoneProps.FocusZoneDirection
        | DirectionalHintFixed of bool
        | OnMenuOpened of Func<IContextualMenuProps, unit>
        | CalloutProps of CalloutProps.ICalloutProps
        | Title of string
        | Styles of IContextualMenuStyles
        | Theme of obj
        | OnRenderSubMenu of IRenderFunction<IContextualMenuProps>
        interface IFabricProp
    
    and IContextualMenuItem =
        | Key of string
        | Name of string
        | ItemType of ContextualMenuItemType
        | IconProps of IconProps.IIconProps
        | SubmenuIconProps of IconProps.IIconProps
        | Icon of string
        | Disabled of bool
        | IsDisabled of bool
        | ShortCut of string
        | CanCheck of bool
        | Checked of bool
        | IsChecked of bool
        | Data of obj
        | OnClick of Func<Fable.Import.React.MouseEvent, IContextualMenuItem, unit>
        | Href of string
        | Target of string
        | Items of ResizeArray<IContextualMenuItem>
        | SubMenuProps of IContextualMenuProps
        | SectionProps of IContextualMenuSection
        | ClassName of string
        | Style of HTMLAttr
        | AriaLabel of string
        | Title of string
        | OnRender of Func<obj, React.ReactElement>
        | OnMouseDown of Func<IContextualMenuItem, obj, unit>
        | Role of string
    
    and IContextualMenuSection =
        | Items of ResizeArray<IContextualMenuItem>
        | Title of string
        | TopDivider of bool
        | BottomDivider of bool
    
    and IContextualMenuStyles =
        | Title of Fable.Helpers.React.Props.HTMLAttr
    
// makeHTMLProp
let ContextualMenu = importMember<Fable.Import.React.ComponentClass<ContextualMenuProps.IContextualMenuProps>> "office-ui-fabric-react"
let inline contextualMenu b c = makeEl ContextualMenu b c
                        
let inline ContextualMenuStyle (css: ContextualMenuProps.IContextualMenuStyles list): HTMLAttr =
    !!("styles", keyValueList CaseRules.LowerFirst css)



module BreadcrumbProps =
    
    type IBreadcrumb =
        interface end
    
    and IBreadCrumbData = {
        props : IBreadcrumbProps
        renderedItems : IBreadcrumbItem[]
        renderedOverflowItems : IBreadcrumbItem[]
    }
    
    and IBreadcrumbProps =
        | ComponentRef of Func<IBreadcrumb, unit>
        | Items of ResizeArray<IBreadcrumbItem>
        | ClassName of string
        | MaxDisplayedItems of float
        | OnRenderItem of IRenderFunction<IBreadcrumbItem>
        | OnReduceData of Func<IBreadCrumbData, U2<IBreadCrumbData, unit>>
        | AriaLabel of string
        interface IFabricProp
    
    and IBreadcrumbItem =
        | Text of string
        | Key of string
        | OnClick of Func<Fable.Import.React.MouseEvent, IBreadcrumbItem, unit>
        | Href of string
        | IsCurrentItem of bool
    
// makeHTMLProp
let Breadcrumb = importMember<Fable.Import.React.ComponentClass<BreadcrumbProps.IBreadcrumbProps>> "office-ui-fabric-react"
let inline breadcrumb b c = makeEl Breadcrumb b c


module ButtonProps =
    type ElementType =
    /// <button> element.
    | Button = 0
    /// <a> element.
    | Anchor = 1
    type ButtonType =
    | Normal = 0
    | Primary = 1
    | Hero = 2
    | Compound = 3
    | Command = 4
    | Icon = 5
    | Default = 6

    type IButton =
        | Focus of Func<unit, unit>
        | DismissMenu of Func<unit, unit>
    
    and IButtonProps =
        | ComponentRef of Func<IButton, unit>
        | Href of string
        | Primary of bool
        | UniqueId of U2<string, float>
        | Disabled of bool
        | Styles of IButtonStyles
        | Theme of obj
        | Checked of bool
        | ClassName of string
        | AriaLabel of string
        | AriaDescription of string
        | Text of string
        | IconProps of IconProps.IIconProps
        | MenuProps of ContextualMenuProps.IContextualMenuProps
        | Split of bool
        | MenuIconProps of IconProps.IIconProps
        | OnRenderIcon of IRenderFunction<IButtonProps>
        | OnRenderText of IRenderFunction<IButtonProps>
        | OnRenderDescription of IRenderFunction<IButtonProps>
        | OnRenderAriaDescription of IRenderFunction<IButtonProps>
        | OnRenderChildren of IRenderFunction<IButtonProps>
        | OnRenderMenuIcon of IRenderFunction<IButtonProps>
        | OnRenderMenu of IRenderFunction<ContextualMenuProps.IContextualMenuProps>
        | Description of string
        | ButtonType of ButtonType
        | RootProps of U2<React.HTMLAttributes, React.HTMLAttributes>
        | Icon of string
        | MenuIconName of U3<Fable.Helpers.OfficeUIFabricReact.IconName, string, obj>
        | Null of obj
        | Toggled of bool
        | Data of obj
        interface IFabricProp
    
    and IButtonStyles =
        | Root of Fable.Helpers.React.Props.HTMLAttr
        | RootChecked of Fable.Helpers.React.Props.HTMLAttr
        | RootDisabled of Fable.Helpers.React.Props.HTMLAttr
        | RootHovered of Fable.Helpers.React.Props.HTMLAttr
        | RootFocused of Fable.Helpers.React.Props.HTMLAttr
        | RootPressed of Fable.Helpers.React.Props.HTMLAttr
        | RootExpanded of Fable.Helpers.React.Props.HTMLAttr
        | RootCheckedHovered of Fable.Helpers.React.Props.HTMLAttr
        | RootCheckedPressed of Fable.Helpers.React.Props.HTMLAttr
        | RootCheckedDisabled of Fable.Helpers.React.Props.HTMLAttr
        | RootExpandedHovered of Fable.Helpers.React.Props.HTMLAttr
        | FlexContainer of Fable.Helpers.React.Props.HTMLAttr
        | TextContainer of Fable.Helpers.React.Props.HTMLAttr
        | Icon of Fable.Helpers.React.Props.HTMLAttr
        | IconHovered of Fable.Helpers.React.Props.HTMLAttr
        | IconPressed of Fable.Helpers.React.Props.HTMLAttr
        | IconExpanded of Fable.Helpers.React.Props.HTMLAttr
        | IconExpandedHovered of Fable.Helpers.React.Props.HTMLAttr
        | IconDisabled of Fable.Helpers.React.Props.HTMLAttr
        | IconChecked of Fable.Helpers.React.Props.HTMLAttr
        | Label of Fable.Helpers.React.Props.HTMLAttr
        | LabelDisabled of Fable.Helpers.React.Props.HTMLAttr
        | LabelChecked of Fable.Helpers.React.Props.HTMLAttr
        | MenuIcon of Fable.Helpers.React.Props.HTMLAttr
        | MenuIconDisabled of Fable.Helpers.React.Props.HTMLAttr
        | MenuIconChecked of Fable.Helpers.React.Props.HTMLAttr
        | Description of Fable.Helpers.React.Props.HTMLAttr
        | DescriptionHovered of Fable.Helpers.React.Props.HTMLAttr
        | DescriptionPressed of Fable.Helpers.React.Props.HTMLAttr
        | DescriptionDisabled of Fable.Helpers.React.Props.HTMLAttr
        | DescriptionChecked of Fable.Helpers.React.Props.HTMLAttr
        | ScreenReaderText of Fable.Helpers.React.Props.HTMLAttr
        | SplitButtonContainer of Fable.Helpers.React.Props.HTMLAttr
        | SplitButtonContainerDisabled of Fable.Helpers.React.Props.HTMLAttr
        | SplitButtonDivider of Fable.Helpers.React.Props.HTMLAttr
        | SplitButtonMenuButton of Fable.Helpers.React.Props.HTMLAttr
        | SplitButtonMenuButtonDisabled of Fable.Helpers.React.Props.HTMLAttr
        | SplitButtonMenuButtonChecked of Fable.Helpers.React.Props.HTMLAttr
        | SplitButtonMenuButtonExpanded of Fable.Helpers.React.Props.HTMLAttr
        | SplitButtonMenuIcon of Fable.Helpers.React.Props.HTMLAttr
        | SplitButtonMenuIconDisabled of Fable.Helpers.React.Props.HTMLAttr
        | SplitButtonFlexContainer of Fable.Helpers.React.Props.HTMLAttr
    
// makeHTMLProp
let Button = importMember<Fable.Import.React.ComponentClass<ButtonProps.IButtonProps>> "office-ui-fabric-react"
let inline button b c = makeEl Button b c
                        
let inline ButtonStyle (css: ButtonProps.IButtonStyles list): HTMLAttr =
    !!("styles", keyValueList CaseRules.LowerFirst css)


module CalendarProps =
    
    type ICalendar =
        | Focus of Func<unit, unit>
    
    and ICalendarProps =
        | ComponentRef of Func<ICalendar, unit>
        | OnSelectDate of Func<DateTime, ResizeArray<DateTime>, unit>
        | OnDismiss of Func<unit, unit>
        | IsMonthPickerVisible of bool
        | IsDayPickerVisible of bool
        | ShowMonthPickerAsOverlay of bool
        | Today of DateTime
        | Value of DateTime
        | FirstDayOfWeek of DayOfWeek
        | DateRangeType of DateRangeType
        | AutoNavigateOnSelection of bool
        | ShowGoToToday of bool
        | ShouldFocusOnMount of bool
        | Strings of U2<ICalendarStrings, obj>
        | Null of obj
        | HighlightCurrentMonth of bool
        | NavigationIcons of ICalendarIconStrings
        | ShowWeekNumbers of bool
        | DateTimeFormatter of ICalendarFormatDateCallbacks
        interface IFabricProp
    
    and ICalendarStrings =
        | Months of ResizeArray<string>
        | ShortMonths of ResizeArray<string>
        | Days of ResizeArray<string>
        | ShortDays of ResizeArray<string>
        | GoToToday of string
        | PrevMonthAriaLabel of string
        | NextMonthAriaLabel of string
        | PrevYearAriaLabel of string
        | NextYearAriaLabel of string
    
    and ICalendarIconStrings =
        | LeftNavigation of string
        | RightNavigation of string
    
    and ICalendarFormatDateCallbacks =
        | FormatMonthDayYear of Func<DateTime, ICalendarStrings, string>
        | FormatMonthYear of Func<DateTime, ICalendarStrings, string>
        | FormatDay of Func<DateTime, string>
        | FormatYear of Func<DateTime, string>
    
// makeHTMLProp
let Calendar = importMember<Fable.Import.React.ComponentClass<CalendarProps.ICalendarProps>> "office-ui-fabric-react"
let inline calendar b c = makeEl Calendar b c

module CheckboxProps =
    
    type ICheckbox =
        | Checked of bool
        | Focus of Func<unit, unit>
    
    and ICheckboxProps =
        | ComponentRef of Func<ICheckbox, unit>
        | ClassName of string
        | Checked of bool
        | DefaultChecked of bool
        | Label of string
        | Disabled of bool
        | OnChange of Func<React.FormEvent<U2<HTMLElement, HTMLInputElement>>, bool, unit>
        | InputProps of React.ButtonHTMLAttributes<U2<HTMLElement, HTMLButtonElement>>
        | BoxSide of (* TODO StringEnum start | end *) string
        | Theme of ITheme
        | AriaLabel of string
        | AriaLabelledBy of string
        | AriaDescribedBy of string
        | Styles of ICheckboxStyles
        | OnRenderLabel of IRenderFunction<ICheckboxProps>
        interface IFabricProp
    
    and ICheckboxStyles =
        | Root of Fable.Helpers.React.Props.HTMLAttr
        | Label of Fable.Helpers.React.Props.HTMLAttr
        | LabelReversed of Fable.Helpers.React.Props.HTMLAttr
        | LabelDisabled of Fable.Helpers.React.Props.HTMLAttr
        | Checkbox of Fable.Helpers.React.Props.HTMLAttr
        | CheckboxHovered of Fable.Helpers.React.Props.HTMLAttr
        | CheckboxChecked of Fable.Helpers.React.Props.HTMLAttr
        | CheckboxCheckedHovered of Fable.Helpers.React.Props.HTMLAttr
        | CheckboxDisabled of Fable.Helpers.React.Props.HTMLAttr
        | CheckboxCheckedDisabled of Fable.Helpers.React.Props.HTMLAttr
        | Checkmark of Fable.Helpers.React.Props.HTMLAttr
        | CheckmarkChecked of Fable.Helpers.React.Props.HTMLAttr
        | CheckmarkDisabled of Fable.Helpers.React.Props.HTMLAttr
        | CheckmarkCheckedDisabled of Fable.Helpers.React.Props.HTMLAttr
        | Text of Fable.Helpers.React.Props.HTMLAttr
        | TextHovered of Fable.Helpers.React.Props.HTMLAttr
        | TextDisabled of Fable.Helpers.React.Props.HTMLAttr
    
// makeHTMLProp
let Checkbox = importMember<Fable.Import.React.ComponentClass<CheckboxProps.ICheckboxProps>> "office-ui-fabric-react"
let inline checkbox b c = makeEl Checkbox b c
                        
let inline CheckboxStyle (css: CheckboxProps.ICheckboxStyles list): HTMLAttr =
    !!("styles", keyValueList CaseRules.LowerFirst css)


module ChoiceGroupProps =
    
    type IChoiceGroup =
        interface end
    
    and IChoiceGroupProps =
        | ComponentRef of Func<IChoiceGroup, unit>
        | Options of ResizeArray<IChoiceGroupOption>
        | DefaultSelectedKey of U2<string, float>
        | SelectedKey of U2<string, float>
        | OnChange of Func<React.FormEvent<U2<HTMLElement, HTMLInputElement>>, IChoiceGroupOption, unit>
        | Label of string
        | OnChanged of Func<IChoiceGroupOption, React.FormEvent<U2<HTMLElement, HTMLInputElement>>, unit>
        interface IFabricProp
    
    and IChoiceGroupOption =
        | Key of string
        | Text of string
        | OnRenderField of IRenderFunction<IChoiceGroupOption>
        | OnRenderLabel of Func<IChoiceGroupOption, JSX.Element>
        | IconProps of IconProps.IIconProps
        | ImageSrc of string
        | SelectedImageSrc of string
        | ImageSize of obj
        | Disabled of bool
        | Checked of bool
        | Id of string
        | LabelId of string
    
// makeHTMLProp
let ChoiceGroup = importMember<Fable.Import.React.ComponentClass<ChoiceGroupProps.IChoiceGroupProps>> "office-ui-fabric-react"
let inline choiceGroup b c = makeEl ChoiceGroup b c


module ColorPickerProps =
    
    type IColorPickerProps =
        | ComponentRef of Func<unit, unit>
        | Color of string
        | OnColorChanged of Func<string, unit>
        | AlphaSliderHidden of bool
        interface IFabricProp
    
// makeHTMLProp
let ColorPicker = importMember<Fable.Import.React.ComponentClass<ColorPickerProps.IColorPickerProps>> "office-ui-fabric-react"
let inline colorPicker b c = makeEl ColorPicker b c


module ComboBoxProps =
    
    type IComboBox =
        abstract focus: unit -> bool
    
    and IComboBoxOption =
        
        | Styles of Partial<IComboBoxOptionStyles>
    
    and IComboBoxProps =
        
        | ComponentRef of Func<IComboBox, unit>
        | Options of ResizeArray<IComboBoxOption>
        | OnChanged of Func<IComboBoxOption, float, string, unit>
        | OnResolveOptions of Func<ResizeArray<IComboBoxOption>, U2<ResizeArray<IComboBoxOption>, PromiseLike<ResizeArray<IComboBoxOption>>>>
        | AllowFreeform of bool
        | AutoComplete of string
        | Value of string
        | ButtonIconProps of IconProps.IIconProps
        | Theme of ITheme
        | Styles of Partial<IComboBoxStyles>
        | CaretDownButtonStyles of Partial<IButtonStyles>
        | ComboBoxOptionStyles of Partial<IComboBoxOptionStyles>
        interface IFabricProp
    
    and IComboBoxStyles =
        | Container of Fable.Helpers.React.Props.HTMLAttr
        | Label of Fable.Helpers.React.Props.HTMLAttr
        | Root of Fable.Helpers.React.Props.HTMLAttr
        | RootError of Fable.Helpers.React.Props.HTMLAttr
        | RootDisallowFreeForm of Fable.Helpers.React.Props.HTMLAttr
        | RootHovered of Fable.Helpers.React.Props.HTMLAttr
        | RootFocused of Fable.Helpers.React.Props.HTMLAttr
        | RootDisabled of Fable.Helpers.React.Props.HTMLAttr
        | Input of Fable.Helpers.React.Props.HTMLAttr
        | InputDisabled of Fable.Helpers.React.Props.HTMLAttr
        | ErrorMessage of Fable.Helpers.React.Props.HTMLAttr
        | Callout of Fable.Helpers.React.Props.HTMLAttr
        | OptionsContainer of Fable.Helpers.React.Props.HTMLAttr
        | Header of Fable.Helpers.React.Props.HTMLAttr
        | Divider of Fable.Helpers.React.Props.HTMLAttr
    
    and IComboBoxOptionStyles =
            | RootChecked of Fable.Helpers.React.Props.HTMLAttr
    | RootDisabled of Fable.Helpers.React.Props.HTMLAttr
    | RootHovered of Fable.Helpers.React.Props.HTMLAttr
    | RootFocused of Fable.Helpers.React.Props.HTMLAttr
    | RootPressed of Fable.Helpers.React.Props.HTMLAttr
    | RootExpanded of Fable.Helpers.React.Props.HTMLAttr
    | RootCheckedHovered of Fable.Helpers.React.Props.HTMLAttr
    | RootCheckedPressed of Fable.Helpers.React.Props.HTMLAttr
    | RootCheckedDisabled of Fable.Helpers.React.Props.HTMLAttr
    | RootExpandedHovered of Fable.Helpers.React.Props.HTMLAttr
    | FlexContainer of Fable.Helpers.React.Props.HTMLAttr
    | TextContainer of Fable.Helpers.React.Props.HTMLAttr
    | Icon of Fable.Helpers.React.Props.HTMLAttr
    | IconHovered of Fable.Helpers.React.Props.HTMLAttr
    | IconPressed of Fable.Helpers.React.Props.HTMLAttr
    | IconExpanded of Fable.Helpers.React.Props.HTMLAttr
    | IconExpandedHovered of Fable.Helpers.React.Props.HTMLAttr
    | IconDisabled of Fable.Helpers.React.Props.HTMLAttr
    | IconChecked of Fable.Helpers.React.Props.HTMLAttr
    | Label of Fable.Helpers.React.Props.HTMLAttr
    | LabelDisabled of Fable.Helpers.React.Props.HTMLAttr
    | LabelChecked of Fable.Helpers.React.Props.HTMLAttr
    | MenuIcon of Fable.Helpers.React.Props.HTMLAttr
    | MenuIconDisabled of Fable.Helpers.React.Props.HTMLAttr
    | MenuIconChecked of Fable.Helpers.React.Props.HTMLAttr
    | Description of Fable.Helpers.React.Props.HTMLAttr
    | DescriptionHovered of Fable.Helpers.React.Props.HTMLAttr
    | DescriptionPressed of Fable.Helpers.React.Props.HTMLAttr
    | DescriptionDisabled of Fable.Helpers.React.Props.HTMLAttr
    | DescriptionChecked of Fable.Helpers.React.Props.HTMLAttr
    | ScreenReaderText of Fable.Helpers.React.Props.HTMLAttr
    | SplitButtonContainer of Fable.Helpers.React.Props.HTMLAttr
    | SplitButtonContainerDisabled of Fable.Helpers.React.Props.HTMLAttr
    | SplitButtonDivider of Fable.Helpers.React.Props.HTMLAttr
    | SplitButtonMenuButton of Fable.Helpers.React.Props.HTMLAttr
    | SplitButtonMenuButtonDisabled of Fable.Helpers.React.Props.HTMLAttr
    | SplitButtonMenuButtonChecked of Fable.Helpers.React.Props.HTMLAttr
    | SplitButtonMenuButtonExpanded of Fable.Helpers.React.Props.HTMLAttr
    | SplitButtonMenuIcon of Fable.Helpers.React.Props.HTMLAttr
    | SplitButtonMenuIconDisabled of Fable.Helpers.React.Props.HTMLAttr
    | SplitButtonFlexContainer of Fable.Helpers.React.Props.HTMLAttr



        | OptionText of Fable.Helpers.React.Props.HTMLAttr
    
// makeHTMLProp
let ComboBox = importMember<Fable.Import.React.ComponentClass<ComboBoxProps.IComboBoxProps>> "office-ui-fabric-react"
let inline comboBox b c = makeEl ComboBox b c
                        
let inline ComboBoxStyle (css: ComboBoxProps.IComboBoxStyles list): HTMLAttr =
    !!("styles", keyValueList CaseRules.LowerFirst css)
                        
let inline ComboBoxStyle (css: ComboBoxProps.IComboBoxOptionStyles list): HTMLAttr =
    !!("styles", keyValueList CaseRules.LowerFirst css)


module CommandBarProps =
    
    type ICommandBar =
        abstract focus: unit -> unit
    
    and ICommandBarProps =
        | ComponentRef of Func<ICommandBar, unit>
        | IsSearchBoxVisible of bool
        | SearchPlaceholderText of string
        | Items of ResizeArray<IContextualMenuItem>
        | OverflowItems of ResizeArray<IContextualMenuItem>
        | ElipisisAriaLabel of string
        | FarItems of ResizeArray<IContextualMenuItem>
        | ClassName of string
        interface IFabricProp
    
// makeHTMLProp
let CommandBar = importMember<Fable.Import.React.ComponentClass<CommandBarProps.ICommandBarProps>> "office-ui-fabric-react"
let inline commandBar b c = makeEl CommandBar b c

module DatePickerProps =
    
    type IDatePicker =
        interface end
    
    and IDatePickerProps =
        | ComponentRef of Func<IDatePicker, unit>
        | OnSelectDate of Func<U2<DateTime, obj>, unit>
        | Label of string
        | IsRequired of bool
        | Disabled of bool
        | AriaLabel of string
        | PickerAriaLabel of string
        | IsMonthPickerVisible of bool
        | ShowMonthPickerAsOverlay of bool
        | AllowTextInput of bool
        | DisableAutoFocus of bool
        | Placeholder of string
        | Value of DateTime
        | FormatDate of Func<DateTime, string>
        | ParseDateFromString of Func<string, U2<DateTime, obj>>
        | Null of obj
        | FirstDayOfWeek of DayOfWeek
        | Strings of IDatePickerStrings
        | HighlightCurrentMonth of bool
        | ShowWeekNumbers of bool
        | ShowGoToToday of bool
        | Borderless of bool
        | ClassName of string
        | DateTimeFormatter of ICalendarFormatDateCallbacks
        interface IFabricProp
    
    and IDatePickerStrings =
        | Months of ResizeArray<string>
        | ShortMonths of ResizeArray<string>
        | Days of ResizeArray<string>
        | ShortDays of ResizeArray<string>
        | GoToToday of string
        | IsRequiredErrorMessage of string
        | InvalidInputErrorMessage of string
        | PrevMonthAriaLabel of string
        | NextMonthAriaLabel of string
        | PrevYearAriaLabel of string
        | NextYearAriaLabel of string
    
// makeHTMLProp
let DatePicker = importMember<Fable.Import.React.ComponentClass<DatePickerProps.IDatePickerProps>> "office-ui-fabric-react"
let inline datePicker b c = makeEl DatePicker b c


module DetailsListProps =
    
    type IDetailsList =
        
        | ForceUpdate of Func<unit, unit>
    
    and IDetailsListProps =
        
        | ComponentRef of Func<IDetailsList, unit>
        | SetKey of string
        | Items of ResizeArray<obj>
        | ListProps of IListProps
        | InitialFocusedIndex of float
        | ClassName of string
        | Groups of ResizeArray<IGroup>
        | GroupProps of IGroupRenderProps
        | Selection of ISelection
        | SelectionMode of SelectionMode
        | SelectionPreservedOnEmptyClick of bool
        | LayoutMode of DetailsListLayoutMode
        | CheckboxVisibility of CheckboxVisibility
        | IsHeaderVisible of bool
        | Columns of ResizeArray<IColumn>
        | ConstrainMode of ConstrainMode
        | RowElementEventMap of ResizeArray<obj>
        | OnDidUpdate of Func<DetailsList, obj>
        | OnRowDidMount of Func<obj, float, unit>
        | OnRowWillUnmount of Func<obj, float, unit>
        | OnColumnHeaderClick of Func<Fable.Import.React.MouseEvent, IColumn, unit>
        | OnColumnHeaderContextMenu of Func<IColumn, Fable.Import.React.MouseEvent, unit>
        | OnColumnResize of Func<IColumn, float, unit>
        | OnItemInvoked of Func<obj, float, Event, unit>
        | OnItemContextMenu of Func<obj, float, Event, U2<unit, bool>>
        | OnRenderRow of IRenderFunction<IDetailsRowProps>
        | OnRenderItemColumn of Func<obj, float, IColumn, obj>
        | DragDropEvents of IDragDropEvents
        | OnRenderMissingItem of Func<float, React.ReactElement>
        | OnRenderDetailsHeader of IRenderFunction<IDetailsHeaderProps>
        | Viewport of IViewport
        | OnActiveItemChanged of Func<obj, float, Fable.Import.React.FocusEvent, unit>
        | AriaLabelForListHeader of string
        | AriaLabelForSelectAllCheckbox of string
        | AriaLabelForSelectionColumn of string
        | GetRowAriaLabel of Func<obj, string>
        | GetKey of Func<obj, float, string>
        | AriaLabel of string
        | CheckButtonAriaLabel of string
        | AriaLabelForGrid of string
        | ShouldApplyApplicationRole of bool
        | MinimumPixelsForDrag of float
        | Compact of bool
        | UsePageCache of bool
        | OnShouldVirtualize of Func<IListProps, bool>
        interface IFabricProp
    
    and IColumn =
        | Key of string
        | Name of string
        | FieldName of string
        | ClassName of string
        | MinWidth of float
        | AriaLabel of string
        | IsRowHeader of bool
        | MaxWidth of float
        | ColumnActionsMode of ColumnActionsMode
        | IconName of IconName
        | IsIconOnly of bool
        | IconClassName of string
        | IsCollapsable of bool
        | IsSorted of bool
        | IsSortedDescending of bool
        | IsResizable of bool
        | IsMultiline of bool
        | OnRender of Func<obj, float, IColumn, obj>
        | IsFiltered of bool
        | OnColumnClick of Func<Fable.Import.React.MouseEvent, IColumn, obj>
        | OnColumnContextMenu of Func<IColumn, Fable.Import.React.MouseEvent, obj>
        | IsGrouped of bool
        | Data of obj
        | CalculatedWidth of float
        | HeaderClassName of string
        | IsPadded of bool
    
// makeHTMLProp
let DetailsList = importMember<Fable.Import.React.ComponentClass<DetailsListProps.IDetailsListProps>> "office-ui-fabric-react"
let inline detailsList b c = makeEl DetailsList b c


module DialogProps =
    
    type IDialog =
        interface end
    
    and IDialogProps =
        
        
        | ComponentRef of Func<IDialog, unit>
        | DialogContentProps of IDialogContentProps
        | OnDismiss of Func<Fable.Import.React.MouseEvent, obj>
        | Hidden of bool
        | ModalProps of IModalProps
        | IsOpen of bool
        | IsDarkOverlay of bool
        | OnDismissed of Func<unit, obj>
        | IsBlocking of bool
        | ClassName of string
        | ContainerClassName of string
        | OnLayerDidMount of Func<unit, unit>
        | OnLayerMounted of Func<unit, unit>
        | Type of DialogType
        | Title of string
        | SubText of string
        | ContentClassName of string
        | TopButtonsProps of ResizeArray<IButtonProps>
        | AriaLabelledById of string
        | AriaDescribedById of string
        interface IFabricProp
    
// makeHTMLProp
let Dialog = importMember<Fable.Import.React.ComponentClass<DialogProps.IDialogProps>> "office-ui-fabric-react"
let inline dialog b c = makeEl Dialog b c


module DialogContentProps =
    
    type IDialogContent =
        interface end
    
    and IDialogContentProps =
        | ComponentRef of Func<IDialogContent, unit>
        | ShowCloseButton of bool
        | TopButtonsProps of ResizeArray<IButtonProps>
        | ClassName of string
        | OnDismiss of Func<Fable.Import.React.MouseEvent, obj>
        | SubTextId of string
        | SubText of string
        | TitleId of string
        | Title of string
        | ResponsiveMode of ResponsiveMode
        | CloseButtonAriaLabel of string
        | Type of DialogType
        interface IFabricProp
    
// makeHTMLProp
let DialogContent = importMember<Fable.Import.React.ComponentClass<DialogContentProps.IDialogContentProps>> "office-ui-fabric-react"
let inline dialogContent b c = makeEl DialogContent b c


module DocumentCardProps =
    
    type IDocumentCard =
        interface end
    
    and IDocumentCardProps =
        | ComponentRef of Func<IDocumentCard, unit>
        | Type of DocumentCardType
        | OnClick of Func<Fable.Import.React.SyntheticEvent, unit>
        | OnClickHref of string
        | ClassName of string
        | AccentColor of string
        interface IFabricProp
    
    and IDocumentCardPreviewProps =
        | ComponentRef of Func<unit, unit>
        | PreviewImages of ResizeArray<IDocumentCardPreviewImage>
        | GetOverflowDocumentCountText of Func<float, string>
        interface IFabricProp
    
    and IDocumentCardPreviewImage =
        | ComponentRef of Func<unit, unit>
        | Name of string
        | Url of string
        | PreviewImageSrc of string
        | ErrorImageSrc of string
        | IconSrc of string
        | Width of float
        | Height of float
        | ImageFit of ImageFit
        | AccentColor of string
        | PreviewIconProps of IconProps.IIconProps
    
    and IDocumentCardTitleProps =
        | ComponentRef of Func<unit, unit>
        | Title of string
        | ShouldTruncate of bool
        interface IFabricProp
    
    and IDocumentCardLocationProps =
        | ComponentRef of Func<unit, unit>
        | Location of string
        | LocationHref of string
        | OnClick of Func<Fable.Import.React.MouseEvent, unit>
        | AriaLabel of string
        interface IFabricProp
    
    and IDocumentCardActivityProps =
        | ComponentRef of Func<unit, unit>
        | Activity of string
        | People of ResizeArray<IDocumentCardActivityPerson>
        interface IFabricProp
    
    and IDocumentCardActivityPerson =
        | Name of string
        | ProfileImageSrc of string
        | Initials of string
        | InitialsColor of PersonaInitialsColor
    
    and IDocumentCardActionsProps =
        | ComponentRef of Func<unit, unit>
        | Actions of ResizeArray<IButtonProps>
        | Views of float
        interface IFabricProp
    
// makeHTMLProp
let DocumentCard = importMember<Fable.Import.React.ComponentClass<DocumentCardProps.IDocumentCardProps>> "office-ui-fabric-react"
let inline documentCard b c = makeEl DocumentCard b c
                        
// makeHTMLProp
let DocumentCard = importMember<Fable.Import.React.ComponentClass<DocumentCardProps.IDocumentCardPreviewProps>> "office-ui-fabric-react"
let inline documentCard b c = makeEl DocumentCard b c
                        
// makeHTMLProp
let DocumentCard = importMember<Fable.Import.React.ComponentClass<DocumentCardProps.IDocumentCardTitleProps>> "office-ui-fabric-react"
let inline documentCard b c = makeEl DocumentCard b c
                        
// makeHTMLProp
let DocumentCard = importMember<Fable.Import.React.ComponentClass<DocumentCardProps.IDocumentCardLocationProps>> "office-ui-fabric-react"
let inline documentCard b c = makeEl DocumentCard b c
                        
// makeHTMLProp
let DocumentCard = importMember<Fable.Import.React.ComponentClass<DocumentCardProps.IDocumentCardActivityProps>> "office-ui-fabric-react"
let inline documentCard b c = makeEl DocumentCard b c
                        
// makeHTMLProp
let DocumentCard = importMember<Fable.Import.React.ComponentClass<DocumentCardProps.IDocumentCardActionsProps>> "office-ui-fabric-react"
let inline documentCard b c = makeEl DocumentCard b c


module DropdownProps =
    
    type IDropdown =
        | Focus of Func<unit, unit>
    
    and IDropdownProps =
        
        | PlaceHolder of string
        | OnChanged of Func<IDropdownOption, float, unit>
        | OnRenderPlaceHolder of IRenderFunction<IDropdownProps>
        | OnRenderTitle of IRenderFunction<U2<IDropdownOption, ResizeArray<IDropdownOption>>>
        | OnRenderCaretDown of IRenderFunction<IDropdownProps>
        | DropdownWidth of float
        | ResponsiveMode of ResponsiveMode
        | MultiSelect of bool
        | DefaultSelectedKeys of U2<ResizeArray<string>, ResizeArray<float>>
        | SelectedKeys of U2<ResizeArray<string>, ResizeArray<float>>
        | MultiSelectDelimiter of string
        | IsDisabled of bool
        interface IFabricProp
    
    and IDropdownOption =
        
        | Data of obj
        | IsSelected of bool
    
// makeHTMLProp
let Dropdown = importMember<Fable.Import.React.ComponentClass<DropdownProps.IDropdownProps>> "office-ui-fabric-react"
let inline dropdown b c = makeEl Dropdown b c


module FacepileProps =
    
    type IFacepile =
        interface end
    
    and IFacepileProps =
        | ComponentRef of Func<IFacepile, unit>
        | Personas of ResizeArray<IFacepilePersona>
        | MaxDisplayablePersonas of float
        | PersonaSize of PersonaSize
        | AriaDescription of string
        | ShowAddButton of bool
        | AddButtonProps of IButtonProps
        | ChevronButtonProps of IButtonProps
        | OverflowButtonProps of IButtonProps
        | OverflowButtonType of OverflowButtonType
        | GetPersonaProps of Func<IFacepilePersona, IPersonaProps>
        | ClassName of string
        interface IFabricProp
    
    and IFacepilePersona =
        | PersonaName of string
        | ImageUrl of string
        | ImageInitials of string
        | InitialsColor of PersonaInitialsColor
        | OnClick of Func<Fable.Import.React.MouseEvent, IFacepilePersona, unit>
        | OnMouseMove of Func<Fable.Import.React.MouseEvent, IFacepilePersona, unit>
        | OnMouseOut of Func<Fable.Import.React.MouseEvent, IFacepilePersona, unit>
        | Data of obj
    
// makeHTMLProp
let Facepile = importMember<Fable.Import.React.ComponentClass<FacepileProps.IFacepileProps>> "office-ui-fabric-react"
let inline facepile b c = makeEl Facepile b c


module FocusTrapZoneProps =
    
    type IFocusTrapZone =
        | Focus of Func<unit, unit>
    
    and IFocusTrapZoneProps =
        | ComponentRef of Func<IFocusTrapZone, unit>
        | ElementToFocusOnDismiss of HTMLElement
        | AriaLabelledBy of string
        | IsClickableOutsideFocusTrap of bool
        | IgnoreExternalFocusing of bool
        | ForceFocusInsideTrap of bool
        | FirstFocusableSelector of string
        interface IFabricProp
    
// makeHTMLProp
let FocusTrapZone = importMember<Fable.Import.React.ComponentClass<FocusTrapZoneProps.IFocusTrapZoneProps>> "office-ui-fabric-react"
let inline focusTrapZone b c = makeEl FocusTrapZone b c



module GroupedListProps =
    
    type IGroupedList =
        
        | ForceUpdate of Func<unit, unit>
        | ToggleCollapseAll of Func<bool, unit>
    
    and IGroupedListProps =
        | ComponentRef of Func<IGroupedList, unit>
        | ClassName of string
        | DragDropEvents of IDragDropEvents
        | DragDropHelper of IDragDropHelper
        | EventsToRegister of ResizeArray<obj>
        | GroupProps of IGroupRenderProps
        | Groups of ResizeArray<IGroup>
        | Items of ResizeArray<obj>
        | ListProps of IListProps
        | OnRenderCell of Func<float, obj, float, React.ReactElement>
        | Selection of ISelection
        | SelectionMode of SelectionMode
        | Viewport of IViewport
        | OnGroupExpandStateChanged of Func<bool, unit>
        | UsePageCache of bool
        | OnShouldVirtualize of Func<IListProps, bool>
        interface IFabricProp
    
    and IGroup =
        | Key of string
        | Name of string
        | StartIndex of float
        | Count of float
        | Children of ResizeArray<IGroup>
        | Level of float
        | IsSelected of bool
        | IsCollapsed of bool
        | IsShowingAll of bool
        | IsDropEnabled of bool
        | Data of obj
        | AriaLabel of string
        | HasMoreData of bool
    
    and IGroupRenderProps =
        | IsAllGroupsCollapsed of bool
        | GetGroupItemLimit of Func<IGroup, float>
        | OnToggleCollapseAll of Func<bool, unit>
        | HeaderProps of IGroupDividerProps
        | ShowAllProps of IGroupDividerProps
        | FooterProps of IGroupDividerProps
        | OnRenderHeader of IRenderFunction<IGroupDividerProps>
        | OnRenderShowAll of IRenderFunction<IGroupDividerProps>
        | OnRenderFooter of IRenderFunction<IGroupDividerProps>
        | CollapseAllVisibility of CollapseAllVisibility
        | ShowEmptyGroups of bool
        interface IFabricProp
    
    and IGroupDividerProps =
        | ComponentRef of Func<unit, unit>
        | IsGroupLoading of Func<IGroup, bool>
        | LoadingText of string
        | Group of IGroup
        | GroupIndex of float
        | GroupLevel of float
        | Selected of bool
        | IsSelected of bool
        | Viewport of IViewport
        | SelectionMode of SelectionMode
        | FooterText of string
        | ShowAllLinkText of string
        | OnToggleSummarize of Func<IGroup, unit>
        | OnGroupHeaderClick of Func<IGroup, unit>
        | OnToggleCollapse of Func<IGroup, unit>
        | OnToggleSelectGroup of Func<IGroup, unit>
        | IsCollapsedGroupSelectVisible of bool
        interface IFabricProp
    
// makeHTMLProp
let GroupedList = importMember<Fable.Import.React.ComponentClass<GroupedListProps.IGroupedListProps>> "office-ui-fabric-react"
let inline groupedList b c = makeEl GroupedList b c
                        
// makeHTMLProp
let GroupedList = importMember<Fable.Import.React.ComponentClass<GroupedListProps.IGroupRenderProps>> "office-ui-fabric-react"
let inline groupedList b c = makeEl GroupedList b c
                        
// makeHTMLProp
let GroupedList = importMember<Fable.Import.React.ComponentClass<GroupedListProps.IGroupDividerProps>> "office-ui-fabric-react"
let inline groupedList b c = makeEl GroupedList b c


module ExpandingCardProps =
    
    type IExpandingCard =
        interface end
    
    and IExpandingCardProps =
        | ComponentRef of Func<IExpandingCard, unit>
        | RenderData of obj
        | OnRenderCompactCard of IRenderFunction<IExpandingCardProps>
        | OnRenderExpandedCard of IRenderFunction<IExpandingCardProps>
        | TargetElement of HTMLElement
        | OnEnter of Func<obj, unit>
        | OnLeave of Func<obj, unit>
        | CompactCardHeight of float
        | ExpandedCardHeight of float
        | Mode of ExpandingCardMode
        | Theme of ITheme
        | DirectionalHint of DirectionalHint
        | GapSpace of float
        | Styles of IExpandingCardStyles
        interface IFabricProp
    
    and IExpandingCardStyles =
        | Root of Fable.Helpers.React.Props.HTMLAttr
        | CompactCard of Fable.Helpers.React.Props.HTMLAttr
        | ExpandedCard of Fable.Helpers.React.Props.HTMLAttr
        | ExpandedCardScroll of Fable.Helpers.React.Props.HTMLAttr
    
// makeHTMLProp
let ExpandingCard = importMember<Fable.Import.React.ComponentClass<ExpandingCardProps.IExpandingCardProps>> "office-ui-fabric-react"
let inline expandingCard b c = makeEl ExpandingCard b c
                        
let inline ExpandingCardStyle (css: ExpandingCardProps.IExpandingCardStyles list): HTMLAttr =
    !!("styles", keyValueList CaseRules.LowerFirst css)


module HoverCardProps =
    
    type IHoverCard =
        interface end
    
    and IHoverCardProps =
        | ComponentRef of Func<IHoverCard, unit>
        | ExpandingCardProps of IExpandingCardProps
        | SetAriaDescribedBy of bool
        | CardOpenDelay of float
        | CardDismissDelay of float
        | ExpandedCardOpenDelay of float
        | Sticky of bool
        | InstantOpenOnClick of bool
        | Styles of IHoverCardStyles
        | Target of U2<HTMLElement, string>
        | OnCardVisible of Func<unit, unit>
        | OnCardHide of Func<unit, unit>
        interface IFabricProp
    
    and IHoverCardStyles =
        | Host of Fable.Helpers.React.Props.HTMLAttr
    
// makeHTMLProp
let HoverCard = importMember<Fable.Import.React.ComponentClass<HoverCardProps.IHoverCardProps>> "office-ui-fabric-react"
let inline hoverCard b c = makeEl HoverCard b c
                        
let inline HoverCardStyle (css: HoverCardProps.IHoverCardStyles list): HTMLAttr =
    !!("styles", keyValueList CaseRules.LowerFirst css)


module LabelProps =
    
    type ILabel =
        interface end
    
    and ILabelProps =
        | ComponentRef of Func<ILabel, unit>
        | Required of bool
        | Disabled of bool
        interface IFabricProp
    
// makeHTMLProp
let Label = importMember<Fable.Import.React.ComponentClass<LabelProps.ILabelProps>> "office-ui-fabric-react"
let inline label b c = makeEl Label b c


module LayerProps =
    
    type ILayer =
        interface end
    
    and ILayerProps =
        | ComponentRef of Func<ILayer, unit>
        | OnLayerMounted of Func<unit, unit>
        | OnLayerDidMount of Func<unit, unit>
        | OnLayerWillUnmount of Func<unit, unit>
        | HostId of string
        interface IFabricProp
    
// makeHTMLProp
let Layer = importMember<Fable.Import.React.ComponentClass<LayerProps.ILayerProps>> "office-ui-fabric-react"
let inline layer b c = makeEl Layer b c


module LayerHostProps =
    
    type ILayerHost =
        interface end
    
    and ILayerHostProps =
        | ComponentRef of Func<ILayerHost, unit>
        | Id of string
        interface IFabricProp
    
// makeHTMLProp
let LayerHost = importMember<Fable.Import.React.ComponentClass<LayerHostProps.ILayerHostProps>> "office-ui-fabric-react"
let inline layerHost b c = makeEl LayerHost b c


module LinkProps =
    
    type ILink =
        abstract focus: unit -> unit
    
    and ILinkProps =
        | ComponentRef of Func<ILink, unit>
        | Disabled of bool
        interface IFabricProp
    
// makeHTMLProp
let Link = importMember<Fable.Import.React.ComponentClass<LinkProps.ILinkProps>> "office-ui-fabric-react"
let inline link b c = makeEl Link b c


module ListProps =
    
    type IList =
        abstract scrollToIndex: index: float * ?measureItem: Func<float, float> -> unit
    
    and IListProps =
        | ComponentRef of Func<IList, unit>
        | ClassName of string
        | Items of ResizeArray<obj>
        | OnRenderCell of Func<obj, float, React.ReactElement>
        | OnPageAdded of Func<IPage, unit>
        | OnPageRemoved of Func<IPage, unit>
        | GetKey of Func<obj, float, string>
        | GetPageSpecification of Func<float, IRectangle, IPageSpecification>
        | GetItemCountForPage of Func<float, IRectangle, float>
        | GetPageHeight of Func<float, IRectangle, float>
        | GetPageStyle of Func<IPage, obj>
        | RenderedWindowsAhead of float
        | RenderedWindowsBehind of float
        | StartIndex of float
        | RenderCount of float
        | UsePageCache of bool
        | OnShouldVirtualize of Func<IListProps, bool>
        | Role of string
        | OnRenderPage of Func<IPageProps, IRenderFunction<IPageProps>, React.ReactElement>
        interface IFabricProp
    
    and IPage =
        | Key of string
        | Items of U2<ResizeArray<obj>, undefined>
        | StartIndex of float
        | ItemCount of float
        | Style of obj
        | Top of float
        | Height of float
        | Data of obj
    
    and IPageProps =
        | Role of string
        | Page of IPage
        interface IFabricProp
    
    and IPageSpecification =
        | ItemCount of float
        | Height of float
        | Data of obj
    
// makeHTMLProp
let List = importMember<Fable.Import.React.ComponentClass<ListProps.IListProps>> "office-ui-fabric-react"
let inline list b c = makeEl List b c
                        
// makeHTMLProp
let List = importMember<Fable.Import.React.ComponentClass<ListProps.IPageProps>> "office-ui-fabric-react"
let inline list b c = makeEl List b c


module MarqueeSelectionProps =
    
    type IMarqueeSelection =
        interface end
    
    and IMarqueeSelectionProps =
        | ComponentRef of Func<IMarqueeSelection, unit>
        | Selection of ISelection
        | RootProps of Fable.Helpers.React.Props.HTMLAttr
        | OnShouldStartSelection of Func<MouseEvent, bool>
        | IsEnabled of bool
        | IsDraggingConstrainedToRoot of bool
        interface IFabricProp
    
// makeHTMLProp
let MarqueeSelection = importMember<Fable.Import.React.ComponentClass<MarqueeSelectionProps.IMarqueeSelectionProps>> "office-ui-fabric-react"
let inline marqueeSelection b c = makeEl MarqueeSelection b c


module MessageBarProps =
    
    type IMessageBar =
        interface end
    
    and IMessageBarProps =
        | ComponentRef of Func<IMessageBar, unit>
        | MessageBarType of MessageBarType
        | Actions of JSX.Element
        | AriaLabel of string
        | OnDismiss of Func<React.MouseEvent<U4<HTMLButtonElement, BaseButton, HTMLAnchorElement, Button>>, obj>
        | IsMultiline of bool
        | DismissButtonAriaLabel of string
        interface IFabricProp
    
// makeHTMLProp
let MessageBar = importMember<Fable.Import.React.ComponentClass<MessageBarProps.IMessageBarProps>> "office-ui-fabric-react"
let inline messageBar b c = makeEl MessageBar b c


module ModalProps =
    
    type IModal =
        interface end
    
    and IModalProps =
        
        
        | ComponentRef of Func<IModal, unit>
        | IsOpen of bool
        | IsDarkOverlay of bool
        | OnDismiss of Func<Fable.Import.React.MouseEvent, obj>
        | OnDismissed of Func<unit, obj>
        | IsBlocking of bool
        | ClassName of string
        | ContainerClassName of string
        | OnLayerDidMount of Func<unit, unit>
        | TitleAriaId of string
        | SubtitleAriaId of string
        interface IFabricProp
    
// makeHTMLProp
let Modal = importMember<Fable.Import.React.ComponentClass<ModalProps.IModalProps>> "office-ui-fabric-react"
let inline modal b c = makeEl Modal b c


module NavProps =
    
    type INav =
        | SelectedKey of U2<string, undefined>
    
    and INavProps =
        | ComponentRef of Func<INav, unit>
        | Groups of U2<ResizeArray<INavLinkGroup>, obj>
        | Null of obj
        | ClassName of string
        | OnRenderLink of Function
        | OnLinkClick of Func<Fable.Import.React.MouseEvent, INavLink, unit>
        | IsOnTop of bool
        | InitialSelectedKey of string
        | SelectedKey of string
        | AriaLabel of string
        | ExpandButtonAriaLabel of string
        | ExpandedStateText of string
        | CollapsedStateText of string
        interface IFabricProp
    
    and INavLinkGroup =
        | Name of string
        | Links of ResizeArray<INavLink>
        | AutomationId of string
        | CollapseByDefault of bool
        | OnHeaderClick of Func<Fable.Import.React.MouseEvent, bool, unit>
    
    and INavLink =
        | Name of string
        | Url of string
        | Key of string
        | Links of ResizeArray<INavLink>
        | OnClick of Func<Fable.Import.React.MouseEvent, INavLink, unit>
        | Icon of string
        | IconClassName of string
        | EngagementName of string
        | AltText of string
        | AutomationId of string
        | IsExpanded of bool
        | AriaLabel of string
        | Title of string
        | Target of string
        | ParentId of string
        | ForceAnchor of bool
        [<Emit("$0[$1]{{=$2}}")>] | Item of propertyName: string -> obj
    
// makeHTMLProp
let Nav = importMember<Fable.Import.React.ComponentClass<NavProps.INavProps>> "office-ui-fabric-react"
let inline nav b c = makeEl Nav b c


module OverflowSetProps =
    
    type IOverflowSet =
        | Focus of Func<unit, unit>
    
    and IOverflowSetProps =
        | ComponentRef of Func<IOverflowSet, unit>
        | ClassName of string
        | Items of ResizeArray<IOverflowSetItemProps>
        | OverflowItems of ResizeArray<IOverflowSetItemProps>
        | OnRenderItem of Func<IOverflowSetItemProps, obj>
        | OnRenderOverflowButton of IRenderFunction<ResizeArray<obj>>
        interface IFabricProp
    
    and IOverflowSetItemProps =
        | Key of string
        [<Emit("$0[$1]{{=$2}}")>] | Item of propertyName: string -> obj
        interface IFabricProp
    
// makeHTMLProp
let OverflowSet = importMember<Fable.Import.React.ComponentClass<OverflowSetProps.IOverflowSetProps>> "office-ui-fabric-react"
let inline overflowSet b c = makeEl OverflowSet b c
                        
// makeHTMLProp
let OverflowSet = importMember<Fable.Import.React.ComponentClass<OverflowSetProps.IOverflowSetItemProps>> "office-ui-fabric-react"
let inline overflowSet b c = makeEl OverflowSet b c


module OverlayProps =
    
    type IOverlay =
        interface end
    
    and IOverlayProps =
        | ComponentRef of Func<IOverlay, unit>
        | IsDarkThemed of bool
        interface IFabricProp
    
// makeHTMLProp
let Overlay = importMember<Fable.Import.React.ComponentClass<OverlayProps.IOverlayProps>> "office-ui-fabric-react"
let inline overlay b c = makeEl Overlay b c


module PanelProps =
    
    type IPanel =
        | Open of Func<unit, unit>
        | Dismiss of Func<unit, unit>
    
    and IPanelProps =
        | ComponentRef of Func<IPanel, unit>
        | IsOpen of bool
        | HasCloseButton of bool
        | IsLightDismiss of bool
        | IsBlocking of bool
        | IsFooterAtBottom of bool
        | HeaderText of string
        | OnDismiss of Func<unit, unit>
        | OnDismissed of Func<unit, unit>
        | ClassName of string
        | Type of PanelType
        | CustomWidth of string
        | CloseButtonAriaLabel of string
        | HeaderClassName of string
        | ElementToFocusOnDismiss of HTMLElement
        | IgnoreExternalFocusing of bool
        | ForceFocusInsideTrap of bool
        | FirstFocusableSelector of string
        | LayerProps of ILayerProps
        | OnRenderNavigation of IRenderFunction<IPanelProps>
        | OnRenderHeader of IRenderFunction<IPanelProps>
        | OnRenderBody of IRenderFunction<IPanelProps>
        | OnRenderFooter of IRenderFunction<IPanelProps>
        | OnRenderFooterContent of IRenderFunction<IPanelProps>
        | ComponentId of string
        interface IFabricProp
    
// makeHTMLProp
let Panel = importMember<Fable.Import.React.ComponentClass<PanelProps.IPanelProps>> "office-ui-fabric-react"
let inline panel b c = makeEl Panel b c



module PivotProps =
    
    type IPivot =
        interface end
    
    and IPivotProps =
        | ComponentRef of Func<IPivot, unit>
        | InitialSelectedIndex of float
        | InitialSelectedKey of string
        | SelectedKey of string
        | OnLinkClick of Func<PivotItem, Fable.Import.React.MouseEvent, unit>
        | LinkSize of PivotLinkSize
        | LinkFormat of PivotLinkFormat
        | HeadersOnly of bool
        | GetTabId of Func<string, float, string>
        interface IFabricProp
    
// makeHTMLProp
let Pivot = importMember<Fable.Import.React.ComponentClass<PivotProps.IPivotProps>> "office-ui-fabric-react"
let inline pivot b c = makeEl Pivot b c


module PivotItemProps =
    
    type IPivotItemProps =
        | ComponentRef of Func<unit, unit>
        | LinkText of string
        | ItemKey of string
        | AriaLabel of string
        | ItemCount of float
        | ItemIcon of string
        | OnRenderItemLink of IRenderFunction<IPivotItemProps>
        interface IFabricProp
    
// makeHTMLProp
let PivotItem = importMember<Fable.Import.React.ComponentClass<PivotItemProps.IPivotItemProps>> "office-ui-fabric-react"
let inline pivotItem b c = makeEl PivotItem b c


module PopupProps =
    
    type IPopup =
        interface end
    
    and IPopupProps =
        | ComponentRef of Func<IPopup, unit>
        | Role of string
        | AriaLabel of string
        | AriaLabelledBy of string
        | AriaDescribedBy of string
        | OnDismiss of Func<U2<Fable.Import.React.MouseEvent, Fable.Import.React.KeyboardEvent>, obj>
        | ClassName of string
        | ShouldRestoreFocus of bool
        interface IFabricProp
    
// makeHTMLProp
let Popup = importMember<Fable.Import.React.ComponentClass<PopupProps.IPopupProps>> "office-ui-fabric-react"
let inline popup b c = makeEl Popup b c


module ProgressIndicatorProps =
    
    type IProgressIndicator =
        interface end
    
    and IProgressIndicatorProps =
        | ComponentRef of Func<IProgressIndicator, unit>
        | ClassName of string
        | Label of string
        | Description of string
        | PercentComplete of float
        | AriaValueText of string
        | Title of string
        interface IFabricProp
    
// makeHTMLProp
let ProgressIndicator = importMember<Fable.Import.React.ComponentClass<ProgressIndicatorProps.IProgressIndicatorProps>> "office-ui-fabric-react"
let inline progressIndicator b c = makeEl ProgressIndicator b c


module RatingProps =
    
    type IRating =
        interface end
    
    and IRatingProps =
        | ComponentRef of Func<IRating, unit>
        | Rating of float
        | Min of float
        | Max of float
        | Icon of string
        | Size of RatingSize
        | OnChanged of Func<float, unit>
        | AriaLabelIcon of string
        | AriaLabelId of string
        interface IFabricProp
    
// makeHTMLProp
let Rating = importMember<Fable.Import.React.ComponentClass<RatingProps.IRatingProps>> "office-ui-fabric-react"
let inline rating b c = makeEl Rating b c


module ResizeGroupProps =
    
    type IResizeGroup =
        interface end
    
    and IResizeGroupProps =
        | ComponentRef of Func<IResizeGroup, unit>
        | Data of obj
        | OnRenderData of Func<obj, JSX.Element>
        | OnReduceData of Func<obj, obj>
        | OnGrowData of Func<obj, obj>
        | DataDidRender of Func<obj, unit>
        interface IFabricProp
    
// makeHTMLProp
let ResizeGroup = importMember<Fable.Import.React.ComponentClass<ResizeGroupProps.IResizeGroupProps>> "office-ui-fabric-react"
let inline resizeGroup b c = makeEl ResizeGroup b c


module ScrollablePaneProps =
    
    type IScrollablePaneProps =
        | ComponentRef of Func<IScrollablePaneProps, unit>
        | ClassName of string
        interface IFabricProp
    
// makeHTMLProp
let ScrollablePane = importMember<Fable.Import.React.ComponentClass<ScrollablePaneProps.IScrollablePaneProps>> "office-ui-fabric-react"
let inline scrollablePane b c = makeEl ScrollablePane b c


module SearchBoxProps =
    
    type ISearchBox =
        abstract focus: unit -> unit
    
    and ISearchBoxProps =
        | ComponentRef of Func<ISearchBox, unit>
        | LabelText of string
        | OnChange of Func<obj, unit>
        | OnSearch of Func<obj, unit>
        | OnClear of Func<obj, unit>
        | OnEscape of Func<obj, unit>
        | OnChanged of Func<obj, unit>
        | Value of string
        | ClassName of string
        | AriaLabel of string
        interface IFabricProp
    
// makeHTMLProp
let SearchBox = importMember<Fable.Import.React.ComponentClass<SearchBoxProps.ISearchBoxProps>> "office-ui-fabric-react"
let inline searchBox b c = makeEl SearchBox b c


module SliderProps =
    
    type ISlider =
        | Value of U2<float, undefined>
        | Focus of Func<unit, unit>
    
    and ISliderProps =
        | ComponentRef of Func<ISlider, unit>
        | Label of string
        | DefaultValue of float
        | Value of float
        | Min of float
        | Max of float
        | Step of float
        | ShowValue of bool
        | OnChange of Func<float, unit>
        | AriaLabel of string
        | Vertical of bool
        | Disabled of bool
        | ClassName of string
        | ButtonProps of Fable.Helpers.React.Props.HTMLAttr
        interface IFabricProp
    
// makeHTMLProp
let Slider = importMember<Fable.Import.React.ComponentClass<SliderProps.ISliderProps>> "office-ui-fabric-react"
let inline slider b c = makeEl Slider b c


module SpinButtonProps =
    
    type ISpinButton =
        | Value of string
        | Focus of Func<unit, unit>
    
    and ISpinButtonProps =
        | ComponentRef of Func<ISpinButton, unit>
        | DefaultValue of string
        | Value of string
        | Min of float
        | Max of float
        | Step of float
        | AriaLabel of string
        | Title of string
        | Disabled of bool
        | ClassName of string
        | Label of string
        | LabelPosition of Position
        | IconProps of IconProps.IIconProps
        | OnValidate of Func<string, U2<string, unit>>
        | OnIncrement of Func<string, U2<string, unit>>
        | OnDecrement of Func<string, U2<string, unit>>
        | OnFocus of Fable.Import.React.FocusEventHandler
        | OnBlur of Fable.Import.React.FocusEventHandler
        | IncrementButtonIcon of IconProps.IIconProps
        | DecrementButtonIcon of IconProps.IIconProps
        | Styles of Partial<ISpinButtonStyles>
        | UpArrowButtonStyles of Partial<IButtonStyles>
        | DownArrowButtonStyles of Partial<IButtonStyles>
        | Theme of ITheme
        interface IFabricProp
    
    and ISpinButtonStyles =
        | Root of Fable.Helpers.React.Props.HTMLAttr
        | LabelWrapper of Fable.Helpers.React.Props.HTMLAttr
        | LabelWrapperStart of Fable.Helpers.React.Props.HTMLAttr
        | LabelWrapperEnd of Fable.Helpers.React.Props.HTMLAttr
        | LabelWrapperTop of Fable.Helpers.React.Props.HTMLAttr
        | LabelWrapperBottom of Fable.Helpers.React.Props.HTMLAttr
        | Icon of Fable.Helpers.React.Props.HTMLAttr
        | Label of Fable.Helpers.React.Props.HTMLAttr
        | SpinButtonWrapper of Fable.Helpers.React.Props.HTMLAttr
        | SpinButtonWrapperTopBottom of Fable.Helpers.React.Props.HTMLAttr
        | SpinButtonWrapperHovered of Fable.Helpers.React.Props.HTMLAttr
        | SpinButtonWrapperFocused of Fable.Helpers.React.Props.HTMLAttr
        | SpinButtonWrapperDisabled of Fable.Helpers.React.Props.HTMLAttr
        | Input of Fable.Helpers.React.Props.HTMLAttr
        | InputTextSelected of Fable.Helpers.React.Props.HTMLAttr
        | InputDisabled of Fable.Helpers.React.Props.HTMLAttr
        | ArrowButtonsContainer of Fable.Helpers.React.Props.HTMLAttr
        | ArrowButtonsContainerDisabled of Fable.Helpers.React.Props.HTMLAttr
    
// makeHTMLProp
let SpinButton = importMember<Fable.Import.React.ComponentClass<SpinButtonProps.ISpinButtonProps>> "office-ui-fabric-react"
let inline spinButton b c = makeEl SpinButton b c
                        
let inline SpinButtonStyle (css: SpinButtonProps.ISpinButtonStyles list): HTMLAttr =
    !!("styles", keyValueList CaseRules.LowerFirst css)


module SpinnerProps =
    
    type ISpinner =
        interface end
    
    and ISpinnerProps =
        | ComponentRef of Func<ISpinner, unit>
        | Type of SpinnerType
        | Size of SpinnerSize
        | Label of string
        | ClassName of string
        | AriaLive of (* TODO StringEnum assertive | polite | off *) string
        | AriaLabel of string
        interface IFabricProp
    
// makeHTMLProp
let Spinner = importMember<Fable.Import.React.ComponentClass<SpinnerProps.ISpinnerProps>> "office-ui-fabric-react"
let inline spinner b c = makeEl Spinner b c


module StickyProps =
    
    type IStickyProps =
        | ComponentRef of Func<IStickyProps, unit>
        | StickyClassName of string
        | StickyPosition of StickyPositionType
        interface IFabricProp
    
// makeHTMLProp
let Sticky = importMember<Fable.Import.React.ComponentClass<StickyProps.IStickyProps>> "office-ui-fabric-react"
let inline sticky b c = makeEl Sticky b c


module SwatchColorPickerProps =
    
    type ISwatchColorPicker =
        interface end
    
    and ISwatchColorPickerProps =
        | ComponentRef of Func<ISwatchColorPicker, unit>
        | ColumnCount of float
        | Id of string
        | ClassName of string
        | CellShape of (* TODO StringEnum circle | square *) string
        | SelectedId of string
        | ColorCells of ResizeArray<IColorCellProps>
        | OnColorChanged of Func<string, string, unit>
        | OnCellHovered of Func<string, string, unit>
        | OnCellFocused of Func<string, string, unit>
        | Disabled of bool
        | PositionInSet of float
        | SetSize of float
        | ShouldFocusCircularNavigate of bool
        interface IFabricProp
    
    and IColorCellProps =
        | Id of string
        | Label of string
        | Color of string
        | Index of float
        interface IFabricProp
    
// makeHTMLProp
let SwatchColorPicker = importMember<Fable.Import.React.ComponentClass<SwatchColorPickerProps.ISwatchColorPickerProps>> "office-ui-fabric-react"
let inline swatchColorPicker b c = makeEl SwatchColorPicker b c
                        
// makeHTMLProp
let SwatchColorPicker = importMember<Fable.Import.React.ComponentClass<SwatchColorPickerProps.IColorCellProps>> "office-ui-fabric-react"
let inline swatchColorPicker b c = makeEl SwatchColorPicker b c


module TeachingBubbleProps =
    
    type ITeachingBubble =
        interface end
    
    and ITeachingBubbleProps =
        
        | ComponentRef of Func<ITeachingBubble, unit>
        | CalloutProps of ICalloutProps
        | Headline of string
        | HasCondensedHeadline of bool
        | HasCloseIcon of bool
        | IllustrationImage of IImageProps
        | PrimaryButtonProps of IButtonProps
        | SecondaryButtonProps of IButtonProps
        | TargetElement of HTMLElement
        | OnDismiss of Func<obj, unit>
        interface IFabricProp
    
// makeHTMLProp
let TeachingBubble = importMember<Fable.Import.React.ComponentClass<TeachingBubbleProps.ITeachingBubbleProps>> "office-ui-fabric-react"
let inline teachingBubble b c = makeEl TeachingBubble b c


module TextFieldProps =
    
    type ITextField =
        | Value of U2<string, undefined>
        | Focus of Func<unit, unit>
        | Select of Func<unit, unit>
        | SetSelectionStart of Func<float, unit>
        | SetSelectionEnd of Func<float, unit>
        | SetSelectionRange of Func<float, float, unit>
        | SelectionStart of float
        | SelectionEnd of float
    
    and ITextFieldProps =
        | ComponentRef of Func<ITextField, unit>
        | Multiline of bool
        | Resizable of bool
        | AutoAdjustHeight of bool
        | Underlined of bool
        | Borderless of bool
        | Label of string
        | Description of string
        | AddonString of string
        | OnRenderAddon of IRenderFunction<ITextFieldProps>
        | IconProps of IconProps.IIconProps
        | DefaultValue of string
        | Value of string
        | Disabled of bool
        | ErrorMessage of string
        | OnChanged of Func<obj, unit>
        | OnBeforeChange of Func<obj, unit>
        | OnNotifyValidationResult of Func<string, U2<string, undefined>, unit>
        | OnGetErrorMessage of Func<string, U3<string, PromiseLike<string>, undefined>>
        | DeferredValidationTime of float
        | ClassName of string
        | InputClassName of string
        | AriaLabel of string
        | ValidateOnFocusIn of bool
        | ValidateOnFocusOut of bool
        | ValidateOnLoad of bool
        | IconClass of string
        interface IFabricProp
    
// makeHTMLProp
let TextField = importMember<Fable.Import.React.ComponentClass<TextFieldProps.ITextFieldProps>> "office-ui-fabric-react"
let inline textField b c = makeEl TextField b c


module ToggleProps =
    
    type IToggle =
        | Focus of Func<unit, unit>
    
    and IToggleProps =
        | ComponentRef of Func<IToggle, unit>
        | Label of string
        | OnText of string
        | OffText of string
        | OnAriaLabel of string
        | OffAriaLabel of string
        | Checked of bool
        | DefaultChecked of bool
        | Disabled of bool
        | OnChanged of Func<bool, unit>
        | Theme of ITheme
        | Styles of IToggleStyles
        interface IFabricProp
    
    and IToggleStyles =
        | Root of Fable.Helpers.React.Props.HTMLAttr
        | Label of Fable.Helpers.React.Props.HTMLAttr
        | Container of Fable.Helpers.React.Props.HTMLAttr
        | Pill of Fable.Helpers.React.Props.HTMLAttr
        | PillChecked of Fable.Helpers.React.Props.HTMLAttr
        | PillHovered of Fable.Helpers.React.Props.HTMLAttr
        | PillCheckedHovered of Fable.Helpers.React.Props.HTMLAttr
        | PillDisabled of Fable.Helpers.React.Props.HTMLAttr
        | PillCheckedDisabled of Fable.Helpers.React.Props.HTMLAttr
        | Thumb of Fable.Helpers.React.Props.HTMLAttr
        | ThumbHovered of Fable.Helpers.React.Props.HTMLAttr
        | ThumbChecked of Fable.Helpers.React.Props.HTMLAttr
        | ThumbCheckedHovered of Fable.Helpers.React.Props.HTMLAttr
        | ThumbDisabled of Fable.Helpers.React.Props.HTMLAttr
        | ThumbCheckedDisabled of Fable.Helpers.React.Props.HTMLAttr
        | Text of Fable.Helpers.React.Props.HTMLAttr
    
// makeHTMLProp
let Toggle = importMember<Fable.Import.React.ComponentClass<ToggleProps.IToggleProps>> "office-ui-fabric-react"
let inline toggle b c = makeEl Toggle b c
                        
let inline ToggleStyle (css: ToggleProps.IToggleStyles list): HTMLAttr =
    !!("styles", keyValueList CaseRules.LowerFirst css)


module TooltipProps =
    
    type ITooltip =
        interface end
    
    and ITooltipProps =
        | ComponentRef of Func<ITooltip, unit>
        | CalloutProps of ICalloutProps
        | Content of string
        | OnRenderContent of IRenderFunction<ITooltipProps>
        | Delay of TooltipDelay
        | MaxWidth of U2<string, obj>
        | Null of obj
        | TargetElement of HTMLElement
        | DirectionalHint of DirectionalHint
        | DirectionalHintForRTL of DirectionalHint
        interface IFabricProp
    
// makeHTMLProp
let Tooltip = importMember<Fable.Import.React.ComponentClass<TooltipProps.ITooltipProps>> "office-ui-fabric-react"
let inline tooltip b c = makeEl Tooltip b c


module TooltipHostProps =
    
    type ITooltipHost =
        interface end
    
    and ITooltipHostProps =
        | ComponentRef of Func<ITooltipHost, unit>
        | CalloutProps of ICalloutProps
        | TooltipProps of ITooltipProps
        | SetAriaDescribedBy of bool
        | Delay of TooltipDelay
        | Content of string
        | DirectionalHint of DirectionalHint
        | DirectionalHintForRTL of DirectionalHint
        | OverflowMode of TooltipOverflowMode
        | HostClassName of string
        abstract onTooltipToggle: isTooltipVisible: bool -> unit
        interface IFabricProp
    
// makeHTMLProp
let TooltipHost = importMember<Fable.Import.React.ComponentClass<TooltipHostProps.ITooltipHostProps>> "office-ui-fabric-react"
let inline tooltipHost b c = makeEl TooltipHost b c


module BasePickerProps =
    
    type IBasePicker<'T> =
        | Items of U2<ResizeArray<'T>, undefined>
        | Focus of Func<unit, unit>
    
    and IBasePickerProps<'T> =
        | ComponentRef of Func<IBasePicker<'T>, unit>
        | OnRenderItem of Func<IPickerItemProps<'T>, JSX.Element>
        | OnRenderSuggestionsItem of Func<'T, obj, JSX.Element>
        | OnResolveSuggestions of Func<string, ResizeArray<'T>, U2<ResizeArray<'T>, PromiseLike<ResizeArray<'T>>>>
        | OnEmptyInputFocus of Func<ResizeArray<'T>, U2<ResizeArray<'T>, PromiseLike<ResizeArray<'T>>>>
        | DefaultSelectedItems of ResizeArray<'T>
        | OnChange of Func<ResizeArray<'T>, unit>
        | OnFocus of React.FocusEventHandler<U2<HTMLInputElement, BaseAutoFill>>
        | OnBlur of React.FocusEventHandler<U2<HTMLInputElement, BaseAutoFill>>
        | GetTextFromItem of Func<'T, string, string>
        | OnGetMoreResults of Func<string, ResizeArray<'T>, U2<ResizeArray<'T>, PromiseLike<ResizeArray<'T>>>>
        | ClassName of string
        | PickerSuggestionsProps of IBasePickerSuggestionsProps
        | InputProps of IInputProps
        | OnRemoveSuggestion of Func<IPersonaProps, unit>
        | OnValidateInput of Func<string, ValidationState>
        | SearchingText of U2<Func<obj, string>, string>
        | Disabled of bool
        | ItemLimit of float
        | CreateGenericItem of Func<string, ValidationState, ISuggestionModel<'T>>
        | RemoveButtonAriaLabel of string
        | OnItemSelected of Func<'T, U2<'T, PromiseLike<'T>>>
        | SelectedItems of ResizeArray<'T>
    
    and IBasePickerSuggestionsProps =
        | OnRenderNoResultFound of IRenderFunction<unit>
        | SuggestionsHeaderText of string
        | MostRecentlyUsedHeaderText of string
        | NoResultsFoundText of string
        | ClassName of string
        | SuggestionsClassName of string
        | SuggestionsItemClassName of string
        | SearchForMoreText of string
        | LoadingText of string
        | SearchingText of string
        | ResultsFooterFull of Func<unit, JSX.Element>
        | ResultsFooter of Func<unit, JSX.Element>
        | ResultsMaximumNumber of float
        | ShowRemoveButtons of bool
        | SuggestionsAvailableAlertText of string
        interface IFabricProp
    
    and IInputProps =
        abstract ``aria-label``: string option with get, set
        interface IFabricProp
    
// makeHTMLProp
let BasePicker = importMember<Fable.Import.React.ComponentClass<BasePickerProps.IBasePickerSuggestionsProps>> "office-ui-fabric-react"
let inline basePicker b c = makeEl BasePicker b c
                        
// makeHTMLProp
let BasePicker = importMember<Fable.Import.React.ComponentClass<BasePickerProps.IInputProps>> "office-ui-fabric-react"
let inline basePicker b c = makeEl BasePicker b c


module PickerItemProps =
    
    type IPickerItemProps<'T> =
        | ComponentRef of Func<unit, unit>
        | Item of 'T
        | Index of float
        | Selected of bool
        | OnRemoveItem of Func<unit, unit>
        | OnItemChange of Func<'T, float, unit>
        | Key of U2<string, float>
        | RemoveButtonAriaLabel of string
    



module BaseAutoFillProps =
    
    type IBaseAutoFill =
        | CursorLocation of float
        | IsValueSelected of bool
        | Value of string
        | SelectionStart of float
        | SelectionEnd of float
        | InputElement of HTMLInputElement
        abstract focus: unit -> unit
        abstract clear: unit -> unit
    
    and IBaseAutoFillProps =
        | ComponentRef of Func<IBaseAutoFill, unit>
        | SuggestedDisplayValue of string
        | OnInputValueChange of Func<string, unit>
        | EnableAutoFillOnKeyPress of ResizeArray<KeyCodes>
        | DefaultVisibleValue of string
        | UpdateValueInWillReceiveProps of Func<unit, U2<string, obj>>
        | Null of obj
        | ShouldSelectFullInputValueInComponentDidUpdate of Func<unit, bool>
        interface IFabricProp
    
// makeHTMLProp
let BaseAutoFill = importMember<Fable.Import.React.ComponentClass<BaseAutoFillProps.IBaseAutoFillProps>> "office-ui-fabric-react"
let inline baseAutoFill b c = makeEl BaseAutoFill b c


module SuggestionsProps =
    
    type ISuggestionsProps<'T> =
        | ComponentRef of Func<unit, unit>
        | OnRenderSuggestion of Func<'T, 'T, JSX.Element>
        | OnSuggestionClick of Func<Fable.Import.React.MouseEvent, obj, float, unit>
        | Suggestions of ResizeArray<ISuggestionModel<'T>>
        | OnRenderNoResultFound of IRenderFunction<unit>
        | SuggestionsHeaderText of string
        | MostRecentlyUsedHeaderText of string
        | SearchForMoreText of string
        | OnGetMoreResults of Func<unit, unit>
        | ClassName of string
        | SearchErrorText of string
        | NoResultsFoundText of string
        | SuggestionsItemClassName of string
        | MoreSuggestionsAvailable of bool
        | IsLoading of bool
        | IsSearching of bool
        | LoadingText of string
        | SearchingText of string
        | IsMostRecentlyUsedVisible of bool
        | OnSuggestionRemove of Func<Fable.Import.React.MouseEvent, IPersonaProps, float, unit>
        | IsResultsFooterVisible of bool
        | ResultsMaximumNumber of float
        | ResultsFooterFull of Func<ISuggestionsProps<'T>, JSX.Element>
        | ResultsFooter of Func<ISuggestionsProps<'T>, JSX.Element>
        | ShowRemoveButtons of bool
        | SuggestionsAvailableAlertText of string
        | RefocusSuggestions of Func<KeyCodes, unit>
    
    and ISuggestionItemProps<'T> =
        | ComponentRef of Func<unit, unit>
        | SuggestionModel of ISuggestionModel<'T>
        | RenderSuggestion of Func<'T, ISuggestionItemProps<'T>, JSX.Element>
        | OnClick of Func<Fable.Import.React.MouseEvent, unit>
        | OnRemoveItem of Func<Fable.Import.React.MouseEvent, unit>
        | ClassName of string
        | Id of string
        | ShowRemoveButton of bool
    



module PeoplePickerItemProps =
    
    type IPeoplePickerItemProps =
        
        interface IFabricProp
    
    
    and IPeoplePickerItemWithMenuProps =
        
        | Item of IPersonaWithMenu
        interface IFabricProp
    
    and IPersonaWithMenu =
            | ComponentRef of Func<IPersona, unit>
    | PrimaryText of string
    | OnRenderPrimaryText of IRenderFunction<IPersonaProps>
    | Size of PersonaSize
    | ImageShouldFadeIn of bool
    | ImageShouldStartVisible of bool
    | ImageUrl of string
    | ImageAlt of string
    | ImageInitials of string
    | OnRenderInitials of IRenderFunction<IPersonaProps>
    | InitialsColor of PersonaInitialsColor
    | Presence of PersonaPresence
    | SecondaryText of string
    | OnRenderSecondaryText of IRenderFunction<IPersonaProps>
    | TertiaryText of string
    | OnRenderTertiaryText of IRenderFunction<IPersonaProps>
    | OptionalText of string
    | OnRenderOptionalText of IRenderFunction<IPersonaProps>
    | HidePersonaDetails of bool
    | ClassName of string
    | ShowSecondaryText of bool



        | MenuItems of ResizeArray<IContextualMenuItem>
    
// makeHTMLProp
let PeoplePickerItem = importMember<Fable.Import.React.ComponentClass<PeoplePickerItemProps.IPeoplePickerItemProps>> "office-ui-fabric-react"
let inline peoplePickerItem b c = makeEl PeoplePickerItem b c
                        
// makeHTMLProp
let PeoplePickerItem = importMember<Fable.Import.React.ComponentClass<PeoplePickerItemProps.IPeoplePickerItemWithMenuProps>> "office-ui-fabric-react"
let inline peoplePickerItem b c = makeEl PeoplePickerItem b c


module ComponentStatusProps =
    
    type IComponentStatusProps =
        | KeyboardAccessibilitySupport of ChecklistStatus
        | MarkupSupport of ChecklistStatus
        | HighContrastSupport of ChecklistStatus
        | RtlSupport of ChecklistStatus
        | TestCoverage of ChecklistStatus
        interface IFabricProp
    
// makeHTMLProp
let ComponentStatus = importMember<Fable.Import.React.ComponentClass<ComponentStatusProps.IComponentStatusProps>> "office-ui-fabric-react"
let inline componentStatus b c = makeEl ComponentStatus b c


module GridProps =
    
    type IGridProps =
        | ComponentRef of Func<unit, unit>
        | Items of ResizeArray<obj>
        | ColumnCount of float
        | OnRenderItem of Func<obj, float, JSX.Element>
        | ShouldFocusCircularNavigate of bool
        | ContainerClassName of string
        | OnBlur of Func<unit, unit>
        | PositionInSet of float
        | SetSize of float
        interface IFabricProp
    
// makeHTMLProp
let Grid = importMember<Fable.Import.React.ComponentClass<GridProps.IGridProps>> "office-ui-fabric-react"
let inline grid b c = makeEl Grid b c


module GridCellProps =
    
    type IGridCellProps<'T> =
        | Item of 'T
        | Id of string
        | Disabled of bool
        | Selected of bool
        | OnClick of Func<'T, unit>
        | OnRenderItem of Func<'T, JSX.Element>
        | OnHover of Func<'T, unit>
        | OnFocus of Func<'T, unit>
        | Role of string
        | ClassName of string
        | CellDisabledStyle of ResizeArray<string>
        | CellIsSelectedStyle of ResizeArray<string>
        | Index of float
        | Label of string
    



module SelectableDroppableTextProps =
    
    type ISelectableDroppableTextProps<'T> =
        | ComponentRef of Func<'T, unit>
        | Label of string
        | AriaLabel of string
        | Id of string
        | ClassName of string
        | DefaultSelectedKey of U2<string, float>
        | SelectedKey of U2<string, float>
        | Options of obj
        | OnChanged of Func<ISelectableOption, float, unit>
        | OnRenderContainer of IRenderFunction<ISelectableDroppableTextProps<'T>>
        | OnRenderList of IRenderFunction<ISelectableDroppableTextProps<'T>>
        | OnRenderItem of IRenderFunction<ISelectableOption>
        | OnRenderOption of IRenderFunction<ISelectableOption>
        | Disabled of bool
        | Required of bool
        | CalloutProps of ICalloutProps
        | ErrorMessage of string
    



module SelectableOptionProps =
    
    type ISelectableOption =
        | Key of U2<string, float>
        | Text of string
        | ItemType of SelectableOptionMenuItemType
        | Index of float
        | AriaLabel of string
        | Selected of bool
    

