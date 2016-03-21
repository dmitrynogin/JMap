using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class OptionalScalarConverions
    {
        public static JObject Optional<T>(this JObject jObject, Expression<Func<string, T>> mapping, Func<string, T> conversion) =>
            jObject.Optional<string, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<int, T>> mapping, Func<int, T> conversion) =>
            jObject.Optional<int, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<long, T>> mapping, Func<long, T> conversion) =>
            jObject.Optional<long, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<float, T>> mapping, Func<float, T> conversion) =>
            jObject.Optional<float, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<double, T>> mapping, Func<double, T> conversion) =>
            jObject.Optional<double, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<bool, T>> mapping, Func<bool, T> conversion) =>
            jObject.Optional<bool, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<DateTime, T>> mapping, Func<DateTime, T> conversion) =>
            jObject.Optional<DateTime, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<int?, T>> mapping, Func<int?, T> conversion) =>
            jObject.Optional<int?, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<long?, T>> mapping, Func<long?, T> conversion) =>
            jObject.Optional<long?, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<float?, T>> mapping, Func<float?, T> conversion) =>
            jObject.Optional<float?, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<double?, T>> mapping, Func<double?, T> conversion) =>
            jObject.Optional<double?, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<bool?, T>> mapping, Func<bool?, T> conversion) =>
            jObject.Optional<bool?, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<DateTime?, T>> mapping, Func<DateTime?, T> conversion) =>
            jObject.Optional<DateTime?, T>(mapping, conversion);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<JObject, T>> mapping, Func<JObject, T> conversion) =>
            jObject.Optional<JObject, T>(mapping, conversion);

        static JObject Optional<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping, Func<TSource, TTarget> conversion)
        {
            jObject.TryConvert(mapping, conversion);
            return jObject;
        }
    }
}
