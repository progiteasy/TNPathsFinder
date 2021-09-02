using TNPathsFinder.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace TNPathsFinder.Models
{
    /// <summary>
    /// Класс для представления модели маршрута общественного транспорта
    /// </summary>
    public class TransportRoute
    {
        /// <summary>
        /// Список остановок на маршруте
        /// </summary>
        public ReadOnlyCollection<TransportStop> TransportStops { get; }

        /// <summary>
        /// Список временных интервалов между остановками
        /// </summary>
        public ReadOnlyCollection<TimeSpan> TimeIntervals { get; }

        /// <summary>
        /// Суммарное время поездки по маршруту
        /// </summary>
        public TimeSpan TripTotalTime
            => TimeIntervals.Sum();

        /// <summary>
        /// Конструктор класса с заданными параметрами
        /// </summary>
        /// <param name="transportStops">Массив остановок на маршруте</param>
        /// <param name="timeIntervals">Массив интервалов времени между остановками</param>
        public TransportRoute(TransportStop[] transportStops, int[] timeIntervals)
        {
            TransportStops = new ReadOnlyCollection<TransportStop>(new List<TransportStop>(transportStops) { transportStops[0] });
            TimeIntervals = new ReadOnlyCollection<TimeSpan>(timeIntervals.Select(timeInterval => TimeSpan.FromMinutes(timeInterval)).ToArray());
        }

        /// <summary>
        /// Метод приведения объекта к строке
        /// </summary>
        /// <returns>Строка, содержащая все остановки на маршруте и интервалы времени между ними</returns>
        public override string ToString()
            => $"{String.Join(" => ", TransportStops.Zip(TimeIntervals, (stop, timeInterval) => $"{stop.Id} = ({(int)timeInterval.TotalMinutes} мин.)"))} => {TransportStops.First().Id}";
    }
}