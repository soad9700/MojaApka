using Microsoft.EntityFrameworkCore;
using MojaApka.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MojaApka.Nowy_folder
{
    public class MojaApkaContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public MojaApkaContext(DbContextOptions<MojaApkaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
