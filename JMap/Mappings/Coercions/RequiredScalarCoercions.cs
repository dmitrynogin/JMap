using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class RequiredScalarCoercions
    {
        public static JObject Required<T>(this JObject jObject, Expression<Func<string, T>> mapping) =>
            jObject.Required<string, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<int, T>> mapping) =>
            jObject.Required<int, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<long, T>> mapping) =>
            jObject.Required<long, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<float, T>> mapping) =>
            jObject.Required<float, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<double, T>> mapping) =>
            jObject.Required<double, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<bool, T>> mapping) =>
            jObject.Required<bool, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<DateTime, T>> mapping) =>
            jObject.Required<DateTime, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<int?, T>> mapping) =>
            jObject.Required<int?, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<long?, T>> mapping) =>
            jObject.Required<long?, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<float?, T>> mapping) =>
            jObject.Required<float?, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<double?, T>> mapping) =>
            jObject.Required<double?, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<bool?, T>> mapping) =>
            jObject.Required<bool?, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<DateTime?, T>> mapping) =>
            jObject.Required<DateTime?, T>(mapping);

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
