using Helpaluno.Bussiness.Entities;
using Microsoft.EntityFrameworkCore;

namespace Helpaluno.Data.Contexts
{
    public class AppSettingsDbContext : DbContext
    {
        public AppSettingsDbContext(DbContextOptions<AppSettingsDbContext> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
    }
}
