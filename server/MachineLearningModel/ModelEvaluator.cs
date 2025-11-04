using Microsoft.ML;
using Microsoft.ML.Data;

namespace MachineLearningModel;

public static class ModelEvaluator
{
  public static CalibratedBinaryClassificationMetrics Evaluate(MLContext context, ITransformer model,
    IDataView splitTestSet)
  {
    var predictions = model.Transform(splitTestSet);
    var metrics = context.BinaryClassification.Evaluate(
      predictions,
      "Label",
      "Score"
    );
    Console.WriteLine();
    Console.WriteLine("Model quality metrics evaluation");
    Console.WriteLine("--------------------------------");
    Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
    Console.WriteLine($"Auc: {metrics.AreaUnderRocCurve:P2}");
    Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
    Console.WriteLine($"  LogLoss:           {metrics.LogLoss:0.##}");
    Console.WriteLine($"  LogLossReduction:  {metrics.LogLossReduction:0.##}");
    Console.WriteLine($"  PositivePrecision: {metrics.PositivePrecision:0.##}");
    Console.WriteLine($"  PositiveRecall:    {metrics.PositiveRecall:0.##}");
    Console.WriteLine($"  NegativePrecision: {metrics.NegativePrecision:0.##}");
    Console.WriteLine($"  NegativeRecall:    {metrics.NegativeRecall:0.##}");
    Console.WriteLine("=============== End of model evaluation ===============");
    return metrics;
  }
}
