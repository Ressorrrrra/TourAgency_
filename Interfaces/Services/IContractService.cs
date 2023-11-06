using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IContractService
    {
        List<ContractDto> GetAllContracts();
        ContractDto GetContract(int id);

        void CreateContract(ContractDto contract);

        void UpdateContract(ContractDto contract);

        void DeleteContract(int id);
    }
}
