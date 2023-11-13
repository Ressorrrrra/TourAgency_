using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLevel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;


namespace BLL.Services
{
    public class ClientService : IClientService
    {
        private IDbRepos db;
        public ClientService(IDbRepos repos)
        {
            db = repos;
        }


        public bool Save(IDbRepos db)
        {
            if (db.Save() > 0) return true;
            return false;
        }
        public void CreateClient(ClientDto client)
        {
            db.Clients.Create(new Client() { Name = client.Name, DateOfBirth = client.DateOfBirth, PassportNumber = client.PassportNumber, InternationalPassportNumber = client.InternationalPassportNumber});
            Save(db);
        }

        public void DeleteClient(int id)
        {
            Client p = db.Clients.GetItem(id);
            if (p != null)
            {
                db.Clients.Delete(p.Id);
                Save(db);
            }
        }

        public List<ClientDto> GetAllClients()
        {
            return db.Clients.GetList().Select(i => new ClientDto(i)).ToList();
        }

        public ClientDto GetClient(int id)
        {
            return new ClientDto(db.Clients.GetItem(id));
        }

        public void UpdateClient(ClientDto client)
        {
            Client cl = db.Clients.GetItem(client.Id);
            cl.Name = client.Name;
            cl.DateOfBirth  = client.DateOfBirth;
            cl.PassportNumber = client.PassportNumber;
            cl.InternationalPassportNumber=client.InternationalPassportNumber;
            db.Clients.Update(cl);
            Save(db);
        }
    }
}
