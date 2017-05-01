using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class AsyncOptionalArrayConversions
    {
        public static JTask Optional<T>(this JTask jTask, Expression<Func<string[], IList<T>>> mapping, Func<string, Task<T>> conversion) =>
            jTask.Optional<string, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int[], IList<T>>> mapping, Func<int, Task<T>> conversion) =>
            jTask.Optional<int, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long[], IList<T>>> mapping, Func<long, Task<T>> conversion) =>
            jTask.Optional<long, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float[], IList<T>>> mapping, Func<float, Task<T>> conversion) =>
            jTask.Optional<float, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double[], IList<T>>> mapping, Func<double, Task<T>> conversion) =>
            jTask.Optional<double, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool[], IList<T>>> mapping, Func<bool, Task<T>> conversion) =>
            jTask.Optional<bool, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime[], IList<T>>> mapping, Func<DateTime, Task<T>> conversion) =>
            jTask.Optional<DateTime, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int?[], IList<T>>> mapping, Func<int?, Task<T>> conversion) =>
            jTask.Optional<int?, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long?[], IList<T>>> mapping, Func<long?, Task<T>> conversion) =>
            jTask.Optional<long?, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float?[], IList<T>>> mapping, Func<float?, Task<T>> conversion) =>
            jTask.Optional<float?, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double?[], IList<T>>> mapping, Func<double?, Task<T>> conversion) =>
            jTask.Optional<double?, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool?[], IList<T>>> mapping, Func<bool?, Task<T>> conversion) =>
            jTask.Optional<bool?, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime?[], IList<T>>> mapping, Func<DateTime?, Task<T>> conversion) =>
            jTask.Optional<DateTime?, T>(mapping, conversion);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<JObject[], IList<T>>> mapping, Func<JObject, Task<T>> conversion) =>
            jTask.Optional<JObject, T>(mapping, conversion);
        
        static JTask Optional<TSource, TTarget>(this JTask jTask, Mapping<TSource[], IList<TTarget>> mapping, Func<TSource, Task<TTarget>> conversion)
        {            
            return jTask + jTask.TryConvertAsync(mapping, conversion);
        }
    }
}
