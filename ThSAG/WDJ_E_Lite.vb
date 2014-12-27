Imports System.Drawing.Font
Imports System.Drawing.FontConverter
Imports System.Drawing.FontFamily
Public Class WDJ_E_Lite
    Public Declare Function GetKeyState Lib "user32.dll" (ByVal KeyCode As Integer) As Short
    Public Const JUDGE_MISS As Integer = 0
    Public Const JUDGE_GRAZE As Integer = 1
    Public Const JUDGE_AWAY As Integer = 2
    Public Const JUDGE_NONE As Integer = 3
    Public Const IMAGE_BG As Integer = 0
    Public Const IMAGE_CG As Integer = 1
    Public Const IMAGE_BULLET As Integer = 2

    Public Class Base
        Public Class MathGroup
            Shared Function Distance2D(ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single) As Single
                Return Math.Sqrt((x2 - x1) ^ 2 + (y2 - y1) ^ 2)
            End Function
            Shared Function Distance3D(ByVal x1 As Single, ByVal y1 As Single, ByVal z1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal z2 As Single) As Single
                Return Math.Sqrt((x2 - x1) ^ 2 + (y2 - y1) ^ 2 + (z1 - z2) ^ 2)
            End Function
        End Class

        Public Class DrawingGroup

            Public Class DxLibVB

                Public Structure Images
                    Public Handle As Integer
                    Public Width As Integer
                    Public Height As Integer
                End Structure

                Public Shared Sub DxSetIcon(ByVal Handle As Integer)
                    DxLibDLL.DX.SetWindowIconHandle(Handle)
                End Sub

                Public Shared Sub DxInit(ByVal Title As String, Optional ByVal IsFullScreen As Boolean = False, Optional ByVal Width As Integer = 640, Optional ByVal Height As Integer = 480)
                    If IsFullScreen Then
                        DxLibDLL.DX.ChangeWindowMode(1)
                        DxLibDLL.DX.SetWindowStyleMode(2)
                        DxLibDLL.DX.SetWindowSize(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
                    Else
                        DxLibDLL.DX.ChangeWindowMode(1)
                        DxLibDLL.DX.SetWindowStyleMode(5)
                        DxLibDLL.DX.SetWindowSize(Width, Height)
                    End If

                    DxLibDLL.DX.SetGraphMode(1920, 1080, 32) 'Use this method for basic
Jump:
                    DxLibDLL.DX.SetWindowText(Title)
                    DxLibDLL.DX.SetDisplayRefreshRate(60)
                    If DxLibDLL.DX.DxLib_Init() = -1 Then
                        End
                    End If
                    DxLibDLL.DX.SetDrawScreen(DxLibDLL.DX.DX_SCREEN_BACK)
                End Sub

                Public Shared Sub DxEnd()
                    DxLibDLL.DX.DxLib_End()
                End Sub

                Public Shared Function LoadTexture(ByVal IsRelativePath As Boolean, ByVal Path As String, ByRef Image As Images) As Boolean
                    If Not Path = "" Or Not Path = Nothing Then
                        If IsRelativePath Then
                            If FileSystem.Dir(Application.StartupPath & Path) <> "" Then
                                Image.Handle = DxLibDLL.DX.LoadGraph(Application.StartupPath & Path)
                                Dim ImgTep As Bitmap = New Bitmap(Application.StartupPath & Path)
                                Image.Width = ImgTep.Width
                                Image.Height = ImgTep.Height
                                ImgTep.Dispose()
                                Return True
                            Else
                                Return False
                            End If
                        Else
                            If FileSystem.Dir(Path) <> "" Then
                                Image.Handle = DxLibDLL.DX.LoadGraph(Path)
                                Dim ImgTep As Bitmap = New Bitmap(Path)
                                Image.Width = ImgTep.Width
                                Image.Height = ImgTep.Height
                                ImgTep.Dispose()
                                Return True
                            Else
                                Return False
                            End If
                        End If
                    Else
                        Return True
                    End If
                End Function
                Public Shared Function LoadString(ByRef Context As String, ByRef Brush As System.Drawing.Brush, ByVal Size As Integer, _
                                                  Optional ByVal Width As Integer = 1920, Optional ByVal Height As Integer = 1080) As Integer
                    Dim Image As System.Drawing.Bitmap = New Bitmap(Width, Height)
                    Dim GDI As System.Drawing.Graphics = Graphics.FromImage(Image)
                    Dim FontFamily As System.Drawing.FontFamily = New FontFamily("微软雅黑")
                    Dim Font As System.Drawing.Font = New Font(FontFamily, Size, FontStyle.Regular, GraphicsUnit.Pixel)
                    GDI.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    GDI.InterpolationMode = Drawing2D.InterpolationMode.High
                    GDI.DrawString(Context, Font, Brush, 0, 0)
                    Image.Save("String.dat", Imaging.ImageFormat.Png)
                    GDI.Dispose() : Image.Dispose() : Font.Dispose() : FontFamily.Dispose()
                    Return DxLibDLL.DX.LoadGraph("String.dat")
                End Function
                Public Shared Sub DrawString(x As Integer, ByVal y As Integer, ByRef Handle As Integer)
                    DxLibDLL.DX.DrawGraph(x, y, Handle, 1)
                End Sub
                Public Shared Sub DrawPic(ByVal Image As Images, ByVal x As Single, ByVal y As Single)
                    DxLibDLL.DX.DrawGraphF(x - (Image.Width / 2), y - (Image.Height / 2), Image.Handle, 1)
                    'DxLibDLL.DX.DrawGraphF(x, y, Image.Handle, 1)
                End Sub
                Public Shared Sub DrawPicR(ByVal Image As Images, ByVal Angle As Double, ByVal ExRate As Double, ByVal x As Single, ByVal y As Single, Optional ByVal z As Single = 0)
                    DxLibDLL.DX.DrawRotaGraph3D(x - Image.Width / 2, y - Image.Height / 2, z, ExRate, Angle, Image.Handle, 1)
                End Sub
                Public Class FPS
                    Private StartTime As Integer
                    Private Count As Integer
                    Private FPSNum As Single
                    Private Const N As Integer = 60
                    Private Const FPS As Integer = 60
                    Public Sub New()
                        StartTime = 0
                        Count = 0
                        FPSNum = 0
                    End Sub
                    Public Function Update() As Boolean
                        If Count = 0 Then
                            StartTime = GetTickCount
                        End If
                        If Count = N Then
                            Dim TmpTime As Integer = GetTickCount
                            FPSNum = 1000 / ((TmpTime - StartTime) / N)
                            Count = 0
                            StartTime = TmpTime
                        End If
                        Count = Count + 1
                        Return True
                    End Function
                    Public Function GetFPS()
                        Return FPSNum
                    End Function
                    Public Sub WaitTime()
                        Dim TookTime As Integer = GetTickCount - StartTime
                        Dim WaitTime As Integer = Count * 1000 / FPS - TookTime
                        If WaitTime > 0 Then
                            DxLibDLL.DX.WaitTimer(WaitTime)
                        End If
                    End Sub
                End Class

            End Class

        End Class

        Public Class ControlGroup
            Public Shared Function GetKey(ByVal KeyCode As Integer) As Boolean
                If &H8000 = (&H8000 And GetKeyState(KeyCode)) Then
                    Return True
                Else
                    Return False
                End If
            End Function
        End Class

        Public Class AudioGroup
            Public Class DxLibVB
                Public Shared Sub PlaySE(ByVal Path As String)
                    DxLibDLL.DX.PlaySoundFile(Path, DxLibDLL.DX.DX_PLAYTYPE_BACK)
                End Sub
                Public Shared Sub PlayBGM(ByVal Path As String)
                    DxLibDLL.DX.PlayMusic(Path, DxLibDLL.DX.DX_PLAYTYPE_LOOP)
                End Sub
            End Class
        End Class
    End Class


    Public Class STG

        Public Structure Objects
            Public x As Single
            Public y As Single
            Public Width As Single
            Public Height As Single
            Public Angle As Single
            Public Scale As Single
            Public k As Single
            Public dy As Single
            Public dx As Single
            Public dxIsZero As Boolean
            Public GrazeEnabled As Boolean
            Public DrawingEnabled As Boolean
            Public Life As Integer
            Public Type As Integer
            Public Index As Integer
            Public Sub Initilize()
                x = 0 : y = 0 : Angle = 0 : Scale = 0 : k = 0 : dy = 0 : dx = 0 : dxIsZero = False : GrazeEnabled = False : DrawingEnabled = False : Life = 0 : Type = 0 : Index = 0 : Width = 0 : Height = 0
            End Sub
        End Structure

        Shared Function BulletPreJudge(ByVal PlayerX As Single, ByVal PlayerY As Single, ByVal BulletX As Single, ByVal BulletY As Single, ByVal SetDistance As Single) As Boolean
            If Math.Abs(PlayerX - BulletX) < SetDistance And Math.Abs(PlayerY - BulletY) < SetDistance Then
                Return True
            Else
                Return False
            End If
        End Function

        Shared Function BulletJudge(ByVal PlayerX As Single, ByVal PlayerY As Single, ByVal BulletX As Single, ByVal BulletY As Single, ByVal SetMinDistance As Single, _
                                    ByVal SetMaxDistance As Single) As Integer
            If WDJ_E_Lite.Base.MathGroup.Distance2D(PlayerX, PlayerY, BulletX, BulletY) > SetMaxDistance Then
                Return JUDGE_AWAY
                Exit Function
            ElseIf WDJ_E_Lite.Base.MathGroup.Distance2D(PlayerX, PlayerY, BulletX, BulletY) > SetMinDistance Then
                Return JUDGE_GRAZE
            Else
                Return JUDGE_MISS
            End If
        End Function
    End Class
    Public Class AVG
        Public Structure Image
            Public Path As String
            Public Index As Integer
        End Structure
        Public Structure PicObj
            Public Location As Single     'Can use Enum
            Public IMG As Image
        End Structure
        Public Structure Selection
            Public Handle As Integer
            Public Context As String
            Public JumpSceneIndex As Integer
        End Structure
        Public Enum WordType
            Comment
            Script
            Title
            GameRun
            Saving
            Loading
        End Enum
        Public Class Scene
            Public SceneIndex As Integer
            Public BG As Image
            Public CG() As PicObj
            Public BGM As String
            Public WordType As WordType
            Public Choices() As Selection
            Public IsBuilt As Boolean
            Public Sub New()
                IsBuilt = False
                SceneIndex = -1
                BG.Path = ""
                BG.Index = -1
                BGM = ""
                WordType = -1
                ReDim CG(10)
                ReDim Choices(100)
            End Sub
        End Class
        Private Enum ScriptHead
            NULL
            StartSceneDim
            EndSceneDim
            Background
            BGM
            StartCGDim
            EndCGDim
            CGPath
            CGLocation
            StartWordDim
            Choice
            Jump
            EndWordDim
        End Enum
        Public Shared Function LoadScript(ByVal IsFullPath As Boolean, ByVal ScriptPath As String) As Scene()
            Dim SceneTmp(10000) As Scene
            Dim SceneIndexTmp As Integer = Nothing
            Dim CGIndexTmp As Integer = Nothing
            Dim ChoiceAutoIndexTmp As Integer = Nothing
            Dim ScriptFullPath As String = ""
            Dim AppStartPath As String = Application.StartupPath & "\"        '获取当前位置

            If IsFullPath Then        '确定脚本是在程序目录下被代码自动调用，还是手动选择调用
                ScriptFullPath = ScriptPath
            Else
                ScriptFullPath = Application.StartupPath & "\" & ScriptPath
            End If

            Dim Head As ScriptHead = ScriptHead.NULL        '定义脚本头
            Dim LineBreak As Integer = 10        '设定换行符
            Dim Size As Long = Microsoft.VisualBasic.FileIO.FileSystem.GetFileInfo(ScriptFullPath).Length     '获取文件大小
            Dim CookedString As String = ""     '定义已处理字符串变量
            Dim WordTmp As String = ""        '定义选择文字临时变量
            Dim Strings As String = Microsoft.VisualBasic.FileIO.FileSystem.ReadAllText(ScriptFullPath, System.Text.Encoding.Default)     '读取文件
            Dim Steps As Integer = Strings.Length     '获取字符串长度
            Dim x As Integer = 0, y As Integer = 0      '定义循环控制变量

            Do Until x >= Steps     '检测是否读到文件结尾
                Do Until Strings.Chars(x) = " " Or Strings.Chars(x) = Chr(LineBreak)    '检测是否读到空格或行结尾,并避开回车符
                    CookedString = CookedString & Strings.Chars(x)     '存入已处理字符串变量数组
                    x = x + 1     '下一个字符
                    If x = Steps Then                '这个String的编号（String.Chars(Integer)）是从0开始的，这里防止数组越界。
                        GoTo EndFlag                 '即字符数为Num的字符串其编号为0到Num-1，上面的+1实际已经超出界限，这里检
                    End If                           '测并跳出。
                Loop
                Select Case Head
                    Case ScriptHead.NULL
                        Select Case CookedString
                            Case "开始定义场景"
                                Head = ScriptHead.StartSceneDim
                            Case "结束定义场景"
                                Head = ScriptHead.EndSceneDim
                            Case "背景"
                                Head = ScriptHead.Background
                            Case "音乐"
                                Head = ScriptHead.BGM
                            Case "开始定义立绘"
                                Head = ScriptHead.StartCGDim
                            Case "结束定义立绘"
                                Head = ScriptHead.EndCGDim
                            Case "立绘地址"
                                Head = ScriptHead.CGPath
                            Case "立绘位置"
                                Head = ScriptHead.CGLocation
                            Case "开始定义文字"
                                Head = ScriptHead.StartWordDim
                            Case "选择"
                                Head = ScriptHead.Choice
                            Case "跳转"
                                Head = ScriptHead.Jump
                            Case "结束定义文字"
                                Head = ScriptHead.EndWordDim
                        End Select
                    Case ScriptHead.StartSceneDim
                        SceneIndexTmp = CInt(CookedString)
                        SceneTmp(SceneIndexTmp) = New Scene
                        SceneTmp(SceneIndexTmp).SceneIndex = SceneIndexTmp
                        Head = ScriptHead.NULL
                    Case ScriptHead.EndSceneDim
                        SceneTmp = Nothing
                        Head = ScriptHead.NULL
                    Case ScriptHead.Background
                        SceneTmp(SceneIndexTmp).BG.Path = AppStartPath & CookedString
                        SceneTmp(SceneIndexTmp).BG.Index = SceneIndexTmp
                        Head = ScriptHead.NULL
                    Case ScriptHead.BGM
                        SceneTmp(SceneIndexTmp).BGM = AppStartPath & CookedString
                        Head = ScriptHead.NULL
                    Case ScriptHead.StartCGDim
                        CGIndexTmp = CInt(CookedString)
                        SceneTmp(SceneIndexTmp).CG(CGIndexTmp).IMG.Index = CGIndexTmp
                        Head = ScriptHead.NULL
                    Case ScriptHead.EndCGDim
                        CGIndexTmp = Nothing
                        Head = ScriptHead.NULL
                    Case ScriptHead.CGPath
                        SceneTmp(SceneIndexTmp).CG(CGIndexTmp).IMG.Path = AppStartPath & CookedString
                        Head = ScriptHead.NULL
                    Case ScriptHead.CGLocation
                        SceneTmp(SceneIndexTmp).CG(CGIndexTmp).Location = CSng(CookedString)
                        Head = ScriptHead.NULL
                    Case ScriptHead.StartWordDim
                        ChoiceAutoIndexTmp = 0
                        Select Case CookedString
                            Case "对话" & vbCr
                                SceneTmp(SceneIndexTmp).WordType = WordType.Comment
                            Case "读档" & vbCr
                                SceneTmp(SceneIndexTmp).WordType = WordType.Loading
                            Case "存档" & vbCr
                                SceneTmp(SceneIndexTmp).WordType = WordType.Saving
                            Case "旁白" & vbCr
                                SceneTmp(SceneIndexTmp).WordType = WordType.Script
                            Case "标题" & vbCr
                                SceneTmp(SceneIndexTmp).WordType = WordType.Title
                            Case "启动" & vbCr
                                SceneTmp(SceneIndexTmp).WordType = WordType.GameRun
                        End Select
                        Head = ScriptHead.NULL
                    Case ScriptHead.Choice
                        WordTmp = WordTmp & CookedString & " "
                        If Strings.Chars(x) = Chr(LineBreak) Then
                            SceneTmp(SceneIndexTmp).Choices(ChoiceAutoIndexTmp).Context = WordTmp
                            WordTmp = ""
                            Head = ScriptHead.NULL
                        End If
                    Case ScriptHead.Jump
                        SceneTmp(SceneIndexTmp).Choices(ChoiceAutoIndexTmp).JumpSceneIndex = CInt(CookedString)
                        ChoiceAutoIndexTmp = ChoiceAutoIndexTmp + 1
                        Head = ScriptHead.NULL
                    Case ScriptHead.EndWordDim
                        ChoiceAutoIndexTmp = 0
                        Head = ScriptHead.NULL
                End Select

                CookedString = ""

                If Strings.Chars(x) = " " Or Strings.Chars(x) = Chr(LineBreak) Then     '检测是否读到行结尾
                    x = x + 1
                End If

            Loop
EndFlag:
            Return SceneTmp
        End Function
        Public Shared Sub BuildScene(ByVal Scene As Scene)
            If Not Scene Is Nothing Then
                SceneTmp = Scene
                If Not Scene.BG.Path = Nothing Or Not Scene.BG.Path = "" Then
                    Base.DrawingGroup.DxLibVB.DrawPic(ImageArray(IMAGE_BG, Scene.BG.Index), 960, 540)
                End If
                For i = 0 To Scene.CG.GetUpperBound(0) Step 1
                    If Not Scene.CG(i).IMG.Path = Nothing Or Not Scene.CG(i).IMG.Path = "" Then
                        Base.DrawingGroup.DxLibVB.DrawPic(ImageArray(IMAGE_CG, Scene.CG(i).IMG.Index), Scene.CG(i).Location, 800)
                    End If
                Next i
                Select Case Scene.WordType
                    Case WordType.Comment
                        For i = 0 To Scene.Choices.GetUpperBound(0) Step 1
                            If Not Scene.Choices(i).Handle = Nothing Then
                                'DxLibDLL.DX.DrawString(100, 900 + i * 20, Scene.Choices(i).Handle, 16777215)
                                Base.DrawingGroup.DxLibVB.DrawString(100, 600 + i * 100, Scene.Choices(i).Handle)
                                'DxLibDLL.DX.DrawString(100, 900 + AVGControl * 20, Scene.Choices(AVGControl).Context, 65535)
                                Base.DrawingGroup.DxLibVB.DrawPic(ImageArray(IMAGE_BULLET, 0), 100, 650 + AVGControl * 100)
                            End If
                        Next i
                    Case WordType.GameRun
                        For i = 0 To Scene.Choices.GetUpperBound(0) Step 1
                            If Not Scene.Choices(i).Handle = Nothing Then
                                'DxLibDLL.DX.DrawString(100, 400 + i * 20, Scene.Choices(i).Handle, 16777215)
                                Base.DrawingGroup.DxLibVB.DrawString(100, 400 + i * 200, Scene.Choices(i).Handle)
                            End If
                        Next i
                    Case WordType.Loading
                        For i = 0 To Scene.Choices.GetUpperBound(0) Step 1
                            If Not Scene.Choices(i).Handle = Nothing Then
                                'DxLibDLL.DX.DrawString(100, 100 + i * 20, Scene.Choices(i).Handle, 16777215)
                                Base.DrawingGroup.DxLibVB.DrawString(100, 100 + i * 100, Scene.Choices(i).Handle)
                                'DxLibDLL.DX.DrawString(100, 100 + AVGControl * 20, Scene.Choices(AVGControl).Context, 65535)
                                Base.DrawingGroup.DxLibVB.DrawPic(ImageArray(IMAGE_BULLET, 0), 100, 150 + AVGControl * 100)
                            End If
                        Next i
                    Case WordType.Saving
                        For i = 0 To Scene.Choices.GetUpperBound(0) Step 1
                            If Not Scene.Choices(i).Handle = Nothing Then
                                'DxLibDLL.DX.DrawString(100, 100 + i * 20, Scene.Choices(i).Handle, 16777215)
                                Base.DrawingGroup.DxLibVB.DrawString(100, 100 + i * 100, Scene.Choices(i).Handle)
                                'DxLibDLL.DX.DrawString(100, 100 + AVGControl * 20, Scene.Choices(AVGControl).Context, 65535)
                                Base.DrawingGroup.DxLibVB.DrawPic(ImageArray(IMAGE_BULLET, 0), 100, 150 + AVGControl * 100)
                            End If
                        Next i
                    Case WordType.Script
                        For i = 0 To Scene.Choices.GetUpperBound(0) Step 1
                            If Not Scene.Choices(i).Handle = Nothing Then
                                'DxLibDLL.DX.DrawString(100, 900 + i * 20, Scene.Choices(i).Handle, 16777215)
                                Base.DrawingGroup.DxLibVB.DrawString(100, 600 + i * 100, Scene.Choices(i).Handle)
                            End If
                        Next i
                    Case WordType.Title
                        For i = 0 To Scene.Choices.GetUpperBound(0) Step 1
                            If Not Scene.Choices(i).Handle = Nothing Then
                                'DxLibDLL.DX.DrawString(920, 100 + i * 20, Scene.Choices(i).Handle, 16777215)
                                Base.DrawingGroup.DxLibVB.DrawString(800, 100 + i * 100, Scene.Choices(i).Handle)
                                'DxLibDLL.DX.DrawString(920, 100 + AVGControl * 20, Scene.Choices(AVGControl).Context, 65535)
                                Base.DrawingGroup.DxLibVB.DrawPic(ImageArray(IMAGE_BULLET, 0), 800, 150 + AVGControl * 100)
                            End If
                        Next i
                End Select

                If Not Scene.BGM = Nothing Then
                    Base.AudioGroup.DxLibVB.PlayBGM(Scene.BGM)
                End If

                Scene.IsBuilt = True
            End If
        End Sub
    End Class
End Class
