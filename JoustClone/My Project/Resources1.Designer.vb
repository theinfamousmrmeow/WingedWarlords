﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.34014
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("JoustClone.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property bg_mountains() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("bg_mountains", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property castle() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("castle", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property clouds() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("clouds", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property crag() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("crag", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to PROGRAMMING
        '''Alexander Macey
        '''
        '''
        '''
        '''GRAPHICS
        '''Alexander Macey
        '''
        '''
        '''
        '''SOUND EFFECTS
        '''Alexander Macey
        '''
        '''
        '''
        '''MUSIC COMPOSED BY
        '''Geoff and Tom Follin
        '''
        '''
        '''
        '''INSPIRED BY
        '''Joust
        '''
        '''
        '''
        '''
        '''SPECIAL THANKS TO
        '''
        '''James Cole, for no particular reason
        '''
        '''Kenny T, For always keeping it real
        '''
        '''Mr. Armstrong, For occasionally getting James to talk to someone else
        '''
        '''
        '''
        '''
        '''
        '''
        '''
        '''
        '''But most of all
        '''
        '''
        '''
        '''
        '''
        '''
        '''
        '''
        '''THANK YOU FOR PLAYING,
        '''
        '''AND REMEMBER
        '''
        '''A HERO IS YOU!.
        '''</summary>
        Friend ReadOnly Property Credits() As String
            Get
                Return ResourceManager.GetString("Credits", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property helmets() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("helmets", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to KING ARTHUR
        '''10000
        '''MORDRED
        '''9000
        '''SIR LANCELOT
        '''8000
        '''SIR GALLAHAD
        '''5000
        '''SIR GAWAIN
        '''3000
        '''SIR BEDEVIERE
        '''2000
        '''KNIGHT
        '''1000
        '''Alex Again
        '''950
        '''Alex Macey
        '''450
        '''DUNG-GATHERER
        '''50
        '''.
        '''</summary>
        Friend ReadOnly Property HIGHSCORES() As String
            Get
                Return ResourceManager.GetString("HIGHSCORES", resourceCulture)
            End Get
        End Property

        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property knight_dismount() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("knight_dismount", resourceCulture)
                Return CType(obj, System.Drawing.Bitmap)
            End Get
        End Property

        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property knight_fall() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("knight_fall", resourceCulture)
                Return CType(obj, System.Drawing.Bitmap)
            End Get
        End Property

        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property menu_bleep() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("menu_bleep", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property mount_down() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("mount_down", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property Pickup_Coin14() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("Pickup_Coin14", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property rider_dive() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("rider_dive", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property rider_down() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("rider_down", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property rider_stand() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("rider_stand", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property rider_turn() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("rider_turn", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property rider_up() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("rider_up", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property sfx_flap() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("sfx_flap", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property sfx_impale_enemy() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("sfx_impale_enemy", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property sfx_jump() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("sfx_jump", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property sfx_land() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("sfx_land", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property sfx_losegame() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("sfx_losegame", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property sfx_parry() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("sfx_parry", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property sfx_player_hit() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("sfx_player_hit", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        '''</summary>
        Friend ReadOnly Property sfx_spawn() As System.IO.UnmanagedMemoryStream
            Get
                Return ResourceManager.GetStream("sfx_spawn", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
