using Microsoft.ML;

namespace MachineLearningModel.Trainers;


/// <summary>
/// Binary classification trainer that requires dataset normalization.
/// </summary>
public class LbfgsLogisticRegressionTrainer : ITrainer
{
  public string Name  => "LBFGS_LogisticRegression";

  public ITransformer BuildAndTrainModel(MLContext context, IDataView splitTrainTest)
  {
    var pipeline = FeatureTransformer.Concatenate(context)
      .Append(context.Transforms.NormalizeMeanVariance("Features"))
    .Append(context.BinaryClassification.Trainers.LbfgsLogisticRegression());

    return pipeline.Fit(splitTrainTest);
  }
  
}
