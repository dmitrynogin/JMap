using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class RequiredScalarMerges
    {
        public static JObject Required<T>(this JObject jObject, Expression<Func<string, T>> mapping, Action<string, T> merge)
            where T : class =>
            jObject.Required<string, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<int, T>> mapping, Action<int, T> merge)
            where T : class =>
            jObject.Required<int, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<long, T>> mapping, Action<long, T> merge)
            where T : class =>
            jObject.Required<long, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<float, T>> mapping, Action<float, T> merge)
            where T : class =>
            jObject.Required<float, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<double, T>> mapping, Action<double, T> merge)
            where T : class =>
            jObject.Required<double, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<bool, T>> mapping, Action<bool, T> merge)
            where T : class =>
            jObject.Required<bool, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<DateTime, T>> mapping, Action<DateTime, T> merge)
            where T : class =>
            jObject.Required<DateTime, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<int?, T>> mapping, Action<int?, T> merge)
            where T : class =>
            jObject.Required<int?, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<long?, T>> mapping, Action<long?, T> merge)
            where T : class =>
            jObject.Required<long?, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<float?, T>> mapping, Action<float?, T> merge)
            where T : class =>
            jObject.Required<float?, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<double?, T>> mapping, Action<double?, T> merge)
            where T : class =>
            jObject.Required<double?, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<bool?, T>> mapping, Action<bool?, T> merge)
            where T : class =>
            jObject.Required<bool?, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<DateTime?, T>> mapping, Action<DateTime?, T> merge)
            where T : class =>
            jObject.Required<DateTime?, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<JObject, T>> mapping, Action<JObject, T> merge)
            where T : class =>
            jObject.Required<JObject, T>(mapping, merge);

        static JObject Required<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping, Action<TSource, TTarget> merge)
            where TTarget : class
        {
            if (!jObject.TryMerge(mapping, merge))
                throw new MissingFieldException(mapping.Field);

            return jObject;
        }
    }
}
