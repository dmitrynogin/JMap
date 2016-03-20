using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    static class Validation
    {
        public static bool TryAssert<T>(this JObject jObject, Assert<T> assert)
        {
            var token = jObject[assert.Field];
            if (token == null)
                return false;

            var value = token.Value<T>();
            if (!assert[value])
                throw new ValueMistmatchException(assert.Field);

            return true;
        }
    }
}
