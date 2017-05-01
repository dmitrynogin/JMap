using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class AsyncOptionalScalarMerges
    {
        public static JTask Optional<T>(this JTask jTask, Expression<Func<string, T>> mapping, Func<string, T, Task> merge) 
            where T : class =>
            jTask.Optional<string, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int, T>> mapping, Func<int, T, Task> merge) 
            where T : class =>
            jTask.Optional<int, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long, T>> mapping, Func<long, T, Task> merge) 
            where T : class =>
            jTask.Optional<long, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float, T>> mapping, Func<float, T, Task> merge) 
            where T : class =>
            jTask.Optional<float, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double, T>> mapping, Func<double, T, Task> merge) 
            where T : class =>
            jTask.Optional<double, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool, T>> mapping, Func<bool, T, Task> merge)
            where T : class =>
            jTask.Optional<bool, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime, T>> mapping, Func<DateTime, T, Task> merge) 
            where T : class =>
            jTask.Optional<DateTime, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int?, T>> mapping, Func<int?, T, Task> merge)
            where T : class =>
            jTask.Optional<int?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long?, T>> mapping, Func<long?, T, Task> merge) 
            where T : class =>
            jTask.Optional<long?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float?, T>> mapping, Func<float?, T, Task> merge) 
            where T : class =>
            jTask.Optional<float?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double?, T>> mapping, Func<double?, T, Task> merge) 
            where T : class =>
            jTask.Optional<double?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool?, T>> mapping, Func<bool?, T, Task> merge) 
            where T : class =>
            jTask.Optional<bool?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime?, T>> mapping, Func<DateTime?, T, Task> merge) 
            where T : class =>
            jTask.Optional<DateTime?, T>(mapping, merge);

        static JTask Optional<TSource, TTarget>(this JTask jTask, Mapping<TSource, TTarget> mapping, Func<TSource, TTarget, Task> merge)
            where TTarget : class
        {
            return jTask + jTask.TryMergeAsync(mapping, merge);
        }
        
        public static JTask Optional<T>(this JTask jTask, Expression<Func<JObject, T>> mapping, Func<JTask, T, Task> merge)
            where T : class
        {
            return jTask + jTask.TryMergeAsync(mapping, 
                (JObject source, T target) => merge(source.MapAsync(), target));
        }
    }
}
