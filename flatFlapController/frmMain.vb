﻿Imports System.ComponentModel
Imports System.IO.Ports

Public Class formMain


    ''' <summary>
    ''' 27/10/18
    ''' Added a text file with a set of thread code for reading the COM port
    ''' Started to integrate this code into the project
    ''' Moved the UPDATEUI call to the SET() method of the port status property
    ''' The thread to monitor the serial port is working!!!
    ''' Need to review the command string sent to the Arduino, and the resonse back
    ''' The process sub needs updating to process the return message
    ''' 
    ''' 24/10/18
    ''' Added property to hold status of port, with ENUM of status
    ''' Added new code to handle the status of the port and enable/disable buttons as needed
    ''' Tidied up code to split up longer processes into smaller code subs
    ''' Added a HELLO button
    ''' 
    ''' 
    ''' TO DO
    ''' Test the saving of the COM port value with another serial port device added in
    ''' Find out how to add a new thread to update the UI and add a listener to the portStatus property - NOT NEEDED, SEE UPDATE FOR 27th
    ''' Add in the Background worker thread to get the serial data back from the Arduino
    ''' Change the labelStatus for a proper status bar - add the updating into the UI thread
    ''' 
    ''' 
    ''' </summary>

#Region "Declarations"
    Private Enum STATUS As Byte
        [_FIRST] = 0
        NULL = 0
        CLOSED = 1
        CONNECTING = 2
        TRANSMIT = 3
        RECEIVE = 4
        IDLE = 5
        OPEN = 6
        [_LAST] = 7
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

            ' Update the UI from the status
            UpdateUI()

        End Set
    End Property


    ' Declare the serial port
    Dim WithEvents mySerialPort As New SerialPort

    ' Notification object
    Dim isRun As New Threading.ManualResetEvent(False)

    Dim buf As New List(Of Byte)
    Dim bufLock As New Object

