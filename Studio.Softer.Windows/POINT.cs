using System.Runtime.InteropServices;

namespace Studio.Softer.Windows
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct POINT
    {
        public int x;
        public int y;
    }
}