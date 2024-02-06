using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoslaAPI.Models.DTO
{
    public class ChildDTO
    {
        public int ChildId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 18, ErrorMessage = "Age must be between 1 and 18.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        //[RegularExpression("(?i)^(Male|Female|Other)$", ErrorMessage = "Invalid gender.")]
        public string Gender { get; set; } = null!;

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
        public string Address { get; set; } = null!;

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
    }
}
