using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class RequiredScalarConversions
    {
        public static JTask Required<T>(this JTask jTask, Expression<Func<string, T>> mapping, Func<string, T> conversion) =>
            jTask.Required<string, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int, T>> mapping, Func<int, T> conversion) =>
            jTask.Required<int, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long, T>> mapping, Func<long, T> conversion) =>
            jTask.Required<long, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float, T>> mapping, Func<float, T> conversion) =>
            jTask.Required<float, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double, T>> mapping, Func<double, T> conversion) =>
            jTask.Required<double, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool, T>> mapping, Func<bool, T> conversion) =>
            jTask.Required<bool, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime, T>> mapping, Func<DateTime, T> conversion) =>
            jTask.Required<DateTime, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<int?, T>> mapping, Func<int?, T> conversion) =>
            jTask.Required<int?, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<long?, T>> mapping, Func<long?, T> conversion) =>
            jTask.Required<long?, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<float?, T>> mapping, Func<float?, T> conversion) =>
            jTask.Required<float?, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<double?, T>> mapping, Func<double?, T> conversion) =>
            jTask.Required<double?, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<bool?, T>> mapping, Func<bool?, T> conversion) =>
            jTask.Required<bool?, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<DateTime?, T>> mapping, Func<DateTime?, T> conversion) =>
            jTask.Required<DateTime?, T>(mapping, conversion);

        public static JTask Required<T>(this JTask jTask, Expression<Func<JObject, T>> mapping, Func<JObject, T> conversion) =>
            jTask.Required<JObject, T>(mapping, conversion);

        static JTask Required<TSource, TTarget>(this JTask jTask, Mapping<TSource, TTarget> mapping, Func<TSource, TTarget> conversion)
        {
            if (!jTask.TryConvert(mapping, conversion))
                throw new MissingFieldException(mapping.Field);

            return jTask;
        }
    }
}
