using System;

namespace Studio.Softer.Windows.UI
{
    public class ClosingWindowEventHandlerArgs : EventArgs
    {
        public bool Cancelled { get; set; }
    }
}
