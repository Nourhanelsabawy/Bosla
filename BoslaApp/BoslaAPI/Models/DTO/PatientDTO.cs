using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoslaAPI.Models.DTO
{
    public class PatientDTO
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Age is required.")]
        [Range(5, 100, ErrorMessage = "Age must be between 5 and 100.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        //[RegularExpression("(?i)^(Male|Female|Other)$", ErrorMessage = "Invalid gender.")]
        public string Gender { get; set; } = null!;

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "Phone is required.")]
        //[RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; } = null!;

        [DisplayName("Profile Image")]
        public IFormFile? ProfileImage { get; set; }

        [DisplayName("Profile Image Name")]
        public string? ProfileImageName { get; set; }

        [Required(ErrorMessage = "Relative Name is required.")]
        [StringLength(100, ErrorMessage = "Relative Name cannot exceed 100 characters.")]
        [DisplayName("Relative Name")]
        public string RelativeName { get; set; } = null!;

        [Required(ErrorMessage = "Relative Phone is required.")]
        //[RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid relative phone number.")]
        [DisplayName("Relative Phone")]
        public string RelativePhone { get; set; } = null!;

        [Required(ErrorMessage = "Doctor Name is required.")]
        [StringLength(100, ErrorMessage = "Doctor Name cannot exceed 100 characters.")]
        [DisplayName("Doctor Name")]
        public string DrName { get; set; } = null!;

        [Required(ErrorMessage = "Doctor Phone is required.")]
        //[RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid doctor phone number.")]
        [DisplayName("Doctor Phone")]
        public string DrPhone { get; set; } = null!;

        [Required(ErrorMessage = "Blood Type is required.")]
        [RegularExpression("^(A\\+|A\\-|B\\+|B\\-|AB\\+|AB\\-|O\\+|O\\-)$", ErrorMessage = "Invalid blood type.")]
        [DisplayName("Blood Type")]
        public string BloodType { get; set; } = null!;

        [Required(ErrorMessage = "Disease is required.")]
        [StringLength(100, ErrorMessage = "Disease cannot exceed 100 characters.")]
        public string Disease { get; set; } = null!;

        [Required(ErrorMessage = "Allergic Foods are required.")]
        [StringLength(250, ErrorMessage = "Allergic Foods cannot exceed 250 characters.")]
        [DisplayName("Allergic Foods")]
        public string AllergicFoods { get; set; } = null!;
    }
}
