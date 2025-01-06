using System;
using System.Collections.Generic;

#nullable disable

namespace MyEfProject.Models
{
    public partial class Trainer
    {
        public Trainer()
        {
            Students = new HashSet<Student>();
        }

        public int IdTrainer { get; set; }
        public int IdGym { get; set; }
        public string Name { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string Specialization { get; set; }

        public virtual Gym IdGymNavigation { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
