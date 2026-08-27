using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G02_ADV01
{
    internal interface IRepository<T>
    {
        void Add(T entity);
        List<T> GetAll();
        T GetById(int id);
        void Delete(T entity);

    }
}
