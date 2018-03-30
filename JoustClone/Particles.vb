''Particles have no physics and have no collision interactions
''They don't do anything except animate and then disappear

Public Class ParallaxObject
    Public Z As Integer = 0
    Public y_flip As Integer = 1
    Public x_factor As Decimal = 0
    Public Image As Image
    Public Scale As Decimal
    Public Width As Integer
    Public Height As Integer

    Sub New(img As Image, Optional y As Integer = 1)
        Z = Game.Random.Next(Game.DISTANCE_TO_CASTLE) + 100
        x_factor = (Game.Random.Next(200) - 100) / 100
        Image = img
        Scale = 1
        y_flip = y
        Width = img.Width * Scale
        Height = img.Height * Scale
    End Sub

End Class

Public Class Particle : Inherits Label


    Public spawn_time As Integer = 0
    Public float_rate As Integer = 1
    Public exists_length = 60
    Dim SplashBrushes As Brush() = {New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(15, 15), Color.Gold, Color.White), _
                                       New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(15, 15), Color.Lime, Color.White), _
                                       New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(15, 15), Color.Aqua, Color.White), _
                                       New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(15, 15), Color.Crimson, Color.White), _
                                       New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(15, 15), Color.Orchid, Color.White) _
                                       }
    ''Set the particle brush to one of those above
    Public mybrush As Brush = SplashBrushes(Math.Round(Game.Random.Next(5)))

    Sub New()

    End Sub

    Sub New(ByRef time As Integer, x As Integer, y As Integer, mytext As String)
        Visible = True
        Width = 30
        Height = 20
        AutoSize = True
        ForeColor = Color.Lime
        BackColor = Color.Transparent
        spawn_time = time
        Name = "Particle" + time.ToString
        Font = Game.FONT
        time += 1
        Left = x + Width / 2
        Top = y + Height / 2
        TextAlign = ContentAlignment.MiddleCenter
        Text = mytext
        BringToFront()
        Left -= mytext.Length * 6
        exists_length = 15 + Text.LongCount * 5
    End Sub

End Class

Public Class prt_ring : Inherits Particle
    Sub New()
        Text = " "
        exists_length = 10
    End Sub
End Class