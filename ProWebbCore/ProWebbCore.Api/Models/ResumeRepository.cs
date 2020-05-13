using System.Collections.Generic;
using System.Linq;
using ProWebbCore.Shared;

namespace ProWebbCore.Api.Models
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly AppDbContext _appDbContext;

        public ResumeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Resume> GetAllResumes()
        {
            return _appDbContext.Resumes;
        }

        public Resume GetResumeById(int id)
        {
            return _appDbContext.Resumes.FirstOrDefault(c => c.Id == id);
        }

        public Resume AddResume(int userId)
        {
            var newResume = new Resume();
            newResume.UserId = userId;

            var addedEntity = _appDbContext.Resumes.Add(newResume);

            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }
    }
}