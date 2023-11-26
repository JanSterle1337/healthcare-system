namespace healthcare_system.Utils
{
    public class PasswordHasher
    {
        public String hashPassword(String password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);        
        }

        public bool verifyPassword(String password, String hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
        }
    }
}
