using MachineLearningModel.Utilities;
using Microsoft.ML;
using LbfgsOptions = Microsoft.ML.Trainers.LbfgsLogisticRegressionBinaryTrainer.Options;

namespace MachineLearningModel.Trainers;

public class LbfgsLogisticRegressionTrainer : ITrainer
{
  public ITransformer BuildAndTrainModel(MLContext context, IDataView splitTrainTest)
  {
    var options = new LbfgsOptions
    {
      MaximumNumberOfIterations = 300,
      L1Regularization = 0.001f,
      L2Regularization = 0.01f,
      OptimizationTolerance = 1e-7f,
      HistorySize = 50,
      ExampleWeightColumnName = "ExampleWeight"
    };

    var pipeline = FeatureTransformer.Concatenate(context)
      .Append(context.Transforms.NormalizeMeanVariance("Features"))
      .Append(context.Transforms.CustomMapping<LabelInput, WeightOutput>(
        (input, output) => output.ExampleWeight = input.Label ? 1.4f : 1f,
        contractName: "LbfgsWeighting"))
      .Append(context.BinaryClassification.Trainers.LbfgsLogisticRegression(options));

    return pipeline.Fit(splitTrainTest);
  }

  private class LabelInput
  {
    public bool Label { get; set; }
  }

  private class WeightOutput
  {
    public float ExampleWeight { get; set; }
  }
}
