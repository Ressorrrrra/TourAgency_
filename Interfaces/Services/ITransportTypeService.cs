using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ITransportTypeService
    {
        List<TransportTypeDto> GetAllTransportTypes();
        TransportTypeDto GetTransportType(int id);

        void CreateTransportType(TransportTypeDto transportType);

        void UpdateTransportType(TransportTypeDto transportType);

        void DeleteTransportType(int id);
    }
}
