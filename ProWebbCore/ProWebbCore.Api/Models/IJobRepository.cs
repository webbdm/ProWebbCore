using System.Collections.Generic;
using ProWebbCore.Shared;

namespace ProWebbCore.Api.Models
{
    public interface IJobRepository
    {
        IEnumerable<Job> GetAllJobs();
        Job GetJobById(int id);
    }
}