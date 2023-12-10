using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IRequestService
    {
        List<RequestDto> GetAllRequests();
        RequestDto GetRequest(int id);

        void CreateRequest(RequestDto Request);

        void UpdateRequest(RequestDto Request);

        void DeleteRequest(int id);
    }
}
