using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TNPathsFinder.Models;

namespace TNPathsFinder.Interfaces
{
    /// <summary>
    /// Интерфейс для определения базовой реализации движка поиска минимальных путей в транспортной сети
    /// </summary>
    public interface IPathsFinderEngine
    {
        /// <summary>
        /// Список найденных движком минимальных по времени поездки путей
        /// </summary>
        ReadOnlyCollection<TransportNetworkPath> MinTimePaths { get; }

        /// <summary>
        /// Список найденных движком минимальных по стоимости проезда путей
        /// </summary>
        ReadOnlyCollection<TransportNetworkPath> MinCostPaths { get; }

        /// <summary>
        /// Метод нахождения в сети общественного транспорта минимальных по стоимости проезда и времени поездки путей между двумя остановками
        /// </summary>
        /// <param name="sourceTransportStop">Начальная транспортная остановка</param>
        /// <param name="destinationTransportStop">Конечная транспортная остановка</param>
        /// <param name="tripStartTime">Время начала поездки</param>
        /// <returns>Асинхронная задача нахождения минимальных путей между двумя остановками</returns>
        Task FindMinPaths(TransportStop sourceTransportStop, TransportStop destinationTransportStop, TimeSpan tripStartTime);
    }
}