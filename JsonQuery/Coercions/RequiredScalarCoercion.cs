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
        public static JObject Required<T>(this JObject jObject, Expression<Func<string, T>> mapping) =>
            jObject.Required<string, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<int, T>> mapping) =>
            jObject.Required<int, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<JObject, T>> mapping) =>
            jObject.Required<JObject, T>(mapping);

        static JObject Required<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping)
        {
            if (!jObject.TryCoerce(mapping))
                throw new MissingFieldException($"Required {mapping.Field} field not found in the JSON payload.");

            return jObject;
        }
    }
}
