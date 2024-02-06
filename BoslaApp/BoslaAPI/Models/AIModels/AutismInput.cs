using System.ComponentModel.DataAnnotations;

namespace BoslaAPI.Models.AIModels
{
    public class AutismInput
    {
        [Required(ErrorMessage = "Age is required.")]
        public int age { get; set; }

        [Required(ErrorMessage = "Jaundice information is required.")]
        public int jaundice { get; set; }

        [Required(ErrorMessage = "Austim information is required.")]
        public int austim { get; set; }

        [Required(ErrorMessage = "Result of AQ1-10 screening test is required.")]
        public int result { get; set; }
    }
}
