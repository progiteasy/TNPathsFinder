using System;
using System.Collections.Generic;
using System.Linq;

namespace TNPathsFinder.Extensions
{
    /// <summary>
    /// Статический класс для представления методов-расширений для коллекций IEnumerable
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Метод суммирования всех элементов коллекции TimeSpan
        /// </summary>
        /// <param name="timeSpanCollection">Коллекция элементов TimeSpan</param>
        /// <returns>Сумма элементов коллекции в виде объекта TimeSpan</returns>
        public static TimeSpan Sum(this IEnumerable<TimeSpan> timeSpanCollection)
            => timeSpanCollection.Aggregate(TimeSpan.Zero, (subtotal, currentTime) => subtotal.Add(currentTime));

        /// <summary>
        /// Метод декартова произведения коллекций
        /// </summary>
        /// <param name="sequenceCollection">Коллекция объектов IEnumerable, для которых нужно найти декартово произведения</param>
        /// <returns>Декартово произведение заданных коллекций</returns>
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequenceCollection)
        {
            IEnumerable<IEnumerable<T>> tempCollection = new List<IEnumerable<T>>() { Enumerable.Empty<T>() };

            return sequenceCollection.Aggregate(tempCollection, (accumulator, sequence) =>
                from accumulatorSequence in accumulator
                from sequenceItem in sequence
                select accumulatorSequence.Concat(new List<T> { sequenceItem })
            );
        }
    }
}