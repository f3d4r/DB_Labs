using System;
using System.Collections.Generic;

#nullable disable

namespace MyEfProject.Models
{
    public partial class Result
    {
        public Result()
        {
            Norms = new HashSet<Norm>();
        }

        public int IdResult { get; set; }
        public short Mark { get; set; }
        public DateTime DateOfCompletion { get; set; }

        public virtual ICollection<Norm> Norms { get; set; }
    }
}
