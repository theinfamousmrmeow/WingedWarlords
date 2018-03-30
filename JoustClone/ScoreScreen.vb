
Imports System.IO


Public Class ScoreScreen

    Dim brokerecord As Boolean = False

    Dim Filename As String = My.Settings.highscore_filepath

    Dim ranking As Integer = 0

    Private Sub CheckScores()

        brokerecord = False

        For i As Integer = lstScores.Items.Count - 1 To 0 Step -1

            If Game.SCORE > lstScores.Items.Item(i) Then
                brokerecord = True
                ranking = i
            End If

        Next

        If brokerecord = True Then
            lblScoreSplash.Text = lblScoreSplash.Text + " You broke " + lstNames.Items.Item(ranking).ToString + "'s score!"
            lstNames.Items.Item(ranking) = "_"
            lstScores.Items.Item(ranking) = Game.SCORE
            lblInput.Visible = True
            txtInput.Visible = True
            txtInput.Focus()
        Else

            lblInput.Visible = False
            txtInput.Visible = False
            lblScoreSplash.Text = lblScoreSplash.Text + " though none will remember thy name..."
        End If


    End Sub

    Private Sub ScoreScreen_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        CheckScores()
    End Sub

    Private Sub ScoreScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblScoreSplash.Visible = Game.BEEN_PLAYED

        lblScoreSplash.Text = String.Empty
        lblInput.Visible = False
        txtInput.Visible = False

        If WON = True Then lblScoreSplash.Text = lblScoreSplash.Text & "All glory to thee!  You have vanquished the evil in these lands,"
        If WON = False Then lblScoreSplash.Text = lblScoreSplash.Text & "Thou hast perished in the Sea of Sorrows, "

        If My.Settings.fullscreen = True Then Me.WindowState = FormWindowState.Maximized

        lblScoreSplash.Text = lblScoreSplash.Text + " and thy valiance garnered " + Game.SCORE.ToString + " points!"

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
                For counter = 0 To number_of_entries - 1
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
        ''Let the user type in their name
        If brokerecord = True Then
            lblInput.Visible = True
            txtInput.Visible = True
            txtInput.Focus()
        End If

    End Sub

    Private Sub ScoreScreen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        If brokerecord And File.Exists(Filename) Then
            ''Write the High Score Table to the file
            Dim scorefile As StreamWriter
            Dim strOutput As String = String.Empty
            Dim counter As Integer = 1

            ''Open up the file
            Try
                My.Computer.FileSystem.DeleteFile(Filename)
                Dim fs As FileStream = File.Create(Filename)
                fs.Close()
                scorefile = My.Computer.FileSystem.OpenTextFileWriter(Filename, True)
            Catch

            End Try
            ''Start writing what's currently on the table to this file
            For counter = 0 To lstNames.Items.Count - 1
                strOutput = lstNames.Items.Item(counter)
                scorefile.Write(strOutput)
                scorefile.WriteLine()
                strOutput = lstScores.Items.Item(counter)
                scorefile.Write(strOutput)
                scorefile.WriteLine()
            Next
            scorefile.Close()
        End If
        ''
        brokerecord = False
        Game.SCORE = 0
        ''Go back to main menu
        MainMenu.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub txtInput_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not txtInput.Text = String.Empty Then
                lblInput.Focus()
            End If
        End If
    End Sub

    Private Sub txtInput_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInput.KeyPress

    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles txtInput.Leave
        If brokerecord = True Then
            sender.Hide()
            lblInput.Hide()
            ''Dim mypos As Integer = lstNames.Items.IndexOf("_")
            lstNames.Items.RemoveAt(ranking)
            lstNames.Items.Insert(ranking, txtInput.Text)
        End If
    End Sub

    Private Sub txtInput_TextChanged(sender As Object, e As EventArgs) Handles txtInput.TextChanged

    End Sub

    Private Sub lblScoreSplash_Click(sender As Object, e As EventArgs) Handles lblScoreSplash.Click

    End Sub
End Class