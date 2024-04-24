using OverTime.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace OverTime.Business
{
    public class LogHelper
    {
        public enum ModuleLog
        {
            FindDaysOff = 1,
            FindForgetFinger = 2,
            RegisterOT = 3,
        }
        private static string GetModuleName(ModuleLog moduleId)
        {
            if (moduleId == ModuleLog.FindDaysOff) return "Tìm ngày nghỉ ưu đãi";
            else if (moduleId == ModuleLog.FindForgetFinger) return "Tìm kiếm quên vân tay";
            else if (moduleId == ModuleLog.RegisterOT) return "Đăng kí tăng ca";
            else
            {
                return "Không xác định";
            }
        }
        internal static void InsertExceptionLog(Exception exception, string formName)
        {
            try
            {
                using (var context = new DBContext())
                {
                    LOGDATA lOGDATA = new LOGDATA();

                    lOGDATA.CategoryId = formName;
                    lOGDATA.OperateAccount = GetAccount();
                    lOGDATA.ModuleName = exception.StackTrace.Substring(0, 199);
                    lOGDATA.HostName = Environment.MachineName;
                    lOGDATA.ExecuteName = "Phát hiện Exception!";
                    lOGDATA.LogTime = DateTime.Now;
                    context.LOGDATAs.Add(lOGDATA);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static string GetAccount()
        {
            foreach (Form form in System.Windows.Forms.Application.OpenForms)
            {
                if (form.Name == "FormMain")
                {
                    FormMain main = form as FormMain;
                    return main.USERNAME;
                }
            }
            return null; // Form not found
        }

        internal static void GetDataLog(string formName, ModuleLog module, params string[] parameter)
        {
            using(var context = new DBContext()) 
            {
                LOGDATA logData = new LOGDATA();
                logData.CategoryId = formName;
                logData.OperateAccount = GetAccount();
                logData.ModuleId = (int)module;
                logData.ModuleName = GetModuleName(module);
                logData.HostName = Environment.MachineName;
                logData.IPAddress = GetLocalIPv4(NetworkInterfaceType.Ethernet);
                logData.ExecuteId = 1;
                if(parameter != null && parameter.Length > 0)
                {
                    string content = "";
                    foreach(var param in parameter)
                    {
                        content += param.ToString() + "-";
                    }
                    logData.ExecuteName = logData.ModuleName + content;
                }
                else
                {
                    logData.ExecuteName = logData.ModuleName;
                }
                logData.LogTime = DateTime.Now;
                context.LOGDATAs.Add(logData);
                context.SaveChanges();
            }
        }

      
        static string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces().Where(n => n.NetworkInterfaceType == _type && n.OperationalStatus == OperationalStatus.Up))
            {
                foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        output = ip.Address.ToString();
                    }
                }
            }
            return output;
        }
    }
}
