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
    public class ComponentRepo : IComponent, IDisposable
    {
        private DataMgmtDbContext context;
        public ComponentRepo(DataMgmtDbContext context)
        {
            this.context = context;
        }
        public void DeleteComponents(int Id)
        {
            Components component = context.Components.Find(Id);
            context.Components.Remove(component);
        }

        public async Task<IEnumerable<Components>> FindComponents(string searchString)
        {
            return await context.Components.Where(s =>
                (s.ManufacturerID.ToString().Contains(searchString)) || searchString == null
            ).ToListAsync();
        }

        public async Task<IEnumerable<Components>> GetComponents()
        {
            return await context.Components.ToListAsync();
        }

        public Components GetComponentsByID(int studentId)
        {
            return context.Components.Find(studentId);

        }

        public void InsertComponents(Components animalPart)
        {
            context.Components.Add(animalPart);

        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateComponents(Components animalPart)
        {
            context.Entry(animalPart).State = EntityState.Modified;
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

    }
}
