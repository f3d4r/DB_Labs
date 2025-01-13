using MyEfProject.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyEfProject.Services
{
    public class GroupService
    {
        public string AddGroup(Group group)
        {
            using (var db = new PEContext())
            {
                db.Groups.Add(group);
                db.SaveChanges();
              //  Console.WriteLine("Студент успешно добавлен");
            }
            return "Группа успешно добавлена";
        } 

        public string EditGroup(int groupId, Group updatedData)
        {
            using (var db = new PEContext())
            {
                // Ищем студента в базе
                var group = db.Groups.FirstOrDefault(g => g.IdGroup == groupId);
                if (group == null)
                {
                    return "Группа с указанным ID не найдена";
                }

                // Обновляем данные только если были переданы новые значения
                group.Name = !string.IsNullOrWhiteSpace(updatedData.Name) ? updatedData.Name : group.Name;

                db.SaveChanges();
                return "Данные группы успешно обновлены";
            }
        }

        public string DeleteGroup(int groupId)
        {
            using (var db = new PEContext())
            {
                var group = db.Groups.FirstOrDefault(g => g.IdGroup == groupId);

                if (group == null)
                {
                    return "Группа с указанным ID не найдена";
                }

                db.Groups.Remove(group);
                db.SaveChanges();

                return "Студент успешно удалён.";
            }
        }

        public Group SearchGroupByName(string searchTerm)
        {
            using (var db = new PEContext())
            {
                var group = db.Groups
                    .AsEnumerable()
                    .FirstOrDefault(g => g.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

                return group;
            }
        }
    }
}