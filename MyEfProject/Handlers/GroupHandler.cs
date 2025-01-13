using System;
using MyEfProject.Models;
using MyEfProject.Services;
using System.ComponentModel.DataAnnotations;

namespace MyEfProject.Handlers
{
    public class GroupHandler
    {
        private readonly GroupService _groupService;

        public GroupHandler(GroupService groupService)
        {
            _groupService = groupService;
        }

        public void HandleAddGroup()
        {  
            string groupName;

            Console.WriteLine("Введите данные для таблицы group:");

            Console.Write("Name: ");
            groupName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(groupName))
            {
                Console.WriteLine("Ошибка: имя не может быть пустым");
                Console.Write("Name: ");
                groupName = Console.ReadLine();
            }

            // Сохранение данных в базу данных
            
            var group = new Group
            {
                Name = groupName
            };           
        }

        public void HandleEditGroup()
        {
            Console.Write("Введите ID группы для редактирования: ");
            if (!int.TryParse(Console.ReadLine(), out int groupId))
            {
                Console.WriteLine("Ошибка: ID должен быть числом.");
                return;
            }

            Console.WriteLine("Введите новые данные (оставьте поле пустым, чтобы сохранить старое значение):");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            var updatedData = new Group
            {
                Name = name
            };

            // Передаем в сервис для обновления
            string result = _groupService.EditGroup(groupId, updatedData);
            Console.WriteLine(result);
        }

        public void HandleDeleteGroup()
        {
            Console.Write("Введите ID группы для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int groupId))
            {
                var result = _groupService.DeleteGroup(groupId);
                Console.WriteLine(result);
            }

            else
            {
                Console.WriteLine("Некорректный ввод, ID должен быть числом");
            }
        }

        public void HandleSearchGroupByName()
        {
            Console.Write("Введите строку для поиска: ");
            var searchTerm = Console.ReadLine();

            var group = _groupService.SearchGroupByName(searchTerm);

             if (group == null)
            {
                Console.WriteLine("Не найдено группы, соответствующей запросу");
            }
            else
            {
                Console.WriteLine("Результаты поиска:");
                {
                    Console.WriteLine($"ID: {group.IdGroup}, Название: {group.Name}");
                }
            }
        }
    }

}