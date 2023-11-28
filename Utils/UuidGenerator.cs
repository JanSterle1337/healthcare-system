namespace healthcare_system.Utils
{
    public class UuidGenerator
    {
        public String generateUuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
