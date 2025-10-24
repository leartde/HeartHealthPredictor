using System.ComponentModel.DataAnnotations;

namespace Api.Enums;

public enum ChestPainType
{
  [Display(Name = "Typical Angina")]
  TypicalAngina = 1,
  [Display(Name = "Atypical Angina")]
  AtypicalAngina = 2,
  [Display(Name = "Non-anginal Pain")]
  NonAnginalPain = 3,
  [Display(Name = "Asymptomatic")]
  Asymptomatic = 4
}
