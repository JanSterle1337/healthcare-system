using healthcare_system.Data;
using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;

        public DepartmentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Department> GetAll()
        {
            return _db.Departments.ToList();
        }

        public Department GetById(string id)
        {
            return _db.Departments.Find(id);
        }

        public void Add(Department department)
        {
            _db.Departments.Add(department);
            _db.SaveChanges();
        }

        public void Update(Department department)
        {
            _db.Departments.Update(department);
            _db.SaveChanges();
        }

        public void Remove(string id)
        {
            var department = _db.Departments.Find(id);

            if (department != null)
            {
                _db.Departments.Remove(department);
                _db.SaveChanges();
            }
        }
    }
}
