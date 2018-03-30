<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScoreScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstNames = New System.Windows.Forms.ListBox()
        Me.lstScores = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblScoreSplash = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.lblInput = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstNames
        '
        Me.lstNames.BackColor = System.Drawing.Color.Black
        Me.lstNames.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstNames.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstNames.Font = New System.Drawing.Font("Castellar", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNames.ForeColor = System.Drawing.Color.White
        Me.lstNames.FormattingEnabled = True
        Me.lstNames.ItemHeight = 23
        Me.lstNames.Location = New System.Drawing.Point(3, 16)
        Me.lstNames.Name = "lstNames"
        Me.lstNames.Size = New System.Drawing.Size(275, 399)
        Me.lstNames.TabIndex = 0
        '
        'lstScores
        '
        Me.lstScores.BackColor = System.Drawing.Color.Black
        Me.lstScores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstScores.Dock = System.Windows.Forms.DockStyle.Right
        Me.lstScores.Font = New System.Drawing.Font("Castellar", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstScores.ForeColor = System.Drawing.Color.White
        Me.lstScores.FormattingEnabled = True
        Me.lstScores.ItemHeight = 23
        Me.lstScores.Location = New System.Drawing.Point(386, 16)
        Me.lstScores.Name = "lstScores"
        Me.lstScores.Size = New System.Drawing.Size(221, 399)
        Me.lstScores.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Black
        Me.GroupBox1.Controls.Add(Me.lstNames)
        Me.GroupBox1.Controls.Add(Me.lstScores)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(150, 141)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(610, 418)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "HEROES"
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Castellar", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Gold
        Me.lblTitle.Location = New System.Drawing.Point(273, 23)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(372, 35)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "Ye Olde High Scores"
        '
        'lblScoreSplash
        '
        Me.lblScoreSplash.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblScoreSplash.AutoEllipsis = True
        Me.lblScoreSplash.Font = New System.Drawing.Font("Castellar", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScoreSplash.ForeColor = System.Drawing.Color.White
        Me.lblScoreSplash.Location = New System.Drawing.Point(0, 58)
        Me.lblScoreSplash.Name = "lblScoreSplash"
        Me.lblScoreSplash.Size = New System.Drawing.Size(886, 80)
        Me.lblScoreSplash.TabIndex = 4
        Me.lblScoreSplash.Text = "Well Fought!  Thou hast earned"
        '
        'Button4
        '
        Me.Button4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Font = New System.Drawing.Font("Castellar", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(0, 565)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(898, 36)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "&Quit"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'txtInput
        '
        Me.txtInput.BackColor = System.Drawing.Color.MediumTurquoise
        Me.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInput.Location = New System.Drawing.Point(381, 118)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(379, 20)
        Me.txtInput.TabIndex = 6
        Me.txtInput.Text = "Enter thy name here" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblInput
        '
        Me.lblInput.AutoSize = True
        Me.lblInput.Font = New System.Drawing.Font("Castellar", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInput.ForeColor = System.Drawing.Color.White
        Me.lblInput.Location = New System.Drawing.Point(149, 118)
        Me.lblInput.Name = "lblInput"
        Me.lblInput.Size = New System.Drawing.Size(211, 19)
        Me.lblInput.TabIndex = 7
        Me.lblInput.Text = "What is thine name?"
        '
        'ScoreScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(898, 601)
        Me.Controls.Add(Me.lblInput)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblScoreSplash)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ScoreScreen"
        Me.Text = "ScoreScreen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstNames As System.Windows.Forms.ListBox
    Friend WithEvents lstScores As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblScoreSplash As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents lblInput As System.Windows.Forms.Label
End Class
