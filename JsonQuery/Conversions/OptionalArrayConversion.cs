using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuery
{
    public static class OptionalArrayConversion
    {
        public static JObject Optional<T>(this JObject jObject, Expression<Func<string[], IList<T>>> mapping, Func<string, T> conversion) =>
            jObject.Optional<string, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<int[], IList<T>>> mapping, Func<int, T> conversion) =>
            jObject.Optional<int, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<JObject[], IList<T>>> mapping, Func<JObject, T> conversion) =>
            jObject.Optional<JObject, T>(mapping, conversion);
        
        static JObject Optional<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping, Func<TSource, TTarget> conversion)
        {
            jObject.TryConvert(mapping, conversion);
            return jObject;
        }
    }
}
