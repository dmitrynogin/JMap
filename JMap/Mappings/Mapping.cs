using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    class Mapping<TSource, TTarget>
    {
        public static implicit operator Mapping<TSource, TTarget>(Expression<Func<TSource, TTarget>> mapping) => 
            new Mapping<TSource, TTarget>(mapping);

        public Mapping(Expression<Func<TSource, TTarget>> mapper)
        {
            var newValue = Expression.Parameter(mapper.Body.Type);
            var assign = Expression.Lambda<Action<TSource, TTarget>>(
                Expression.Assign(mapper.Body, newValue),
                mapper.Parameters[0], newValue);

            Field = mapper.Parameters[0].Name;
            Getter = mapper.Compile().Invoke;
            Setter = assign.Compile().Invoke;
        }

        public string Field { get; }

        public TTarget this[TSource source]
        {
            get { return Getter(source); }
            set { Setter(source, value); }
        }

        Func<TSource, TTarget> Getter { get; }
        Action<TSource, TTarget> Setter { get; }
    }
}
