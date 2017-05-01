using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class AsyncOptionalScalarConverions
    {
        public static JTask Optional<T>(this JTask jTask, Expression<Func<string, T>> mapping, Func<string, Task<T>> conversion) =>
            jTask.Optional<string, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int, T>> mapping, Func<int, Task<T>> conversion) =>
            jTask.Optional<int, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long, T>> mapping, Func<long, Task<T>> conversion) =>
            jTask.Optional<long, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float, T>> mapping, Func<float, Task<T>> conversion) =>
            jTask.Optional<float, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double, T>> mapping, Func<double, Task<T>> conversion) =>
            jTask.Optional<double, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool, T>> mapping, Func<bool, Task<T>> conversion) =>
            jTask.Optional<bool, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime, T>> mapping, Func<DateTime, Task<T>> conversion) =>
            jTask.Optional<DateTime, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int?, T>> mapping, Func<int?, Task<T>> conversion) =>
            jTask.Optional<int?, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long?, T>> mapping, Func<long?, Task<T>> conversion) =>
            jTask.Optional<long?, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float?, T>> mapping, Func<float?, Task<T>> conversion) =>
            jTask.Optional<float?, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double?, T>> mapping, Func<double?, Task<T>> conversion) =>
            jTask.Optional<double?, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool?, T>> mapping, Func<bool?, Task<T>> conversion) =>
            jTask.Optional<bool?, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime?, T>> mapping, Func<DateTime?, Task<T>> conversion) =>
            jTask.Optional<DateTime?, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<JObject, T>> mapping, Func<JObject, Task<T>> conversion) =>
            jTask.Optional<JObject, T>(mapping, conversion);

        static JTask Optional<TSource, TTarget>(this JTask jTask, Mapping<TSource, TTarget> mapping, Func<TSource, Task<TTarget>> conversion)
        {            
            return jTask + jTask.TryConvertAsync(mapping, conversion);
        }
    }
}
