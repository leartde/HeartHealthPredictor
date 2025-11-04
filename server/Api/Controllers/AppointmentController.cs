using Api.Data;
using Api.DTOs.Appointment;
using Api.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/appointments")]
public class AppointmentController : ControllerBase
{
  private readonly ApplicationDbContext _context;

  public AppointmentController(ApplicationDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<IActionResult> GetAppointments()
  {
    var appointments = await _context.Appointments
      .Include(a => a.Doctor)
      .Include(a => a.Patient)
      .ToListAsync();
    return Ok(appointments.Select(a => a.ToDto()));
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetAppointment(int id)
  {
    var appointment = await _context.Appointments
      .Where(a => a.Id == id)
      .Include(a => a.Doctor)
      .Include(a => a.Patient)
      .SingleOrDefaultAsync();

    if (appointment is null) return BadRequest($"Couldn't find appointment with id: {id}");

    return Ok(appointment.ToDto());
  }

  [HttpPost]
  public async Task<IActionResult> CreateAppointment(AddAppointmentDto dto)
  {
    var appointmentToAdd = dto.ToEntity();
    await _context.Appointments.AddAsync(appointmentToAdd);
    await _context.SaveChangesAsync();
    return Ok(appointmentToAdd.ToDto());
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteAppointment(int id)
  {
    var appointment = await _context.Appointments
      .FindAsync(id);
    if (appointment is null) return BadRequest($"Couldn't find appointment with id: {id}");

    _context.Appointments.Remove(appointment);
    await _context.SaveChangesAsync();
    return Ok($"Appointment with id: {id} successfully deleted.");
  }
}
