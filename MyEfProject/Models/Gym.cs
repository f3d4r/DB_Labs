using System;
using System.Collections.Generic;

#nullable disable

namespace MyEfProject.Models
{
    public partial class Gym
    {
        public Gym()
        {
            Students = new HashSet<Student>();
            Trainers = new HashSet<Trainer>();
        }

        public int IdGym { get; set; }
        public string Address { get; set; }
        public TimeSpan? OpeningHours { get; set; }
        public TimeSpan? ClosingHours { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
