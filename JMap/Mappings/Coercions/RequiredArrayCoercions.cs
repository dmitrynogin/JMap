using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class RequiredArrayCoercions
    {
        public static JObject Required<T>(this JObject jObject, Expression<Func<string[], IList<T>>> mapping) =>
            jObject.Required<string, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<int[], IList<T>>> mapping) =>
            jObject.Required<int, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<long[], IList<T>>> mapping) =>
            jObject.Required<long, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<float[], IList<T>>> mapping) =>
            jObject.Required<float, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<double[], IList<T>>> mapping) =>
            jObject.Required<double, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<bool[], IList<T>>> mapping) =>
            jObject.Required<bool, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<DateTime[], IList<T>>> mapping) =>
            jObject.Required<DateTime, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<int?[], IList<T>>> mapping) =>
            jObject.Required<int?, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<long?[], IList<T>>> mapping) =>
            jObject.Required<long?, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<float?[], IList<T>>> mapping) =>
            jObject.Required<float?, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<double?[], IList<T>>> mapping) =>
            jObject.Required<double?, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<bool?[], IList<T>>> mapping) =>
            jObject.Required<bool?, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<DateTime?[], IList<T>>> mapping) =>
            jObject.Required<DateTime?, T>(mapping);

        public static JObject Required<T>(this JObject jObject, Expression<Func<JObject[], IList<T>>> mapping) =>
            jObject.Required<JObject, T>(mapping);

        static JObject Required<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping)
        {
            if (!jObject.TryCoerce(mapping))
                throw new MissingFieldException(mapping.Field);

            return jObject;
        }
    }
}
