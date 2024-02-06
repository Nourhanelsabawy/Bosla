namespace BoslaAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Specialization { get; set; } = null!;

        // Relationship 1(Doctor) => N(Patients)
        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
