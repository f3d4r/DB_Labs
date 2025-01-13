using MyEfProject.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyEfProject.Services
{

    public class StudentService
    {
        public string AddStudent(Student student)
        {
            using (var db = new PEContext())
            {
                db.Students.Add(student);
                db.SaveChanges();

                //  Console.WriteLine("Студент успешно добавлен");
            }

            return "Студент успешно добавлен";
        }

        public string EditStudent(int studentId, Student updatedData)
        {
            using (var db = new PEContext())
            {
                // Ищем студента в базе
                var student = db.Students.FirstOrDefault(s => s.IdStudent == studentId);
                if (student == null)
                {
                    return "Студент с указанным ID не найден";
                }

                // Обновляем данные только если были переданы новые значения
                student.IdGroup = updatedData.IdGroup > 0 ? updatedData.IdGroup : student.IdGroup;
                student.IdGym = updatedData.IdGym > 0 ? updatedData.IdGym : student.IdGym;
                student.IdNorm = updatedData.IdNorm > 0 ? updatedData.IdNorm : student.IdNorm;
                student.IdTrainer = updatedData.IdTrainer > 0 ? updatedData.IdTrainer : student.IdTrainer;
                student.Name = !string.IsNullOrWhiteSpace(updatedData.Name) ? updatedData.Name : student.Name;
                student.Gender = !string.IsNullOrWhiteSpace(updatedData.Gender) ? updatedData.Gender : student.Gender;

                // Сохраняем изменения
                db.SaveChanges();
                return "Данные студента успешно обновлены";
            }
        }

        public string DeleteStudent(int studentId)
        {
            using (var db = new PEContext())
            {
                // Находим студента в базе данных
                var student = db.Students.FirstOrDefault(s => s.IdStudent == studentId);

                if (student == null)
                {
                    return "Студент с указанным ID не найден.";
                }

                // Удаляем студента
                db.Students.Remove(student);
                db.SaveChanges();

                return "Студент успешно удалён.";
            }
        }

        /* public List<Student> SearchStudentsById(int searchTerm)
         {
             using (var db = new PEContext())
             {
                 // Поиск по Id (регистронезависимо)
                 var students = db.Students
                     .AsEnumerable()
                     .Where(s => s.IdStudent.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                     .ToList();

                 return students;
             }
         } */



        public List<Student> SearchStudentsByName(string searchTerm)
        {
            using (var db = new PEContext())
            {
                // Поиск по имени (регистронезависимо)
                var students = db.Students
                    .AsEnumerable()
                    .Where(s => s.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                return students;
            }
        }


        public class StudentGroupAnalysis
        {
            public int IdGroup { get; set; }
            public int StudentCount { get; set; }
        }

        public List<StudentGroupAnalysis> GetStudentByGroup(string gender)
        {
            using (var db = new PEContext())
            {
                var analysis = db.Students
                .Where(s => s.Gender == gender) // Фильтр по Gender
                .GroupBy(s => s.IdGroup)       // Группировка по IdGroup
                .Select(group => new StudentGroupAnalysis
                {
                    IdGroup = group.Key,                     // Группа
                    StudentCount = group.Count(),            // Количество студентов
                })
                .ToList();

                return analysis;
            }
        }
    }

}