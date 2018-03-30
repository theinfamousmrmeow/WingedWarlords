Module Palettes


    Public grayscale As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                       {New Single() {0.299, 0.299, 0.299, 0, 0}, _
                        New Single() {0.587, 0.587, 0.587, 0, 0}, _
                        New Single() {0.114, 0.114, 0.114, 0, 0}, _
                        New Single() {0, 0, 0, 1, 0}, _
                        New Single() {0, 0, 0, 0, 1}})


    Public negative As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                                 {New Single() {-1, 0, 0, 0, 0}, _
                                  New Single() {0, -1, 0, 0, 0}, _
                                  New Single() {0, 0, -1, 0, 0}, _
                                  New Single() {0, 0, 0, 1, 0}, _
                                  New Single() {0, 0, 0, 0, 1}})

    Public colorize_black As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                                 {New Single() {-1, 0, 0, 0, 0}, _
                                  New Single() {0, -1, 0, 0, 0}, _
                                  New Single() {0, 0, -1, 0, 0}, _
                                  New Single() {0, 0, 0, 1, 0}, _
                                  New Single() {0, 0, 0, 0, 1}})

    Public normal As System.Drawing.Imaging.ColorMatrix = New System.Drawing.Imaging.ColorMatrix(New Single()() _
                                  {New Single() {1, 0, 0, 0, 0}, _
                                   New Single() {0, 1, 0, 0, 0}, _
                                   New Single() {0, 0, 1, 0, 0}, _
                                   New Single() {0, 0, 0, 1, 0}, _
                                   New Single() {0, 0, 0, 0, 1}})

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



End Module
