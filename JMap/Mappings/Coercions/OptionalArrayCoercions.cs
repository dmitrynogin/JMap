using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class OptionalArrayCoercions
    {
        public static JTask Optional<T>(this JTask jTask, Expression<Func<string[], IList<T>>> mapping) =>
            jTask.Optional<string, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int[], IList<T>>> mapping) =>
            jTask.Optional<int, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long[], IList<T>>> mapping) =>
            jTask.Optional<long, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float[], IList<T>>> mapping) =>
            jTask.Optional<float, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double[], IList<T>>> mapping) =>
            jTask.Optional<double, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool[], IList<T>>> mapping) =>
            jTask.Optional<bool, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime[], IList<T>>> mapping) =>
            jTask.Optional<DateTime, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int?[], IList<T>>> mapping) =>
            jTask.Optional<int?, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long?[], IList<T>>> mapping) =>
            jTask.Optional<long?, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float?[], IList<T>>> mapping) =>
            jTask.Optional<float?, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double?[], IList<T>>> mapping) =>
            jTask.Optional<double?, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool?[], IList<T>>> mapping) =>
            jTask.Optional<bool?, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime?[], IList<T>>> mapping) =>
            jTask.Optional<DateTime?, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<JObject[], IList<T>>> mapping) =>
            jTask.Optional<JObject, T>(mapping);

        static JTask Optional<TSource, TTarget>(this JTask jTask, Mapping<TSource[], IList<TTarget>> mapping)
        {
            jTask.TryCoerce(mapping);
            return jTask;
        }
    }
}
