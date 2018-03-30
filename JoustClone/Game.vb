Module Game

    Public Const INVINCIBILITY_LENGTH As Integer = 60
    Public Const DISTANCE_TO_CASTLE = 1000

    Public WON = False
    Public DEFAULT_WIDTH = 640
    Public DEFAULT_HEIGHT = 480
    Public number_of_agents As Integer = 0
    Public SCORE As Integer = 0
    Public SCORE_2 As Integer = 0
    Public ENEMIES_SPAWNED As Integer = -1
    Public TIME As Integer = 0
    Public LIVES() As Integer = {3, 3, 3, 3, 3}
    Public LEVEL As Integer = 1
    Public LIVES_2 As Integer = 3
    Public WAVE As Integer = 0
    Public DEBUG As Boolean = True
    Public INTERLUDE_START As Integer = -1
    Public DEATH_START As Integer = -1
    Public INTERLUDE_LENGTH As Integer = 250
    Public WAVE_SIZE As Decimal = 3
    Public FONT_SMALL = New Font("Castellar", 12)
    Public FONT = New Font("Algerian", 16)
    Public NUM_PLAYERS As Integer = 1
    Public Random As New Random()
    Public DISTANCE_TRAVELED As Integer = 0
    Public TRAVELING As Boolean = 0
    ''
    ''PLAYER 1 Uses Green
    Public brush_player1 = New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(15, 15), Color.Lime, Color.White)
    ''PLAYER 2 Uses Purple
    Public brush_player2 = New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(15, 15), Color.Purple, Color.White)
    ''LISTS OF THINGS FOR LATER
    Public Agents As New Microsoft.VisualBasic.Collection()
    Public Pickups As New Microsoft.VisualBasic.Collection()
    Public PLAYERS As New Microsoft.VisualBasic.Collection()
    Public ENEMIES As New Microsoft.VisualBasic.Collection()
    Public Parallax As New Microsoft.VisualBasic.Collection()

    ''
    Sub LoseLife(ByVal PlayerNum As Object)


        ''Kill the player and center him
        PlayerNum.Top = DEFAULT_HEIGHT / 2
        PlayerNum.Left = DEFAULT_WIDTH / 2
        PlayerNum.Hspeed = 0
        PlayerNum.Vspeed = 0
        PlayerNum.spawnedtime = Game.TIME

        ''Subtract lives, and remove player if he's super-dead
        LIVES(PlayerNum.player_num) -= 1
        If LIVES(PlayerNum.player_num) = 0 Then
            Game.PLAYERS.Remove(PlayerNum.Name)
            Game.Agents.Remove(PlayerNum.Name)
        End If

        My.Computer.Audio.Play(My.Resources.sfx_player_hit, AudioPlayMode.Background)

    End Sub

    Sub GetLife(PlayerNum)
        LIVES(PlayerNum) += 1
    End Sub

    Sub Start()
        WON = False
        DISTANCE_TRAVELED = 0
        ENEMIES_SPAWNED = 0
        ClearGame()
        LIVES = {0, 3, 3, 3, 3}
        TIME = 0
        WAVE = 0
        WAVE_SIZE = 1
        LEVEL = 1
        SCORE = 0
    End Sub

    Sub ClearGame()
        Agents.Clear()
        PLAYERS.Clear()
        Pickups.Clear()
        ENEMIES.Clear()
        Parallax.Clear()
        DEATH_START = -1
    End Sub

    Sub Wave_next()

        ''ENEMIES_SPAWNED = 0
        INTERLUDE_START = Game.TIME
        WAVE += 1
        WAVE_SIZE = Math.Round(WAVE_SIZE * 1.5)
        If WAVE >= 4 Then
            WAVE = 1
            LEVEL += 1
        End If

    End Sub

    Sub Win()
        WON = True
        CreditsScreen.Show()
        Form1.Close()
    End Sub

    Sub Lose()
        Form1.Close()
        ScoreScreen.Show()
        LIVES = {0, 3, 3, 3, 3}
    End Sub

    Sub GetScore(ByVal amount As Integer, ByVal x As Integer, ByVal y As Integer)
        If Not amount = 0 Then
            Dim rand = New Random()
            SCORE += amount
            Dim myself As New Particle(Game.TIME, x + rand.Next(20) - 10, y + rand.Next(20) - 10, amount.ToString)
            Form1.ParticleList.Add(myself, myself.Name)
            If amount < 0 Then myself.float_rate *= -1
            If SCORE < 0 Then SCORE = 0
        End If
    End Sub

End Module
