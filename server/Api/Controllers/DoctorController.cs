using Api.Data;
using Api.DTOs.Doctor;
using Api.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/doctors")]
public class DoctorController : ControllerBase
{
  private readonly ApplicationDbContext _context;

  public DoctorController(ApplicationDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<IActionResult> GetDoctors()
  {
    var doctors = await _context.Doctors.ToListAsync();
    return Ok(doctors.Select(s => s.ToDto()));
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetDoctor(int id)
  {
    if (id < 1) return BadRequest("Invalid id");
    var doctor = await _context.Doctors.FindAsync(id);
    if (doctor is null) return BadRequest($"Can't find doctor with id: {id}");
    return Ok(doctor.ToDto());
  }

  [HttpPost]
  public async Task<IActionResult> CreateDoctor(AddDoctorDto dto)
  {
    var doctorToAdd = dto.ToEntity();
    await _context.Doctors.AddAsync(doctorToAdd);
    await _context.SaveChangesAsync();
    return Ok(doctorToAdd.ToDto());
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteDoctor(int id)
  {
    if (id < 1) return BadRequest("Invalid id");
    var doctor = await _context.Doctors.FindAsync(id);
    if (doctor is null) return BadRequest($"Can't find doctor with id: {id}");
    _context.Doctors.Remove(doctor);
    await _context.SaveChangesAsync();
    return Ok($"Doctor with id: {id} successfully deleted from the database");
  }
}
