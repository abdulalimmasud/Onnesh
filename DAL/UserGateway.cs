using Dapper;
using OnneshProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OnneshProject.DAL
{
    public class UserGateway
    {
        public int SaveUser(Users user)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Name", value: user.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Email", value: user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Mobile", value: user.Mobile, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Password", value: user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@InstituteName", value: user.InstituteName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Address", value: user.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@DistrictId", value: user.DistrictId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Execute(sql: @"[General].[USP_InsertUser]", param: parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public List<Users> GetUsers(int isPermitted, int isActive)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@IsPermitted", value: isPermitted, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameter.Add(name: "@IsActive", value: isActive, dbType: DbType.Int16, direction: ParameterDirection.Input);
            using(var con = new ConnectionGateway().GetConnection())
            {
                return con.Query<Users>(sql: "[Admin].[GetUsers]", param: parameter, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public int UpdateUser(Users user)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Id", value: user.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add(name: "@Name", value: user.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Email", value: user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Mobile", value: user.Mobile, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@InstituteName", value: user.InstituteName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Address", value: user.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@DistrictId", value: user.DistrictId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Execute(sql: @"[General].[USP_UpdateUserInfo]", param: parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public Users GetUser(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Id", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Query<Users>(sql: "[General].[USP_GetUser]", param: parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public int ConfirmUser(int id, int confirmBy)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Id", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add(name: "@ConfirmBy", value: confirmBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Execute(sql: "[Admin].[USP_ConfirmUser]", param: parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public int DeleteUser(int id, int deletedBy)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Id", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add(name: "@DeletedBy", value: deletedBy, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Execute(sql: "[Admin].[USP_DeleteUser]", param: parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }
}