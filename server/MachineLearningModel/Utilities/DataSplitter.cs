using MachineLearningModel.DataEntities;
using Microsoft.ML;
using static Microsoft.ML.DataOperationsCatalog;

namespace MachineLearningModel.Utilities;

public static class DataSplitter
{
  public static TrainTestData LoadData(this MLContext context, string dataPath, double testSplit)
  {
    var dataView = context.Data.LoadFromTextFile<HeartDiseaseData>(
      dataPath,
      hasHeader: true,
      separatorChar: ','
    );
    return context.Data.TrainTestSplit(
      dataView,
      testSplit
    );
  }
}
