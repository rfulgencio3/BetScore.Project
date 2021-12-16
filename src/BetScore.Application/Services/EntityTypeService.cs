using AutoMapper;
using BetScore.Application.DTOs;
using BetScore.Application.Interfaces;
using BetScore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetScore.Application.Services
{
    public class UserService : BaseBetScoreService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(
            IUserRepository userRepository,
            IMapper mapper
            )
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }
        public async Task<UserDTO> FindByEmail(string email)
        {
            var response = _userRepository.FindByEmail(email);
            return _mapper.Map<UserDTO>(response);
        }
    }
}