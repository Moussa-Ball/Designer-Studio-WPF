using System.Runtime.InteropServices;

namespace Studio.Softer.Windows
{
    /// <summary>
    /// BITMAPINFOHEADER Compression type.  BI_*.
    /// </summary>
    internal enum BI
    {
        RGB = 0,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct BITMAPINFOHEADER
    {
        public int biSize;
        public int biWidth;
        public int biHeight;
        public short biPlanes;
        public short biBitCount;
        public BI biCompression;
        public int biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public int biClrUsed;
        public int biClrImportant;
    }
}
