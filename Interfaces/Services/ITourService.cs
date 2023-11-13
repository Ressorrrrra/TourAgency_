using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ITourService
    {
        List<TourDto> GetAllTours();
        TourDto GetTour(int id);

        void CreateTour(TourDto tour);

        void UpdateTour(TourDto tour);

        void DeleteTour(int id);
    }
}
