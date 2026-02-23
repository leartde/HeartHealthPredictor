using MachineLearningModel.Utilities;
using Microsoft.ML;
using SdcaOptions = Microsoft.ML.Trainers.SdcaLogisticRegressionBinaryTrainer.Options;

namespace MachineLearningModel.Trainers;

public class SdcaLogisticRegressionTrainer : ITrainer
{
  public ITransformer BuildAndTrainModel(MLContext context, IDataView splitTrainTest)
  {
    var options = new SdcaOptions
    {
      MaximumNumberOfIterations = 300,
      L1Regularization = 0.0001f,
      L2Regularization = 0.001f,
      ConvergenceTolerance = 1e-5f,
      PositiveInstanceWeight = 1.4f
    };

    var pipeline = FeatureTransformer.Concatenate(context)
      .Append(context.Transforms.NormalizeMeanVariance("Features"))
      .Append(context.BinaryClassification.Trainers.SdcaLogisticRegression(options));

    return pipeline.Fit(splitTrainTest);
  }
}
