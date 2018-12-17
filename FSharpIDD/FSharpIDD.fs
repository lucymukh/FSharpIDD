﻿namespace FSharpIDD

open WebSharper

[<AutoOpen>]
module Conversions =
    [<Inline "$0 % 256">]
    let inline byte x = byte x

module Utils =
    [<Inline "Math.floor(new Date().valueOf() * Math.random()).toString()">]
    let getUniqueId(): string = 
        System.Guid.NewGuid().ToString()


[<JavaScript>]
module Plots =        
    type DataSeries = float seq
    
    module Polyline =
        /// The cap (shape of ending) of the line
        type LineCap =
        |   Butt
        |   Round
        |   Square

        /// The shape of joins of polyline's strait segments
        type LineJoin =
        |   Bevel
        |   Round
        |   Miter

        /// The single polyline settings
        type Plot = {
            /// Specifies how to annotate the polyline in the legend. Null means that name is not set
            Name: string
            /// Series of X coords of the points that form the polyline
            X: DataSeries
            /// Series of Y coords of the points that form the polyline
            Y: DataSeries
            /// The fill colour of the polyline
            Colour: Colour.Colour
            /// The line thickness of the polyline in pixels
            Thickness: float
            /// The cap (shape of ending) of the line
            LineCap: LineCap
            /// The shape of joins of polyline's strait segments
            LineJoin: LineJoin
            }
        
        type Options() =
            let mutable name: string option = None
            let mutable colour: Colour.Colour option = None
            let mutable thickness: float option = None
            let mutable lineCap: LineCap option = None
            let mutable lineJoin: LineJoin option = None

            member s.Name with set v = name <- Some(v)                
            member s.SpecifiedName with internal get() = name
            member s.Colour with set v = colour <- Some(v)
            member s.SpecifiedColour with internal get() = colour
            member s.Thickness with set v = thickness <- Some(v)
            member s.SpecifiedThickness with internal get() = thickness
            member s.LineCap with set v = lineCap <- Some(v)
            member s.SpecifiedLineCap with internal get() = lineCap
            member s.LineJoin with set v = lineJoin <- Some(v)
            member s.SpecifiedLineJoin with internal get() = lineJoin
    
        /// sets several polyline options at once
        let setOptions (options:Options) polyline =
            let polyline =
                match options.SpecifiedName with
                | None -> polyline
                | Some(name) -> {polyline with Name = name}
            let polyline =
                match options.SpecifiedColour with
                | None -> polyline
                | Some(color) -> {polyline with Colour = color}
            let polyline =
                match options.SpecifiedThickness with
                | None -> polyline
                | Some(thickness) -> {polyline with Thickness = thickness}
            let polyline =
                match options.SpecifiedLineCap with
                | None -> polyline
                | Some(cap) -> {polyline with LineCap = cap}
            let polyline =
                match options.SpecifiedLineJoin with
                | None -> polyline
                | Some(join) -> {polyline with LineJoin = join}
            polyline
        
        /// Creates a basic polyline using the specified set of X and Y coords
        let createPolyline x y = 
                {
                    X = x
                    Y = y
                    Colour = Colour.Default
                    Thickness = 1.0
                    Name = null
                    LineCap = LineCap.Butt
                    LineJoin = LineJoin.Miter
                }
        
        /// Changes the name of the polyline (how it is depicted in the legend)
        let setName name polyline =
            {
                polyline with
                    Name = name
            }

        /// Changes the colour of the polyline
        let setStrokeColour colour polyline =
            {
                polyline with
                    Colour = colour
            }
        
        /// Sets the line thickness in pixels
        let setThickness thickness polyline =
            {
                polyline with
                    Thickness = thickness
            }
        
        /// Sets the shape of polyline caps (line endings)
        let setLineCap capType polyline =
            {
                polyline with
                    LineCap = capType
            }

        /// Sets the shape of polyline strait segment joins
        let setLineJoin joinType polyline =
            {
                polyline with
                    LineJoin = joinType
            }

    module Markers =
        /// Marker primitives
        type Shape =
        |   Box
        |   Circle
        |   Diamond
        |   Cross
        |   Triangle

        /// The single marker plot settings
        type Plot = {
            /// Specifies how to annotate markers in a legend. Null means that name is not set
            Name: string
            /// Series of X coords of markers
            X: DataSeries
            /// Series of Y coords of markers
            Y: DataSeries
            /// Specifies the size of one marker in pixels
            Size: float
            /// The colour with which the colour will be filled
            FillColour: Colour.Colour
            /// The colour of a marker border
            BorderColour: Colour.Colour
            /// The shape of a marker
            Shape: Shape
        }
        
        type Options() =
            let mutable name: string option = None
            let mutable fillcolour: Colour.Colour option = None
            let mutable bordercolour: Colour.Colour option = None
            let mutable shape: Shape option = None
            let mutable size: float option = None

            member s.Name with set v = name <- Some(v)                
            member s.SpecifiedName with internal get() = name
            member s.FillColour with set v = fillcolour <- Some(v)
            member s.SpecifiedFillColour with internal get() = fillcolour
            member s.BorderColour with set v = bordercolour <- Some(v)
            member s.SpecifiedBorderColour with internal get() = bordercolour
            member s.Shape with set v = shape <- Some(v)
            member s.SpecifiedShape with internal get() = shape
            member s.Size with set v = size <- Some(v)
            member s.SpecifiedSize with internal get() = size
    
        /// sets several markers options at once
        let setOptions (options:Options) markers =
            let markers =
                match options.SpecifiedName with
                | None -> markers
                | Some(name) -> {markers with Name = name}
            let markers =
                match options.SpecifiedFillColour with
                | None -> markers
                | Some(fillcolour) -> {markers with FillColour = fillcolour}
            let markers =
                match options.SpecifiedBorderColour with
                | None -> markers
                | Some(bordercolour) -> {markers with BorderColour = bordercolour}
            let markers =
                match options.SpecifiedShape with
                | None -> markers
                | Some(shape) -> {markers with Shape = shape}
            let markers =
                match options.SpecifiedSize with
                | None -> markers
                | Some(size) -> {markers with Size = size}
            markers
        
        /// Creates markers plot using the specified set of X and Y coords with default settings
        let createMarkers x y = 
                {
                    X = x
                    Y = y
                    FillColour = Colour.Default
                    BorderColour = Colour.Default
                    Name = null
                    Shape = Shape.Box
                    Size = 10.0
                }
        
        /// Changes the name of markers (how are they depicted in the legend)
        let setName name markers =
            {
                markers with
                    Name = name
            }
        
        /// Changes the colour of a marker's border
        let setBorderColour bordercolour markers =
            {
                markers with
                    BorderColour = bordercolour
            }
        
        /// Changes the colour with which a marker is filled (how are they depicted in the legend)
        let setFillColour fillcolour markers =
            {
                markers with
                    FillColour = fillcolour
            }

        /// Sets the shape of a marker
        let setShape shapeType markers =
            {
                markers with
                    Shape = shapeType
            }

        /// Sets the size of a marker
        let setSize size markers =
            {
                markers with
                    Size = size
            }

    module BarChart =
        type Shadow =
        |   WithoutShadow
        |   WithShadow of Colour.Colour

        /// BarChart plot settings
        type Plot = {
            /// Specifies how to annotate BarChart plot in a legend
            Name: string
            /// Series of bar centers horizontal coordinates. Length of the series equals the number of bars
            BarCenters: DataSeries
            /// Series of bar heights. Length of the series equals the number of bars
            BarHeights: DataSeries
            /// The width in plot coordinates of one bar in a bar chart plot
            BarWidth: float
            /// The colour with which a bar will be filled
            FillColour: Colour.Colour
            /// The colour of a bar border
            BorderColour: Colour.Colour
            /// Shadow mode: with or without shadow, shadow colour
            Shadow: Shadow
        }
        
        type Options() =
            let mutable name: string option = None
            let mutable fillcolour: Colour.Colour option = None
            let mutable bordercolour: Colour.Colour option = None
            let mutable shadow: Shadow option = None
            let mutable barwidth: float option = None

            member s.Name with set v = name <- Some(v)                
            member s.SpecifiedName with internal get() = name
            member s.FillColour with set v = fillcolour <- Some(v)
            member s.SpecifiedFillColour with internal get() = fillcolour
            member s.BorderColour with set v = bordercolour <- Some(v)
            member s.SpecifiedBorderColour with internal get() = bordercolour
            member s.Shadow with set v = shadow <- Some(v)
            member s.SpecifiedShadow with internal get() = shadow
            member s.BarWidth with set v = barwidth <- Some(v)
            member s.SpecifiedBarWidth with internal get() = barwidth
    
        /// sets several bar chart options at once
        let setOptions (options:Options) barchart =
            let barchart =
                match options.SpecifiedName with
                | None -> barchart
                | Some(name) -> {barchart with Name = name}
            let barchart =
                match options.SpecifiedFillColour with
                | None -> barchart
                | Some(fillcolour) -> {barchart with FillColour = fillcolour}
            let barchart =
                match options.SpecifiedBorderColour with
                | None -> barchart
                | Some(bordercolour) -> {barchart with BorderColour = bordercolour}
            let barchart =
                match options.SpecifiedBarWidth with
                | None -> barchart
                | Some(barwidth) -> {barchart with BarWidth = barwidth}
            let barchart =
                match options.SpecifiedShadow with
                | None -> barchart
                | Some(shadow) -> {barchart with Shadow = shadow}
            barchart
        
        /// Creates bar chart plot using the specified set of BarCenters and BarHeights with default settings
        let createBarChart barcenters barheights = 
                {
                    BarCenters = barcenters
                    BarHeights = barheights
                    Name = null
                    FillColour = Colour.Default
                    BorderColour = Colour.Default
                    Shadow = Shadow.WithoutShadow
                    BarWidth = 1.0
                }
        
        /// Changes a colour of bar's borders
        let setBorderColour bordercolour barchart =
            {
                barchart with
                    BorderColour = bordercolour
            }
        
        /// Changes a colour with which a bar is filled (how are they depicted in the legend)
        let setFillColour fillcolour barchart =
            {
                barchart with
                    FillColour = fillcolour
            }

        /// Sets whether a bar has a shadow and what colour is it
        let setShadow shadow barchart =
            {
                barchart with
                    Shadow = shadow
            }

        /// Sets bar width (in plot coords) of a bar
        let setBarWidth barwidth barchart =
            {
                barchart with
                    BarWidth = barwidth
            }
        
        
        /// Changes the name of bar chart plot (how it is depicted in the legend)
        let setName name barChart =
            {
                barChart with
                    Name = name
            }
    
    module Histogram =
        /// Histogram plot
        type Plot = {        
            /// Specifies how to annotate the histogram in a legend
            Name: string
            /// Samples to calculate the histogram for
            Samples: DataSeries        
            /// The colour of the histogramS
            Colour: Colour.Colour
            /// Number of bins in the histogram
            BinCount: int
        }

        /// Creates a histogram plot for the passed data
        let createHistogram samples =
            {
                Name = null
                Samples = samples
                Colour = Colour.Default
                BinCount = 30
            }
        
        let setName name hist = {hist with Name = name}
        let setColour colour hist = {hist with Colour = colour}
        let setBinCount count hist = {hist with BinCount = count}
        
        
    type Plot =
    |   Polyline of Polyline.Plot
    |   Markers of Markers.Plot
    |   BarChart of Bars.Plot
    |   Histogram of Histogram.Plot

    type SizeType = int

