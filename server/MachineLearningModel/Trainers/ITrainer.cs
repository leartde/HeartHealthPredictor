using Microsoft.ML;

namespace MachineLearningModel.Trainers;

public interface ITrainer
{
  ITransformer BuildAndTrainModel(MLContext context, IDataView splitTrainSet);
}
