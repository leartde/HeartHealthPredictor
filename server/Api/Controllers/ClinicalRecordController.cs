using Api.Data;
using Api.DTOs.ClinicalRecord;
using Api.Mapping;
using MachineLearningModel.DataEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ML;

namespace Api.Controllers;

[ApiController]
[Route("api/clinicalRecords")]
public class ClinicalRecordController : ControllerBase
{
  private readonly ApplicationDbContext _context;
  private readonly PredictionEnginePool<HeartDiseaseData, HeartDiseasePrediction> _predictionEnginePool;

  public ClinicalRecordController(ApplicationDbContext context,
    PredictionEnginePool<HeartDiseaseData, HeartDiseasePrediction> predictionEnginePool)
  {
    _context = context;
    _predictionEnginePool = predictionEnginePool;
  }

  [HttpGet]
  public async Task<IActionResult> GetClinicalRecords()
  {
    var clinicalRecords = await _context.ClinicalRecords
      .Include(m => m.Patient)
      .Include(m => m.RecordedByDoctor)
      .ToListAsync();
    return Ok(clinicalRecords.Select(m => m.ToDto()));
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetClinicalRecord(int id)
  {
    if (id < 1) return BadRequest("Invalid id.");
    var clinicalRecord = await _context.ClinicalRecords.FindAsync(id);
    if (clinicalRecord is null) return BadRequest($"Couldn't find clinical record with id: {id}");
    return Ok(clinicalRecord.ToDto());
  }


  [HttpPost]
  public async Task<IActionResult> CreateClinicalRecord(AddClinicalRecordDto clinicalRecordDto)
  {
    var patient = await _context.Patients.FindAsync(clinicalRecordDto.PatientId);
    if (patient is null) return BadRequest($"Couldn't find patient with id: {clinicalRecordDto.PatientId}");

    var patientDto = patient.ToDto();
    var heartDiseaseData = new HeartDiseaseData
    {
      Age = patientDto.Age,
      Sex = patientDto.Sex == "Male" ? 1f : 0f,
      Cp = (float)clinicalRecordDto.ChestPainType,
      Trestbps = clinicalRecordDto.RestingBloodPressure,
      Chol = clinicalRecordDto.CholesterolTotal,
      Fbs = clinicalRecordDto.FastingBloodSugar >= 120 ? 1f : 0f,
      Restecg = (float)clinicalRecordDto.RestECG,
      Thalach = clinicalRecordDto.MaximumHeartRate,
      Exang = clinicalRecordDto.ExerciseInducedAngina ? 1f : 0f,
      Oldpeak = (float)clinicalRecordDto.OldPeak,
      Slope = (float)clinicalRecordDto.Slope,
      Ca = clinicalRecordDto.MajorVesselsColored,
      Thal = (float)clinicalRecordDto.Thalassemia
    };
    var prediction = await Task.FromResult(_predictionEnginePool.Predict("HeartDiseaseModel", heartDiseaseData));
    var clinicalRecordToAdd = clinicalRecordDto.ToEntity();
    clinicalRecordToAdd.Label = prediction.Prediction;
    clinicalRecordToAdd.Probability = prediction.Probability;
    await _context.ClinicalRecords.AddAsync(clinicalRecordToAdd);
    await _context.SaveChangesAsync();
    return Ok(clinicalRecordToAdd.ToDto());
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteClinicalRecord(int id)
  {
    if (id < 1) return BadRequest("Invalid id.");
    var clinicalRecord = await _context.ClinicalRecords.FindAsync(id);
    if (clinicalRecord is null) return BadRequest($"Couldn't find clinical record with id: {id}");
    _context.ClinicalRecords.Remove(clinicalRecord);
    await _context.SaveChangesAsync();
    return Ok($"Clinical record with id: {id} successfully deleted.");
  }
}
