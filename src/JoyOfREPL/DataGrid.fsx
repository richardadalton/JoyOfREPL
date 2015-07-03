open System.Drawing
open System.Windows.Forms

let random = System.Random()

type Student = {Name: string; Subject: string; Grade: int}

let students = ["Larry"; "Curley"; "Moe"; "Thelma"; "Louise"]
let subjects = ["Maths"; "English"; "History"; "Geography"; "History"; "Philosophy"]

let results = [| for student in students do 
                 for subject in subjects do
                 yield {Name=student; Subject=subject; Grade=random.Next(35,95)} |]



let form = new Form(Visible = true, Text = "An F# Data Grid",
                    TopMost = true, Size = Size(600,600))
 
let data = new DataGridView(Dock = DockStyle.Fill, Text = "F# Programming is Fun!",
                            Font = new Font("Lucida Console",12.0f),
                            ForeColor = Color.DarkBlue)
 
 
form.Controls.Add(data)
 
data.DataSource <- results
data.Columns.[0].Width <- 400