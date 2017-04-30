using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class OptionalScalarCoercions
    {
        public static JTask Optional<T>(this JTask jTask, Expression<Func<string, T>> mapping) =>
            jTask.Optional<string, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int, T>> mapping) =>
            jTask.Optional<int, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long, T>> mapping) =>
            jTask.Optional<long, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float, T>> mapping) =>
            jTask.Optional<float, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double, T>> mapping) =>
            jTask.Optional<double, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool, T>> mapping) =>
            jTask.Optional<bool, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime, T>> mapping) =>
            jTask.Optional<DateTime, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<int?, T>> mapping) =>
            jTask.Optional<int?, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<long?, T>> mapping) =>
            jTask.Optional<long?, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<float?, T>> mapping) =>
            jTask.Optional<float?, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<double?, T>> mapping) =>
            jTask.Optional<double?, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<bool?, T>> mapping) =>
            jTask.Optional<bool?, T>(mapping);

        public static JTask Optional<T>(this JTask jTask, Expression<Func<DateTime?, T>> mapping) =>
            jTask.Optional<DateTime?, T>(mapping);
        
        public static JTask Optional<T>(this JTask jTask, Expression<Func<JObject, T>> mapping) =>
            jTask.Optional<JObject, T>(mapping);

        static JTask Optional<TSource, TTarget>(this JTask jTask, Mapping<TSource, TTarget> mapping)
        {
            jTask.TryCoerce(mapping);
            return jTask;
        }
    }
}
