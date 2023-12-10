using DomainLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ILoggingService
    {
        public User? FindUser(string login, string password);
    }
}
