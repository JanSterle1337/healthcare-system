using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public interface IMedicineRepository
    {
        List<Medicine> GetAll();
        Medicine GetById(string id);
        void Add(Medicine medicine);
        void Update(Medicine medicine);
        void Remove(string id);
    }
}
