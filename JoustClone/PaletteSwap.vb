Imports System.Drawing.Imaging

''I GOT THIS OFF OF CODEPROJECT.ORG
''Can't remember the gentleman's name
''it is open-source code.
''I don't actually use any of this code directly, but I did learn this technique from him.

Module PaletteSwap

    Public Function translate(ByVal img As Image, ByVal red As Single, _
                       ByVal green As Single, ByVal blue As Single, _
                       Optional ByVal alpha As Single = 0) As Image


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

        ' apply the matrix to the image
        Return draw_adjusted_image(img, cm)

    End Function


    Private Function draw_adjusted_image(ByVal img As Image, _
                    ByVal cm As ColorMatrix) As Image


        Try
            Dim bmp As New Bitmap(img) ' create a copy of the source image 
            Dim imgattr As New ImageAttributes()
            Dim rc As New Rectangle(0, 0, img.Width, img.Height)
            Dim g As Graphics = Graphics.FromImage(img)

            ' associate the ColorMatrix object with an ImageAttributes object
            imgattr.SetColorMatrix(cm)
            ' draw the copy of the source image back over the original image, 
            'applying the ColorMatrix
            g.DrawImage(bmp, rc, 0, 0, img.Width, img.Height, _
                                   GraphicsUnit.Pixel, imgattr)

            Return bmp

        Catch

        End Try

    End Function


    Public Function grayscale(ByVal img As Image) As Image

        Dim cm As ColorMatrix = New ColorMatrix(New Single()() _
                               {New Single() {0.299, 0.299, 0.299, 0, 0}, _
                                New Single() {0.587, 0.587, 0.587, 0, 0}, _
                                New Single() {0.114, 0.114, 0.114, 0, 0}, _
                                New Single() {0, 0, 0, 1, 0}, _
                                New Single() {0, 0, 0, 0, 1}})


        Return draw_adjusted_image(img, cm)

    End Function

    Public Function negative(ByVal img As Image) As Image

        Dim cm As ColorMatrix = New ColorMatrix(New Single()() _
                               {New Single() {-1, 0, 0, 0, 0}, _
                                New Single() {0, -1, 0, 0, 0}, _
                                New Single() {0, 0, -1, 0, 0}, _
                                New Single() {0, 0, 0, 1, 0}, _
                                New Single() {0, 0, 0, 0, 1}})

        Return draw_adjusted_image(img, cm)

    End Function
End Module
