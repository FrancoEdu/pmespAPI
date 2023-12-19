using pmesp.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmesp.Application.Interfaces.Base;

public interface IBaseService<T>
{
    Task<Response<IEnumerable<T>>> GetAll();
    Task<Response<T>> GetById(string id);
    Task<Response<T>> Add(T entity);
    Task<Response<T>> Update(T entity);
    Task<Response<T>> Delete(string id);
}
