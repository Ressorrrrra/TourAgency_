using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLevel;

namespace DAL.Repository
{
    public class ClientRepository : IRepository<Client>
    {
        private TourAgencyContext db;

        public ClientRepository(TourAgencyContext context)
        {
                db = context;
        }
        public void Create(Client item)
        {
            db.Clients.Add(item);
        }

        public void Delete(int id)
        {
            Client client = GetItem(id);
            if (client != null)
            {
                db.Clients.Remove(client);
            }
        }

        public Client GetItem(int id)
        {
            return db.Clients.Find(id);
        }

        public List<Client> GetList()
        {
            return db.Clients.ToList();
        }

        public void Update(Client item)
        {
            db.Clients.Update(item);
        }
    }
}
