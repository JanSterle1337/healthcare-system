namespace healthcare_system.Utils
{
    public class AgeCalculator
    {
        public int calculateAgeFromBirth(DateTime birth)
        {
            DateTime currentDate = DateTime.Now.Date;
            int age = currentDate.Year - birth.Year;

            //if (birth.Date > currentDate.AddYears(age))

            return age;
        }
    }
}
