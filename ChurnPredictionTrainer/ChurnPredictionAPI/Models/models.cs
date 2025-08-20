using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurnPredictionTrainer.Models
{
    public class CustomerData
    {
        [LoadColumn(1)]
        public float Tenure { get; set; }

        [LoadColumn(2)]
        public float MonthlyCharges { get; set; }

        [LoadColumn(3)]
        public float TotalCharges { get; set; }

        [LoadColumn(4)]
        public bool IsActive { get; set; }

        [LoadColumn(5)]
        public bool Churned { get; set; }
    }


    public class ChurnPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Churned { get; set; }
        public float Probability { get; set; }
        public float Score { get; set; }
    }

}
