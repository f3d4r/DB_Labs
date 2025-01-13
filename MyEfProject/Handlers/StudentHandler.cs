using System;
using MyEfProject.Models;
using MyEfProject.Services;
using System.ComponentModel.DataAnnotations;

namespace MyEfProject.Handlers
{

    public class StudentHandler
    {
        private readonly StudentService _studentService;

        public StudentHandler(StudentService studentService)
        {
            _studentService = studentService;
        }

        public void HandleAddStudent()
        {

            int idGroup, idGym, idNorm, idTrainer;
            string studentName, studentGender;

            Console.WriteLine("Введите данные для таблицы student:");

            Console.Write("IdGroup: ");
            while (!int.TryParse(Console.ReadLine(), out idGroup))
            {
                Console.WriteLine("Ошибка: введите корректное число");
                Console.Write("IdGroup: ");
            }

            Console.Write("IdGym: ");
            while (!int.TryParse(Console.ReadLine(), out idGym))
            {
                Console.WriteLine("Ошибка: введите корректное число");
                Console.Write("IdGym: ");
            }

            Console.Write("IdNorm: ");
            while (!int.TryParse(Console.ReadLine(), out idNorm))
            {
                Console.WriteLine("Ошибка: введите корректное число");
                Console.Write("IdNorm: ");
            }

            Console.Write("IdTrainer: ");
            while (!int.TryParse(Console.ReadLine(), out idTrainer))
            {
                Console.WriteLine("Ошибка: введите корректное число");
                Console.Write("IdTrainer: ");
            }

            Console.Write("Name: ");
            studentName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(studentName))
            {
                Console.WriteLine("Ошибка: имя не может быть пустым");
                Console.Write("Name: ");
                studentName = Console.ReadLine();
            }

            Console.Write("Gender: ");
            studentGender = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(studentGender))
            {
                Console.WriteLine("Ошибка: пол не может быть пустым");
                Console.Write("Gender: ");
                studentGender = Console.ReadLine();
            }

            // Сохранение данных в базу данных
            /* using (var db = new PEContext())
             { */
            var student = new Student
            {
                IdGroup = idGroup,
                IdGym = idGym,
                IdNorm = idNorm,
                IdTrainer = idTrainer,
                Name = studentName,
                Gender = studentGender
            };

            /*   db.Students.Add(student);
               db.SaveChanges(); 
           }

           Console.WriteLine("Студент успешно добавлен"); */
        }

        public void HandleEditStudent()
        {
            Console.Write("Введите ID студента для редактирования: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Ошибка: ID должен быть числом.");
                return;
            }

            // Ввод новых данных
            Console.WriteLine("Введите новые данные (оставьте поле пустым, чтобы сохранить старое значение):");

            Console.Write("IdGroup: ");
            int.TryParse(Console.ReadLine(), out int idGroup);

            Console.Write("IdGym: ");
            int.TryParse(Console.ReadLine(), out int idGym);

            Console.Write("IdNorm: ");
            int.TryParse(Console.ReadLine(), out int idNorm);

            Console.Write("IdTrainer: ");
            int.TryParse(Console.ReadLine(), out int idTrainer);

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Gender: ");
            string gender = Console.ReadLine();

            // Создаем объект с новыми данными
            var updatedData = new Student
            {
                IdGroup = idGroup,
                IdGym = idGym,
                IdNorm = idNorm,
                IdTrainer = idTrainer,
                Name = name,
                Gender = gender
            };

            // Передаем в сервис для обновления
            string result = _studentService.EditStudent(studentId, updatedData);
            Console.WriteLine(result);
        }

        public void HandleDeleteStudent()
        {
            Console.Write("Введите ID студента для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var result = _studentService.DeleteStudent(studentId);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Некорректный ввод, ID должен быть числом");
            }
        }

        public void HandleSearchStudentsByName()
        {
            Console.Write("Введите строку для поиска: ");
            var searchTerm = Console.ReadLine();

            var students = _studentService.SearchStudentsByName(searchTerm);

            if (students.Count == 0)
            {
                Console.WriteLine("Не найдено студентов, соответствующих запросу.");
            }
            else
            {
                Console.WriteLine("Результаты поиска:");
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.IdStudent}, Имя: {student.Name}, Пол: {student.Gender}");
                }
            }
        }

        public void HandleStudentGroupBy()
        {
            Console.Write("Введите пол для анализа (например, Male/Female): ");
            var gender = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(gender))
            {
                Console.WriteLine("Ошибка: Пол не может быть пустым.");
                return;
            }

            var analysis = _studentService.GetStudentByGroup(gender);

            if (analysis.Count == 0)
            {
                Console.WriteLine("Нет данных для указанного пола.");
            }
            else
            {
                Console.WriteLine("Информация по группам:");
                foreach (var group in analysis)
                {
                    Console.WriteLine($"Группа: {group.IdGroup}, Количество студентов: {group.StudentCount}");
                }
            }
        }
    }

}