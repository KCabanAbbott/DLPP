using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.DataModels.Admin
{
    public class Manufacturer
    {
        [Column("ID")]
        public int ID { get; set; }
        [Column("Manufacturer")]
        public string? _Manufacturer { get; set; }


    }
}
