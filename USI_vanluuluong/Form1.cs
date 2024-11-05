using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using S7.Net;
using Microsoft.Win32;
using System.Diagnostics;

namespace USI_vanluuluong
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static SqlHelper db_form1 = new SqlHelper(KN.Chuoi);
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }
        private void Open_home()
        {
            Main f2 = new Main();
            OpenTab("Giám sát", "Giám sát", f2, true, Properties.Resources.monitor_18px);
            Mainnew f1 = new Mainnew();
            OpenTab("Trang chính", "Trang chính", f1, true, Properties.Resources.Start_16);
        }
        private void btGiamsat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Main f2 = new Main();
            OpenTab("Giám sát", "Giám sát", f2, true, Properties.Resources.monitor_18px);
        }
        public void OpenTab(string TieuDe, string Tag, Form frm, bool isOnly, Image img = null, string buttonTag = "")
        {
            try
            {
                string _strTieuDe = TieuDe;
                if (isOnly)
                {
                    if (checkOpenTabs(_strTieuDe) > -1)

                        return;
                }
                DevExpress.XtraTab.XtraTabPage t = new DevExpress.XtraTab.XtraTabPage();
                t.Text = _strTieuDe;
                t.Tag = buttonTag;
                if (t.Text == "Trang chính" || t.Text == "Giám sát")
                {
                    t.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
                }
                if ((frm) is DevExpress.XtraEditors.XtraForm)
                {
                    var withBlock = (DevExpress.XtraEditors.XtraForm)frm;
                    withBlock.Hide();
                    withBlock.Tag = Tag;
                    withBlock.Dock = DockStyle.Fill;
                    withBlock.FormBorderStyle = FormBorderStyle.None;

                    if (img != null)
                        t.Image = img;
                    withBlock.TopLevel = false;

                    t.Controls.Add(frm);

                    withBlock.Show();
                    tabMain.Invoke(new MethodInvoker(delegate { tabMain.TabPages.Add(t); }));
                    tabMain.SelectedTabPageIndex = tabMain.TabPages.Count - 1;
                }
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }
        public int checkOpenTabs(string name)
        {
            for (int i = 0; i <= tabMain.TabPages.Count - 1; i++)
            {
                if (tabMain.TabPages[i].Text == name)
                {
                    tabMain.SelectedTabPageIndex = i;
                    return i;
                }
            }
            return -1;
        }


        private void tabMain_CloseButtonClick(object sender, EventArgs e)
        {
            int tabIndex = tabMain.SelectedTabPageIndex;
            if (tabIndex > 1)
            {
                tabMain.SelectedTabPage.Dispose();
                tabMain.SelectedTabPageIndex = tabIndex + 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetDoubleBuffered(tabMain);
            Open_home();
            rk.SetValue("My App", path);
        }

        #region "Auto turning"
        private RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true); // Khóa dành cho khởi động cùng Windows
        private string path = Process.GetCurrentProcess().MainModule.FileName; // Tên (name) của ứng dụng đang chạy
        private object th;
        #endregion

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }



        private void btGioithieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            About f3 = new About();
            OpenTab("Giới thiệu", "Giới thiệu", f3, true, Properties.Resources.addRow_18);
        }

        private void btBaocao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frmreport f3 = new Frmreport();
            OpenTab("Báo cáo", "Báo cáo", f3, true, Properties.Resources.business_report_18px);
        }

        public Thread th_PLC;
        private void Timer_loaddata_Tick(object sender, EventArgs e)
        {
            try
            {
                if (th_PLC is null)
                {
                    th_PLC = new Thread(KNPLC_S7);
                    th_PLC.Start();
                }
                else
                {
                    if (th_PLC.IsAlive == false)
                    {
                        th_PLC = new Thread(KNPLC_S7);
                        th_PLC.Start();
                    }
                }
            }
            catch
            {

            }
        }

        Plc PLC = new Plc(CpuType.S71200, USI_vanluuluong.Properties.Settings.Default.PLCip, 0, 1);
        private void KNPLC_S7()
        {
            try
            {
                if (PLC.IsAvailable == false || PLC.IsConnected == false)
                {
                    if (PLC.Open() == ErrorCode.NoError)
                    {
                        PLC_connect.ItemAppearance.Normal.BackColor = Color.LimeGreen;
                        DATA_PLC.connect = true;
                    }
                    else
                    {
                        PLC_connect.ItemAppearance.Normal.BackColor = Color.Red;
                        DATA_PLC.connect = false;
                    }
                    Thread.Sleep(500);
                    PLC.Open();
                }
                else
                {
                    PLC_connect.ItemAppearance.Normal.BackColor = Color.LimeGreen;
                    DATA_PLC.connect = true;
                    Readdata_PLC();
                }

            }
            catch (Exception ex)
            {
                PLC.Close();
                PLC_connect.ItemAppearance.Normal.BackColor = Color.Red;
                DATA_PLC.connect = false;
                Thread.Sleep(500);
                PLC.Open();
            }
        }

        int Count_1m = 0;
        private void Readdata_PLC()
        {
            Count_1m++;
            if (Count_1m >= 60)
            {
                Count_1m = 0;
            }
            DATA_PLC.Read_PLC = PLC.ReadBytes(DataType.DataBlock, 8, 0, 142);
            if (DATA_PLC.Read_PLC.Length >= 142)
            {
                Data.v1 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[0], 0);
                Data.v2 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[0], 1);
                Data.v3 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[0], 2);
                Data.v4 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[0], 3);
                Data.v5 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[0], 4);
                Data.v6 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[0], 5);
                Data.v7 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[0], 6);
                Data.v8 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[0], 7);
                Data.v9 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[1], 0);
                Data.v10 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[1], 1);
                Data.v11 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[92], 0);
                Data.v12 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[92], 1);
                Data.v13 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[92], 2);
                Data.v14 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[92], 3);
                Data.v15 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[92], 4);
                Data.v16 = ChuyenDoi.LayDataBool(DATA_PLC.Read_PLC[92], 5);


                Data.llv1 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 2), 1);
                Data.ttv1 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 6), 1);
                Data.llv2 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 10), 1);
                Data.ttv2 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 14), 1);
                Data.llv3 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 18), 1);
                Data.ttv3 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 22), 1);
                Data.llv4 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 26), 1);
                Data.ttv4 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 30), 1);
                Data.llv5 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 34), 1);
                Data.ttv5 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 38), 1);
                Data.llv6 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 42), 1);
                Data.ttv6 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 46), 1);
                Data.llv7 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 50), 1);
                Data.ttv7 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 54), 1);
                Data.llv8 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 58), 1);
                Data.ttv8 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 62), 1);
                Data.llv9 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 66), 1);
                Data.ttv9 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 70), 1);
                Data.llv10 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 74), 1);
                Data.ttv10 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 78), 1);
                Data.llv11 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 94), 1);
                Data.ttv11 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 98), 1);
                Data.llv12 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 102), 1);
                Data.ttv12 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 106), 1);
                Data.llv13 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 110), 1);
                Data.ttv13 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 114), 1);
                Data.llv14 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 118), 1);
                Data.ttv14 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 122), 1);
                Data.llv15 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 126), 1);
                Data.ttv15 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 130), 1);
                Data.llv16 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 134), 1);
                Data.ttv16 = Math.Round(ChuyenDoi.LayDataDouble(DATA_PLC.Read_PLC, 138), 1);



                Data.ttvT = Data.ttv1 + Data.ttv2 + Data.ttv3 + Data.ttv4 + Data.ttv5 + Data.ttv6 + Data.ttv7 + Data.ttv8 + Data.ttv9 + Data.ttv10 + Data.ttv11 + Data.ttv12 + Data.ttv13 + Data.ttv14 + Data.ttv15 + Data.ttv16;
                Data.llvT = Data.llv1 + Data.llv2 + Data.llv3 + Data.llv4 + Data.llv5 + Data.llv6 + Data.llv7 + Data.llv8 + Data.llv9 + Data.llv10 + Data.llv11 + Data.llv12 + Data.llv13 + Data.llv14 + Data.llv15 + Data.llv16;

                try
                {
                    if (Count_1m == 1)
                    {
                        db_form1.AddParameter("@Thoigian", DateTime.Now);
                        db_form1.AddParameter("@LL1", Data.llv1);
                        db_form1.AddParameter("@TT1", Data.ttv1);
                        db_form1.AddParameter("@LL2", Data.llv2);
                        db_form1.AddParameter("@TT2", Data.ttv2);
                        db_form1.AddParameter("@LL3", Data.llv3);
                        db_form1.AddParameter("@TT3", Data.ttv3);
                        db_form1.AddParameter("@LL4", Data.llv4);
                        db_form1.AddParameter("@TT4", Data.ttv4);
                        db_form1.AddParameter("@LL5", Data.llv5);
                        db_form1.AddParameter("@TT5", Data.ttv5);
                        db_form1.AddParameter("@LL6", Data.llv6);
                        db_form1.AddParameter("@TT6", Data.ttv6);
                        db_form1.AddParameter("@LL7", Data.llv7);
                        db_form1.AddParameter("@TT7", Data.ttv7);
                        db_form1.AddParameter("@LL8", Data.llv8);
                        db_form1.AddParameter("@TT8", Data.ttv8);
                        db_form1.AddParameter("@LL9", Data.llv9);
                        db_form1.AddParameter("@TT9", Data.ttv9);
                        db_form1.AddParameter("@LL10", Data.llv10);
                        db_form1.AddParameter("@TT10", Data.ttv10);
                        db_form1.AddParameter("@LL11", Data.llv11);
                        db_form1.AddParameter("@TT11", Data.ttv11);
                        db_form1.AddParameter("@LL12", Data.llv12);
                        db_form1.AddParameter("@TT12", Data.ttv12);
                        db_form1.AddParameter("@LL13", Data.llv13);
                        db_form1.AddParameter("@TT13", Data.ttv13);
                        db_form1.AddParameter("@LL14", Data.llv14);
                        db_form1.AddParameter("@TT14", Data.ttv14);
                        db_form1.AddParameter("@LL15", Data.llv15);
                        db_form1.AddParameter("@TT15", Data.ttv15);
                        db_form1.AddParameter("@LL16", Data.llv16);
                        db_form1.AddParameter("@TT16", Data.ttv16);

                        if (db_form1.doInsert("DATA_REAL") == null)
                        {
                            KN.Logerror(db_form1.LoiNgoaiLe);
                        }
                    }
                }
                catch
                {

                }
                if (DATA_PLC.plc_write)
                {
                    PLC.Write("DB12.DBD0", DATA_PLC.write_data);
                    PLC.Write("DB12.DBW4", DATA_PLC.write_length);
                    PLC.Write("DB12.DBW8", DATA_PLC.write_return);
                    DATA_PLC.plc_write = false;
                }
            }

        }

        public static DataTable TBA_view;
        public static DataTable TBA1_view;
        private void LoadGR()
        {
            try
            {
                //    string sql0 = "select * from TBA2_VIEW ";
                //    sql0 += "select * from Tram_bien_ap_VIEW";
                //    DataSet dt = db_form1.ExecuteSQLDataSet(sql0);
                //    TBA_view = dt.Tables[0];
                //    TBA1_view = dt.Tables[1];
            }
            catch (Exception)
            {

            }
        }

        private void btCaidat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCaidat f4 = new frmCaidat();
            OpenTab("Cài đặt", "Cài đặt", f4, true, Properties.Resources.settings_18px);
        }

        private void btBieudo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Bieudo f4 = new Bieudo();
            OpenTab("Biểu đồ", "Biểu đồ", f4, true, Properties.Resources.area_chart_18px);
        }

        private void barBt_Trangchinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Open_home();
        }


        private void Timer_display_Tick(object sender, EventArgs e)
        {
            if (Data.v1 == false)
            {
                la_v1.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v1.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v2 == false)
            {
                la_v2.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v2.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v3 == false)
            {
                la_v3.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v3.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v4 == false)
            {
                la_v4.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v4.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v5 == false)
            {
                la_v5.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v5.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v6 == false)
            {
                la_v6.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v6.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v7 == false)
            {
                la_v7.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v7.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v8 == false)
            {
                la_v8.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v8.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v9 == false)
            {
                la_v9.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v9.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v10 == false)
            {
                la_v10.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v10.ItemAppearance.Normal.BackColor = Color.Red;
            }

            // Thêm kiểm tra cho các van từ 11 đến 16
            if (Data.v11 == false)
            {
                la_v11.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v11.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v12 == false)
            {
                la_v12.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v12.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v13 == false)
            {
                la_v13.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v13.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v14 == false)
            {
                la_v14.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v14.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v15 == false)
            {
                la_v15.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v15.ItemAppearance.Normal.BackColor = Color.Red;
            }

            if (Data.v16 == false)
            {
                la_v16.ItemAppearance.Normal.BackColor = Color.LimeGreen;
            }
            else
            {
                la_v16.ItemAppearance.Normal.BackColor = Color.Red;
            }
        }


        int Hour = 1;
        int Hour_month = 1;
        int ID_ngay = 0;
        int ID_thang = 0;
        public static DataSet SQL_data;
        private void timer_SQL_Tick(object sender, EventArgs e)
        {
            Hour = DateTime.Now.Hour;
            if (Hour <= 0)
            {
                Hour = 1;
            }

            Hour_month = (DateTime.Now.Day - 1) * 24 + DateTime.Now.Day;
            if (Hour_month <= 0)
            {
                Hour_month = 1;
            }

            string sql = "select top(2) * from DATA_NGAY order by ID_ngay desc ";
            sql += "select top(2) * from DATA_THANG order by ID_thang desc";
            SQL_data = db_form1.ExecuteSQLDataSet(sql);

            //DATA NGAY

            if (SQL_data.Tables[0].Rows.Count > 0 && DATA_PLC.connect == true)
            {
                ID_ngay = Convert.ToInt32(SQL_data.Tables[0].Rows[0]["ID_ngay"]);
                if (Convert.ToDateTime(SQL_data.Tables[0].Rows[0]["Thoigian"]).Day != DateTime.Now.Day)
                {
                    db_form1.AddParameter("@Thoigian", DateTime.Now.Date);
                    db_form1.AddParameter("@TTV1", 0);
                    db_form1.AddParameter("@LLMV1", 0);
                    db_form1.AddParameter("@TTV2", 0);
                    db_form1.AddParameter("@LLTBV2", 0);
                    db_form1.AddParameter("@LLMV2", 0);
                    db_form1.AddParameter("@TTV3", 0);
                    db_form1.AddParameter("@LLTBV3", 0);
                    db_form1.AddParameter("@LLMV3", 0);
                    db_form1.AddParameter("@TTV4", 0);
                    db_form1.AddParameter("@LLTBV4", 0);
                    db_form1.AddParameter("@LLMV4", 0);
                    db_form1.AddParameter("@TTV5", 0);
                    db_form1.AddParameter("@LLTBV5", 0);
                    db_form1.AddParameter("@LLMV5", 0);
                    db_form1.AddParameter("@TTV6", 0);
                    db_form1.AddParameter("@LLTBV6", 0);
                    db_form1.AddParameter("@LLMV6", 0);
                    db_form1.AddParameter("@TTV7", 0);
                    db_form1.AddParameter("@LLTBV7", 0);
                    db_form1.AddParameter("@LLMV7", 0);
                    db_form1.AddParameter("@TTV8", 0);
                    db_form1.AddParameter("@LLTBV8", 0);
                    db_form1.AddParameter("@LLMV8", 0);
                    db_form1.AddParameter("@TTV9", 0);
                    db_form1.AddParameter("@LLTBV9", 0);
                    db_form1.AddParameter("@LLMV9", 0);
                    db_form1.AddParameter("@TTV10", 0);
                    db_form1.AddParameter("@LLTBV10", 0);
                    db_form1.AddParameter("@LLMV10", 0);
                    db_form1.AddParameter("@TTTV1", 0);
                    db_form1.AddParameter("@TTTV2", 0);
                    db_form1.AddParameter("@TTTV3", 0);
                    db_form1.AddParameter("@TTTV4", 0);
                    db_form1.AddParameter("@TTTV5", 0);
                    db_form1.AddParameter("@TTTV6", 0);
                    db_form1.AddParameter("@TTTV7", 0);
                    db_form1.AddParameter("@TTTV8", 0);
                    db_form1.AddParameter("@TTTV9", 0);
                    db_form1.AddParameter("@TTTV10", 0);
                    // Initialization for a new day
                    db_form1.AddParameter("@TTV11", 0);
                    db_form1.AddParameter("@LLTBV11", 0);
                    db_form1.AddParameter("@LLMV11", 0);
                    db_form1.AddParameter("@TTV12", 0);
                    db_form1.AddParameter("@LLTBV12", 0);
                    db_form1.AddParameter("@LLMV12", 0);
                    db_form1.AddParameter("@TTV13", 0);
                    db_form1.AddParameter("@LLTBV13", 0);
                    db_form1.AddParameter("@LLMV13", 0);
                    db_form1.AddParameter("@TTV14", 0);
                    db_form1.AddParameter("@LLTBV14", 0);
                    db_form1.AddParameter("@LLMV14", 0);
                    db_form1.AddParameter("@TTV15", 0);
                    db_form1.AddParameter("@LLTBV15", 0);
                    db_form1.AddParameter("@LLMV15", 0);
                    db_form1.AddParameter("@TTV16", 0);
                    db_form1.AddParameter("@LLTBV16", 0);
                    db_form1.AddParameter("@LLMV16", 0);
                    db_form1.AddParameter("@TTTV11", 0);
                    db_form1.AddParameter("@TTTV12", 0);
                    db_form1.AddParameter("@TTTV13", 0);
                    db_form1.AddParameter("@TTTV14", 0);
                    db_form1.AddParameter("@TTTV15", 0);
                    db_form1.AddParameter("@TTTV16", 0);
                    db_form1.AddParameter("@Ro", 0);
                    if (db_form1.doInsert("DATA_NGAY") == null)
                    {
                        KN.Logerror(db_form1.LoiNgoaiLe);
                    }
                }
                else
                {
                    db_form1.AddParameter("@Thoigian", DateTime.Now.Date);
                    db_form1.AddParameter("@TTV1", Math.Round(Data.ttv1 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV1"]), 1));
                    db_form1.AddParameter("@LLTBV1", Math.Round((Data.ttv1 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV1"])) / Hour, 1));
                    if (Data.llv1 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV1"]))
                    {
                        db_form1.AddParameter("@LLMV1", Math.Round(Data.llv1, 1));
                    }
                    db_form1.AddParameter("@TTV2", Math.Round(Data.ttv2 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV2"]), 1));
                    db_form1.AddParameter("@LLTBV2", Math.Round((Data.ttv2 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV2"])) / Hour, 1));
                    if (Data.llv2 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV2"]))
                    {
                        db_form1.AddParameter("@LLMV2", Math.Round(Data.llv2, 1));
                    }
                    db_form1.AddParameter("@TTV3", Math.Round(Data.ttv3 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV3"]), 1));
                    db_form1.AddParameter("@LLTBV3", Math.Round((Data.ttv3 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV3"])) / Hour, 1));
                    if (Data.llv3 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV3"]))
                    {
                        db_form1.AddParameter("@LLMV3", Math.Round(Data.llv3, 1));
                    }
                    db_form1.AddParameter("@TTV4", Math.Round(Data.ttv4 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV4"]), 1));
                    db_form1.AddParameter("@LLTBV4", Math.Round((Data.ttv4 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV4"])) / Hour, 1));
                    if (Data.llv4 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV4"]))
                    {
                        db_form1.AddParameter("@LLMV4", Math.Round(Data.llv4, 1));
                    }
                    db_form1.AddParameter("@TTV5", Math.Round(Data.ttv5 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV5"]), 1));
                    db_form1.AddParameter("@LLTBV5", Math.Round((Data.ttv5 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV5"])) / Hour, 1));
                    if (Data.llv5 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV5"]))
                    {
                        db_form1.AddParameter("@LLMV5", Math.Round(Data.llv5, 1));
                    }
                    db_form1.AddParameter("@TTV6", Math.Round(Data.ttv6 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV6"]), 1));
                    db_form1.AddParameter("@LLTBV6", Math.Round((Data.ttv6 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV6"])) / Hour, 1));
                    if (Data.llv6 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV6"]))
                    {
                        db_form1.AddParameter("@LLMV6", Math.Round(Data.llv6, 1));
                    }
                    db_form1.AddParameter("@TTV7", Math.Round(Data.ttv7 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV7"]), 1));
                    db_form1.AddParameter("@LLTBV7", Math.Round((Data.ttv7 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV7"])) / Hour, 1));
                    if (Data.llv7 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV7"]))
                    {
                        db_form1.AddParameter("@LLMV7", Math.Round(Data.llv7, 1));
                    }
                    db_form1.AddParameter("@TTV8", Math.Round(Data.ttv8 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV8"]), 1));
                    db_form1.AddParameter("@LLTBV8", Math.Round((Data.ttv8 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV8"])) / Hour, 1));
                    if (Data.llv8 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV8"]))
                    {
                        db_form1.AddParameter("@LLMV8", Math.Round(Data.llv8, 1));
                    }
                    db_form1.AddParameter("@TTV9", Math.Round(Data.ttv9 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV9"]), 1));
                    db_form1.AddParameter("@LLTBV9", Math.Round((Data.ttv9 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV9"])) / Hour, 1));
                    if (Data.llv9 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV9"]))
                    {
                        db_form1.AddParameter("@LLMV9", Math.Round(Data.llv9, 1));
                    }
                    db_form1.AddParameter("@TTV10", Math.Round(Data.ttv10 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV10"]), 1));
                    db_form1.AddParameter("@LLTBV10", Math.Round((Data.ttv10 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV10"])) / Hour, 1));
                    if (Data.llv10 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV10"]))
                    {
                        db_form1.AddParameter("@LLMV10", Math.Round(Data.llv10, 1));
                    }
                    // Update logic for valves 11 to 16
                    db_form1.AddParameter("@TTV11", Math.Round(Data.ttv11 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV11"]), 1));
                    db_form1.AddParameter("@LLTBV11", Math.Round((Data.ttv11 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV11"])) / Hour, 1));
                    if (Data.llv11 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV11"]))
                    {
                        db_form1.AddParameter("@LLMV11", Math.Round(Data.llv11, 1));
                    }

                    db_form1.AddParameter("@TTV12", Math.Round(Data.ttv12 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV12"]), 1));
                    db_form1.AddParameter("@LLTBV12", Math.Round((Data.ttv12 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV12"])) / Hour, 1));
                    if (Data.llv12 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV12"]))
                    {
                        db_form1.AddParameter("@LLMV12", Math.Round(Data.llv12, 1));
                    }

                    db_form1.AddParameter("@TTV13", Math.Round(Data.ttv13 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV13"]), 1));
                    db_form1.AddParameter("@LLTBV13", Math.Round((Data.ttv13 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV13"])) / Hour, 1));
                    if (Data.llv13 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV13"]))
                    {
                        db_form1.AddParameter("@LLMV13", Math.Round(Data.llv13, 1));
                    }

                    db_form1.AddParameter("@TTV14", Math.Round(Data.ttv14 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV14"]), 1));
                    db_form1.AddParameter("@LLTBV14", Math.Round((Data.ttv14 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV14"])) / Hour, 1));
                    if (Data.llv14 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV14"]))
                    {
                        db_form1.AddParameter("@LLMV14", Math.Round(Data.llv14, 1));
                    }

                    db_form1.AddParameter("@TTV15", Math.Round(Data.ttv15 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV15"]), 1));
                    db_form1.AddParameter("@LLTBV15", Math.Round((Data.ttv15 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV15"])) / Hour, 1));
                    if (Data.llv15 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV15"]))
                    {
                        db_form1.AddParameter("@LLMV15", Math.Round(Data.llv15, 1));
                    }

                    //var aa = SQL_data.Tables[0].Rows[1]["TTTV15"];
                    //var bb = SQL_data.Tables[0].Rows[1]["TTTV16"];

                    db_form1.AddParameter("@TTV16", Math.Round(Data.ttv16 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV16"]), 1));
                    db_form1.AddParameter("@LLTBV16", Math.Round((Data.ttv16 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV16"])) / Hour, 1));
                    if (Data.llv16 > Convert.ToDouble(SQL_data.Tables[0].Rows[0]["LLMV16"]))
                    {
                        db_form1.AddParameter("@LLMV16", Math.Round(Data.llv16, 1));
                    }
                    if (Data.ttv1 > 0)
                    {
                        db_form1.AddParameter("@TTTV1", Math.Round(Data.ttv1, 1));
                    }
                    if (Data.ttv2 > 0)
                    {
                        db_form1.AddParameter("@TTTV2", Math.Round(Data.ttv2, 1));
                    }
                    if (Data.ttv3 > 0)
                    {
                        db_form1.AddParameter("@TTTV3", Math.Round(Data.ttv3, 1));
                    }
                    if (Data.ttv4 > 0)
                    {
                        db_form1.AddParameter("@TTTV4", Math.Round(Data.ttv4, 1));
                    }
                    if (Data.ttv5 > 0)
                    {
                        db_form1.AddParameter("@TTTV5", Math.Round(Data.ttv5, 1));
                    }
                    if (Data.ttv6 > 0)
                    {
                        db_form1.AddParameter("@TTTV6", Math.Round(Data.ttv6, 1));
                    }
                    if (Data.ttv7 > 0)
                    {
                        db_form1.AddParameter("@TTTV7", Math.Round(Data.ttv7, 1));
                    }
                    if (Data.ttv8 > 0)
                    {
                        db_form1.AddParameter("@TTTV8", Math.Round(Data.ttv8, 1));
                    }
                    if (Data.ttv9 > 0)
                    {
                        db_form1.AddParameter("@TTTV9", Math.Round(Data.ttv9, 1));
                    }
                    if (Data.ttv10 > 0)
                    {
                        db_form1.AddParameter("@TTTV10", Math.Round(Data.ttv10, 1));
                    }
                    // Add new valves (ttv11 to ttv16)
                    if (Data.ttv11 > 0)
                    {
                        db_form1.AddParameter("@TTTV11", Math.Round(Data.ttv11, 1));
                    }
                    if (Data.ttv12 > 0)
                    {
                        db_form1.AddParameter("@TTTV12", Math.Round(Data.ttv12, 1));
                    }
                    if (Data.ttv13 > 0)
                    {
                        db_form1.AddParameter("@TTTV13", Math.Round(Data.ttv13, 1));
                    }
                    if (Data.ttv14 > 0)
                    {
                        db_form1.AddParameter("@TTTV14", Math.Round(Data.ttv14, 1));
                    }
                    if (Data.ttv15 > 0)
                    {
                        db_form1.AddParameter("@TTTV15", Math.Round(Data.ttv15, 1));
                    }
                    if (Data.ttv16 > 0)
                    {
                        db_form1.AddParameter("@TTTV16", Math.Round(Data.ttv16, 1));
                    }
                    // Update the @Ro parameter to account for new valves
                    db_form1.AddParameter("@Ro",
                        Math.Round(Data.ttv1 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV1"]), 1) -
                        Math.Round(Data.ttv16 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV16"]), 1));

                    db_form1.AddParameterWhere("@ID_ngay", ID_ngay);
                    if (db_form1.doUpdate("DATA_NGAY", "ID_ngay = @ID_ngay") == null)
                    {
                        KN.Logerror(db_form1.LoiNgoaiLe);
                    }
                }
            }

            //DATA THANG
            if (SQL_data.Tables[1].Rows.Count > 0 && DATA_PLC.connect == true && DATA_PLC.Read_PLC.Length >= 50)
            {
                ID_thang = Convert.ToInt32(SQL_data.Tables[1].Rows[0]["ID_thang"]);
                if (Convert.ToDateTime(SQL_data.Tables[1].Rows[0]["Thoigian"]).Month != DateTime.Now.Month)
                {
                    db_form1.AddParameter("@Thoigian", DateTime.Now.Date);
                    db_form1.AddParameter("@TTV1", 0);
                    db_form1.AddParameter("@LLTBV1", 0);
                    db_form1.AddParameter("@LLMV1", 0);
                    db_form1.AddParameter("@TTV2", 0);
                    db_form1.AddParameter("@LLTBV2", 0);
                    db_form1.AddParameter("@LLMV2", 0);
                    db_form1.AddParameter("@TTV3", 0);
                    db_form1.AddParameter("@LLTBV3", 0);
                    db_form1.AddParameter("@LLMV3", 0);
                    db_form1.AddParameter("@TTV4", 0);
                    db_form1.AddParameter("@LLTBV4", 0);
                    db_form1.AddParameter("@LLMV4", 0);
                    db_form1.AddParameter("@TTV5", 0);
                    db_form1.AddParameter("@LLTBV5", 0);
                    db_form1.AddParameter("@LLMV5", 0);
                    db_form1.AddParameter("@TTV6", 0);
                    db_form1.AddParameter("@LLTBV6", 0);
                    db_form1.AddParameter("@LLMV6", 0);
                    db_form1.AddParameter("@TTV7", 0);
                    db_form1.AddParameter("@LLTBV7", 0);
                    db_form1.AddParameter("@LLMV7", 0);
                    db_form1.AddParameter("@TTV8", 0);
                    db_form1.AddParameter("@LLTBV8", 0);
                    db_form1.AddParameter("@LLMV8", 0);
                    db_form1.AddParameter("@TTV9", 0);
                    db_form1.AddParameter("@LLTBV9", 0);
                    db_form1.AddParameter("@LLMV9", 0);
                    db_form1.AddParameter("@TTV10", 0);
                    db_form1.AddParameter("@LLTBV10", 0);
                    db_form1.AddParameter("@LLMV10", 0);
                    db_form1.AddParameter("@TTV11", 0);
                    db_form1.AddParameter("@LLTBV11", 0);
                    db_form1.AddParameter("@LLMV11", 0);
                    db_form1.AddParameter("@TTV12", 0);
                    db_form1.AddParameter("@LLTBV12", 0);
                    db_form1.AddParameter("@LLMV12", 0);
                    db_form1.AddParameter("@TTV13", 0);
                    db_form1.AddParameter("@LLTBV13", 0);
                    db_form1.AddParameter("@LLMV13", 0);
                    db_form1.AddParameter("@TTV14", 0);
                    db_form1.AddParameter("@LLTBV14", 0);
                    db_form1.AddParameter("@LLMV14", 0);
                    db_form1.AddParameter("@TTV15", 0);
                    db_form1.AddParameter("@LLTBV15", 0);
                    db_form1.AddParameter("@LLMV15", 0);
                    db_form1.AddParameter("@TTV16", 0);
                    db_form1.AddParameter("@LLTBV16", 0);
                    db_form1.AddParameter("@LLMV16", 0);
                    db_form1.AddParameter("@TTTV1", 0);
                    db_form1.AddParameter("@TTTV2", 0);
                    db_form1.AddParameter("@TTTV3", 0);
                    db_form1.AddParameter("@TTTV4", 0);
                    db_form1.AddParameter("@TTTV5", 0);
                    db_form1.AddParameter("@TTTV6", 0);
                    db_form1.AddParameter("@TTTV7", 0);
                    db_form1.AddParameter("@TTTV8", 0);
                    db_form1.AddParameter("@TTTV9", 0);
                    db_form1.AddParameter("@TTTV10", 0);
                    db_form1.AddParameter("@TTTV11", 0);
                    db_form1.AddParameter("@TTTV12", 0);
                    db_form1.AddParameter("@TTTV13", 0);
                    db_form1.AddParameter("@TTTV14", 0);
                    db_form1.AddParameter("@TTTV15", 0);
                    db_form1.AddParameter("@TTTV16", 0);
                    db_form1.AddParameter("@Ro", 0);
                    if (db_form1.doInsert("DATA_THANG") == null)
                    {
                        KN.Logerror(db_form1.LoiNgoaiLe);
                    }
                }
                else
                {
                    db_form1.AddParameter("@Thoigian", DateTime.Now.Date);
                    db_form1.AddParameter("@TTV1", Math.Round(Data.ttv1 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV1"]), 1));
                    db_form1.AddParameter("@LLTBV1", Math.Round((Data.ttv1 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV1"])) / Hour_month, 1));
                    if (Data.llv1 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV1"]))
                    {
                        db_form1.AddParameter("@LLMV1", Math.Round(Data.llv1, 1));
                    }

                    db_form1.AddParameter("@TTV2", Math.Round(Data.ttv2 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV2"]), 1));
                    db_form1.AddParameter("@LLTBV2", Math.Round((Data.ttv2 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV2"])) / Hour_month, 1));
                    if (Data.llv2 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV2"]))
                    {
                        db_form1.AddParameter("@LLMV2", Math.Round(Data.llv2, 1));
                    }

                    db_form1.AddParameter("@TTV3", Math.Round(Data.ttv3 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV3"]), 1));
                    db_form1.AddParameter("@LLTBV3", Math.Round((Data.ttv3 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV3"])) / Hour_month, 1));
                    if (Data.llv3 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV3"]))
                    {
                        db_form1.AddParameter("@LLMV3", Math.Round(Data.llv3, 1));
                    }

                    db_form1.AddParameter("@TTV4", Math.Round(Data.ttv4 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV4"]), 1));
                    db_form1.AddParameter("@LLTBV4", Math.Round((Data.ttv4 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV4"])) / Hour_month, 1));
                    if (Data.llv4 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV4"]))
                    {
                        db_form1.AddParameter("@LLMV4", Math.Round(Data.llv4, 1));
                    }

                    db_form1.AddParameter("@TTV5", Math.Round(Data.ttv5 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV5"]), 1));
                    db_form1.AddParameter("@LLTBV5", Math.Round((Data.ttv5 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV5"])) / Hour_month, 1));
                    if (Data.llv5 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV5"]))
                    {
                        db_form1.AddParameter("@LLMV5", Math.Round(Data.llv5, 1));
                    }

                    db_form1.AddParameter("@TTV6", Math.Round(Data.ttv6 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV6"]), 1));
                    db_form1.AddParameter("@LLTBV6", Math.Round((Data.ttv6 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV6"])) / Hour_month, 1));
                    if (Data.llv6 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV6"]))
                    {
                        db_form1.AddParameter("@LLMV6", Math.Round(Data.llv6, 1));
                    }

                    db_form1.AddParameter("@TTV7", Math.Round(Data.ttv7 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV7"]), 1));
                    db_form1.AddParameter("@LLTBV7", Math.Round((Data.ttv7 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV7"])) / Hour_month, 1));
                    if (Data.llv7 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV7"]))
                    {
                        db_form1.AddParameter("@LLMV7", Math.Round(Data.llv7, 1));
                    }

                    db_form1.AddParameter("@TTV8", Math.Round(Data.ttv8 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV8"]), 1));
                    db_form1.AddParameter("@LLTBV8", Math.Round((Data.ttv8 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV8"])) / Hour_month, 1));
                    if (Data.llv8 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV8"]))
                    {
                        db_form1.AddParameter("@LLMV8", Math.Round(Data.llv8, 1));
                    }

                    db_form1.AddParameter("@TTV9", Math.Round(Data.ttv9 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV9"]), 1));
                    db_form1.AddParameter("@LLTBV9", Math.Round((Data.ttv9 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV9"])) / Hour_month, 1));
                    if (Data.llv9 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV9"]))
                    {
                        db_form1.AddParameter("@LLMV9", Math.Round(Data.llv9, 1));
                    }

                    db_form1.AddParameter("@TTV10", Math.Round(Data.ttv10 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV10"]), 1));
                    db_form1.AddParameter("@LLTBV10", Math.Round((Data.ttv10 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV10"])) / Hour_month, 1));
                    if (Data.llv10 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV10"]))
                    {
                        db_form1.AddParameter("@LLMV10", Math.Round(Data.llv10, 1));
                    }

                    db_form1.AddParameter("@TTV11", Math.Round(Data.ttv11 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV11"]), 1));
                    db_form1.AddParameter("@LLTBV11", Math.Round((Data.ttv11 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV11"])) / Hour_month, 1));
                    if (Data.llv11 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV11"]))
                    {
                        db_form1.AddParameter("@LLMV11", Math.Round(Data.llv11, 1));
                    }

                    db_form1.AddParameter("@TTV12", Math.Round(Data.ttv12 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV12"]), 1));
                    db_form1.AddParameter("@LLTBV12", Math.Round((Data.ttv12 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV12"])) / Hour_month, 1));
                    if (Data.llv12 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV12"]))
                    {
                        db_form1.AddParameter("@LLMV12", Math.Round(Data.llv12, 1));
                    }

                    db_form1.AddParameter("@TTV13", Math.Round(Data.ttv13 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV13"]), 1));
                    db_form1.AddParameter("@LLTBV13", Math.Round((Data.ttv13 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV13"])) / Hour_month, 1));
                    if (Data.llv13 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV13"]))
                    {
                        db_form1.AddParameter("@LLMV13", Math.Round(Data.llv13, 1));
                    }

                    db_form1.AddParameter("@TTV14", Math.Round(Data.ttv14 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV14"]), 1));
                    db_form1.AddParameter("@LLTBV14", Math.Round((Data.ttv14 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV14"])) / Hour_month, 1));
                    if (Data.llv14 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV14"]))
                    {
                        db_form1.AddParameter("@LLMV14", Math.Round(Data.llv14, 1));
                    }

                    db_form1.AddParameter("@TTV15", Math.Round(Data.ttv15 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV15"]), 1));
                    db_form1.AddParameter("@LLTBV15", Math.Round((Data.ttv15 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV15"])) / Hour_month, 1));
                    if (Data.llv15 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV15"]))
                    {
                        db_form1.AddParameter("@LLMV15", Math.Round(Data.llv15, 1));
                    }

                    db_form1.AddParameter("@TTV16", Math.Round(Data.ttv16 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV16"]), 1));
                    db_form1.AddParameter("@LLTBV16", Math.Round((Data.ttv16 - Convert.ToDouble(SQL_data.Tables[1].Rows[1]["TTTV16"])) / Hour_month, 1));
                    if (Data.llv16 > Convert.ToDouble(SQL_data.Tables[1].Rows[0]["LLMV16"]))
                    {
                        db_form1.AddParameter("@LLMV16", Math.Round(Data.llv16, 1));
                    }
                    if (Data.ttv1 > 0)
                    {
                        db_form1.AddParameter("@TTTV1", Math.Round(Data.ttv1, 1));
                    }
                    if (Data.ttv2 > 0)
                    {
                        db_form1.AddParameter("@TTTV2", Math.Round(Data.ttv2, 1));
                    }
                    if (Data.ttv3 > 0)
                    {
                        db_form1.AddParameter("@TTTV3", Math.Round(Data.ttv3, 1));
                    }
                    if (Data.ttv4 > 0)
                    {
                        db_form1.AddParameter("@TTTV4", Math.Round(Data.ttv4, 1));
                    }
                    if (Data.ttv5 > 0)
                    {
                        db_form1.AddParameter("@TTTV5", Math.Round(Data.ttv5, 1));
                    }
                    if (Data.ttv6 > 0)
                    {
                        db_form1.AddParameter("@TTTV6", Math.Round(Data.ttv6, 1));
                    }

                    if (Data.ttv7 > 0)
                    {
                        db_form1.AddParameter("@TTTV7", Math.Round(Data.ttv7, 1));
                    }
                    if (Data.ttv8 > 0)
                    {
                        db_form1.AddParameter("@TTTV8", Math.Round(Data.ttv8, 1));
                    }
                    if (Data.ttv9 > 0)
                    {
                        db_form1.AddParameter("@TTTV9", Math.Round(Data.ttv9, 1));
                    }
                    if (Data.ttv10 > 0)
                    {
                        db_form1.AddParameter("@TTTV10", Math.Round(Data.ttv10, 1));
                    }
                    if (Data.ttv11 > 0)
                    {
                        db_form1.AddParameter("@TTTV11", Math.Round(Data.ttv11, 1));
                    }
                    if (Data.ttv12 > 0)
                    {
                        db_form1.AddParameter("@TTTV12", Math.Round(Data.ttv12, 1));
                    }
                    if (Data.ttv13 > 0)
                    {
                        db_form1.AddParameter("@TTTV13", Math.Round(Data.ttv13, 1));
                    }
                    if (Data.ttv14 > 0)
                    {
                        db_form1.AddParameter("@TTTV14", Math.Round(Data.ttv14, 1));
                    }
                    if (Data.ttv15 > 0)
                    {
                        db_form1.AddParameter("@TTTV15", Math.Round(Data.ttv15, 1));
                    }
                    if (Data.ttv16 > 0)
                    {
                        db_form1.AddParameter("@TTTV16", Math.Round(Data.ttv16, 1));
                    }
                    db_form1.AddParameter("@Ro", Math.Round(Data.ttv1 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV1"]), 1) - Math.Round(Data.ttv16 - Convert.ToDouble(SQL_data.Tables[0].Rows[1]["TTTV16"]), 1));

                    db_form1.AddParameterWhere("@ID_thang", ID_thang);
                    if (db_form1.doUpdate("DATA_THANG", "ID_thang = @ID_thang") == null)
                    {
                        KN.Logerror(db_form1.LoiNgoaiLe);
                    }
                }
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
        }


    }
}
