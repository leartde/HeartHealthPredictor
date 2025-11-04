using Microsoft.ML;

namespace MachineLearningModel.Trainers;

public class LbfgsLogisticRegressionTrainer : ITrainer
{
  public ITransformer BuildAndTrainModel(MLContext context, IDataView splitTrainTest)
  {
    var pipeline = FeatureTransformer.Concatenate(context)
      .Append(context.Transforms.NormalizeMeanVariance("Features"))
      .Append(context.BinaryClassification.Trainers.LbfgsLogisticRegression());

    return pipeline.Fit(splitTrainTest);
  }
}
