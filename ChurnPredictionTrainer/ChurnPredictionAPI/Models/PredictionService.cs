using ChurnPredictionTrainer.Models;
using Microsoft.ML;

public class PredictionService
{
    private readonly PredictionEngine<CustomerData, ChurnPrediction> _predictionEngine;

    public PredictionService()
    {
        var context = new MLContext();
        var model = context.Model.Load("churn_model.zip", out _);
        _predictionEngine = context.Model.CreatePredictionEngine<CustomerData, ChurnPrediction>(model);
    }

    public ChurnPrediction Predict(CustomerData input)
    {
        return _predictionEngine.Predict(input);
    }
}
