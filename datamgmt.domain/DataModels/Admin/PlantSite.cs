using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.DataModels.Admin
{
    public class PlantSite
    {
        public int ID { get; set; }
        public string? Site { get; set; }
        [NotMapped]
        public bool IsDeleted { get; set; } = false;
    }
}
