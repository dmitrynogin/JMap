using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class AsyncOptionalArrayMerges
    {
        public static JTask Optional<T>(this JTask jTask, Expression<Func<string[], IList<T>>> mapping, Func<string, T, Task> merge) 
            where T : class, new() =>
            jTask.Optional<string, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int[], IList<T>>> mapping, Func<int, T, Task> merge) 
            where T : class, new() =>
            jTask.Optional<int, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long[], IList<T>>> mapping, Func<long, T, Task> merge) 
            where T : class, new() =>
            jTask.Optional<long, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float[], IList<T>>> mapping, Func<float, T, Task> merge) 
            where T : class, new() =>
            jTask.Optional<float, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double[], IList<T>>> mapping, Func<double, T, Task> merge) 
            where T : class, new() =>
            jTask.Optional<double, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool[], IList<T>>> mapping, Func<bool, T, Task> merge) 
            where T : class, new() =>
            jTask.Optional<bool, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime[], IList<T>>> mapping, Func<DateTime, T, Task> merge) 
            where T : class, new() =>
            jTask.Optional<DateTime, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int?[], IList<T>>> mapping, Func<int?, T, Task> merge) 
            where T : class, new() =>
            jTask.Optional<int?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long?[], IList<T>>> mapping, Func<long?, T, Task> merge) 
            where T : class, new() =>
            jTask.Optional<long?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float?[], IList<T>>> mapping, Func<float?, T, Task> merge) 
            where T : class, new() =>
            jTask.Optional<float?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double?[], IList<T>>> mapping, Func<double?, T, Task> merge) 
            where T : class, new() =>
            jTask.Optional<double?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool?[], IList<T>>> mapping, Func<bool?, T, Task> merge) 
            where T : class, new() =>
            jTask.Optional<bool?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime?[], IList<T>>> mapping, Func<DateTime?, T, Task> merge) 
            where T : class, new() =>
            jTask.Optional<DateTime?, T>(mapping, merge);

        static JTask Optional<TSource, TTarget>(this JTask jTask, Mapping<TSource[], IList<TTarget>> mapping, Func<TSource, TTarget, Task> merge)
            where TTarget : class, new()
        {
            return jTask + jTask.TryMergeAsync(mapping, merge);
        }

        public static JTask Optional<T>(this JTask jTask, Expression<Func<JObject[], IList<T>>> mapping, Func<JTask, T, Task> merge)
            where T : class, new()
        {
            return jTask + jTask.TryMergeAsync(mapping,
                (JObject source, T target) => merge(source.MapAsync(), target));
        }
    }
}
