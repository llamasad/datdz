using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcPaper.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<PaperDetail> PaperDetail { get; set; } = default!;
        public DbSet<PaperType> PaperType { get; set; } = default!;
    }
}
