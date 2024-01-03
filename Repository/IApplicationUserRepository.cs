using healthcare_system.Data;
using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetAll();
        ApplicationUser GetById(string id);
        ApplicationUser GetUserByEmail(string email);
        void Add(ApplicationUser user);
        void Update(ApplicationUser user);
        void Remove(string id);
    }
}
