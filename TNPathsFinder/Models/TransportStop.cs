using System;

namespace TNPathsFinder.Models
{
    /// <summary>
    /// Абстрактный класс для представления модели остановки общественного транспорта
    /// </summary>
    public abstract class TransportStop : IEquatable<TransportStop>
    {
        /// <summary>
        /// Идентификатор остановки
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Конструктор класса с заданными параметрами
        /// </summary>
        /// <param name="id">Идентификатор остановки</param>
        public TransportStop(int id)
            => Id = id;

        /// <summary>
        /// Метод проверки равества текущего объекта с другим объектом типа TransportStop
        /// </summary>
        /// <param name="otherObject">Объект типа TransportStop, с которым происходит сравнение</param>
        /// <returns>Признак равенства заданного объекта с текущим</returns>
        public bool Equals(TransportStop otherObject)
            => otherObject != null && otherObject.Id == Id;

        /// <summary>
        /// Метод проверки равества текущего объекта с другим объектом типа object
        /// </summary>
        /// <param name="otherObject">Объект типа object, с которым происходит сравнение</param>
        /// <returns>Признак равенства заданного объекта с текущим</returns>
        public override bool Equals(object otherObject)
            => Equals(otherObject as TransportStop);

        /// <summary>
        /// Метод вычисления хэш-кода текущего объекта
        /// </summary>
        /// <returns>Хэш-код текущего объекта</returns>
        public override int GetHashCode()
            => Id.GetHashCode();

        /// <summary>
        /// Метод приведения объекта к строке
        /// </summary>
        /// <returns>Строка, содержащая идентификатор текущей транспортной остановки</returns>
        public override string ToString()
            => Id.ToString();
    }
}