﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.18444
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On



<Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
 Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")>  _
Partial Friend NotInheritable Class Options
    Inherits Global.System.Configuration.ApplicationSettingsBase
    
    Private Shared defaultInstance As Options = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Options()),Options)
    
    Public Shared ReadOnly Property [Default]() As Options
        Get
            Return defaultInstance
        End Get
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
    Public Property Players() As Integer
        Get
            Return CType(Me("Players"),Integer)
        End Get
        Set
            Me("Players") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("""HIGHSCORES.TXT""")>  _
    Public Property HighScoreFile() As String
        Get
            Return CType(Me("HighScoreFile"),String)
        End Get
        Set
            Me("HighScoreFile") = value
        End Set
    End Property
End Class