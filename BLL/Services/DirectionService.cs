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
    public class DirectionService : IDirectionService
    {
        private IDbRepos db;

        public DirectionService(IDbRepos repos)
        {
            db = repos;
        }

        public List<DirectionDto> GetAllDirections()
        {
            return db.Directions.GetList().Select(i => new DirectionDto(i)).ToList();
        }


        public DirectionDto GetDirection(int Id)
        {
            return new DirectionDto(db.Directions.GetItem(Id));
        }

        public void CreateDirection(DirectionDto d)
        {
            db.Directions.Create(new Direction() { City = d.City, Country = d.Country });
            db.Save();

        }



        public void UpdateDirection(DirectionDto dir)
        {
            Direction d = db.Directions.GetItem(dir.Id);
            d.City = dir.City;
            d.Country = dir.Country;
            db.Directions.Update(d);
            db.Save();
        }

        public void DeleteDirection(int id)
        {
            Direction p = db.Directions.GetItem(id);
            if (p != null)
            {
                db.Directions.Delete(p.Id);
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
