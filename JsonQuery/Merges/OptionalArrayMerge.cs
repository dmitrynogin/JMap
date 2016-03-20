using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuery
{
    public static class OptionalArrayMerge
    {
        public static JObject Optional<T>(this JObject jObject, Expression<Func<string[], IList<T>>> mapping, Action<string, T> merge)
            where T : class, new() =>
            jObject.Optional<string, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<int[], IList<T>>> mapping, Action<int, T> merge) 
            where T : class, new() =>
            jObject.Optional<int, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<JObject[], IList<T>>> mapping, Action<JObject, T> merge)
            where T : class, new() =>
            jObject.Optional<JObject, T>(mapping, merge);

        static JObject Optional<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping, Action<TSource, TTarget> merge)
            where TTarget : class, new()
        {
            jObject.TryMerge(mapping, merge);
            return jObject;
        }
    }
}
