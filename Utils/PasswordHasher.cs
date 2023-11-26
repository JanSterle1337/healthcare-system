namespace healthcare_system.Utils
{
    public class PasswordHasher
    {
        public String hashPassword(String password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);        
        }

        public bool verifyPassword(String inputPassword, String hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(inputPassword, hashedPassword);
        }
    }
}
