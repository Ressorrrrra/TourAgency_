using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.Arm;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;

namespace TourAgency_.Models.Repository
{
    public class ContractRepository : IRepository<Contract>
    {
        private TourAgencyContext db;

        public ContractRepository(TourAgencyContext context)
        {
            db = context;
        }
        public void Create(Contract item)
        {
            db.Contracts.Add(item);
        }

        public void Delete(int id)
        {
            Contract contract = GetItem(id);
            if (contract != null)
            {
                db.Contracts.Remove(contract);
            }
        }

        public Contract GetItem(int id)
        {
            return db.Contracts.Find(id);
        }

        public List<Contract> GetList()
        {
            return db.Contracts.ToList();
        }

        public void Update(Contract item)
        {
            db.Contracts.Update(item);
        }
    }
}
