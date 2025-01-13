using MyEfProject.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MyEfProject.Services
{
    public class TrainerService
    {
        public string AddTrainer(Trainer trainer)
        {
            using (var db = new PEContext())
            {
                db.Trainers.Add(trainer);
                db.SaveChanges();
                return "Тренер успешно добавлен.";
            }
        }

        public string EditTrainer(int trainerId, Trainer updatedData)
        {
            using (var db = new PEContext())
            {
                var trainer = db.Trainers.FirstOrDefault(t => t.IdTrainer == trainerId);
                if (trainer == null)
                {
                    return "Тренер с указанным ID не найден.";
                }

                // Обновляем данные только если переданы новые значения
                trainer.IdGym = updatedData.IdGym > 0 ? updatedData.IdGym : trainer.IdGym;
                trainer.Name = !string.IsNullOrWhiteSpace(updatedData.Name) ? updatedData.Name : trainer.Name;
                trainer.Education = !string.IsNullOrWhiteSpace(updatedData.Education) ? updatedData.Education : trainer.Education;
                trainer.Experience = !string.IsNullOrWhiteSpace(updatedData.Experience) ? updatedData.Experience : trainer.Experience;
                trainer.Specialization = !string.IsNullOrWhiteSpace(updatedData.Specialization) ? updatedData.Specialization : trainer.Specialization;

                db.SaveChanges();
                return "Данные тренера успешно обновлены.";
            }
        }

        public string DeleteTrainer(int trainerId)
        {
            using (var db = new PEContext())
            {
                var trainer = db.Trainers.FirstOrDefault(t => t.IdTrainer == trainerId);
                if (trainer == null)
                {
                    return "Тренер с указанным ID не найден.";
                }

                db.Trainers.Remove(trainer);
                db.SaveChanges();
                return "Тренер успешно удалён.";
            }
        }

        public Trainer SearchTrainerById(int trainerId)
        {
            using (var db = new PEContext())
            {
                return db.Trainers.FirstOrDefault(t => t.IdTrainer == trainerId);
            }
        }

        public List<Trainer> SearchTrainersByName(string name)
        {
            using (var db = new PEContext())
            {
                return db.Trainers
                    .Where(t => t.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }
    }
}