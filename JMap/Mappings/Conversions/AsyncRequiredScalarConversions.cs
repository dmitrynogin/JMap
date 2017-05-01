using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class AsyncRequiredScalarConversions
    {
        public static JTask Required<T>(this JTask jTask, Expression<Func<string, T>> mapping, Func<string, Task<T>> conversion) =>
            jTask.Required<string, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int, T>> mapping, Func<int, Task<T>> conversion) =>
            jTask.Required<int, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long, T>> mapping, Func<long, Task<T>> conversion) =>
            jTask.Required<long, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float, T>> mapping, Func<float, Task<T>> conversion) =>
            jTask.Required<float, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double, T>> mapping, Func<double, Task<T>> conversion) =>
            jTask.Required<double, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool, T>> mapping, Func<bool, Task<T>> conversion) =>
            jTask.Required<bool, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime, T>> mapping, Func<DateTime, Task<T>> conversion) =>
            jTask.Required<DateTime, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int?, T>> mapping, Func<int?, Task<T>> conversion) =>
            jTask.Required<int?, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long?, T>> mapping, Func<long?, Task<T>> conversion) =>
            jTask.Required<long?, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float?, T>> mapping, Func<float?, Task<T>> conversion) =>
            jTask.Required<float?, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double?, T>> mapping, Func<double?, Task<T>> conversion) =>
            jTask.Required<double?, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool?, T>> mapping, Func<bool?, Task<T>> conversion) =>
            jTask.Required<bool?, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime?, T>> mapping, Func<DateTime?, Task<T>> conversion) =>
            jTask.Required<DateTime?, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<JObject, T>> mapping, Func<JObject, Task<T>> conversion) =>
            jTask.Required<JObject, T>(mapping, conversion);

        static JTask Required<TSource, TTarget>(this JTask jTask, Mapping<TSource, TTarget> mapping, Func<TSource, Task<TTarget>> conversion) =>
            jTask + jTask.TryConvertAsync(mapping, conversion)
                .ContinueWith(t =>
                {
                    if (!t.Result)
                        throw new MissingFieldException(mapping.Field);
                });
    }
}
