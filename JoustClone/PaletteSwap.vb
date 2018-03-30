Imports System.Drawing.Imaging

''I GOT THIS OFF OF CODEPROJECT.ORG
''Can't remember the gentleman's name
''it is open-source code.
''I don't actually use any of this code directly, but I did learn this technique from him.

Module PaletteSwap

    Public Function translate(ByVal img As Image, ByVal red As Single, _
                       ByVal green As Single, ByVal blue As Single, _
                       Optional ByVal alpha As Single = 0) As Integer

        Dim sr, sg, sb, sa As Single

        ' noramlize the color components to 1
        sr = red / 255
        sg = green / 255
        sb = blue / 255
        sa = alpha / 255

        ' create the color matrix
        Dim cm As New ColorMatrix(New Single()() _
                       {New Single() {1, 0, 0, 0, 0}, _
                        New Single() {0, 1, 0, 0, 0}, _
                        New Single() {0, 0, 1, 0, 0}, _
                        New Single() {0, 0, 0, 1, 0}, _
                        New Single() {sr, sg, sb, sa, 1}})



        Return 1
    End Function


End Module
