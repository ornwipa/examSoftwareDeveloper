using System;
using System.ComponentModel.DataAnnotations;

namespace BloodProfile.Models
{
    public class BloodWork
    {
        public Guid Id { get; set; }
        // public string UserId { get; set; }

        [DataType(DataType.Date)]
        [CreatedDate(ErrorMessage = "Created date needs to be today or before.")]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        [ExamDate(ErrorMessage = "Exam date cannot be after created date.")]
        public DateTime ExamDate { get; set; }

        [DataType(DataType.Date)]
        [ResultsDate(ErrorMessage = "Results date can neither be after created date nor before exam date.")]
        public DateTime ResultsDate { get; set; }

        public string Description { get; set; }
        public double Hemoglobin { get; set; }
        public double Hematocrit { get; set; }
        public double WhiteBloodCellCount { get; set; }
        public double RedBloodCellCount { get; set; }
    }
}
