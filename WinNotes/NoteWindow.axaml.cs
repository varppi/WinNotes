using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System;
using System.Runtime.InteropServices;

namespace WinNotes;

public partial class NoteWindow : Window
{

    public NoteWindow()
    {
        InitializeComponent();
        Dispatcher.UIThread.Post(() => NoteBox.Focus());
    }

}