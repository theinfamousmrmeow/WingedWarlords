Public Class Joystick



    ''This class represents a controller
    ''There's two main kinds
    ''Player Joystick ( Has customizable keys for players 1 and 2)
    ''and AI Joystick ( simulates key presses to pass to an agent)

    Public INPUT_xdir As Integer = 0 '' -1 is left, 0 is no input, 1 is right
    Public INPUT_ydir As Integer = 0 '' 1 is down, 0 is no input, -1 is up
    Public up_pressed As Boolean = False ''This is toggled when you press the up key.  Gets set to false when INPUT_ydir = 0.

    ''User Input
    ''Pressing Keys



End Class
