using System;
using System.Linq;
using TNPathsFinder.Extensions;

namespace TNPathsFinder.Models
{
    /// <summary>
    /// Абстрактный класс для представления модели транспортного средства
    /// </summary>
    public abstract class TransportVehicle
    {
        /// <summary>
        /// Время окончания текущего дня
        /// </summary>
        private readonly TimeSpan CurrentDayEndTime = new TimeSpan(24, 0, 0);

        /// <summary>
        /// Идентификатор транспортного средства
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Стоимость проездного билета
        /// </summary>
        public int TicketPrice { get; }

        /// <summary>
        /// Время работы
        /// </summary>
        public (TimeSpan Start, TimeSpan End) OperatingHours { get; }

        /// <summary>
        /// Маршрут
        /// </summary>
        public TransportRoute Route { get; }
        
        /// <summary>
        /// Описание транспортного средства, содержащее его номер
        /// </summary>
        public virtual string Description => $"{Id}";

        /// <summary>
        /// Метод расчёта времени окончания работы
        /// </summary>
        /// <param name="operatingHoursStart">Время начала работы</param>
        /// <param name="route">Маршрут</param>
        /// <returns>Время окончания работы</returns>
        private TimeSpan CalculateOperatingHoursEnd(TimeSpan operatingHoursStart, TransportRoute route)
        {
            var routeFirstStopCurrentDepartureTime = operatingHoursStart;

            while (routeFirstStopCurrentDepartureTime + route.TripTotalTime < CurrentDayEndTime)
                routeFirstStopCurrentDepartureTime += route.TripTotalTime;

            return routeFirstStopCurrentDepartureTime;
        }

        /// <summary>
        /// Конструктор класса с заданными параметрами
        /// </summary>
        /// <param name="id">Идентификатор транспортного средства</param>
        /// <param name="ticketPrice">Стоимость проездного билета</param>
        /// <param name="operatingHoursStart">Время начала работы</param>
        /// <param name="route">Маршрут</param>
        public TransportVehicle(int id, int ticketPrice, TimeSpan operatingHoursStart, TransportRoute route)
        {
            Id = id;
            TicketPrice = ticketPrice;
            OperatingHours = (operatingHoursStart, CalculateOperatingHoursEnd(operatingHoursStart, route));
            Route = route;
        }

        /// <summary>
        /// Метод расчёта времени ожидания транспортного средства на заданной остановке
        /// </summary>
        /// <param name="sourceTransportStop">Остановка, на которой пассажир ожидает транспорт</param>
        /// <param name="currentTime">Текущее время, когда пассажир пришёл на остановку</param>
        /// <returns>Время ожидания приезда следующего транспортного средства</returns>
        public TimeSpan CalculateWaitingTime(TransportStop sourceTransportStop, TimeSpan currentTime)
        {
            var lastDepartureTime = OperatingHours.End - Route.TimeIntervals.Skip(Route.TransportStops.IndexOf(sourceTransportStop)).Sum();

            if (currentTime > lastDepartureTime || currentTime < OperatingHours.Start)
                return TimeSpan.MaxValue;

            var nextDepartureTime = OperatingHours.Start + Route.TimeIntervals.Take(Route.TransportStops.IndexOf(sourceTransportStop)).Sum();

            while (nextDepartureTime < currentTime && nextDepartureTime < OperatingHours.End)
                nextDepartureTime += Route.TripTotalTime;

            return nextDepartureTime - currentTime;
        }

        /// <summary>
        /// Метод расчёта времени поездки от заданной остановки до следующей по маршруту
        /// </summary>
        /// <param name="sourceTransportStop">Остановка, с которой пассажир отправляется в поездку</param>
        /// <returns>Время поездки транспортного средства до следующей остановки</returns>
        public TimeSpan CalculateJourneyTime(TransportStop sourceTransportStop)
            => Route.TimeIntervals[Route.TransportStops.IndexOf(sourceTransportStop)];

        /// <summary>
        /// Метод приведения объекта к строке
        /// </summary>
        /// <returns>Строка, содержащая идентификатор, стоимость проездного билета, время начала и окончания работы, а также маршрут транспортного средства</returns>
        public override string ToString()
            => $"№{Id}" + Environment.NewLine +
               $"Стоимость билета: {TicketPrice} руб." + Environment.NewLine +
               $"Время начала работы: {OperatingHours.Start.ToString(@"hh\:mm")}" + Environment.NewLine +
               $"Время окончания работы: {OperatingHours.End.ToString(@"hh\:mm")}" + Environment.NewLine +
               $"Маршрут: {Route}";
    }
}