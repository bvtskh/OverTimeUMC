using CommonProject.Entities;
using OverTime.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverTime.Business
{
    public static class GroupSupportHelper
    {
        public static string AddToGroup(string StaffCode, string Group, string cus)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var exist = db.Tbl_GroupSupporters.Where(m => m.StaffCode == StaffCode).FirstOrDefault();
                    if (exist == null)
                    {
                        db.Tbl_GroupSupporters.Add(new Tbl_GroupSupporter()
                        {
                            StaffCode = StaffCode,
                            GroupLine = Group,
                            Customer = cus,
                            Updator = Common.UserLogin.UserName,
                            UpdTime = DateTime.Now
                        });
                    }
                    else
                    {
                        exist.GroupLine = Group;
                        exist.Customer = cus;
                        exist.UpdTime = DateTime.Now;
                        exist.Updator = Common.UserLogin.UserName;
                    }
                    db.SaveChanges();
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public static bool CheckExistGroup(string StaffCode, string GroupLine)
        {
            if (string.IsNullOrEmpty(GroupLine)) return false;
            using (var db = new DBContext())
            {
                var result = db.Tbl_GroupSupporters.Where(m => m.StaffCode == StaffCode).FirstOrDefault();
                if (result == null) return true;
                if (result != null && result.GroupLine != GroupLine) return true;
                return false;
            }

        }

        internal static string DeleteFromGroup(string code)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var result = db.Tbl_GroupSupporters.Where(m => m.StaffCode == code).FirstOrDefault();
                    if (result != null)
                    {
                        db.Tbl_GroupSupporters.Remove(result);
                        db.SaveChanges();
                    }
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
