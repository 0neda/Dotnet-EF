﻿using AulaEntityFramework.Models;

namespace AulaEntityFramework.Repositories
{
    public interface IPessoaRepository
    {
        public List<Pessoa>? GetAll();
        public Pessoa? Get(int id);
        public List<Pessoa>? GetByName(string? name);
        public List<Pessoa>? GetByBirthDate(DateTime date);
        public List<Pessoa>? GetByPeriodBirthDate(DateTime startDate, DateTime endDate);
        public List<Pessoa>? GetByBirthYear(int year);
        public List<Pessoa>? GetByBirthMonth(int month);

        public Pessoa Insert(Pessoa p);
        public Pessoa Update(Pessoa p);
        public Pessoa Delete(int id);

    }
}