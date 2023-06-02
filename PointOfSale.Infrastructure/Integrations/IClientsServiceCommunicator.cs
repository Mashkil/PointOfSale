using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Infrastructure.Integrations
{
    public interface IClientsServiceCommunicator
    {
        public Task<bool> IsExisting(Guid id);
    }
}
