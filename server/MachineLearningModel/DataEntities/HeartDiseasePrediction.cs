using Microsoft.ML.Data;

namespace MachineLearningModel.DataEntities;

public class HeartDiseasePrediction
{
  [ColumnName("PredictedLabel")] public bool Prediction { get; set; }
  [ColumnName("Probability")] public float Probability { get; set; }
  [ColumnName("Score")] public float Score { get; set; }
}
