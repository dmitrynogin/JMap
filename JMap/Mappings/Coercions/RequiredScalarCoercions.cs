using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class RequiredScalarCoercions
    {
        public static JTask Required<T>(this JTask jTask, Expression<Func<string, T>> mapping) =>
            jTask.Required<string, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int, T>> mapping) =>
            jTask.Required<int, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long, T>> mapping) =>
            jTask.Required<long, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float, T>> mapping) =>
            jTask.Required<float, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double, T>> mapping) =>
            jTask.Required<double, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool, T>> mapping) =>
            jTask.Required<bool, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime, T>> mapping) =>
            jTask.Required<DateTime, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int?, T>> mapping) =>
            jTask.Required<int?, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long?, T>> mapping) =>
            jTask.Required<long?, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float?, T>> mapping) =>
            jTask.Required<float?, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double?, T>> mapping) =>
            jTask.Required<double?, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool?, T>> mapping) =>
            jTask.Required<bool?, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime?, T>> mapping) =>
            jTask.Required<DateTime?, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<JObject, T>> mapping) =>
            jTask.Required<JObject, T>(mapping);

        static JTask Required<TSource, TTarget>(this JTask jTask, Mapping<TSource, TTarget> mapping)
        {
            if (!jTask.TryCoerce(mapping))
                throw new MissingFieldException($"Required {mapping.Field} field not found in the JSON payload.");

            return jTask;
        }
    }
}
