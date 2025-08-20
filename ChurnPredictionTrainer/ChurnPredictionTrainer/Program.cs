using ChurnPredictionTrainer.Models;
using Microsoft.ML;
using Microsoft.ML.Data;

var context = new MLContext();

// Load data
var data = context.Data.LoadFromTextFile<CustomerData>(
    path: "customer_data.csv",
    hasHeader: true,
    separatorChar: ',');

// Define the ML pipeline
var pipeline = context.Transforms
    .Conversion.ConvertType("IsActiveFloat", nameof(CustomerData.IsActive), DataKind.Single)
    .Append(context.Transforms.Concatenate("Features",
        nameof(CustomerData.Tenure),
        nameof(CustomerData.MonthlyCharges),
        nameof(CustomerData.TotalCharges),
        "IsActiveFloat"))
    .Append(context.BinaryClassification.Trainers.SdcaLogisticRegression(
        labelColumnName: nameof(CustomerData.Churned),
        featureColumnName: "Features"));

// Train the model
var model = pipeline.Fit(data);

// Save the model
context.Model.Save(model, data.Schema, "churn_model.zip");

Console.WriteLine("✅ Model trained and saved successfully.");
