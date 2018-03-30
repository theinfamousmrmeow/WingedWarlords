Module Physics

    ''Physics Constants
    Public Const PHY_gravity As Decimal = 0.05 ''was 0.05
    Public Const PHY_friction As Decimal = 0.01 ''Was 0.01
    Public Const PHY_terminal_velocity As Decimal = 2 ''Was 3
    Public Const PHY_ceiling = 0

    ''CHECK TO SEE IF TWO AGENTS ARE TOUCHING
    Public Function agents_collide(one As Agent, two As Agent)
        Dim rect As New Rectangle(one.Left, one.Top, one.Width, one.Height)
        Dim rect2 As New Rectangle(two.Left, two.Top, two.Width, two.Height)
        If rect.IntersectsWith(rect2) Then
            Return True
        Else : Return False
        End If
    End Function
    ''CHECK TO SEE IF AN AGENT IS TOUCHING A BARRIER
    Public Function check_collide(one As Agent, two As Barrier)
        Dim rect As New Rectangle(one.Left, one.Top, one.Right, one.Bottom)
        If rect.IntersectsWith(two.Bounds) Then
            Return True
        Else : Return False
        End If
    End Function
    ''CHECK AT A SPECIFIC LOCATION
    Public Function position_free(b As Collection, x As Integer, y As Integer, width As Integer) As Boolean
        ''The position is free until proven otherwise
        Dim check As Boolean = True
        Dim recta As New Rectangle(x - width / 2, y, width / 2, 1)
        ''Check against the collection it gave
        For Each barrier As Barrier In b
            ''If he already detected a barrier, no need to check the rest of them
            If Not check = False Then
                ''Check the rectangle we created earlier against the current barrier
                If recta.IntersectsWith(barrier.Bounds) Then
                    check = False ''The position is not free
                    ''Play the landing sound effect
                    ''My.Computer.Audio.Play(My.Resources.sfx_land, AudioPlayMode.Background)
                End If
            End If
        Next
        ''Return our results
        '' false = not free, there's a barrier there
        '' true = free, no barriers
        Return check
    End Function


    Sub move_outside_other2(c As Agent, w As Object)

        If c.Bounds.IntersectsWith(w.Bounds) Then

            ''Moves the Collidee (C) until it is outside of the
            ''Wall (w)

            Dim x_dir As Integer = 0
            Dim y_dir As Integer = 0

            ''
            Dim a_c_x As Integer = c.Left + c.Width / 2
            Dim a_c_y As Integer = c.Top + c.Height / 2
            ''
            Dim w_c_x As Integer = w.Left + c.Width / 2
            Dim w_c_y As Integer = w.Top + w.Height / 2

            If a_c_x > w_c_x And c.Hspeed < 0 Then x_dir = 1 ''Hit from right side mostly
            If a_c_x < w_c_x And c.Hspeed > 0 Then x_dir = -1 ''Hit from left side mostly
            If a_c_y < w_c_y And c.Vspeed < 0 Then y_dir = -1 '' hit from above mostly
            If a_c_y > w_c_y And c.Vspeed > 0 Then y_dir = 1 '' hit from below mostly

            If x_dir = 1 Then
                ''Move right until he's not inside the box
                Do While c.Left < w.Right
                    c.Left += 1
                Loop
            End If
            If x_dir = -1 Then
                ''Move left until he's not inside the box
                Do While c.Right < w.Left
                    c.Left -= 1
                Loop
            End If
            If c.Bounds.IntersectsWith(w.Bounds) Then
                If y_dir > 0 Then
                    ''Move DOWN until outside the box
                    Do While c.Top < w.Bottom
                        c.Top += 1
                    Loop
                End If
                If y_dir < 0 Then
                    ''Move UP until he's not inside the box
                    Do While c.Bottom < w.Top
                        c.Top -= 1
                    Loop
                End If
            End If
        End If

    End Sub

    Sub move_outside_other(c As Agent, w As Object)

        If c.Bounds.IntersectsWith(w.Bounds) Then

            ''Moves the Collidee (C) until it is outside of the
            ''Wall (w)

            Dim x_dir As Integer = 0
            Dim y_dir As Integer = 0

            ''
            Dim a_c_x As Integer = c.Left + c.Width / 2
            Dim a_c_y As Integer = c.Top + c.Height / 2
            ''
            Dim w_c_x As Integer = w.Left + c.Width / 2
            Dim w_c_y As Integer = w.Top + w.Height / 2

            If a_c_x > w_c_x Then x_dir = 1 ''Hit from right side mostly
            If a_c_x < w_c_x Then x_dir = -1 ''Hit from left side mostly
            If a_c_y < w_c_y Then y_dir = -1 '' hit from above mostly
            If a_c_y > w_c_y Then y_dir = 1 '' hit from below mostly

            x_dir = -1

            If x_dir > 0 Then
                ''Move right until he's not inside the box
                Do While c.Left < w.Right
                    c.Left += 1
                Loop
            End If
            If x_dir = -1 Then
                ''Move left until he's not inside the box
                Do While c.Right < w.Left
                    c.Left -= 1
                Loop
            End If
            If c.Bounds.IntersectsWith(w.Bounds) Then
                If y_dir > 0 Then
                    ''Move DOWN until outside the box
                    Do While c.Top < w.Bottom
                        c.Top += 1
                    Loop
                End If
                If y_dir < 0 Then
                    ''Move UP until he's not inside the box
                    Do While c.Bottom < w.Top
                        c.Top -= 1
                    Loop
                End If
            End If
        End If

    End Sub

    ''COLLISION WITH BLOCKS
    Sub hit_barrier(k As Agent, w As Barrier)
        Dim COLLIDED As Boolean = False


        ''move_outside_other2(k, w)

        'OKAY
        'STILL NOT WORKING PERFECTLY
        'NEW IDEA
        'Find the percentage of which side he is mostly on
        ' if he is a little bit above but mostly to the left, treat it as a left collision

        'THIS NEEDS TO CHECK TOP AND BOTTOM FIRST

        ''Coming from above
        If k.Right > w.Left And k.Left < w.Right And k.Bottom >= w.Top And k.Bottom < w.Bottom And COLLIDED = False Then
            If k.Bottom > w.Top Then k.Top = w.Top - k.Height
            k.Vspeed = 0
            COLLIDED = True
        End If
        ''Coming from below
        ''You bounce off the bottom of blocks
        If (k.Right > w.Left And k.Left < w.Right) And k.Top <= w.Bottom And k.Bottom > w.Top And k.Bottom > w.Bottom And COLLIDED = False Then
            If k.Top < w.Bottom Then k.Top = w.Bottom
            COLLIDED = True
            ''You lost some vertical speed and bounce off
            If k.Vspeed < 0 Then k.Vspeed *= -0.5
        End If



        ''Coming from Right Side
        If k.Left <= w.Right And k.Right >= w.Right And k.Bottom > w.Top And k.Top < w.Bottom And COLLIDED = False Then
            If k.Right > w.Right Then k.Left = w.Right
            k.Hspeed = 0
            COLLIDED = True
        End If
        ''Coming from LEft Side
        If k.Right >= w.Left And k.Left <= w.Left And (k.Bottom > w.Top And k.Bottom < w.Bottom) Or k.Right >= w.Left And k.Left <= w.Left And (k.Top < w.Top And k.Bottom > w.Top) And COLLIDED = False Then
            If k.Left < w.Left Then k.Left = w.Left - k.Width
            k.Hspeed = 0
            COLLIDED = True
        End If



    End Sub

End Module
