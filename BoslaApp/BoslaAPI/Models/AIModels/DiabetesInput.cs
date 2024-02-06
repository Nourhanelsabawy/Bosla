using System.ComponentModel.DataAnnotations;

namespace BoslaAPI.Models.AIModels
{
    public class DiabetesInput
    {
        [Required(ErrorMessage = "Pregnancies is required.")]
        public int Pregnancies { get; set; }

        [Required(ErrorMessage = "Glucose is required.")]
        public int Glucose { get; set; }

        [Required(ErrorMessage = "BloodPressure is required.")]
        public int BloodPressure { get; set; }

        [Required(ErrorMessage = "SkinThickness is required.")]
        public int SkinThickness { get; set; }

        [Required(ErrorMessage = "Insulin is required.")]
        public int Insulin { get; set; }

        [Required(ErrorMessage = "BMI is required.")]
        public decimal BMI { get; set; }

        [Required(ErrorMessage = "DiabetesPedigreeFunction is required.")]
        public decimal DiabetesPedigreeFunction { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
    }
}
