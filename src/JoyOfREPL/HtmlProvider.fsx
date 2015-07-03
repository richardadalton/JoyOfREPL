#r "../packages/FSharp.Data.2.2.3/lib/net40/FSharp.Data.dll"
#load "../packages/FSharp.Charting.0.90.10/FSharp.Charting.fsx"

open FSharp.Data
open FSharp.Charting
open System.Drawing
open System.Windows.Forms
    
type Species = HtmlProvider<"https://en.wikipedia.org/wiki/The_world's_100_most_threatened_species">

let firstWord (s: string) = (s.Split ' ').[0]

let species = 
    [ for x in Species.GetSample().Tables.``Species list``.Rows ->
        firstWord x.Type, x.``Common name``]

let speciesByType = Seq.countBy fst species

let form = new Form(Visible = true, Text = "An F# Data Grid",
                    TopMost = true, Size = Size(600,600))
 
let data = new DataGridView(Dock = DockStyle.Fill, Text = "F# Programming is Fun!",
                            Font = new Font("Lucida Console",12.0f),
                            ForeColor = Color.DarkBlue)
 
 
form.Controls.Add(data)
 
data.DataSource <- Array.ofSeq speciesByType
data.Columns.[0].Width <- 400

Chart.Pie speciesByType