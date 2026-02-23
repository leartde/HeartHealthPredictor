using MachineLearningModel.Utilities;
using Microsoft.ML;
using LightGbmOptions = Microsoft.ML.Trainers.LightGbm.LightGbmBinaryTrainer.Options;

namespace MachineLearningModel.Trainers;

public class LightGbmBinaryTreeTrainer : ITrainer
{
  public ITransformer BuildAndTrainModel(MLContext context, IDataView splitTrainTest)
  {
    var options = new LightGbmOptions
    {
      NumberOfLeaves = 31,
      NumberOfIterations = 250,
      MinimumExampleCountPerLeaf = 2,
      LearningRate = 0.03,
      WeightOfPositiveExamples = 1.4
    };

    var pipeline = FeatureTransformer.Concatenate(context)
      .Append(context.BinaryClassification.Trainers.LightGbm(options));

    return pipeline.Fit(splitTrainTest);
  }
}
