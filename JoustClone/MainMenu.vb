
Public Class MainMenu



    Dim counter As Integer = 0
    ' Accessing the Winmm.dll, a windows API
    ' Not sure what kind of legal issues this raises...

    ''Here I'm declaring a function that I'll use later to play an mp3
    ''The function is actually in the 'winmm.dll' library
    ''Its called mciSendStringA in the library

    ''I didn't declare
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Int32, ByVal hwndCallback As Int32) As Int32

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ScoreScreen.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Game.NUM_PLAYERS = 1
        Game.Start()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OptionsScreen.Show()
    End Sub

    Private Sub MainMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Game.ClearGame()
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Game.WON = False
        lblStudios.Font = Game.FONT
        If My.Settings.fullscreen = True Then Me.WindowState = FormWindowState.Maximized
        Sound.play_bgm("C:\Users\student\Desktop\bgm_title.mp3")

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        counter += 1
        Me.Invalidate()
        Dim colors As Integer = 0
        colors = counter Mod 2
        Select Case colors
            Case 1
                lblTitle.ForeColor = Color.Yellow
                lblTitle2.ForeColor = Color.Red
            Case 0
                lblTitle.ForeColor = Color.Red
                lblTitle2.ForeColor = Color.Yellow
        End Select
        If counter > 100 Then


            Timer1.Enabled = 0
            lblTitle.ForeColor = Color.Maroon
            lblTitle2.ForeColor = Color.Purple

        End If
    End Sub

    Private Sub MainMenu_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim Font = New Font("Algerian", 72)
        Dim gradbrush = New Drawing2D.LinearGradientBrush(New Point(1 + counter * 2, 1), New Point(20 + counter * 2, 15), Color.Purple, Color.White)
        Dim gradbrush2 = New Drawing2D.LinearGradientBrush(New Point(1 + counter, 1), New Point(20 + counter, 20), Color.Azure, Color.Goldenrod)

        e.Graphics.DrawString("Winged", Font, gradbrush, New Point(100, 30))
        e.Graphics.DrawString("Warlords", Font, gradbrush2, New Point(130, 120))


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CreditsScreen.Show()
    End Sub

    Private Sub lblTitle2_Paint(sender As Object, e As PaintEventArgs) Handles lblTitle2.Paint, lblTitle.Paint

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Game.NUM_PLAYERS = 2
        Game.Start()
        Form1.Show()
    End Sub
End Class