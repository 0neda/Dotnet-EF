using AulaEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AulaEntityFramework.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly MyDbContext _dbContext;

        public PessoaRepository(MyDbContext context)
        {
            _dbContext = context; // Injeção de dependência
        }

        public Pessoa Delete(int id)
        {
            var pessoa = Get(id);

            if (pessoa is null)
                return null!;

            _dbContext.Pessoa.Remove(pessoa);
            _dbContext.SaveChangesAsync();

            return pessoa;
        }

        public Pessoa? Get(int id)
        {
            var pessoa = _dbContext
                .Pessoa.Where(w => w.Id == id)
                .Include(e => e.Enderecos)
                .FirstOrDefault();

            return pessoa;
        }

        public List<Pessoa>? GetAll()
        {
            return _dbContext
                .Pessoa
                .Include(e => e.Enderecos)
                .ToList();
        }

        public List<Pessoa>? GetByBirthDate(DateTime date)
        {
            return _dbContext
                .Pessoa
                .Include(e => e.Enderecos)
                .Where(w => w.BirthDate == date)
                .ToList();
        }

        public List<Pessoa>? GetByBirthMonth(int month)
        {
            return _dbContext
                .Pessoa
                .Include(e => e.Enderecos)
                .Where(w => w.BirthDate.Month == month)
                .ToList();
        }

        public List<Pessoa>? GetByBirthYear(int year)
        {
            return _dbContext
                .Pessoa
                .Include(e => e.Enderecos)
                .Where(w => w.BirthDate.Year == year)
                .ToList();
        }

        public List<Pessoa>? GetByName(string? name)
        {
            return _dbContext
                .Pessoa
                .Include(e => e.Enderecos)
                .Where(w => w.Name!.Equals(name))
                .ToList();
        }

        public List<Pessoa>? GetByPeriodBirthDate(DateTime startDate, DateTime endDate)
        {
            return _dbContext
                .Pessoa
                .Include(e => e.Enderecos)
                .Where(w => w.BirthDate >= startDate && w.BirthDate <= endDate)
                .ToList();
        }

        public Pessoa Insert(Pessoa p)
        {
            _dbContext.Pessoa.Add(p);
            _dbContext.SaveChangesAsync();
            return p;
        }

        public Pessoa Update(Pessoa p)
        {
            throw new NotImplementedException();
        }
    }
}
