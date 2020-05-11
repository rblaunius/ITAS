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
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tab_general = New System.Windows.Forms.TabPage()
        Me.checkbox_StartDark = New System.Windows.Forms.CheckBox()
        Me.checkbox_ShowStartup = New System.Windows.Forms.CheckBox()
        Me.tab_telescope = New System.Windows.Forms.TabPage()
        Me.btn_scan = New System.Windows.Forms.Button()
        Me.lbl_status = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tab_remotesetup = New System.Windows.Forms.TabPage()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.tab_general.SuspendLayout()
        Me.tab_telescope.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tab_general)
        Me.TabControl1.Controls.Add(Me.tab_telescope)
        Me.TabControl1.Controls.Add(Me.tab_remotesetup)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.HotTrack = True
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(536, 448)
        Me.TabControl1.TabIndex = 0
        '
        'tab_general
        '
        Me.tab_general.BackColor = System.Drawing.Color.White
        Me.tab_general.Controls.Add(Me.checkbox_StartDark)
        Me.tab_general.Controls.Add(Me.checkbox_ShowStartup)
        Me.tab_general.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tab_general.Location = New System.Drawing.Point(4, 30)
        Me.tab_general.Name = "tab_general"
        Me.tab_general.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_general.Size = New System.Drawing.Size(528, 414)
        Me.tab_general.TabIndex = 0
        Me.tab_general.Text = "General"
        '
        'checkbox_StartDark
        '
        Me.checkbox_StartDark.AutoSize = True
        Me.checkbox_StartDark.Location = New System.Drawing.Point(6, 37)
        Me.checkbox_StartDark.Name = "checkbox_StartDark"
        Me.checkbox_StartDark.Size = New System.Drawing.Size(255, 28)
        Me.checkbox_StartDark.TabIndex = 5
        Me.checkbox_StartDark.Text = "Always Load ITAS in Dark Mode"
        Me.checkbox_StartDark.UseCompatibleTextRendering = True
        Me.checkbox_StartDark.UseVisualStyleBackColor = True
        '
        'checkbox_ShowStartup
        '
        Me.checkbox_ShowStartup.AutoSize = True
        Me.checkbox_ShowStartup.Location = New System.Drawing.Point(6, 6)
        Me.checkbox_ShowStartup.Name = "checkbox_ShowStartup"
        Me.checkbox_ShowStartup.Size = New System.Drawing.Size(355, 25)
        Me.checkbox_ShowStartup.TabIndex = 4
        Me.checkbox_ShowStartup.Text = "Open Login Window Every Time ITAS Launches"
        Me.ToolTip1.SetToolTip(Me.checkbox_ShowStartup, "Leaving this property unchecked will load the last user's log and remember all pr" &
        "eferences.")
        Me.checkbox_ShowStartup.UseVisualStyleBackColor = True
        '
        'tab_telescope
        '
        Me.tab_telescope.Controls.Add(Me.btn_scan)
        Me.tab_telescope.Controls.Add(Me.lbl_status)
        Me.tab_telescope.Controls.Add(Me.Label1)
        Me.tab_telescope.Location = New System.Drawing.Point(4, 30)
        Me.tab_telescope.Name = "tab_telescope"
        Me.tab_telescope.Size = New System.Drawing.Size(528, 414)
        Me.tab_telescope.TabIndex = 1
        Me.tab_telescope.Text = "Telescope Setup"
        Me.tab_telescope.UseVisualStyleBackColor = True
        '
        'btn_scan
        '
        Me.btn_scan.Location = New System.Drawing.Point(190, 7)
        Me.btn_scan.Name = "btn_scan"
        Me.btn_scan.Size = New System.Drawing.Size(190, 32)
        Me.btn_scan.TabIndex = 2
        Me.btn_scan.Text = "Scan for Connection"
        Me.btn_scan.UseVisualStyleBackColor = True
        '
        'lbl_status
        '
        Me.lbl_status.AutoSize = True
        Me.lbl_status.Location = New System.Drawing.Point(66, 13)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(114, 21)
        Me.lbl_status.TabIndex = 1
        Me.lbl_status.Text = "Not Connected"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Status:"
        '
        'tab_remotesetup
        '
        Me.tab_remotesetup.Location = New System.Drawing.Point(4, 30)
        Me.tab_remotesetup.Name = "tab_remotesetup"
        Me.tab_remotesetup.Size = New System.Drawing.Size(528, 414)
        Me.tab_remotesetup.TabIndex = 2
        Me.tab_remotesetup.Text = "Remote Setup"
        Me.tab_remotesetup.UseVisualStyleBackColor = True
        '
        'frm_preferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 448)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frm_preferences"
        Me.Text = "Preferences"
        Me.TopMost = True
        Me.TabControl1.ResumeLayout(False)
        Me.tab_general.ResumeLayout(False)
        Me.tab_general.PerformLayout()
        Me.tab_telescope.ResumeLayout(False)
        Me.tab_telescope.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tab_general As TabPage
    Friend WithEvents checkbox_ShowStartup As CheckBox
    Friend WithEvents checkbox_StartDark As CheckBox
    Friend WithEvents tab_telescope As TabPage
    Friend WithEvents btn_scan As Button
    Friend WithEvents lbl_status As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tab_remotesetup As TabPage
    Friend WithEvents ToolTip1 As ToolTip
End Class
