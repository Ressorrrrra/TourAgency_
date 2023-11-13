using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IClientService
    {
        List<ClientDto> GetAllClients();
        ClientDto GetClient(int id);

        void CreateClient(ClientDto client);

        void UpdateClient(ClientDto client);

        void DeleteClient(int id);
    }
}
