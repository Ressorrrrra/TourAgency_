﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLevel;

namespace Interfaces.DTO
{
    public class RequestStatusDto
    {
        public int Id {  get; set; }
        public string Status { get; set; }

        public RequestStatusDto()
        {
                
        }

        public RequestStatusDto(RequestStatus rt)
        {
            this.Id = rt.Id;
            this.Status = rt.Status;
        }
    }
}
