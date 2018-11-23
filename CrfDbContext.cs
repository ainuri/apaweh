using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCrf.Models;

namespace WebCrf
{
    public class CrfDbContext : DbContext
    {

        public CrfDbContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<tb_user> tb_users { get; set; }
        public DbSet<tb_role> tb_roles { get; set; }
        public DbSet <tb_user_role> tb_user_roles { get; set; }

    }
}
