using Api.DTOs.ClinicalRecord;
using Api.Helpers;
using Api.Models;

namespace Api.Mapping;

public static class ClinicalRecordMapping
{
  public static ViewClinicalRecordDto ToDto(this ClinicalRecord entity)
  {
    return new ViewClinicalRecordDto
    {
      Id = entity.Id,
      Patient = entity.Patient?.ToDto(),
      RecordedByDoctor = entity.RecordedByDoctor?.ToDto(),
      RecordedDate = entity.RecordedDate,
      ChestPainType = entity.ChestPainType.GetDisplayName(),
      RestingBloodPressure = entity.RestingBloodPressure,
      CholesterolTotal = entity.CholesterolTotal,
      FastingBloodSugar =
        entity.FastingBloodSugar ? "Greater than or equal to 120 mg/ml" : "Lower than 120 mg/ml",
      RestEcg = entity.RestEcg.GetDisplayName(),
      MaximumHeartRate = entity.MaximumHeartRate,
      ExerciseInducedAngina = entity.ExerciseInducedAngina,
      OldPeak = entity.OldPeak,
      Slope = entity.Slope.ToString(),
      MajorVesselsColored = entity.MajorVesselsColored,
      Thalassemia = entity.Thalassemia.GetDisplayName(),
      Label = entity.Label,
      Probability = entity.Probability
    };
  }

  public static ClinicalRecord ToEntity(this AddClinicalRecordDto dto)
  {
    return new ClinicalRecord
    {
      PatientId = dto.PatientId,
      RecordedByDoctorId = dto.RecordedByDoctorId,
      ChestPainType = dto.ChestPainType,
      RestingBloodPressure = dto.RestingBloodPressure,
      CholesterolTotal = dto.CholesterolTotal,
      FastingBloodSugar = dto.FastingBloodSugar >= 120,
      RestEcg = dto.RestECG,
      MaximumHeartRate = dto.MaximumHeartRate,
      ExerciseInducedAngina = dto.ExerciseInducedAngina,
      OldPeak = dto.OldPeak,
      Slope = dto.Slope,
      MajorVesselsColored = dto.MajorVesselsColored,
      Thalassemia = dto.Thalassemia
    };
  }
}
