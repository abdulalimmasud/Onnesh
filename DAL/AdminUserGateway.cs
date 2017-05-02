using Dapper;
using OnneshProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OnneshProject.DAL
{
    public class AdminUserGateway
    {
        public int SaveNewAdmin(AdminUser user)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Name", value: user.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Email", value: user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Mobile", value: user.Mobile, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Password", value: user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Address", value: user.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@DistrictId", value: user.DistrictId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add(name: "@AdminType", value: user.AdminType, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add(name: "@AddedBy", value: user.AddedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Execute(sql: @"[Admin].[USP_InsertAdminUser]", param: parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }
}