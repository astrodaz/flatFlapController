<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.buttonExit = New System.Windows.Forms.Button()
        Me.groupSerialFeedback = New System.Windows.Forms.GroupBox()
        Me.buttonConnect = New System.Windows.Forms.Button()
        Me.buttonReset = New System.Windows.Forms.Button()
        Me.buttonStats = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.comboPort = New System.Windows.Forms.ComboBox()
        Me.textSerialData = New System.Windows.Forms.TextBox()
        Me.buttonFlap = New System.Windows.Forms.Button()
        Me.buttonEL = New System.Windows.Forms.Button()
        Me.buttonSetZero = New System.Windows.Forms.Button()
        Me.buttonSetOpenPosition = New System.Windows.Forms.Button()
        Me.textOpenPosition = New System.Windows.Forms.TextBox()
        Me.buttonLED = New System.Windows.Forms.Button()
        Me.comboLED = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.buttonHello = New System.Windows.Forms.Button()
        Me.buttonSetAccel = New System.Windows.Forms.Button()
        Me.textStepperAccel = New System.Windows.Forms.TextBox()
        Me.buttonSetSpeed = New System.Windows.Forms.Button()
        Me.textStepperSpeed = New System.Windows.Forms.TextBox()
        Me.groupSerialFeedback.SuspendLayout()
        Me.SuspendLayout()
        '
        'buttonExit
        '
        Me.buttonExit.Location = New System.Drawing.Point(356, 344)
        Me.buttonExit.Name = "buttonExit"
        Me.buttonExit.Size = New System.Drawing.Size(72, 23)
        Me.buttonExit.TabIndex = 1
        Me.buttonExit.Text = "Exit"
        Me.buttonExit.UseVisualStyleBackColor = True
        '
        'groupSerialFeedback
        '
        Me.groupSerialFeedback.Controls.Add(Me.buttonConnect)
        Me.groupSerialFeedback.Controls.Add(Me.buttonReset)
        Me.groupSerialFeedback.Controls.Add(Me.Label1)
        Me.groupSerialFeedback.Controls.Add(Me.comboPort)
        Me.groupSerialFeedback.Controls.Add(Me.textSerialData)
        Me.groupSerialFeedback.Location = New System.Drawing.Point(20, 21)
        Me.groupSerialFeedback.Name = "groupSerialFeedback"
        Me.groupSerialFeedback.Size = New System.Drawing.Size(420, 146)
        Me.groupSerialFeedback.TabIndex = 2
        Me.groupSerialFeedback.TabStop = False
        Me.groupSerialFeedback.Text = "Serial Feedback"
        '
        'buttonConnect
        '
        Me.buttonConnect.Location = New System.Drawing.Point(329, 68)
        Me.buttonConnect.Name = "buttonConnect"
        Me.buttonConnect.Size = New System.Drawing.Size(75, 23)
        Me.buttonConnect.TabIndex = 19
        Me.buttonConnect.Text = "Connect"
        Me.buttonConnect.UseVisualStyleBackColor = True
        '
        'buttonReset
        '
        Me.buttonReset.Location = New System.Drawing.Point(329, 107)
        Me.buttonReset.Name = "buttonReset"
        Me.buttonReset.Size = New System.Drawing.Size(75, 23)
        Me.buttonReset.TabIndex = 18
        Me.buttonReset.Tag = "control"
        Me.buttonReset.Text = "Reset"
        Me.ToolTip1.SetToolTip(Me.buttonReset, "Resets all values back to default")
        Me.buttonReset.UseVisualStyleBackColor = True
        '
        'buttonStats
        '
        Me.buttonStats.Location = New System.Drawing.Point(113, 185)
        Me.buttonStats.Name = "buttonStats"
        Me.buttonStats.Size = New System.Drawing.Size(75, 23)
        Me.buttonStats.TabIndex = 17
        Me.buttonStats.Tag = "control"
        Me.buttonStats.Text = "Get Values"
        Me.ToolTip1.SetToolTip(Me.buttonStats, "Return all values from the board")
        Me.buttonStats.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(326, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Serial Port"
        '
        'comboPort
        '
        Me.comboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboPort.FormattingEnabled = True
        Me.comboPort.Location = New System.Drawing.Point(329, 41)
        Me.comboPort.Name = "comboPort"
        Me.comboPort.Size = New System.Drawing.Size(75, 21)
        Me.comboPort.TabIndex = 15
        '
        'textSerialData
        '
        Me.textSerialData.Location = New System.Drawing.Point(12, 22)
        Me.textSerialData.Multiline = True
        Me.textSerialData.Name = "textSerialData"
        Me.textSerialData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textSerialData.Size = New System.Drawing.Size(291, 108)
        Me.textSerialData.TabIndex = 0
        '
        'buttonFlap
        '
        Me.buttonFlap.BackColor = System.Drawing.SystemColors.Control
        Me.buttonFlap.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.buttonFlap.Location = New System.Drawing.Point(194, 185)
        Me.buttonFlap.Name = "buttonFlap"
        Me.buttonFlap.Size = New System.Drawing.Size(75, 23)
        Me.buttonFlap.TabIndex = 3
        Me.buttonFlap.Tag = "control"
        Me.buttonFlap.Text = "Toggle Flap"
        Me.ToolTip1.SetToolTip(Me.buttonFlap, "Toggles the flap open or closed")
        Me.buttonFlap.UseVisualStyleBackColor = False
        '
        'buttonEL
        '
        Me.buttonEL.Location = New System.Drawing.Point(275, 185)
        Me.buttonEL.Name = "buttonEL"
        Me.buttonEL.Size = New System.Drawing.Size(75, 23)
        Me.buttonEL.TabIndex = 4
        Me.buttonEL.Tag = "control"
        Me.buttonEL.Text = "EL Power"
        Me.ToolTip1.SetToolTip(Me.buttonEL, "Toggle the EL Panel power")
        Me.buttonEL.UseVisualStyleBackColor = True
        '
        'buttonSetZero
        '
        Me.buttonSetZero.Location = New System.Drawing.Point(32, 269)
        Me.buttonSetZero.Name = "buttonSetZero"
        Me.buttonSetZero.Size = New System.Drawing.Size(75, 23)
        Me.buttonSetZero.TabIndex = 10
        Me.buttonSetZero.Tag = "control"
        Me.buttonSetZero.Text = "Set Zero"
        Me.ToolTip1.SetToolTip(Me.buttonSetZero, "Sets the current position of the stepper to be 0 (Closed)")
        Me.buttonSetZero.UseVisualStyleBackColor = True
        '
        'buttonSetOpenPosition
        '
        Me.buttonSetOpenPosition.Location = New System.Drawing.Point(113, 269)
        Me.buttonSetOpenPosition.Name = "buttonSetOpenPosition"
        Me.buttonSetOpenPosition.Size = New System.Drawing.Size(75, 23)
        Me.buttonSetOpenPosition.TabIndex = 11
        Me.buttonSetOpenPosition.Tag = "control"
        Me.buttonSetOpenPosition.Text = "Set Open"
        Me.ToolTip1.SetToolTip(Me.buttonSetOpenPosition, "Set the value in the text box to be the new Open position")
        Me.buttonSetOpenPosition.UseVisualStyleBackColor = True
        '
        'textOpenPosition
        '
        Me.textOpenPosition.Location = New System.Drawing.Point(113, 299)
        Me.textOpenPosition.MaxLength = 4
        Me.textOpenPosition.Name = "textOpenPosition"
        Me.textOpenPosition.Size = New System.Drawing.Size(75, 20)
        Me.textOpenPosition.TabIndex = 12
        Me.textOpenPosition.Tag = "control"
        '
        'buttonLED
        '
        Me.buttonLED.Location = New System.Drawing.Point(194, 269)
        Me.buttonLED.Name = "buttonLED"
        Me.buttonLED.Size = New System.Drawing.Size(75, 23)
        Me.buttonLED.TabIndex = 14
        Me.buttonLED.Tag = "control"
        Me.buttonLED.Text = "Set LED"
        Me.ToolTip1.SetToolTip(Me.buttonLED, "Set the pin in the combo box to be the LED pin on the board")
        Me.buttonLED.UseVisualStyleBackColor = True
        '
        'comboLED
        '
        Me.comboLED.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboLED.FormattingEnabled = True
        Me.comboLED.Location = New System.Drawing.Point(194, 298)
        Me.comboLED.Name = "comboLED"
        Me.comboLED.Size = New System.Drawing.Size(72, 21)
        Me.comboLED.TabIndex = 15
        Me.comboLED.Tag = "control"
        '
        'buttonHello
        '
        Me.buttonHello.Location = New System.Drawing.Point(32, 185)
        Me.buttonHello.Name = "buttonHello"
        Me.buttonHello.Size = New System.Drawing.Size(75, 23)
        Me.buttonHello.TabIndex = 21
        Me.buttonHello.Text = "Hello"
        Me.ToolTip1.SetToolTip(Me.buttonHello, "Flashes the LED on the board")
        Me.buttonHello.UseVisualStyleBackColor = True
        '
        'buttonSetAccel
        '
        Me.buttonSetAccel.Location = New System.Drawing.Point(275, 269)
        Me.buttonSetAccel.Name = "buttonSetAccel"
        Me.buttonSetAccel.Size = New System.Drawing.Size(75, 23)
        Me.buttonSetAccel.TabIndex = 22
        Me.buttonSetAccel.Text = "Set Accel"
        Me.ToolTip1.SetToolTip(Me.buttonSetAccel, "Set Stepper Acceleration")
        Me.buttonSetAccel.UseVisualStyleBackColor = True
        '
        'textStepperAccel
        '
        Me.textStepperAccel.Location = New System.Drawing.Point(275, 298)
        Me.textStepperAccel.MaxLength = 3
        Me.textStepperAccel.Name = "textStepperAccel"
        Me.textStepperAccel.Size = New System.Drawing.Size(75, 20)
        Me.textStepperAccel.TabIndex = 23
        Me.textStepperAccel.Text = "0"
        '
        'buttonSetSpeed
        '
        Me.buttonSetSpeed.Location = New System.Drawing.Point(356, 269)
        Me.buttonSetSpeed.Name = "buttonSetSpeed"
        Me.buttonSetSpeed.Size = New System.Drawing.Size(75, 23)
        Me.buttonSetSpeed.TabIndex = 24
        Me.buttonSetSpeed.Text = "Set Speed"
        Me.buttonSetSpeed.UseVisualStyleBackColor = True
        '
        'textStepperSpeed
        '
        Me.textStepperSpeed.Location = New System.Drawing.Point(356, 298)
        Me.textStepperSpeed.MaxLength = 4
        Me.textStepperSpeed.Name = "textStepperSpeed"
        Me.textStepperSpeed.Size = New System.Drawing.Size(75, 20)
        Me.textStepperSpeed.TabIndex = 25
        Me.textStepperSpeed.Text = "0"
        '
        'formMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 382)
        Me.Controls.Add(Me.textStepperSpeed)
        Me.Controls.Add(Me.buttonSetSpeed)
        Me.Controls.Add(Me.textStepperAccel)
        Me.Controls.Add(Me.buttonSetAccel)
        Me.Controls.Add(Me.buttonHello)
        Me.Controls.Add(Me.buttonStats)
        Me.Controls.Add(Me.comboLED)
        Me.Controls.Add(Me.buttonLED)
        Me.Controls.Add(Me.textOpenPosition)
        Me.Controls.Add(Me.buttonSetOpenPosition)
        Me.Controls.Add(Me.buttonSetZero)
        Me.Controls.Add(Me.buttonEL)
        Me.Controls.Add(Me.buttonFlap)
        Me.Controls.Add(Me.groupSerialFeedback)
        Me.Controls.Add(Me.buttonExit)
        Me.Name = "formMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FlatFlap Stepper Controller"
        Me.groupSerialFeedback.ResumeLayout(False)
        Me.groupSerialFeedback.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents buttonExit As Button
    Friend WithEvents groupSerialFeedback As GroupBox
    Friend WithEvents textSerialData As TextBox
    Friend WithEvents buttonFlap As Button
    Friend WithEvents buttonEL As Button
    Friend WithEvents buttonSetZero As Button
    Friend WithEvents buttonSetOpenPosition As Button
    Friend WithEvents textOpenPosition As TextBox
    Friend WithEvents buttonLED As Button
    Friend WithEvents comboLED As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents comboPort As ComboBox
    Friend WithEvents buttonStats As Button
    Friend WithEvents buttonReset As Button
    Friend WithEvents buttonConnect As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents buttonHello As Button
    Friend WithEvents buttonSetAccel As Button
    Friend WithEvents textStepperAccel As TextBox
    Friend WithEvents buttonSetSpeed As Button
    Friend WithEvents textStepperSpeed As TextBox
End Class
