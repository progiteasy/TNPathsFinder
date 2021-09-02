using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace TNPathsFinder.Models
{
    /// <summary>
    /// Класс для представления пути в сети общественного транспорта
    /// </summary>
    public class TransportNetworkPath
    {
        /// <summary>
        /// Список остановок транспорта, из которых состоит путь
        /// </summary>
        public ReadOnlyCollection<TransportStop> TransportStops { get; }

        /// <summary>
        /// Список транспортных средств для проезда по сегментам данного пути
        /// </summary>
        public ReadOnlyCollection<TransportVehicle> TransportVehicles { get; }

        /// <summary>
        /// Суммарное время поездки по маршруту
        /// </summary>
        public TimeSpan TotalTime { get; }

        /// <summary>
        /// Суммарная стоимость поездки по маршруту
        /// </summary>
        public int TotalCost { get; }

        /// <summary>
        /// Метод расчёта суммарного времени поездки по данному маршруту
        /// </summary>
        /// <param name="transportVehicles">Массив транспортных средств для проезда по сегментам пути</param>
        /// <param name="transportStops">Массив транспортных остановок, из которых состоят сегменты пути</param>
        /// <param name="tripStartTime">Время начала поездки</param>
        /// <returns>Суммарное время, которое нужно потратить для поездки по всем сегментам маршрута</returns>
        private TimeSpan CalculateTotalTime(TransportVehicle[] transportVehicles, TransportStop[] transportStops, TimeSpan tripStartTime)
        {
            var totalTime = TimeSpan.Zero;

            for (var i = 0; i < transportVehicles.Length; i++)
            {
                var transportVehicleWaitingTime = transportVehicles[i].CalculateWaitingTime(transportStops[i], tripStartTime + totalTime);

                if (transportVehicleWaitingTime == TimeSpan.MaxValue)
                {
                    totalTime = TimeSpan.MaxValue;
                    break;
                }

                totalTime += transportVehicleWaitingTime + transportVehicles[i].CalculateJourneyTime(transportStops[i]);
            }

            return totalTime;
        }

        /// <summary>
        /// Метод расчёта суммарной стоимости поездки по данному маршруту
        /// </summary>
        /// <param name="transportVehicles">Массив транспортных средств для проезда по сегментам пути</param>
        /// <returns>Суммарное количество денег, которое нужно потратить для поездки по всем сегментам маршрута</returns>
        private int CalculateTotalCost(TransportVehicle[] transportVehicles)
        {
            var totalCost = transportVehicles.First().TicketPrice;

            for (var i = 1; i < transportVehicles.Length; i++)
            {
                if (transportVehicles[i].Id != TransportVehicles[i - 1].Id)
                    totalCost += TransportVehicles[i].TicketPrice;
            }

            return totalCost;
        }

        /// <summary>
        /// Конструктор класса с заданными параметрами
        /// </summary>
        /// <param name="transportStops">Массив транспортных остановок, из которых состоят сегменты пути</param>
        /// <param name="transportVehicles">Массив транспортных средств для проезда по сегментам пути</param>
        /// <param name="tripStartTime">Время начала поездки</param>
        public TransportNetworkPath(TransportStop[] transportStops, TransportVehicle[] transportVehicles, TimeSpan tripStartTime)
        {
            TransportStops = new ReadOnlyCollection<TransportStop>(transportStops);
            TransportVehicles = new ReadOnlyCollection<TransportVehicle>(transportVehicles);
            TotalTime = CalculateTotalTime(transportVehicles, transportStops, tripStartTime);
            TotalCost = CalculateTotalCost(transportVehicles);
        }

        // <summary>
        /// Метод приведения объекта к строке
        /// </summary>
        /// <returns>Строка, содержащая все остановки, транспортные средства для проезда между соответсвующими сегментами пути, а также время в пути и стоимость поездки</returns>
        public override string ToString()
            => $"{String.Join(" => ", TransportStops.Zip(TransportVehicles, (stop, transportVehicle) => $"{stop.Id} = [{transportVehicle.Description}]"))} => {TransportStops.Last().Id}" + Environment.NewLine +
               $"Общее время поездки: {(int)TotalTime.TotalMinutes} мин." + Environment.NewLine +
               $"Суммарная стоимость проезда: {TotalCost} руб.";
    }
}