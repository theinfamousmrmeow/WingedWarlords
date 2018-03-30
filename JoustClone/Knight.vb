''Agents are just active things that have physics on them
'Declaration

Public Class PhysObj

End Class

Public Class Agent '': Inherits PictureBox

    Public dive As Boolean = False
    Public palette As System.Drawing.Imaging.ColorMatrix = Palettes.shift
    Public skill As Integer = 0
    Public spawnedtime As Integer
    Public Hspeed As Decimal
    Public Vspeed As Decimal
    Public OnGround As Boolean = True
    Public Visible As Boolean = True
    Public Width As Integer = 1
    Public Height As Integer = 1
    Public Left As Integer = 0
    Public Top As Integer = 0
    Public Name As String = "Null"
    Public Image As Image
    Public Shielded As Boolean = False
    Public has_sword As Boolean = False
    ''
    Public INPUT_x As Integer = 0
    Public INPUT_y As Integer = 0

    ''Movement shit
    Public accel As Decimal = 0.15
    Public max_hspeed As Decimal = 3
    Public jump_speed As Decimal = 2.5
    Public max_flyspeed As Decimal = -4
    Public flap_speed As Decimal = 1.5
    Public facing As Integer = 1


    Sub New(time As Integer)

        spawnedtime = time
        Hspeed = 0
        Vspeed = 0
        Visible = True
        Width = 40
        Height = 30
        facing = Game.Random.Next(2) - 1
        If facing = 0 Then facing = -1
        ''Image = JoustClone.My.Resources.

    End Sub

    ReadOnly Property Right As Integer

        Get
            Return Left + Width
        End Get

    End Property

    ReadOnly Property Bounds As Rectangle

        Get
            Return New Rectangle(Left, Top, Width, Height)
        End Get

    End Property

    ReadOnly Property Bottom As Integer

        Get
            Return Top + Height
        End Get

    End Property

    Sub Destroy()
        ''Do whatever it is that kills him

    End Sub

    ''
    Function Isplayer(ByVal agent)

        If Game.PLAYERS.Contains(agent.Name) Then
            Return True
        Else
            Return False
        End If
    End Function

    ''Movement
    Sub move_accel(ByVal dir)

        If Not dir = 0 Then facing = dir
        Hspeed += Me.accel * dir
        If Hspeed > max_hspeed Then Hspeed = max_hspeed
        If Hspeed < -max_hspeed Then Hspeed = -max_hspeed
    End Sub

    Sub Jump(ByVal agent As Agent)
        ''If he's capable of flight
        If flap_speed > 0 Then
            ''If he's on the ground, use jumping height
            If OnGround = True Then
                Vspeed = -jump_speed
                If Isplayer(agent) Then Sound.play_sfx(My.Resources.sfx_jump)
                ''If he's not on the ground, use Flapping Speed
            Else
                Vspeed -= flap_speed
                If Vspeed > 0 Then Vspeed = 0
                If Isplayer(agent) Then Sound.play_sfx(My.Resources.sfx_flap, -1)
            End If

            If Vspeed < max_flyspeed Then Vspeed = max_flyspeed

            ''jumped = True
        End If
    End Sub

End Class

Public Class Knight : Inherits Agent

    Public player_num As Integer = -1

    Sub New(time As Integer)
        Call MyBase.New(time)
        player_num = -1
        skill = 0
        Width = 32
        Height = 30
        Image = JoustClone.My.Resources.rider_stand
    End Sub

End Class

Public Class Mount : Inherits Agent

    Sub New(time As Integer)
        Call MyBase.New(time)
        Hspeed = 0
        Vspeed = 0
        Visible = True
        Width = 32
        Height = 32
        Image = JoustClone.My.Resources.mount_down
    End Sub

End Class

Public Class Rider : Inherits Agent

    Sub New(time)
        Call MyBase.New(time)
        spawnedtime = time
        Hspeed = 0
        Vspeed = 0
        facing = 1
        Visible = True
        Width = 16
        Height = 16
        max_hspeed = 1
        jump_speed = 0
        flap_speed = 0
        Image = JoustClone.My.Resources.Resources.knight_dismount
    End Sub

End Class

Public Class Barrier

    Public Visible As Boolean
    Public Name As String
    Public Top As Integer
    Public Left As Integer
    Public Height As Integer
    Public Width As Integer
    Public Color As Color

    Sub New()
        Name = "Barrier"
        Visible = True
        Width = 80
        Height = 16
    End Sub

    ReadOnly Property Right As Integer

        Get
            Return Left + Width
        End Get

    End Property

    ReadOnly Property Bounds As Rectangle

        Get
            Return New Rectangle(Left, Top, Width, Height)
        End Get

    End Property

    ReadOnly Property Bottom As Integer

        Get
            Return Top + Height
        End Get

    End Property

End Class


''PICKUP CLASS
''All of these collide with players only
''Have limited physics on them

Public Class Pickup '': Inherits PictureBox

    Public skill As Integer = 0
    Public spawnedtime As Integer
    Public Hspeed As Decimal
    Public Vspeed As Decimal
    Public OnGround As Boolean = True
    Public Visible As Boolean = True
    Public Width As Integer = 1
    Public Height As Integer = 1
    Public Left As Integer = 0
    Public Top As Integer = 0
    Public Name As String = "Null"
    Public Image As Image
    ''
    Public INPUT_x As Integer = 0
    Public INPUT_y As Integer = 0

    ''Movement shit
    Dim accel As Decimal = 0.15
    Public max_hspeed As Decimal = 3
    Public jump_speed As Decimal = 2.5
    Public max_flyspeed As Decimal = -4
    Public flap_speed As Decimal = 1.5
    Public facing As Integer = 1


    Sub New(time As Integer)
        spawnedtime = time
        Hspeed = 0
        Vspeed = 0
        Visible = True
        Width = 40
        Height = 30
        facing = 1
    End Sub

    ReadOnly Property Right As Integer

        Get
            Return Left + Width
        End Get

    End Property

    ReadOnly Property Bottom As Integer

        Get
            Return Top + Height
        End Get

    End Property

    Sub Destroy()
        ''Do whatever it is that kills him
    End Sub

End Class