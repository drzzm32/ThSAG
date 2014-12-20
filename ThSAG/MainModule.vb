Module MainModule
    Public Declare Function GetTickCount Lib "kernel32" Alias "GetTickCount" () As Long

    Public SceneStep As Integer = 0
    Public AVGControl As Integer = 0

    Public PathTmp(2, 10000) As String
    Public SceneTmp As WDJ_E_Lite.AVG.Scene = New WDJ_E_Lite.AVG.Scene
    Public ImageArray(2, 10000) As WDJ_E_Lite.Base.DrawingGroup.DxLibVB.Images

End Module
