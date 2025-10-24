namespace Api.DTOs.Appointment;

public class AddAppointmentDto
{
  public int DoctorId { get; set; }
  public int PatientId { get; set; }
  public DateTime Time { get; set; }
}
