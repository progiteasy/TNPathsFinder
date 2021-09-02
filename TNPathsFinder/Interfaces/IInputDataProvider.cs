using TNPathsFinder.Models;

namespace TNPathsFinder.Interfaces
{
    /// <summary>
    /// Интерфейс для определения базовой реализации поставщика исходных данных приложения
    /// </summary>
    public interface IInputDataProvider
    {
        /// <summary>
        /// Метод получения данных приложения из поставщика исходных данных
        /// </summary>
        /// <returns>Исходные данные приложения, содержащие коллекцию остановок и коллекцию общественного транспорта</returns>
        InputData GetData();
    }
}