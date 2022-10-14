using datamgmt.domain.DataModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.Repositories.Interfaces
{
    public interface ILocalFolderRemediationRepository : IDisposable
    {
        Task<IEnumerable<LocalFolderRemediation>> GetFolder();
        Task<IEnumerable<LocalFolderRemediation>> FindFolder(string searchString);
        LocalFolderRemediation GetFolderByID(int supplierId);
        void InsertFolder(LocalFolderRemediation supplier);
        void DeleteFolder(int Id);
        void UpdateFolder(LocalFolderRemediation supplier);
        void Save();
    }
}
