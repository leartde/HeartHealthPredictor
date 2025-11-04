using MachineLearningModel.DataEntities;
using Microsoft.ML;
using Microsoft.ML.Transforms;

namespace MachineLearningModel.Trainers;

public static class FeatureTransformer
{
  public static ColumnConcatenatingEstimator Concatenate(MLContext context)
  {
    return context.Transforms.Concatenate("Features",
      nameof(HeartDiseaseData.Age),
      nameof(HeartDiseaseData.Sex),
      nameof(HeartDiseaseData.Cp),
      nameof(HeartDiseaseData.Trestbps),
      nameof(HeartDiseaseData.Chol),
      nameof(HeartDiseaseData.Fbs),
      nameof(HeartDiseaseData.Restecg),
      nameof(HeartDiseaseData.Thalach),
      nameof(HeartDiseaseData.Exang),
      nameof(HeartDiseaseData.Oldpeak),
      nameof(HeartDiseaseData.Slope),
      nameof(HeartDiseaseData.Ca),
      nameof(HeartDiseaseData.Thal));
  }
}
