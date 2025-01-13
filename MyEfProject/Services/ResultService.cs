using MyEfProject.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MyEfProject.Services
{
    public class ResultService
    {
        public string AddResult(Result result)
        {
            using (var db = new PEContext())
            {
                db.Results.Add(result);
                db.SaveChanges();
                return "Результат успешно добавлен.";
            }
        }

        public string EditResult(int resultId, Result updatedData)
        {
            using (var db = new PEContext())
            {
                var result = db.Results.FirstOrDefault(r => r.IdResult == resultId);
                if (result == null)
                {
                    return "Результат с указанным ID не найден.";
                }

                // Обновление данных
                result.Mark = updatedData.Mark > 0 ? updatedData.Mark : result.Mark;
                result.DateOfCompletion = updatedData.DateOfCompletion != default ? updatedData.DateOfCompletion : result.DateOfCompletion;

                db.SaveChanges();
                return "Данные результата успешно обновлены.";
            }
        }

        public string DeleteResult(int resultId)
        {
            using (var db = new PEContext())
            {
                var result = db.Results.FirstOrDefault(r => r.IdResult == resultId);
                if (result == null)
                {
                    return "Результат с указанным ID не найден.";
                }

                db.Results.Remove(result);
                db.SaveChanges();
                return "Результат успешно удалён.";
            }
        }

        public Result SearchResultById(int resultId)
        {
            using (var db = new PEContext())
            {
                return db.Results.FirstOrDefault(r => r.IdResult == resultId);
            }
        }

        public List<Result> SearchResultsByDate(DateTime date)
        {
            using (var db = new PEContext())
            {
                return db.Results.Where(r => r.DateOfCompletion.Date == date.Date).ToList();
            }
        }
    }
}