Public Class formMain

    Dim serialPort As New IO.Ports.SerialPort


    Private Sub buttonExit_Click(sender As Object, e As EventArgs) Handles buttonExit.Click
        Application.Exit()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub formMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Load the allowable LED values into the combo box
        comboLED.Items.Add("13")
        comboLED.Items.Add("12")
        comboLED.Items.Add("7")
        comboLED.Items.Add("6")
        comboLED.Items.Add("5")
        comboLED.Items.Add("4")
        comboLED.Items.Add("3")
        comboLED.Items.Add("2")

        ' Set the default values
        ' LED Pin
        comboLED.SelectedIndex = comboLED.FindStringExact("13")

        ' Nudge value
        txtNudgeValue.Text = "25"

        ' Open position
        textOpenPosition.Text = "1356"

        ' Serial Ports
        GetComPorts()

    End Sub


    Private Sub GetComPorts()

        ' Declare Ports 
        Dim Ports As String() = IO.Ports.SerialPort.GetPortNames()
        ' Add port name Into a comboBox control 
        For Each Port In Ports
            comboPort.Items.Add(Port)
        Next Port
        ' Select an item in the combobox 
        If comboPort.Items.Count > 0 Then
            comboPort.SelectedIndex = 0
        End If

    End Sub

    Private Sub comboPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboPort.SelectedIndexChanged

        serialPort.PortName = comboPort.SelectedItem
        serialPort.BaudRate = 9600
        serialPort.ReadTimeout = 10000

    End Sub

    Private Sub buttonConnect_Click(sender As Object, e As EventArgs) Handles buttonConnect.Click

        serialPort.Open()
        serialPort.Write(":HH#")

    End Sub

    Private Sub buttonFlap_Click(sender As Object, e As EventArgs) Handles buttonFlap.Click

        Dim serialData As String
        serialPort.Write(":TF#")
        serialData = serialPort.ReadLine()
        textSerialData.Text += serialData
        parseSerialData(serialData)

    End Sub


    Private Sub readSerialData()

        Dim returnString As String = ""
        Dim receivedChars As String = ""

        Try
            Do
                receivedChars = serialPort.ReadLine()
                If receivedChars Is Nothing Then
                    Exit Do
                Else
                    returnString = receivedChars + vbCrLf
                    receivedChars = ""
                    receivedChars = returnString.TrimStart(":")
                    returnString = receivedChars
                    receivedChars = returnString.TrimEnd("#")
                    parseSerialData(receivedChars)
                End If

            Loop

        Catch ex As TimeoutException
            returnString = "Error: Serial Port read timed out."

        End Try

    End Sub

    Private Sub parseSerialData(serialString As String)

        ' Process feedback from the serial port
        Select Case (serialString)
            Case "FO"
                textSerialData.Text += "Flap toggled - now OPEN"
                buttonFlap.BackColor = Color.Lime
            Case "FC"
                textSerialData.Text += "Flap toggled - now CLOSED"
                buttonFlap.BackColor = Color.Red
        End Select
    End Sub
End Class