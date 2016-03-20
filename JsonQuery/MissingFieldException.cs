using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuery
{
    public class MissingFieldException : FormatException
    {
        public MissingFieldException(string fieldName) 
            : base($"JSON payload misses required field {fieldName}.")
        {
        }
    }
}
