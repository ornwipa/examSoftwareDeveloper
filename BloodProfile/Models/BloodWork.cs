using System;

namespace BloodProfile.Models
{
    public class BloodWork
    {
        public Guid Id { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime ResultsDate { get; set; }
        public string Description { get; set; }
        public double Hemoglobin { get; set; }
        public double Hematocrit { get; set; }
        public double WhiteBloodCellCount { get; set; }
        public double RedBloodCellCount { get; set; }
    }
}
