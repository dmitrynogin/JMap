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
        public static JObject Try<T>(this JObject jObject, Expression<Func<string, T>> mapping) =>
            jObject.Try<string, T>(mapping);

        public static JObject Try<T>(this JObject jObject, Expression<Func<int, T>> mapping) =>
            jObject.Try<int, T>(mapping);

        public static JObject Try<T>(this JObject jObject, Expression<Func<JObject, T>> mapping) =>
            jObject.Try<JObject, T>(mapping);

        static JObject Try<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping)
        {
            jObject.TryCoerce(mapping);
            return jObject;
        }
    }
}
