using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodProfile.Models;

namespace BloodProfile.Services
{
    public class TempBloodWorkService : IBloodWorkService
    {
        public Task<BloodWork[]> GetBloodWorkAsync()
        {
            var default_record = new BloodWork
            {
                DateCreated = DateTime.Now,
                ExamDate = new System.DateTime(2021, 1, 4, 8, 14, 0),
                ResultsDate = new System.DateTime(2021, 1, 8, 15, 33, 0),
                Description = "This is a default data point for testing.",
                Hemoglobin = 12.0,
                Hematocrit = 35.5,
                WhiteBloodCellCount = 9000,
                RedBloodCellCount = 4.6
            };
            return Task.FromResult(new[] { default_record });
        }
    }
}
