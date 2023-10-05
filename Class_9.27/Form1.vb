
'Jessica McArthur
'RCET 3371
'HW 3-1
'26 Sept 2023

Option Strict On
Option Explicit On

Public Class Form1
    Dim numArray(10) As Integer

    'Varialbes to write file
    Private Const Prompt As String = "File Not Found"
    Dim dateTemp As String
    Dim fileName As String
    Dim drivePath As String


    'not needed...from past example
    'Displays a random integer from -10 to 10 is displayed in a listbox.
    Private Sub DisplayButton_Click(sender As Object, e As EventArgs) Handles DisplayButton.Click

            ListBox1.Items.Clear()                          'Clears listbox

            numArray(0) = RandomNumber()                    'Set content of array to randomize number
            numArray(1) = RandomNumber()
            numArray(2) = RandomNumber()
            numArray(3) = RandomNumber()
            numArray(4) = RandomNumber()
            numArray(5) = RandomNumber()
            numArray(6) = RandomNumber()
            numArray(7) = RandomNumber()
            numArray(8) = RandomNumber()
            numArray(9) = RandomNumber()
            ListBox1.Items.Add(Str(numArray(0)))              'Displays output in listbox
            ListBox1.Items.Add(Str(numArray(1)))
            ListBox1.Items.Add(Str(numArray(2)))
            ListBox1.Items.Add(Str(numArray(3)))
            ListBox1.Items.Add(Str(numArray(4)))
            ListBox1.Items.Add(Str(numArray(5)))
            ListBox1.Items.Add(Str(numArray(6)))
            ListBox1.Items.Add(Str(numArray(7)))
            ListBox1.Items.Add(Str(numArray(8)))
            ListBox1.Items.Add(Str(numArray(9)))
        End Sub

    'Function to generate random integer from -10 to 10.
    Function RandomNumber() As Integer
            Return CInt((Rnd() * 21) - 10)
        End Function

    'Exits the program when button is pressed.
    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click
            Me.Close()
        End Sub

    'How to write file


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dateTemp = DateString  'Sets current date from computer
        'Set file name to be created : "CLASS and current date value
        'works
        'fileName = "C:\Users\jekam\Documents\CLASS_" & dateTemp & ".txt"


        'Saves file to debug of current project
        'works
        fileName = CurDir() & "\" & dateTemp & ".txt"
        ' not work
        'fileName = drivePath & "\" & dateTemp & ".txt"



    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Try
            FileOpen(1, fileName, OpenMode.Append) 'Open file for Append
        Catch ex As Exception
            'Doing nothing
        End Try

        'Line of data must be same lenght of items or will not read file....crashes program
        'both options work
        'WriteLine(1, "      ", RandomNumber)
        WriteLine(1, Label2.Text, RandomNumber)

        FileClose(1)
    End Sub

    Private Sub ReadFileButton_Click(sender As Object, e As EventArgs) Handles ReadFileButton.Click
        Dim Record(1000, 3) As String
        Dim ptr As Int32
        Dim lineCount As Integer
        lineCount = 1
        ListBox1.Items.Clear()

        Try
            FileOpen(1, fileName, OpenMode.Input) 'Open file for read

        Catch ex As Exception
            MsgBox(Prompt)
        End Try

        Do While Not EOF(1) 'Read until end of file
            Input(1, Record(ptr, 0))
            Input(1, Record(ptr, 1))
            ListBox1.Items.Add(Str(lineCount) & vbTab & Record(ptr, 0) & vbTab & Record(ptr, 1))
            If ptr >= UBound(Record, 1) Then Exit Do
            ptr += 1
            lineCount += 1
        Loop
        FileClose(1)
    End Sub
End Class


