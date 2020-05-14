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

        public Job AddJob(Job job)
        {
            var addedEntity = _appDbContext.Jobs.Add(job);
            _appDbContext.SaveChanges();

            return addedEntity.Entity;
        }

        public Job UpdateJob(Job job)
        {
            var foundJob = _appDbContext.Jobs.FirstOrDefault(e => e.Id == job.Id);

            if (foundJob != null)
            {
                // Add changes here
                _appDbContext.SaveChanges();

                return foundJob;
            }

            return null;
        }

        public void DeleteJob(int id)
        {

        }
    }
}