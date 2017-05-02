using OnneshProject.DAL;
using OnneshProject.Models;
using OnneshProject.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnneshProject.ViewModel
{
    public class Repository
    {
        public Account AdminFind(string username)
        {
            return ReadAdminData(GetAdminSession());
        }
        public Account AdminLogin(Account acc)
        {
            return ReadAdminData(new AccountGateway().AdminUserLogin(acc.Email,acc.Password));
        }
        private Account ReadAdminData(AdminUser user)
        {
            Account account = null;
            try
            {
                account = new Account();
                account.Id = user.Id.ToString();
                account.Name = user.Name;
                account.Email = user.Email;
                account.AccountType = user.AdminType.ToString();
                if(user.AdminType == 1)
                {
                    account.Roles = new string[] { "Super" };
                }
                else if(user.AdminType == 2)
                {
                    account.Roles = new string[] { "Admin" };
                }
                else if (user.AdminType == 3)
                {
                    account.Roles = new string[] { "Content" };
                }
                else if (user.AdminType == 4)
                {
                    account.Roles = new string[] { "Sales" };
                }
                else if (user.AdminType == 5)
                {
                    account.Roles = new string[] { "Accounts" };
                }
                else if (user.AdminType == 6)
                {
                    account.Roles = new string[] { "CRM" };
                }
            }
            catch(Exception ex)
            {

            }
            return account;
        }
        private AdminUser GetAdminSession()
        {
            AdminUser user = new AdminUser();
            user.Id = Convert.ToInt32(SessionPersister.Id);
            user.Email = SessionPersister.Email;
            user.Name = SessionPersister.Name;
            user.AdminType = Convert.ToInt32(SessionPersister.AccountType);
            return user;
        }
    }
}