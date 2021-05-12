using System;

namespace Studio.Softer.Schemes
{
    internal class SchemeException : Exception
    {
        public SchemeException() { }

        public SchemeException(string message)
            : base(string.Format("Error SchemeManager: {0}", message)) { }
    }
}
