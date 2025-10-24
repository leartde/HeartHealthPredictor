using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Api.Enums;

namespace Api.Models;

public class Patient
{
  public int Id { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public DateOnly DateOfBirth { get; set; }
  public Sex Sex { get; set; }
  [Phone]
  public string PhoneNumber { get; set; } = string.Empty;
  [EmailAddress]
  public string Email { get; set; } = string.Empty;
  public DateTime CreatedAt = DateTime.Now;
}
