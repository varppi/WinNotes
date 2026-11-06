using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Threading;
using System;
using System.Runtime.InteropServices;

namespace WinNotes;

public partial class MainWindow : Window
{
    private const int WM_HOTKEY = 0x0312;
    private const int HotkeyId = 1;
    private const uint MOD_CONTROL = 0x0002;
    private const uint MOD_SHIFT = 0x0004;
    private const uint VK_SPACE = 0x20;

    private IntPtr _hwnd;
    private readonly Random _random = new();

    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    public MainWindow()
    {
        Initialize(this);
        InitializeComponent();
        Dispatcher.UIThread.Post(() =>
        {
            if (IsVisible)
                Hide();
            else
            {
                Show();
                Activate();
            }
        });
    }

    public void ClickedButton(object sender, RoutedEventArgs args) => NewNote();

    private void NewNote()
    {
        var note = new NoteWindow
        {
            Topmost = true,
            WindowStartupLocation = WindowStartupLocation.Manual,
            Position = new Avalonia.PixelPoint(
                _random.Next(Screens.Primary?.Bounds.Width / 2 ?? 0),
                _random.Next(Screens.Primary?.Bounds.Height / 2 ?? 0)
            )
        };

        var val = _random.Next(100000);
        note.Background = Brush.Parse($"rgba({(val << 1) & 0x64},{(val << 2) & 0x64},{(val << 4) & 0x64},1)");

        note.Show();
    }

    private void Initialize(Window window)
    {
        _hwnd = window.TryGetPlatformHandle()!.Handle;
        RegisterHotKey(_hwnd, HotkeyId, MOD_CONTROL | MOD_SHIFT, VK_SPACE);

        Win32Properties.AddWndProcHookCallback(window, WndProc);
    }

    private IntPtr WndProc(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        if (msg == WM_HOTKEY && wParam.ToInt32() == HotkeyId)
        {
            handled = true;
            NewNote();
        }

        return IntPtr.Zero;
    }
}