using MyEfProject.Services;
using MyEfProject.Models;
using System;

public class ResultHandler
{
    private readonly ResultService _resultService;

    public ResultHandler(ResultService resultService)
    {
        _resultService = resultService;
    }

    public void HandleAddResult()
    {
        Console.WriteLine("Введите данные для новой записи результата:");
        short mark;
        Console.Write("Mark (оценка): ");
        while (!short.TryParse(Console.ReadLine(), out mark))
        {
            Console.WriteLine("Ошибка: введите корректное значение для оценки.");
        }

        Console.Write("Date of Completion (дата завершения, формат YYYY-MM-DD): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dateOfCompletion))
        {
            Console.WriteLine("Ошибка: некорректный формат даты.");
            return;
        }

        var result = new Result
        {
            Mark = mark,
            DateOfCompletion = dateOfCompletion
        };

        string response = _resultService.AddResult(result);
        Console.WriteLine(response);
    }

    public void HandleEditResult()
    {
        Console.Write("Введите ID результата для редактирования: ");
        if (!int.TryParse(Console.ReadLine(), out int resultId))
        {
            Console.WriteLine("Ошибка: ID должен быть числом.");
            return;
        }

        Console.WriteLine("Введите новые данные (оставьте поле пустым, чтобы сохранить старое значение):");

        Console.Write("Mark (оценка): ");
        short.TryParse(Console.ReadLine(), out short mark);

        Console.Write("Date of Completion (дата завершения, формат YYYY-MM-DD): ");
        DateTime.TryParse(Console.ReadLine(), out DateTime dateOfCompletion);

        var updatedData = new Result
        {
            Mark = mark,
            DateOfCompletion = dateOfCompletion
        };

        string response = _resultService.EditResult(resultId, updatedData);
        Console.WriteLine(response);
    }

    public void HandleDeleteResult()
    {
        Console.Write("Введите ID результата для удаления: ");
        if (!int.TryParse(Console.ReadLine(), out int resultId))
        {
            Console.WriteLine("Ошибка: ID должен быть числом.");
            return;
        }

        string response = _resultService.DeleteResult(resultId);
        Console.WriteLine(response);
    }

    public void HandleSearchResultById()
    {
        Console.Write("Введите ID результата для поиска: ");
        if (!int.TryParse(Console.ReadLine(), out int resultId))
        {
            Console.WriteLine("Ошибка: ID должен быть числом.");
            return;
        }

        var result = _resultService.SearchResultById(resultId);
        if (result != null)
        {
            Console.WriteLine($"Найден результат: ID={result.IdResult}, Mark={result.Mark}, DateOfCompletion={result.DateOfCompletion}");
        }
        else
        {
            Console.WriteLine("Результат с указанным ID не найден.");
        }
    }

    public void HandleSearchResultsByDate()
    {
        Console.Write("Введите дату завершения (формат YYYY-MM-DD): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Ошибка: некорректный формат даты.");
            return;
        }

        var results = _resultService.SearchResultsByDate(date);
        if (results.Count == 0)
        {
            Console.WriteLine("Не найдено результатов для указанной даты.");
        }
        else
        {
            Console.WriteLine("Результаты:");
            foreach (var result in results)
            {
                Console.WriteLine($"ID: {result.IdResult}, Mark: {result.Mark}, DateOfCompletion: {result.DateOfCompletion}");
            }
        }
    }
}