using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.DataModels.Admin
{
    [Table("Component")]
    public partial class Components
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        public int PartTypeID { get; set; }
        public int PartClassificationID { get; set; }
        public int SupplierID { get; set; }
        public int PurchaserUserID { get; set; }
        public int ManufacturerID { get; set; }
        public int ManufacturedDateTime { get; set; }
        public int PlantSiteID { get; set; }
        public bool PartDelivered { get; set; }
        public bool DocumentDelivered { get; set; }
        public bool AnimalContent { get; set; }
        public string? UOM { get; set; }
        public string? PartNumber { get; set; }
        public string? LotNumber { get; set; }
        public string? PartDescription { get; set; }
        public DateTime? PurchasedDateTime { get; set; }
        //[NotMapped]
        public virtual List<AnimalContentDetail> contentDetailList { get; set; } = new List<AnimalContentDetail>();
        public virtual PartClassification partClassification { get; private set; }
        public virtual PartType partType { get; private set; }
        public virtual Supplier supplier { get; private set; }
        public virtual Manufacturer manufacturer { get; private set; }
        public virtual PlantSite plantSite { get; private set; }
        //public virtual List<AnimalSpecies> animalSpeciesList { get; set; } = new List<AnimalSpecies>();
    }
}
