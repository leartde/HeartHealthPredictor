using Microsoft.ML.Data;

namespace MachineLearningModel.DataEntities;

public class HeartDiseaseData
{
  [LoadColumn(0)] public float Age { get; set; }
  [LoadColumn(1)] public float Sex { get; set; }
  [LoadColumn(2)] public float Cp { get; set; }
  [LoadColumn(3)] public float Trestbps { get; set; }
  [LoadColumn(4)] public float Chol { get; set; }
  [LoadColumn(5)] public float Fbs { get; set; }
  [LoadColumn(6)] public float Restecg { get; set; }
  [LoadColumn(7)] public float Thalach { get; set; }
  [LoadColumn(8)] public float Exang { get; set; }
  [LoadColumn(9)] public float Oldpeak { get; set; }
  [LoadColumn(10)] public float Slope { get; set; }
  [LoadColumn(11)] public float Ca { get; set; }
  [LoadColumn(12)] public float Thal { get; set; }
  [LoadColumn(13)] public bool Label { get; set; }

  private string ChestPainType(int type)
  {
    return type switch
    {
      0 => "Typical Angina ",
      1 => "Atypical Angina",
      2 => "Non-anginal Pain",
      3 => "Asymptomatic",
      _ => "Invalid Type"
    };
  }

  private string RestEcgResults(int res)
  {
    return res switch
    {
      0 => "Normal",
      1 => "Having ST-T wave abnormality",
      2 => "Showing probable or definite left ventricular hypertrophy by Estes' criteria",
      _ => "Invalid result"
    };
  }

  private string SlopeResults(int slope)
  {
    return slope switch
    {
      0 => "Uplsoping",
      1 => "Flat",
      2 => "Downlsoping",
      _ => "Invalid slope value"
    };
  }

  private string ThalassemiaResults(int thal)
  {
    return thal switch
    {
      0 => "Error",
      1 => "Fixed defect",
      2 => "Normal",
      3 => "Reversible Defect",
      _ => "Invalid value"
    };
  }

  public override string ToString()
  {
    return $"\nAge: {Age} " +
           $"\nSex: {((int)Sex == 1 ? "Male" : "Female")}" +
           $"\nChest pain type: {ChestPainType((int)Cp)}" +
           $"\nResting blood pressure: {Trestbps}" +
           $"\nSerum cholesterol in mg/dl: {Chol}" +
           $"\nFasting blood sugar > 120 mg/dl: {(int)Fbs == 1}" +
           $"\nResting electrocardiographic results: {RestEcgResults((int)Restecg)}" +
           $"\nMaximum heart rate achieved: {Thalach}" +
           $"\nExercise reduced angina : {(int)Exang == 1}" +
           $"\nST depression induced by exercise relative to rest: {Oldpeak}" +
           $"\nThe slope of the peak exercise ST segment: {SlopeResults((int)Slope)}" +
           $"\nNumber of major vessels colored by fluoroscopy : {Ca}" +
           $"\nThalassemia : {ThalassemiaResults((int)Thal)}";
  }
}
