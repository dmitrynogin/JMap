using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class OptionalArrayMerges
    {
        public static JObject Optional<T>(this JObject jObject, Expression<Func<string[], IList<T>>> mapping, Action<string, T> merge) 
            where T : class, new() =>
            jObject.Optional<string, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<int[], IList<T>>> mapping, Action<int, T> merge) 
            where T : class, new() =>
            jObject.Optional<int, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<long[], IList<T>>> mapping, Action<long, T> merge) 
            where T : class, new() =>
            jObject.Optional<long, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<float[], IList<T>>> mapping, Action<float, T> merge) 
            where T : class, new() =>
            jObject.Optional<float, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<double[], IList<T>>> mapping, Action<double, T> merge) 
            where T : class, new() =>
            jObject.Optional<double, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<bool[], IList<T>>> mapping, Action<bool, T> merge) 
            where T : class, new() =>
            jObject.Optional<bool, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<DateTime[], IList<T>>> mapping, Action<DateTime, T> merge) 
            where T : class, new() =>
            jObject.Optional<DateTime, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<int?[], IList<T>>> mapping, Action<int?, T> merge) 
            where T : class, new() =>
            jObject.Optional<int?, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<long?[], IList<T>>> mapping, Action<long?, T> merge) 
            where T : class, new() =>
            jObject.Optional<long?, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<float?[], IList<T>>> mapping, Action<float?, T> merge) 
            where T : class, new() =>
            jObject.Optional<float?, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<double?[], IList<T>>> mapping, Action<double?, T> merge) 
            where T : class, new() =>
            jObject.Optional<double?, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<bool?[], IList<T>>> mapping, Action<bool?, T> merge) 
            where T : class, new() =>
            jObject.Optional<bool?, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<DateTime?[], IList<T>>> mapping, Action<DateTime?, T> merge) 
            where T : class, new() =>
            jObject.Optional<DateTime?, T>(mapping, merge);

        public static JObject Optional<T>(this JObject jObject, Expression<Func<JObject[], IList<T>>> mapping, Action<JObject, T> merge)
            where T : class, new() =>
            jObject.Optional<JObject, T>(mapping, merge);

        static JObject Optional<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping, Action<TSource, TTarget> merge)
            where TTarget : class, new()
        {
            jObject.TryMerge(mapping, merge);
            return jObject;
        }
    }
}
