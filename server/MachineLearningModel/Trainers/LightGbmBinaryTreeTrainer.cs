using Microsoft.ML;

namespace MachineLearningModel.Trainers;

public class LightGbmBinaryTreeTrainer : ITrainer
{
  public ITransformer BuildAndTrainModel(MLContext context, IDataView splitTrainTest)
  {
    var pipeline = FeatureTransformer.Concatenate(context)
      .Append(context.BinaryClassification.Trainers.LightGbm(
        numberOfLeaves: 10,
        numberOfIterations: 75,
        minimumExampleCountPerLeaf: 40,
        learningRate: 0.05
      ));

    return pipeline.Fit(splitTrainTest);
  }
}
