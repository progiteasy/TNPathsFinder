using System;

namespace TNPathsFinder.Models
{
    /// <summary>
    /// Класс для представления модели автобуса
    /// </summary>
    public class Bus : TransportVehicle
    {
        /// <summary>
        /// Описание транспортного средства, содержащее его номер и тип
        /// </summary>
        public override string Description => $"{base.Description} авт.";

        /// <summary>
        /// Конструктор класса с заданными параметрами
        /// </summary>
        /// <param name="id">Идентификатор автобуса</param>
        /// <param name="ticketPrice">Стоимость проездного билета</param>
        /// <param name="operatingHoursStart">Время начала работы</param>
        /// <param name="route">Маршрут</param>
        public Bus(int id, int ticketPrice, TimeSpan operatingHoursStart, TransportRoute route) 
            : base(id, ticketPrice, operatingHoursStart, route) { }

        /// <summary>
        /// Метод приведения объекта к строке
        /// </summary>
        /// <returns>Строка, содержащая тип транспорта, идентификатор, стоимость проездного билета, время начала и окончания работы, а также маршрут автобуса</returns>
        public override string ToString()
            => $"Автобус {base.ToString()}";
    }
}