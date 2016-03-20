using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuery
{
    public static class RequiredArrayCoercion
    {
        public static JObject Require<T>(this JObject jObject, Expression<Func<string[], IList<T>>> mapping) =>
            jObject.Require<string, T>(mapping);

        public static JObject Require<T>(this JObject jObject, Expression<Func<int[], IList<T>>> mapping) =>
            jObject.Require<int, T>(mapping);

        public static JObject Require<T>(this JObject jObject, Expression<Func<JObject[], IList<T>>> mapping) =>
            jObject.Require<JObject, T>(mapping);

        static JObject Require<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping)
        {
            if (!jObject.TryCoerce(mapping))
                throw new MissingFieldException(mapping.Field);

            return jObject;
        }
    }
}
