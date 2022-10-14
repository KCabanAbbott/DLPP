using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.DataModels.Admin
{
    [Table("AnimalPart")]
    public class AnimalPart
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("AnimalPart")]

        public string? _AnimalPart { get; set; }

        //public virtual List<Component> component { get; set; } = new List<Component>();
        [NotMapped]
        public bool IsDeleted { get; set; } = false;

    }
}
