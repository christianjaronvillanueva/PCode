using Microsoft.EntityFrameworkCore;

using PCode.DataAccess.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCode.DataAccess
{
    public class PCodeContext : DbContext
    {
        public PCodeContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Authentication> Authentications { get; set; }
    }
}
