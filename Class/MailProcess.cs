using NPOI.SS.Formula.Functions;
using OverTime.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public class MailProcess
    {
        public static bool SendEmail(List<string> lstEmail, string content, string subject, bool isHtml, bool hasAttack, string pathAttack)
        {
            bool result = false;
            try
            {

                MailMessage message = new MailMessage();
                // message.From = new MailAddress("LCA_Program_Group@umcvn.com", "", System.Text.Encoding.UTF8);
                message.From = new MailAddress("DXsystem@umcvn.com", "", System.Text.Encoding.UTF8);
                foreach (var item in lstEmail)
                    if (!string.IsNullOrEmpty(item))
                        message.To.Add(item);

                //send html format
                message.IsBodyHtml = isHtml;
                message.Body = content;

                //send text format
                //message.Body = "hello";
                //message.BodyEncoding = System.Text.Encoding.UTF8;
                if (hasAttack)
                {
                    if (System.IO.File.Exists(pathAttack))
                    {
                        Attachment attach1 = new Attachment(pathAttack);
                        message.Attachments.Add(attach1);
                    }
                }

                message.Subject = subject;
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;

                //client.Credentials = new System.Net.NetworkCredential("LCA_Program_Group@umcvn.com", "Lcagroup2021"); //"LCA_Program_Group@umcvn.com",""
                client.Credentials = new System.Net.NetworkCredential("DXsystem@umcvn.com", "Lca@12345"); // thay đổi mail DX
                client.Send(message);

                message.Dispose();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không gửi được Email, Nhờ chụp ảnh gửi lại LCA\n\n" + ex);
                result = false;
            }
            return result;
        }

        public static void SendEmail(string Dept, string subject, string content)
        {
            try
            {
                //var task = Task.Run(new Action(() =>
                //{
                var toMails = new List<string>();
                if (!string.IsNullOrEmpty(Common.UserLogin.Email))
                    toMails.Add(Common.UserLogin.Email);
                // lst mail user của bộ phận
                var lstEmailUser = GetListUserEmail();
                var lstEmailSend = lstEmailUser.Where(x => x.Dept == Dept).ToList();
                foreach (var item in lstEmailSend)
                {
                    if (item.Email != null)
                        toMails.Add(item.Email);
                }
                //list Mail CC
                using (var db = new DBContext())
                {
                    var DeptCC = Dept;
                    var findMailCCDept = db.Tbl_MailSetting.Where(x => x.Dept == DeptCC || x.Dept == "ALL").ToList();
                    foreach (var item in findMailCCDept)
                    {
                        if (item.EmailCC != null)
                        {
                            toMails.Add(item.EmailCC);
                        }
                    }
                }
                SendEmail(toMails.Distinct().ToList(), content, subject, true, false, string.Empty);
                //}
                //));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không gửi được Email, Nhờ chụp ảnh và gửi lại DX - 2266\n\n" + ex);
                return;
            }
        }



        public static void SendEmailAlarm(string sendMailTo, string subject, string content)
        {
            try
            {
                var task = Task.Run(new Action(() =>
                {
                    var toMails = new List<string>();
                    if (!string.IsNullOrEmpty(Common.UserLogin.Email))
                        toMails.Add(Common.UserLogin.Email);
                    var lstDept = sendMailTo.Split('|').ToArray();
                    var lstEmailUser = GetListUserEmail();
                    foreach (var item in lstDept)
                    {
                        // lst mail user của bộ phận
                        var lstEmailSend = lstEmailUser.Where(x => x.Dept == item).ToList();
                        foreach (var itemMail in lstEmailSend)
                        {
                            if (itemMail.Email != null)
                                toMails.Add(itemMail.Email);
                        }
                    }
                    SendEmail(toMails, content, subject, true, false, string.Empty);
                }
              ));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không gửi được Email, Nhờ chụp ảnh và gửi lại LCA\n\n" + ex);
                return;
            }
        }

        public static void SendEmailReject(string sendMailTo, string subject, string content)
        {
            try
            {
                var task = Task.Run(new Action(() =>
                {
                    var toMails = new List<string>();
                    if (!string.IsNullOrEmpty(Common.UserLogin.Email))
                        toMails.Add(Common.UserLogin.Email);
                    var Dept = sendMailTo;
                    var lstEmailUser = GetListUserEmail();
                    var lstEmailSend = lstEmailUser.Where(x => x.Dept == Dept).ToList();
                    foreach (var item in lstEmailSend)
                    {
                        if (item.Email != null)
                            toMails.Add(item.Email);
                    }
                    SendEmail(toMails, content, subject, true, false, string.Empty);
                }
              ));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không gửi được Email, Nhờ chụp ảnh và gửi lại LCA\n\n" + ex);
                return;
            }
        }




        public static void SendEmailConfirm(string sendMailTo, string subject, string content)
        {
            try
            {
                var task = Task.Run(new Action(() =>
                {
                    var toMails = new List<string>();
                    if (!string.IsNullOrEmpty(Common.UserLogin.Email))
                        toMails.Add(Common.UserLogin.Email);
                    var Dept = sendMailTo;
                    var lstEmailUser = GetListUserEmail();
                    var lstEmailSend = lstEmailUser.Where(x => x.Dept == Dept).ToList();
                    foreach (var item in lstEmailSend)
                    {
                        if (item.Email != null)
                            toMails.Add(item.Email);
                    }

                    // list Mail GA Nhận thông báo Confirm hoàn thành
                    using (var db = new DBContext())
                    {
                        var findConfirm = db.Tbl_User.Where(x => x.ReceiveConfirm != null).ToList();
                        if (findConfirm.Count > 0)
                        {
                            foreach (var itemConfirm in findConfirm)
                            {
                                if (itemConfirm.Email != null)
                                {
                                    toMails.Add(itemConfirm.Email);
                                }
                            }
                        }
                    }
                    SendEmail(toMails, content, subject, true, false, string.Empty);
                }
              ));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không gửi được Email, Nhờ chụp ảnh và gửi lại LCA\n\n" + ex);
                return;
            }
        }

        public static List<UserEmail> GetListUserEmail()
        {
            List<UserEmail> lstResult = new List<UserEmail>();
            using (var db = new DBContext())
            {
                var lstUser = db.Tbl_User.ToList();
                foreach (var item in lstUser)
                {
                    if (item.Dept != null)
                    {
                        string[] DeptArr = item.Dept.Split('|').ToArray();
                        foreach (var itemDept in DeptArr)
                        {
                            UserEmail u = new UserEmail();
                            u.Code = item.UserCode;
                            u.Dept = itemDept;
                            u.Email = item.Email;
                            lstResult.Add(u);
                        }
                    }
                }
            }
            return lstResult;
        }
    }

    public class UserEmail
    {
        public string Code { get; set; }
        public string Dept { get; set; }
        public string Email { get; set; }
    }
}
