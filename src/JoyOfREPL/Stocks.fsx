#r "../packages/FSharp.Data.2.2.3/lib/net40/FSharp.Data.dll"
#load "../packages/FSharp.Charting.0.90.10/FSharp.Charting.fsx"

open FSharp.Data
open FSharp.Charting

type Stocks = CsvProvider<"StocksFormat.csv">
//let msft = Stocks.Load("http://ichart.finance.yahoo.com/table.csv?s=MSFT").Cache()
let msft = Stocks.Load("MSFT.CSV")

let prices (stocks: seq<Stocks.Row>) = 
    stocks
    |> Seq.take 100 
    |> Seq.map (fun (p: Stocks.Row) -> (p.High, p.Low, p.Open, p.Close))

let movingAverage prices count =
    let averagePrice (h, l, o, c) = (o + c) / 2.0M
    let seqWindows = Seq.windowed count prices
    seqWindows |> Seq.map (Array.averageBy averagePrice)

let msftPrices = prices msft.Rows
let oneDayAverage = movingAverage msftPrices 1
let tenDayAverage = movingAverage msftPrices 10
let twentyDayAverage = movingAverage msftPrices 20

Chart.Combine( 
   [ Chart.Stock msftPrices
     Chart.Line oneDayAverage
     Chart.Line tenDayAverage
     Chart.Line twentyDayAverage])
|> Chart.WithArea.AxisY(Minimum = 40.0, Maximum = 50.0)
