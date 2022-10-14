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
    public class USBException
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("UPI")]

        public string? UPI { get; set; }

        [Column("Abbott511")]

        public string? Abbott511 { get; set; }
        [Column("Organization")]

        public string? Organization { get; set; }
        [Column("FirstName")]

        public string? FirstName { get; set; }
        [Column("LastName")]

        public string? LastName { get; set; }

        [Column("Country")]

        public string? Country { get; set; }

        [Column("ArcherException")]

        public string? ArcherException { get; set; }
        [Column("AddOrRemove")]

        public string? AddOrRemove { get; set; }
        [Column("ReadWrite")]

        public string? ReadWrite { get; set; }

        //[Column("Created")]

        //public DateTime? Created { get; set; }

        //[Column("Updated")]

        //public DateTime? Updated { get; set; }
        //[Column("CreatedBy")]

        //public string? CreatedBy { get; set; }
        //[Column("UpdatedBy")]

        //public string? UpdatedBy { get; set; }
        [Column("RequestedDate")]

        public string? RequestedDate { get; set; }

        [Column("ItemType")]

        public string? ItemType { get; set; }
        [Column("Path")]

        public string? Path { get; set; }
        [Column("EmailID")]

        public string? EmailID { get; set; }


    }
}
