Public Class Main
    Dim MousePos As Point
    Private Sub Main_MouseMove(sender As Object, e As MouseEventArgs) Handles TOPButton.MouseMove
        If Not e.Button = Windows.Forms.MouseButtons.None Then
            Dim PosTmp As Point = MyBase.PointToScreen(e.Location)
            If MyBase.WindowState = FormWindowState.Maximized Then
                FormMinSub()
            End If
            If MyBase.WindowState = FormWindowState.Normal Then
                PosTmp = MyBase.PointToScreen(e.Location)
                If MyBase.Left <= 5 Then
                    MyBase.Left = PosTmp.X - MyBase.Width / 2
                    MousePos = New Point(PosTmp.X - MyBase.Left, PosTmp.Y - MyBase.Top)
                End If
                MyBase.Left = PosTmp.X - MousePos.X
                MyBase.Top = PosTmp.Y - MousePos.Y
            End If
        End If
    End Sub
    Private Sub Main_MouseDown(sender As Object, e As MouseEventArgs) Handles TOPButton.MouseDown
        If Not e.Button = Windows.Forms.MouseButtons.None Then
            Dim PosTmp As Point = MyBase.PointToScreen(e.Location)
            MousePos = New Point(PosTmp.X - MyBase.Left, PosTmp.Y - MyBase.Top)
        End If
    End Sub
    Private Sub Main_MouseUp(sender As Object, e As MouseEventArgs) Handles TOPButton.MouseUp
        If MyBase.Top < 0 Then
            FormMaxSub()
        End If
    End Sub
    Private Sub FormRepair()
        UpExitButton.Left = Me.Width - UpExitButton.Width
        MaxButton.Left = UpExitButton.Left - MaxButton.Width
        MinButton.Left = MaxButton.Left - MinButton.Width
        TOPButton.Width = MinButton.Left - TOPButton.Left

        ModeBButton.Top = Me.Height - ModeBButton.Height - 12
        BasicPanel.Left = (Me.Width - BasicPanel.Width) / 2
        BasicPanel.Top = (Me.Height - BasicPanel.Height) / 2

        AdvancedPanel.Width = Me.Width
        AdvancedPanel.Height = Me.Height - AboutButton.Height
        ModeAButton.Top = AdvancedPanel.Height - ModeAButton.Height - 12
        DecOder.Width = AdvancedPanel.Width / 2 - 12
    End Sub
    '/////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FileSystem.Dir(Application.StartupPath & "\back.jpg") <> "" Then
            Me.BackgroundImage = New Bitmap(Application.StartupPath & "\back.jpg")
        End If
        If FileSystem.Dir(Application.StartupPath & "\back.png") <> "" Then
            Me.BackgroundImage = New Bitmap(Application.StartupPath & "\back.png")
        End If
        If FileSystem.Dir(Application.StartupPath & "\back.bmp") <> "" Then
            Me.BackgroundImage = New Bitmap(Application.StartupPath & "\back.bmp")
        End If
    End Sub

    Private Sub UpExitButton_Click(sender As Object, e As EventArgs) Handles UpExitButton.Click
        End
    End Sub

    Private Sub MaxButton_Click(sender As Object, e As EventArgs) Handles MaxButton.Click
        If Me.WindowState = FormWindowState.Maximized Then
            FormMinSub()
            Exit Sub
        End If
        FormMaxSub()
    End Sub
    Private Sub FormMaxSub()
        Me.WindowState = FormWindowState.Maximized
        FormRepair()
        MaxButton.Text = "Re"
    End Sub
    Private Sub FormMinSub()
        Me.WindowState = FormWindowState.Normal
        FormRepair()
        MaxButton.Text = "Ma"
    End Sub
    Private Sub MinButton_Click(sender As Object, e As EventArgs) Handles MinButton.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub AboutButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        MsgBox("This is ThSAG Engine Development kit." & Chr(10) & "CopyRight the WDJ 2005 - 2015, All Rights Reserved.", MsgBoxStyle.OkOnly, "About")
    End Sub

    Private Sub ModeBButton_Click(sender As Object, e As EventArgs) Handles ModeBButton.Click
        BasicPanel.Hide()
        AdvancedPanel.Show()
    End Sub
    Private Sub ModeAButton_Click(sender As Object, e As EventArgs) Handles ModeAButton.Click
        BasicPanel.Show()
        AdvancedPanel.Hide()
    End Sub
End Class
