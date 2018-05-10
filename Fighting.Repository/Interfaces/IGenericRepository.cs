using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting.Repository.Interfaces
{
    public interface IGenericRepository<T>
    {
        T GetById(object id);
        List<T> Gets(object whereConditions);
        List<T> Gets(string whereConditions);
        T Insert(T value);
        int Update(T value);
        int DeleteById(object id);
    }
}
