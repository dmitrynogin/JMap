using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class OptionalArrayCoercions
    {
        public static JObject Optional<T>(this JObject jObject, Expression<Func<string[], IList<T>>> mapping) =>
            jObject.Optional<string, T>(mapping);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<int[], IList<T>>> mapping) =>
            jObject.Optional<int, T>(mapping);
        
        public static JObject Optional<T>(this JObject jObject, Expression<Func<JObject[], IList<T>>> mapping) =>
            jObject.Optional<JObject, T>(mapping);

        static JObject Optional<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping)
        {
            jObject.TryCoerce(mapping);
            return jObject;
        }
    }
}
