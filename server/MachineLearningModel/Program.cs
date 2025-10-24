using MachineLearningModel.DataEntities;
using MachineLearningModel.Enums;

namespace MachineLearningModel;

class Program
{
  static void Main(string[] args)
  {
    var mlResult = new MachineLearningBuilder()
      .WithData("heart_disease.csv")
      .WithAlgorithm(TrainingAlgorithm.FastTree)
      .WithTestSplit(0.2)
      .Build();

    ModelEvaluator.Evaluate(mlResult.Context, mlResult.Model, mlResult.SplitData.TestSet);
    string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
    string modelPath = Path.Combine(projectDirectory, "HeartDiseaseModel.zip");
    mlResult.Context.Model.Save(mlResult.Model, mlResult.SplitData.TrainSet.Schema, modelPath);  
  
  }
}
