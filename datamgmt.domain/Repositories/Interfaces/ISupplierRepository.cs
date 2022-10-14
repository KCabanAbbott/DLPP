using datamgmt.domain.DataModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.Repositories.Interfaces
{
    public interface ISupplierRepository : IDisposable
    {
        Task<IEnumerable<Supplier>> GetSupplier();
        Task<IEnumerable<Supplier>> FindSupplier(string searchString);
        Supplier GetSupplierByID(int supplierId);
        void InsertSupplier(Supplier supplier);
        void DeleteSupplier(int Id);
        void UpdateSupplier(Supplier supplier);
        void Save();
    }
}
