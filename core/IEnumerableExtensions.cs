using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Executes a method on every element in the enumerable.
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> oEnumerable, Action<T> pfFunc)
        {
            foreach (T o in oEnumerable)
                pfFunc(o);
        }

        /// <summary>
        /// Executes a method on every element in the enumerable.
        /// </summary>
        public static TRet ForEach<TRet, T>(this IEnumerable<T> oEnumerable, TRet ret, Action<TRet, T> pfFunc)
        {
            foreach (T o in oEnumerable)
                pfFunc(ret, o);
            return ret;
        }
    }
}
