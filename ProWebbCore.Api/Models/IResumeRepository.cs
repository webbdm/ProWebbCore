using System.Collections.Generic;
using ProWebbCore.Shared;

namespace ProWebbCore.Api.Models
{
    public interface IResumeRepository
    {
        IEnumerable<Resume> GetAllResumes();
        Resume GetResumeById(int id);
    }
}