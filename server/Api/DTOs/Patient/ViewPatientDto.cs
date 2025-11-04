using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.Patient;

public class ViewPatientDto
{
  public DateTime CreatedAt = DateTime.Now;
  public int Id { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public int Age { get; set; }
  public string Sex { get; set; } = string.Empty;

  [Phone] public string PhoneNumber { get; set; } = string.Empty;

  [EmailAddress] public string Email { get; set; } = string.Empty;
}
