using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class RequiredArrayCoercions
    {
        public static JTask Required<T>(this JTask jTask, Expression<Func<string[], IList<T>>> mapping) =>
            jTask.Required<string, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int[], IList<T>>> mapping) =>
            jTask.Required<int, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long[], IList<T>>> mapping) =>
            jTask.Required<long, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float[], IList<T>>> mapping) =>
            jTask.Required<float, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double[], IList<T>>> mapping) =>
            jTask.Required<double, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool[], IList<T>>> mapping) =>
            jTask.Required<bool, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime[], IList<T>>> mapping) =>
            jTask.Required<DateTime, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int?[], IList<T>>> mapping) =>
            jTask.Required<int?, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long?[], IList<T>>> mapping) =>
            jTask.Required<long?, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float?[], IList<T>>> mapping) =>
            jTask.Required<float?, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double?[], IList<T>>> mapping) =>
            jTask.Required<double?, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool?[], IList<T>>> mapping) =>
            jTask.Required<bool?, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime?[], IList<T>>> mapping) =>
            jTask.Required<DateTime?, T>(mapping);

        public static JTask Required<T>(this JTask jTask, Expression<Func<JObject[], IList<T>>> mapping) =>
            jTask.Required<JObject, T>(mapping);

        static JTask Required<TSource, TTarget>(this JTask jTask, Mapping<TSource[], IList<TTarget>> mapping)
        {
            if (!jTask.TryCoerce(mapping))
                throw new MissingFieldException(mapping.Field);

            return jTask;
        }
    }
}
