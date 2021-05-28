using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimeSheets.Data
{
    /// <summary>
    /// Базовый интерфейс. Реализация CRUD.
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public interface IRepository<T>
    {
        T GetOne(int ID) ;
        IEnumerable<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(int ID);
    }
}
