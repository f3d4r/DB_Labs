using System;
using MyEfProject.Models;
using MyEfProject.Services;
using System.ComponentModel.DataAnnotations;

namespace MyEfProject.Handlers
{
    public class NormHandler
    {
        private readonly NormService _normService;

        public NormHandler(NormService normService)
        {
            _normService = normService;
        }

        public void HandleAddNorm()
        {
            int idResult;
            string name, type, description, normType;

            Console.WriteLine("Введите данные для таблицы Norm:");

            Console.Write("IdResult: ");
            while (!int.TryParse(Console.ReadLine(), out idResult))
            {
                Console.WriteLine("Ошибка: введите корректное число");
                Console.Write("IdResult: ");
            }

            Console.Write("Name: ");
            name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ошибка: имя не может быть пустым");
                Console.Write("Name: ");
            }

            Console.Write("Type: ");
            type = Console.ReadLine();

            Console.Write("Description: ");
            description = Console.ReadLine();

            Console.Write("NormType: ");
            normType = Console.ReadLine();

            // Сохранение данных в базу данных
            var norm = new Norm
            {
                IdResult = idResult,
                Name = name,
                Type = type,
                Description = description,
                NormType = normType
            };

            var result = _normService.AddNorm(norm);
            Console.WriteLine(result);
        }

        public void HandleEditNorm()
        {
            Console.Write("Введите ID норматива для редактирования: ");
            if (!int.TryParse(Console.ReadLine(), out int normId))
            {
                Console.WriteLine("Ошибка: ID должен быть числом.");
                return;
            }

            // Ввод новых данных
            Console.WriteLine("Введите новые данные (оставьте поле пустым, чтобы сохранить старое значение):");

            Console.Write("IdResult: ");
            int.TryParse(Console.ReadLine(), out int idResult);

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Type: ");
            string type = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("NormType: ");
            string normType = Console.ReadLine();

            // Создаем объект с новыми данными
            var updatedData = new Norm
            {
                IdResult = idResult,
                Name = name,
                Type = type,
                Description = description,
                NormType = normType
            };

            var result = _normService.EditNorm(normId, updatedData);
            Console.WriteLine(result);
        }

        public void HandleDeleteNorm()
        {
            Console.Write("Введите ID норматива для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int normId))
            {
                var result = _normService.DeleteNorm(normId);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Некорректный ввод, ID должен быть числом");
            }
        }

        public void HandleSearchNormById()
        {
            Console.Write("Введите ID норматива для поиска: ");
            if (int.TryParse(Console.ReadLine(), out int normId))
            {
                var norm = _normService.SearchNormById(normId);

                if (norm == null)
                {
                    Console.WriteLine("Норматив с указанным ID не найден.");
                }
                else
                {
                    Console.WriteLine($"ID: {norm.IdNorm}, Имя: {norm.Name}, Тип: {norm.Type}, Описание: {norm.Description}, Тип норматива: {norm.NormType}");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод, ID должен быть числом.");
            }
        }

    }
}