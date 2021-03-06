﻿[<WebSharper.JavaScript>]
module MarkersTests

open FSharpIDD.Plots
open FSharpIDD.Chart
open FSharpIDD
open FSharpIDD.Plots.Markers

let Xseries = Array.init 3 (fun i -> float(i+1))
let Yseries = Xseries |> Array.map (fun x -> sin(2.0*x)/x)

let Empty : Chart =
    Chart.Empty
    |> Chart.setSize 300 200
    |> Chart.setNavigationEnabled false

// Basic markers sample
let basicMarkersPlot : Markers.Plot = createMarkers Xseries Yseries

// Basic markers test
let basicMarkersChart = Chart.addMarkers basicMarkersPlot Empty
let basicMarkersTest =
    "Simple markers sample",
    [
        "createMarkers Xseries Yseries"
        "Box-shaped blue markers"
    ],
    basicMarkersChart
    

// Specifying empty set of markers options with setOptions call
let emptyOptionsMarkers = Markers.setOptions(Markers.Options()) basicMarkersPlot
let emptyOptionsMarkersChart = Chart.addMarkers emptyOptionsMarkers Empty
let emptyOptionsMarkersTest =
    "Setting empty properties list",
    [
        "Markers.setOptions(Markers.Options())"
        "Same markers as on the previous chart"
    ],
    emptyOptionsMarkersChart
    

// Specifying markers name with setOptions call
let nameMarkersPlot = Markers.setOptions (Markers.Options(Name = "Markers")) basicMarkersPlot
let nameMarkersChart = Chart.addMarkers nameMarkersPlot Empty
let nameMarkersTest =
    "Specifying name of the markers",
    [
        "Markers.setOptions (Markers.Options(Name = 'Markers'))"
        "Same markers as on the previous chart with a legend "
    ],
    nameMarkersChart
    

// Specifying markers border and fill colours with setOptions call
let borderFillMarkersPlot = Markers.setOptions (Markers.Options(BorderColour = Colour.Blue, FillColour = Colour.Green)) basicMarkersPlot
let borderFillMarkersPlotChart = Chart.addMarkers borderFillMarkersPlot Empty
let borderFillMarkersTest =
    "Specifying border and fill colours of the markers",
    [
        "Markers.setOptions (Markers.Options(BorderColour = Colour.Blue, FillColour = Colour.Green))"
        "Markers are green with blue borders now "
    ],
    borderFillMarkersPlotChart
    

// Specifying markers shape with setOptions call
let shapeMarkersPlot = Markers.setOptions (Markers.Options(Shape = Shape.Cross)) basicMarkersPlot
let shapeMarkersPlotChart = Chart.addMarkers shapeMarkersPlot Empty
let shapeMarkersTest =
    "Specifying shape of a marker",
    [
        "Markers.setOptions (Markers.Options(Shape = Shape.Cross))"
        "Markers have a cross shape"
    ],
    shapeMarkersPlotChart
    

// Specifying marker size with setOptions call
let sizeMarkersPlot = Markers.setOptions (Markers.Options(Size = 30.0)) basicMarkersPlot
let sizeMarkersPlotChart = Chart.addMarkers sizeMarkersPlot Empty
let sizeMarkersTest =
    "Specifying size of a marker",
    [
        "Markers.setOptions (Markers.Options(Size = 30.0))"
        "Markers are 30px of a size"
    ],
    sizeMarkersPlotChart