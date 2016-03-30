using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JMap.Tests
{
    public class WebResource
    {
        public virtual void ValidateUrl(string text)
        {
            string pattern = @"^(http:\/\/|https:\/\/)[-a-zA-Z0-9+&@#\/%=~_|$?!:;,.\*\(\)]*[a-zA-Z0-9+&@#\/%=~\-_|$]$";
            if (!Regex.IsMatch(text, pattern))
                throw new ValidationException($"Invalid URL: {text}.");

            if (text.Length > 2048)
                throw new ValidationException($"URL {text} exceeds 2048 characters.");
        }
    }
}
