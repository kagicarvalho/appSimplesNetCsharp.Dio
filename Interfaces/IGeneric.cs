using System;
using System.Collections.Generic;

namespace Dio.Series.Interfaces
{
    public interface IGeneric<T>
    {
         List<T> GetAll();
         T GetById(int id);
         void Add(T entity);
         void Delete(int id);
         void Update(int id, T entity);
         int NextId();

    }
}