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

            var groupService = new GroupService();
            var groupHandler = new GroupHandler(groupService);

            var gymService = new GymService();
            var gymHandler = new GymHandler(gymService);

            var normService = new NormService();
            var normHandler = new NormHandler(normService);

            var resultService = new ResultService();
            var resultHandler = new ResultHandler(resultService);

            var trainerService = new TrainerService();
            var trainerHandler = new TrainerHandler(trainerService);

            void StudentMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Управление студентами:");
                    Console.WriteLine("1. Добавить студента");
                    Console.WriteLine("2. Удалить студента");
                    Console.WriteLine("3. Редактировать студента");
                    Console.WriteLine("4. Найти студентов по имени");
                    Console.WriteLine("5. Найти количество студентов по полу в группах");
                    Console.WriteLine("0. Выход");

                    Console.Write("Выберите действие: ");

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
                            string a = Console.ReadLine();
                            break;
                        case "5":
                            studentHandler.HandleStudentGroupBy();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неверный ввод");
                            break;
                    }
                    Console.WriteLine();
                }
            }

            void GroupMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Управление группами:");
                    Console.WriteLine("1. Добавить группу");
                    Console.WriteLine("2. Удалить группу");
                    Console.WriteLine("3. Редактировать группу");
                    Console.WriteLine("4. Найти группу по названию");
                    Console.WriteLine("0. Выход");

                    Console.Write("Выберите действие: ");

                    string key = Console.ReadLine();
                    switch (key)
                    {
                        case "1":
                            groupHandler.HandleAddGroup();
                            break;
                        case "2":
                            groupHandler.HandleDeleteGroup();
                            break;
                        case "3":
                            groupHandler.HandleEditGroup();
                            break;
                        case "4":
                            groupHandler.HandleSearchGroupByName();
                            string a = Console.ReadLine();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неверный ввод");
                            break;
                    }
                    Console.WriteLine();
                }
            }

            void GymMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Управление спортзалами:");
                    Console.WriteLine("1. Добавить спортзал");
                    Console.WriteLine("2. Удалить спортзал");
                    Console.WriteLine("3. Редактировать спортзал");
                    Console.WriteLine("4. Найти спортзал по ID");
                    Console.WriteLine("0. Выход");

                    Console.Write("Выберите действие: ");

                    string key = Console.ReadLine();
                    switch (key)
                    {
                        case "1":
                            gymHandler.HandleAddGym();
                            break;
                        case "2":
                            gymHandler.HandleDeleteGym();
                            break;
                        case "3":
                            gymHandler.HandleEditGym();
                            break;
                        case "4":
                            gymHandler.HandleSearchGymById();
                            string a = Console.ReadLine();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неверный ввод");
                            break;
                    }

                    Console.WriteLine();
                }
            }

            void NormMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Управление нормативами:");
                    Console.WriteLine("1. Добавить норматив");
                    Console.WriteLine("2. Удалить норматив");
                    Console.WriteLine("3. Редактировать норматив");
                    Console.WriteLine("4. Найти норматив по ID");
                    Console.WriteLine("0. Выход");

                    Console.Write("Выберите действие: ");

                    string key = Console.ReadLine();
                    switch (key)
                    {
                        case "1":
                            normHandler.HandleAddNorm();
                            break;
                        case "2":
                            normHandler.HandleDeleteNorm();
                            break;
                        case "3":
                            normHandler.HandleEditNorm();
                            break;
                        case "4":
                            normHandler.HandleSearchNormById();
                            string a = Console.ReadLine();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неверный ввод");
                            break;
                    }
                    Console.WriteLine();
                }
            }

            void ResultMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Управление результатами:");
                    Console.WriteLine("1. Добавить результат");
                    Console.WriteLine("2. Удалить результат");
                    Console.WriteLine("3. Редактировать результат");
                    Console.WriteLine("4. Найти результат по ID");
                    Console.WriteLine("0. Выход");

                    Console.Write("Выберите действие: ");
                    string key = Console.ReadLine();
                    switch (key)
                    {
                        case "1":
                            resultHandler.HandleAddResult();
                            break;
                        case "2":
                            resultHandler.HandleDeleteResult();
                            break;
                        case "3":
                            resultHandler.HandleEditResult();
                            break;
                        case "4":
                            resultHandler.HandleSearchResultById();
                            string a = Console.ReadLine();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неверный ввод");
                            break;
                    }
                    Console.WriteLine();
                }
            }

            void TrainerMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Управление тренерами:");
                    Console.WriteLine("1. Добавить тренера");
                    Console.WriteLine("2. Удалить тренера");
                    Console.WriteLine("3. Редактировать тренера");
                    Console.WriteLine("4. Найти тренеров по имени");
                    Console.WriteLine("0. Выход");

                    Console.Write("Выберите действие: ");
                    string key = Console.ReadLine();
                    switch (key)
                    {
                        case "1":
                            trainerHandler.HandleAddTrainer();
                            break;
                        case "2":
                            trainerHandler.HandleDeleteTrainer();
                            break;
                        case "3":
                            trainerHandler.HandleEditTrainer();
                            break;
                        case "4":
                            trainerHandler.HandleSearchTrainersByName();
                            string a = Console.ReadLine();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неверный ввод");
                            break;
                    }
                    Console.WriteLine();
                }
            }


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Управление студентами");
                Console.WriteLine("2. Управление группами");
                Console.WriteLine("3. Управление нормативами");
                Console.WriteLine("4. Управление спортзалами");
                Console.WriteLine("5. Управление результатами");
                Console.WriteLine("6. Управление тренерами");
                Console.WriteLine("0. Выход");

                Console.Write("Выберите действие: ");
                string key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        StudentMenu();
                        break;
                    case "2":
                        GroupMenu();
                        break;
                    case "3":
                        NormMenu();
                        break;
                    case "4":
                        GymMenu();
                        break;
                    case "5":
                        ResultMenu();
                        break;
                    case "6":
                        TrainerMenu();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}



