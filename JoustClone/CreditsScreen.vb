Imports System.IO

Public Class CreditsScreen


    Private Sub CreditsScreen_Load(sender As Object, e As EventArgs) Handles Me.Load

        If My.Settings.fullscreen = True Then Me.WindowState = FormWindowState.Maximized
        ''Me.Controls.Remove(a)

        Dim scorefile As StreamReader
        ''& CStr(Directory.GetCurrentDirectory())
        ''That shit grabs the working directory.
        ''I'm there's someway I can hunt down this text file pragmatically.
        Dim Filename As String = "C:\Users\student\Documents\Visual Studio 2012\Projects\JoustClone\JoustClone\Resources\Credits.txt"
        Dim strOutput As String = My.Resources.Resources.Credits
        Dim counter As Integer = 1

        If File.Exists(Filename) Then

            Try

                ''OPEN THE HIGHSCORE FILE
                scorefile = File.OpenText(Filename)
                ''Read the data

                ''Read a name and score from file
                strOutput = scorefile.ReadToEnd
                ''Dim a As New Label()

                strOutput = strOutput

                a.Visible = True
                ''a.Font = Game.FONT
                a.Text = strOutput
                a.ForeColor = Color.White
                a.BackColor = Color.Black
                a.Enabled = True
                a.Width = 300
                a.Height = 800
                a.TextAlign = ContentAlignment.MiddleCenter
                a.Left = ClientRectangle.Width / 2 - a.Width / 2
                a.Top = ClientRectangle.Height / 2 - a.Height / 2
                a.Top = ClientRectangle.Bottom
                ''Close the file
                scorefile.Close()

            Catch

                MessageBox.Show("Found the file, but failed to open it!")
            Finally




            End Try
        Else
            MessageBox.Show("No Credits file found.")
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        a.Top -= 1
        Me.Invalidate()
        If a.Bottom < 0 Then
            a.Top = ClientRectangle.Bottom
            MainMenu.Show()
            Me.Close()
        End If
    End Sub

    Private Sub CreditsScreen_Paint(sender As Object, e As PaintEventArgs) Handles a.Paint

        Dim Font = a.Font
        Dim gradbrush = New Drawing2D.LinearGradientBrush(New Point(1, 1), New Point(15, 15), Color.Purple, Color.White)
        ''Dim gradbrush2 = New Drawing2D.LinearGradientBrush(New Point(1, 1), New Point(20, 20), Color.Azure, Color.Goldenrod)

        '' e.Graphics.DrawString(a.Text, Font, gradbrush, a.Top, a.Left)

    End Sub
End Class