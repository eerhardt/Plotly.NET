(*** hide ***)

(*** condition: prepare ***)
#r @"..\packages\Newtonsoft.Json\lib\netstandard2.0\Newtonsoft.Json.dll"
#r "../bin/Plotly.NET/net5.0/Plotly.NET.dll"
(*** condition: fsx ***)
#if FSX
#r "../packages/Newtonsoft.Json/lib/netstandard2.0/Newtonsoft.Json.dll"
#r "../bin/Plotly.NET/net5.0/Plotly.NET.dll"
#endif // FSX
(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, 2.0.0-beta1"
#r "nuget: Plotly.NET.Interactive, 2.0.0-alpha5"
#endif // IPYNB

(** 
# Heatmaps

[![Binder](https://mybinder.org/badge_logo.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=heatmaps.ipynb)

*Summary:* This example shows how to create heatmap charts in F#.

let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET 
 
let matrix =
    [[1.;1.5;0.7;2.7];
    [2.;0.5;1.2;1.4];
    [0.1;2.6;2.4;3.0];]

let rownames = ["p3";"p2";"p1"]
let colnames = ["Tp0";"Tp30";"Tp60";"Tp160"]

let colorscaleValue = 
    StyleParam.Colorscale.Custom [(0.0,"#3D9970");(1.0,"#001f3f")]

// Generating the Heatmap 
let heat1 =
    Chart.Heatmap(
        matrix,colnames,rownames,
        Colorscale=colorscaleValue,
        Showscale=true
    )
    |> Chart.withSize(700.,500.)
    |> Chart.withMarginSize(Left=200.)

(*** condition: ipynb ***)
#if IPYNB
heat1
#endif // IPYNB

(***hide***)
heat1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
A heatmap chart can be created using the `Chart.HeatMap` functions.
When creating heatmap charts, it is usually desirable to provide the values in matrix form, rownames and colnames.
*)

(**
## Styling Colorbars

All charts that contain colorbars can be styled by the `Chart.withColorBarStyle` function.
Here is an example that adds a title to the colorbar:
*)

let heat2 =
    heat1
    |> Chart.withColorBarStyle(
        "Im the Colorbar",
        TitleSide = StyleParam.Side.Right,
        TitleFont = Font.init(Size=20)
    )

(*** condition: ipynb ***)
#if IPYNB
heat2
#endif // IPYNB

(***hide***)
heat2 |> GenericChart.toChartHTML
(***include-it-raw***)
