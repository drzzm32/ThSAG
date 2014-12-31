Imports ThSAG.WDJ_E_Lite
Imports ThSAG.WDJ_E_Lite.STG
Imports ThSAG.WDJ_E_Lite.Base.DrawingGroup
Imports ThSAG.WDJ_E_Lite.Base.ControlGroup

Public Class Main
    Dim AppName As String = "ThSAG VB .NET & DirectX Edition ~ AVG Part"
    Dim IsSTGEnabled As Boolean = False
    Dim IsReleaseMode As Boolean = False
    Dim ReleaseFile As String = "NyaSamaSoulLove"

    Dim Bullets(100, 1000) As Objects
    Dim Player1 As Objects
    Dim Enemies(100) As Objects
    Dim Scenes(10000) As AVG.Scene
    Dim MousePos As Point

    Dim FPS_obj As New DxLibVB.FPS
    Dim FPS As Integer
    Dim NowTime As Integer
    Dim TempFPSTime As Integer
    Dim LastFPS As Integer
    Dim FPSNum As Single
    Dim SleepTime As Integer = 0

    Dim ModelHandle As Integer
    Dim CameraValue(5) As Single
    Dim Audio As New Devices.Audio

    Dim GameTime As Long = 0
    Dim Flag As Integer
    Dim GrazeValue As Integer = 0
    Dim MissValue As Integer = 0
    Dim DifficultyValue As Integer = 10
    Dim DifficultyUpI As Integer = 10
    Dim DifficultyUpJ As Integer = 1000
    Dim BulletWidth As Integer = 30

    Dim a As Single = 0
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        Player1.x = 960
        Player1.y = 540
        If IsReleaseMode Then
            SPButton.Enabled = False
            SHButton.Enabled = False
        Else
            SPButton.Enabled = True
            SHButton.Enabled = True
        End If

        For i = 0 To 5 Step 1
            CameraValue(i) = 0
        Next i

    End Sub
    Private Sub Main_MouseMove(sender As Object, e As MouseEventArgs) Handles TOPButton.MouseMove
        If e.Button = MouseButtons.Left Then
            Dim PosTmp As Point = MyBase.PointToScreen(e.Location)
            MyBase.Left = PosTmp.X - MousePos.X
            MyBase.Top = PosTmp.Y - MousePos.Y
        End If
    End Sub
    Private Sub Main_MouseDown(sender As Object, e As MouseEventArgs) Handles TOPButton.MouseDown
        If e.Button = MouseButtons.Left Then
            Dim PosTmp As Point = MyBase.PointToScreen(e.Location)
            MousePos = New Point(PosTmp.X - MyBase.Left, PosTmp.Y - MyBase.Top)
        End If
    End Sub
    Private Sub Start_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        If IsReleaseMode Then
            SPButton_Click(Nothing, Nothing)
        End If
        If GameNameBox.Text <> "" Then
            AppName = GameNameBox.Text
        End If
        DxLibDLL.DX.SetWindowIconHandle(ThSAG.My.Resources.Resources.Icon.Handle)
        If ChkBox1.Checked Then
            If RBtn1.Checked Then
                DxLibVB.DxInit(AppName, True, 1280, 720)
            ElseIf RBtn2.Checked Then
                DxLibVB.DxInit(AppName, True, 1600, 900)
            ElseIf RBtn3.Checked Then
                DxLibVB.DxInit(AppName, True, 1920, 1080)
            ElseIf RBtn4.Checked Then
                DxLibVB.DxInit(AppName, True, 2560, 1440)
            End If
        Else
            If RBtn1.Checked Then
                DxLibVB.DxInit(AppName, False, 1280, 720)
            ElseIf RBtn2.Checked Then
                DxLibVB.DxInit(AppName, False, 1600, 900)
            ElseIf RBtn3.Checked Then
                DxLibVB.DxInit(AppName, False, 1920, 1080)
            ElseIf RBtn4.Checked Then
                DxLibVB.DxInit(AppName, False, 2560, 1440)
            End If
        End If

        ProBar.Value = 33
        Me.Refresh()


        If Not ResourcesLoad() Then
            MsgBox("Some Files Can Not Be Loaded.", MsgBoxStyle.Critical, AppName)
            GoTo ExitFlag
        End If

        ProBar.Value = 66
        Me.Refresh()

        For i = 0 To 100 Step 1
            For j = 0 To 1000 Step 1
                Bullets(i, j).Initilize()
            Next j
        Next i

        StringLoad()
        ProBar.Value = 100
        Me.Refresh()

        Select Case TrackBar.Value
            Case 0
                DifficultyValue = 10
            Case 1
                DifficultyValue = 10
            Case 2
                DifficultyValue = 10
            Case 3
                DifficultyValue = 5
            Case 4
                DifficultyValue = 5
            Case 5
                DifficultyValue = 4
            Case 6
                DifficultyValue = 4
            Case 7
                DifficultyValue = 2
            Case 8
                DifficultyValue = 2
            Case 9
                DifficultyValue = 1
            Case 10
                DifficultyValue = 1
        End Select

        Me.Hide()

        Timer.Start()

        Dim Color_obj As DxLibDLL.DX.COLOR_F
        Color_obj.r = 1 : Color_obj.g = 1 : Color_obj.b = 1 : Color_obj.a = 1
        DxLibDLL.DX.SetLightAmbColor(Color_obj)
        DxLibDLL.DX.SetLightEnable(1)
        DxLibDLL.DX.SetLightPosition(DxLibDLL.DX.VGet(10, 0, 0))
        DxLibDLL.DX.SetLightDirection(DxLibDLL.DX.VGet(-10, 0, 0))
        DxLibDLL.DX.SetCameraNearFar(0, 1000)
        DxLibDLL.DX.SetCameraPositionAndTarget_UpVecY(DxLibDLL.DX.VGet(0, 10, -20), DxLibDLL.DX.VGet(0, 10, 0))
        CameraValue(0) = 0 : CameraValue(1) = 10 : CameraValue(2) = -20 : CameraValue(3) = 0 : CameraValue(4) = 10 : CameraValue(5) = 0

        'Audio.Play("D:\Users\D.zzm\Desktop\BGM.wav", AudioPlayMode.BackgroundLoop)

        Do
            'DxLibDLL.DX.MV1DrawModel(ModelHandle)
            DxLibDLL.DX.SetCameraPositionAndTarget_UpVecY(DxLibDLL.DX.VGet(CameraValue(0), CameraValue(1), CameraValue(2)), DxLibDLL.DX.VGet(CameraValue(3), CameraValue(4), CameraValue(5)))
            MainCircle()

            FPS = FPS + 1
            NowTime = GetTickCount
            If NowTime - TempFPSTime >= 1000 Then
                LastFPS = FPS
                TempFPSTime = NowTime
                FPS = 0
            End If
            FPSNum = LastFPS

            If FPS > 60 Then
                SleepTime = SleepTime + 1
            ElseIf FPS = 60 Then

            Else
                SleepTime = SleepTime - 1
                If SleepTime = 0 Then
                    SleepTime = 1
                End If
            End If
            DxLibDLL.DX.WaitTimer(SleepTime)

            'FPS_obj.Update()
            'FPSNum = FPS_obj.GetFPS
            'FPSNum = Math.Round(FPSNum, 1)
            'FPS_obj.WaitTime()


            '
        Loop Until WDJ_E_Lite.Base.ControlGroup.GetKey(Keys.Escape) Or DxLibDLL.DX.ProcessMessage = -1 'Choice Your Own Control
