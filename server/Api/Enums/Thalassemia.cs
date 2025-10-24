using System.ComponentModel.DataAnnotations;

namespace Api.Enums;

public enum Thalassemia
{
  Null = 0,
  [Display(Name = "Normal")]
  Normal = 3,
  [Display(Name = "Fixed Defect")]
  FixedDefect = 6,
  [Display(Name = "Reversible Defect")]
  ReversibleDefect  = 7
}
