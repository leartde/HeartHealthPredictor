using Api.Enums;

namespace Api.DTOs.ClinicalRecord;

public class AddClinicalRecordDto
{
  public int PatientId { get; set; }
  public int RecordedByDoctorId { get; set; }
  public ChestPainType ChestPainType { get; set; }
  public int RestingBloodPressure { get; set; }
  public int CholesterolTotal { get; set; }
  public int FastingBloodSugar { get; set; }
  public RestECG RestECG { get; set; }
  public int MaximumHeartRate { get; set; }
  public bool ExerciseInducedAngina { get; set; }
  public double OldPeak { get; set; }
  public Slope Slope { get; set; }
  public int MajorVesselsColored { get; set; }
  public Thalassemia Thalassemia { get; set; }
}
