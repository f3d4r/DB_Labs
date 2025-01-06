using System;
using System.Collections.Generic;

#nullable disable

namespace MyEfProject.Models
{
    public partial class Norm
    {
        public Norm()
        {
            Students = new HashSet<Student>();
        }

        public int IdNorm { get; set; }
        public int IdResult { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string NormType { get; set; }

        public virtual Result IdResultNavigation { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
