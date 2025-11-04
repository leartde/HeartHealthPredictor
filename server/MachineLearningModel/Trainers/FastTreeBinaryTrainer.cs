using Microsoft.ML;

namespace MachineLearningModel.Trainers;

public class FastTreeBinaryTrainer : ITrainer
{
  public ITransformer BuildAndTrainModel(MLContext context, IDataView splitTrainTest)
  {
    var pipeline = FeatureTransformer.Concatenate(context)
      .Append(context.BinaryClassification.Trainers.FastTree(
        numberOfLeaves: 15,
        numberOfTrees: 80,
        minimumExampleCountPerLeaf: 40,
        learningRate: 0.05));

    return pipeline.Fit(splitTrainTest);
  }
}
