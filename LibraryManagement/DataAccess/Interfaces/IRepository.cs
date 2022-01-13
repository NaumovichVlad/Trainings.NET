using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    /// <summary>
    /// Repository for data access
    /// </summary>
    public interface IRepository<T>
        where T : EntityBase
    {
        List<T> GetList();
        T GetById(int id);
        void Create(T t);
        void Update(T t);
        void Delete(int id);
    }
}
