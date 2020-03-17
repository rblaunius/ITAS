<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_preferences
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tab_general = New System.Windows.Forms.TabPage()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.tab_appearance = New System.Windows.Forms.TabPage()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.tab_misc = New System.Windows.Forms.TabPage()
        Me.loginwindow = New System.Windows.Forms.Label()
        Me.darkmode = New System.Windows.Forms.Label()
        Me.lastuser = New System.Windows.Forms.Label()
        Me.lasttele = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tab_general.SuspendLayout()
        Me.tab_appearance.SuspendLayout()
        Me.tab_misc.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tab_general)
        Me.TabControl1.Controls.Add(Me.tab_appearance)
        Me.TabControl1.Controls.Add(Me.tab_misc)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.HotTrack = True
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(396, 379)
        Me.TabControl1.TabIndex = 0
        '
        'tab_general
        '
        Me.tab_general.BackColor = System.Drawing.Color.White
        Me.tab_general.Controls.Add(Me.CheckBox3)
        Me.tab_general.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tab_general.Location = New System.Drawing.Point(4, 30)
        Me.tab_general.Name = "tab_general"
        Me.tab_general.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_general.Size = New System.Drawing.Size(388, 345)
        Me.tab_general.TabIndex = 0
        Me.tab_general.Text = "General"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(6, 6)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(263, 25)
        Me.CheckBox3.TabIndex = 4
        Me.CheckBox3.Text = "Open Startup Window Every Time"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'tab_appearance
        '
        Me.tab_appearance.Controls.Add(Me.CheckBox2)
        Me.tab_appearance.Controls.Add(Me.CheckBox1)
        Me.tab_appearance.Controls.Add(Me.RadioButton3)
        Me.tab_appearance.Controls.Add(Me.RadioButton1)
        Me.tab_appearance.Controls.Add(Me.RadioButton2)
        Me.tab_appearance.Location = New System.Drawing.Point(4, 30)
        Me.tab_appearance.Name = "tab_appearance"
        Me.tab_appearance.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_appearance.Size = New System.Drawing.Size(388, 345)
        Me.tab_appearance.TabIndex = 1
        Me.tab_appearance.Text = "Appearance"
        Me.tab_appearance.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(8, 68)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(220, 25)
        Me.CheckBox2.TabIndex = 4
        Me.CheckBox2.Text = "Open Fullscreen On Startup"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(8, 37)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(214, 25)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "Use This Theme on Startup"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(204, 6)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(83, 25)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Modern"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(8, 6)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(61, 25)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Dark"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(93, 6)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(96, 25)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Very Dark"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'tab_misc
        '
        Me.tab_misc.Controls.Add(Me.loginwindow)
        Me.tab_misc.Controls.Add(Me.darkmode)
        Me.tab_misc.Controls.Add(Me.lastuser)
        Me.tab_misc.Controls.Add(Me.lasttele)
        Me.tab_misc.Controls.Add(Me.Label4)
        Me.tab_misc.Controls.Add(Me.Label3)
        Me.tab_misc.Controls.Add(Me.Label2)
        Me.tab_misc.Controls.Add(Me.Label1)
        Me.tab_misc.Controls.Add(Me.Button1)
        Me.tab_misc.Location = New System.Drawing.Point(4, 30)
        Me.tab_misc.Name = "tab_misc"
        Me.tab_misc.Size = New System.Drawing.Size(388, 345)
        Me.tab_misc.TabIndex = 2
        Me.tab_misc.Text = "Misc."
        Me.tab_misc.UseVisualStyleBackColor = True
        '
        'loginwindow
        '
        Me.loginwindow.AutoSize = True
        Me.loginwindow.Location = New System.Drawing.Point(237, 134)
        Me.loginwindow.Name = "loginwindow"
        Me.loginwindow.Size = New System.Drawing.Size(35, 21)
        Me.loginwindow.TabIndex = 13
        Me.loginwindow.Text = "text"
        '
        'darkmode
        '
        Me.darkmode.AutoSize = True
        Me.darkmode.Location = New System.Drawing.Point(237, 113)
        Me.darkmode.Name = "darkmode"
        Me.darkmode.Size = New System.Drawing.Size(35, 21)
        Me.darkmode.TabIndex = 12
        Me.darkmode.Text = "text"
        '
        'lastuser
        '
        Me.lastuser.AutoSize = True
        Me.lastuser.Location = New System.Drawing.Point(237, 92)
        Me.lastuser.Name = "lastuser"
        Me.lastuser.Size = New System.Drawing.Size(35, 21)
        Me.lastuser.TabIndex = 11
        Me.lastuser.Text = "text"
        '
        'lasttele
        '
        Me.lasttele.AutoSize = True
        Me.lasttele.Location = New System.Drawing.Point(237, 71)
        Me.lasttele.Name = "lasttele"
        Me.lasttele.Size = New System.Drawing.Size(35, 21)
        Me.lasttele.TabIndex = 10
        Me.lasttele.Text = "text"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(202, 21)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Dark Mode Enabled at Start:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(163, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 21)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Last User:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(226, 21)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Login Window Enabled at Start:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(129, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 21)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Last Telescope:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(372, 34)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Refresh Debug Stats"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frm_preferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 379)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frm_preferences"
        Me.Text = "Preferences"
        Me.TopMost = True
        Me.TabControl1.ResumeLayout(False)
        Me.tab_general.ResumeLayout(False)
        Me.tab_general.PerformLayout()
        Me.tab_appearance.ResumeLayout(False)
        Me.tab_appearance.PerformLayout()
        Me.tab_misc.ResumeLayout(False)
        Me.tab_misc.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tab_general As TabPage
    Friend WithEvents tab_appearance As TabPage
    Friend WithEvents tab_misc As TabPage
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents loginwindow As Label
    Friend WithEvents darkmode As Label
    Friend WithEvents lastuser As Label
    Friend WithEvents lasttele As Label
    Friend WithEvents Label4 As Label
End Class
