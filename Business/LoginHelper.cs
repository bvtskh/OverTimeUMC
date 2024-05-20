using Microsoft.Win32;
using OverTime.DataBase;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OverTime.Business
{
    public static class LoginHelper
    {
        public static KeyValuePair<string,string> GetAccountSaved()
        {
            string user = "";
            string password = "";
            RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"HKEY_CURRENT_USER\OVERTIME\Account");
            if (Key == null)
            {
                Key = Registry.CurrentUser.CreateSubKey(@"HKEY_CURRENT_USER\OVERTIME\Account");
                Key.CreateSubKey("User");
                Key.CreateSubKey("Password");
                Key.SetValue("User", "");
                Key.SetValue("Password", "");
                return new KeyValuePair<string,string>(user, password);
            }
            else
            {
                user = Key.GetValue("User").ToString();
                password =Key.GetValue("Password").ToString();
                return new KeyValuePair<string, string>(user, password);
            }
        }

        internal static string CheckPasswordChange(string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword)) return "Mật khẩu mới không được để trống";
            if (string.IsNullOrWhiteSpace(newPassword)) return "Mật khẩu không được chứa khoảng trắng";
            if (ContainsWhiteSpace(newPassword)) return "Mật khẩu không được chứa khoảng trắng";
            if (newPassword.Length < 4) return "Mật khẩu phải từ 4 ký tự trở lên";
            return null;
        }

        private static bool ContainsWhiteSpace(string input)
        {
            // Regular expression to match whitespace characters.
            Regex regex = new Regex(@"\s");

            // Check if the input contains any whitespace characters.
            return regex.IsMatch(input);
        }

        internal static Tbl_User GetAccout(string user, string password)
        {
            using(var context = new DBContext())
            {
                return context.Tbl_User.Where(w=>w.UserCode == user && w.Password == password).FirstOrDefault();
            }
        }

        internal static void SaveChangeAccount(Tbl_User account, bool @checked)
        {
            RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"HKEY_CURRENT_USER\OVERTIME\Account",true);
            if(@checked)
            {
                Key.SetValue("User",account.UserCode);
                Key.SetValue("Password", account.Password);
            }
            else
            {
                Key.SetValue("User", "");
                Key.SetValue("Password","");
            }              
        }

        internal static bool ChangePassword(Tbl_User account, string newPassword)
        {
            try
            {
                using(var context = new DBContext())
                {
                    var accExist = context.Tbl_User.Where(w=>w.UserCode == account.UserCode && w.Password == account.Password).FirstOrDefault();
                    if(accExist != null)
                    {
                        accExist.Password = newPassword;
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Tbl_Version GetCurrentVersion()
        {
            using(var context = new DBContext())
            {
               return  context.Tbl_Version.OrderByDescending(o=>o.Id).FirstOrDefault();              
            }
        }

        internal static bool CheckVersionSuccess()
        {
            var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
            var version = assemblyName.Version.ToString();
            if(GetCurrentVersion().Version != version) return false;
            return true;
        }
    }
}
