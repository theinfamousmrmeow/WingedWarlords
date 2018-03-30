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
        ''SET THE COLORS
        If guy.player_num = 1 Then guy.palette = Palettes.normal
        If guy.player_num = 2 Then guy.palette = Palettes.playertwo
        ''end of color setting
        guy.Name = "Player" & guy.player_num
        guy.palette = Palettes.normal
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
        guy.Vspeed = (Game.Random.Next(5) * -1) + 1
        guy.Hspeed = Game.Random.Next(3) - 1.5
        guy.INPUT_x = 1 - Math.Floor(Game.Random.Next(3))
        guy.palette = Palettes.knave
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

    Function Spawn_Champion(ByVal x As Integer, y As Integer)

        Dim elite As Knight = Spawn_Knight(x, y)
        elite.skill = 3
        elite.palette = Palettes.baron
        elite.max_hspeed *= 1.2
        elite.accel *= 1.2

        Return elite

    End Function

    Function Spawn_Elite(ByVal x As Integer, y As Integer)

        Dim elite As Knight = Spawn_Knight(x, y)
        elite.skill = 1
        elite.palette = Palettes.knight

        Return elite

    End Function

    Function Spawn_Nightmare(ByVal x As Integer, y As Integer)
        ''UNHOLY DEMON GUARDIANS OF THE CASTLE
        Dim elite As Knight = Spawn_Knight(x, y)
        elite.skill = 4
        elite.palette = Palettes.unholy
        elite.max_hspeed *= 1.25
        elite.accel *= 1.25
        Return elite

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
