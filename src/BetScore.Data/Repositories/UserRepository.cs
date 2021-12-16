using BetScore.Data.Interfaces;
using BetScore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetScore.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Context _dbContext { get; set; }
        public UserRepository(Context context)
        {
            _dbContext = context;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
        public User FindByEmail(string email)
        {
            return _dbContext.Users
                .Where(p => p.Email.Equals(email))
                .OrderBy(c => c.Id)
                .FirstOrDefault();
        }
        
        public User Find(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

        
