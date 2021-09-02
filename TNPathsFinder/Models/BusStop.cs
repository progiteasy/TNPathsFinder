namespace TNPathsFinder.Models
{
    /// <summary>
    /// Класс для представления модели автобусной остановки
    /// </summary>
    public class BusStop : TransportStop
    {
        /// <summary>
        /// Конструктор класса с заданными параметрами
        /// </summary>
        /// <param name="id">Идентификатор остановки</param>
        public BusStop(int id) 
            : base(id) { }

        /// <summary>
        /// Метод приведения объекта к строке
        /// </summary>
        /// <returns>Строка, содержащая идентификатор и тип текущей автобусной остановки</returns>
        public override string ToString()
            => $"{base.ToString()} (авт.)";
    }
}