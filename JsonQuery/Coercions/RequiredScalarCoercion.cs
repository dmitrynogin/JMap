using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuery
{
    public static class RequiredScalarCoercion
    {
        public static JObject Require<T>(this JObject jObject, Expression<Func<string, T>> mapping) =>
            jObject.Require<string, T>(mapping);

        public static JObject Require<T>(this JObject jObject, Expression<Func<int, T>> mapping) =>
            jObject.Require<int, T>(mapping);

        public static JObject Require<T>(this JObject jObject, Expression<Func<JObject, T>> mapping) =>
            jObject.Require<JObject, T>(mapping);

        static JObject Require<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping)
        {
            if (!jObject.TryCoerce(mapping))
                throw new MissingFieldException($"Required {mapping.Field} field not found in the JSON payload.");

            return jObject;
        }
    }
}
