Module Sound

    Dim lastsfx
    Dim lastsfx_time As Integer = 0
    Dim lastpriority As Integer = 0
    ' Accessing the Winmm.dll, a windows API
    ' Not sure what kind of legal issues this raises...

    ''Here I'm declaring a function that I'll use later to play an mp3
    ''The function is actually in the 'winmm.dll' library
    ''Its called mciSendStringA in the library

    ''I didn't declare
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Int32, ByVal hwndCallback As Int32) As Int32


    Sub play_sfx(ByVal sound As Object, Optional ByVal priority As Integer = 0)
        If My.Settings.play_sounds = True Then
            '' If Not sound.ToString = lastsfx.ToString Then
            If lastsfx_time < Game.TIME + 6 Or priority > lastpriority Then
                My.Computer.Audio.Play(sound, AudioPlayMode.Background)
                lastpriority = priority
                lastsfx_time = Game.TIME
                lastsfx = sound
            End If


        End If
    End Sub

    Sub play_bgm(ByVal file_location As String)



        If My.Settings.play_bgm = True Then

            ''Okay so Visual Basic can't really handle MP3s on its own.
            ''A traditional technique is to invoke a windows API
            ''I of course didn't come up with this technique, though this is my own implementation.

            Dim _filename As String = file_location
            ''So apparently, mpegvideo codec uses the mp3 codec to render sound
            ''since you can't legally use the mp3 codec, you can use the mpegvideo codec to the same effect

            ''So you need to use the function twice to play the mp3

            mciSendString("open """ & _filename & """ type mpegvideo alias audiofile", Nothing, 0, IntPtr.Zero)
            Dim playCommand As String = "play audiofile from 0"
            mciSendString(playCommand, Nothing, 0, IntPtr.Zero)

        End If
    End Sub

    Sub Reset()
        lastpriority = -1
        lastsfx_time = -1
    End Sub

End Module
