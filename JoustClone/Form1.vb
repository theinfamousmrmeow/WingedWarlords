''For GDI+ stuff
Imports System.Drawing.Drawing2D
''Imports Physics

Public Class Form1

    
    Dim SKY_BOTTOM = DEFAULT_HEIGHT * (5 / 12)
    Public VIEW_RATIO_WIDTH = 1
    Public VIEW_RATIO_HEIGHT = 1
    Public Const AI_floor = 480 * (7 / 8)

    Dim number_of_agents As Integer = 0

    Public ParticleList As New Microsoft.VisualBasic.Collection()

    ''Declare user controls
    ''Joystick2 exists even if its single player.
    Dim joystick1 As New Joystick()
    Dim joystick2 As New Joystick()
    ''In a single player game, the player accepts input from both 

    ''(misPic.Bounds.IntersectsWith(barPic.Bounds))
    Sub ScreenWrap(guy As Agent)
        Dim outside As Boolean = False

        If guy.Left > DEFAULT_WIDTH Then
            guy.Left = 0 - guy.Width + 1
            outside = True
        End If

        If guy.Right < 0 Then
            guy.Left = DEFAULT_WIDTH - 1
            outside = True
        End If

        ''If he went outside the room
        If outside Then
            ''Mounts and riders just leave the game
            If TypeOf guy Is Mount Or TypeOf guy Is Rider Then
                Destroy_Agent(guy)
            End If

        End If

    End Sub

    Function get_nearest_player(ByVal a As Agent) As Agent
        Dim target As Object
        Dim targetdist As Integer = 1000
        Dim dist As Integer = 0
        If Game.PLAYERS.Count > 0 Then target = Game.PLAYERS(1) Else  : target = a

        For Each player As Knight In Game.PLAYERS
            dist = Math.Abs(a.Left - player.Left)
            If dist < targetdist Then
                target = Game.PLAYERS(player.Name)
                targetdist = dist
            End If

        Next


        Return target

    End Function

 


    ''DESTROY A KNIGHT/MOUNT/RIDER
    Sub Destroy_Agent(ByRef agent As Object)


        ''IF AN ENEMY DIED
        If IsPlayer(agent) = False Then
            ''If he doesn't have the sword, then let the rider be unhorsed
            ''If he has the sword, kill horse and rider in one blow
            '' If Game.Agents(1).has_sword = False Then
            If TypeOf agent Is Knight Then
                Dim b = Spawning.Spawn_Rider(agent.Left + agent.Width / 2, agent.Top + agent.Height / 2)
                b.Hspeed = agent.Hspeed / 2
                b.Vspeed = agent.Vspeed / 2
                b.palette = agent.palette
                Dim bob As Mount
                bob = Spawning.Spawn_Mount(agent.Left, agent.Top)
                bob.INPUT_x = agent.INPUT_x
                bob.Hspeed = agent.Hspeed
                bob.palette = agent.palette
                bob.Vspeed = agent.Vspeed
                ''End If
                ''Play the knight death sound
                Sound.play_sfx(My.Resources.sfx_impale_enemy, 1)
            End If

            ''Get some points depending on type
            Dim scoreworth As Integer = 0
            If TypeOf agent Is Mount Then scoreworth = 0
            If TypeOf agent Is Knight Then scoreworth = 50 * (agent.Skill + 1)
            If TypeOf agent Is Rider Then scoreworth = 100
            ''If he falls out of the game, you get no points
            If agent.Top >= DEFAULT_HEIGHT Then scoreworth = 0
            Game.GetScore(scoreworth, agent.Left, agent.Top)
            ''Remove from agent collection
            Game.Agents.Remove(agent.Name)
            If Game.ENEMIES.Contains(agent.Name) Then Game.ENEMIES.Remove(agent.Name)
            ''Derefence the Agent
            agent = Nothing

            ''IF A PLAYER DIED
        Else
            Game.GetScore(-100, agent.Top, agent.Left)
            Game.LoseLife(agent)
            agent.Top = DEFAULT_HEIGHT / 2
            agent.Left = DEFAULT_WIDTH / 2
            agent.Hspeed = 0
            agent.Vspeed = 0
            agent.spawnedtime = Game.TIME

        End If

    End Sub

    Function list_getindex(list As Collection, obj As Agent)
        Dim pos As Integer = -1
        For i As Integer = 1 To list.Count
            If list(i).Equals(obj) Then pos = i
        Next
        Return pos
    End Function

    Sub Spawn_Barrier(ByVal x As Integer, ByVal y As Integer)

        Dim b As New Barrier()
        b.Left = x - b.Width / 2
        b.Top = y - b.Height / 2

        ''Me.Controls.Add(b)
        Game.BarrierList.Add(b)

    End Sub



    Function IsPlayer(agent As Agent)

        Dim check As Boolean = False

        If Game.PLAYERS.Contains(agent.Name) Then check = True

        Return check

    End Function

    Sub MOVE_PLAYERS()
        ''Player 1 Controls
        If LIVES(1) > 0 Then MoveAgent(Game.PLAYERS(1), joystick1)

        ''Player 2 Controls
        If Game.NUM_PLAYERS = 2 And LIVES(2) > 0 And LIVES(1) > 0 Then MoveAgent(Game.PLAYERS(2), joystick2)
        If Game.NUM_PLAYERS = 2 And LIVES(2) > 0 And LIVES(1) = 0 Then MoveAgent(Game.PLAYERS(1), joystick2)
    End Sub

    Sub Physics(things As Collection)

        ''Update sprites
        For Each Knight As Agent In things
            If TypeOf Knight Is Knight Then
                If Knight.OnGround = False Then
                    If Knight.Vspeed < 0 Then
                        Knight.Image = My.Resources.rider_up
                    Else : Knight.Image = My.Resources.rider_down
                    End If
                    If Knight.dive = True Then Knight.Image = My.Resources.rider_dive
                    If Knight.facing < 0 And Knight.Hspeed > 0 Then Knight.Image = My.Resources.rider_turn
                    If Knight.facing > 0 And Knight.Hspeed < 0 Then Knight.Image = My.Resources.rider_turn

                Else
                    Knight.Image = My.Resources.Resources.rider_stand
                End If
            End If
            ''Rider Sprites
            If TypeOf Knight Is Rider Then
                If Knight.Vspeed > 0 Then
                    Knight.Image = My.Resources.knight_fall
                End If
                If Knight.Vspeed = 0 Then
                    Knight.Image = My.Resources.knight_dismount
                End If
            End If
        Next
        ''END PLAYER SECTION

        For Each guy As Agent In things

            ''Make sure Riders don't fall too fast
            If TypeOf guy Is Rider Then
                If guy.Vspeed > 1 Then guy.Vspeed = 1
            End If

            ''Apply Gravity
            guy.Vspeed += PHY_gravity
            ''Apply friction to horizontal moves
            ''Moving Right
            If guy.Hspeed > 0 Then
                guy.Hspeed -= (PHY_friction - (guy.OnGround * 0.05))
                If guy.Hspeed < 0 Then guy.Hspeed = 0
            End If
            ''Moving Left
            If guy.Hspeed < 0 Then
                guy.Hspeed += (PHY_friction - (guy.OnGround * 0.05))
                If guy.Hspeed > 0 Then guy.Hspeed = 0
            End If
            ''Make sure he doesn't fall too fast
            If guy.Vspeed > PHY_terminal_velocity - (guy.dive * 1) Then guy.Vspeed = PHY_terminal_velocity - (guy.dive * 1)
            ''Stop him flying too far up
            If guy.Top < PHY_ceiling Then
                guy.Top = PHY_ceiling
                If guy.Vspeed < 0 Then guy.Vspeed = 0
            End If

            ''Wrap left and right
            ScreenWrap(guy)

            ''
            Dim lastx = guy.Left
            Dim lasty = guy.Top

            ''Update Position
            guy.Left += guy.Hspeed
            guy.Top += guy.Vspeed

            ''Force Screen update
            If Not guy.Left = lastx Then
                Me.Invalidate()
            ElseIf Not guy.Top = lasty Then
                Me.Invalidate()
            End If

            ''Hit Walls
            For Each barrier As Barrier In Game.BarrierList
                ''Make sure what we're looking at is a barrier
                If barrier.Name = "Barrier" Then
                    ''Check for physical collisions
                    hit_barrier(guy, barrier)
                End If
            Next
            ''See if he's on the ground
            ''If he's considered to be on the ground yet,
            ''Check to see if he is now
            Dim changed As Boolean = guy.OnGround
            guy.OnGround = Not position_free(BarrierList, guy.Left + guy.Width / 2, guy.Bottom, guy.Width)
            If Not guy.OnGround = changed And changed = False And IsPlayer(guy) Then Sound.play_sfx(My.Resources.sfx_land, -1)

            ''Fall off bottom and die.  Has to be last thing called, as it might
            ''Dereference the object
            If guy.Top > DEFAULT_HEIGHT Then
                If TypeOf guy Is Mount Or TypeOf guy Is Rider Then
                    Destroy_Agent(guy)
                Else : Destroy_Agent(guy)
                End If


            End If

        Next
    End Sub

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        Spawn_Knight(MousePosition.X, MousePosition.Y)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Button1.Focus()

        ''DEBUG
        If Game.DISTANCE_TRAVELED < Game.LEVEL * 100 Then
            Game.DISTANCE_TRAVELED += 0.5
            Me.Invalidate()
        End If
        ''DEBUG
        ''WIN THE GAME
        If Game.DISTANCE_TRAVELED >= Game.DISTANCE_TO_CASTLE Then
            Game.Win()
        End If

        ''Spawn the blocks if we are done moving
        If Game.DISTANCE_TRAVELED = Game.LEVEL * 100 And Game.SPAWNED_BLOCKS = False Then
            Game.BLOCKOUT_LEVEL()
        End If


        ''Check for end of wave
        If Game.ENEMIES.Count = 0 And Game.INTERLUDE_START = -1 And Game.ENEMIES_SPAWNED = -1 Then

            Game.Wave_next()
            If Game.NUM_PLAYERS = 1 Then Game.SplashText(Game.TIME, "PREPARE THYSELF")
            If Game.NUM_PLAYERS = 2 Then Game.SplashText(Game.TIME, "PREPARE THYSELVES")
            If WAVE = 1 Then Game.SplashText(Game.TIME, "FLYING O'ER TO YON CASTLE")


        End If
        ''CHECK FOR PLAYERS DEAD
        If Game.PLAYERS.Count = 0 And Game.DEATH_START = -1 Then
            Dim myself As Particle
            Game.DEATH_START = Game.TIME
            If Game.NUM_PLAYERS = 1 Then myself = Game.SplashText(Game.TIME, "THY LIFE IS SPENT")
            If Game.NUM_PLAYERS > 1 Then myself = Game.SplashText(Game.TIME, "THY LIVES ARE SPENT")
            Sound.play_sfx(My.Resources.sfx_losegame, 10)


        End If

        ''CHECK THE PLAYERS FOR PICKUP GRABS
        ''If there are Pickups to grab
        If Game.Pickups.Count > 0 Then
            For Each Player As Knight In Game.PLAYERS
                For Each Pickup As Agent In Game.Pickups
                    ''If its able to be picked up right now
                    If Pickup.spawnedtime + Game.INVINCIBILITY_LENGTH < Game.TIME Then
                        ''If its touching the player
                        If Pickup.Bounds.IntersectsWith(Player.Bounds) Then
                            ''DO A PICKUP COLLISION
                            Game.GetScore(100, Player.Left, Player.Top)
                            Game.Pickups.Remove(Pickup.Name)
                            If Game.Agents.Contains(Pickup.Name) Then Game.Agents.Remove(Pickup.Name)
                        End If
                    End If
                Next
            Next
        End If
        ''Check the players for JOUST collisions
        For Each player As Agent In Game.PLAYERS
            ''Get each player in the List

            ''If the agent in the loop is a player, run a loop checking
            ''all the other agents for potential collisions
            For Each enemy As Agent In Game.ENEMIES

                If TypeOf enemy Is Knight Then

                    ''If both Agents can have a collision, and they did indeed collide
                    If Game.TIME > enemy.spawnedtime + Game.INVINCIBILITY_LENGTH And Game.TIME > player.spawnedtime + Game.INVINCIBILITY_LENGTH And agents_collide(enemy, player) Then
                        ''If there is a collision with player
                        ''Check to see if the Player won
                        If enemy.Top > player.Top + 10 Then
                            ''If the player won, kill enemy
                            Destroy_Agent(enemy)
                        ElseIf player.Top > enemy.Top + 10 Then
                            ''If the enemy won, kill player
                            Destroy_Agent(player)
                        Else
                            ''It there was no winner, do a Parry
                            Sound.play_sfx(My.Resources.sfx_parry, 2)
                            ''BOUNCES AWAY PROPERLY NOW
                            If player.Left < enemy.Left And player.Hspeed > 0 Then
                                player.Hspeed *= -1
                                enemy.Hspeed = player.Hspeed * -1
                            elseIf player.Left > enemy.Left And player.Hspeed < 0 Then
                                player.Hspeed *= -1
                                enemy.Hspeed = player.Hspeed * -1
                            Else
                                player.Hspeed *= 1.1
                                enemy.Hspeed = player.Hspeed * -1
                            End If
                        '' player.Hspeed *= -(1) ''Bounce off, and halve the speed
                        '' enemy.Hspeed = player.Hspeed * -1 ''Grant that impact speed to guy he hit
                        End If
                        ''End of collision with player
                    End If
                    ''Riders always lose to knights

                    If TypeOf enemy Is Rider Then
                        If enemy.Vspeed > 1 Then enemy.Vspeed = 1
                        If Game.TIME > enemy.spawnedtime + Game.INVINCIBILITY_LENGTH And agents_collide(enemy, player) Then
                            Destroy_Agent(enemy)
                        End If

                    End If

                End If
            Next


        Next


        ''MOVEMENT
        For Each enemy As Agent In Game.ENEMIES

            ''AI movements
            ''Everyone can move on the ground, or if the air if they can fly
            If enemy.OnGround = True Or enemy.flap_speed > 0 Then
                MoveAgent(enemy, enemy.facing, enemy.INPUT_y)
                ''UNSKILLED MOVEMENT, JUST RANDOM
                If enemy.skill = 0 Then
                    If Game.Random.Next(20) = 19 Then
                        If Not TypeOf enemy Is Mount Then enemy.facing *= -1
                    End If
                    ''Weight it to jump the lower he is
                    If enemy.Bottom > DEFAULT_HEIGHT Then enemy.Top = DEFAULT_HEIGHT - enemy.Height
                    If enemy.Vspeed >= 0 And Game.Random.Next(35 - (Math.Round(((enemy.Bottom / DEFAULT_HEIGHT) * 30) - enemy.skill / 2))) = 1 Then
                        enemy.INPUT_y = -1
                    Else : enemy.INPUT_y = 0
                    End If
                End If
                ''End of UNSKILLED MOVEMENT
                ''SKILLED MOVEMENT
                If enemy.skill > 0 Then
                    Dim myenemy = get_nearest_player(enemy)
                    If Game.Random.Next(10 - enemy.skill) = 2 Then
                        If myenemy.Left < enemy.Left Then enemy.facing = -1 Else enemy.facing = 1
                    End If
                    ''Weight it to jump the lower he is
                    If enemy.Vspeed >= 0 And Game.Random.Next(35 - (Math.Round((enemy.Bottom / DEFAULT_HEIGHT) * 30))) = 1 Then
                        enemy.INPUT_y = -1
                    Else : enemy.INPUT_y = 0
                    End If
                End If
            End If
        Next
        ''Update physics
        MOVE_PLAYERS()
        Physics(Game.Agents)
        ''Physics(Game.Pickups)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Dim bob = New ParallaxObject(My.Resources.castle)
        bob.x_factor = 0
        bob.Z = DISTANCE_TO_CASTLE + 10
        bob.Scale = 2
        Game.Parallax.Add(bob, "Castle")

        Dim i As Integer = 0
        Dim mydist As Integer = 999
        Do Until i = 10
            i += 1
            bob = New ParallaxObject(My.Resources.crag)
            bob.Z = mydist
            mydist -= 99
            Game.Parallax.Add(bob, "Scenery" + i.ToString)
        Loop
        ''Make me some clouds
        ''These are super cool but will just take too long to implement now
        'i = 0
        'mydist = 500
        'Do Until i = 8
        '    i += 1
        '    bob = New ParallaxObject(My.Resources.clouds, -1 * Game.Random.Next(2) / 2)
        '    bob.Z = mydist
        '    bob.Scale = 0.8
        '    mydist -= 200
        '    Game.Parallax.Add(bob, "Clouds" + i.ToString)
        'Loop

        Me.Width = 640
        Me.Height = 480

        Dim player As Agent
        Button1.Focus()

        ''Create the player
        player = Spawning.Spawn_Player(ClientRectangle.Width / 2, ClientRectangle.Height / 4)
        player.Image = My.Resources.Resources.rider_stand
        player.has_sword = False
        ''Spawn Player2
        If Game.NUM_PLAYERS = 2 Then
            player = Spawning.Spawn_Player(ClientRectangle.Width / 2 + 30, ClientRectangle.Height / 4)
            player.palette = Palettes.playertwo
            player.Image = My.Resources.Resources.rider_stand
            player.has_sword = False
        End If

        If My.Settings.fullscreen = True Then Me.WindowState = FormWindowState.Maximized

    End Sub

    ''User Input
    ''Pressing Keys

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress, Button1.KeyPress

        ''PLAYER 1
        If e.KeyChar = "W" Or e.KeyChar = "w" Then
            joystick1.INPUT_ydir = -1
        End If
        ''PLAYER 2
        If e.KeyChar = "8" Or e.KeyChar = "u" Then
            joystick2.INPUT_ydir = -1
        End If

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, Button1.KeyDown
        ''PLAYER 1
        If e.KeyCode = Keys.A Then
            joystick1.INPUT_xdir = -1
        End If
        If e.KeyCode = Keys.D Then
            joystick1.INPUT_xdir = 1
        End If
        If e.KeyCode = Keys.S Then
            joystick1.INPUT_ydir = 1
        End If
        ''PLAYER 2
        If e.KeyCode = Keys.NumPad4 Then
            joystick2.INPUT_xdir = -1
        End If
        If e.KeyCode = Keys.NumPad6 Then
            joystick2.INPUT_xdir = 1
        End If
        If e.KeyCode = Keys.NumPad5 Then
            joystick2.INPUT_ydir = 1
        End If

        ''Check here for escape keya
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        ''Cheat code to kill all enemies on screen
        If e.KeyCode = Keys.Delete Then
            For Each Agent As Agent In Game.ENEMIES
                Game.ENEMIES.Remove(Agent.Name)
                Game.Agents.Remove(Agent.Name)
            Next
        End If

    End Sub

    ''Releasing Keys

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp, Button1.KeyUp
        ''PLAYER 1 BUTTON RELEASE
        Select Case e.KeyCode
            Case Keys.W : If joystick1.INPUT_ydir = -1 Then
                    joystick1.INPUT_ydir = 0
                    joystick1.up_pressed = False
                End If
            Case Keys.A : If joystick1.INPUT_xdir = -1 Then joystick1.INPUT_xdir = 0
            Case Keys.S : If joystick1.INPUT_ydir = 1 Then joystick1.INPUT_ydir = 0
            Case Keys.D : If joystick1.INPUT_xdir = 1 Then joystick1.INPUT_xdir = 0
        End Select

        ''PLAYER 2 BUTTON RELEASE
        Select Case e.KeyCode
            Case Keys.NumPad8 : If joystick2.INPUT_ydir = -1 Then
                    joystick2.INPUT_ydir = 0
                    joystick2.up_pressed = False
                End If
            Case Keys.NumPad4 : If joystick2.INPUT_xdir = -1 Then joystick2.INPUT_xdir = 0
            Case Keys.NumPad5 : If joystick2.INPUT_ydir = 1 Then joystick2.INPUT_ydir = 0
            Case Keys.NumPad6 : If joystick2.INPUT_xdir = 1 Then joystick2.INPUT_xdir = 0
        End Select


    End Sub
    ''Move an agent using a Joystick
    Private Sub MoveAgent(ByVal Hero As Agent, ByVal controller As Joystick)

        Hero.move_accel(controller.INPUT_xdir)
        If controller.INPUT_ydir = 1 Then
            Hero.Vspeed += 0.5
        End If
        If controller.INPUT_ydir = -1 And controller.up_pressed = False Then
            Hero.Jump(Hero)
            controller.up_pressed = True
        End If
        If controller.INPUT_ydir = 1 Then Hero.dive = True Else Hero.dive = False


    End Sub
    ''Move an agent with AI values
    Private Sub MoveAgent(ByVal Hero As Agent, ByVal xdir As Integer, ByVal ydir As Integer)

        Hero.move_accel(xdir)
        If ydir = -1 Then
            Hero.Jump(Hero)
        End If


    End Sub


    ''Drawing

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

        Game.HUDBRUSH = New Drawing2D.LinearGradientBrush(New Point(0 + Game.TIME Mod 30, 0), New Point(15 + Game.TIME Mod 30, 15), Color.Gold, Color.Azure)
        ''This scales what you're seeing.
        e.Graphics.ScaleTransform(VIEW_RATIO_WIDTH, VIEW_RATIO_HEIGHT)
        ''INterpolation is bad for pixel-art
        e.Graphics.InterpolationMode = InterpolationMode.Low

        ''Draw the background
        Dim horizonpen = Pens.Red
        ''Draw Create Sea and Sky
        Dim sky = New Rectangle(0, 0, DEFAULT_WIDTH, SKY_BOTTOM)
        Dim sea = New Rectangle(0, SKY_BOTTOM, DEFAULT_WIDTH, DEFAULT_HEIGHT)
        'NEW SKYDRAW
        Dim band_height As Integer = 8
        Dim alternate_bands As Integer = 1
        Dim cur_y As Integer = SKY_BOTTOM
        Do Until band_height = 0
            Dim myrect As New Rectangle(0, cur_y - band_height, DEFAULT_WIDTH, band_height)
            cur_y -= band_height
            e.Graphics.FillRectangle(Brushes.DarkMagenta, myrect)
            ''
            myrect = New Rectangle(0, cur_y - alternate_bands, DEFAULT_WIDTH, alternate_bands)
            cur_y -= alternate_bands
            e.Graphics.FillRectangle(Brushes.DarkSlateBlue, myrect)
            alternate_bands += 1
            band_height -= 1
        Loop
        ''Draw the rest of the sky
        Dim myrect2 As Rectangle
        myrect2 = New Rectangle(0, 0, DEFAULT_WIDTH, cur_y)
        e.Graphics.FillRectangle(Brushes.DarkSlateBlue, myrect2)
        ''
        'NEW SEADRAW
        band_height = 8
        alternate_bands = 1
        cur_y = SKY_BOTTOM
        Do Until band_height = 0
            Dim myrect As New Rectangle(0, cur_y, DEFAULT_WIDTH, band_height)
            cur_y += band_height
            e.Graphics.FillRectangle(Brushes.MidnightBlue, myrect)
            ''
            myrect = New Rectangle(0, cur_y, DEFAULT_WIDTH, alternate_bands)
            cur_y += alternate_bands
            e.Graphics.FillRectangle(Brushes.Navy, myrect)
            alternate_bands += 1
            band_height -= 1
        Loop
        ''Draw the rest of the sky
        myrect2 = New Rectangle(0, cur_y, DEFAULT_WIDTH, DEFAULT_HEIGHT - cur_y)
        e.Graphics.FillRectangle(Brushes.Navy, myrect2)
        ''DRAWING THE PARALLAX OBJECTS
        For Each scenery As ParallaxObject In Game.Parallax
            ''Draw the Sea-Crags on the way there
            Dim distance_to_me As Integer = scenery.Z - Game.DISTANCE_TRAVELED

            Dim obj_scale As Decimal = ((Game.DISTANCE_TO_CASTLE - distance_to_me) / 1000) * scenery.Scale
            If distance_to_me = -1 Then obj_scale = 0
            If obj_scale < 0 Then obj_scale = 0
            Dim x_offset As Integer = DEFAULT_WIDTH / 2 + ((Game.DISTANCE_TO_CASTLE - distance_to_me) / 900) * DEFAULT_WIDTH / 2 * scenery.x_factor
            Dim y_offset As Integer = SKY_BOTTOM + (((Game.DISTANCE_TO_CASTLE - distance_to_me) / 900) * (DEFAULT_HEIGHT - SKY_BOTTOM) / 4) * scenery.y_flip

            obj_scale += 0.1
            Dim castle_width As Decimal = scenery.Width * obj_scale
            Dim castle_height As Decimal = scenery.Height * obj_scale
            e.Graphics.DrawImage(scenery.Image, x_offset - castle_width / 2, y_offset - castle_height, castle_width, castle_height)
            If scenery.y_flip = 1 Then e.Graphics.DrawLine(Pens.Teal, New Point(x_offset - castle_width / 1.75, y_offset + 1), New Point(x_offset + castle_width / 1.75, y_offset + 1))

        Next
        ''
        Dim gradbrush = New LinearGradientBrush(New Point(0, 0), New Point(15, 15), Color.Gold, Color.White)
        Dim HUDfont = New Font("Arial", 8)
        e.Graphics.TextContrast() = 1

        ''Draw the lives counter
        e.Graphics.DrawString(Game.LEVEL.ToString + "-" + Game.WAVE.ToString, Game.FONT, Game.HUDBRUSH, New Point(DEFAULT_WIDTH / 2 - 16, DEFAULT_HEIGHT - 48))
        e.Graphics.DrawString("Score: " & Game.SCORE.ToString, Game.FONT, Game.HUDBRUSH, New Point(DEFAULT_WIDTH / 2 - 64, DEFAULT_HEIGHT - 24))
        e.Graphics.DrawString("Lives: ", Game.FONT, Game.brush_player1, New Point(10, DEFAULT_HEIGHT - 24))
        For xx As Integer = 1 To Game.LIVES(1) Step 1
            e.Graphics.DrawImage(My.Resources.helmets, 64 + xx * 18, DEFAULT_HEIGHT - 24)
        Next
        ''Draw the lives counter for player 2
        If Game.NUM_PLAYERS = 2 Then
            e.Graphics.DrawString("Lives: ", Game.FONT, Game.brush_player2, New Point(10, DEFAULT_HEIGHT - 56))
            For xx As Integer = 1 To Game.LIVES(2) Step 1
                ''Palette shift the helmets SON
                '' e.Graphics.DrawImage(My.Resources.helmets, 64 + xx * 18, DEFAULT_HEIGHT - 64)

                Dim att = New System.Drawing.Imaging.ImageAttributes()
                att.SetColorMatrix(Palettes.playertwo)
                e.Graphics.DrawImage(My.Resources.helmets, New Rectangle(64 + xx * 18, DEFAULT_HEIGHT - 56, My.Resources.helmets.Width, My.Resources.helmets.Height), 0, 0, My.Resources.helmets.Height, My.Resources.helmets.Width, GraphicsUnit.Pixel, att)




            Next
        End If
        ''DRAW ALL THE AGENTS
        'DEBUG

        ''DRAW A BUBBLE ON THE PICKUPS
        For Each a As Object In Game.Pickups

            ''Draw a bubble
            Dim gradbrush2 = New LinearGradientBrush(New Point(0, 0), New Point(16, 16), Color.Aqua, Color.Fuchsia)
            Dim apen = New Pen(gradbrush2)
            apen.Width = 2
            apen.DashStyle = DashStyle.Dash
            apen.DashCap = DashCap.Triangle
            e.Graphics.DrawEllipse(apen, a.Left, a.Top, a.Width, a.Height)

        Next

        For Each a As Agent In Game.Agents

            If a.spawnedtime + Game.INVINCIBILITY_LENGTH > Game.TIME Then
                If Game.TIME Mod 2 = 0 Then a.Visible = False Else a.Visible = True
            End If

            If a.spawnedtime + Game.INVINCIBILITY_LENGTH < Game.TIME Then a.Visible = True

            If (a.Visible = False Or a.Shielded = True) And IsPlayer(a) Then
                ''Draw a protector bubble thing
                Dim gradbrush2 = New LinearGradientBrush(New Point(0, 0), New Point(16, 16), Color.Goldenrod, Color.AliceBlue)
                Dim apen = New Pen(gradbrush2)
                apen.Width = 2
                apen.DashStyle = DashStyle.Dot
                apen.DashCap = DashCap.Round
                e.Graphics.DrawEllipse(apen, a.Left, a.Top, a.Width, a.Height)
            End If



            ''Drawing the Sprite
            ''Now with palette swapping SON
            If a.Visible Or a.Visible = False And IsPlayer(a) Then
                Dim offset As Integer = 0
                If a.facing = -1 Then offset = a.Width
                Dim att As New System.Drawing.Imaging.ImageAttributes()
                att.SetColorMatrix(a.palette)
                If a.Visible = False Then att.SetColorMatrix(Palettes.whiteout)
                e.Graphics.DrawImage(a.Image, New Rectangle(a.Left + offset, a.Top, a.Width * a.facing, a.Height), 0, 0, a.Image.Width, a.Image.Height, GraphicsUnit.Pixel, att)

            End If

        Next

        ''Drawing all the walls
        For Each a As Barrier In BarrierList
            Dim gradpen = New LinearGradientBrush(New Point(0, 0), New Point(32, 16), Color.BlanchedAlmond, Color.AliceBlue)
            Dim apen = New Pen(gradbrush)
            apen.Width = 2
            ''Dim hatchbrush = New System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.ZigZag, Color.Red, Color.Blue)
            apen.DashStyle = DashStyle.Solid
            apen.LineJoin = LineJoin.Bevel
            ''e.Graphics.DrawRectangle(apen, a.Bounds)
            e.Graphics.FillRectangle(gradpen, a.Bounds)
        Next

        ''Drawing all the Particle Effects
        For Each a As Particle In Me.ParticleList
            If TypeOf a Is prt_ring Then
                Dim rad As Integer = Game.TIME - a.spawn_time
                Dim arect As New Rectangle(a.Left - rad / 2, a.Top - rad / 2, rad, rad)
                e.Graphics.DrawEllipse(Pens.Azure, arect)
            End If
            If a.Name = "SPLASH" Then e.Graphics.DrawString(a.Text, Game.FONT_SMALL, Game.HUDBRUSH, New Point(a.Left, a.Top))
            If Not a.Name = "SPLASH" Then e.Graphics.DrawString(a.Text, Game.FONT_SMALL, a.mybrush, New Point(a.Left, a.Top))
        Next

    End Sub

    Private Sub tmrGlobal_Tick(sender As Object, e As EventArgs) Handles tmrGlobal.Tick

        ''EVERYONE IS DEAD

        If Game.DEATH_START > 0 And Game.DEATH_START + Game.INTERLUDE_LENGTH < Game.TIME Then
            Game.Lose()
        End If


        ''Spawn enough enemies
        If Game.ENEMIES_SPAWNED <= Game.WAVE_SIZE And Not Game.ENEMIES_SPAWNED < 0 And Game.TIME > 20 Then

            Game.ENEMIES_SPAWNED += 1
            Dim type_to_spawn As String = "Knave"
            ''After level 1, the last guy to spawn is a KNIGHT
            If Game.ENEMIES_SPAWNED = Game.WAVE_SIZE And Game.LEVEL > 1 Then type_to_spawn = "Knight"
            ''After level 5 half of the guys spawned are KNIGHTS
            If Game.ENEMIES_SPAWNED > Game.WAVE_SIZE / 2 And Game.LEVEL >= 5 Then type_to_spawn = "Knight"
            ''After level 3, the last guy spawned is a BARON
            If Game.ENEMIES_SPAWNED = Game.WAVE_SIZE And Game.LEVEL >= 3 Then type_to_spawn = "Baron"
            ''Level 9 ALL DAY
            If Game.LEVEL >= 9 Then type_to_spawn = "Knightmare"

            If type_to_spawn = "Knave" Then Spawn_Knight(DEFAULT_WIDTH / 2, DEFAULT_HEIGHT / 2)
            If type_to_spawn = "Knight" Then Spawn_Elite(DEFAULT_WIDTH / 2, DEFAULT_HEIGHT / 2)
            If type_to_spawn = "Baron" Then Spawn_Champion(DEFAULT_WIDTH / 2, DEFAULT_HEIGHT / 2)
            If type_to_spawn = "Knightmare" Then Spawn_Nightmare(DEFAULT_WIDTH / 2, DEFAULT_HEIGHT / 2)

            ''If we've spawned enough, stop spawning
            If Game.ENEMIES_SPAWNED = Game.WAVE_SIZE Then Game.ENEMIES_SPAWNED = -1

        End If

            ''Use this for global animation and timers and shit
            Game.TIME += 1
            ''Start the next wave
        If Game.INTERLUDE_START > 0 And Game.INTERLUDE_START + Game.INTERLUDE_LENGTH < Game.TIME Then
            Game.SplashText(Game.TIME, "LEVEL " + Game.LEVEL.ToString + " - " + Game.WAVE.ToString + ", " + Game.WAVE_SIZE.ToString + " foes approach!")
            ''Toggle the interlude to off
            Game.INTERLUDE_START = -1
            ''Begin Spawning Enemies
            Game.ENEMIES_SPAWNED = 0
        End If
            ''Clean up Pop-Up scores that need to leave now
            For Each lab As Particle In ParticleList

            lab.Top -= lab.float_rate
            If Game.TIME > lab.spawn_time + lab.exists_length Then
                ParticleList.Remove(lab.Name)
                Me.Controls.Remove(lab)
                ''Derefence the label
                lab = Nothing
            End If

        Next
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ''Resizes teh game window
        VIEW_RATIO_HEIGHT = ClientRectangle.Height / DEFAULT_HEIGHT
        VIEW_RATIO_WIDTH = ClientRectangle.Width / DEFAULT_WIDTH
    End Sub
End Class
