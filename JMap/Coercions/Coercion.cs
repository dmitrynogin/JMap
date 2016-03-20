using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    static class Coercion
    {
        public static bool TryCoerce<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping)
        {
            var token = jObject[mapping.Field];
            if (token == null)
                return false;

            mapping[token.Value<TSource>()] = token.Value<TTarget>();
            return true;
        }

        public static bool TryCoerce<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping)
        {
            var token = jObject[mapping.Field];
            if (token == null)
                return false;

            mapping[token.Values<TSource>().ToArray()] = token.Values<TTarget>().ToArray();
            return true;
        }
    }
}
