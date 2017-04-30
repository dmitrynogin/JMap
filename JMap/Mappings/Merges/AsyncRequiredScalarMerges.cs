using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class AsyncRequiredScalarMerges
    {
        public static JTask Required<T>(this JTask jTask, Expression<Func<string, T>> mapping, Func<string, T, Task> merge)
            where T : class =>
            jTask.Required<string, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int, T>> mapping, Func<int, T, Task> merge)
            where T : class =>
            jTask.Required<int, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long, T>> mapping, Func<long, T, Task> merge)
            where T : class =>
            jTask.Required<long, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float, T>> mapping, Func<float, T, Task> merge)
            where T : class =>
            jTask.Required<float, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double, T>> mapping, Func<double, T, Task> merge)
            where T : class =>
            jTask.Required<double, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool, T>> mapping, Func<bool, T, Task> merge)
            where T : class =>
            jTask.Required<bool, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime, T>> mapping, Func<DateTime, T, Task> merge)
            where T : class =>
            jTask.Required<DateTime, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int?, T>> mapping, Func<int?, T, Task> merge)
            where T : class =>
            jTask.Required<int?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long?, T>> mapping, Func<long?, T, Task> merge)
            where T : class =>
            jTask.Required<long?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float?, T>> mapping, Func<float?, T, Task> merge)
            where T : class =>
            jTask.Required<float?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double?, T>> mapping, Func<double?, T, Task> merge)
            where T : class =>
            jTask.Required<double?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool?, T>> mapping, Func<bool?, T, Task> merge)
            where T : class =>
            jTask.Required<bool?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime?, T>> mapping, Func<DateTime?, T, Task> merge)
            where T : class =>
            jTask.Required<DateTime?, T>(mapping, merge);

        static JTask Required<TSource, TTarget>(this JTask jTask, Mapping<TSource, TTarget> mapping, Func<TSource, TTarget, Task> merge)
            where TTarget : class =>
            jTask + jTask.TryMergeAsync(mapping, merge)
                .ContinueWith(t =>
                {
                    if (!t.Result)
                        throw new MissingFieldException(mapping.Field);
                });

        public static JTask Required<T>(this JTask jTask, Expression<Func<JObject, T>> mapping, Func<JTask, T, Task> merge)
            where T : class, new() =>
            jTask + jTask.TryMergeAsync(mapping,
                (JObject source, T target) => merge(source.MapAsync(), target))
                .ContinueWith(t =>
                {
                    if (!t.Result)
                        throw new MissingFieldException(new Mapping<JObject, T>(mapping).Field);
                });
    }
}
