using healthcare_system.Data;
using healthcare_system.Models;

namespace healthcare_system.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ApplicationUser> GetAll()
        {
            //return _db.Appl.ToList();
            return _db.ApplicationUsers.ToList();
        }

        public ApplicationUser GetById(string id)
        {
            return _db.ApplicationUsers.Find(id);
        }

        public void Add(ApplicationUser user)
        {
            _db.ApplicationUsers.Add(user);
            _db.SaveChanges();
        }

        public void Update(ApplicationUser user)
        {
            _db.ApplicationUsers.Update(user);
            _db.SaveChanges();
        }

        public void Remove(string id)
        {
            var user = _db.ApplicationUsers.Find(id);

            if (user != null)
            {
                _db.ApplicationUsers.Remove(user);
                _db.SaveChanges();
            }
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            return _db.ApplicationUsers.FirstOrDefault(user => user.Email == email);
            
        } 
    }
}
