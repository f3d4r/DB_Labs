using MyEfProject.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyEfProject.Services
{
    public class NormService
    {
        public string AddNorm(Norm norm)
        {
            using (var db = new PEContext())
            {
                db.Norms.Add(norm);
                db.SaveChanges();
            }

            return "Норматив успешно добавлен";
        }

        public string EditNorm(int normId, Norm updatedData)
        {
            using (var db = new PEContext())
            {
                var norm = db.Norms.FirstOrDefault(n => n.IdNorm == normId);
                if (norm == null)
                {
                    return "Норматив с указанным ID не найден";
                }

                norm.IdResult = updatedData.IdResult > 0 ? updatedData.IdResult : norm.IdResult;
                norm.Name = !string.IsNullOrWhiteSpace(updatedData.Name) ? updatedData.Name : norm.Name;
                norm.Type = !string.IsNullOrWhiteSpace(updatedData.Type) ? updatedData.Type : norm.Type;
                norm.Description = !string.IsNullOrWhiteSpace(updatedData.Description) ? updatedData.Description : norm.Description;
                norm.NormType = !string.IsNullOrWhiteSpace(updatedData.NormType) ? updatedData.NormType : norm.NormType;

                db.SaveChanges();
                return "Данные норматива успешно обновлены";
            }
        }

        public string DeleteNorm(int normId)
        {
            using (var db = new PEContext())
            {   
                var norm = db.Norms.FirstOrDefault(n => n.IdNorm == normId);
                if (norm == null)
                {
                    return "Норматив с указанным ID не найден.";
                }

                db.Norms.Remove(norm);
                db.SaveChanges();
                return "Норматив успешно удалён.";
            }
        }

        public List<Norm> SearchNormByName(string searchTerm)
        {
            using (var db = new PEContext())
            {
                return db.Norms
                    .AsEnumerable()
                    .Where(n => n.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }

        public Norm SearchNormById(int normId)
        {
            using (var db = new PEContext())
            {
                var norm = db.Norms.FirstOrDefault(n => n.IdNorm == normId);
                return norm;
            }
        }
    }
}