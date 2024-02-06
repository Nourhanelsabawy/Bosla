using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoslaAPI.Models.AIModels
{
    public class HeartInput
    {
        [DisplayName("Age")]
        [Required(ErrorMessage = "Age is required.")]
        public int age { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Sex is required.")]
        public int sex { get; set; }

        [DisplayName("Chest Pain Type")]
        [Required(ErrorMessage = "chest pain type is required.")]
        public int cp { get; set; }

        [DisplayName("Resting Blood Pressure")]
        [Required(ErrorMessage = "resting blood pressure is required.")]
        public int trestbps { get; set; }

        [DisplayName("Serum Cholestoral")]
        [Required(ErrorMessage = "serum cholestoral is required.")]
        public int chol { get; set; }

        [DisplayName("Fasting Blood Sugar")]
        [Required(ErrorMessage = "fasting blood sugar is required.")]
        public int fbs { get; set; }

        [DisplayName("Resting Electrocardiographic Results")]
        [Required(ErrorMessage = "resting electrocardiographic results is required.")]
        public int restecg { get; set; }

        [DisplayName("Maximum Heart Rate Achieved")]
        [Required(ErrorMessage = "maximum heart rate achieved is required.")]
        public int thalach { get; set; }

        [DisplayName("Exercise Induced Angina")]
        [Required(ErrorMessage = "exercise induced angina is required.")]
        public int exang { get; set; }

        [DisplayName("ST Depression Induced By Exercise Relative To Rest")]
        [Required(ErrorMessage = "ST depression induced by exercise relative to rest is required.")]
        public decimal oldpeak { get; set; }

        [DisplayName("The Slope Of The Peak Exercise ST Segment")]
        [Required(ErrorMessage = "the slope of the peak exercise ST segment is required.")]
        public int slope { get; set; }

        [DisplayName("Number Of Major Vessels (0-3) Colored By Flourosopy")]
        [Required(ErrorMessage = "number of major vessels (0-3) colored by flourosopy is required.")]
        public int ca { get; set; }

        [DisplayName("Thal: 0 = normal; 1 = fixed defect; 2 = reversable defect")]
        [Required(ErrorMessage = "0 = normal; 1 = fixed defect; 2 = reversable defect is required.")]
        public int thal { get; set; }
    }
}
