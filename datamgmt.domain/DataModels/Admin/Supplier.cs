using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.DataModels.Admin
{
    public class Supplier
    {
        public int ID { get; set; }
        [Column("Supplier")]
        public string? _Supplier { get; set; }

    }
}
