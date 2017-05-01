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
        public static JTask OptionalAssert(this JTask jTask, Expression<Predicate<string>> assert) =>
             jTask.OptionalAssert<string>(assert);

        public static JTask OptionalAssert(this JTask jTask, Expression<Predicate<int>> assert) =>
            jTask.OptionalAssert<int>(assert);

        public static JTask OptionalAssert(this JTask jTask, Expression<Predicate<JObject>> assert) =>
            jTask.OptionalAssert<JObject>(assert);

        static JTask OptionalAssert<T>(this JTask jTask, Assert<T> assert)
        {
            jTask.TryAssert(assert);
            return jTask;
        }
    }
}
