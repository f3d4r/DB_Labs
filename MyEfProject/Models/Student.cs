using System;
using System.Collections.Generic;

#nullable disable

namespace MyEfProject.Models
{
    public partial class Student
    {
        public int IdStudent { get; set; }
        public int IdGroup { get; set; }
        public int IdGym { get; set; }
        public int IdNorm { get; set; }
        public int IdTrainer { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public virtual Group IdGroupNavigation { get; set; }
        public virtual Gym IdGymNavigation { get; set; }
        public virtual Norm IdNormNavigation { get; set; }
        public virtual Trainer IdTrainerNavigation { get; set; }
    }
}
