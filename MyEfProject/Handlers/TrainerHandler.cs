using System;
using MyEfProject.Models;
using MyEfProject.Services;
using System.ComponentModel.DataAnnotations;

public class TrainerHandler
{
    private readonly TrainerService _trainerService;

    public TrainerHandler(TrainerService trainerService)
    {
        _trainerService = trainerService;
    }

    public void HandleAddTrainer()
    {
        Console.WriteLine("Введите данные для нового тренера:");

        int idGym;
        Console.Write("IdGym: ");
        while (!int.TryParse(Console.ReadLine(), out idGym))
        {
            Console.WriteLine("Ошибка: введите корректное число.");
        }

        Console.Write("Name: ");
        string name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Ошибка: имя не может быть пустым.");
            Console.Write("Name: ");
            name = Console.ReadLine();
        }

        Console.Write("Education: ");
        string education = Console.ReadLine();

        Console.Write("Experience: ");
        string experience = Console.ReadLine();

        Console.Write("Specialization: ");
        string specialization = Console.ReadLine();

        var trainer = new Trainer
        {
            IdGym = idGym,
            Name = name,
            Education = education,
            Experience = experience,
            Specialization = specialization
        };

        string response = _trainerService.AddTrainer(trainer);
        Console.WriteLine(response);
    }

    public void HandleEditTrainer()
    {
        Console.Write("Введите ID тренера для редактирования: ");
        if (!int.TryParse(Console.ReadLine(), out int trainerId))
        {
            Console.WriteLine("Ошибка: ID должен быть числом.");
            return;
        }

        Console.WriteLine("Введите новые данные (оставьте поле пустым, чтобы сохранить старое значение):");

        Console.Write("IdGym: ");
        int.TryParse(Console.ReadLine(), out int idGym);

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Education: ");
        string education = Console.ReadLine();

        Console.Write("Experience: ");
        string experience = Console.ReadLine();

        Console.Write("Specialization: ");
        string specialization = Console.ReadLine();

        var updatedData = new Trainer
        {
            IdGym = idGym,
            Name = name,
            Education = education,
            Experience = experience,
            Specialization = specialization
        };

        string response = _trainerService.EditTrainer(trainerId, updatedData);
        Console.WriteLine(response);
    }

    public void HandleDeleteTrainer()
    {
        Console.Write("Введите ID тренера для удаления: ");
        if (!int.TryParse(Console.ReadLine(), out int trainerId))
        {
            Console.WriteLine("Ошибка: ID должен быть числом.");
            return;
        }

        string response = _trainerService.DeleteTrainer(trainerId);
        Console.WriteLine(response);
    }

    public void HandleSearchTrainerById()
    {
        Console.Write("Введите ID тренера для поиска: ");
        if (!int.TryParse(Console.ReadLine(), out int trainerId))
        {
            Console.WriteLine("Ошибка: ID должен быть числом.");
            return;
        }

        var trainer = _trainerService.SearchTrainerById(trainerId);
        if (trainer != null)
        {
            Console.WriteLine($"Найден тренер: ID={trainer.IdTrainer}, Name={trainer.Name}, Education={trainer.Education}, Experience={trainer.Experience}, Specialization={trainer.Specialization}");
        }
        else
        {
            Console.WriteLine("Тренер с указанным ID не найден.");
        }
    }

    public void HandleSearchTrainersByName()
    {
        Console.Write("Введите имя тренера для поиска: ");
        string name = Console.ReadLine();

        var trainers = _trainerService.SearchTrainersByName(name);
        if (trainers.Count == 0)
        {
            Console.WriteLine("Не найдено тренеров, соответствующих запросу.");
        }
        else
        {
            Console.WriteLine("Результаты поиска:");
            foreach (var trainer in trainers)
            {
                Console.WriteLine($"ID: {trainer.IdTrainer}, Name: {trainer.Name}, Education: {trainer.Education}, Experience: {trainer.Experience}, Specialization: {trainer.Specialization}");
            }
        }
    }
}