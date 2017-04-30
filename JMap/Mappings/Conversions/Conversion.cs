using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    static class Conversion
    {
        public static bool TryConvert<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping, Func<TSource, TTarget> conversion)
        {
            var token = jObject[mapping.Field];
            if (token == null)
                return false;

            mapping[token.Value<TSource>()] = conversion(token.Value<TSource>());
            return true;
        }

        public static bool TryConvert<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping, Func<TSource, TTarget> conversion)
        {
            var token = jObject[mapping.Field];
            if (token == null)
                return false;

            mapping[token.Values<TSource>().ToArray()] = token.Values<TSource>()
                .Select(v => conversion(v))
                .ToArray();

            return true;
        }

        public static async Task<bool> TryConvertAsync<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping, Func<TSource, Task<TTarget>> asyncConversion)
        {
            var token = jObject[mapping.Field];
            if (token == null)
                return false;

            mapping[token.Value<TSource>()] = await asyncConversion(token.Value<TSource>());
            return true;
        }

        public static async Task<bool> TryConvertAsync<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping, Func<TSource, Task<TTarget>> asyncConversion)
        {
            var token = jObject[mapping.Field];
            if (token == null)
                return false;

            mapping[token.Values<TSource>().ToArray()] = await Task.WhenAll(
                token.Values<TSource>()
                    .Select(v => asyncConversion(v)));

            return true;
        }
    }
}
