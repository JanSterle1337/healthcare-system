using healthcare_system.Models;

namespace healthcare_system.Data.Mock
{
    public class DepartmentMock
    {

        private readonly ApplicationDbContext _db;

        public DepartmentMock(ApplicationDbContext db) 
        {
            _db = db;
        }

        public void seedDepartments()
        {
            var mockDepartments = new List<Department>
            {
                new Department
                {
                    DepartmentId = "A1",
                    Name = "Kardiologija",
                    Floor = "1",
                    HospitalId = "A",
                },
                new Department
                {
                    DepartmentId = "A2",
                    Name = "Endokrinologija",
                    Floor = "1",
                    HospitalId = "A",
                },
                new Department
                {
                    DepartmentId = "A3",
                    Name = "Gastroentrologija",
                    Floor = "1",
                    HospitalId = "A",
                },
                new Department
                {
                    DepartmentId = "B1",
                    Name = "Hematologija",
                    Floor = "2",
                    HospitalId = "A",
                },
                new Department
                {
                    DepartmentId = "B2",
                    Name = "Hipertenzija",
                    Floor = "2",
                    HospitalId = "A",
                },
                new Department
                {
                    DepartmentId = "B3",
                    Name = "Intenzivna interna medicina",
                    Floor = "2",
                    HospitalId = "A",
                },
                new Department
                {
                    DepartmentId = "C1",
                    Name = "Internistična prva pomoč",
                    Floor = "3",
                    HospitalId = "A",
                },
                new Department
                {
                    DepartmentId = "C2",
                    Name = "Intenzivna interna medicina",
                    Floor = "2",
                    HospitalId = "A",
                },
            };

            var existingDepartmentIds = _db.Departments.Select(p => p.DepartmentId).ToList();

            foreach (var mockDepartment in mockDepartments)
            {
                if (!existingDepartmentIds.Contains(mockDepartment.DepartmentId))
                {
                    _db.Departments.Add(mockDepartment);
                }
            }

            _db.SaveChanges();

        }
    }
}
