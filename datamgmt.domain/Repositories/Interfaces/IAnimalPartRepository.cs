using datamgmt.domain.DataModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.Repositories.Interfaces
{
    public interface IAnimalPartRepository : IDisposable
    {
        Task<IEnumerable<AnimalPart>> GetAnimalPart();
        Task<IEnumerable<AnimalPart>> FindAnimalPart(string searchString);
        AnimalPart GetAnimalPartByID(int studentId);
        void InsertAnimalPart(AnimalPart animalPart);
        void DeleteAnimalPart(int Id);
        void UpdateAnimalPart(AnimalPart animalPart);
        void Save();
    }
}
