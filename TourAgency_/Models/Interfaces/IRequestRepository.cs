﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;

namespace TourAgency_.Models.Interfaces
{
    public interface IRequestRepository : IRepository<Request>
    {
        public List<Request>? GetRequestsByUser(int userId);
    }
}
