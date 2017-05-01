using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class AsyncRequiredArrayMerges
    {
        public static JTask Required<T>(this JTask jTask, Expression<Func<string[], IList<T>>> mapping, Func<string, T, Task> merge)
            where T : class, new() =>
            jTask.Required<string, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int[], IList<T>>> mapping, Func<int, T, Task> merge)
            where T : class, new() =>
            jTask.Required<int, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long[], IList<T>>> mapping, Func<long, T, Task> merge)
            where T : class, new() =>
            jTask.Required<long, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float[], IList<T>>> mapping, Func<float, T, Task> merge)
            where T : class, new() =>
            jTask.Required<float, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double[], IList<T>>> mapping, Func<double, T, Task> merge)
            where T : class, new() =>
            jTask.Required<double, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool[], IList<T>>> mapping, Func<bool, T, Task> merge)
            where T : class, new() =>
            jTask.Required<bool, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime[], IList<T>>> mapping, Func<DateTime, T, Task> merge)
            where T : class, new() =>
            jTask.Required<DateTime, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int?[], IList<T>>> mapping, Func<int?, T, Task> merge)
            where T : class, new() =>
            jTask.Required<int?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long?[], IList<T>>> mapping, Func<long?, T, Task> merge)
            where T : class, new() =>
            jTask.Required<long?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float?[], IList<T>>> mapping, Func<float?, T, Task> merge)
            where T : class, new() =>
            jTask.Required<float?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double?[], IList<T>>> mapping, Func<double?, T, Task> merge)
            where T : class, new() =>
            jTask.Required<double?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool?[], IList<T>>> mapping, Func<bool?, T, Task> merge)
            where T : class, new() =>
            jTask.Required<bool?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime?[], IList<T>>> mapping, Func<DateTime?, T, Task> merge)
            where T : class, new() =>
            jTask.Required<DateTime?, T>(mapping, merge);

         static JTask Required<TSource, TTarget>(this JTask jTask, Mapping<TSource[], IList<TTarget>> mapping, Func<TSource, TTarget, Task> merge)
            where TTarget : class, new() =>
            jTask + jTask.TryMergeAsync(mapping, merge)
                .ContinueWith(t =>
                {
                    if (!t.Result)
                        throw new MissingFieldException(mapping.Field);
                });

        public static JTask Required<T>(this JTask jTask, Expression<Func<JObject[], IList<T>>> mapping, Func<JObject, T, Task> merge)
            where T : class, new() =>
            jTask + jTask.TryMergeAsync(mapping,
                (JObject source, T target) => merge(source.MapAsync(), target))
                .ContinueWith(t =>
                {
                    if (!t.Result)
                        throw new MissingFieldException(new Mapping<JObject[], IList<T>>(mapping).Field);
                });        
    }
}
