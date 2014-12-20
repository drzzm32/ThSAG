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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.StartButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.GpBox1 = New System.Windows.Forms.GroupBox()
        Me.ChkBox1 = New System.Windows.Forms.CheckBox()
        Me.RBtn4 = New System.Windows.Forms.RadioButton()
        Me.RBtn3 = New System.Windows.Forms.RadioButton()
        Me.RBtn2 = New System.Windows.Forms.RadioButton()
        Me.RBtn1 = New System.Windows.Forms.RadioButton()
        Me.UpExitButton = New System.Windows.Forms.Button()
        Me.TOPButton = New System.Windows.Forms.Button()
        Me.AboutButton = New System.Windows.Forms.Button()
        Me.BackGndButton = New System.Windows.Forms.Button()
        Me.OpenBackLog = New System.Windows.Forms.OpenFileDialog()
        Me.ProBar = New System.Windows.Forms.ProgressBar()
        Me.OpenScriptLog = New System.Windows.Forms.OpenFileDialog()
        Me.SPButton = New System.Windows.Forms.Button()
        Me.SHButton = New System.Windows.Forms.Button()
        Me.GpBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnShift = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnLeft = New System.Windows.Forms.Button()
        Me.BtnRight = New System.Windows.Forms.Button()
        Me.BtnDown = New System.Windows.Forms.Button()
        Me.BtnUp = New System.Windows.Forms.Button()
        Me.GpBox3 = New System.Windows.Forms.GroupBox()
        Me.GpBox5 = New System.Windows.Forms.GroupBox()
        Me.TrackBar = New System.Windows.Forms.TrackBar()
        Me.GpBox4 = New System.Windows.Forms.GroupBox()
        Me.GameNameBox = New System.Windows.Forms.TextBox()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.GpBox1.SuspendLayout()
        Me.GpBox2.SuspendLayout()
        Me.GpBox3.SuspendLayout()
        Me.GpBox5.SuspendLayout()
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GpBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.BackColor = System.Drawing.Color.Transparent
        Me.StartButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.StartButton.FlatAppearance.BorderSize = 2
        Me.StartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.StartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StartButton.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.StartButton.ForeColor = System.Drawing.Color.Black
        Me.StartButton.Location = New System.Drawing.Point(282, 382)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(206, 50)
        Me.StartButton.TabIndex = 0
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = False
        '
        'ExitButton
        '
        Me.ExitButton.BackColor = System.Drawing.Color.Transparent
        Me.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.ExitButton.FlatAppearance.BorderSize = 2
        Me.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExitButton.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.ExitButton.ForeColor = System.Drawing.Color.Black
        Me.ExitButton.Location = New System.Drawing.Point(388, 438)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(100, 50)
        Me.ExitButton.TabIndex = 1
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'GpBox1
        '
        Me.GpBox1.BackColor = System.Drawing.Color.Transparent
        Me.GpBox1.Controls.Add(Me.ChkBox1)
        Me.GpBox1.Controls.Add(Me.RBtn4)
        Me.GpBox1.Controls.Add(Me.RBtn3)
        Me.GpBox1.Controls.Add(Me.RBtn2)
        Me.GpBox1.Controls.Add(Me.RBtn1)
        Me.GpBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GpBox1.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.GpBox1.ForeColor = System.Drawing.Color.Black
        Me.GpBox1.Location = New System.Drawing.Point(12, 62)
        Me.GpBox1.Name = "GpBox1"
        Me.GpBox1.Size = New System.Drawing.Size(160, 200)
        Me.GpBox1.TabIndex = 2
        Me.GpBox1.TabStop = False
        Me.GpBox1.Text = "Display Config"
        '
        'ChkBox1
        '
        Me.ChkBox1.AutoSize = True
        Me.ChkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChkBox1.Location = New System.Drawing.Point(6, 165)
        Me.ChkBox1.Name = "ChkBox1"
        Me.ChkBox1.Size = New System.Drawing.Size(114, 29)
        Me.ChkBox1.TabIndex = 13
        Me.ChkBox1.Text = "FullScreen"
        Me.ChkBox1.UseVisualStyleBackColor = True
        '
        'RBtn4
        '
        Me.RBtn4.AutoSize = True
        Me.RBtn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RBtn4.Location = New System.Drawing.Point(6, 130)
        Me.RBtn4.Name = "RBtn4"
        Me.RBtn4.Size = New System.Drawing.Size(138, 29)
        Me.RBtn4.TabIndex = 12
        Me.RBtn4.Text = "2560 × 1440"
        Me.RBtn4.UseVisualStyleBackColor = True
        '
        'RBtn3
        '
        Me.RBtn3.AutoSize = True
        Me.RBtn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RBtn3.Location = New System.Drawing.Point(6, 95)
        Me.RBtn3.Name = "RBtn3"
        Me.RBtn3.Size = New System.Drawing.Size(134, 29)
        Me.RBtn3.TabIndex = 11
        Me.RBtn3.Text = "1920 × 1080"
        Me.RBtn3.UseVisualStyleBackColor = True
        '
        'RBtn2
        '
        Me.RBtn2.AutoSize = True
        Me.RBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RBtn2.Location = New System.Drawing.Point(6, 60)
        Me.RBtn2.Name = "RBtn2"
        Me.RBtn2.Size = New System.Drawing.Size(127, 29)
        Me.RBtn2.TabIndex = 10
        Me.RBtn2.Text = "1600 × 900"
        Me.RBtn2.UseVisualStyleBackColor = True
        '
        'RBtn1
        '
        Me.RBtn1.AutoSize = True
        Me.RBtn1.Checked = True
        Me.RBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RBtn1.Location = New System.Drawing.Point(6, 25)
        Me.RBtn1.Name = "RBtn1"
        Me.RBtn1.Size = New System.Drawing.Size(126, 29)
        Me.RBtn1.TabIndex = 9
        Me.RBtn1.TabStop = True
        Me.RBtn1.Text = "1280 × 720"
        Me.RBtn1.UseVisualStyleBackColor = True
        '
        'UpExitButton
        '
        Me.UpExitButton.BackColor = System.Drawing.Color.Transparent
        Me.UpExitButton.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.UpExitButton.FlatAppearance.BorderSize = 0
        Me.UpExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.UpExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UpExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UpExitButton.Font = New System.Drawing.Font("微软雅黑", 11.25!)
        Me.UpExitButton.ForeColor = System.Drawing.Color.Black
        Me.UpExitButton.Location = New System.Drawing.Point(428, 0)
        Me.UpExitButton.Name = "UpExitButton"
        Me.UpExitButton.Size = New System.Drawing.Size(72, 48)
        Me.UpExitButton.TabIndex = 3
        Me.UpExitButton.Text = " X"
        Me.UpExitButton.UseVisualStyleBackColor = False
        '
        'TOPButton
        '
        Me.TOPButton.BackColor = System.Drawing.Color.Transparent
        Me.TOPButton.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.TOPButton.FlatAppearance.BorderSize = 0
        Me.TOPButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.TOPButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TOPButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TOPButton.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.TOPButton.ForeColor = System.Drawing.Color.Black
        Me.TOPButton.Location = New System.Drawing.Point(48, 0)
        Me.TOPButton.Name = "TOPButton"
        Me.TOPButton.Size = New System.Drawing.Size(380, 48)
        Me.TOPButton.TabIndex = 4
        Me.TOPButton.Text = "ThSAG Launcher"
        Me.TOPButton.UseVisualStyleBackColor = False
        '
        'AboutButton
        '
        Me.AboutButton.BackColor = System.Drawing.Color.Transparent
        Me.AboutButton.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.AboutButton.FlatAppearance.BorderSize = 0
        Me.AboutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.AboutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.AboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AboutButton.Font = New System.Drawing.Font("微软雅黑 Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.AboutButton.ForeColor = System.Drawing.Color.Black
        Me.AboutButton.Location = New System.Drawing.Point(0, 0)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(48, 48)
        Me.AboutButton.TabIndex = 5
        Me.AboutButton.Text = "TH SAG"
        Me.AboutButton.UseVisualStyleBackColor = False
        '
        'BackGndButton
        '
        Me.BackGndButton.BackColor = System.Drawing.Color.Transparent
        Me.BackGndButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BackGndButton.FlatAppearance.BorderSize = 2
        Me.BackGndButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.BackGndButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackGndButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BackGndButton.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.BackGndButton.ForeColor = System.Drawing.Color.Black
        Me.BackGndButton.Location = New System.Drawing.Point(282, 438)
        Me.BackGndButton.Name = "BackGndButton"
        Me.BackGndButton.Size = New System.Drawing.Size(100, 50)
        Me.BackGndButton.TabIndex = 6
        Me.BackGndButton.Text = "BackGnd"
        Me.BackGndButton.UseVisualStyleBackColor = False
        Me.BackGndButton.Visible = False
        '
        'OpenBackLog
        '
        Me.OpenBackLog.Filter = "JPG|*.jpg|JPEG|*.jpeg|BMP|*.bmp|PNG|*.png|TIF|*.tif|TIFF|*.tiff"
        Me.OpenBackLog.InitialDirectory = "C:\"
        Me.OpenBackLog.Title = "Choose a background image"
        '
        'ProBar
        '
        Me.ProBar.Location = New System.Drawing.Point(12, 438)
        Me.ProBar.Name = "ProBar"
        Me.ProBar.Size = New System.Drawing.Size(370, 50)
        Me.ProBar.Step = 100
        Me.ProBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProBar.TabIndex = 7
        '
        'OpenScriptLog
        '
        Me.OpenScriptLog.Filter = "All Files|*.*"
        Me.OpenScriptLog.InitialDirectory = "C:\"
        Me.OpenScriptLog.Multiselect = True
        Me.OpenScriptLog.Title = "Choose Your Script Files"
        '
        'SPButton
        '
        Me.SPButton.BackColor = System.Drawing.Color.Transparent
        Me.SPButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.SPButton.FlatAppearance.BorderSize = 2
        Me.SPButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.SPButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SPButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SPButton.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.SPButton.ForeColor = System.Drawing.Color.Black
        Me.SPButton.Location = New System.Drawing.Point(147, 382)
        Me.SPButton.Name = "SPButton"
        Me.SPButton.Size = New System.Drawing.Size(129, 50)
        Me.SPButton.TabIndex = 8
        Me.SPButton.Text = "Scripts Path"
        Me.SPButton.UseVisualStyleBackColor = False
        '
        'SHButton
        '
        Me.SHButton.BackColor = System.Drawing.Color.Transparent
        Me.SHButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.SHButton.FlatAppearance.BorderSize = 2
        Me.SHButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.SHButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SHButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SHButton.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.SHButton.ForeColor = System.Drawing.Color.Black
        Me.SHButton.Location = New System.Drawing.Point(12, 382)
        Me.SHButton.Name = "SHButton"
        Me.SHButton.Size = New System.Drawing.Size(129, 50)
        Me.SHButton.TabIndex = 9
        Me.SHButton.Text = "Scripts Help"
        Me.SHButton.UseVisualStyleBackColor = False
        '
        'GpBox2
        '
        Me.GpBox2.BackColor = System.Drawing.Color.Transparent
        Me.GpBox2.Controls.Add(Me.BtnShift)
        Me.GpBox2.Controls.Add(Me.BtnCancel)
        Me.GpBox2.Controls.Add(Me.BtnOK)
        Me.GpBox2.Controls.Add(Me.BtnLeft)
        Me.GpBox2.Controls.Add(Me.BtnRight)
        Me.GpBox2.Controls.Add(Me.BtnDown)
        Me.GpBox2.Controls.Add(Me.BtnUp)
        Me.GpBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GpBox2.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.GpBox2.ForeColor = System.Drawing.Color.Black
        Me.GpBox2.Location = New System.Drawing.Point(178, 62)
        Me.GpBox2.Name = "GpBox2"
        Me.GpBox2.Size = New System.Drawing.Size(310, 200)
        Me.GpBox2.TabIndex = 14
        Me.GpBox2.TabStop = False
        Me.GpBox2.Text = "Key Preview"
        '
        'BtnShift
        '
        Me.BtnShift.BackColor = System.Drawing.Color.Transparent
        Me.BtnShift.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnShift.FlatAppearance.BorderSize = 2
        Me.BtnShift.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.BtnShift.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnShift.Font = New System.Drawing.Font("微软雅黑", 11.25!)
        Me.BtnShift.ForeColor = System.Drawing.Color.Black
        Me.BtnShift.Location = New System.Drawing.Point(5, 87)
        Me.BtnShift.Name = "BtnShift"
        Me.BtnShift.Size = New System.Drawing.Size(96, 48)
        Me.BtnShift.TabIndex = 17
        Me.BtnShift.Text = " Shift"
        Me.BtnShift.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnCancel.FlatAppearance.BorderSize = 2
        Me.BtnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("微软雅黑", 11.25!)
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Location = New System.Drawing.Point(101, 135)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(48, 48)
        Me.BtnCancel.TabIndex = 16
        Me.BtnCancel.Text = " X"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnOK
        '
        Me.BtnOK.BackColor = System.Drawing.Color.Transparent
        Me.BtnOK.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnOK.FlatAppearance.BorderSize = 2
        Me.BtnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.BtnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOK.Font = New System.Drawing.Font("微软雅黑", 11.25!)
        Me.BtnOK.ForeColor = System.Drawing.Color.Black
        Me.BtnOK.Location = New System.Drawing.Point(101, 39)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(48, 48)
        Me.BtnOK.TabIndex = 15
        Me.BtnOK.Text = " Z"
        Me.BtnOK.UseVisualStyleBackColor = False
        '
        'BtnLeft
        '
        Me.BtnLeft.BackColor = System.Drawing.Color.Transparent
        Me.BtnLeft.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnLeft.FlatAppearance.BorderSize = 2
        Me.BtnLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.BtnLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLeft.Font = New System.Drawing.Font("微软雅黑", 11.25!)
        Me.BtnLeft.ForeColor = System.Drawing.Color.Black
        Me.BtnLeft.Location = New System.Drawing.Point(161, 87)
        Me.BtnLeft.Name = "BtnLeft"
        Me.BtnLeft.Size = New System.Drawing.Size(48, 48)
        Me.BtnLeft.TabIndex = 14
        Me.BtnLeft.Text = " ←"
        Me.BtnLeft.UseVisualStyleBackColor = False
        '
        'BtnRight
        '
        Me.BtnRight.BackColor = System.Drawing.Color.Transparent
        Me.BtnRight.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnRight.FlatAppearance.BorderSize = 2
        Me.BtnRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.BtnRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRight.Font = New System.Drawing.Font("微软雅黑", 11.25!)
        Me.BtnRight.ForeColor = System.Drawing.Color.Black
        Me.BtnRight.Location = New System.Drawing.Point(257, 87)
        Me.BtnRight.Name = "BtnRight"
        Me.BtnRight.Size = New System.Drawing.Size(48, 48)
        Me.BtnRight.TabIndex = 13
        Me.BtnRight.Text = " →"
        Me.BtnRight.UseVisualStyleBackColor = False
        '
        'BtnDown
        '
        Me.BtnDown.BackColor = System.Drawing.Color.Transparent
        Me.BtnDown.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnDown.FlatAppearance.BorderSize = 2
        Me.BtnDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.BtnDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDown.Font = New System.Drawing.Font("微软雅黑", 11.25!)
        Me.BtnDown.ForeColor = System.Drawing.Color.Black
        Me.BtnDown.Location = New System.Drawing.Point(209, 135)
        Me.BtnDown.Name = "BtnDown"
        Me.BtnDown.Size = New System.Drawing.Size(48, 48)
        Me.BtnDown.TabIndex = 12
        Me.BtnDown.Text = " ↓"
        Me.BtnDown.UseVisualStyleBackColor = False
        '
        'BtnUp
        '
        Me.BtnUp.BackColor = System.Drawing.Color.Transparent
        Me.BtnUp.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnUp.FlatAppearance.BorderSize = 2
        Me.BtnUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.BtnUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUp.Font = New System.Drawing.Font("微软雅黑", 11.25!)
        Me.BtnUp.ForeColor = System.Drawing.Color.Black
        Me.BtnUp.Location = New System.Drawing.Point(209, 39)
        Me.BtnUp.Name = "BtnUp"
        Me.BtnUp.Size = New System.Drawing.Size(48, 48)
        Me.BtnUp.TabIndex = 11
        Me.BtnUp.Text = " ↑"
        Me.BtnUp.UseVisualStyleBackColor = False
        '
        'GpBox3
        '
        Me.GpBox3.BackColor = System.Drawing.Color.Transparent
        Me.GpBox3.Controls.Add(Me.GpBox5)
        Me.GpBox3.Controls.Add(Me.GpBox4)
        Me.GpBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GpBox3.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.GpBox3.ForeColor = System.Drawing.Color.Black
        Me.GpBox3.Location = New System.Drawing.Point(12, 268)
        Me.GpBox3.Name = "GpBox3"
        Me.GpBox3.Size = New System.Drawing.Size(476, 108)
        Me.GpBox3.TabIndex = 15
        Me.GpBox3.TabStop = False
        Me.GpBox3.Text = "InGame Config"
        '
        'GpBox5
        '
        Me.GpBox5.BackColor = System.Drawing.Color.Transparent
        Me.GpBox5.Controls.Add(Me.TrackBar)
        Me.GpBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GpBox5.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.GpBox5.ForeColor = System.Drawing.Color.Black
        Me.GpBox5.Location = New System.Drawing.Point(242, 27)
        Me.GpBox5.Name = "GpBox5"
        Me.GpBox5.Size = New System.Drawing.Size(228, 75)
        Me.GpBox5.TabIndex = 18
        Me.GpBox5.TabStop = False
        Me.GpBox5.Text = "Difficulty"
        '
        'TrackBar
        '
        Me.TrackBar.BackColor = System.Drawing.Color.White
        Me.TrackBar.LargeChange = 1
        Me.TrackBar.Location = New System.Drawing.Point(6, 24)
        Me.TrackBar.Name = "TrackBar"
        Me.TrackBar.Size = New System.Drawing.Size(216, 45)
        Me.TrackBar.TabIndex = 0
        Me.TrackBar.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'GpBox4
        '
        Me.GpBox4.BackColor = System.Drawing.Color.Transparent
        Me.GpBox4.Controls.Add(Me.GameNameBox)
        Me.GpBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GpBox4.Font = New System.Drawing.Font("微软雅黑 Light", 14.25!)
        Me.GpBox4.ForeColor = System.Drawing.Color.Black
        Me.GpBox4.Location = New System.Drawing.Point(6, 27)
        Me.GpBox4.Name = "GpBox4"
        Me.GpBox4.Size = New System.Drawing.Size(228, 75)
        Me.GpBox4.TabIndex = 17
        Me.GpBox4.TabStop = False
        Me.GpBox4.Text = "Game Name"
        '
        'GameNameBox
        '
        Me.GameNameBox.BackColor = System.Drawing.Color.White
        Me.GameNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GameNameBox.ForeColor = System.Drawing.Color.Black
        Me.GameNameBox.Location = New System.Drawing.Point(6, 32)
        Me.GameNameBox.Name = "GameNameBox"
        Me.GameNameBox.Size = New System.Drawing.Size(216, 26)
        Me.GameNameBox.TabIndex = 6
        '
        'Timer
        '
        Me.Timer.Interval = 20
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(500, 500)
        Me.Controls.Add(Me.ProBar)
        Me.Controls.Add(Me.GpBox3)
        Me.Controls.Add(Me.GpBox2)
        Me.Controls.Add(Me.SHButton)
        Me.Controls.Add(Me.SPButton)
        Me.Controls.Add(Me.BackGndButton)
        Me.Controls.Add(Me.AboutButton)
        Me.Controls.Add(Me.TOPButton)
        Me.Controls.Add(Me.UpExitButton)
        Me.Controls.Add(Me.GpBox1)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.StartButton)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ThAVG Launcher"
        Me.GpBox1.ResumeLayout(False)
        Me.GpBox1.PerformLayout()
        Me.GpBox2.ResumeLayout(False)
        Me.GpBox3.ResumeLayout(False)
        Me.GpBox5.ResumeLayout(False)
        Me.GpBox5.PerformLayout()
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GpBox4.ResumeLayout(False)
        Me.GpBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents GpBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents UpExitButton As System.Windows.Forms.Button
    Friend WithEvents ChkBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents RBtn4 As System.Windows.Forms.RadioButton
    Friend WithEvents RBtn3 As System.Windows.Forms.RadioButton
    Friend WithEvents RBtn2 As System.Windows.Forms.RadioButton
    Friend WithEvents RBtn1 As System.Windows.Forms.RadioButton
    Friend WithEvents TOPButton As System.Windows.Forms.Button
    Friend WithEvents AboutButton As System.Windows.Forms.Button
    Friend WithEvents BackGndButton As System.Windows.Forms.Button
    Friend WithEvents OpenBackLog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProBar As System.Windows.Forms.ProgressBar
    Friend WithEvents OpenScriptLog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SPButton As System.Windows.Forms.Button
    Friend WithEvents SHButton As System.Windows.Forms.Button
    Friend WithEvents GpBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GpBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GpBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents GpBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GameNameBox As System.Windows.Forms.TextBox
    Friend WithEvents BtnShift As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnLeft As System.Windows.Forms.Button
    Friend WithEvents BtnRight As System.Windows.Forms.Button
    Friend WithEvents BtnDown As System.Windows.Forms.Button
    Friend WithEvents BtnUp As System.Windows.Forms.Button
    Friend WithEvents Timer As System.Windows.Forms.Timer

End Class
