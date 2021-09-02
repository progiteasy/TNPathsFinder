using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TNPathsFinder.Models
{
    /// <summary>
    /// Класс для представления модели входных данных приложения
    /// </summary>
    public class InputData
    {
        /// <summary>
        /// Список остановок общественного транспорта
        /// </summary>
        public ReadOnlyCollection<TransportStop> TransportStops { get; }

        /// <summary>
        /// Список общественного транспорта
        /// </summary>
        public ReadOnlyCollection<TransportVehicle> TransportVehicles { get; }

        /// <summary>
        /// Конструктор класса с заданными параметрами
        /// </summary>
        /// <param name="transportStops">Коллекция остановок</param>
        /// <param name="transportVehicles">Коллекция транспортных средств</param>
        public InputData(IEnumerable<TransportStop> transportStops, IEnumerable<TransportVehicle> transportVehicles)
        {
            TransportStops = new ReadOnlyCollection<TransportStop>(transportStops.ToArray());
            TransportVehicles = new ReadOnlyCollection<TransportVehicle>(transportVehicles.ToArray());
        }
    }
}