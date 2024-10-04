using Microsoft.EntityFrameworkCore;
using AulaEntityFramework.Models;

namespace AulaEntityFramework.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Time> Times { get; set; }
        public DbSet<TimePessoa> TimesPessoas { get; set; }
        public DbSet<AulaEntityFramework.Models.Pessoa> Pessoa { get; set; } = default!;
        public DbSet<AulaEntityFramework.Models.Endereco> Endereco { get; set; } = default!;
    }
}
