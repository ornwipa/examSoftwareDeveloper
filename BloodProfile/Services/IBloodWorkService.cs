using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodProfile.Models;

namespace BloodProfile.Services
{
    public interface IBloodWorkService
    {
        Task<BloodWork[]> GetBloodWorkAsync(string searchString, DateTime startDate, DateTime endDate); // Index
        BloodWork GetSpecificBloodWork(Guid Id); // Details
        Task<bool> AddRecordAsync(BloodWork newBloodWork); // Create
        Task<bool> EditRecordAsync(Guid Id, BloodWork selectedBloodWork); // Edit
    }
}
