using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IDirectionService
    {
        List<DirectionDto> GetAllDirections();
        DirectionDto GetDirection(int id);

        void CreateDirection(DirectionDto direction);

        void UpdateDirection(DirectionDto direction);

        void DeleteDirection(int id);
    }
}
