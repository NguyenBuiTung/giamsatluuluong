using DevExpress.Utils;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USI_vanluuluong
{
    class KN
    {
        public static string noi_dung;
        public static DevExpress.Utils.WaitDialogForm wDlg;
        public static XtraForm frmpopup = new XtraForm();

        public static string Chuoi ="";
        public static void Showalert(string NOiDUNG)
        {
            ImageCollection image = new ImageCollection();
            image.AddImage(Properties.Resources.error_18px);
            AlertControl alertControl1 = new AlertControl();
            alertControl1.Show(Form1.ActiveForm, "Cảnh báo", NOiDUNG, image.Images[0]);
        }

        public static void ShowalertThanhCong(string NOiDUNG)
        {
            ImageCollection image = new ImageCollection();
            image.AddImage(Properties.Resources.ok_50px);
            AlertControl alertControl1 = new AlertControl();
            alertControl1.Show(Form1.ActiveForm, "Thông báo", NOiDUNG, image.Images[0]);
        }

        public static void Popup(Panel panel, int width, int Height)
        {
            frmpopup.FormBorderStyle = FormBorderStyle.None;
            frmpopup.MaximizeBox = false;
            frmpopup.MinimizeBox = false;
            panel.Dock = DockStyle.Fill;
            frmpopup.BackColor = Color.White;
            frmpopup.StartPosition = FormStartPosition.CenterScreen;
            frmpopup.Width = width;
            frmpopup.Height = Height;
            frmpopup.ShowIcon = false;
            frmpopup.Controls.Add(panel);
            panel.Visible = true;
            frmpopup.ShowDialog();
        }

        public static void CanhBao_delay(string noidung = "")
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
           

            args.AutoCloseOptions.Delay = 500000;
            args.Caption = "Thông báo";
            var Cbitmap = Properties.Resources.warning_18px;
            IntPtr icH = Cbitmap.GetHicon();
            Icon ico = Icon.FromHandle(icH);
            args.Icon = ico;
            args.Text = noidung;
            args.Buttons = new DialogResult[] { DialogResult.OK };
            args.DefaultButtonIndex = 0;
            args.Showing += Args_Showing;
            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            XtraMessageBox.Show(args).ToString();
        }


        private static void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            foreach (var control in e.Form.Controls)
            {
                SimpleButton button = control as SimpleButton;
                if (button != null)
                {
                    button.ImageOptions.SvgImageSize = new Size(16, 16);
                    //button.Height = 25;
                    switch (button.DialogResult.ToString())
                    {
                        case ("OK"):
                            button.ImageOptions.SvgImage = Properties.Resources.ok;
                            break;
                        case ("Cancel"):
                            button.ImageOptions.SvgImage = Properties.Resources.cancel;
                            break;
                        case ("Retry"):
                            button.ImageOptions.SvgImage = Properties.Resources.synchronize;
                            break;
                    }
                }
            }
        }

        public static void ShowCanhBao(string NoiDung)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(NoiDung, "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void ShowWaiting(string _Noi_Dung = "Đang tải dữ liệu ...", string _Tieu_De = "")
        {
            wDlg = new DevExpress.Utils.WaitDialogForm(_Noi_Dung, _Tieu_De);
            wDlg.AutoSize = true;
            wDlg.Show();
        }

        public static void CloseWaiting()
        {
            wDlg.Close();
        }


        public static void Logerror(string NoiDung)
        {
            string path = Application.StartupPath.ToString() + "\\Log" + DateTime.Now.ToString("yyyy") + "\\";
            string filename = "Log" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            Application.StartupPath.ToString();
            if (!System.IO.Directory.Exists(Application.StartupPath.ToString() + "\\Log" + DateTime.Now.ToString("yyyy") + "\\"))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath.ToString() + "\\Log" + DateTime.Now.ToString("yyyy") + "\\");
            }

            FileStream st = new FileStream(path + filename, FileMode.Append);
            StreamWriter sWriter = new StreamWriter(st, Encoding.UTF8);
            sWriter.WriteLine("Log-" + DateTime.Now.ToString("HH:mm") + "-" + NoiDung + "\n");
            sWriter.Flush();
            st.Close();
        }
        public static void Showloi(string NoiDung)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(NoiDung, "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            string path = Application.StartupPath.ToString() + "\\Log" + DateTime.Now.ToString("yyyy") + "\\";
            string filename = "Log" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            Application.StartupPath.ToString();
            if (!System.IO.Directory.Exists(Application.StartupPath.ToString() + "\\Log" + DateTime.Now.ToString("yyyy") + "\\"))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath.ToString() + "\\Log" + DateTime.Now.ToString("yyyy") + "\\");
            }
            FileStream st = new FileStream(path + filename, FileMode.Append);
            StreamWriter sWriter = new StreamWriter(st, Encoding.UTF8);
            sWriter.WriteLine("Log-" + DateTime.Now.ToString("HH:mm") + "-" + NoiDung);
            sWriter.Flush();
            st.Close();
        }
       
        public static Boolean ShowCauhoi(string NoiDung)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show(NoiDung, "Chú ý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
