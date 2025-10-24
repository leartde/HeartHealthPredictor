using Api.DTOs.Doctor;
using Api.DTOs.Patient;

namespace Api.DTOs.Appointment;

public class ViewAppointmentDto
{
  public int Id { get; set; }
  public ViewDoctorDto? Doctor { get; set; }
  public ViewPatientDto? Patient { get; set; }
  public DateTime Time { get; set; }
}
