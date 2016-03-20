using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    static class Merge
    {
        public static bool TryMerge<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping, Action<TSource, TTarget> merge)
            where TTarget : class
        {
            var token = jObject[mapping.Field];
            if (token == null)
                return false;

            var source = token.Value<TSource>();
            var target = mapping[source];
            if (target == null)
                target = mapping[token.Value<TSource>()] = Activator.CreateInstance<TTarget>();

            merge(source, target);
            return true;
        }

        public static bool TryMerge<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping, Action<TSource, TTarget> merge)
            where TTarget : class, new()
        {
            var token = jObject[mapping.Field];
            if (token == null)
                return false;

            var sources = token.Values<TSource>().ToArray();
            mapping[sources] = sources
                .Select(s =>
                {
                    var t = new TTarget();
                    merge(s, t);
                    return t;
                })
                .ToArray();

            return true;
        }
    }
}
