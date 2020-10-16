



Public Class Form1

    Dim com3 As IO.Ports.SerialPort = Nothing


    Private Sub Form1_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        On Error Resume Next
        com3.Close()

    End Sub




    Function ReceiveSerialData2() As String

        com3 = My.Computer.Ports.OpenSerialPort("COM3")
        com3.BaudRate = 115200
        com3.Write("a")
        On Error GoTo pulo1
        TextBox3.Text = com3.ReadLine()
        ProgressBar1.Value = TextBox3.Text / 10.24


        com3.Write("b")
        com3.Write(TextBox1.Text & ",")
pulo1:
        On Error Resume Next
        com3.Close()

    End Function

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ReceiveSerialData2()
    End Sub


    Private Sub VScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar1.Scroll
        TextBox1.Text = VScrollBar1.Value

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1.Enabled = True

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Timer1.Enabled = False
    End Sub


End Class





