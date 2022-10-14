using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.DataModels.Admin
{
    public class ViewModel
    {
        [Key]
        public int Id { get; set; }
        public Components componentVm { get; set; }
        public PartType PartTypeVm { get; set; }
        public Manufacturer ManufacturerVm { get; set; }
        public PartClassification PartClassificationVm { get; set; }
        public Supplier SupplierVm { get; set; }
        public PlantSite PlantSiteVm { get; set; }

    }
}
