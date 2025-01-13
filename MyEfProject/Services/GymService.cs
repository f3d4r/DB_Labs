using MyEfProject.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyEfProject.Services
{
    public class GymService
    {
        public string AddGym(Gym gym)
        {   
            using (var db = new PEContext())
            {
                db.Gyms.Add(gym);
                db.SaveChanges();
            }

            return "Спортзал успешно добавлен";
        }

        public string EditGym(int gymId, Gym updatedData)
        {
            using (var db = new PEContext())
            {
                var gym = db.Gyms.FirstOrDefault(g => g.IdGym == gymId);
                if (gym == null)
                {
                    return "Спортзал с указанным ID не найден";
                }

                gym.Address = !string.IsNullOrWhiteSpace(updatedData.Address) ? updatedData.Address : gym.Address;
                gym.OpeningHours = updatedData.OpeningHours ?? gym.OpeningHours;
                gym.ClosingHours = updatedData.ClosingHours ?? gym.ClosingHours;

                db.SaveChanges();
                return "Данные спортзала успешно обновлены";
            }
        }

        public string DeleteGym(int gymId)
        {
            using (var db = new PEContext())
            {
                var gym = db.Gyms.FirstOrDefault(g => g.IdGym == gymId);
            
                if (gym == null)
                {
                    return "Спортзал с указанным ID не найден.";
                }  

                db.Gyms.Remove(gym);
                db.SaveChanges();

                return "Спортзал успешно удалён.";
            }
        }

        public Gym SearchGymById(int gymId)
        {
            using (var db = new PEContext())
            {
                var gym = db.Gyms.FirstOrDefault(g => g.IdGym == gymId);
                return gym;
            }
        }

    }   
}