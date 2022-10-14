using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.DataModels.Admin
{
    public class PartType
    {
        public int ID { get; set; }
        [Column("PartType") ]
        public string _PartType { get; set; }
        [NotMapped]
        public bool IsDeleted { get; set; } = false;
    }
}
