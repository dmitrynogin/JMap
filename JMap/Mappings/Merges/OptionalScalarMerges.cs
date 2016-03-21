using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class OptionalScalarMerges
    {
        public static JObject Optional<T>(this JObject jObject, Expression<Func<string, T>> mapping, Action<string, T> merge) 
            where T : class =>
            jObject.Optional<string, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<int, T>> mapping, Action<int, T> merge) 
            where T : class =>
            jObject.Optional<int, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<long, T>> mapping, Action<long, T> merge) 
            where T : class =>
            jObject.Optional<long, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<float, T>> mapping, Action<float, T> merge) 
            where T : class =>
            jObject.Optional<float, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<double, T>> mapping, Action<double, T> merge) 
            where T : class =>
            jObject.Optional<double, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<bool, T>> mapping, Action<bool, T> merge)
            where T : class =>
            jObject.Optional<bool, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<DateTime, T>> mapping, Action<DateTime, T> merge) 
            where T : class =>
            jObject.Optional<DateTime, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<int?, T>> mapping, Action<int?, T> merge)
            where T : class =>
            jObject.Optional<int?, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<long?, T>> mapping, Action<long?, T> merge) 
            where T : class =>
            jObject.Optional<long?, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<float?, T>> mapping, Action<float?, T> merge) 
            where T : class =>
            jObject.Optional<float?, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<double?, T>> mapping, Action<double?, T> merge) 
            where T : class =>
            jObject.Optional<double?, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<bool?, T>> mapping, Action<bool?, T> merge) 
            where T : class =>
            jObject.Optional<bool?, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<DateTime?, T>> mapping, Action<DateTime?, T> merge) 
            where T : class =>
            jObject.Optional<DateTime?, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<JObject, T>> mapping, Action<JObject, T> merge)
            where T : class =>
            jObject.Optional<JObject, T>(mapping, merge);

        static JObject Optional<TSource, TTarget>(this JObject jObject, Mapping<TSource, TTarget> mapping, Action<TSource, TTarget> merge)
            where TTarget : class
        {
            jObject.TryMerge(mapping, merge);
            return jObject;
        }
    }
}
