using System.ComponentModel.DataAnnotations;

namespace Api.Enums;

public enum Sex
{
  [Display(Name = "Female")]
  Female = 0,
  [Display(Name = "Male")]
  Male = 1
}
