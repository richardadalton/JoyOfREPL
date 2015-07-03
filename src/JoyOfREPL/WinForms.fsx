open System
open System.Drawing
open System.Windows.Forms

// Create a Windows Form
let myForm = new Form(Text = "Hello, World!", Visible = true, TopMost = true)

// We can alter it's properties
myForm.BackColor <- Color.Blue

let button =
    let btn = new Button()
    btn.Size <- new System.Drawing.Size(100,100)
    btn.Text <- "Click"
    btn.Location <- new System.Drawing.Point(100,25)
    btn

myForm.Controls.Add(button)

button.ForeColor <- Color.White

// Create Controls
let makeLabel size location text =
    let lbl = new Label()
    lbl.Size <- new System.Drawing.Size(size)
    lbl.Text <- text
    lbl.ForeColor <- Color.White
    lbl.AutoSize <- true
    lbl.Location <- location
    lbl

let firstLabel = makeLabel (new Point (100,50)) (new System.Drawing.Point(25,25)) "First"
myForm.Controls.Add(firstLabel)


let makeSmallLabel = makeLabel (new Point (100,50))
let secondLabel = makeSmallLabel (new System.Drawing.Point(25,150)) "Hey There"
myForm.Controls.Add(secondLabel)


let onClick () = MessageBox.Show(secondLabel.Text) |> ignore
button.Click.AddHandler (fun _ _ -> onClick ())

secondLabel.Text <- "Hi"
