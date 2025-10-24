using Api.DTOs.Patient;
using Api.Models;

namespace Api.Mapping;

public static class PatientMapping
{
  public static ViewPatientDto ToDto(this Patient entity)
  {
    return new ViewPatientDto
    {
      Id = entity.Id,
      FirstName = entity.FirstName,
      LastName = entity.LastName,
      Age = CalculateAge(entity.DateOfBirth),
      Sex = entity.Sex.ToString(),
      PhoneNumber = entity.PhoneNumber,
      Email = entity.Email,
      CreatedAt = entity.CreatedAt
    };
  }

  public static Patient ToEntity(this AddPatientDto dto)
  {
    return new Patient
    {
      FirstName = dto.FirstName,
      LastName = dto.LastName,
      DateOfBirth = dto.DateOfBirth,
      PhoneNumber = dto.PhoneNumber,
      Sex = dto.Sex,
      Email = dto.Email
    };
  }
  
  private static int CalculateAge(DateOnly dob)
  {
    var today = DateOnly.FromDateTime(DateTime.UtcNow);
    var age = today.Year - dob.Year;
    if (dob > today.AddYears(-age))
      age--;
    return age;
  }
}
