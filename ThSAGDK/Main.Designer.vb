<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.ModeBButton = New System.Windows.Forms.Button()
        Me.AboutButton = New System.Windows.Forms.Button()
        Me.TOPButton = New System.Windows.Forms.Button()
        Me.MinButton = New System.Windows.Forms.Button()
        Me.MaxButton = New System.Windows.Forms.Button()
        Me.UpExitButton = New System.Windows.Forms.Button()
        Me.BasicPanel = New System.Windows.Forms.Panel()
        Me.EditorButton = New System.Windows.Forms.Button()
        Me.UnDoButton = New System.Windows.Forms.Button()
        Me.DoButton = New System.Windows.Forms.Button()
        Me.AdvancedPanel = New System.Windows.Forms.Panel()
        Me.DecOder = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ModeAButton = New System.Windows.Forms.Button()
        Me.BasicPanel.SuspendLayout()
        Me.AdvancedPanel.SuspendLayout()
        Me.DecOder.SuspendLayout()
        Me.SuspendLayout()
        '
        'ModeBButton
        '
        Me.ModeBButton.BackColor = System.Drawing.Color.Transparent
        Me.ModeBButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.ModeBButton.FlatAppearance.BorderSize = 2
        Me.ModeBButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.ModeBButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ModeBButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ModeBButton.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.ModeBButton.Location = New System.Drawing.Point(12, 660)
        Me.ModeBButton.Name = "ModeBButton"
        Me.ModeBButton.Size = New System.Drawing.Size(128, 48)
        Me.ModeBButton.TabIndex = 0
        Me.ModeBButton.Text = "Advanced"
        Me.ModeBButton.UseVisualStyleBackColor = False
        '
        'AboutButton
        '
        Me.AboutButton.BackColor = System.Drawing.Color.Transparent
        Me.AboutButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.AboutButton.FlatAppearance.BorderSize = 0
        Me.AboutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.AboutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.AboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AboutButton.Font = New System.Drawing.Font("微软雅黑 Light", 7.25!)
        Me.AboutButton.Location = New System.Drawing.Point(0, 0)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(48, 48)
        Me.AboutButton.TabIndex = 1
        Me.AboutButton.Text = "TH SAGDK"
        Me.AboutButton.UseVisualStyleBackColor = False
        '
        'TOPButton
        '
        Me.TOPButton.BackColor = System.Drawing.Color.Transparent
        Me.TOPButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.TOPButton.FlatAppearance.BorderSize = 0
        Me.TOPButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TOPButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TOPButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TOPButton.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.TOPButton.Location = New System.Drawing.Point(48, 0)
        Me.TOPButton.Name = "TOPButton"
        Me.TOPButton.Size = New System.Drawing.Size(1016, 48)
        Me.TOPButton.TabIndex = 2
        Me.TOPButton.Text = "ThSAG Development Kit"
        Me.TOPButton.UseVisualStyleBackColor = False
        '
        'MinButton
        '
        Me.MinButton.BackColor = System.Drawing.Color.Transparent
        Me.MinButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.MinButton.FlatAppearance.BorderSize = 0
        Me.MinButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.MinButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MinButton.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.MinButton.Location = New System.Drawing.Point(1064, 0)
        Me.MinButton.Name = "MinButton"
        Me.MinButton.Size = New System.Drawing.Size(72, 48)
        Me.MinButton.TabIndex = 3
        Me.MinButton.Text = "Mi"
        Me.MinButton.UseVisualStyleBackColor = False
        '
        'MaxButton
        '
        Me.MaxButton.BackColor = System.Drawing.Color.Transparent
        Me.MaxButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.MaxButton.FlatAppearance.BorderSize = 0
        Me.MaxButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.MaxButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MaxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MaxButton.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.MaxButton.Location = New System.Drawing.Point(1136, 0)
        Me.MaxButton.Name = "MaxButton"
        Me.MaxButton.Size = New System.Drawing.Size(72, 48)
        Me.MaxButton.TabIndex = 4
        Me.MaxButton.Text = "Ma"
        Me.MaxButton.UseVisualStyleBackColor = False
        '
        'UpExitButton
        '
        Me.UpExitButton.BackColor = System.Drawing.Color.Transparent
        Me.UpExitButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.UpExitButton.FlatAppearance.BorderSize = 0
        Me.UpExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.UpExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UpExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UpExitButton.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.UpExitButton.Location = New System.Drawing.Point(1208, 0)
        Me.UpExitButton.Name = "UpExitButton"
        Me.UpExitButton.Size = New System.Drawing.Size(72, 48)
        Me.UpExitButton.TabIndex = 5
        Me.UpExitButton.Text = "X"
        Me.UpExitButton.UseVisualStyleBackColor = False
        '
        'BasicPanel
        '
        Me.BasicPanel.AutoSize = True
        Me.BasicPanel.BackColor = System.Drawing.Color.Transparent
        Me.BasicPanel.Controls.Add(Me.EditorButton)
        Me.BasicPanel.Controls.Add(Me.UnDoButton)
        Me.BasicPanel.Controls.Add(Me.DoButton)
        Me.BasicPanel.Location = New System.Drawing.Point(247, 229)
        Me.BasicPanel.Name = "BasicPanel"
        Me.BasicPanel.Size = New System.Drawing.Size(786, 262)
        Me.BasicPanel.TabIndex = 9
        '
        'EditorButton
        '
        Me.EditorButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.EditorButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.EditorButton.FlatAppearance.BorderSize = 0
        Me.EditorButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.EditorButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.EditorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EditorButton.Font = New System.Drawing.Font("微软雅黑 Light", 20.25!)
        Me.EditorButton.Location = New System.Drawing.Point(527, 3)
        Me.EditorButton.Name = "EditorButton"
        Me.EditorButton.Size = New System.Drawing.Size(256, 256)
        Me.EditorButton.TabIndex = 11
        Me.EditorButton.Text = "Editor"
        Me.EditorButton.UseVisualStyleBackColor = False
        '
        'UnDoButton
        '
        Me.UnDoButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.UnDoButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.UnDoButton.FlatAppearance.BorderSize = 0
        Me.UnDoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.UnDoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.UnDoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UnDoButton.Font = New System.Drawing.Font("微软雅黑 Light", 20.25!)
        Me.UnDoButton.Location = New System.Drawing.Point(265, 3)
        Me.UnDoButton.Name = "UnDoButton"
        Me.UnDoButton.Size = New System.Drawing.Size(256, 256)
        Me.UnDoButton.TabIndex = 10
        Me.UnDoButton.Text = "Decode"
        Me.UnDoButton.UseVisualStyleBackColor = False
        '
        'DoButton
        '
        Me.DoButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DoButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.DoButton.FlatAppearance.BorderSize = 0
        Me.DoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DoButton.Font = New System.Drawing.Font("微软雅黑 Light", 20.25!)
        Me.DoButton.Location = New System.Drawing.Point(3, 3)
        Me.DoButton.Name = "DoButton"
        Me.DoButton.Size = New System.Drawing.Size(256, 256)
        Me.DoButton.TabIndex = 9
        Me.DoButton.Text = "Encode"
        Me.DoButton.UseVisualStyleBackColor = False
        '
        'AdvancedPanel
        '
        Me.AdvancedPanel.BackColor = System.Drawing.Color.Transparent
        Me.AdvancedPanel.Controls.Add(Me.DecOder)
        Me.AdvancedPanel.Controls.Add(Me.ModeAButton)
        Me.AdvancedPanel.Location = New System.Drawing.Point(0, 48)
        Me.AdvancedPanel.Name = "AdvancedPanel"
        Me.AdvancedPanel.Size = New System.Drawing.Size(1280, 672)
        Me.AdvancedPanel.TabIndex = 10
        Me.AdvancedPanel.Visible = False
        '
        'DecOder
        '
        Me.DecOder.Controls.Add(Me.Button3)
        Me.DecOder.Controls.Add(Me.Button2)
        Me.DecOder.Controls.Add(Me.Button1)
        Me.DecOder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DecOder.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.DecOder.Location = New System.Drawing.Point(12, 16)
        Me.DecOder.Name = "DecOder"
        Me.DecOder.Size = New System.Drawing.Size(640, 590)
        Me.DecOder.TabIndex = 4
        Me.DecOder.TabStop = False
        Me.DecOder.Text = "Dec.Oder"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button3.FlatAppearance.BorderSize = 2
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.Button3.Location = New System.Drawing.Point(274, 536)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 48)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Basic"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button2.FlatAppearance.BorderSize = 2
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.Button2.Location = New System.Drawing.Point(140, 536)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 48)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Basic"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button1.FlatAppearance.BorderSize = 2
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.Button1.Location = New System.Drawing.Point(6, 536)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 48)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Basic"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ModeAButton
        '
        Me.ModeAButton.BackColor = System.Drawing.Color.Transparent
        Me.ModeAButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.ModeAButton.FlatAppearance.BorderSize = 2
        Me.ModeAButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.ModeAButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ModeAButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ModeAButton.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.ModeAButton.Location = New System.Drawing.Point(12, 612)
        Me.ModeAButton.Name = "ModeAButton"
        Me.ModeAButton.Size = New System.Drawing.Size(128, 48)
        Me.ModeAButton.TabIndex = 2
        Me.ModeAButton.Text = "Basic"
        Me.ModeAButton.UseVisualStyleBackColor = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.ThSAGDK.My.Resources.Resources.VSBack
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.Controls.Add(Me.AdvancedPanel)
        Me.Controls.Add(Me.BasicPanel)
        Me.Controls.Add(Me.UpExitButton)
        Me.Controls.Add(Me.MaxButton)
        Me.Controls.Add(Me.MinButton)
        Me.Controls.Add(Me.TOPButton)
        Me.Controls.Add(Me.AboutButton)
        Me.Controls.Add(Me.ModeBButton)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1280, 720)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ThSAGDK"
        Me.BasicPanel.ResumeLayout(False)
        Me.AdvancedPanel.ResumeLayout(False)
        Me.DecOder.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ModeBButton As System.Windows.Forms.Button
    Friend WithEvents AboutButton As System.Windows.Forms.Button
    Friend WithEvents TOPButton As System.Windows.Forms.Button
    Friend WithEvents MinButton As System.Windows.Forms.Button
    Friend WithEvents MaxButton As System.Windows.Forms.Button
    Friend WithEvents UpExitButton As System.Windows.Forms.Button
    Friend WithEvents BasicPanel As System.Windows.Forms.Panel
    Friend WithEvents EditorButton As System.Windows.Forms.Button
    Friend WithEvents UnDoButton As System.Windows.Forms.Button
    Friend WithEvents DoButton As System.Windows.Forms.Button
    Friend WithEvents AdvancedPanel As System.Windows.Forms.Panel
    Friend WithEvents ModeAButton As System.Windows.Forms.Button
    Friend WithEvents DecOder As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
