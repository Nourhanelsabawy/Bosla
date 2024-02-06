namespace BoslaAPI.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public int PatId { get; set; }
        public string Diagnose { get; set; } = null!;
        public string Prescription { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        // Relationship 1(Patient) => N(MedicalHistories)
        public Patient Patient { get; set; } = null!;
    }
}