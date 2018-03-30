Module Game

    Public Const INVINCIBILITY_LENGTH As Integer = 60
    Public Const DISTANCE_TO_CASTLE = 1000

    Public SPAWNED_BLOCKS = False
    Public HUDBRUSH As New Drawing2D.LinearGradientBrush(New Point(0 + Game.TIME, 0 + Game.TIME), New Point(15 + Game.TIME, 15 + Game.TIME), Color.Gold, Color.Azure)
    Public WON = False
    Public BEEN_PLAYED = False
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
    Public INTERLUDE_LENGTH As Integer = 200
    Public WAVE_SIZE As Decimal = 3
    Public FONT_SMALL = New Font("Castellar", 12)
    Public FONT = New Font("Algerian", 16)
    Public NUM_PLAYERS As Integer = 1
    Public Random As New Random()
    Public DISTANCE_TRAVELED As Decimal = 0
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
    Public BarrierList As New Microsoft.VisualBasic.Collection()
    ''
    Public Function SplashText(ByRef time As Integer, mytext As String)
        Dim bob = New Particle(time, DEFAULT_WIDTH / 2, DEFAULT_HEIGHT / 2, mytext)
        bob.mybrush = Game.HUDBRUSH
        bob.Name = "SPLASH"
        bob.float_rate = 0
        If Form1.ParticleList.Contains("SPLASH") Then Form1.ParticleList.Remove("SPLASH")
        Form1.ParticleList.Add(bob, bob.Name)
        Return bob
    End Function

    Sub LoseLife(ByVal PlayerNum As Object)


       

        ''Subtract lives, and remove player if he's super-dead
        LIVES(PlayerNum.player_num) -= 1
        If LIVES(PlayerNum.player_num) = 0 Then
            ''Create a deathburst
            ''Dim burst As New prt_ring()
            ''Form1.ParticleList.Add(burst, "PLAYERDEATHBURST" + PlayerNum.name + Game.TIME.ToString)
            Game.PLAYERS.Remove(PlayerNum.Name)
            Game.Agents.Remove(PlayerNum.Name)
        End If


        ''Kill the player and center him
        PlayerNum.Top = DEFAULT_HEIGHT / 2
        PlayerNum.Left = DEFAULT_WIDTH / 2
        PlayerNum.Hspeed = 0
        PlayerNum.Vspeed = 0
        PlayerNum.spawnedtime = Game.TIME

        Sound.play_sfx(My.Resources.sfx_player_hit, 3)

    End Sub

    Sub GetLife(PlayerNum)
        LIVES(PlayerNum) += 1
    End Sub

    Sub Start()
        ClearGame()
        BEEN_PLAYED = True
        WON = False
        DISTANCE_TRAVELED = 0
        ENEMIES_SPAWNED = -1
        LIVES = {0, 3, 3, 3, 3}
        TIME = 0
        WAVE = 0
        WAVE_SIZE = 1
        LEVEL = 1
        SCORE = 0
    End Sub

    Sub ClearGame()
        SCORE = 0
        SPAWNED_BLOCKS = False
        Agents.Clear()
        PLAYERS.Clear()
        Pickups.Clear()
        ENEMIES.Clear()
        Parallax.Clear()
        BarrierList.Clear()
        DEATH_START = -1
        ENEMIES_SPAWNED = -1
        INTERLUDE_START = -1
        Sound.Reset()
    End Sub

    Sub Wave_next()


        INTERLUDE_START = Game.TIME
        WAVE += 1
        WAVE_SIZE = Math.Round(WAVE_SIZE * 1.5)
        If WAVE >= 4 Then
            Level_next()
        End If

    End Sub

    Sub Level_next()
        ''If BarrierList.Count > 0 Then BarrierList.Remove(BarrierList.Count)
        BarrierList.Clear()
        SplashText(TIME, "Moving towards the Castle!")
        SPAWNED_BLOCKS = False
        LEVEL += 1
        WAVE = 1
        WAVE_SIZE = Math.Round(WAVE_SIZE / 2)
        If LEVEL = 9 Then WAVE_SIZE = Math.Round(WAVE_SIZE / 2)

        ''Wave size reduced, as enemies become higher quality
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
            Dim myself As New Particle(Game.TIME, x + rand.Next(24) - 12, y + rand.Next(24) - 12, amount.ToString)
            Form1.ParticleList.Add(myself, myself.Name)
            If amount < 0 Then
                myself.float_rate *= -1
                myself.mybrush = Brushes.Red
            End If

            If SCORE < 0 Then SCORE = 0
        End If
    End Sub

    Sub BLOCKOUT_LEVEL()
        SPAWNED_BLOCKS = True
        Select Game.LEVEL
            Case 1
                Form1.Spawn_Barrier(DEFAULT_WIDTH / 4, DEFAULT_HEIGHT / 4)
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (3 / 4), DEFAULT_HEIGHT / 4)
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (3 / 4), DEFAULT_HEIGHT * (3 / 4))
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (1 / 4), DEFAULT_HEIGHT * (3 / 4))
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (1 / 2), DEFAULT_HEIGHT * (7 / 8))
            Case 2
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (1 / 6), DEFAULT_HEIGHT / 4)
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (5 / 6), DEFAULT_HEIGHT / 4)
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (1 / 2), DEFAULT_HEIGHT * (5 / 8))
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (3 / 4), DEFAULT_HEIGHT * (5 / 6))
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (1 / 4), DEFAULT_HEIGHT * (5 / 6))
            Case 3
                Form1.Spawn_Barrier(DEFAULT_WIDTH / 4, DEFAULT_HEIGHT / 4)
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (3 / 4), DEFAULT_HEIGHT / 4)
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (1 / 2), DEFAULT_HEIGHT * (3 / 4))
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (1 / 2), DEFAULT_HEIGHT * (1 / 4))
            Case 4
                Form1.Spawn_Barrier(DEFAULT_WIDTH / 4, DEFAULT_HEIGHT / 4)
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (3 / 4), DEFAULT_HEIGHT / 4)
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (1 / 2), DEFAULT_HEIGHT * (3 / 4))
            Case 5
                Form1.Spawn_Barrier(DEFAULT_WIDTH / 4, DEFAULT_HEIGHT * (3 / 4))
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (3 / 4), DEFAULT_HEIGHT * (3 / 4))
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (1 / 2), DEFAULT_HEIGHT * (1 / 4))
            Case 6
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (4 / 5), DEFAULT_HEIGHT * (3 / 4))
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (1 / 5), DEFAULT_HEIGHT * (3 / 4))
            Case 7
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (3 / 4), DEFAULT_HEIGHT * (3 / 4))
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (1 / 4), DEFAULT_HEIGHT * (3 / 4))
            Case 8
                Form1.Spawn_Barrier(DEFAULT_WIDTH * (1 / 2), DEFAULT_HEIGHT * (3 / 4))
            Case 9
                ''You get only death on wave 9.
            Case 10
                ''And now you win!
        End Select
    End Sub


End Module
