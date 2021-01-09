using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodProfile.Models;
using BloodProfile.Data;

namespace BloodProfile.Services
{
    public class DefaultBloodWorkService // : IBloodWorkService
    {
        BloodWork default_record = new BloodWork
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
        public Task<BloodWork[]> GetBloodWorkAsync()
        {
            return Task.FromResult(new[] { default_record });
        }
        public BloodWork GetSpecificBloodWorkAsync(Guid Id)
        {
            return default_record;
        }
    }
}
