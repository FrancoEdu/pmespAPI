using pmesp.Domain.Entities.BanditAddresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pmesp.Domain.Interfaces.IBanditAddresses;

public interface IBanditAddressesRepository
{
    Task<BanditAddress> CreateAsync(BanditAddress entity);
}
