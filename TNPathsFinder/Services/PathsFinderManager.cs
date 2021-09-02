using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TNPathsFinder.Interfaces;
using TNPathsFinder.Models;
using TNPathsFinder.Services;

namespace TNPathsFinder
{
    /// <summary>
    /// Класс для представления менеджера поисковика минимальных путей в сети общественного транспорта
    /// </summary>
    public class PathsFinderManager
    {
        /// <summary>
        /// Список остановок общественного транспорта
        /// </summary>
        public ReadOnlyCollection<TransportStop> TransportStops { get; private set; }

        /// <summary>
        /// Список общественного транспорта
        /// </summary>
        public ReadOnlyCollection<TransportVehicle> TransportVehicles { get; private set; }

        /// <summary>
        /// Движок поиска минимальных путей в транспортной сети
        /// </summary>
        public PathsFinderEngine FinderEngine { get; private set; }

        /// <summary>
        /// Конструктор класса без параметров
        /// </summary>
        public PathsFinderManager()
        {
            TransportStops = new ReadOnlyCollection<TransportStop>(new List<TransportStop>());
            TransportVehicles = new ReadOnlyCollection<TransportVehicle>(new List<TransportVehicle>());
        }

        /// <summary>
        /// Асинхронный метод чтения входных данных из заданного поставщика
        /// </summary>
        /// <param name="inputDataProvider">Поставщик исходных данных</param>
        /// <returns>Асинхронная задача чтения входных данных</returns>
        public async Task ReadInputData(IInputDataProvider inputDataProvider)
        {
            var inputData = await Task.Run(() => inputDataProvider.GetData());

            TransportStops = inputData.TransportStops;
            TransportVehicles = inputData.TransportVehicles;
            FinderEngine = new PathsFinderEngine(TransportVehicles.ToArray());
        }
    }
}