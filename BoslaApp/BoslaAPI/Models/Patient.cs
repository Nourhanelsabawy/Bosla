namespace BoslaAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public int DrId { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Gender { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? ProfileImage { get; set; }
        public string RelativeName { get; set; } = null!;
        public string RelativePhone { get; set; } = null!;
        public string BloodType { get; set; } = null!;
        public string Disease { get; set; } = null!;
        public string AllergicFoods { get; set; } = null!;

        // Relationship 1(Doctor) => N(Patients)
        public Doctor Doctor { get; set; } = null!;

        // Relationship 1(Patient) => N(MedicalHistories)
        public List<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
    }
}
