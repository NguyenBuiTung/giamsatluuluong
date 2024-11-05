using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace USI_vanluuluong
{
    public partial class Frmreport : DevExpress.XtraEditors.XtraForm
    {
        public Frmreport()
        {
            InitializeComponent();
        }
        public static SqlHelper db_report = new SqlHelper(KN.Chuoi);
        public static DataTable tb_data = new DataTable();

        private void Frmreport_Load(object sender, EventArgs e)
        {
            barEditItem1.EditValue = "Ngày";
            tungay.EditValue = DateTime.Now.AddDays(-30);
            denngay.EditValue = DateTime.Now;
            bt_Taidulieu.PerformClick();
        }

        private void btTaidulieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (barEditItem1.EditValue == "Ngày")
                {
                    string sql = "select * from DATA_NGAY where Thoigian between '" + Convert.ToDateTime(tungay.EditValue).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(denngay.EditValue).AddDays(1).ToString("yyyy-MM-dd") + "'  order by ID_ngay asc ";
                    tb_data = db_report.ExecuteSQLDataTable(sql);
                    g_dulieu.Columns[0].Caption = "Ngày";
                    g_dulieu.Columns[0].DisplayFormat.FormatString = "dd/MM/yyyy";
                    g_dulieu.Columns[0].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
             
                    gdv_dulieu.DataSource = tb_data;
                }
                else if (barEditItem1.EditValue == "Tháng")
                {
                    string sql = "select * from DATA_THANG where Thoigian between '" + Convert.ToDateTime(tungay.EditValue).ToString("yyyy-MM")+"-01" + "' and '" + Convert.ToDateTime(denngay.EditValue).AddMonths(1).ToString("yyyy-MM")+"-01" + "'  order by ID_thang asc ";
                    tb_data = db_report.ExecuteSQLDataTable(sql);
                    g_dulieu.Columns[0].Caption = "Tháng";
                    g_dulieu.Columns[0].DisplayFormat.FormatString = "MM/yyyy";
                    g_dulieu.Columns[0].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
          
                    gdv_dulieu.DataSource = tb_data;
                }
            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }

        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            if (barEditItem1.EditValue == "Ngày")
            {

            }
        }

        private void btExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = "Bao_Cao_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            gdv_dulieu.ExportToXlsx(path);
            Process.Start(path);
        }

       
    }
}