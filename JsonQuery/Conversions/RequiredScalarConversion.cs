using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuery
{
    public static class RequiredScalarConversion
    {
        public static JObject Require<T>(this JObject jObject, Expression<Func<string, T>> mapping, Func<string, T> conversion) =>
            jObject.Require<string, T>(mapping, conversion);

        public static JObject Require<T>(this JObject jObject, Expression<Func<int, T>> mapping, Func<int, T> conversion) =>
            jObject.Require<int, T>(mapping, conversion);

        public static JObject Require<T>(this JObject jObject, Expression<Func<JObject, T>> mapping, Func<JObject, T> conversion) =>
            jObject.Require<JObject, T>(mapping, conversion);

        static JObject Require<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping, Func<TSource, TTarget> conversion)
        {
            if (!jObject.TryConvert(mapping, conversion))
                throw new MissingFieldException(mapping.Field);

            return jObject;
        }
    }
}
