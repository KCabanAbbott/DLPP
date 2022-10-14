using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datamgmt.domain.DbContexts;
using datamgmt.domain.Repositories.Interfaces;
using datamgmt.domain.DataModels.Admin;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

namespace datamgmt.domain.Repositories
{
    public class UserAccountRepository : IUserAccountRepository, IDisposable
    {
        private DataMgmtDbContext context;

        public UserAccountRepository(DataMgmtDbContext context)
        {   
            this.context = context;
        }

        public async  Task<IEnumerable<UserAccount>> GetUserAccounts()
        {
            return await context.UserAccounts.ToListAsync();
        }

        public async Task<IEnumerable<UserAccount>> FindUserAccounts(string searchString)
        {
            return await context.UserAccounts.Where(s=>
                (s.FirstName.Contains(searchString) ||
                s.LastName.Contains(searchString) ||
                s.LoginName.Contains(searchString)) || searchString == null
            ).ToListAsync();
        }

        public UserAccount GetUserAccountByID(int id)
        {
            return context.UserAccounts.Find(id);
        }

        public void InsertUserAccount(UserAccount UserAccount)
        {
            context.UserAccounts.Add(UserAccount);
        }

        public void DeleteUserAccount(int UserAccountID)
        {
            UserAccount UserAccount = context.UserAccounts.Find(UserAccountID);
            context.UserAccounts.Remove(UserAccount);
        }

        public void UpdateUserAccount(UserAccount UserAccount)
        {
            context.Entry(UserAccount).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
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

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8604 // Possible null reference argument.
