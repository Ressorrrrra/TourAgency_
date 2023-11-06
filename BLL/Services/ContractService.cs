
using DAL;
using DomainLevel;
using Interfaces;
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
        //private TourAgencyContext db;
        private IDbRepos db;
        public ContractService(IDbRepos repos)
        {
            db = repos;
        }

        //public List<ContractDto> GetAllContracts()
        //{
        //    return db.Contracts.ToList().Select(i => new ContractDto(i)).ToList();
        //}

        //public List<EmployeeDto> GetAllEmployees()
        //{
        //    return db.Employees.ToList().Select(i => new EmployeeDto(i)).ToList();
        //}


        //public ContractDto GetContract(int Id)
        //{
        //    return new ContractDto(db.Contracts.Find(Id));
        //}

        //public void CreateContract(ContractDto c)
        //{
        //    db.Contracts.Add(new Contract() { TotalCost = c.TotalCost, Employee = db.Employees.Find(c.EmployeeId), Client = db.Clients.Find(c.EmployeeId), Tour = db.Tours.Find(c.TourId), ConclusionDate = c.ConclusionDate});
        //    Save(db);
        //    //db.Contracts.Attach(p);
        //}



        //public void UpdateContract(ContractDto p)
        //{
        //    Contract ph = db.Contracts.Find(p.Id);
        //    ph.Employee = db.Employees.Find(p.EmployeeId);
        //    ph.Tour = db.Tours.Find(p.TourId);
        //    ph.Client = db.Clients.Find(p.ClientId);
        //    ph.TotalCost = p.TotalCost;
        //    ph.ConclusionDate = p.ConclusionDate;
        //    Save(db);
        //}

        //public void DeleteContract(int id)
        //{
        //    Contract p = db.Contracts.Find(id);
        //    if (p != null)
        //    {
        //        db.Contracts.Remove(p);
        //        Save(db);
        //    }
        //}


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
            db.Contracts.Create(new Contract() { TotalCost = contract.TotalCost, Employee = db.Employees.GetItem(contract.EmployeeId), Client = db.Cleints.GetItem(contract.EmployeeId), Tour = db.Tours.GetItem(contract.TourId), ConclusionDate = contract.ConclusionDate });
            Save(db);
            //db.Contracts.Attach(p);
        }

        public void UpdateContract(ContractDto contract)
        {
            Contract ph = db.Contracts.GetItem(contract.Id);
            ph.Employee = db.Employees.GetItem(contract.EmployeeId);
            ph.Tour = db.Tours.GetItem(contract.TourId);
            ph.Client = db.Cleints.GetItem(contract.ClientId);
            ph.TotalCost = contract.TotalCost;
            ph.ConclusionDate = contract.ConclusionDate;
            db.Contracts.Update(ph);
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
