Module Spawning


    Function Spawn_Player(ByVal x As Integer, y As Integer)

        ''Play the agent spawn sound
        Sound.play_sfx(My.Resources.sfx_spawn)
        ''Create the new Knight
        Dim guy As New Knight(Game.TIME)
        guy.Left = x
        guy.Top = y
        guy.Vspeed = 0
        guy.flap_speed *= 1.2
        guy.jump_speed *= 1
        guy.player_num = Game.PLAYERS.Count + 1
        guy.Name = "Player" & guy.player_num ''Each knight ever created needs a unique name
        ''Add to Agent List
        Game.PLAYERS.Add(guy, guy.Name)
        Game.Agents.Add(guy, guy.Name)
        Return guy

    End Function

    Function Spawn_Knight(ByVal x As Integer, y As Integer)

        ''Play the agent spawn sound
        Sound.play_sfx(My.Resources.sfx_spawn)
        ''Create the new Knight
        Dim guy As New Knight(Game.TIME)
        guy.Left = x
        guy.Top = y
        guy.Vspeed = -4
        guy.INPUT_x = 1 - Math.Floor(Game.Random.Next(3))
        guy.palette = Palettes.colorize_red
        number_of_agents += 1
        ''ReDim Preserve AgentArray(number_of_agents - 1)
        ''AgentArray(number_of_agents - 1) = guy
        guy.Name = "Knight" & number_of_agents ''Each knight ever created needs a unique name

        ''Add to Agent List
        Game.Agents.Add(guy, guy.Name)
        Game.ENEMIES.Add(guy, guy.Name)
        '
        Return guy

    End Function

    Function Spawn_Elite(ByVal x As Integer, y As Integer)

        Dim elite As Knight = Spawn_Knight(x, y)
        elite.skill = 1
        elite.palette = Palettes.colorize_black

    End Function


    Function Spawn_Mount(ByVal x As Integer, y As Integer)
        ''Create the new Knight
        Dim guy As New Mount(Game.TIME)
        guy.Left = x
        guy.Top = y
        guy.Vspeed = 3
        ''Make him go up or down randomly
        guy.INPUT_x = 1 - Math.Floor(Game.Random.Next(3))
        number_of_agents += 1
        guy.Name = "Mount" & number_of_agents ''Each knight ever created needs a unique name
        ''Add to Agent List
        Game.Agents.Add(guy, guy.Name)
        Game.ENEMIES.Add(guy, guy.Name)

        Return guy
    End Function

    Function Spawn_Rider(ByVal x As Integer, y As Integer)

        ''Create the Rider
        Dim guy As New Rider(Game.TIME)
        guy.Left = x
        guy.Top = y
        guy.Vspeed = 3
        guy.INPUT_x = 1 - Math.Floor(Game.Random.Next(3))
        number_of_agents += 1
        guy.Name = "Rider" & number_of_agents ''Each knight ever created needs a unique name
        ''Add to Agent List
        Game.Agents.Add(guy, guy.Name)
        Game.Pickups.Add(guy, guy.Name)
        ''
        Return guy

    End Function

End Module
