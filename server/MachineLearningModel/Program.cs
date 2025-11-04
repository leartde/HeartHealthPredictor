using MachineLearningModel.Enums;

namespace MachineLearningModel;

internal class Program
{
  private static void Main(string[] args)
  {
    var res = new MachineLearningBuilder()
      .WithData("heart_disease.csv")
      .WithAlgorithm(TrainingAlgorithm.FastTree)
      .WithTestSplit(0.2)
      .Build();

    ModelEvaluator.Evaluate(res.Context, res.Model, res.SplitData.TestSet);
    string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
    string modelPath = Path.Combine(projectDirectory, "HeartDiseaseModel.zip");
    res.Context.Model.Save(res.Model, res.SplitData.TrainSet.Schema, modelPath);
  }
}
