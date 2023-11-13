using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DomainLevel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;

namespace BLL.Services
{
    public class TransportTypeService : ITransportTypeService
    {
        private IDbRepos db;

        public TransportTypeService(IDbRepos repos)
        {
            db = repos;
        }

        public List<TransportTypeDto> GetAllTransportTypes()
        {
            return db.TransportTypes.GetList().Select(i => new TransportTypeDto(i)).ToList();
        }


        public TransportTypeDto GetTransportType(int Id)
        {
            return new TransportTypeDto(db.TransportTypes.GetItem(Id));
        }

        public void CreateTransportType(TransportTypeDto d)
        {
            db.TransportTypes.Create(new TransportType() { Name = d.Name });
            db.Save();

        }

        public void UpdateTransportType(TransportTypeDto tr)
        {
            TransportType t = db.TransportTypes.GetItem(tr.Id);
            t.Name = tr.Name;
            db.TransportTypes.Update(t);
            db.Save();
        }

        public void DeleteTransportType(int id)
        {
            TransportType t = db.TransportTypes.GetItem(id);
            if (t != null)
            {
                db.TransportTypes.Delete(t.Id);
                db.Save();
            }
        }

        public bool Save(TourAgencyContext db)
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
