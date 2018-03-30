Module Palettes


    Public grayscale As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                       {New Single() {0.299, 0.299, 0.299, 0, 0}, _
                        New Single() {0.587, 0.587, 0.587, 0, 0}, _
                        New Single() {0.114, 0.114, 0.114, 0, 0}, _
                        New Single() {0, 0, 0, 1, 0}, _
                        New Single() {0, 0, 0, 0, 1}})

    Public whiteout As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                          {New Single() {0, 0, 0, 0, 0}, _
                           New Single() {0, 0, 0, 0, 0}, _
                           New Single() {0, 0, 0, 0, 0}, _
                           New Single() {0, 0, 0, 1, 0}, _
                           New Single() {1, 1, 1, 0, 0}})

    ''Shifts the color to negative
    Public negative As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                          {New Single() {-1, 0, 0, 0, 0}, _
                           New Single() {0, -1, 0, 0, 0}, _
                           New Single() {0, 0, -1, 0, 0}, _
                           New Single() {0, 0, 0, 1, 0}, _
                           New Single() {1, 1, 1, 0, 0}})

    ''Blue Rider, Green horse
    Public greenshift As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                          {New Single() {-0.5, 0, 0, 0, 0}, _
                           New Single() {0, 1, 0, 0, 0}, _
                           New Single() {0, 0, -1, 0, 0}, _
                           New Single() {0, 0, 0, 1, 0}, _
                           New Single() {1, 0, 1, 0, 0}})


    ''Teal Rider, Blue Horse
    Public playertwo As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                          {New Single() {0.6, 0, 0, 0, 0}, _
                           New Single() {0, 0.5, 0, 0, 0}, _
                           New Single() {0, 0, -0.5, 0, 0}, _
                           New Single() {0, 0, 0, 1, 0}, _
                           New Single() {0.4, 0.4, 0.8, 0, 0}})

    ''Teal Rider, Blue Horse
    Public teal As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                          {New Single() {-1, 0, 0, 0, 0}, _
                           New Single() {0, -0.5, 0, 0, 0}, _
                           New Single() {0, 0, -0.5, 0, 0}, _
                           New Single() {0, 0, 0, 1, 0}, _
                           New Single() {1, 1, 1, 0, 0}})

    ''Intense Purple, Black Wings
    Public unholy As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                          {New Single() {-0.5, 0, 0, 0, 0}, _
                           New Single() {0, -1, 0, 0, 0}, _
                           New Single() {0, 0, 1, 0, 0}, _
                           New Single() {0, 0, 0, 1, 0}, _
                           New Single() {1, 0, 1, 0, 0}})

    ''Purple rider, red horse
    Public skeletor As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                          {New Single() {0.5, 0, 0, 0, 0}, _
                           New Single() {0, -0.9, 0, 0, 0}, _
                           New Single() {0, 0, -0.9, 0, 0}, _
                           New Single() {0, 0, 0, 1, 0}, _
                           New Single() {0.5, 0.75, 0.75, 0, 0}})
    ''                           New Single() {0.5, 0.9, 0.9, 0, 0}})
    '' was 1, 1, 1
    ''Color Half-Shift
    Public elemental As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                          {New Single() {-1, 0, 0, 0, 0}, _
                           New Single() {0, 1, 0, 0, 0}, _
                           New Single() {0, 0, -1, 0, 0}, _
                           New Single() {0, 0, 0, 1, 0}, _
                           New Single() {1, 1, 1, 0, 0}})

    Public blackout As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                                 {New Single() {0, 0, 0, 0, 0}, _
                                  New Single() {0, 0, 0, 0, 0}, _
                                  New Single() {0, 0, 0, 0, 0}, _
                                  New Single() {0, 0, 0, 1, 0}, _
                                  New Single() {0, 0, 0, 0, 1}})

    Public normal As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                                  {New Single() {1, 0, 0, 0, 0}, _
                                   New Single() {0, 1, 0, 0, 0}, _
                                   New Single() {0, 0, 1, 0, 0}, _
                                   New Single() {0, 0, 0, 1, 0}, _
                                   New Single() {0, 0, 0, 0, 1}})

    ''Top one scale red
    ''Second line scales green
    ''third scales blue
    ''fourth line scale alpha
    ''Fifth line is just addition

    Public colorize_red As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                {New Single() {1, 0, 0, 0, 0}, _
                 New Single() {0, 1, 0, 0, 0}, _
                 New Single() {0, 0, 1, 0, 0}, _
                 New Single() {0, 0, 0, 1, 0}, _
                 New Single() {0, -0.5, -0.5, 0, 1}})

    Public shift As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                        {New Single() {1, 0, 0, 0, 0}, _
                        New Single() {0, 1, 0, 0, 0}, _
                        New Single() {0, 0, 1, 0, 0}, _
                        New Single() {0, 0, 0, 1, 0}, _
                        New Single() {0.5, 0.5, 0.5, 0.5, 1}})

    ''Named for convenience
    Public knave As System.Drawing.Imaging.ColorMatrix = negative
    Public knight As System.Drawing.Imaging.ColorMatrix = greenshift
    Public baron As System.Drawing.Imaging.ColorMatrix = skeletor

End Module
