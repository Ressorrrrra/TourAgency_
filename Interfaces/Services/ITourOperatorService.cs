using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ITourOperatorService
    {
        List<TourOperatorDto> GetAllTourOperators();
        TourOperatorDto GetTourOperator(int id);

        void CreateTourOperator(TourOperatorDto client);

        void UpdateTourOperator(TourOperatorDto client);

        void DeleteTourOperator(int id);
    }
}
