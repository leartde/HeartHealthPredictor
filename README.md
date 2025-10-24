# HeartHealthPredictor

A machine learning project with ML.NET using binary classification algorithms to predict whether a patient has heart disease based on the popular UCI Heart Disease dataset, which can be found here: https://archive.ics.uci.edu/dataset/45/heart+disease.

Educational purpose only: This project is designed as a machine learning demonstration for binary classification. The original dataset is limited in size and scope, which means the model's predictions should not be used for actual medical diagnosis.

Creating a new TrainingResult object :
```C#
var res = new MachineLearningBuilder()
      .WithData("heart_disease.csv")
      .WithAlgorithm(TrainingAlgorithm.FastTree)
      .WithTestSplit(0.2)
      .Build();
```

4 algorithms are available:
-Fast Tree
-LBFGS
-LightGBM
-SDCA

0.2 is the recommended and default value for the test split.

Printing the model evaluations:
```C# 
ModelEvaluator.Evaluate(res.Context, res.Model, res.SplitData.TestSet);
```
Saving the trained model in a zip file:
```C# 
     string projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
    string modelPath = Path.Combine(projectDirectory, "HeartDiseaseModel.zip");
    res.Context.Model.Save(res.Model, res.SplitData.TrainSet.Schema, modelPath); 
```

 Creating a prediction engine on the API:
```C#
 var modelPath = Path.Combine(builder.Environment.ContentRootPath, "MachineLearningModels", "HeartDiseaseModel.zip");
builder.Services.AddPredictionEnginePool<HeartDiseaseData, HeartDiseasePrediction>()
  .FromFile(modelName: "HeartDiseaseModel", filePath: modelPath, watchForChanges: true);
``` 