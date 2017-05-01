using Dapper;
using OnneshProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OnneshProject.DAL
{
    public class GeneralGateway
    {
        public List<Districts> GetDistricts()
        {
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Query<Districts>(sql: "[General].[GetDistricts]", param: null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}