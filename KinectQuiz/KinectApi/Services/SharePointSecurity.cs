using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectApi.Services
{
    public class SharePointSecurity
    {
        public static readonly string ClientID = ConfigurationManager.AppSettings["ida:ClientID"];
        public static readonly string ReturnUri = ConfigurationManager.AppSettings["ReturnUrl"];

        // Properties used to communicate with a Windows Azure AD tenant.
        public const string CommonAuthority = "https://login.windows.net/Common";
        public const string DiscoveryResourceId = "https://api.office.com/discovery/";

        public static string GetAccessToken()
        {
            return ConfigurationManager.AppSettings["SharePointAccessToken"];
        }
    }
}
