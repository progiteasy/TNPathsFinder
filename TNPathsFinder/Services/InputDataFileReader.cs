using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TNPathsFinder.Interfaces;
using TNPathsFinder.Models;

namespace TNPathsFinder
{
    /// <summary>
    /// Класс для представления модели сервиса, который считывает входные данные приложения из текстового файла
    /// </summary>
    public class InputDataFileReader : IInputDataProvider
    {
        /// <summary>
        /// Название текстового файла, содержащего исходные данные для чтения
        /// </summary>
        private string _fileName;

        /// <summary>
        /// Конструктор класса с заданными параметрами
        /// </summary>
        /// <param name="fileName">Название текстового файла, содержащего исходные данные для чтения</param>
        public InputDataFileReader(string fileName)
        {
            _fileName = fileName;
        }

        /// <summary>
        /// Метод получения исходных данных приложения из текстового файла
        /// </summary>
        /// <returns>Исходные данные приложения, содержащие коллекцию остановок и коллекцию общественного транспорта</returns>
        public InputData GetData()
        {
            var fileData = File.ReadAllLines(_fileName);

            var vehiclesCount = Int32.Parse(fileData[0]);
            var stopsCount = Int32.Parse(fileData[1]);
            var stopCollection = Enumerable.Range(1, stopsCount).Select(stop => new BusStop(stop)).ToArray();
            var vehicleCollection = new List<TransportVehicle>();
            var operatingHoursStartTimeCollection = fileData[2].Split(' ').Select(operatingHoursStartTime => TimeSpan.Parse(operatingHoursStartTime)).ToArray();
            var ticketPriceCollection = fileData[3].Split(' ').Select(ticketPrice => Int32.Parse(ticketPrice)).ToArray();

            for (int i = 0; i < vehiclesCount; i++)
            {
                var currentVehicleRouteData = fileData[4 + i].Split(' ').Select(currentValue => Int32.Parse(currentValue)).Skip(1);
                var currentVehicleStopCollection = currentVehicleRouteData.Take(currentVehicleRouteData.Count() / 2);
                var currentVehicleTimeIntervalCollection = currentVehicleRouteData.Skip(currentVehicleRouteData.Count() / 2).Take(currentVehicleRouteData.Count() / 2);
                var currentVehicleRoute = new TransportRoute(currentVehicleStopCollection.Select(stop => stopCollection[stop - 1]).ToArray(), currentVehicleTimeIntervalCollection.ToArray());

                vehicleCollection.Add(new Bus(i + 1, ticketPriceCollection[i], operatingHoursStartTimeCollection[i], currentVehicleRoute));
            }

            return new InputData(stopCollection, vehicleCollection);
        }
    }
}