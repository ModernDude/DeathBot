using System.Collections.Generic;
using System.Linq;

namespace DeathBot.Bot
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Create a cartesian product of an arbitrary number of sequences.
        /// 
        /// Function courtesy of Eric Lippert
        /// http://stackoverflow.com/questions/3093622/generating-all-possible-combinations
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequences"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] {Enumerable.Empty<T>()};
            return sequences.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                from accseq in accumulator
                from item in sequence
                select accseq.Concat(new[] {item}));
        }
    }
}