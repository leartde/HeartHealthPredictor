
using System.ComponentModel.DataAnnotations;

namespace HealthcareApi.Enums;

public enum Slope
{
  [Display(Name = "Uplsoping")]
  Uplsoping = 1,
  [Display(Name = "Flat")]
  Flat = 2,
  [Display(Name ="Downsloping")]
  Downsloping = 3,
}
