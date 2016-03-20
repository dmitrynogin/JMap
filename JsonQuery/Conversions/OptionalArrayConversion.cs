﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuery
{
    public static class OptionalArrayConversion
    {
        public static JObject Try<T>(this JObject jObject, Expression<Func<string[], IList<T>>> mapping, Func<string, T> conversion) =>
            jObject.Try<string, T>(mapping, conversion);

        public static JObject Try<T>(this JObject jObject, Expression<Func<int[], IList<T>>> mapping, Func<int, T> conversion) =>
            jObject.Try<int, T>(mapping, conversion);

        public static JObject Try<T>(this JObject jObject, Expression<Func<JObject[], IList<T>>> mapping, Func<JObject, T> conversion) =>
            jObject.Try<JObject, T>(mapping, conversion);
        
        static JObject Try<TSource, TTarget>(this JObject jObject, Mapping<TSource[], IList<TTarget>> mapping, Func<TSource, TTarget> conversion)
        {
            jObject.TryConvert(mapping, conversion);
            return jObject;
        }
    }
}