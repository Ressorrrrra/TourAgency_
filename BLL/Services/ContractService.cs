
using DomainLevel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ContractService : IContractService
    {
        private IDbRepos db;
        public ContractService(IDbRepos repos)
        {
            db = repos;
        }


        public bool Save(IDbRepos db)
        {
            if (db.Save() > 0) return true;
            return false;
        }

        public List<ContractDto> GetAllContracts()
        {
            return db.Contracts.GetList().Select(i => new ContractDto(i)).ToList();
        }

        public ContractDto GetContract(int id)
        {
            return new ContractDto(db.Contracts.GetItem(id));
        }

        public void CreateContract(ContractDto contract)
        {
            db.Contracts.Create(new Contract() { TotalCost = contract.TotalCost, Employee = db.Employees.GetItem(contract.EmployeeId), Client = db.Clients.GetItem(contract.EmployeeId), Tour = db.Tours.GetItem(contract.TourId), ConclusionDate = contract.ConclusionDate });
            Save(db);
            //db.Contracts.Attach(p);
        }

        public void UpdateContract(ContractDto contract)
        {
            Contract cn = db.Contracts.GetItem(contract.Id);
            cn.Employee = db.Employees.GetItem(contract.EmployeeId);
            cn.Tour = db.Tours.GetItem(contract.TourId);
            cn.Client = db.Clients.GetItem(contract.ClientId);
            cn.TotalCost = contract.TotalCost;
            cn.ConclusionDate = contract.ConclusionDate;
            db.Contracts.Update(cn);
            Save(db);
        }

        public void DeleteContract(int id)
        {
            Contract p = db.Contracts.GetItem(id);
            if (p != null)
            {
                db.Contracts.Delete(p.Id);
                Save(db);
            }
        }
    }
}
