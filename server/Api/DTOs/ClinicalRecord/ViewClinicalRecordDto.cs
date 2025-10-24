using Api.DTOs.Doctor;
using Api.DTOs.Patient;

namespace Api.DTOs.ClinicalRecord;

public class ViewClinicalRecordDto
{
  public int Id { get; set; }
  public ViewPatientDto? Patient { get; set; }
  public ViewDoctorDto? RecordedByDoctor { get; set; }
  public DateTime RecordedDate { get; set; }
  public string ChestPainType { get; set; } = string.Empty;
  public int RestingBloodPressure { get; set; }
  public int CholesterolTotal { get; set; }
  public string FastingBloodSugar { get; set; } = string.Empty;
  public string RestEcg { get; set; } = string.Empty;
  public int MaximumHeartRate { get; set; }
  public bool ExerciseInducedAngina { get; set; }
  public double OldPeak { get; set; }
  public string Slope { get; set; } = string.Empty;
  public int MajorVesselsColored { get; set; }
  public string Thalassemia { get; set; } = string.Empty;
  public bool Label { get; set; }
  public double Probability { get; set; }
}
