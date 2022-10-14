using datamgmt.domain.DataModels.Admin;
using datamgmt.domain.DbContexts;
using datamgmt.domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.Repositories
{
    public class SupplierRepository : ISupplierRepository, IDisposable
    {
        private DataMgmtDbContext context;
        public SupplierRepository(DataMgmtDbContext context)
        {
            this.context = context;
        }

        public void DeleteSupplier(int Id)
        {
            Supplier supplier = context.Supplier.Find(Id);
            context.Supplier.Remove(supplier);
        }

        //public async Task<IEnumerable<USBException>> FindSupplier(string searchString)
        //{
        //    return await context.USBException.Where(s =>
        //        (s._Supplier.Contains(searchString)) || searchString == null  
        //    ).ToListAsync();
        //}

        public async Task<IEnumerable<Supplier>> GetSupplier()
        {
            return await context.Supplier.ToListAsync();
        }

        public Supplier GetSupplierByID(int supplierId)
        {
            return context.Supplier.Find(supplierId);
        }

        public void InsertSupplier(Supplier supplier)
        {
            context.Supplier.Add(supplier);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            context.Entry(supplier).State = EntityState.Modified;
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<IEnumerable<Supplier>> FindSupplier(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
