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
        Me.buttonNudgeCW = New System.Windows.Forms.Button()
        Me.buttonNudgeCCW = New System.Windows.Forms.Button()
        Me.textNudgeValue = New System.Windows.Forms.TextBox()
        Me.buttonSetZero = New System.Windows.Forms.Button()
        Me.buttonSetOpenPosition = New System.Windows.Forms.Button()
        Me.textOpenPosition = New System.Windows.Forms.TextBox()
        Me.buttonLED = New System.Windows.Forms.Button()
        Me.comboLED = New System.Windows.Forms.ComboBox()
        Me.groupSerialFeedback.SuspendLayout()
        Me.SuspendLayout()
        '
        'buttonExit
        '
        Me.buttonExit.Location = New System.Drawing.Point(524, 359)
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
        Me.groupSerialFeedback.Controls.Add(Me.buttonStats)
        Me.groupSerialFeedback.Controls.Add(Me.Label1)
        Me.groupSerialFeedback.Controls.Add(Me.comboPort)
        Me.groupSerialFeedback.Controls.Add(Me.textSerialData)
        Me.groupSerialFeedback.Location = New System.Drawing.Point(20, 21)
        Me.groupSerialFeedback.Name = "groupSerialFeedback"
        Me.groupSerialFeedback.Size = New System.Drawing.Size(591, 256)
        Me.groupSerialFeedback.TabIndex = 2
        Me.groupSerialFeedback.TabStop = False
        Me.groupSerialFeedback.Text = "Serial Feedback"
        '
        'buttonConnect
        '
        Me.buttonConnect.Location = New System.Drawing.Point(504, 68)
        Me.buttonConnect.Name = "buttonConnect"
        Me.buttonConnect.Size = New System.Drawing.Size(75, 23)
        Me.buttonConnect.TabIndex = 19
        Me.buttonConnect.Text = "Connect"
        Me.buttonConnect.UseVisualStyleBackColor = True
        '
        'buttonReset
        '
        Me.buttonReset.Location = New System.Drawing.Point(501, 216)
        Me.buttonReset.Name = "buttonReset"
        Me.buttonReset.Size = New System.Drawing.Size(75, 23)
        Me.buttonReset.TabIndex = 18
        Me.buttonReset.Text = "Reset"
        Me.buttonReset.UseVisualStyleBackColor = True
        '
        'buttonStats
        '
        Me.buttonStats.Location = New System.Drawing.Point(501, 178)
        Me.buttonStats.Name = "buttonStats"
        Me.buttonStats.Size = New System.Drawing.Size(75, 23)
        Me.buttonStats.TabIndex = 17
        Me.buttonStats.Text = "Get Values"
        Me.buttonStats.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(501, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Serial Port"
        '
        'comboPort
        '
        Me.comboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboPort.FormattingEnabled = True
        Me.comboPort.Location = New System.Drawing.Point(504, 41)
        Me.comboPort.Name = "comboPort"
        Me.comboPort.Size = New System.Drawing.Size(75, 21)
        Me.comboPort.TabIndex = 15
        '
        'textSerialData
        '
        Me.textSerialData.Enabled = False
        Me.textSerialData.Location = New System.Drawing.Point(12, 22)
        Me.textSerialData.Multiline = True
        Me.textSerialData.Name = "textSerialData"
        Me.textSerialData.Size = New System.Drawing.Size(472, 217)
        Me.textSerialData.TabIndex = 0
        '
        'buttonFlap
        '
        Me.buttonFlap.BackColor = System.Drawing.SystemColors.Control
        Me.buttonFlap.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.buttonFlap.Location = New System.Drawing.Point(20, 298)
        Me.buttonFlap.Name = "buttonFlap"
        Me.buttonFlap.Size = New System.Drawing.Size(75, 23)
        Me.buttonFlap.TabIndex = 3
        Me.buttonFlap.Text = "Flap"
        Me.buttonFlap.UseVisualStyleBackColor = False
        '
        'buttonEL
        '
        Me.buttonEL.Location = New System.Drawing.Point(20, 327)
        Me.buttonEL.Name = "buttonEL"
        Me.buttonEL.Size = New System.Drawing.Size(75, 23)
        Me.buttonEL.TabIndex = 4
        Me.buttonEL.Text = "EL Panel"
        Me.buttonEL.UseVisualStyleBackColor = True
        '
        'buttonNudgeCW
        '
        Me.buttonNudgeCW.Location = New System.Drawing.Point(139, 298)
        Me.buttonNudgeCW.Name = "buttonNudgeCW"
        Me.buttonNudgeCW.Size = New System.Drawing.Size(75, 23)
        Me.buttonNudgeCW.TabIndex = 7
        Me.buttonNudgeCW.Text = "Nudge CW"
        Me.buttonNudgeCW.UseVisualStyleBackColor = True
        '
        'buttonNudgeCCW
        '
        Me.buttonNudgeCCW.Location = New System.Drawing.Point(139, 356)
        Me.buttonNudgeCCW.Name = "buttonNudgeCCW"
        Me.buttonNudgeCCW.Size = New System.Drawing.Size(75, 23)
        Me.buttonNudgeCCW.TabIndex = 8
        Me.buttonNudgeCCW.Text = "Nudge CCW"
        Me.buttonNudgeCCW.UseVisualStyleBackColor = True
        '
        'textNudgeValue
        '
        Me.textNudgeValue.Location = New System.Drawing.Point(151, 330)
        Me.textNudgeValue.MaxLength = 2
        Me.textNudgeValue.Name = "textNudgeValue"
        Me.textNudgeValue.Size = New System.Drawing.Size(53, 20)
        Me.textNudgeValue.TabIndex = 9
        '
        'buttonSetZero
        '
        Me.buttonSetZero.Location = New System.Drawing.Point(260, 298)
        Me.buttonSetZero.Name = "buttonSetZero"
        Me.buttonSetZero.Size = New System.Drawing.Size(75, 23)
        Me.buttonSetZero.TabIndex = 10
        Me.buttonSetZero.Text = "Set Zero"
        Me.buttonSetZero.UseVisualStyleBackColor = True
        '
        'buttonSetOpenPosition
        '
        Me.buttonSetOpenPosition.Location = New System.Drawing.Point(260, 330)
        Me.buttonSetOpenPosition.Name = "buttonSetOpenPosition"
        Me.buttonSetOpenPosition.Size = New System.Drawing.Size(75, 23)
        Me.buttonSetOpenPosition.TabIndex = 11
        Me.buttonSetOpenPosition.Text = "Set Open"
        Me.buttonSetOpenPosition.UseVisualStyleBackColor = True
        '
        'textOpenPosition
        '
        Me.textOpenPosition.Location = New System.Drawing.Point(268, 359)
        Me.textOpenPosition.MaxLength = 4
        Me.textOpenPosition.Name = "textOpenPosition"
        Me.textOpenPosition.Size = New System.Drawing.Size(55, 20)
        Me.textOpenPosition.TabIndex = 12
        '
        'buttonLED
        '
        Me.buttonLED.Location = New System.Drawing.Point(376, 298)
        Me.buttonLED.Name = "buttonLED"
        Me.buttonLED.Size = New System.Drawing.Size(75, 23)
        Me.buttonLED.TabIndex = 14
        Me.buttonLED.Text = "Set LED"
        Me.buttonLED.UseVisualStyleBackColor = True
        '
        'comboLED
        '
        Me.comboLED.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboLED.FormattingEnabled = True
        Me.comboLED.Location = New System.Drawing.Point(379, 332)
        Me.comboLED.Name = "comboLED"
        Me.comboLED.Size = New System.Drawing.Size(72, 21)
        Me.comboLED.TabIndex = 15
        '
        'formMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 399)
        Me.Controls.Add(Me.comboLED)
        Me.Controls.Add(Me.buttonLED)
        Me.Controls.Add(Me.textOpenPosition)
        Me.Controls.Add(Me.buttonSetOpenPosition)
        Me.Controls.Add(Me.buttonSetZero)
        Me.Controls.Add(Me.textNudgeValue)
        Me.Controls.Add(Me.buttonNudgeCCW)
        Me.Controls.Add(Me.buttonNudgeCW)
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
    Friend WithEvents buttonNudgeCW As Button
    Friend WithEvents buttonNudgeCCW As Button
    Friend WithEvents textNudgeValue As TextBox
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
End Class
