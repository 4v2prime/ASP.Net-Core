namespace Core_ConsumeAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string State { get; set; } = null!;
        public int Pincode { get; set; }

        public List<Student> ListStudent { get; set; } =null!;

    }
    public class Country
    {
        public string Iso2 { get; set; }
        public string Name { get; set; }
    }
    public class State
    {
        public string Iso2 { get; set; }
        public string Name { get; set; }
    }
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
