using System;
using System.Windows.Interop;
using System.Runtime.InteropServices;

class HwndHostEx : HwndHost
{
    private IntPtr ChildHandle = IntPtr.Zero;

    [DllImport("user32.dll")]
    static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    [DllImport("user32.dll")]
    static extern int SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);

    public HwndHostEx(IntPtr handle)
    {
        ChildHandle = handle;
    }

    protected override HandleRef BuildWindowCore(HandleRef hwndParent)
    {
        HandleRef href = new HandleRef();

        if (ChildHandle != IntPtr.Zero)
        {
            const int GWL_STYLE = -16;
            const int WS_CHILD = 0x40000000;

            SetWindowLong(ChildHandle, GWL_STYLE, WS_CHILD);


            SetParent(ChildHandle, hwndParent.Handle);
            href = new HandleRef(this, ChildHandle);
        }

        return href;
    }

    protected override void DestroyWindowCore(HandleRef hwnd)
    {

    }
}