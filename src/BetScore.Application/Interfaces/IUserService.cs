using BetScore.Application.DTOs;
using System.Threading.Tasks;

namespace BetScore.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> FindByEmail(string email);
    }
}
