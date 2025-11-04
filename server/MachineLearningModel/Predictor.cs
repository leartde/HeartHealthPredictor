using MachineLearningModel.DataEntities;
using Microsoft.ML;

namespace MachineLearningModel;

public static class Predictor
{
  public static HeartDiseasePrediction UseModelWithSingleItem(MLContext context, ITransformer model,
    HeartDiseaseData sampleData)
  {
    var predictionEngine
      = context.Model.CreatePredictionEngine<HeartDiseaseData, HeartDiseasePrediction>(model);

    var resultPrediction = predictionEngine.Predict(sampleData);
    Console.WriteLine();
    Console.WriteLine("=============== Prediction Test of model with a single sample and test dataset ===============");
    Console.WriteLine();
    Console.WriteLine(
      $"Patient medical data: {sampleData} | Prediction: {(resultPrediction.Prediction ? "Positive" : "Negative")} | Probability: {resultPrediction.Probability} Score: {resultPrediction.Score}");

    Console.WriteLine("=============== End of Predictions ===============");
    Console.WriteLine();
    return resultPrediction;
  }
}
