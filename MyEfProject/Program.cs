using System;
using System.Linq;

using MyEfProject.Handlers;
using MyEfProject.Services;

// using var db = new PEContext();

namespace MyEfProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentService = new StudentService();
            var studentHandler = new StudentHandler(studentService);

            while (true)
            {
                Console.WriteLine("Действия (для таблицы студент):");
                Console.WriteLine("1.Ввод данных");
                Console.WriteLine("2.Удаление");
                Console.WriteLine("3.Редактирование");
                Console.WriteLine("4.Поиск по имени");
                Console.WriteLine("0.Выход");

                Console.Write("Выберите действие (для таблицы студент):");
                string key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        studentHandler.HandleAddStudent();
                        break;
                    case "2":
                        studentHandler.HandleDeleteStudent();
                        break;
                    case "3":
                        studentHandler.HandleEditStudent();
                        break;
                    case "4":
                        studentHandler.HandleSearchStudentsByName();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }
    }
}



