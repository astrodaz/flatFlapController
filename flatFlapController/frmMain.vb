Public Class formMain


    ''' <summary>
    ''' 24/10/18
    ''' Added property to hold status of port, with ENUM of status
    ''' Added new code to handle the status of the port and enable/disable buttons as needed
    ''' Tidied up code to split up longer processes into smaller code subs
    ''' Added a HELLO button
    ''' 
    ''' 
    ''' TO DO
    ''' Test the saving of the COM port value with another serial port device added in
    ''' Find out how to add a new thread to update the UI and add a listener to the portStatus property
    ''' Add in the Background worker thread to get the serial data back from the Arduino
    ''' Change the labelStatus for a proper status bar - add the updating into the UI thread
    ''' 
    ''' </summary>


    Private Enum STATUS As Byte
        [_FIRST] = 0
        CLOSED = 0
        CONNECTING = 1
        TRANSMIT = 2
        RECEIVE = 3
        IDLE = 4
        OPEN = 5
        [_LAST] = 6
        PORT_ERROR = 99
    End Enum

    ' Property to hold the status flag
    Public portStatus As String
    Private Property _portStatus As STATUS
        Get
            Return portStatus.ToString
        End Get
        Set(value As STATUS)
            Dim bFound As Boolean
            bFound = False

            For V = STATUS._FIRST To STATUS._LAST
                If value = V Then
                    portStatus = value
                    bFound = True
                End If
            Next

            If Not bFound Then portStatus = STATUS.PORT_ERROR

        End Set
    End Property


    ' Declare the serial port
    Dim serialPort As New IO.Ports.SerialPort


    Private Sub buttonExit_Click(sender As Object, e As EventArgs) Handles buttonExit.Click
        Application.Exit()
    End Sub


    Private Sub formMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SetInitialValues()

    End Sub

    Private Sub comboPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboPort.SelectedIndexChanged

        serialPort.PortName = comboPort.SelectedItem

    End Sub

    Private Sub buttonConnect_Click(sender As Object, e As EventArgs) Handles buttonConnect.Click

        ' Save the settings
        If My.Settings("userPort") <> comboPort.SelectedIndex Then
            My.Settings("userPort") = comboPort.SelectedIndex
            My.Settings.Save()
        End If

        If buttonConnect.Text = "Connect" Then
            ' Open the COM Port
            portStatus = STATUS.CONNECTING
            UpdateUI()
            serialPort.BaudRate = 9600
            serialPort.ReadTimeout = 10000
            serialPort.Open()
            portStatus = STATUS.OPEN
            UpdateUI()
            serialPort.Write(":HH#")
            portStatus = STATUS.IDLE
            UpdateUI()

        Else
            serialPort.Close()
            portStatus = STATUS.CLOSED
            UpdateUI()
        End If

        portStatus = STATUS.IDLE

    End Sub

    Private Sub buttonFlap_Click(sender As Object, e As EventArgs) Handles buttonFlap.Click

        portStatus = STATUS.TRANSMIT
        serialPort.Write(":TF#")
        UpdateUI()

        portStatus = STATUS.IDLE
        UpdateUI()


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

        Select Case portStatus
            Case STATUS.OPEN
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
                buttonHello.Enabled = True

            Case STATUS.CONNECTING

            Case STATUS.TRANSMIT, STATUS.RECEIVE
                buttonConnect.Enabled = False
                labelStatus.Text = "Communicating with Arduino"
                buttonExit.Enabled = False
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
                buttonHello.Enabled = False

            Case STATUS.IDLE
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
                buttonHello.Enabled = True
                labelStatus.Text = "Arduino idle"

            Case STATUS.CLOSED, STATUS.PORT_ERROR
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
                buttonHello.Enabled = False

        End Select

        If IO.Ports.SerialPort.GetPortNames.Count = 0 Then
            buttonConnect.Enabled = False
        Else
            buttonConnect.Enabled = True
        End If

    End Sub

    Private Sub UpdateUI()

        ' Update the button state
        UpdateButtons()


    End Sub

    Private Sub LoadLEDPins()

        ' Load the allowable LED values into the combo box
        comboLED.Items.Add("13")
        comboLED.Items.Add("12")
        comboLED.Items.Add("7")
        comboLED.Items.Add("6")
        comboLED.Items.Add("5")
        comboLED.Items.Add("4")
        comboLED.Items.Add("3")
        comboLED.Items.Add("2")

        ' LED Pin
        comboLED.SelectedIndex = My.Settings("userLED")

    End Sub

    Private Sub SetInitialValues()

        ' Load the LEDs
        ' Load the LED pins
        LoadLEDPins()

        ' Set the form values
        ' Nudge value
        textNudgeValue.Text = My.Settings("userNudge")

        ' Open position
        textOpenPosition.Text = My.Settings("userOpenPosition")

        ' Serial Ports
        GetComPorts()

    End Sub

    Private Sub GetComPorts()

        ' Declare Ports 
        Dim idxFound As Integer = -1

        Dim Ports As String() = IO.Ports.SerialPort.GetPortNames()
        ' Add port name Into a comboBox control 

        For Each Port In Ports
            comboPort.Items.Add(Port)
        Next Port

        idxFound = comboPort.FindStringExact(My.Settings("userPort"))

        If idxFound = -1 Then
            comboPort.SelectedIndex = 0
        Else
            comboPort.SelectedIndex = idxFound
        End If

        portStatus = STATUS.CLOSED

    End Sub

    Private Sub formMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        UpdateUI()

    End Sub

    Private Sub buttonHello_Click(sender As Object, e As EventArgs) Handles buttonHello.Click

        serialPort.WriteLine(":HH#")

    End Sub
End Class