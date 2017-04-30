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
        public static JTask Optional<T>(this JTask jTask, Expression<Func<string, T>> mapping, Action<string, T> merge) 
            where T : class =>
            jTask.Optional<string, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int, T>> mapping, Action<int, T> merge) 
            where T : class =>
            jTask.Optional<int, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long, T>> mapping, Action<long, T> merge) 
            where T : class =>
            jTask.Optional<long, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float, T>> mapping, Action<float, T> merge) 
            where T : class =>
            jTask.Optional<float, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double, T>> mapping, Action<double, T> merge) 
            where T : class =>
            jTask.Optional<double, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool, T>> mapping, Action<bool, T> merge)
            where T : class =>
            jTask.Optional<bool, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime, T>> mapping, Action<DateTime, T> merge) 
            where T : class =>
            jTask.Optional<DateTime, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int?, T>> mapping, Action<int?, T> merge)
            where T : class =>
            jTask.Optional<int?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long?, T>> mapping, Action<long?, T> merge) 
            where T : class =>
            jTask.Optional<long?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float?, T>> mapping, Action<float?, T> merge) 
            where T : class =>
            jTask.Optional<float?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double?, T>> mapping, Action<double?, T> merge) 
            where T : class =>
            jTask.Optional<double?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool?, T>> mapping, Action<bool?, T> merge) 
            where T : class =>
            jTask.Optional<bool?, T>(mapping, merge);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime?, T>> mapping, Action<DateTime?, T> merge) 
            where T : class =>
            jTask.Optional<DateTime?, T>(mapping, merge);

        //public static JTask Optional<T>(this JTask jTask, Expression<Func<JObject, T>> mapping, Action<JObject, T> merge)
        //    where T : class =>
        //    jTask.Optional<JObject, T>(mapping, merge);

        static JTask Optional<TSource, TTarget>(this JTask jTask, Mapping<TSource, TTarget> mapping, Action<TSource, TTarget> merge)
            where TTarget : class
        {
            jTask.TryMerge(mapping, merge);
            return jTask;
        }
    }
}
