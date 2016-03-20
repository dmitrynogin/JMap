using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public static class OptionalAsserts
    {
        public static JObject OptionalAssert(this JObject jObject, Expression<Predicate<string>> assert) =>
             jObject.OptionalAssert<string>(assert);

        public static JObject OptionalAssert(this JObject jObject, Expression<Predicate<int>> assert) =>
            jObject.OptionalAssert<int>(assert);

        public static JObject OptionalAssert(this JObject jObject, Expression<Predicate<JObject>> assert) =>
            jObject.OptionalAssert<JObject>(assert);

        static JObject OptionalAssert<T>(this JObject jObject, Assert<T> assert)
        {
            jObject.TryAssert(assert);
            return jObject;
        }
    }
}
