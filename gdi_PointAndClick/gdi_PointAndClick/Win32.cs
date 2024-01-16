namespace gdi_PointAndClick;

using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class Win32
{
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetKeyboardState(byte[] lpKeyState);

    private static byte GetVirtualKeyCode(Keys key)
    {
        int value = (int)key;
        return (byte)(value & 0xFF);
    }

    public static bool IsKeyPressed(Keys key)
    {
        var keyboard = new byte[256];
        GetKeyboardState(keyboard);

        return (keyboard[GetVirtualKeyCode(key)] & 0x80) is not 0;
    }
}