using System;

namespace MyEfProject
{
    public static class Menu
    {
        public static void ShowMainMenu()
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
        }
    }
}
