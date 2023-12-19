using pmesp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pmesp.Application.Interfaces.Base;

public interface IBaseService<T>
{
    Task<ResultService<ICollection<T>>> GetAllAsync();
}
