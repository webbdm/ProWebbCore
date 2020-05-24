using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProWebbCore.Shared;

namespace ProWebbCore.Api.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _appDbContext.Users.Include(u => u.Resumes).ThenInclude(r => r.Skill);
        }

        public User GetUserById(int id)
        {
            return _appDbContext.Users.FirstOrDefault(c => c.Id == id);
        }

        public User AddUser(User user)
        {
            var addedEntity = _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();

            var _resumeRepo = new ResumeRepository(_appDbContext);
            _resumeRepo.AddResume(addedEntity.Entity.Id);

            return addedEntity.Entity;
        }

        public User UpdateUser(User user)
        {
            var foundUser = _appDbContext.Users.FirstOrDefault(e => e.Id == user.Id);

            if (foundUser != null)
            {
                foundUser.FirstName = user.FirstName;
                foundUser.LastName = user.LastName;

                _appDbContext.SaveChanges();

                return foundUser;
            }

            return null;
        }
        public void DeleteUser(int id)
        {

        }
    }
}