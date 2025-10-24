using Api.DTOs.Appointment;
using Api.Models;

namespace Api.Mapping;

public static class AppointmentMapping
{
  public static ViewAppointmentDto ToDto(this Appointment entity)
  {
    return new ViewAppointmentDto
    {
      Id = entity.Id,
      Patient = entity.Patient?.ToDto(),
      Doctor = entity.Doctor?.ToDto(),
      Time = entity.Time
    };
  }

  public static Appointment ToEntity(this AddAppointmentDto dto)
  {
    return new Appointment
    {
      PatientId = dto.PatientId,
      DoctorId = dto.DoctorId,
      Time = dto.Time
    };
  }
}
