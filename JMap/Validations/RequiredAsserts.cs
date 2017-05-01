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
        public static JTask RequiredAssert(this JTask jTask, Expression<Predicate<string>> assert) =>
             jTask.RequiredAssert<string>(assert);

        public static JTask RequiredAssert(this JTask jTask, Expression<Predicate<int>> assert) =>
            jTask.RequiredAssert<int>(assert);

        public static JTask RequiredAssert(this JTask jTask, Expression<Predicate<JObject>> assert) =>
            jTask.RequiredAssert<JObject>(assert);

        static JTask RequiredAssert<T>(this JTask jTask, Assert<T> assert)
        {
            if (!jTask.TryAssert(assert))
                throw new MissingFieldException(assert.Field);

            return jTask;
        }
    }
}
