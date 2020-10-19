Imports System.IO.Ports

Public Class Form1

    Dim com3 As IO.Ports.SerialPort = Nothing
    Public Shared Function GetPortNames() As String()

    End Function
    Public Property PortaSerial As SerialPort
        Get
            Return com3
        End Get
        Set(value As SerialPort)
            com3 = value
        End Set
    End Property

    Private Sub Form1_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        On Error Resume Next
        PortaSerial.Close()

    End Sub




    Function ReceiveSerialData2() As String
        PortaSerial.PortName = "COM3"
        PortaSerial.BaudRate = 9600
        PortaSerial.DataBits = 8
        PortaSerial.Parity = Parity.None
        PortaSerial.StopBits = StopBits.None

        PortaSerial = My.Computer.Ports.OpenSerialPort(PortaSerial.PortName, PortaSerial.BaudRate, PortaSerial.Parity, PortaSerial.DataBits, PortaSerial.StopBits)


        PortaSerial.Write("a")
        On Error GoTo pulo1
        TextBox3.Text = PortaSerial.ReadLine()
        ProgressBar1.Value = TextBox3.Text / 10.24


        PortaSerial.Write("b")
        PortaSerial.Write(TextBox1.Text & ",")
pulo1:
        On Error Resume Next
        PortaSerial.Close()

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

    Public Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim COM3 = GetPortNames()

    End Sub
End Class





