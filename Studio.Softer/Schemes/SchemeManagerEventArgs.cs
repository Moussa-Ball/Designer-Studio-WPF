using System;

namespace Studio.Softer.Schemes
{
    public class SchemeManagerEventArgs : EventArgs
    {
        public SchemeEnum OldScheme { get; set; }
        public SchemeEnum NewScheme { get; set; }
    }
}
