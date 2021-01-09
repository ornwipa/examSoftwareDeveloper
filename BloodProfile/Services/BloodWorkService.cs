using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodProfile.Data;
using BloodProfile.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodProfile.Services
{
    public class BloodWorkService : IBloodWorkService
    {
        private readonly ApplicationDbContext _context;
        public BloodWorkService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BloodWork[]> GetBloodWorkAsync()
        {
            var records = await _context.Records.ToArrayAsync();
            return records;
        }
        public BloodWork GetSpecificBloodWork(Guid Id)
        {
            var record = _context.Records.Where(x => x.Id == Id).FirstOrDefault();
            return record;
        }
        public async Task<bool> AddRecordAsync(BloodWork newBloodWork)
        {
            newBloodWork.Id = Guid.NewGuid();
            _context.Records.Add(newBloodWork);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }       
        public async Task<bool> EditRecordAsync(Guid Id, BloodWork selectedBloodWork)
        {
            var record = _context.Records.Where(x => x.Id == Id).FirstOrDefault();
            if (record == null) return false;
            // record = selectedBloodWork;
            // _context.Update(record);
            _context.Remove(record);
            _context.Add(selectedBloodWork);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }   
}
