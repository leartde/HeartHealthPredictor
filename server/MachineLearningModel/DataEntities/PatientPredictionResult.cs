namespace MachineLearningModel.DataEntities;

public class PatientPredictionResult : HeartDiseasePrediction
{
  public string TrainerName { get; set; } = string.Empty;
  public string PatientType { get; set; } = string.Empty;
  public DateTime Timestamp { get; set; }

  public override string ToString()
  {
    return $"\nTrainer: {TrainerName}" +
           $"\nPatient Type: {PatientType}" +
           $"\nPredicted probability: {Probability}" +
           $"\nPredicted label: {Prediction}" +
           $"\nTimestamp : {Timestamp}";
  }
}