[<JavaScript>]
module Chart =        
    open Plots

    type Axis = 
    /// The axis is disabled (not visible)
    |   Hidden
    /// Numeric axis of automatically calculated and placed numerical ticks with values
    |   Numeric

    type GridLines =
    |   Disabled
    |   Enabled of strokeColour: Colour.Colour * lineWidthPX: float

    let DefaultGridLines = Enabled(Colour.DarkGrey, 1.0)

    type LegendVisibility =
    /// The legend is always visible (even if all of the plots are without names)
    |   Visible
    /// The legend is visible if some of the plots have their name set
    |   Automatic
    /// The legend is not visible
    |   Hidden

    type VisibleRegion =
    /// Fits the visible region so that all of the data is visible adding additional padding (blank visible area) in pixels
    |   Autofit of dataPaddingPx:int
    /// Explicit visible region in data coordinates
    |   Explicit of xmin:float * ymin:float * xmax:float * ymax:float

    /// Represents single chart that can be transformed later into the HTML IDD Chart    
    type Chart = {
        /// The width of the chart in pixels
        Width: int 
        /// The height of the chart in pixels
        Height: int
        /// The text that is centered and placed above the chart
        Title: string
        /// The text which describes the X axis
        Xlabel: string
        /// Which X axis to draw
        Xaxis: Axis
        /// The text which describes the Y axis        
        Ylabel: string
        /// Which Y axis to draw
        Yaxis: Axis
        /// The appearance of grid lines
        GridLines : GridLines
        /// A collection of plots (polyline, markers, bar charts, etc) to draw
        Plots: Plot list
        /// Whether the legend (list of plot names and their icons) is visible in the top-right part of the chart
        IsLegendEnabled: LegendVisibility
        /// Whether the chart visible area can be navigated with a mouse or touch gestures
        IsNavigationEnabled: bool
        /// Which visible rectangle is displayed by the chart
        VisibleRegion : VisibleRegion
    }

    let Empty : Chart = {
        Width = 800
        Height = 600
        Title = null // null means not set
        Xlabel = null // null means not set
        Ylabel = null // null means not set
        Xaxis = Axis.Numeric
        Yaxis = Axis.Numeric
        GridLines = DefaultGridLines
        IsLegendEnabled = Automatic
        IsNavigationEnabled = true
        Plots = []
        VisibleRegion = VisibleRegion.Autofit 20
    }

    let addPolyline polyline chart = { chart with Plots = Polyline(polyline)::chart.Plots }

    let addMarkers markers chart = { chart with Plots = Markers(markers)::chart.Plots }

    let addBarChart barchart chart = { chart with Plots = BarChart(barchart)::chart.Plots }

    let addHistogram histogram chart = { chart with Plots = Histogram(histogram)::chart.Plots }

    /// Sets the textual title that will be placed above the charting area
    let setTitle title chart =  { chart with Title = title}

    /// Sets the size of the chart in pixels
    let setSize width height chart = { chart with Width = width; Height = height}

    /// Sets the X axis textual  label (placed below the X axis)
    let setXlabel label chart = { chart with Xlabel = label}

    /// Sets the mode of X axis
    let setXaxis axisMode chart = {chart with Xaxis = axisMode}

    /// Sets the visible region that is displayed by the chart
    let setVisibleRegion region chart = { chart with VisibleRegion = region}

    /// Set the Y axis textual label (placed to the left of Y axis)
    let setYlabel label chart = { chart with Ylabel = label}

    /// Sets the mode of Y axis
    let setYaxis axisMode chart = { chart with Yaxis = axisMode}

    /// Set the mode of grid lines appearance
    let setGridLines gridLines chart = {chart with GridLines = gridLines}
    
    /// Set the visibility of the plot legend floating in the top-right region of the chart
    let setLegendEnabled legendVisibility chart = {chart with IsLegendEnabled = legendVisibility}

    /// Set whether the chart can be navigated with a mouse or touch gestures
    let setNavigationEnabled isEnabled chart = {chart with IsNavigationEnabled = isEnabled}

    open Html

    let toHTML (chart:Chart) =
        let chartNode =
            let addVisibleRegionAttribute = 
                match chart.VisibleRegion with
                |   Autofit padding -> addAttribute "data-idd-padding" (sprintf "%d" padding)
                |   Explicit(xmin,ymin,xmax,ymax) -> addAttribute "data-idd-visible-region" (sprintf "%f %f %f %f" xmin xmax ymin ymax)
            createDiv()
            |> addAttribute "class" "fsharp-idd" 
            |> addAttribute "data-idd-plot" "figure" 
            |> addAttribute "style" (sprintf "width: %dpx; height: %dpx;" chart.Width chart.Height)
            |> addVisibleRegionAttribute
                
        let chartNode = 
            if chart.Ylabel <> null then
                let containerNode =
                    let labelNode =
                        createDiv()
                        |> addAttribute "class" "idd-verticalTitle-inner"
                        |> addText chart.Ylabel
                    createDiv()
                    |> addAttribute "class" "idd-verticalTitle"
                    |> addAttribute "data-idd-placement" "left"
                    |> addDiv labelNode                                        
                chartNode |> addDiv containerNode
            else
                chartNode

        let chartNode,yAxisID = 
            match chart.Yaxis with
            |   Axis.Hidden -> chartNode, Option.None
            |   Axis.Numeric ->
                let id = Utils.getUniqueId()
                let axisNode =                    
                    createDiv()
                    |> addAttribute "id" id
                    |> addAttribute "data-idd-axis" "numeric"
                    |> addAttribute "data-idd-placement" "left"
                    |> addAttribute "style" "position: relative;"                    
                (chartNode |> addDiv axisNode),(Some id)
        
        let chartNode = 
            if chart.Xlabel <> null then
                let labelNode =
                    createDiv()
                    |> addAttribute "class" "idd-horizontalTitle"
                    |> addAttribute "data-idd-placement" "bottom"
                    |> addText chart.Xlabel
                chartNode |> addDiv labelNode
            else
                chartNode

        let chartNode,xAxisID = 
            match chart.Xaxis with
            |   Axis.Hidden -> chartNode, Option.None
            |   Axis.Numeric ->
                let id = Utils.getUniqueId()
                let axisNode =                    
                    createDiv()
                    |> addAttribute "id" id
                    |> addAttribute "data-idd-axis" "numeric"
                    |> addAttribute "data-idd-placement" "bottom"
                    |> addAttribute "style" "position: relative;"                    
                (chartNode |> addDiv axisNode),(Some id)               
        
        let effectiveLegendvisibility =
            match chart.IsLegendEnabled with
            |   Visible -> true
            |   Hidden -> false
            |   Automatic ->
                let isNameDefined plot =
                    match plot with
                    |   Polyline p -> p.Name <> null
                    |   Markers m -> m.Name <> null
                    |   BarChart b -> b.Name <> null
                    |   Histogram h -> h.Name <> null
                List.exists isNameDefined chart.Plots

        let chartNode = chartNode |> addAttribute "data-idd-legend-enabled" (if effectiveLegendvisibility then "true" else "false")            
        let chartNode = chartNode |> addAttribute "data-idd-navigation-enabled" (if chart.IsNavigationEnabled then "true" else "false")            

        let chartNode = 
            if chart.Title <> null then
                let titleNode =
                    createDiv()
                    |> addAttribute "class" "idd-title"
                    |> addAttribute "data-idd-placement" "top"
                    |> addText chart.Title
                chartNode |> addDiv titleNode
            else
                chartNode

        let getDataDom xSeries ySeries =
                // can't use string builder here as it is not transpilable with WebSharper
                let str = Seq.fold2 (fun state x y -> state + (sprintf "\t%f\t%f\n" x y)) "\tx\ty\n" xSeries ySeries                                
                str

        let histogramToBars (h:Histogram.Plot) =
            let hist = histogram.buildHistogram h.Samples h.BinCount
            let bars: Bars.Plot = 
                {
                    Name = h.Name
                    X = hist.BinCentres
                    Y = hist.BinCounters |> Seq.map float
                    BarWidth = hist.BinWidth
                    FillColour = h.Colour
                    BorderColour = h.Colour
                    Shadow = Colour.Default
                }
            bars
            

        let polylineToDiv (p:Polyline.Plot) =                                    
            let styleEntries = [ sprintf "thickness: %.1f" p.Thickness ]
            let styleEntries = 
                match p.Colour with
                | Colour.Rgb c -> (sprintf "stroke: rgb(%d,%d,%d)" c.R c.G c.B)::styleEntries
                | Colour.Default -> styleEntries                     
            let styleEntries = 
                let joinStr =
                    match p.LineJoin with
                    | Polyline.LineJoin.Miter -> "miter"
                    | Polyline.LineJoin.Bevel -> "bevel"
                    | Polyline.LineJoin.Round -> "round"
                (sprintf "lineJoin: %s" joinStr)::styleEntries
            let styleEntries = 
                let capStr =
                    match p.LineCap with
                    | Polyline.LineCap.Butt -> "butt"
                    | Polyline.LineCap.Round -> "round"
                    | Polyline.LineCap.Square -> "square"
                (sprintf "lineCap: %s" capStr)::styleEntries
            let styleValue = System.String.Join("; ",styleEntries)

            let resultNode =
                createDiv()
                |> addAttribute "data-idd-plot" "polyline"
                |> addAttribute "data-idd-style" styleValue
                |> addText (getDataDom p.X p.Y)
                        
            let resultNode =
                if System.String.IsNullOrEmpty p.Name then
                    resultNode
                else
                    resultNode |> addAttribute "data-idd-name" p.Name  

            resultNode

        let markersToDiv (m: Markers.Plot) =                                
            // A number is a size in pixels
            let styleEntries = [ sprintf "size: %.1f" m.Size ]

            let styleEntries = 
                match m.FillColour with
                | Colour.Rgb c -> (sprintf "color: rgb(%d,%d,%d)" c.R c.G c.B)::styleEntries
                | Colour.Default -> styleEntries

            let styleEntries = 
                match m.BorderColour with
                | Colour.Rgb c -> (sprintf "border: rgb(%d,%d,%d)" c.R c.G c.B)::styleEntries
                | Colour.Default -> styleEntries
                
            let styleEntries = 
                let shapeStr =
                    match m.Shape with
                    | Markers.Shape.Box -> "box"
                    | Markers.Shape.Circle -> "circle"
                    | Markers.Shape.Cross -> "cross"
                    | Markers.Shape.Diamond -> "diamond"
                    | Markers.Shape.Triangle -> "triangle"
                (sprintf "shape: %s" shapeStr)::styleEntries

            let styleValue = System.String.Join("; ",styleEntries)

            let resultNode =
                createDiv()
                |> addAttribute "data-idd-plot" "markers"
                |> addAttribute "data-idd-style" styleValue
                |> addText (getDataDom m.X m.Y)
                        
            let resultNode =
                if System.String.IsNullOrEmpty m.Name then
                    resultNode
                else
                    resultNode |> addAttribute "data-idd-name" m.Name  

            resultNode

        let barchartToDiv (b: Bars.Plot) =                                
            // A number is a size in plot coords
            let styleEntries = [ sprintf "barWidth: %f" b.BarWidth ]

            let styleEntries = 
                match b.FillColour with
                | Colour.Rgb c -> (sprintf "color: rgb(%d,%d,%d)" c.R c.G c.B)::styleEntries
                | Colour.Default -> styleEntries

            let styleEntries = 
                match b.BorderColour with
                | Colour.Rgb c -> (sprintf "border: rgb(%d,%d,%d)" c.R c.G c.B)::styleEntries
                | Colour.Default -> styleEntries

            let styleEntries = 
                match b.Shadow with
                | BarChart.Shadow.WithShadow c ->
                    match c with
                    |   Colour.Rgb c -> (sprintf "shadow: rgb(%d,%d,%d)" c.R c.G c.B)::styleEntries
                    |   Colour.Default -> "shadow: grey"::styleEntries
                | BarChart.Shadow.WithoutShadow -> styleEntries
                
            let styleEntries = (sprintf "shape: bars")::styleEntries

            let styleValue = System.String.Join("; ",styleEntries)

            let resultNode =
                createDiv()
                |> addAttribute "data-idd-plot" "markers"
                |> addAttribute "data-idd-style" styleValue
                |> addText (getDataDom b.BarCenters b.BarHeights)
                        
            let resultNode =
                if System.String.IsNullOrEmpty b.Name then
                    resultNode
                else
                    resultNode |> addAttribute "data-idd-name" b.Name  

            resultNode
    
        let histogranToDiv (h: Histogram.Plot) =
            histogramToBars h |> barchartToDiv

        let plotToDiv plot =
            match plot with
            |   Polyline p -> polylineToDiv p
            |   Markers m -> markersToDiv m
            |   BarChart b -> barchartToDiv b
            |   Histogram h -> histogranToDiv h

        let plotElems = chart.Plots |> Seq.map plotToDiv
        let chartNode = Seq.fold (fun state elem -> addDiv elem state) chartNode plotElems
        
        let chartNode =
            match chart.GridLines with
            |   GridLines.Enabled(colour,thickness) ->                
                let gridNode =
                    let styleEntries = [ sprintf "thickness: %.1fpx" thickness ]
                    let styleEntries = 
                        match colour with
                        | Colour.Rgb c -> (sprintf "stroke: rgb(%d,%d,%d)" c.R c.G c.B)::styleEntries
                        | Colour.Default -> styleEntries 
                    let styleValue = System.String.Join<string>("; ",styleEntries)
                    createDiv()
                    |> addAttribute "data-idd-plot" "grid"
                    |> addAttribute "data-idd-placement" "center"
                    |> addAttribute "data-idd-style" styleValue
                let gridNode = 
                    match xAxisID with
                    |   Some xId -> gridNode |> addAttribute "data-idd-xaxis" xId
                    |   Option.None -> gridNode
                let gridNode = 
                    match yAxisID with
                    |   Some yId -> gridNode |> addAttribute "data-idd-yaxis" yId
                    |   Option.None -> gridNode
                chartNode |> addDiv gridNode
            |   GridLines.Disabled -> chartNode

        divToStr chartNode

    
