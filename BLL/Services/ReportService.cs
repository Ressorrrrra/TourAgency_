using Interfaces.DTO;
using Interfaces.Repository;
using DAL;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReportService
    {
        public class ContractsByMonth
        {
            public int ContractId { get; set; }
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public DateTime ConclusionDate { get; set; }
            public int TotalCost { get; set; }

        }
        [Keyless]
        public class ContractsByDateResult
        {
            public int contract_id { get; set; }
            public string employee_name { get; set; }
            public DateOnly conclusion_date { get; set; }
            public int total_cost { get; set; }

        }


        public List<EmployeeDto> ExecuteProcedure(string name)
        {
            //TourAgencyContext db = new TourAgencyContext();
            //var result = service.GetAllEmployees();
            //return (List<EmployeeDto>)result.Where(g => g.ContractCount > value).Select(i => i).GroupBy(i => i.ContractCount);
            //return result.Where(g => g.Name.Contains(name)).Select(i => i).ToList();
            //NpgsqlParameter param1 = new NpgsqlParameter("date1", NpgsqlDbType.Date) { Value = date1 };
            //NpgsqlParameter param2 = new NpgsqlParameter("date2", NpgsqlDbType.Date) { Value = date2 };
            //var result = db.Database.SqlQuery<ContractsByDateResult>($"select * from getcontractsforallemployees ({param1.Value},{param2.Value})").ToList();
            var result = new List<EmployeeDto>();
            return result;
        }

    }
}
