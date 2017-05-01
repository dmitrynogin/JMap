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
        public static JTask Required<T>(this JTask jTask, Expression<Func<string[], IList<T>>> mapping, Action<string, T> merge)
            where T : class, new() =>
            jTask.Required<string, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int[], IList<T>>> mapping, Action<int, T> merge)
            where T : class, new() =>
            jTask.Required<int, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long[], IList<T>>> mapping, Action<long, T> merge)
            where T : class, new() =>
            jTask.Required<long, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float[], IList<T>>> mapping, Action<float, T> merge)
            where T : class, new() =>
            jTask.Required<float, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double[], IList<T>>> mapping, Action<double, T> merge)
            where T : class, new() =>
            jTask.Required<double, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool[], IList<T>>> mapping, Action<bool, T> merge)
            where T : class, new() =>
            jTask.Required<bool, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime[], IList<T>>> mapping, Action<DateTime, T> merge)
            where T : class, new() =>
            jTask.Required<DateTime, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int?[], IList<T>>> mapping, Action<int?, T> merge)
            where T : class, new() =>
            jTask.Required<int?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long?[], IList<T>>> mapping, Action<long?, T> merge)
            where T : class, new() =>
            jTask.Required<long?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float?[], IList<T>>> mapping, Action<float?, T> merge)
            where T : class, new() =>
            jTask.Required<float?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double?[], IList<T>>> mapping, Action<double?, T> merge)
            where T : class, new() =>
            jTask.Required<double?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool?[], IList<T>>> mapping, Action<bool?, T> merge)
            where T : class, new() =>
            jTask.Required<bool?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime?[], IList<T>>> mapping, Action<DateTime?, T> merge)
            where T : class, new() =>
            jTask.Required<DateTime?, T>(mapping, merge);

        //public static JTask Required<T>(this JTask jTask, Expression<Func<JObject[], IList<T>>> mapping, Action<JObject, T> merge)
        //    where T : class, new() =>
        //    jTask.Required<JObject, T>(mapping, merge);

        static JTask Required<TSource, TTarget>(this JTask jTask, Mapping<TSource[], IList<TTarget>> mapping, Action<TSource, TTarget> merge)
            where TTarget : class, new()
        {
            if (!jTask.TryMerge(mapping, merge))
                throw new MissingFieldException(mapping.Field);

            return jTask;
        }
    }
}
