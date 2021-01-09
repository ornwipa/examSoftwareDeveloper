using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloodProfile.Models;

namespace BloodProfile.Services
{
    public interface IBloodWorkService
    {
        Task<BloodWork[]> GetBloodWorkAsync();
        BloodWork GetSpecificBloodWork(Guid Id);
        Task<bool> AddRecordAsync(BloodWork newBloodWork);
        Task<bool> EditRecordAsync(Guid Id, BloodWork selectedBloodWork);
    }
}
