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
    public class TourOperatorService : ITourOperatorService
    {
        private IDbRepos db;

        public TourOperatorService(IDbRepos repos)
        {
            db = repos;
        }

        public List<TourOperatorDto> GetAllTourOperators()
        {
            return db.TourOperators.GetList().Select(i => new TourOperatorDto(i)).ToList();
        }


        public TourOperatorDto GetTourOperator(int Id)
        {
            return new TourOperatorDto(db.TourOperators.GetItem(Id));
        }

        public void CreateTourOperator(TourOperatorDto t)
        {
            db.TourOperators.Create(new TourOperator() { Name = t.Name });
            db.Save();

        }



        public void UpdateTourOperator(TourOperatorDto tour)
        {
            TourOperator t = db.TourOperators.GetItem(tour.Id);
            t.Name = tour.Name;
            db.TourOperators.Update(t);
            db.Save();
        }

        public void DeleteTourOperator(int id)
        {
            TourOperator t = db.TourOperators.GetItem(id);
            if (t != null)
            {
                db.TourOperators.Delete(t.Id);
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
