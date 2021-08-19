using AutoMapper;

using Microsoft.EntityFrameworkCore;

using PCode.DataAccess.Models;
using PCode.DataAccess.Repository;
using PCode.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCode.Service
{
    public interface IAuthenticationService
    {
        Task<AuthenticationDTO> Get(string userName, string password);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _repo;
        private readonly IMapper _mapper;
        public AuthenticationService(IAuthenticationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<AuthenticationDTO> Get(string userName, string password)
        {
            var result = await _repo.Get(userName,password).ConfigureAwait(false);
            return _mapper.Map<AuthenticationDTO>(result);
        }

        
    }

}
