using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourAgency_.Models.Entities
{
    public enum RequestStatus
    {
        [Display(Name = "Отправлена")]
        Sent,
        Processing,
        Accepted,
        Denied

           
    }
}
