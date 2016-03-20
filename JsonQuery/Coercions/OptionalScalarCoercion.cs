using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuery
{
    public static class OptionalScalarCoercion
    {
        public static JObject Optional<T>(this JObject jObject, Expression<Func<string, T>> mapping) =>
            jObject.Optional<string, T>(mapping);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<int, T>> mapping) =>
            jObject.Optional<int, T>(mapping);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<JObject, T>> mapping) =>
            jObject.Optional<JObject, T>(mapping);

        static JObject Optional<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping)
        {
            jObject.TryCoerce(mapping);
            return jObject;
        }
    }
}
