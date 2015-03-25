using System;
namespace TestExRestaurant.Monades
{
    public static class Maybe
    {
        public static TInput If<TInput>(this TInput o, Func<TInput, bool> evaluator)
            where TInput : class
        {
            if (o == null) return null;
            return evaluator(o) ? o : null;
        }

        public static TInput Unless<TInput>(this TInput o, Func<TInput, bool> evaluator)
               where TInput : class
        {
            if (o == null) return null;
            return evaluator(o) ? null : o;
        }

        public static TOut IfNotNull<TIn, TOut>(
            this TIn v, Func<TIn, TOut> f)
                    where TIn : class
                    where TOut : class
        {
            if (v == null)
                return null;

            return f(v);
        }
    }
}
