using Api.Data;
using Api.DTOs.Patient;
using Api.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientController : ControllerBase
{
  private readonly ApplicationDbContext _context;
  public PatientController(ApplicationDbContext context)
  {
    _context = context;
  }
  [HttpGet]
  public async Task<IActionResult> GetPatients()
  {
    var patients = await _context.Patients.ToListAsync();
    return Ok(patients.Select(p => p.ToDto()));
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetPatient(int id)
  {
    if (id < 1) return BadRequest("Invalid id");
    var patient = await _context.Patients.FindAsync(id);
    if (patient is null) return BadRequest($"Patient with id: {id} not found");
    return Ok(patient.ToDto());
  }

  [HttpPost]
  public async Task<IActionResult> CreatePatient(AddPatientDto patientDto)
  {
     var patient = patientDto.ToEntity();
      await _context.Patients.AddAsync(patient);
    await _context.SaveChangesAsync();
    return Ok(patient);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeletePatient(int id)
  {
    if (id < 1) return BadRequest("Invalid id");
    var patient = await _context.Patients.FindAsync(id);
    if (patient is null) return BadRequest($"Patient with id: {id} not found");
    _context.Patients.Remove(patient);
    await _context.SaveChangesAsync();
    return Ok($"Patient with id: {id} successfully deleted from the database.");
  }
}
