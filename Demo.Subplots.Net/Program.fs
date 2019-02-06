﻿open FSharpIDD
open FSharpIDD.Chart
open System.IO
open System.Diagnostics
open FSharpIDD.Plots

[<EntryPoint>]
let main argv = 
     // Comparison chart     

    let m_x1 = [|0.0;0.195277778;0.388888889;0.583055556;0.778055556;0.9725;1.167777778;1.361944444;1.556388889;1.750555556;1.944166667;2.1375;2.331944444;2.525555556;2.719166667;2.912777778;3.106111111;3.301388889;3.495833333;3.69;3.885277778;4.080555556;4.274166667;4.468333333;4.663611111;4.858888889;5.053055556;5.2475;5.441944444;5.636944444;5.831388889;6.025833333;6.219444444;6.414722222;6.609722222;6.804166667;6.998888889;7.193333333;7.387777778;7.582222222;7.7775;7.971666667;8.165277778;8.359722222;8.553888889;8.748611111;8.943888889;9.138333333;9.3325;9.526111111;9.721388889;9.915833333;10.11027778;10.30472222;10.49888889;10.6925;10.8875;11.08138889;11.27583333;11.47027778;11.66472222;11.85888889;12.05444444;12.24888889;12.4425;12.63694444;12.83138889;13.025;13.21944444;13.41388889;13.60916667;13.80361111;13.99916667;14.19361111;14.38888889;14.58333333;14.77777778;14.97305556;15.16666667;15.36027778;15.555;15.74861111;15.9425;16.13722222;16.33083333;16.52527778;16.72;16.91472222;17.10833333;17.30222222;17.4975;17.69111111;17.88555556;18.08027778;18.27583333;18.46944444;18.66333333;18.85833333;19.05277778;19.2475|]
    let m_y1 = [|309.0;314.0;320.0;309.0;317.0;315.0;324.0;332.0;332.0;346.0;364.0;357.0;383.0;396.0;413.0;440.0;462.0;504.0;554.0;592.0;640.0;721.0;753.0;834.0;933.0;1020.0;1143.0;1252.0;1422.0;1560.0;1728.0;1918.0;2080.0;2283.0;2546.0;2801.0;3007.0;3279.0;3548.0;3800.0;4076.0;4273.0;4521.0;4734.0;5012.0;5149.0;5377.0;5498.0;5634.0;5770.0;5928.0;6075.0;6183.0;6244.0;6381.0;6442.0;6551.0;6564.0;6682.0;6801.0;6932.0;7141.0;7212.0;7403.0;7452.0;7605.0;7719.0;7867.0;7866.0;8133.0;8133.0;8223.0;8366.0;8418.0;8515.0;8676.0;8706.0;8837.0;8882.0;9012.0;9102.0;9082.0;9168.0;9346.0;9328.0;9409.0;9555.0;9657.0;9605.0;9672.0;9781.0;9764.0;9921.0;10003.0;10131.0;10140.0;10208.0;10287.0;10290.0;10451.0|]

    
    let markers1 =
        Markers.createMarkers m_x1 m_y1
        |> Markers.setSize 3.0
        |> Markers.setFillColour Colour.DarkOrange //dark orange

    let p_x1 = [|0.0;0.195277778;0.388888889;0.583055556;0.778055556;0.9725;1.167777778;1.361944444;1.556388889;1.750555556;1.944166667;2.1375;2.331944444;2.525555556;2.719166667;2.912777778;3.106111111;3.301388889;3.495833333;3.69;3.885277778;4.080555556;4.274166667;4.468333333;4.663611111;4.858888889;5.053055556;5.2475;5.441944444;5.636944444;5.831388889;6.025833333;6.219444444;6.414722222;6.609722222;6.804166667;6.998888889;7.193333333;7.387777778;7.582222222;7.7775;7.971666667;8.165277778;8.359722222;8.553888889;8.748611111;8.943888889;9.138333333;9.3325;9.526111111;9.721388889;9.915833333;10.11027778;10.30472222;10.49888889;10.6925;10.8875;11.08138889;11.27583333;11.47027778;11.66472222;11.85888889;12.05444444;12.24888889;12.4425;12.63694444;12.83138889;13.025;13.21944444;13.41388889;13.60916667;13.80361111;13.99916667;14.19361111;14.38888889;14.58333333;14.77777778;14.97305556;15.16666667;15.36027778;15.555;15.74861111;15.9425;16.13722222;16.33083333;16.52527778;16.72;16.91472222;17.10833333;17.30222222;17.4975;17.69111111;17.88555556;18.08027778;18.27583333;18.46944444;18.66333333;18.85833333;19.05277778;19.2475|]
    let p_y1 = [|43.0214271776715;43.30757391190911;43.680518899432549;44.077885634253988;44.550635900920248;45.131019023178624;45.854001029648487;46.748138614643572;47.863532639420605;49.252977297453512;50.982173594202543;53.137552468074013;55.846180466621789;59.21660793905852;63.426347148727473;68.682913534105523;75.232480526277755;83.4890822664424;93.744481142312779;106.49195375140118;122.42934592052212;142.20875453501148;166.4552215036486;196.39864662973133;233.36064143159371;278.51924192619589;333.01198190218395;398.7402409546072;477.25575279069449;570.436735424958;679.2043596197426;804.976460030905;947.87671807293827;1110.1267614807332;1289.9842966585031;1486.1434942961096;1697.9171820791132;1922.7391579043126;2158.6224702553741;2403.1006827015071;2654.7713647712844;2908.7169713791013;3163.4231471588023;3418.7707956116055;3671.6129567878838;3921.61841677108;4167.6161739873769;4406.9629870745448;4639.7156305578392;4865.1001163829933;5085.30164801156;5297.2614019494249;5501.8403619511319;5698.9923781310526;5888.5137037745171;6070.2825855617284;6246.223996814645;6414.2275010626981;6575.9569969611748;6731.1301713522871;6879.9535245308971;7022.4664495998986;7160.0344920441312;7291.1223212229515;7416.2221962648373;7536.63363058404;7652.0093922962205;7762.0825421157078;7868.0003630395313;7969.4874762483214;8067.1108867784124;8160.2302283954268;8249.94612790801;8335.41057831306;8417.6455837833655;8496.1004905859572;8571.28449913225;8643.64127903921;8712.4007880414374;8778.31656308418;8841.87389344625;8902.4577763079869;8960.63453465729;9016.664247304232;9070.0962009167652;9121.5694948562559;9171.0038494170876;9218.4275096096535;9263.6735676056778;9307.1563143830062;9349.182337782142;9389.1797231274322;9427.7392038179551;9464.8267688031065;9500.5906585853154;9534.5973948940828;9567.310823939788;9598.93330976676;9629.2279904790776;9658.39165195169|]

    let polyline1 =
        Polyline.createPolyline p_x1 p_y1
        |> Polyline.setStrokeColour Colour.Gold //#FFD700 gold

    let m_x2 = [|0.0;0.195277778;0.388888889;0.583055556;0.778055556;0.9725;1.167777778;1.361944444;1.556388889;1.750555556;1.944166667;2.1375;2.331944444;2.525555556;2.719166667;2.912777778;3.106111111;3.301388889;3.495833333;3.69;3.885277778;4.080555556;4.274166667;4.468333333;4.663611111;4.858888889;5.053055556;5.2475;5.441944444;5.636944444;5.831388889;6.025833333;6.219444444;6.414722222;6.609722222;6.804166667;6.998888889;7.193333333;7.387777778;7.582222222;7.7775;7.971666667;8.165277778;8.359722222;8.553888889;8.748611111;8.943888889;9.138333333;9.3325;9.526111111;9.721388889;9.915833333;10.11027778;10.30472222;10.49888889;10.6925;10.8875;11.08138889;11.27583333;11.47027778;11.66472222;11.85888889;12.05444444;12.24888889;12.4425;12.63694444;12.83138889;13.025;13.21944444;13.41388889;13.60916667;13.80361111;13.99916667;14.19361111;14.38888889;14.58333333;14.77777778;14.97305556;15.16666667;15.36027778;15.555;15.74861111;15.9425;16.13722222;16.33083333;16.52527778;16.72;16.91472222;17.10833333;17.30222222;17.4975;17.69111111;17.88555556;18.08027778;18.27583333;18.46944444;18.66333333;18.85833333;19.05277778;19.2475|]
    let m_y2 = [|4220.0;4143.0;4155.0;4044.0;4089.0;4092.0;4105.0;4302.0;4166.0;4132.0;4170.0;4193.0;4174.0;4302.0;4220.0;4301.0;4263.0;4321.0;4416.0;4429.0;4439.0;4509.0;4562.0;4595.0;4677.0;4722.0;4763.0;4918.0;5030.0;5136.0;5167.0;5500.0;5570.0;5821.0;6180.0;6312.0;6625.0;6970.0;7195.0;7467.0;7700.0;8029.0;8356.0;8683.0;8757.0;9013.0;9300.0;9406.0;9712.0;9988.0;10130.0;10424.0;10523.0;10626.0;11044.0;11118.0;11212.0;11525.0;11592.0;11862.0;12164.0;12370.0;12592.0;12807.0;12665.0;12976.0;13147.0;13214.0;13418.0;13695.0;13772.0;13926.0;13947.0;14232.0;14182.0;14326.0;14611.0;14744.0;14761.0;14929.0;15028.0;15242.0;15241.0;15366.0;15582.0;15634.0;16007.0;16026.0;16046.0;16296.0;16564.0;16487.0;16571.0;16723.0;16910.0;16952.0;17097.0;17186.0;17122.0;17283.0|]

    
    let markers2 =
        Markers.createMarkers m_x2 m_y2
        |> Markers.setSize 3.0
        |> Markers.setShape Markers.Shape.Box
        |> Markers.setFillColour Colour.DarkBlue //#00008B dark blue
    
    let p_x2 = [|0.0;0.195277778;0.388888889;0.583055556;0.778055556;0.9725;1.167777778;1.361944444;1.556388889;1.750555556;1.944166667;2.1375;2.331944444;2.525555556;2.719166667;2.912777778;3.106111111;3.301388889;3.495833333;3.69;3.885277778;4.080555556;4.274166667;4.468333333;4.663611111;4.858888889;5.053055556;5.2475;5.441944444;5.636944444;5.831388889;6.025833333;6.219444444;6.414722222;6.609722222;6.804166667;6.998888889;7.193333333;7.387777778;7.582222222;7.7775;7.971666667;8.165277778;8.359722222;8.553888889;8.748611111;8.943888889;9.138333333;9.3325;9.526111111;9.721388889;9.915833333;10.11027778;10.30472222;10.49888889;10.6925;10.8875;11.08138889;11.27583333;11.47027778;11.66472222;11.85888889;12.05444444;12.24888889;12.4425;12.63694444;12.83138889;13.025;13.21944444;13.41388889;13.60916667;13.80361111;13.99916667;14.19361111;14.38888889;14.58333333;14.77777778;14.97305556;15.16666667;15.36027778;15.555;15.74861111;15.9425;16.13722222;16.33083333;16.52527778;16.72;16.91472222;17.10833333;17.30222222;17.4975;17.69111111;17.88555556;18.08027778;18.27583333;18.46944444;18.66333333;18.85833333;19.05277778;19.2475|]
    let p_y2 = [|3771.8306524170107;3772.3906310648558;3772.9183542116084;3773.471665142602;3774.1482238116055;3774.9779817080766;3776.008603765752;3777.280542692934;3778.8651313111341;3780.8374093638809;3783.2907460859578;3786.3480038754665;3790.1890452947337;3794.9679542799095;3800.9358692498377;3808.3857965888978;3817.6650331217816;3829.35699083333;3843.8703628005496;3861.8956160670273;3884.4072369926043;3912.3079211098625;3946.4519220364996;3988.5305199466479;4040.3372589289847;4103.4328870471891;4179.2808059263016;4270.35032702224;4378.5524163456848;4506.1561728959332;4654.0202721924006;4823.5915508387689;5014.4798603098488;5229.0154223146665;5464.2038629898543;5717.703175217498;5988.01922133551;6271.360153608005;6564.8144869479984;6865.04133371286;7170.1419324215694;7474.14406887604;7775.37868147142;8073.8816009867132;8366.2316879231275;8652.3693990249;8931.29347110133;9200.417673310707;9460.2351979146333;9710.3000399739612;9953.4437593131443;10186.672971559559;10411.325232299045;10627.689534235447;10835.879869190871;11036.065636023162;11230.640766183838;11417.526507410035;11598.78381135002;11774.293556628765;11944.459452602312;12109.437545814408;12270.969923324355;12427.332543163957;12579.137382949424;12728.008882542934;12873.559267737292;13015.440380512968;13155.125185275532;13292.236723552252;13427.529553095144;13560.059988895435;13691.334645482046;13820.027831457453;13947.583923541326;14073.055274245049;14197.119210694367;14320.415070015752;14441.481921132083;14561.475648431746;14681.16598121889;14799.269348891148;14916.715353398309;15033.904440448749;15149.73361399155;15265.425148496799;15380.69183513847;15495.422810898914;15609.014102233032;15722.321479227181;15836.028392961534;15948.391837756202;16060.895776779633;16173.24728685962;16285.789787536678;16396.951231406882;16508.032434124118;16619.53072782138;16730.508935720456;16841.461489217421|]

    
    let polyline2 =
        Polyline.createPolyline p_x2 p_y2
        |> Polyline.setStrokeColour Colour.LightBlue //##ADD8E6 lightblue

    let comparisionChart =
        Chart.Empty        
        |> Chart.setVisibleRegion (VisibleRegion.Autofit 1)
        |> Chart.setNavigationEnabled false 
        |> Chart.setSize 250 200

        |> Chart.setTitle "C12 = 3.81"        
        |> Chart.setXlabel "Time (h)"
        |> Chart.setYlabel "Fluorescence"        

        |> Chart.addPolyline polyline1
        |> Chart.addPolyline polyline2
        |> Chart.addMarkers markers1
        |> Chart.addMarkers markers2
        |> Chart.setNavigationEnabled true
    
    let grid = Subplots.createSubplots 8 6 (fun r c -> Some (Chart.setTitle (sprintf "plot %d %d" (r+1) (c+1)) comparisionChart))
    let generatedStr = HTML.ofSubplots grid

    let template = File.ReadAllText "template.html"

    // Injecting it into the HTML template
    let html = template.Replace("<%PLACEHOLDER%>",generatedStr)
    printfn "%s" generatedStr
    let writer = File.CreateText("chart.html")
    writer.Write(html)
    writer.Close()
    // showing the result HTML with browser
    Process.Start("chart.html") |> ignore
    0