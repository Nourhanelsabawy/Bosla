using System.ComponentModel.DataAnnotations;

namespace BoslaAPI.Models.AIModels
{
    public class AlzheimerInput
    {
        [Required(ErrorMessage = "Age is required.")]
        public decimal Age { get; set; }

        [Required(ErrorMessage = "SES is required.")]
        public decimal SES { get; set; }

        [Required(ErrorMessage = "MMSE is required.")]
        public decimal MMSE { get; set; }

        [Required(ErrorMessage = "CDR is required.")]
        public decimal CDR { get; set; }

        [Required(ErrorMessage = "eTIV is required.")]
        public decimal eTIV { get; set; }

        [Required(ErrorMessage = "nWBV is required.")]
        public decimal nWBV { get; set; }

        [Required(ErrorMessage = "ASF is required.")]
        public decimal ASF { get; set; }

        [Required(ErrorMessage = "Visit is required.")]
        public decimal Visit { get; set; }

        [Required(ErrorMessage = "MRDelay is required.")]
        public decimal MRDelay { get; set; }
    }
}
