using System;
using MyEfProject.Models;
using MyEfProject.Services;
using System.ComponentModel.DataAnnotations;

namespace MyEfProject.Handlers
{
    public class GymHandler
    {
        private readonly GymService _gymService;

        public GymHandler(GymService gymService)
        {
            _gymService = gymService;
        }

        public void HandleAddGym()
        {
            Console.WriteLine("Введите данные для таблицы Gym:");

            // Ввод адреса тренажерного зала
            Console.Write("Адрес: ");
            string address = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Ошибка: адрес не может быть пустым.");
                Console.Write("Адрес: ");
                address = Console.ReadLine();
            }

            // Ввод времени открытия
            Console.Write("Время открытия (в формате HH:MM): ");
            TimeSpan? openingHours = null;
            while (true)
            {
                var input = Console.ReadLine();
                if (TimeSpan.TryParse(input, out var Open))
                {
                    openingHours = Open;
                    break;
                }
                Console.WriteLine("Ошибка: введите корректное время в формате HH:MM.");
            }

            // Ввод времени закрытия
            Console.Write("Время закрытия (в формате HH:MM): ");
            TimeSpan? closingHours = null;
            while (true)
            {
                var input = Console.ReadLine();
                if (TimeSpan.TryParse(input, out var Close))
                {
                    closingHours = Close;
                    break;
                }
                Console.WriteLine("Ошибка: введите корректное время в формате HH:MM.");
            }

            // Создание объекта Gym
            var gym = new Gym
            {
                Address = address,
                OpeningHours = openingHours,
                ClosingHours = closingHours
            };

            // Сохранение данных в базу данных
            var result = _gymService.AddGym(gym); // Предполагается, что AddGym реализован в GymService.
            Console.WriteLine(result);
        }

        public void HandleEditGym()
        {
            Console.Write("Введите ID студента для редактирования: ");
            if (!int.TryParse(Console.ReadLine(), out int gymId))
            {
                Console.WriteLine("Ошибка: ID должен быть числом.");
                return;
            }

            // Ввод новых данных
            Console.WriteLine("Введите новые данные (оставьте поле пустым, чтобы сохранить старое значение):");

            Console.Write("Address: ");
            string address = Console.ReadLine();
            

            
        /*    Console.Write("Часы открытия (в формате HH:MM): ");
            TimeSpan? openingHours = null;
            string openingInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(openingInput) && TimeSpan.TryParse(openingInput, out var parsedOpening))
            {
                openingHours = parsedOpening;
            } */


            Console.Write("Часы открытия (в формате HH:MM): ");
            TimeSpan? openingHours = null;
            while (true)
            {
                string openingInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(openingInput))
                {
                    // Пользователь оставил поле пустым
                    break;
                }

                if (TimeSpan.TryParse(openingInput, out var parsedOpening))
                {
                    openingHours = parsedOpening;
                    break;
                }
                else 
                {
                    Console.WriteLine("Ошибка: неверный формат времени. Используйте формат HH:MM.");
                    Console.Write("Попробуйте снова: ");
                }
            }

           /* Console.Write("Часы закрытия (в формате HH:MM): ");
            TimeSpan? closingHours = null;
            string closingInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(closingInput) && TimeSpan.TryParse(closingInput, out var parsedClosing))
            {
                closingHours = parsedClosing;
            } */


            TimeSpan? closingHours = null;
            Console.Write("Часы закрытия (в формате HH:MM): ");
            while (true)
            {
                string closingInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(closingInput))
                {
                    break;
                }

                if (TimeSpan.TryParse(closingInput, out var parsedClosing))
                {
                    closingHours = parsedClosing;
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: неверный формат времени. Используйте формат HH:MM.");
                    Console.Write("Попробуйте снова: ");
                }
            }



            // Создаем объект с новыми данными
            var updatedData = new Gym
            {
                Address = address,
                OpeningHours = openingHours,
                ClosingHours = closingHours
            };

            string result = _gymService.EditGym(gymId, updatedData);
            Console.WriteLine(result);
        }

        public void HandleDeleteGym()
        {
            Console.Write("Введите ID студента для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int gymId))
            {
                var result = _gymService.DeleteGym(gymId);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Некорректный ввод, ID должен быть числом");
            }
        }

        public void HandleSearchGymById()
        {
            Console.Write("Введите ID для поиска: ");
            
            if (!int.TryParse(Console.ReadLine(), out int gymId))
            {
                Console.WriteLine("Ошибка: ID должен быть числом.");
                return;
            }

            var gym = _gymService.SearchGymById(gymId);

             if (gym == null)
            {
                Console.WriteLine("Не найден спортзал, соответствующий запросу");
            }
            else
            {
                Console.WriteLine("Результаты поиска:");
                {
                    Console.WriteLine($"ID: {gym.IdGym}, Адрес: {gym.Address}, Часы работы: {gym.OpeningHours} - {gym.ClosingHours}");
                }
            }
        }
    }


}