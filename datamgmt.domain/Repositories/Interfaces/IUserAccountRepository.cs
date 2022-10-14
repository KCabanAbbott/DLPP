using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datamgmt.domain.DataModels.Admin;


namespace datamgmt.domain.Repositories.Interfaces
{
    public interface IUserAccountRepository : IDisposable
    {
        Task<IEnumerable<UserAccount>> GetUserAccounts();
        Task<IEnumerable<UserAccount>> FindUserAccounts(string searchString);
        UserAccount GetUserAccountByID(int studentId);
        void InsertUserAccount(UserAccount userAccount);
        void DeleteUserAccount(int Id);
        void UpdateUserAccount(UserAccount userAccount);
        void Save();
    }
}
