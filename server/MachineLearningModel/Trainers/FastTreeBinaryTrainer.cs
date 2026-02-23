using MachineLearningModel.Utilities;
using Microsoft.ML;
using FastTreeOptions = Microsoft.ML.Trainers.FastTree.FastTreeBinaryTrainer.Options;

namespace MachineLearningModel.Trainers;

public class FastTreeBinaryTrainer : ITrainer
{
  public ITransformer BuildAndTrainModel(MLContext context, IDataView splitTrainTest)
  {
    var options = new FastTreeOptions
    {
      NumberOfLeaves = 64,
      NumberOfTrees = 300,
      MinimumExampleCountPerLeaf = 2,
      LearningRate = 0.03,
      UnbalancedSets = true
    };

    var pipeline = FeatureTransformer.Concatenate(context)
      .Append(context.BinaryClassification.Trainers.FastTree(options));

    return pipeline.Fit(splitTrainTest);
  }
}
