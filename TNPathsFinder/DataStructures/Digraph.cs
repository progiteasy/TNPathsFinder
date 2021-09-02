using TNPathsFinder.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace TNPathsFinder.DataStructures
{
    /// <summary>
    /// Класс для представления модели ориентированного графа
    /// </summary>
    public class Digraph<T> : IDigraph<T>
    {
        private readonly Dictionary<T, List<T>> _adjacencyList;

        /// <summary>
        /// Конструктор класса без параметров
        /// </summary>
        public Digraph()
            => _adjacencyList = new Dictionary<T, List<T>>();

        /// <summary>
        /// Метод добавления дуги между заданными вершинами графа
        /// </summary>
        /// <param name="sourceVertex">Начальная вершина, из которой исходит дуга</param>
        /// <param name="destinationVertex">Конечная вершина, в которую входит дуга</param> 
        public void AddArc(T sourceVertex, T destinationVertex)
        {
            if (!_adjacencyList.ContainsKey(sourceVertex))
            {
                _adjacencyList.Add(sourceVertex, new List<T>() { destinationVertex });
            }
            else
            {
                if (!_adjacencyList[sourceVertex].Contains(destinationVertex))
                    _adjacencyList[sourceVertex].Add(destinationVertex);
            }

            if (!_adjacencyList.ContainsKey(destinationVertex))
                _adjacencyList.Add(destinationVertex, new List<T>());
        }

        /// <summary>
        /// Метод поиска в графе всех возможных путей между двумя заданными вершинами
        /// </summary>
        /// <param name="sourceVertex">Начальная вершина поиска</param>
        /// <param name="destinationVertex">Конечная вершина поиска</param>
        /// <returns>Массив всех найденных путей между заданными вершинами</returns>
        public T[][] FindAllPathsBetweenVertices(T sourceVertex, T destinationVertex)
        {
            var allFoundPaths = new List<List<T>>();
            var pathsQueue = new Queue<List<T>>();

            pathsQueue.Enqueue(new List<T>() { sourceVertex });

            while (pathsQueue.Any())
            {
                var currentPath = pathsQueue.Dequeue();
                var currentPathLastVertex = currentPath.Last();

                if (currentPathLastVertex.Equals(destinationVertex))
                    allFoundPaths.Add(currentPath);

                foreach (var neighborVertex in _adjacencyList[currentPathLastVertex])
                {
                    if (!currentPath.Contains(neighborVertex))
                        pathsQueue.Enqueue(new List<T>(currentPath) { neighborVertex });
                }
            }

            return allFoundPaths.Select(path => path.ToArray()).ToArray();
        }
    }
}