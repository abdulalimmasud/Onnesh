using Dapper;
using OnneshProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OnneshProject.DAL
{
    public class CategoryGateway
    {
        public int SaveCategory(Category category)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Name", value: category.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@CategoryType", value: category.CategoryType, dbType: DbType.Int16, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Execute(sql: "[General].[USP_InsertCategory]", param: parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public int SaveSubCategory(Category category)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@Name", value: category.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add(name: "@Parent_Id", value: category.Parent_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add(name: "@CategoryType", value: category.CategoryType, dbType: DbType.Int16, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Execute(sql: "[General].[USP_InsertSubCategory]", param: parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public List<Category> GetCategory(int categoryType)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@CategoryType", value: categoryType, dbType: DbType.Int16, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Query<Category>(sql: "[General].[USP_GetCategory]", param: parameter, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<Category> GetSubCategory(int categoryType, int parentId)
        {
            var parameter = new DynamicParameters();
            parameter.Add(name: "@CategoryType", value: categoryType, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameter.Add(name: "@Parent_Id", value: parentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            using (var con = new ConnectionGateway().GetConnection())
            {
                return con.Query<Category>(sql: "[General].[USP_GetSubCategory]", param: parameter, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}