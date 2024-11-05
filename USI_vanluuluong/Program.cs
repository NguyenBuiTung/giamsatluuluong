using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace USI_vanluuluong
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();

            AppDomain currentDomain = default(AppDomain);
            currentDomain = AppDomain.CurrentDomain;
            // Handler for unhandled exceptions.
            currentDomain.UnhandledException += GlobalUnhandledExceptionHandler;
            // Handler for exceptions in threads behind forms.
            System.Windows.Forms.Application.ThreadException += GlobalThreadExceptionHandler;
            Start();
        }
        private static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = default(Exception);
            ex = (Exception)e.ExceptionObject;
        }

        private static void GlobalThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = default(Exception);
            ex = e.Exception;
        }
        public static void Start()   // <-- must be marked public!
        {
            if (PriorProcess() != null)
            {

                MessageBox.Show("Ứng dụng đã khởi chạy, không chạy lại ứng dụng");
                Application.Exit();
            }
            else
            {


                string SqlConfigFile = Application.StartupPath + "\\" + "SqlConfig.txt";
                //MessageBox.Show(SqlConfigFile);
                try
                {
                    string firstLine = "";
                    using (StreamReader reader = new StreamReader(SqlConfigFile))
                    {
                        firstLine = reader.ReadLine() ?? "";
                    }
                   
                    if (firstLine.Trim() == "")
                    {
                      
                        MessageBox.Show("Phần mềm không đọc được cấu hình kết nối tới Cơ sở dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    KN.Chuoi = firstLine;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Phần mềm không đọc được file cấu hình Cơ sở dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en");

                Application.Run(new Form1());
            }
        }

        public static Process PriorProcess()
        // Returns a System.Diagnostics.Process pointing to
        // a pre-existing process with the same name as the
        // current one, if any; or null if the current process
        // is unique.
        {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) &&
                    (p.MainModule.FileName == curr.MainModule.FileName))
                    return p;
            }
            return null;
        }

    }
}
