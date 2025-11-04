using Microsoft.ML;

namespace MachineLearningModel.Trainers;

public class SdcaLogisticRegressionTrainer : ITrainer
{
  public string Name => "SdcaLogisticRegressionTrainer";

  public ITransformer BuildAndTrainModel(MLContext context, IDataView splitTrainTest)
  {
    var pipeline = FeatureTransformer.Concatenate(context)
      .Append(context.Transforms.NormalizeMeanVariance("Features"))
      .Append(context.BinaryClassification.Trainers.SdcaLogisticRegression());
    return pipeline.Fit(splitTrainTest);
  }
}
