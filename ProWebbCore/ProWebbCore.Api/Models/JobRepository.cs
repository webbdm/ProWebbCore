using System.Collections.Generic;
using System.Linq;
using ProWebbCore.Shared;

namespace ProWebbCore.Api.Models
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _appDbContext;

        public JobRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Job> GetAllJobs()
        {
            return _appDbContext.Jobs;
        }

        public Job GetJobById(int id)
        {
            return _appDbContext.Jobs.FirstOrDefault(c => c.Id == id);
        }
    }
}