ExitFlag:

        Audio.Stop()

        DxLibVB.DxEnd()
        Me.Show()
        ProBar.Value = 0
        MissValue = 0
        GrazeValue = 0
        GameTime = 0
        SceneStep = 0
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        End
    End Sub
    Private Sub UpExitButton_Click(sender As Object, e As EventArgs) Handles UpExitButton.Click
        End
    End Sub

    'Private Sub ThemeButton_Click(sender As Object, e As EventArgs)
    '    If Me.BackColor = Color.Black Then Me.BackColor = Color.White Else Me.BackColor = Color.Black
    '    If ThemeButton.ForeColor = Color.Black Then ThemeButton.ForeColor = Color.White Else ThemeButton.ForeColor = Color.Black
    '    If TOPButton.ForeColor = Color.Black Then TOPButton.ForeColor = Color.White Else TOPButton.ForeColor = Color.Black
    '    If UpExitButton.ForeColor = Color.Black Then UpExitButton.ForeColor = Color.White Else UpExitButton.ForeColor = Color.Black
    '    If GpBox1.ForeColor = Color.Black Then GpBox1.ForeColor = Color.White Else GpBox1.ForeColor = Color.Black
    '    If GpBox2.ForeColor = Color.Black Then GpBox2.ForeColor = Color.White Else GpBox2.ForeColor = Color.Black
    '    If GpBox3.ForeColor = Color.Black Then GpBox3.ForeColor = Color.White Else GpBox3.ForeColor = Color.Black
    '    If GpBox4.ForeColor = Color.Black Then GpBox4.ForeColor = Color.White Else GpBox4.ForeColor = Color.Black
    '    If GpBox5.ForeColor = Color.Black Then GpBox5.ForeColor = Color.White Else GpBox5.ForeColor = Color.Black
    '    If StartButton.ForeColor = Color.Black Then StartButton.ForeColor = Color.White Else StartButton.ForeColor = Color.Black
    '    If StartButton.FlatAppearance.BorderColor = Color.Black Then StartButton.FlatAppearance.BorderColor = Color.White Else StartButton.FlatAppearance.BorderColor = Color.Black
    '    If ExitButton.ForeColor = Color.Black Then ExitButton.ForeColor = Color.White Else ExitButton.ForeColor = Color.Black
    '    If ExitButton.FlatAppearance.BorderColor = Color.Black Then ExitButton.FlatAppearance.BorderColor = Color.White Else ExitButton.FlatAppearance.BorderColor = Color.Black
    '    If BackGndButton.ForeColor = Color.Black Then BackGndButton.ForeColor = Color.White Else BackGndButton.ForeColor = Color.Black
    '    If BackGndButton.FlatAppearance.BorderColor = Color.Black Then BackGndButton.FlatAppearance.BorderColor = Color.White Else BackGndButton.FlatAppearance.BorderColor = Color.Black
    '    If SHButton.ForeColor = Color.Black Then SHButton.ForeColor = Color.White Else SHButton.ForeColor = Color.Black
    '    If SHButton.FlatAppearance.BorderColor = Color.Black Then SHButton.FlatAppearance.BorderColor = Color.White Else SHButton.FlatAppearance.BorderColor = Color.Black
    '    If SPButton.ForeColor = Color.Black Then SPButton.ForeColor = Color.White Else SPButton.ForeColor = Color.Black
    '    If SPButton.FlatAppearance.BorderColor = Color.Black Then SPButton.FlatAppearance.BorderColor = Color.White Else SPButton.FlatAppearance.BorderColor = Color.Black

    '    If BtnUp.ForeColor = Color.Black Then BtnUp.ForeColor = Color.White Else BtnUp.ForeColor = Color.Black
    '    If BtnUp.FlatAppearance.BorderColor = Color.Black Then BtnUp.FlatAppearance.BorderColor = Color.White Else BtnUp.FlatAppearance.BorderColor = Color.Black
    '    If BtnDown.ForeColor = Color.Black Then BtnDown.ForeColor = Color.White Else BtnDown.ForeColor = Color.Black
    '    If BtnDown.FlatAppearance.BorderColor = Color.Black Then BtnDown.FlatAppearance.BorderColor = Color.White Else BtnDown.FlatAppearance.BorderColor = Color.Black
    '    If BtnLeft.ForeColor = Color.Black Then BtnLeft.ForeColor = Color.White Else BtnLeft.ForeColor = Color.Black
    '    If BtnLeft.FlatAppearance.BorderColor = Color.Black Then BtnLeft.FlatAppearance.BorderColor = Color.White Else BtnLeft.FlatAppearance.BorderColor = Color.Black
    '    If BtnRight.ForeColor = Color.Black Then BtnRight.ForeColor = Color.White Else BtnRight.ForeColor = Color.Black
    '    If BtnRight.FlatAppearance.BorderColor = Color.Black Then BtnRight.FlatAppearance.BorderColor = Color.White Else BtnRight.FlatAppearance.BorderColor = Color.Black
    '    If BtnOK.ForeColor = Color.Black Then BtnOK.ForeColor = Color.White Else BtnOK.ForeColor = Color.Black
    '    If BtnOK.FlatAppearance.BorderColor = Color.Black Then BtnOK.FlatAppearance.BorderColor = Color.White Else BtnOK.FlatAppearance.BorderColor = Color.Black
    '    If BtnCancel.ForeColor = Color.Black Then BtnCancel.ForeColor = Color.White Else BtnCancel.ForeColor = Color.Black
    '    If BtnCancel.FlatAppearance.BorderColor = Color.Black Then BtnCancel.FlatAppearance.BorderColor = Color.White Else BtnCancel.FlatAppearance.BorderColor = Color.Black
    '    If BtnShift.ForeColor = Color.Black Then BtnShift.ForeColor = Color.White Else BtnShift.ForeColor = Color.Black
    '    If BtnShift.FlatAppearance.BorderColor = Color.Black Then BtnShift.FlatAppearance.BorderColor = Color.White Else BtnShift.FlatAppearance.BorderColor = Color.Black
    '    If GameNameBox.BackColor = Color.Black Then GameNameBox.BackColor = Color.White Else GameNameBox.BackColor = Color.Black
    '    If GameNameBox.ForeColor = Color.Black Then GameNameBox.ForeColor = Color.White Else GameNameBox.ForeColor = Color.Black

    '    IsSTGEnabled = Not IsSTGEnabled
    'End Sub

    Private Sub AboutButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        MsgBox("This is a SAG Engine." & Chr(10) & "CopyRight the WDJ 2005 - 2015, All Rights Reserved.", MsgBoxStyle.OkOnly, "About")
        IsReleaseMode = Not IsReleaseMode
        If IsReleaseMode Then
            SPButton.Enabled = False
            SHButton.Enabled = False
        Else
            SPButton.Enabled = True
            SHButton.Enabled = True
        End If
    End Sub

    Private Sub BackGndButton_Click(sender As Object, e As EventArgs) Handles BackGndButton.Click
        OpenBackLog.ShowDialog()
        If OpenBackLog.FileName <> "" Then
            Me.BackgroundImage = New Bitmap(OpenBackLog.FileName)
        End If
    End Sub

    Private Sub SPButton_Click(sender As Object, e As EventArgs) Handles SPButton.Click
        Dim Path(100) As String

        If IsReleaseMode Then
            Path(0) = Application.StartupPath & "\" & ReleaseFile
        Else
