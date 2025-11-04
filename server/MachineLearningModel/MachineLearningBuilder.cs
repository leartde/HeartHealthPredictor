using MachineLearningModel.Enums;
using MachineLearningModel.Trainers;
using Microsoft.ML;

namespace MachineLearningModel;

public class MachineLearningBuilder
{
  private TrainingAlgorithm _algorithm;
  private string _dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
  private readonly int? _seed = null;
  private double _testSplit = 0.2;

  public MachineLearningBuilder WithData(string dataPath)
  {
    _dataPath = Path.Combine(_dataPath, dataPath);
    return this;
  }

  public MachineLearningBuilder WithDataDirectory(string directoryPath)
  {
    _dataPath = directoryPath;
    return this;
  }

  public MachineLearningBuilder WithTestSplit(double testSplit)
  {
    if (testSplit is < 0 or > 1)
      throw new ArgumentException("Test value should be between 0 and 1.\n" +
                                  "Recommended value is between 0.2 and 0.3");
    _testSplit = testSplit;
    return this;
  }

  public MachineLearningBuilder WithAlgorithm(TrainingAlgorithm algorithm)
  {
    _algorithm = algorithm;
    return this;
  }

  public TrainingResult Build()
  {
    var context = new MLContext(_seed);
    var splitDataView = context.LoadData(_dataPath, _testSplit);
    ITrainer trainer = _algorithm switch
    {
      TrainingAlgorithm.FastTree => new FastTreeBinaryTrainer(),
      TrainingAlgorithm.LightGbm => new LightGbmBinaryTreeTrainer(),
      TrainingAlgorithm.LbfgsLogisticRegression => new LbfgsLogisticRegressionTrainer(),
      TrainingAlgorithm.SdcaLogisticRegression => new SdcaLogisticRegressionTrainer(),
      _ => throw new ArgumentException("Unknown algorithm")
    };
    var model = trainer.BuildAndTrainModel(context, splitDataView.TrainSet);
    return new TrainingResult
    {
      Model = model,
      Context = context,
      SplitData = splitDataView
    };
  }
}
