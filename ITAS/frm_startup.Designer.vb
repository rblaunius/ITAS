<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Startup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Startup))
        Me.btn_continue = New System.Windows.Forms.Button()
        Me.tb_initials = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn_continue
        '
        Me.btn_continue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_continue.BackgroundImage = Global.ITAS.My.Resources.Resources.button_modern
        Me.btn_continue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_continue.FlatAppearance.BorderSize = 0
        Me.btn_continue.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_continue.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_continue.Location = New System.Drawing.Point(299, 349)
        Me.btn_continue.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btn_continue.Name = "btn_continue"
        Me.btn_continue.Size = New System.Drawing.Size(124, 30)
        Me.btn_continue.TabIndex = 0
        Me.btn_continue.Text = "Continue"
        Me.btn_continue.UseCompatibleTextRendering = True
        Me.btn_continue.UseVisualStyleBackColor = True
        '
        'tb_initials
        '
        Me.tb_initials.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.tb_initials.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tb_initials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tb_initials.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tb_initials.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_initials.Location = New System.Drawing.Point(123, 350)
        Me.tb_initials.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tb_initials.Name = "tb_initials"
        Me.tb_initials.Size = New System.Drawing.Size(85, 29)
        Me.tb_initials.TabIndex = 1
        Me.tb_initials.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frm_Startup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = Global.ITAS.My.Resources.Resources.frm_startup
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(459, 400)
        Me.Controls.Add(Me.tb_initials)
        Me.Controls.Add(Me.btn_continue)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "frm_Startup"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ITAS 2020 Startup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_continue As Button
    Friend WithEvents tb_initials As TextBox
End Class
