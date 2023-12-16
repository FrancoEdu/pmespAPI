using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmesp.Application.Interfaces.Base;

public interface IBaseService<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(string id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(string id);
}
