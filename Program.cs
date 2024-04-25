using CommonProject.Loading.LoadingClass;
using OverTime.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
   
            // Set up the global exception handler
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            if (args.Count() > 0)
            {
                string para = string.Empty;
                for (int i = 0; i < args.Count(); i++)
                {
                    if (i != args.Count() - 1) para += args[i] + "|";
                    else
                        para += args[i];
                }

                Application.Run(new FormMain(para));
            }
            else
            {
                //string paratest = "PURLeader|*PUR-13|PUR & LOG";
               // string paratest = "DXLeader|umc@123|PI - DX";
                //string paratest = "22878|umcvn@123|QA-REPAIR|QA - ISO|QA - QC";
                //string paratest = "483|umcvn1|ACC - ACC|ACC - AC";
                //string paratest = "23702|umc@123|PI - DX";
                //string paratest = "34018|umcvn|PMC - WH|PMC - PC|PMC - MC";
                //string paratest = "WHLeader|*WH-5|PMC - WH";
                //string paratest = "450|umcvn|Approve|06/Dec/2023";
                //string paratest = "4221|20288|GA - GA";
                //string paratest = "3750|umcvn|SALES";
                //string paratest = "9800|090191|PD|PD-OFFICE";
                //string paratest = "QALeader|*QA-4|QA-REPAIR|QA - ISO|QA - QC";
                //string paratest = "LCALeader|*LCA-12|PI - LCA";
                //string paratest = "PCLeader|*PC-8|PMC - PC";
                //string paratest = "19|umcvn|GA - GA|ADM - FAC|PD";
                //string paratest = "28548|umcvn|GA - GA|ADM - FAC|PD";
                //string paratest = "UJ00070|umcvn|SALES|SALES - BC";
                //string paratest = "231|umcvn|SALES|SALES - BC";
                //string paratest = "29797|umcvn|PD|PD-OFFICE";
                string paratest = "22636|250494|PD|PD-OFFICE";
                //string paratest = "39298|ngocanh12|PUR & LOG";
                //string paratest = "349|umcvn|PUR & LOG";
                //string paratest = "23138|umcvn|PUR & LOG";
                //string paratest = "GALeader|*GA-1";
               // string paratest = "00716|umcvn";
                Application.Run(new FormMain(paratest));
                //Application.Exit();
                //Application.Run(new FormMain());
            }           
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                HandleException(ex);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private static void HandleException(Exception exception)
        {
            // Determine the current active form, if available
            Form activeForm = Application.OpenForms.Count > 0 ? Application.OpenForms[Application.OpenForms.Count - 1] : null;
            string formName = activeForm != null ? activeForm.Name : "Unknown Form";

            
            // Log or handle the exception along with the form information
           // MessageBox.Show($"An error occurred in form '{formName}': {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LogHelper.InsertExceptionLog(exception, formName);
        }
    }
}


