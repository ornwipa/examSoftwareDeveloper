using System;
using System.ComponentModel.DataAnnotations;

namespace BloodProfile.Models
{
    public class CreatedDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = Convert.ToDateTime(value);
            return date <= DateTime.Now; // created date can only be today or before
        }
    }

    public class ExamDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            BloodWork record = (BloodWork)validationContext.ObjectInstance;
            if (record.ExamDate > record.DateCreated) 
            {
                return new ValidationResult("Invalid Date.");
            }
            return ValidationResult.Success;
            // return base.IsValid(value, validationContext);
        }
    }

    public class ResultsDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            BloodWork record = (BloodWork)validationContext.ObjectInstance;
            if (record.ResultsDate > record.DateCreated || record.ResultsDate < record.ExamDate) 
            {
                return new ValidationResult("Invalid Date.");
            }
            return ValidationResult.Success;
            // return base.IsValid(value, validationContext);
        }
    }
}
