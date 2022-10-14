using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.DataModels.Admin
{
    public class AnimalSpecies
    {
        public int ID { get; set; }
        public string? Species { get; set; }
        //public virtual List<Component> component { get; set; } = new List<Component>();
        [NotMapped]
        public bool IsDeleted { get; set; } = false;
    }
}
