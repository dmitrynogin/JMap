using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuery
{
    public static class OptionalArrayCoercion
    {
        public static JObject Try<T>(this JObject jObject, Expression<Func<string[], IList<T>>> mapping) =>
            jObject.Try<string, T>(mapping);

        public static JObject Try<T>(this JObject jObject, Expression<Func<int[], IList<T>>> mapping) =>
            jObject.Try<int, T>(mapping);
        
        public static JObject Try<T>(this JObject jObject, Expression<Func<JObject[], IList<T>>> mapping) =>
            jObject.Try<JObject, T>(mapping);

        static JObject Try<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping)
        {
            jObject.TryCoerce(mapping);
            return jObject;
        }
    }
}