#End Region


    Private Sub buttonExit_Click(sender As Object, e As EventArgs) Handles buttonExit.Click
        Application.Exit()
    End Sub


    Private Sub comboPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboPort.SelectedIndexChanged

        mySerialPort.PortName = comboPort.SelectedItem

    End Sub

    Private Sub buttonConnect_Click(sender As Object, e As EventArgs) Handles buttonConnect.Click

        If buttonConnect.Text = "Connect" Then

            ' Save the settings
            If My.Settings("userPort") <> comboPort.SelectedItem.ToString Then
                My.Settings("userPort") = comboPort.SelectedItem.ToString
                My.Settings.Save()
            End If

            ' Open the COM Port
            _portStatus = STATUS.CONNECTING
            mySerialPort.BaudRate = 9600
            mySerialPort.ReadTimeout = 10000
            mySerialPort.Open()
            _portStatus = STATUS.OPEN

            mySerialPort.Write(":HH#")
            _portStatus = STATUS.IDLE

        Else

            ' Close the port
            mySerialPort.Close()
            _portStatus = STATUS.CLOSED

        End If

    End Sub

    Private Sub buttonFlap_Click(sender As Object, e As EventArgs) Handles buttonFlap.Click

        Try
            _portStatus = STATUS.TRANSMIT
            bgwSend.RunWorkerAsync(":TF#")

        Catch

            _portStatus = STATUS.PORT_ERROR

        End Try


    End Sub

    Private Sub UpdateButtons()

        Select Case portStatus

            Case STATUS.NULL
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
                labelStatus.Text = "Connecting To Arduino"

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

            Case STATUS.PORT_ERROR
                buttonConnect.Enabled = False
                buttonConnect.Text = "NO PORTS"
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
        Me.Refresh()

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


    Private Sub formMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim idxFound As Integer
        idxFound = comboPort.FindStringExact(My.Settings("userPort"))
        Try
            comboPort.SelectedIndex = idxFound
            _portStatus = STATUS.NULL
        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
        End Try


        ' Load the LEDs
        LoadLEDPins()

        ' Nudge value
        textNudgeValue.Text = My.Settings("userNudge")

        ' Open position
        textOpenPosition.Text = My.Settings("userOpenPosition")

        'this thread reads bytes and adds them to the buffer
        rcvdThrd = New Threading.Thread(AddressOf Receive)
        rcvdThrd.IsBackground = True

        'this thread examines the buffer to see if a 
        'complete message, as defined by the protocol, is available
        procprotoThrd = New Threading.Thread(AddressOf Protocol)
        procprotoThrd.IsBackground = True

        isRun.Set() 'we are running
        procprotoThrd.Start()
        rcvdThrd.Start()


    End Sub

    Private Sub buttonHello_Click(sender As Object, e As EventArgs) Handles buttonHello.Click

        Try
            _portStatus = STATUS.TRANSMIT
            bgwSend.RunWorkerAsync(":HH#")

        Catch
            Debug.WriteLine("ERROR in HELLO")
            _portStatus = STATUS.PORT_ERROR

        End Try
    End Sub

    Private Sub bgwSend_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwSend.DoWork

        portStatus = STATUS.TRANSMIT
        mySerialPort.WriteLine(e.Argument.ToString())

    End Sub

    Dim rcvd As New Threading.AutoResetEvent(False)
    Dim rcvdThrd As Threading.Thread
    Private Sub Receive()
        Do
            If mySerialPort.IsOpen Then 'is port open
                Dim numb As Integer = mySerialPort.BytesToRead 'number of bytes to read
                If numb > 0 Then
                    Dim temp(numb - 1) As Byte 'create a temporary buffer
                    Try
                        numb = mySerialPort.Read(temp, 0, numb) 'read the bytes
                        If numb <> temp.Length Then
                            Array.Resize(temp, numb)
                        End If
                        'add temp buffer to public buffer
                        Threading.Monitor.Enter(bufLock)
                        buf.AddRange(temp)
                        Threading.Monitor.Exit(bufLock)
                        procproto.Set() 'check for possible message
                    Catch ex As Exception
                        'fix error handler
                    End Try
                End If
            End If
            rcvd.WaitOne() 'wait for event handler to fire
        Loop While isRun.WaitOne(0)
    End Sub

    Dim procproto As New Threading.AutoResetEvent(False)
    Dim procprotoThrd As Threading.Thread
    'in this example the protocol is
    'some number of chars followed by 'eol'
    Private Sub Protocol()
        Const eol As Byte = Asc("#") 'EOL = LF
        Do
            If buf.Count > 0 Then 'some data present
                'is it a complete message as defined by our protocol?
                Dim idx As Integer
                Do
                    idx = buf.IndexOf(eol)
                    If idx >= 0 Then 'do I have a EOL?
                        'yes, extract message
                        Dim mess As New System.Text.StringBuilder
                        'get message without EOL and
                        'get rid of processed data in buffer
                        Threading.Monitor.Enter(bufLock)
                        mess.Append(mySerialPort.Encoding.GetChars(buf.ToArray, 0, idx))
                        buf.RemoveRange(0, idx + 1)
                        Threading.Monitor.Exit(bufLock)
                        '
                        'process the message, in this case...
                        'show message to user

                        Me.BeginInvoke(Sub()
                                           textSerialData.Text += mess.ToString
                                           'Label1.Text = mess.ToString
                                           'Label1.Refresh()
                                           _portStatus = STATUS.IDLE
                                       End Sub)
                    End If
                Loop While idx >= 0
            End If
            procproto.WaitOne() 'wait for signal to proccess next potential message
        Loop While isRun.WaitOne(0)
    End Sub

    Private Sub formMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        For Each sp As String In My.Computer.Ports.SerialPortNames
            comboPort.Items.Add(sp)
        Next

    End Sub

    Private Sub mySerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles mySerialPort.DataReceived
        rcvd.Set()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            isRun.Reset() 'closing
            'wake the threads
            rcvd.Set()
            procproto.Set()
            'wait on them
            rcvdThrd.Join()
            procprotoThrd.Join()
            If mySerialPort.IsOpen Then mySerialPort.Close()
        Catch ex As Exception

        End Try
    End Sub

End Class