Head:
            OpenScriptLog.Reset()
            OpenScriptLog.Filter = "Script Files | *.*"
            OpenScriptLog.Title = "Open Script File"
            OpenScriptLog.Multiselect = True
            OpenScriptLog.ShowDialog()
            Path = OpenScriptLog.FileNames
            If Path.Length = 0 Then
                Dim m As Integer = MsgBox("No file in choice.", 53, "WARNING")
                Select Case m
                    Case Is = 2
                        Exit Sub
                    Case Is = 4
                        GoTo Head
                End Select
            End If
        End If
        Dim SceneTmp(10000) As AVG.Scene
        For i = 0 To Path.GetUpperBound(0) Step 1
            If Not Path(i) = "" Then
                SceneTmp = AVG.LoadScript(True, Path(i))
                For j = 0 To 10000 Step 1
                    If Not SceneTmp(j) Is Nothing Then
                        Scenes(j) = SceneTmp(j)

                        Dim Tmp As String = ""
                        For k = 0 To Scenes(j).BG.Path.Length - 1 Step 1        '避开回车符
                            If Not Scenes(j).BG.Path.Chars(k) = vbCr Then
                                Tmp = Tmp & Scenes(j).BG.Path.Chars(k)
                            End If
                        Next k
                        Scenes(j).BG.Path = Tmp

                        Tmp = ""
                        For k = 0 To Scenes(j).BGM.Length - 1 Step 1        '避开回车符
                            If Not Scenes(j).BGM.Chars(k) = vbCr Then
                                Tmp = Tmp & Scenes(j).BGM.Chars(k)
                            End If
                        Next k
                        Scenes(j).BGM = Tmp

                        For l = 0 To Scenes(j).CG.GetUpperBound(0) Step 1
                            If Not Scenes(j).CG(l).IMG.Path = Nothing Then
                                Tmp = ""
                                For k = 0 To Scenes(j).CG(l).IMG.Path.Length - 1 Step 1        '避开回车符
                                    If Not Scenes(j).CG(l).IMG.Path.Chars(k) = vbCr Then
                                        Tmp = Tmp & Scenes(j).CG(l).IMG.Path.Chars(k)
                                    End If
                                Next k
                                Scenes(j).CG(l).IMG.Path = Tmp
                            End If
                        Next l

                        For m = 0 To Scenes(j).Choices.GetUpperBound(0) Step 1
                            If Not Scenes(j).Choices(m).Context = Nothing Then
                                Tmp = ""
                                For k = 0 To Scenes(j).Choices(m).Context.Length - 1 Step 1        '避开回车符
                                    If Not Scenes(j).Choices(m).Context.Chars(k) = vbCr Then
                                        Tmp = Tmp & Scenes(j).Choices(m).Context.Chars(k)
                                    End If
                                Next k
                                Scenes(j).Choices(m).Context = Tmp
                            End If
                        Next m

                    End If
                Next j
            End If
        Next i
        'Stop
    End Sub

    Private Sub SHButton_Click(sender As Object, e As EventArgs) Handles SHButton.Click
        MsgBox("Public Help" & Chr(10) & _
               "//////////////////////////////////////////////////////////////////////////////////////" & Chr(10) & _
               "开始定义场景 [场景编号] [场景名，仅作注释，可用于Debug]" & Chr(10) & _
               "" & Chr(10) & _
               "        [元素定义]        '即 <结束定义场景> 下面的定义" & Chr(10) & _
               "" & Chr(10) & _
               "结束定义场景" & Chr(10) & _
               "" & Chr(10) & _
               "[背景/音乐] [地址]" & Chr(10) & _
               "" & Chr(10) & _
               "开始定义立绘 [立绘编号] [立绘名，仅作注释，可用于Debug]" & Chr(10) & _
               "" & Chr(10) & _
               "        立绘地址 [地址]" & Chr(10) & _
               "" & Chr(10) & _
               "        立绘位置 [位置]" & Chr(10) & _
               "" & Chr(10) & _
               "结束定义立绘" & Chr(10) & _
               "" & Chr(10) & _
               "开始定义文字 [对话/旁白/标题/存档/读档/启动]" & Chr(10) & _
               "" & Chr(10) & _
               "        选择 [内容]" & Chr(10) & _
               "" & Chr(10) & _
               "        跳转 [场景编号]" & Chr(10) & _
               "" & Chr(10) & _
               "结束定义文字" & Chr(10) & _
               "//////////////////////////////////////////////////////////////////////////////////////" & Chr(10) & _
               "场景编号需要手动设置。" & Chr(10) & _
               "背景为单一背景。" & Chr(10) & _
               "对于文字位置调整，请善用空格。当前还未解决字体问题，待解决。" & Chr(10) & _
               ">>>>>NOTE：制作图片资源时，按照游戏界面为1920x1080的分辨率制作，图片需要压缩至需要的像素大小。" & Chr(10) & _
               "立绘编号需要手动设置，目的是区分多立绘的情况,相同的立绘可以使用固定编号。（资源加载待解决，可能会出现内存占用高）" & Chr(10) & _
               "文件路径（即地址）为：【Audio\audio.wav】" & Chr(10) & _
               "文字定义中，脚本顺序即为显示顺序，选择在前，跳转在后，两者紧挨，一个文字定义中选择数目和跳转数目相同。" & Chr(10) & _
               "某些特殊场景，应当使用诸如【0】、【1】、【2】、【3】这种场景编号，并置于独立的文件中。" & Chr(10) & _
               "脚本文件的建立，最好分为配置文件（启动画面，标题画面），存档文件（存档画面，读档画面），游戏脚本。" & Chr(10) & _
               ">>>>>注意：元素定义中，背景，音乐，文字仅可定义一次；立绘定义内部的语句不允许重复，文字定义内部语句可以重复。" & Chr(10) & _
               "待添加。" & Chr(10) & _
               "End Help" _
               , MsgBoxStyle.OkOnly, "#NOTICE OF THE ENGINE#")
    End Sub

    Private Sub BtnUp_Click(sender As Object, e As EventArgs) Handles BtnUp.Click
        MsgBox("Move Up", MsgBoxStyle.OkOnly, "Controls")
    End Sub

    Private Sub BtnDown_Click(sender As Object, e As EventArgs) Handles BtnDown.Click
        MsgBox("Move Down", MsgBoxStyle.OkOnly, "Controls")
    End Sub

    Private Sub BtnLeft_Click(sender As Object, e As EventArgs) Handles BtnLeft.Click
        MsgBox("Move Left", MsgBoxStyle.OkOnly, "Controls")
    End Sub

    Private Sub BtnRight_Click(sender As Object, e As EventArgs) Handles BtnRight.Click
        MsgBox("Move Right", MsgBoxStyle.OkOnly, "Controls")
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        MsgBox("Choice & Shoot", MsgBoxStyle.OkOnly, "Controls")
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        MsgBox("Cancel & Bomb", MsgBoxStyle.OkOnly, "Controls")
    End Sub

    Private Sub BtnShift_Click(sender As Object, e As EventArgs) Handles BtnShift.Click
        MsgBox("Speed Up & Low Speed", MsgBoxStyle.OkOnly, "Controls")
    End Sub
    Private Function ResourcesLoad() As Boolean
        Dim FlagTmp As Boolean = True
        For i = 0 To Scenes.GetUpperBound(0) Step 1
            If Not Scenes(i) Is Nothing Then
                FlagTmp = FlagTmp And DxLibVB.LoadTexture(False, Scenes(i).BG.Path, ImageArray(IMAGE_BG, i))
                If FlagTmp = False Then Return False
                For j = 0 To Scenes(i).CG.GetUpperBound(0) Step 1
                    If Not Scenes(i).CG(j).IMG.Path = Nothing Then
                        FlagTmp = FlagTmp And DxLibVB.LoadTexture(False, Scenes(i).CG(j).IMG.Path, ImageArray(IMAGE_CG, Scenes(i).CG(j).IMG.Index))
                        If FlagTmp = False Then Return False
                    End If
                Next j
            End If
        Next i

        'ModelHandle = DxLibDLL.DX.MV1LoadModel("FrandreScarletVer1.0\FrandreScarletVer1.0.pmx")
        'ModelHandle = DxLibDLL.DX.MV1LoadModel("dat/Lat幃儈僋/Lat幃儈僋Ver2.3_Normal.pmd")

        If _
            DxLibVB.LoadTexture(True, "\Resources\2.png", ImageArray(IMAGE_BULLET, 0)) And _
            DxLibVB.LoadTexture(True, "\Resources\1.png", ImageArray(IMAGE_BULLET, 1)) Then

            Return True
        Else
            Return False
        End If
    End Function
    Private Sub StringLoad()
        For i = 0 To Scenes.GetUpperBound(0) Step 1
            If Not Scenes(i) Is Nothing Then
                Select Case Scenes(i).WordType
                    Case AVG.WordType.Comment
                        For k = 0 To Scenes(i).Choices.GetUpperBound(0) Step 1
                            If Not Scenes(i).Choices(k).Context = Nothing Then
                                Scenes(i).Choices(k).Handle = DxLibVB.LoadString(Scenes(i).Choices(k).Context, Brushes.White, 80)
                            End If
                        Next k
                    Case AVG.WordType.GameRun
                        For k = 0 To Scenes(i).Choices.GetUpperBound(0) Step 1
                            If Not Scenes(i).Choices(k).Context = Nothing Then
                                Scenes(i).Choices(k).Handle = DxLibVB.LoadString(Scenes(i).Choices(k).Context, Brushes.Cyan, 100)
                            End If
                        Next k
                    Case AVG.WordType.Loading
                        For k = 0 To Scenes(i).Choices.GetUpperBound(0) Step 1
                            If Not Scenes(i).Choices(k).Context = Nothing Then
                                Scenes(i).Choices(k).Handle = DxLibVB.LoadString(Scenes(i).Choices(k).Context, Brushes.White, 80)
                            End If
                        Next k
                    Case AVG.WordType.Saving
                        For k = 0 To Scenes(i).Choices.GetUpperBound(0) Step 1
                            If Not Scenes(i).Choices(k).Context = Nothing Then
                                Scenes(i).Choices(k).Handle = DxLibVB.LoadString(Scenes(i).Choices(k).Context, Brushes.White, 80)
                            End If
                        Next k
                    Case AVG.WordType.Script
                        For k = 0 To Scenes(i).Choices.GetUpperBound(0) Step 1
                            If Not Scenes(i).Choices(k).Context = Nothing Then
                                Scenes(i).Choices(k).Handle = DxLibVB.LoadString(Scenes(i).Choices(k).Context, Brushes.White, 80)
                            End If
                        Next k
                    Case AVG.WordType.Title
                        For k = 0 To Scenes(i).Choices.GetUpperBound(0) Step 1
                            If Not Scenes(i).Choices(k).Context = Nothing Then
                                Scenes(i).Choices(k).Handle = DxLibVB.LoadString(Scenes(i).Choices(k).Context, Brushes.White, 80)
                            End If
                        Next k
                End Select       
            End If
        Next i
    End Sub
    Private Sub MainCircle()
        DxLibDLL.DX.ScreenFlip()
        DxLibDLL.DX.ClearDrawScreen()
        If IsSTGEnabled Then
            STGPrintSub()
            BulletControlSub()
            ' BulletGenerateSub()
            BulletTest()
            'BulletJudgeSub()

            DxLibDLL.DX.DrawString(1780, 1010, "FPS    " & CStr(FPSNum) & " fps", 16777215)
            DxLibDLL.DX.DrawString(1780, 1030, "Miss   " & CStr(MissValue), 16777215)
            DxLibDLL.DX.DrawString(1780, 1050, "Graze  " & CStr(GrazeValue), 16777215)
        Else
            AVGPrintSub()
        End If
    End Sub
    Private Sub AVGPrintSub()
        AVG.BuildScene(Scenes(SceneStep))
        DxLibDLL.DX.DrawString(1780, 1010, "FPS    " & CStr(FPSNum) & " fps", 16777215)
        DxLibDLL.DX.DrawString(1780, 1030, "Scene  " & CStr(AVGControl), 16777215)
    End Sub
    Private Sub STGPrintSub()
        For i = 0 To 100 Step 1
            For j = 0 To 1000 Step 1
                If Bullets(i, j).DrawingEnabled Then
                    DxLibVB.DrawPic(ImageArray(IMAGE_BULLET, 0), Bullets(i, j).x, Bullets(i, j).y)
                End If
            Next j
        Next i

        DxLibVB.DrawPic(ImageArray(IMAGE_BULLET, 1), Player1.x, Player1.y)
    End Sub
    Private Sub BulletGenerateSub()

        Select Case GameTime

            Case 3000 To 13000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        Randomize()
                        If Not Bullets(i, j).DrawingEnabled Then
                            Bullets(i, j).x = 960
                            Bullets(i, j).y = 540
                            Select Case Rnd()
                                Case 0 To 0.1
                                    Bullets(i, j).dx = 1 + Rnd()
                                Case 0.1 To 0.2
                                    Bullets(i, j).dx = 2 + Rnd()
                                Case 0.2 To 0.3
                                    Bullets(i, j).dx = 3 + Rnd()
                                Case 0.3 To 0.4
                                    Bullets(i, j).dx = 4 + Rnd()
                                Case 0.4 To 0.5
                                    Bullets(i, j).dx = 5 + Rnd()
                                Case 0.5 To 0.6
                                    Bullets(i, j).dx = 6 + Rnd()
                                Case 0.6 To 0.7
                                    Bullets(i, j).dx = 7 + Rnd()
                                Case 0.7 To 0.8
                                    Bullets(i, j).dx = 8 + Rnd()
                                Case 0.8 To 0.9
                                    Bullets(i, j).dx = 9 + Rnd()
                                Case 0.9 To 1
                                    Bullets(i, j).dx = Rnd()
                            End Select
                            Select Case Rnd()
                                Case 0 To 0.1
                                    Bullets(i, j).dy = 1 + Rnd()
                                Case 0.1 To 0.2
                                    Bullets(i, j).dy = 2 + Rnd()
                                Case 0.2 To 0.3
                                    Bullets(i, j).dy = 3 + Rnd()
                                Case 0.3 To 0.4
                                    Bullets(i, j).dy = 4 + Rnd()
                                Case 0.4 To 0.5
                                    Bullets(i, j).dy = 5 + Rnd()
                                Case 0.5 To 0.6
                                    Bullets(i, j).dy = 6 + Rnd()
                                Case 0.6 To 0.7
                                    Bullets(i, j).dy = 7 + Rnd()
                                Case 0.7 To 0.8
                                    Bullets(i, j).dy = 8 + Rnd()
                                Case 0.8 To 0.9
                                    Bullets(i, j).dy = 9 + Rnd()
                                Case 0.9 To 1
                                    Bullets(i, j).dy = Rnd()
                            End Select
                            If Rnd() >= 0.5 Then
                                Bullets(i, j).dx = Bullets(i, j).dx
                            Else
                                Bullets(i, j).dx = -Bullets(i, j).dx
                            End If
                            If Rnd() >= 0.5 Then
                                Bullets(i, j).dy = Bullets(i, j).dy
                            Else
                                Bullets(i, j).dy = -Bullets(i, j).dy
                            End If
                            Bullets(i, j).DrawingEnabled = True
                            Bullets(i, j).GrazeEnabled = True
                        End If
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 13000 To 18000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / 50
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / 50
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 18000 To 28000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        Randomize()
                        If Not Bullets(i, j).DrawingEnabled Then
                            Bullets(i, j).x = 1920 * Rnd()
                            Bullets(i, j).y = 1080 * Rnd()
                            Bullets(i, j).DrawingEnabled = True
                            Bullets(i, j).GrazeEnabled = True
                        End If
                        Bullets(i, j).x = Bullets(i, j).x + Rnd() * 20
                        Bullets(i, j).x = Bullets(i, j).x - Rnd() * 10
                        Bullets(i, j).y = Bullets(i, j).y + Rnd() * 20
                        Bullets(i, j).y = Bullets(i, j).y - Rnd() * 10
                    Next j
                Next i

            Case 28000 To 33000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / 50
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / 50
                        Bullets(i, j).x = Bullets(i, j).x - Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 33000 To 43000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        If Not Bullets(i, j).DrawingEnabled Then
                            Bullets(i, j).x = 960
                            Bullets(i, j).y = 540
                            Bullets(i, j).DrawingEnabled = True
                            Bullets(i, j).GrazeEnabled = True
                        End If
                        Randomize()
                        If Rnd() >= 0.5 Then
                            Bullets(i, j).x = Bullets(i, j).x + Rnd() * 10
                        Else
                            Bullets(i, j).x = Bullets(i, j).x - Rnd() * 10
                        End If
                        If Rnd() >= 0.5 Then
                            Bullets(i, j).y = Bullets(i, j).y + Rnd() * 10
                        Else
                            Bullets(i, j).y = Bullets(i, j).y - Rnd() * 10
                        End If
                    Next j
                Next i

            Case 43000 To 48000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / 50
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / 50
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y - Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 48000 To 58000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        Randomize()
                        If Not Bullets(i, j).DrawingEnabled Then
                            Bullets(i, j).x = 960
                            Bullets(i, j).y = 540
                            Select Case Rnd()
                                Case 0 To 0.1
                                    Bullets(i, j).dx = 1 + Rnd()
                                Case 0.1 To 0.2
                                    Bullets(i, j).dx = 2 + Rnd()
                                Case 0.2 To 0.3
                                    Bullets(i, j).dx = 3 + Rnd()
                                Case 0.3 To 0.4
                                    Bullets(i, j).dx = 4 + Rnd()
                                Case 0.4 To 0.5
                                    Bullets(i, j).dx = 5 + Rnd()
                                Case 0.5 To 0.6
                                    Bullets(i, j).dx = 6 + Rnd()
                                Case 0.6 To 0.7
                                    Bullets(i, j).dx = 7 + Rnd()
                                Case 0.7 To 0.8
                                    Bullets(i, j).dx = 8 + Rnd()
                                Case 0.8 To 0.9
                                    Bullets(i, j).dx = 9 + Rnd()
                                Case 0.9 To 1
                                    Bullets(i, j).dx = Rnd()
                            End Select
                            Select Case Rnd()
                                Case 0 To 0.1
                                    Bullets(i, j).dy = 1 + Rnd()
                                Case 0.1 To 0.2
                                    Bullets(i, j).dy = 2 + Rnd()
                                Case 0.2 To 0.3
                                    Bullets(i, j).dy = 3 + Rnd()
                                Case 0.3 To 0.4
                                    Bullets(i, j).dy = 4 + Rnd()
                                Case 0.4 To 0.5
                                    Bullets(i, j).dy = 5 + Rnd()
                                Case 0.5 To 0.6
                                    Bullets(i, j).dy = 6 + Rnd()
                                Case 0.6 To 0.7
                                    Bullets(i, j).dy = 7 + Rnd()
                                Case 0.7 To 0.8
                                    Bullets(i, j).dy = 8 + Rnd()
                                Case 0.8 To 0.9
                                    Bullets(i, j).dy = 9 + Rnd()
                                Case 0.9 To 1
                                    Bullets(i, j).dy = Rnd()
                            End Select
                            If Rnd() >= 0.5 Then
                                Bullets(i, j).dx = Bullets(i, j).dx
                            Else
                                Bullets(i, j).dx = -Bullets(i, j).dx
                            End If
                            If Rnd() >= 0.5 Then
                                Bullets(i, j).dy = Bullets(i, j).dy
                            Else
                                Bullets(i, j).dy = -Bullets(i, j).dy
                            End If
                        End If

                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 58000 To 63000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / 50
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / 50
                        Bullets(i, j).x = Bullets(i, j).x - Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 63000 To 73000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        Randomize()
                        If Not Bullets(i, j).DrawingEnabled Then
                            Bullets(i, j).x = 960
                            Bullets(i, j).y = 540
                            Select Case Rnd()
                                Case 0 To 0.1
                                    Bullets(i, j).dx = 1 + Rnd()
                                Case 0.1 To 0.2
                                    Bullets(i, j).dx = 2 + Rnd()
                                Case 0.2 To 0.3
                                    Bullets(i, j).dx = 3 + Rnd()
                                Case 0.3 To 0.4
                                    Bullets(i, j).dx = 4 + Rnd()
                                Case 0.4 To 0.5
                                    Bullets(i, j).dx = 5 + Rnd()
                                Case 0.5 To 0.6
                                    Bullets(i, j).dx = 6 + Rnd()
                                Case 0.6 To 0.7
                                    Bullets(i, j).dx = 7 + Rnd()
                                Case 0.7 To 0.8
                                    Bullets(i, j).dx = 8 + Rnd()
                                Case 0.8 To 0.9
                                    Bullets(i, j).dx = 9 + Rnd()
                                Case 0.9 To 1
                                    Bullets(i, j).dx = Rnd()
                            End Select
                            Select Case Rnd()
                                Case 0 To 0.1
                                    Bullets(i, j).dy = 1 + Rnd()
                                Case 0.1 To 0.2
                                    Bullets(i, j).dy = 2 + Rnd()
                                Case 0.2 To 0.3
                                    Bullets(i, j).dy = 3 + Rnd()
                                Case 0.3 To 0.4
                                    Bullets(i, j).dy = 4 + Rnd()
                                Case 0.4 To 0.5
                                    Bullets(i, j).dy = 5 + Rnd()
                                Case 0.5 To 0.6
                                    Bullets(i, j).dy = 6 + Rnd()
                                Case 0.6 To 0.7
                                    Bullets(i, j).dy = 7 + Rnd()
                                Case 0.7 To 0.8
                                    Bullets(i, j).dy = 8 + Rnd()
                                Case 0.8 To 0.9
                                    Bullets(i, j).dy = 9 + Rnd()
                                Case 0.9 To 1
                                    Bullets(i, j).dy = Rnd()
                            End Select
                            If Rnd() >= 0.5 Then
                                Bullets(i, j).dx = Bullets(i, j).dx
                            Else
                                Bullets(i, j).dx = -Bullets(i, j).dx
                            End If
                            If Rnd() >= 0.5 Then
                                Bullets(i, j).dy = Bullets(i, j).dy
                            Else
                                Bullets(i, j).dy = -Bullets(i, j).dy
                            End If
                            If CInt(14 * Math.Sin(Rnd() * Math.PI)) - 1 < 0 Then
                                Bullets(i, j).Index = 0
                            Else
                                Bullets(i, j).Index = CInt(14 * Math.Sin(Rnd() * Math.PI)) - 1
                            End If
                            Bullets(i, j).Index = Bullets(i, j).Index + 24
                            Bullets(i, j).DrawingEnabled = True
                            Bullets(i, j).GrazeEnabled = True
                        End If
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 73000 To 78000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / 50
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / 50
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 78000 To 88000

                Dim ControlValue As Single = 4
                Dim ReduceValue As Single = 80
                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        If Not Bullets(i, j).DrawingEnabled Then
                            Bullets(i, j).x = ControlValue * j * Math.Cos(0.2 * Math.PI * i + j) + 960
                            Bullets(i, j).y = ControlValue * j * Math.Sin(0.2 * Math.PI * i + j) + 540
                            Bullets(i, j).DrawingEnabled = True
                            Bullets(i, j).GrazeEnabled = True
                        End If
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / ReduceValue
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / ReduceValue
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 88000 To 93000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / 50
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / 50
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y - Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 93000 To 103000

                Dim ControlValue As Single = 5

                Dim ReduceValue As Single = 80
                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        If Not Bullets(i, j).DrawingEnabled Then
                            Bullets(i, j).x = ControlValue * j * Math.Cos(j) * Math.Cos(0.2 * Math.PI * i + j) + 960
                            Bullets(i, j).y = ControlValue * j * Math.Cos(j) * Math.Sin(0.2 * Math.PI * i + j) + 540
                            Bullets(i, j).DrawingEnabled = True
                            Bullets(i, j).GrazeEnabled = True
                        End If
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / ReduceValue
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / ReduceValue
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 103000 To 108000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / 50
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / 50
                        Bullets(i, j).x = Bullets(i, j).x - Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 108000 To 118000

                Dim ControlValue As Single = 2
                Dim FunctionValue As Single = 0.1
                Dim ReduceValue As Single = 80
                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        If Not Bullets(i, j).DrawingEnabled Then
                            Bullets(i, j).x = ControlValue * Math.E ^ (FunctionValue * j) * Math.Cos(0.2 * Math.PI * i + j) + 960
                            Bullets(i, j).y = ControlValue * Math.E ^ (FunctionValue * j) * Math.Sin(0.2 * Math.PI * i + j) + 540
                            Bullets(i, j).DrawingEnabled = True
                            Bullets(i, j).GrazeEnabled = True
                        End If
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / ReduceValue
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / ReduceValue
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 118000 To 123000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / 50
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / 50
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y - Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 123000 To 133000

                Dim ControlValue As Single = 200
                Dim ReduceValue As Single = 80
                For i = 0 To 5 Step DifficultyValue
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        If Not Bullets(i, j).DrawingEnabled Then
                            Bullets(i, j).x = ControlValue * Math.Sin(j) * Math.Cos(0.2 * Math.PI * i + 2 * j) + 960
                            Bullets(i, j).y = ControlValue * Math.Cos(j) * Math.Sin(0.2 * Math.PI * i + 2 * j) + 540
                            Bullets(i, j).DrawingEnabled = True
                            Bullets(i, j).GrazeEnabled = True
                        End If
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / ReduceValue
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / ReduceValue
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i
                For i = 5 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        If Not Bullets(i, j).DrawingEnabled Then
                            Bullets(i, j).x = ControlValue * Math.Sin(2 * j) * Math.Cos(0.2 * Math.PI * i + j) + 960
                            Bullets(i, j).y = ControlValue * Math.Cos(2 * j) * Math.Sin(0.2 * Math.PI * i + j) + 540
                            Bullets(i, j).DrawingEnabled = True
                            Bullets(i, j).GrazeEnabled = True
                        End If
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / ReduceValue
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / ReduceValue
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 133000 To 138000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        Bullets(i, j).dx = (Bullets(i, j).x - 960) / 50
                        Bullets(i, j).dy = (Bullets(i, j).y - 540) / 50
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx / 2
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy / 2
                    Next j
                Next i

            Case 138000 To 158000

                For i = 0 To DifficultyUpI Step 1
                    For j = 0 To DifficultyUpJ Step DifficultyValue
                        If Not Bullets(i, j).DrawingEnabled Then
                            If Rnd() > 0.5 Then
                                Bullets(i, j).x = 960 + Rnd() * 200
                                Bullets(i, j).y = 540 + Rnd() * 200
                            Else
                                Bullets(i, j).x = 960 - Rnd() * 200
                                Bullets(i, j).y = 540 - Rnd() * 200
                            End If
                            If Rnd() > 0.5 Then
                                Bullets(i, j).x = 960 + Rnd() * 200
                                Bullets(i, j).y = 540 - Rnd() * 200
                            Else
                                Bullets(i, j).x = 960 - Rnd() * 200
                                Bullets(i, j).y = 540 + Rnd() * 200
                            End If
                            Bullets(i, j).DrawingEnabled = True
                            Bullets(i, j).GrazeEnabled = True
                        End If
                        Bullets(i, j).dx = (Player1.x - Bullets(i, j).x) / WDJ_E_Lite.Base.MathGroup.Distance2D(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y)
                        Bullets(i, j).dy = (Player1.y - Bullets(i, j).y) / WDJ_E_Lite.Base.MathGroup.Distance2D(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y)
                        Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx * 5
                        Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy * 5
                        If WDJ_E_Lite.Base.MathGroup.Distance2D(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y) < 50 Then
                            Bullets(i, j).DrawingEnabled = False
                        End If
                    Next j
                Next i

            Case Is > 158000

                GameTime = 0

        End Select

        GameTime = GameTime + 10

    End Sub
    Private Sub BulletTestSub()
        For i = 0 To 10 Step 1
            For j = 0 To 100 Step DifficultyValue
                If Not Bullets(i, j).DrawingEnabled Then

                    Bullets(i, j).x = 1920 * Rnd()
                    Bullets(i, j).y = 1080 * Rnd()

                    Bullets(i, j).DrawingEnabled = True
                    Bullets(i, j).GrazeEnabled = True
                End If
                ''速度向量单位化Start
                'Bullets(i, j).dx = (Player1.x - Bullets(i, j).x) / WDJ_E_Lite.Base.MathGroup.Distance2D(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y)
                'Bullets(i, j).dy = (Player1.y - Bullets(i, j).y) / WDJ_E_Lite.Base.MathGroup.Distance2D(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y)
                ''速度向量单位化End
                'Bullets(i, j).dx = WDJ_E_Lite.Base.MathGroup.Distance2D(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y) / (Player1.x - Bullets(i, j).x)
                'Bullets(i, j).dy = WDJ_E_Lite.Base.MathGroup.Distance2D(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y) / (Player1.y - Bullets(i, j).y)

                Bullets(i, j).x = Bullets(i, j).x + Bullets(i, j).dx * 5
                Bullets(i, j).y = Bullets(i, j).y + Bullets(i, j).dy * 5
                If WDJ_E_Lite.Base.MathGroup.Distance2D(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y) > 30 Then
                    '速度向量单位化Start
                    Bullets(i, j).dx = (Player1.x - Bullets(i, j).x) / WDJ_E_Lite.Base.MathGroup.Distance2D(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y)
                    Bullets(i, j).dy = (Player1.y - Bullets(i, j).y) / WDJ_E_Lite.Base.MathGroup.Distance2D(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y)
                    '速度向量单位化End
                Else
                    'Bullets(i, j).DrawingEnabled = False
                End If
            Next j
        Next i

        'Player1.x = Math.Cos(GameTime / 20) * 200 + 960
        'Player1.y = Math.Sin(GameTime / 20) * 200 + 540
        GameTime = GameTime + 1
    End Sub
    Private Sub BulletTest()
        For i = 0 To DifficultyUpI Step 1
            For j = 0 To DifficultyUpJ Step DifficultyValue
                With Bullets(i, j)
                    If Not .DrawingEnabled And (GameTime Mod 30 = 0) Then
                        .x = 960
                        .y = -100
                        .dx = (Rnd() - 0.5)
                        .dy = Rnd()
                        .DrawingEnabled = True
                        .GrazeEnabled = True
                    End If
                    '.dx = (.x - 960) / 5
                    '.dy = (.y - 540) / 5
                    .x = .x + .dx * 50
                    .y = .y + .dy * 50
                End With
            Next j
        Next i
        GameTime = GameTime + 1
    End Sub
    Private Sub BulletControlSub()
        If Player1.x < 0 Then
            Player1.x = 0
        End If
        If Player1.x > 1920 Then
            Player1.x = 1920
        End If
        If Player1.y < 0 Then
            Player1.y = 0
        End If
        If Player1.y > 1080 Then
            Player1.y = 1080
        End If

        For i = 0 To 100 Step 1
            For j = 0 To 1000 Step 1
                'If Bullets(i, j).x < -100 Then
                '    Bullets(i, j).DrawingEnabled = False
                '    Bullets(i, j).x = 0
                'End If
                'If Bullets(i, j).x > 2020 Then
                '    Bullets(i, j).DrawingEnabled = False
                '    Bullets(i, j).x = 0
                'End If
                'If Bullets(i, j).y < -100 Then
                '    Bullets(i, j).DrawingEnabled = False
                '    Bullets(i, j).y = 0
                'End If
                'If Bullets(i, j).y > 1180 Then
                '    Bullets(i, j).DrawingEnabled = False
                '    Bullets(i, j).y = 0
                'End If
                If Bullets(i, j).DrawingEnabled Then
                    If Base.MathGroup.Distance2D(960, 540, Bullets(i, j).x, Bullets(i, j).y) > 1500 Then
                        Bullets(i, j).DrawingEnabled = False
                        Bullets(i, j).x = 0 : Bullets(i, j).y = 0
                    End If
                End If
            Next j
        Next i
    End Sub
    Private Sub BulletJudgeSub()

        For i = 0 To 100 Step 1
            For j = 0 To 1000 Step DifficultyValue
                If Bullets(i, j).DrawingEnabled Then
                    If WDJ_E_Lite.STG.BulletPreJudge(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y, 500) And Bullets(i, j).DrawingEnabled Then

                        Flag = WDJ_E_Lite.STG.BulletJudge(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y, BulletWidth / 2, BulletWidth / 2 * 1.5)
                        If Flag = JUDGE_AWAY And (Not Bullets(i, j).DrawingEnabled Or Not Bullets(i, j).GrazeEnabled) Then
                            Bullets(i, j).DrawingEnabled = True
                            Bullets(i, j).GrazeEnabled = True
                            Flag = JUDGE_NONE
                        End If

                        Flag = WDJ_E_Lite.STG.BulletJudge(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y, BulletWidth / 2, BulletWidth / 2 * 1.5)
                        If Flag = JUDGE_MISS Then
                            If Not Dir(Application.StartupPath & "\Audio\BIU.wav") = "" Then
                                WDJ_E_Lite.Base.AudioGroup.DxLibVB.PlaySE(Application.StartupPath & "\Audio\BIU.wav")
                            End If
                            MissValue = MissValue + 1
                            Bullets(i, j).DrawingEnabled = False
                            Flag = JUDGE_NONE
                            Player1.x = 960
                            Player1.y = 1000
                        End If

                        Flag = WDJ_E_Lite.STG.BulletJudge(Player1.x, Player1.y, Bullets(i, j).x, Bullets(i, j).y, BulletWidth / 2, BulletWidth / 2 * 1.5)
                        If Flag = JUDGE_GRAZE And Bullets(i, j).DrawingEnabled And Bullets(i, j).GrazeEnabled Then
                            If Not Dir(Application.StartupPath & "\Audio\graze.wav") = "" Then
                                WDJ_E_Lite.Base.AudioGroup.DxLibVB.PlaySE(Application.StartupPath & "\Audio\graze.wav")
                            End If
                            GrazeValue = GrazeValue + 1
                            Bullets(i, j).GrazeEnabled = False
                            Flag = JUDGE_NONE
                        End If
                    End If
                End If
            Next j
        Next i

        'For i = 0 To 100 Step 1
        '    For j = 0 To 1000 Step 1
        '        If Bullets(100, j).DrawingEnabled Then
        '            If WDJ_E_Lite.STG.BulletPreJudge(Player1.x, Player1.y, Bullets(100, j).x, Bullets(100, j).y, 500) And Bullets(100, j).DrawingEnabled Then

        '                Flag = WDJ_E_Lite.STG.BulletJudge(Enemies(i).x, Enemies(i).y, Bullets(100, j).x, Bullets(100, j).y, Bullets(100, j).Width / 2, Bullets(100, j).Width / 2)
        '                If Flag = JUDGE_MISS Then
        '                    If Not Dir(Application.StartupPath & "\Audio\bu.wav") = "" Then
        '                        DxLibVB.PlaySE(Application.StartupPath & "\Audio\bu.wav")
        '                    End If
        '                    Enemies(i).Life = Enemies(i).Life - 2
        '                    Bullets(100, j).DrawingEnabled = False
        '                    If Enemies(i).Life <= 0 Then
        '                        Enemies(i).DrawingEnabled = False
        '                    End If
        '                End If

        '            End If
        '        End If
        '    Next j
        'Next i
    End Sub
    Private Sub STGControlSub()
        If GetKey(Keys.ShiftKey) Then
            If GetKey(Keys.Up) Then
                Player1.y = Player1.y - 3
            End If
            If GetKey(Keys.Down) Then
                Player1.y = Player1.y + 3
            End If
            If GetKey(Keys.Left) Then
                Player1.x = Player1.x - 3
            End If
            If GetKey(Keys.Right) Then
                Player1.x = Player1.x + 3
            End If
        Else
            If GetKey(Keys.Up) Then
                Player1.y = Player1.y - 6
            End If
            If GetKey(Keys.Down) Then
                Player1.y = Player1.y + 6
            End If
            If GetKey(Keys.Left) Then
                Player1.x = Player1.x - 6
            End If
            If GetKey(Keys.Right) Then
                Player1.x = Player1.x + 6
            End If
        End If
    End Sub
    Private Sub AVGControlSub()
        If Not Scenes(SceneStep) Is Nothing Then
            If Scenes(SceneStep).WordType = AVG.WordType.Loading Or Scenes(SceneStep).WordType = AVG.WordType.Saving Or _
                Scenes(SceneStep).WordType = AVG.WordType.Comment Or Scenes(SceneStep).WordType = AVG.WordType.Title Then
                If GetKey(Keys.Up) Then
                    Timer.Stop()
                    AVGControl = AVGControl - 1
                    DxLibDLL.DX.WaitTimer(200)
                    Timer.Start()
                End If
                If GetKey(Keys.Down) Then
                    Timer.Stop()
                    AVGControl = AVGControl + 1
                    DxLibDLL.DX.WaitTimer(200)
                    Timer.Start()
                End If
                If GetKey(Keys.Left) Then
                    Timer.Stop()
                    AVGControl = AVGControl - 1
                    DxLibDLL.DX.WaitTimer(200)
                    Timer.Start()
                End If
                If GetKey(Keys.Right) Then
                    Timer.Stop()
                    AVGControl = AVGControl + 1
                    DxLibDLL.DX.WaitTimer(200)
                    Timer.Start()
                End If

                If AVGControl < 0 Then AVGControl = 0
                Dim UpTmp As Integer = 0
                Do
                    UpTmp = UpTmp + 1
                Loop Until Scenes(SceneStep).Choices(UpTmp).Context = Nothing
                UpTmp = UpTmp - 1
                If AVGControl > UpTmp Then AVGControl = UpTmp

                If GetKey(Keys.Z) Then
                    Timer.Stop()
                    SceneStep = Scenes(SceneStep).Choices(AVGControl).JumpSceneIndex
                    DxLibDLL.DX.WaitTimer(200)
                    Timer.Start()
                End If
            Else
                If GetKey(Keys.Z) Then
                    Timer.Stop()
                    SceneStep = SceneStep + 1
                    DxLibDLL.DX.WaitTimer(200)
                    Timer.Start()
                End If
            End If
        End If

        'If GetKey(Keys.W) Then
        '    CameraValue(0) = CameraValue(0) + 1
        'End If
        'If GetKey(Keys.S) Then
        '    CameraValue(0) = CameraValue(0) - 1
        'End If
        'If GetKey(Keys.A) Then
        '    CameraValue(1) = CameraValue(1) + 1
        'End If
        'If GetKey(Keys.D) Then
        '    CameraValue(1) = CameraValue(1) - 1
        'End If
        'If GetKey(Keys.Q) Then
        '    CameraValue(2) = CameraValue(2) + 1
        'End If
        'If GetKey(Keys.E) Then
        '    CameraValue(2) = CameraValue(2) - 1
        'End If

        'If GetKey(Keys.I) Then
        '    CameraValue(3) = CameraValue(3) + 1
        'End If
        'If GetKey(Keys.K) Then
        '    CameraValue(3) = CameraValue(3) - 1
        'End If
        'If GetKey(Keys.J) Then
        '    CameraValue(4) = CameraValue(4) + 1
        'End If
        'If GetKey(Keys.L) Then
        '    CameraValue(4) = CameraValue(4) - 1
        'End If
        'If GetKey(Keys.U) Then
        '    CameraValue(5) = CameraValue(5) + 1
        'End If
        'If GetKey(Keys.O) Then
        '    CameraValue(5) = CameraValue(5) - 1
        'End If

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If IsSTGEnabled Then
            STGControlSub()
        Else
            AVGControlSub()
        End If
    End Sub

End Class
