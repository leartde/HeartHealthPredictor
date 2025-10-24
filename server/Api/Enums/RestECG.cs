using System.ComponentModel.DataAnnotations;

namespace Api.Enums;

public enum RestECG
{
  [Display(Name = "Normal")]
  Normal = 0,
  [Display(Name = "Having ST-T wave abnormality")]
  STTWaveAbnormality = 1,
  [Display(Name = "Showing probable or definite left ventricular hypertrophy by Estes' criteria")]
  LeftVentricularHypertrophy = 2
}
