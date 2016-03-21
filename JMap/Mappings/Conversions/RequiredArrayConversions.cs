using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class RequiredArrayConversions
    {
        public static JObject Required<T>(this JObject jObject, Expression<Func<string[], IList<T>>> mapping, Func<string, T> conversion) =>
            jObject.Required<string, T>(mapping, conversion);

        public static JObject Required<T>(this JObject jObject, Expression<Func<int[], IList<T>>> mapping, Func<int, T> conversion) =>
            jObject.Required<int, T>(mapping, conversion);

        public static JObject Required<T>(this JObject jObject, Expression<Func<long[], IList<T>>> mapping, Func<long, T> conversion) =>
            jObject.Required<long, T>(mapping, conversion);

        public static JObject Required<T>(this JObject jObject, Expression<Func<float[], IList<T>>> mapping, Func<float, T> conversion) =>
            jObject.Required<float, T>(mapping, conversion);

        public static JObject Required<T>(this JObject jObject, Expression<Func<double[], IList<T>>> mapping, Func<double, T> conversion) =>
            jObject.Required<double, T>(mapping, conversion);

        public static JObject Required<T>(this JObject jObject, Expression<Func<bool[], IList<T>>> mapping, Func<bool, T> conversion) =>
            jObject.Required<bool, T>(mapping, conversion);

        public static JObject Required<T>(this JObject jObject, Expression<Func<DateTime[], IList<T>>> mapping, Func<DateTime, T> conversion) =>
            jObject.Required<DateTime, T>(mapping, conversion);

        public static JObject Required<T>(this JObject jObject, Expression<Func<int?[], IList<T>>> mapping, Func<int?, T> conversion) =>
            jObject.Required<int?, T>(mapping, conversion);

        public static JObject Required<T>(this JObject jObject, Expression<Func<long?[], IList<T>>> mapping, Func<long?, T> conversion) =>
            jObject.Required<long?, T>(mapping, conversion);

        public static JObject Required<T>(this JObject jObject, Expression<Func<float?[], IList<T>>> mapping, Func<float?, T> conversion) =>
            jObject.Required<float?, T>(mapping, conversion);

        public static JObject Required<T>(this JObject jObject, Expression<Func<double?[], IList<T>>> mapping, Func<double?, T> conversion) =>
            jObject.Required<double?, T>(mapping, conversion);

        public static JObject Required<T>(this JObject jObject, Expression<Func<bool?[], IList<T>>> mapping, Func<bool?, T> conversion) =>
            jObject.Required<bool?, T>(mapping, conversion);

        public static JObject Required<T>(this JObject jObject, Expression<Func<DateTime?[], IList<T>>> mapping, Func<DateTime?, T> conversion) =>
            jObject.Required<DateTime?, T>(mapping, conversion);

        public static JObject Required<T>(this JObject jObject, Expression<Func<JObject[], IList<T>>> mapping, Func<JObject, T> conversion) =>
            jObject.Required<JObject, T>(mapping, conversion);
        
        static JObject Required<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping, Func<TSource, TTarget> conversion)
        {
            if (!jObject.TryConvert(mapping, conversion))
                throw new MissingFieldException(mapping.Field);

            return jObject;
        }
    }
}
