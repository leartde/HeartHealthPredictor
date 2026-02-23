using Microsoft.ML;
using static Microsoft.ML.DataOperationsCatalog;
namespace MachineLearningModel.Results;

public class TrainingResult
{
  public ITransformer Model { get; set; } = null!;
  public MLContext Context { get; set; } = null!;
  public TrainTestData SplitData { get; set; }
}
