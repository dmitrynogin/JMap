using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public class ValueMistmatchException : FormatException
    {
        public ValueMistmatchException(string fieldName) 
            : base($"JSON payload {fieldName} value mistmatch.")
        {
        }
    }
}
