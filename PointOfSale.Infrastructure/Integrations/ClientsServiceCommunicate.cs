using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Infrastructure.Integrations
{
    public class ClientsServiceCommunicator : IClientsServiceCommunicator
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ClientsServiceCommunicator(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<bool> IsExisting(Guid id)
        {
            var httpclient = httpClientFactory.CreateClient();
            return await httpclient.GetFromJsonAsync<bool>($"https://localhost:3001/api/Client/isExisting/{id}");            
        }
    }
}
