using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnneshProject.Security
{
    public class SessionPersister
    {
        static string userEmailSession = "email";
        static string accountNameSession = "accountName";
        static string accountIdSession = "accountId";
        static string accountTypeSession = "accountType";
        static string accountPermitSession = "permitType";

        public static string Email
        {
            get
            {
                if (HttpContext.Current.Session == null)
                    return string.Empty;
                var sessionvar = HttpContext.Current.Session[userEmailSession];
                if (sessionvar != null)
                    return sessionvar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[userEmailSession] = value;
            }
        }
        public static string Name
        {
            get
            {
                if (HttpContext.Current.Session == null)
                    return string.Empty;
                var name = HttpContext.Current.Session[accountNameSession];
                if (name != null)
                    return name as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[accountNameSession] = value;
            }
        }
        public static string Id
        {
            get
            {
                if (HttpContext.Current.Session == null)
                    return string.Empty;
                var id = HttpContext.Current.Session[accountIdSession];
                if (id != null)
                    return id as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[accountIdSession] = value;
            }
        }
        public static string AccountType
        {
            get
            {
                if (HttpContext.Current.Session == null)
                    return string.Empty;
                var adminType = HttpContext.Current.Session[accountTypeSession];
                if (adminType != null)
                    return adminType as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[accountTypeSession] = value;
            }
        }
        public static string PermitType
        {
            get
            {
                if (HttpContext.Current.Session == null)
                    return string.Empty;
                var permitType = HttpContext.Current.Session[accountPermitSession];
                if (permitType != null)
                    return permitType as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[accountPermitSession] = value;
            }
        }
    }
}