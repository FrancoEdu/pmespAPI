using pmesp.Domain.Entities.Tattoos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmesp.Domain.Interfaces;

public interface ITattooRepository
{
    Task<Tattoo> PostAsync(Tattoo tattoo);
}
