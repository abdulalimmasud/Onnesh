using Dapper;
using OnneshProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OnneshProject.DAL
{
    public class ServiceProviderGateway
    {
        public int SaveServiceProvider(ServiceProvider serviecProvider)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Name", value: serviecProvider.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Email", value: serviecProvider.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Mobile", value: serviecProvider.Mobile, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Password", value: serviecProvider.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Address", value: serviecProvider.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@DistrictId", value: serviecProvider.DistrictId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Execute(sql: @"[Service].[InsertServiceProvider]", param: parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public List<ServiceProvider> GetServiceProviders(int isPermitted, int isActive)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@IsPermitted", value: isPermitted, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameter.Add(name: "@IsActive", value: isActive, dbType: DbType.Int16, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Query<ServiceProvider>(sql: "[Service].[GetServiceProviders]", param: parameter, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public ServiceProvider GetProvider(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Id", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Query<ServiceProvider>(sql: "[Service].[USP_ServiceProvider]", param: parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public int UpdateProvider(ServiceProvider serviecProvider)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Id", value: serviecProvider.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add(name: "@Name", value: serviecProvider.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Email", value: serviecProvider.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Mobile", value: serviecProvider.Mobile, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Address", value: serviecProvider.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@DistrictId", value: serviecProvider.DistrictId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Execute(sql: @"[Service].[USP_UpdateServiceProviderInfo]", param: parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public int ConfirmServiceProvider(int id, int confirmBy)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Id", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add(name: "@ConfirmBy", value: confirmBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Execute(sql: "[Admin].[USP_ConfirmServiceProvider]", param: parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public int DeleteServiceProvider(int id, int deletedBy)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Id", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add(name: "@DeletedBy", value: deletedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Execute(sql: "[Admin].[USP_DeleteServiceProvider]", param: parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }
}