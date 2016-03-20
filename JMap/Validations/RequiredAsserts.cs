using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class RequiredAsserts
    {
        public static JObject RequiredAssert(this JObject jObject, Expression<Predicate<string>> assert) =>
             jObject.RequiredAssert<string>(assert);

        public static JObject RequiredAssert(this JObject jObject, Expression<Predicate<int>> assert) =>
            jObject.RequiredAssert<int>(assert);

        public static JObject RequiredAssert(this JObject jObject, Expression<Predicate<JObject>> assert) =>
            jObject.RequiredAssert<JObject>(assert);

        static JObject RequiredAssert<T>(this JObject jObject, Assert<T> assert)
        {
            if (!jObject.TryAssert(assert))
                throw new MissingFieldException(assert.Field);

            return jObject;
        }
    }
}
