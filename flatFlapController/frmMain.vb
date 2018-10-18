Public Class formMain

    ' Declare the serial port
    Dim serialPort As New IO.Ports.SerialPort

    Private Sub buttonExit_Click(sender As Object, e As EventArgs) Handles buttonExit.Click
        Application.Exit()
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

        ' TO DO
        ' Retrieve the saved values from User Settings

        ' Set the default values
        ' LED Pin
        comboLED.SelectedIndex = My.Settings("userLED")

        ' Nudge value
        textNudgeValue.Text = My.Settings("userNudge")

        ' Open position
        textOpenPosition.Text = My.Settings("userOpenPosition")

        ' Serial Ports
        GetComPorts()

        ' Update the UI
        UpdateUI()

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

    End Sub

    Private Sub buttonConnect_Click(sender As Object, e As EventArgs) Handles buttonConnect.Click

        ' Save the settings
        My.Settings("userPort") = comboPort.SelectedIndex
        My.Settings.Save()

        ' Open the COM Port
        serialPort.BaudRate = 9600
        serialPort.ReadTimeout = 10000
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

    Private Sub UpdateButtons()

        If serialPort.IsOpen = False Then
            buttonConnect.Enabled = True
            buttonConnect.Text = "Connect"
            buttonExit.Enabled = True
            buttonFlap.Enabled = False
            buttonLED.Enabled = False
            buttonNudgeCCW.Enabled = False
            buttonNudgeCW.Enabled = False
            textNudgeValue.Enabled = False
            textOpenPosition.Enabled = False
            buttonEL.Enabled = False
            buttonSetOpenPosition.Enabled = False
            buttonSetZero.Enabled = False
            comboLED.Enabled = False
            buttonStats.Enabled = False
            buttonReset.Enabled = False
        Else
            buttonConnect.Enabled = True
            buttonConnect.Text = "Disconnect"
            buttonExit.Enabled = False
            buttonFlap.Enabled = True
            buttonLED.Enabled = True
            buttonNudgeCCW.Enabled = True
            buttonNudgeCW.Enabled = True
            textNudgeValue.Enabled = True
            textOpenPosition.Enabled = True
            buttonEL.Enabled = True
            buttonSetOpenPosition.Enabled = True
            buttonSetZero.Enabled = True
            comboLED.Enabled = True
            buttonStats.Enabled = True
            buttonReset.Enabled = True
        End If

        If IO.Ports.SerialPort.GetPortNames.Count = 0 Then
            buttonConnect.Enabled = False
        Else
            buttonConnect.Enabled = True
        End If

    End Sub

    Private Sub UpdateUI()

        ' Update the button state
        UpdateButtons()

        ' Update the open position



    End Sub
End Class