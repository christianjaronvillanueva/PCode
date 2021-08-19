using Microsoft.EntityFrameworkCore;

using PCode.DataAccess.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCode.DataAccess.Repository
{
    public interface IAuthenticationRepository
    {
        Task<Authentication> Get(string userName, string password);
    }
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly PCodeContext _context;

        public AuthenticationRepository(PCodeContext context)
        {
            _context = context;
        }
       

        public async Task<Authentication> Get(string userName, string password)
        {
            return await _context.Authentications.SingleOrDefaultAsync(x => x.UserName == userName && x.Password == password).ConfigureAwait(false);
        }

       
    }
}
