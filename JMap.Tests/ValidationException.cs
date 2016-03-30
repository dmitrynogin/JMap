using System;
using System.Runtime.Serialization;

namespace JMap.Tests
{
    [Serializable]
    internal class ValidationException : Exception
    {
        public ValidationException(string message) 
            : base(message)
        {
        }
    }
}