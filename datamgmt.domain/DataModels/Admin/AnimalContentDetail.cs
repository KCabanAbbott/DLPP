using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.DataModels.Admin
{
    public partial class AnimalContentDetail
    {
        [Key]
        public int ID { get; set; }
        //[ForeignKey("Component")]
        public int ComponentID { get; set; }
        //[ForeignKey("AnimalSpecies")]
        public int AnimalSpeciesID { get; set; }
        //[ForeignKey("AnimalPart")]
        public int AnimalPartID { get; set; }
        [NotMapped]
        public bool IsDeleted { get; set; } = false;
        public virtual Components component { get; private set; }
        public virtual AnimalPart animalPart { get; private set; }
        public virtual AnimalSpecies animalSpecies { get; private set; }
    }

}
