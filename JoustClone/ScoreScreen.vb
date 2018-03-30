
Imports System.IO


Public Class ScoreScreen

    Dim brokerecord As Boolean = False

    Dim Filename As String = "C:\Users\student\Documents\Visual Studio 2012\Projects\JoustClone\JoustClone\Resources\HIGHSCORES.txt"

    Dim ranking As Integer = 0

    Private Sub CheckScores()


        For i As Integer = lstScores.Items.Count - 1 To 0 Step -1

            If Game.SCORE > lstScores.Items.Item(i) Then
                brokerecord = True
                ranking = i
            End If

        Next

        If brokerecord = True Then
            lblScoreSplash.Text = lblScoreSplash.Text + " You broke " + lstNames.Items.Item(ranking).ToString + "'s score!"
            lstNames.Items.Item(ranking) = "Player"
            lstScores.Items.Item(ranking) = Game.SCORE
        Else
            lblScoreSplash.Text = lblScoreSplash.Text + " and none will remember thy name."
        End If


    End Sub

    Private Sub ScoreScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If WON = True Then lblScoreSplash.Text = "All glory to thee!  You have vanquished the evil in these lands!"
        If WON = False Then lblScoreSplash.Text = "Thou hast perished in the Sea of Sorrows, "

        If My.Settings.fullscreen = True Then Me.WindowState = FormWindowState.Maximized

        lblScoreSplash.Text = "Well fought!  Thou hast earned " + Game.SCORE.ToString + " points!"

        Dim newrecord As Boolean = False

        lstNames.Font = Game.FONT
        lstScores.Font = Game.FONT
        GroupBox1.Font = Game.FONT

        Const number_of_entries As Integer = 10

        Dim scorefile As StreamReader
        Dim strOutput As String = String.Empty
        Dim counter As Integer = 1

        If File.Exists(Filename) Then

            Try

                ''OPEN THE HIGHSCORE FILE
                scorefile = File.OpenText(Filename)
                ''Read the data
                For counter = 1 To number_of_entries
                    ''Read a name and score from file
                    strOutput = scorefile.ReadLine()
                    lstNames.Items.Add(strOutput)
                    strOutput = scorefile.ReadLine()
                    lstScores.Items.Add(strOutput)
                Next
                scorefile.Close()

            Catch
            Finally



            End Try

        Else
            MessageBox.Show("No high scores found.")

        End If

        CheckScores()

    End Sub

    Private Sub ScoreScreen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        If brokerecord Then
            ''Write the High Score Table to the file
            Dim scorefile As StreamReader
            Dim strOutput As String = String.Empty
            Dim counter As Integer = 1


            ''Open up the file
            scorefile = File.OpenText(Filename)

            ''Start writing what's currently on the table to this file
            'For count As Integer = 1 To lstNames.Items.Count
            ''strOutput = lstNames.Items.Item(count)
            ''scorefile.WriteLine(strOutput)


            '' Next
            scorefile.Close()
        End If
        ''Go back to main menu
        MainMenu.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class