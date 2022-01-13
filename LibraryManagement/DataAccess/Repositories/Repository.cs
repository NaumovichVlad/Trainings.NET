using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Repository for data access
    /// </summary>
    public abstract class Repository<T> : IRepository<T>
        where T : EntityBase
    {
        protected readonly string connectionString;
        public Repository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public abstract void Create(T t);
        public abstract void Delete(int id);
        public abstract T GetById(int id);
        public abstract List<T> GetList();
        public abstract void Update(T t);
    }
}
