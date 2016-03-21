using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class RequiredArrayMerges
    {
        public static JObject Required<T>(this JObject jObject, Expression<Func<string[], IList<T>>> mapping, Action<string, T> merge)
            where T : class, new() =>
            jObject.Required<string, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<int[], IList<T>>> mapping, Action<int, T> merge)
            where T : class, new() =>
            jObject.Required<int, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<long[], IList<T>>> mapping, Action<long, T> merge)
            where T : class, new() =>
            jObject.Required<long, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<float[], IList<T>>> mapping, Action<float, T> merge)
            where T : class, new() =>
            jObject.Required<float, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<double[], IList<T>>> mapping, Action<double, T> merge)
            where T : class, new() =>
            jObject.Required<double, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<bool[], IList<T>>> mapping, Action<bool, T> merge)
            where T : class, new() =>
            jObject.Required<bool, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<DateTime[], IList<T>>> mapping, Action<DateTime, T> merge)
            where T : class, new() =>
            jObject.Required<DateTime, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<int?[], IList<T>>> mapping, Action<int?, T> merge)
            where T : class, new() =>
            jObject.Required<int?, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<long?[], IList<T>>> mapping, Action<long?, T> merge)
            where T : class, new() =>
            jObject.Required<long?, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<float?[], IList<T>>> mapping, Action<float?, T> merge)
            where T : class, new() =>
            jObject.Required<float?, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<double?[], IList<T>>> mapping, Action<double?, T> merge)
            where T : class, new() =>
            jObject.Required<double?, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<bool?[], IList<T>>> mapping, Action<bool?, T> merge)
            where T : class, new() =>
            jObject.Required<bool?, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<DateTime?[], IList<T>>> mapping, Action<DateTime?, T> merge)
            where T : class, new() =>
            jObject.Required<DateTime?, T>(mapping, merge);

        public static JObject Required<T>(this JObject jObject, Expression<Func<JObject[], IList<T>>> mapping, Action<JObject, T> merge)
            where T : class, new() =>
            jObject.Required<JObject, T>(mapping, merge);

        static JObject Required<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping, Action<TSource, TTarget> merge)
            where TTarget : class, new()
        {
            if (!jObject.TryMerge(mapping, merge))
                throw new MissingFieldException(mapping.Field);

            return jObject;
        }
    }
}
