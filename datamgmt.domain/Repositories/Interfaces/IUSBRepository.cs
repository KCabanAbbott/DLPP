using datamgmt.domain.DataModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.Repositories.Interfaces
{
    public interface IUSBRepository : IDisposable
    {
        Task<IEnumerable<USBException>> GetSupplier();
        Task<IEnumerable<USBException>> FindUSB(string searchFirst, string searchEmail, string searchLast, string search511);
        Task<IEnumerable<USBException>> FindUSBTwoOptions(string searchFirst, string searchEmail, string searchLast, string search511);
        //  Task<IEnumerable<USBException>> FindEmail(string searchEmail);
        USBException GetSupplierByID(int supplierId);
        void InsertSupplier(USBException supplier);
        void DeleteSupplier(int Id);
        void UpdateSupplier(USBException supplier);
        void Save();
    }
}
