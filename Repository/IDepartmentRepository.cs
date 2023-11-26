using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetById(string id);
        void Add(Department hospital);
        void Update(Department hospital);
        void Remove(string id);
    }
}
