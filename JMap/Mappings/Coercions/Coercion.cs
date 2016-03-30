using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    static class Coercion
    {
        [DebuggerHidden]
        public static bool TryCoerce<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping)
        {
            var token = jObject[mapping.Field];
            if (token == null)
                return false;

            try
            {
                mapping[token.Value<TSource>()] = token.Value<TTarget>();
            }
            catch (InvalidCastException)
            {
                mapping[token.Value<TSource>()] = (TTarget)TypeDescriptor
                    .GetConverter(typeof(TTarget))
                    .ConvertFrom(token.Value<TSource>());
            }

            return true;
        }

        [DebuggerHidden]
        public static bool TryCoerce<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping)
        {
            var token = jObject[mapping.Field];
            if (token == null)
                return false;

            try
            {
                mapping[token.Values<TSource>().ToArray()] = token.Values<TTarget>().ToArray();
            }
            catch (InvalidCastException)
            {
                mapping[token.Values<TSource>().ToArray()] = token.Values<TSource>()
                    .Select(s =>
                        (TTarget)TypeDescriptor
                            .GetConverter(typeof(TTarget))
                            .ConvertFrom(s))
                    .ToArray();
            }

            return true;
        }
    }
}
