using Dapper;
using OnneshProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OnneshProject.DAL
{
    public class AccountGateway
    {
        public AdminUser AdminUserLogin(string email,string password)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Email", value: email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Password", value: password, dbType: DbType.String, direction: ParameterDirection.Input);
            using(var con = new ConnectionGateway().GetConnection())
            {
                return con.Query<AdminUser>(sql: @"[Admin].[USP_AdminUserLogin]", param: parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public ServiceProvider ServiceProviderLogin(string email, string password)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Email", value: email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Password", value: password, dbType: DbType.String, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Query<ServiceProvider>(sql: @"[Service].[USP_ServiceProviderLogin]", param: parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}