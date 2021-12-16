using BetScore.Domain.Entities;

namespace BetScore.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByEmail(string email);
    }
}