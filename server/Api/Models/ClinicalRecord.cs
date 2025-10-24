using Api.Enums;

namespace Api.Models;

public class ClinicalRecord
{
  public int Id { get; set; }
  public Patient? Patient { get; set; }
  public int PatientId { get; set; }
  public Doctor? RecordedByDoctor { get; set; }
  public int RecordedByDoctorId { get; set; }
  public DateTime RecordedDate { get; set; } = DateTime.UtcNow;
  public ChestPainType ChestPainType { get; set; }
  public int RestingBloodPressure { get; set; }
  public int CholesterolTotal { get; set; }   //serum cholesterol in mg/dl
  public bool FastingBloodSugar { get; set; }  //fasting blood sugar > 120 mg/d
  public RestECG RestEcg { get; set; }
  public int MaximumHeartRate { get; set; }
  public bool ExerciseInducedAngina { get; set; }
  public double OldPeak { get; set; } //ST depression induced by exercise relative to rest
  public Slope Slope { get; set; } // the slope of the peak exercise ST segment
  public int MajorVesselsColored { get; set; } // 0-3
  public Thalassemia Thalassemia  { get; set; }
  public bool Label { get; set; }
  public double Probability { get; set; }
}
