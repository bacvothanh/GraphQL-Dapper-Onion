using Fighting.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting.Service.Interfaces
{
    public interface IGenericService<TEntity>
    {
        TEntity Insert(TEntity value);
        T GetById<T>(object id);
        List<T> Gets<T>();
        ApplicationResult Update(TEntity value);
        ApplicationResult Delete(object id);
    }
}
