using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.DataModels.Admin
{
    [Table("USBExceptions")]
    public class LocalFolderRemediation
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("StartTime")]

        public string? StartTime { get; set; }

        [Column("EndTime")]

        public string? EndTime { get; set; }
        [Column("Email")]

        public string? Email { get; set; }
        [Column("Name")]

        public string? Name { get; set; }

        [Column("EmailSignature")]

        public string? EmailSignature { get; set; }

        [Column("DeviceName")]

        public string? DeviceName { get; set; }
        [Column("IsComplete")]

        public string? IsComplete { get; set; }

    


    }
}
