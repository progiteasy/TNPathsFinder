using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TNPathsFinder.DataStructures;
using TNPathsFinder.Extensions;
using TNPathsFinder.Interfaces;
using TNPathsFinder.Models;

namespace TNPathsFinder.Services
{
    /// <summary>
    /// Класс для представления модели движка поиска минимальных путей в транспортной сети
    /// </summary>
    public class PathsFinderEngine : IPathsFinderEngine
    {
        /// <summary>
        /// Транспортный граф
        /// </summary>
        private Digraph<TransportStop> _transportGraph;

        /// <summary>
        /// Сеть общественного транспорта (сегменты между остановками и списки проходящего по ним транспорта)
        /// </summary>
        private Dictionary<(TransportStop, TransportStop), List<TransportVehicle>> _transportNetwork;

        /// <summary>
        /// Список найденных движком минимальных по времени поездки путей
        /// </summary>
        public ReadOnlyCollection<TransportNetworkPath> MinTimePaths { get; private set; }

        /// <summary>
        /// Список найденных движком минимальных по стоимости проезда путей
        /// </summary>
        public ReadOnlyCollection<TransportNetworkPath> MinCostPaths { get; private set; }

        /// <summary>
        /// Метод генерации транспортного графа на основе списка общественного транспорта
        /// </summary>
        /// <param name="transportVehicles">Массив транспортных средств</param>
        /// <returns>Транспортный граф</returns>
        private Digraph<TransportStop> GenerateTransportGraph(TransportVehicle[] transportVehicles)
        {
            var transportGraph = new Digraph<TransportStop>();

            foreach (var vehicle in transportVehicles)
            {
                for (int i = 0; i < vehicle.Route.TransportStops.Count - 1; i++)
                    transportGraph.AddArc(vehicle.Route.TransportStops[i], vehicle.Route.TransportStops[i + 1]);
            }

            return transportGraph;
        }

        /// <summary>
        /// Метод генерации транспортной сети на основе списка общественного транспорта
        /// </summary>
        /// <param name="transportVehicles">Массив транспортных средств</param>
        /// <returns>Сеть общественного транспорта</returns>
        private Dictionary<(TransportStop, TransportStop), List<TransportVehicle>> GenerateTransportNetwork(TransportVehicle[] transportVehicles)
        {
            var transportNetwork = new Dictionary<(TransportStop, TransportStop), List<TransportVehicle>>();

            foreach (var vehicle in transportVehicles)
            {
                for (int i = 0; i < vehicle.Route.TransportStops.Count - 1; i++)
                {
                    var transportRouteSegment = (vehicle.Route.TransportStops[i], vehicle.Route.TransportStops[i + 1]);

                    if (!transportNetwork.ContainsKey(transportRouteSegment))
                    {
                        transportNetwork.Add(transportRouteSegment, new List<TransportVehicle>() { vehicle });
                    }
                    else
                    {
                        transportNetwork[transportRouteSegment].Add(vehicle);
                    }
                }
            }

            return transportNetwork;
        }

        /// <summary>
        /// Метод нахождения в сети общественного транспорта всех возможных вариантов путей между заданными остановками
        /// </summary>
        /// <param name="sourceTransportStop">Начальная транспортная остановка</param>
        /// <param name="destinationTransportStop">Конечная транспортная остановка</param>
        /// <param name="tripStartTime">Время начала поездки</param>
        /// <returns>Массив всех возможных вариантов путей между заданными остановками</returns>
        private TransportNetworkPath[] FindAllPathsBetweenTransportStops(TransportStop sourceTransportStop, TransportStop destinationTransportStop, TimeSpan tripStartTime)
        {
            var allFoundTransportNetworkPaths = new List<TransportNetworkPath>();
            var allFoundPathsInTransportGraph = _transportGraph.FindAllPathsBetweenVertices(sourceTransportStop, destinationTransportStop);
            var currentPathTransportVehicles = new List<List<TransportVehicle>>();

            foreach (var pathTransportStops in allFoundPathsInTransportGraph)
            {
                currentPathTransportVehicles.Clear();

                for (int i = 0; i < pathTransportStops.Length - 1; i++)
                    currentPathTransportVehicles.Add(_transportNetwork[(pathTransportStops[i], pathTransportStops[i + 1])].ToList());

                allFoundTransportNetworkPaths.AddRange(currentPathTransportVehicles.CartesianProduct().Select(pathTransportVehicles => new TransportNetworkPath(pathTransportStops.ToArray(), pathTransportVehicles.ToArray(), tripStartTime)));
            }

            return allFoundTransportNetworkPaths.ToArray();
        }

        /// <summary>
        /// Метод нахождения в заданном массиве минимальных по стоимости проезда путей
        /// </summary>
        /// <param name="paths">Исходный массив путей в сети общественного транспорта</param>
        /// <returns>Массив минимальных по стоимости проезда путей</returns>
        private TransportNetworkPath[] FindMinCostPaths(TransportNetworkPath[] paths)
            => paths.Where(path => path.TotalTime != TimeSpan.MaxValue)
                    .OrderBy(path => path.TotalCost)
                    .TakeWhile(path => path.TotalCost == paths.First().TotalCost)
                    .ToArray();

        /// <summary>
        /// Метод нахождения в заданном массиве минимальных по времени поездки путей
        /// </summary>
        /// <param name="paths">Исходный массив путей в сети общественного транспорта</param>
        /// <returns>Массив минимальных по времени поездки путей</returns>
        private TransportNetworkPath[] FindMinTimePaths(TransportNetworkPath[] paths)
            => paths.Where(path => path.TotalTime != TimeSpan.MaxValue)
                    .OrderBy(path => path.TotalTime)
                    .TakeWhile(path => path.TotalTime == paths.First().TotalTime)
                    .ToArray();

        /// <summary>
        /// Конструктор класса с заданными параметрами
        /// </summary>
        /// <param name="transportVehicles">Массив общественных транспортных средств</param>
        public PathsFinderEngine(TransportVehicle[] transportVehicles)
        {
            _transportGraph = GenerateTransportGraph(transportVehicles);
            _transportNetwork = GenerateTransportNetwork(transportVehicles);
            MinCostPaths = new ReadOnlyCollection<TransportNetworkPath>(new List<TransportNetworkPath>());
            MinTimePaths = new ReadOnlyCollection<TransportNetworkPath>(new List<TransportNetworkPath>());
        }

        /// <summary>
        /// Асинхронный метод нахождения в сети общественного транспорта минимальных по стоимости проезда и времени поездки путей между двумя остановками
        /// </summary>
        /// <param name="sourceTransportStop">Начальная транспортная остановка</param>
        /// <param name="destinationTransportStop">Конечная транспортная остановка</param>
        /// <param name="tripStartTime">Время начала поездки</param>
        /// <returns>Асинхронная задача нахождения минимальных путей между двумя остановками</returns>
        public async Task FindMinPaths(TransportStop sourceTransportStop, TransportStop destinationTransportStop, TimeSpan tripStartTime)
        {
            var allFoundTransportNetworkPaths = await Task.Run(() => FindAllPathsBetweenTransportStops(sourceTransportStop, destinationTransportStop, tripStartTime));

            if (!allFoundTransportNetworkPaths.Any())
                return;

            MinCostPaths = new ReadOnlyCollection<TransportNetworkPath>(FindMinCostPaths(allFoundTransportNetworkPaths));
            MinTimePaths = new ReadOnlyCollection<TransportNetworkPath>(FindMinTimePaths(allFoundTransportNetworkPaths));
        }
    }
}