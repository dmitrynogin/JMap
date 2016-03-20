using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuery
{
    public static class OptionalScalarMerge
    {
        public static JObject Try<T>(this JObject jObject, Expression<Func<string, T>> mapping, Action<string, T> merge)
            where T : class =>
            jObject.Try<string, T>(mapping, merge);

        public static JObject Try<T>(this JObject jObject, Expression<Func<int, T>> mapping, Action<int, T> merge)
            where T : class =>
            jObject.Try<int, T>(mapping, merge);

        public static JObject Try<T>(this JObject jObject, Expression<Func<JObject, T>> mapping, Action<JObject, T> merge)
            where T : class =>
            jObject.Try<JObject, T>(mapping, merge);

        static JObject Try<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping, Action<TSource, TTarget> merge)
            where TTarget : class
        {
            jObject.TryMerge(mapping, merge);
            return jObject;
        }
    }
}
