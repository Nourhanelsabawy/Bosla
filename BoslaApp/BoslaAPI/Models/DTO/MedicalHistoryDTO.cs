using System.ComponentModel.DataAnnotations;

namespace BoslaAPI.Models.DTO
{
    public class MedicalHistoryDTO
    {
        public string? PatientName { get; set; }
        public int PatientAge { get; set; }
        public string? DoctorPhone { get; set; }
        public string? PatientDisease { get; set; }

        [Required(ErrorMessage = "Patient Phone is required.")]
        public string PatientPhone { get; set; } = null!;

        [Required(ErrorMessage = "Diagnose is required.")]
        [StringLength(255, ErrorMessage = "Diagnose cannot exceed 255 characters.")]
        public string Diagnose { get; set; } = null!;

        [Required(ErrorMessage = "Prescription is required.")]
        [StringLength(255, ErrorMessage = "Prescription cannot exceed 255 characters.")]
        public string Prescription { get; set; } = null!;


    }
}
