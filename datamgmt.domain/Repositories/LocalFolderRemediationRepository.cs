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
    public class LocalFolderRemediationRepository : ILocalFolderRemediationRepository, IDisposable
    {
        private DataMgmtDbContext context;
        public LocalFolderRemediationRepository(DataMgmtDbContext context)
        {
            this.context = context;
        }

        public void DeleteFolder(int Id)
        {
            LocalFolderRemediation supplier = context.LocalFolderRemediation.Find(Id);
            context.LocalFolderRemediation.Remove(supplier);
        }

        public async Task<IEnumerable<LocalFolderRemediation>> FindFolder(string searchString)
        {
            return await context.LocalFolderRemediation.Where(s =>
                (s.Name.Contains(searchString)) || searchString == null
            ).ToListAsync();
        }

        public async Task<IEnumerable<LocalFolderRemediation>> GetFolder()
        {
            return await context.LocalFolderRemediation.ToListAsync();
        }

        public LocalFolderRemediation GetFolderByID(int supplierId)
        {
            return context.LocalFolderRemediation.Find(supplierId);
        }

        public void InsertFolder(LocalFolderRemediation supplier)
        {
            context.LocalFolderRemediation.Add(supplier);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateFolder(LocalFolderRemediation supplier)
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

        //public Task<IEnumerable<LocalFolderRemediation>> FindFolder(string searchString)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
