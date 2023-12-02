using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IRequestStatusService
    {
        List<RequestStatusDto> GetAllRequestStatuses();
        RequestStatusDto GetRequestStatus(int id);

        void CreateRequestStatus(RequestStatusDto status);

        void UpdateRequestStatus(RequestStatusDto status);

        void DeleteRequestStatus(int id);
    }
}
