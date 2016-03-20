using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    class Assert<T>
    {
        public static implicit operator Assert<T>(Expression<Predicate<T>> predicate) =>
            new Assert<T>(predicate);

        public Assert(Expression<Predicate<T>> predicate)
        {
            Field = predicate.Parameters[0].Name;
            Getter = predicate.Compile().Invoke;
        }

        public string Field { get; }

        public bool this[T value] => Getter(value);

        Func<T, bool> Getter { get; }
    }
}
