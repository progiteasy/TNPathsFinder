namespace TNPathsFinder.Interfaces
{
    /// <summary>
    /// Интерфейс для определения базовой реализации ориентированного графа
    /// </summary>
    public interface IDigraph<T>
    {
        /// <summary>
        /// Метод добавления дуги между заданными вершинами графа
        /// </summary>
        /// <param name="sourceVertex">Начальная вершина, из которой исходит дуга</param>
        /// <param name="destinationVertex">Конечная вершина, в которую входит дуга</param> 
        void AddArc(T sourceVertex, T destinationVertex);

        /// <summary>
        /// Метод поиска в графе всех возможных путей между двумя заданными вершинами
        /// </summary>
        /// <param name="sourceVertex">Начальная вершина поиска</param>
        /// <param name="destinationVertex">Конечная вершина поиска</param>
        /// <returns>Массив всех найденных путей между заданными вершинами</returns>
        T[][] FindAllPathsBetweenVertices(T sourceVertex, T destinationVertex);
    }
}