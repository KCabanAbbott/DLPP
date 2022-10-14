using datamgmt.domain.DataModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.Repositories.Interfaces
{
    public interface IComponent : IDisposable
    {
        Task<IEnumerable<Components>> GetComponents();
        Task<IEnumerable<Components>> FindComponents(string searchString);
        Components GetComponentsByID(int studentId);
        void InsertComponents(Components animalPart);
        void DeleteComponents(int Id);
        void UpdateComponents(Components animalPart);
        void Save();
    }
}
