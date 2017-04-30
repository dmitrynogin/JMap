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
        public static JTask Required<T>(this JTask jTask, Expression<Func<string, T>> mapping, Action<string, T> merge)
            where T : class =>
            jTask.Required<string, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int, T>> mapping, Action<int, T> merge)
            where T : class =>
            jTask.Required<int, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long, T>> mapping, Action<long, T> merge)
            where T : class =>
            jTask.Required<long, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float, T>> mapping, Action<float, T> merge)
            where T : class =>
            jTask.Required<float, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double, T>> mapping, Action<double, T> merge)
            where T : class =>
            jTask.Required<double, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool, T>> mapping, Action<bool, T> merge)
            where T : class =>
            jTask.Required<bool, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime, T>> mapping, Action<DateTime, T> merge)
            where T : class =>
            jTask.Required<DateTime, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int?, T>> mapping, Action<int?, T> merge)
            where T : class =>
            jTask.Required<int?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long?, T>> mapping, Action<long?, T> merge)
            where T : class =>
            jTask.Required<long?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float?, T>> mapping, Action<float?, T> merge)
            where T : class =>
            jTask.Required<float?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double?, T>> mapping, Action<double?, T> merge)
            where T : class =>
            jTask.Required<double?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool?, T>> mapping, Action<bool?, T> merge)
            where T : class =>
            jTask.Required<bool?, T>(mapping, merge);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime?, T>> mapping, Action<DateTime?, T> merge)
            where T : class =>
            jTask.Required<DateTime?, T>(mapping, merge);

        //public static JTask Required<T>(this JTask jTask, Expression<Func<JObject, T>> mapping, Action<JObject, T> merge)
        //    where T : class =>
        //    jTask.Required<JObject, T>(mapping, merge);

        static JTask Required<TSource, TTarget>(this JTask jTask, Mapping<TSource, TTarget> mapping, Action<TSource, TTarget> merge)
            where TTarget : class
        {
            if (!jTask.TryMerge(mapping, merge))
                throw new MissingFieldException(mapping.Field);

            return jTask;
        }
    }
}
