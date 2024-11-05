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
using DevExpress.XtraCharts;

namespace USI_vanluuluong
{
    public partial class Bieudo : DevExpress.XtraEditors.XtraForm
    {
        public Bieudo()
        {
            InitializeComponent();
        }
        public static SqlHelper db_bieudo = new SqlHelper(KN.Chuoi);

        public static DataTable SQL_real;
        int k = 0;
        int min_now = DateTime.Now.Minute;
        int min_old = DateTime.Now.AddMinutes(-1).Minute;
        DateTime DT_dothi = DateTime.Now;


        private void Dinh_dang1()
        {
            XYDiagram diagram_Van1 = (XYDiagram)frmVan1.Diagram;
            diagram_Van1.AxisX.Label.TextPattern = "{A:dd/hh:mm}";

            if (V1.Checked)
            {
                frmVan1.Series["VAN1"].Visible = true;
                frmVan1.Series["VAN1"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN1"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN1"].Visible = false;
            }

            if (V2.Checked)
            {
                frmVan1.Series["VAN2"].Visible = true;
                frmVan1.Series["VAN2"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN2"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN2"].Visible = false;
            }

            if (V3.Checked)
            {
                frmVan1.Series["VAN3"].Visible = true;
                frmVan1.Series["VAN3"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN3"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN3"].Visible = false;
            }

            if (V4.Checked)
            {
                frmVan1.Series["VAN4"].Visible = true;
                frmVan1.Series["VAN4"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN4"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN4"].Visible = false;
            }

            if (V5.Checked)
            {
                frmVan1.Series["VAN5"].Visible = true;
                frmVan1.Series["VAN5"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN5"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN5"].Visible = false;
            }

            if (V6.Checked)
            {
                frmVan1.Series["VAN6"].Visible = true;
                frmVan1.Series["VAN6"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN6"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN6"].Visible = false;
            }

            if (V7.Checked)
            {
                frmVan1.Series["VAN7"].Visible = true;
                frmVan1.Series["VAN7"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN7"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN7"].Visible = false;
            }

            if (V8.Checked)
            {
                frmVan1.Series["VAN8"].Visible = true;
                frmVan1.Series["VAN8"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN8"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN8"].Visible = false;
            }

            if (V9.Checked)
            {
                frmVan1.Series["VAN9"].Visible = true;
                frmVan1.Series["VAN9"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN9"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN9"].Visible = false;
            }

            if (V10.Checked)
            {
                frmVan1.Series["VAN10"].Visible = true;
                frmVan1.Series["VAN10"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN10"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN10"].Visible = false;
            }
            if (V11.Checked)
            {
                frmVan1.Series["VAN11"].Visible = true;
                frmVan1.Series["VAN11"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN11"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN11"].Visible = false;
            }
            if (V12.Checked)
            {
                frmVan1.Series["VAN12"].Visible = true;
                frmVan1.Series["VAN12"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN12"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN12"].Visible = false;
            }
            if (V13.Checked)
            {
                frmVan1.Series["VAN13"].Visible = true;
                frmVan1.Series["VAN13"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN13"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN13"].Visible = false;
            }
            if (V14.Checked)
            {
                frmVan1.Series["VAN14"].Visible = true;
                frmVan1.Series["VAN14"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN14"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN14"].Visible = false;
            }
            if (V15.Checked)
            {
                frmVan1.Series["VAN15"].Visible = true;
                frmVan1.Series["VAN15"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN15"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN15"].Visible = false;
            }
            if (V16.Checked)
            {
                frmVan1.Series["VAN16"].Visible = true;
                frmVan1.Series["VAN16"].ArgumentScaleType = ScaleType.DateTime;
                frmVan1.Series["VAN16"].ValueScaleType = ScaleType.Numerical;
            }
            else
            {
                frmVan1.Series["VAN16"].Visible = false;
            }
            DateTimeScaleOptions dateTimeScaleOptions = diagram_Van1.AxisX.DateTimeScaleOptions;
            dateTimeScaleOptions.WorkdaysOnly = false;
            dateTimeScaleOptions.ScaleMode = ScaleMode.Automatic;
            dateTimeScaleOptions.AggregateFunction = AggregateFunction.Average;
            dateTimeScaleOptions.GridSpacing = 1;

        }

        private void tb_panel_v1_Paint(object sender, PaintEventArgs e)
        {

        }


        public static double[] Max = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static double[] Min = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static double[] Avg = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static double[] Total = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static double[] M3_min = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static double[] M3_max = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private void bt_Taidulieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmVan1.Series["VAN1"].Points.Clear();
            frmVan1.Series["VAN2"].Points.Clear();
            frmVan1.Series["VAN3"].Points.Clear();
            frmVan1.Series["VAN4"].Points.Clear();
            frmVan1.Series["VAN5"].Points.Clear();
            frmVan1.Series["VAN6"].Points.Clear();
            frmVan1.Series["VAN7"].Points.Clear();
            frmVan1.Series["VAN8"].Points.Clear();
            frmVan1.Series["VAN9"].Points.Clear();
            frmVan1.Series["VAN10"].Points.Clear();
            frmVan1.Series["VAN11"].Points.Clear();
            frmVan1.Series["VAN12"].Points.Clear();
            frmVan1.Series["VAN13"].Points.Clear();
            frmVan1.Series["VAN14"].Points.Clear();
            frmVan1.Series["VAN15"].Points.Clear();
            frmVan1.Series["VAN16"].Points.Clear();
            string sql = "select * from DATA_REAL where Thoigian between '" + Convert.ToDateTime(tungay.EditValue) + "' and '" + Convert.ToDateTime(denngay.EditValue) + "'  order by ID_real asc ";
            SQL_real = db_bieudo.ExecuteSQLDataTable(sql);
            if ((V1.Checked || V2.Checked || V3.Checked || V4.Checked || V5.Checked || V6.Checked || V7.Checked || V8.Checked || V9.Checked || V10.Checked || V11.Checked || V12.Checked || V13.Checked || V14.Checked || V15.Checked || V16.Checked) && SQL_real.Rows.Count > 0)
            {
                Dinh_dang1();

                for (int i = 0; i < SQL_real.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        Max[1] = Convert.ToDouble(SQL_real.Rows[i]["LL1"]);
                        Max[2] = Convert.ToDouble(SQL_real.Rows[i]["LL2"]);
                        Max[3] = Convert.ToDouble(SQL_real.Rows[i]["LL3"]);
                        Max[4] = Convert.ToDouble(SQL_real.Rows[i]["LL4"]);
                        Max[5] = Convert.ToDouble(SQL_real.Rows[i]["LL5"]);
                        Max[6] = Convert.ToDouble(SQL_real.Rows[i]["LL6"]);
                        Max[7] = Convert.ToDouble(SQL_real.Rows[i]["LL7"]);
                        Max[8] = Convert.ToDouble(SQL_real.Rows[i]["LL8"]);
                        Max[9] = Convert.ToDouble(SQL_real.Rows[i]["LL9"]);
                        Max[10] = Convert.ToDouble(SQL_real.Rows[i]["LL10"]);
                        Max[11] = Convert.ToDouble(SQL_real.Rows[i]["LL11"]);
                        Max[12] = Convert.ToDouble(SQL_real.Rows[i]["LL12"]);
                        Max[13] = Convert.ToDouble(SQL_real.Rows[i]["LL13"]);
                        Max[14] = Convert.ToDouble(SQL_real.Rows[i]["LL14"]);
                        Max[15] = Convert.ToDouble(SQL_real.Rows[i]["LL15"]);
                        Max[16] = Convert.ToDouble(SQL_real.Rows[i]["LL16"]);
                        Min[1] = Max[1];
                        Min[2] = Max[2];
                        Min[3] = Max[3];
                        Min[4] = Max[4];
                        Min[5] = Max[5];
                        Min[6] = Max[6];
                        Min[7] = Max[7];
                        Min[8] = Max[8];
                        Min[9] = Max[9];
                        Min[10] = Max[10];
                        Min[11] = Max[11];
                        Min[12] = Max[12];
                        Min[13] = Max[13];
                        Min[14] = Max[14];
                        Min[15] = Max[15];
                        Min[16] = Max[16];
                        Total[1] = 0;
                        Total[2] = 0;
                        Total[3] = 0;
                        Total[4] = 0;
                        Total[5] = 0;
                        Total[6] = 0;
                        Total[7] = 0;
                        Total[8] = 0;
                        Total[9] = 0;
                        Total[10] = 0;
                        Total[11] = 0;
                        Total[12] = 0;
                        Total[13] = 0;
                        Total[14] = 0;
                        Total[15] = 0;
                        Total[16] = 0;
                        M3_min[1] = Convert.ToDouble(SQL_real.Rows[i]["TT1"]);
                        M3_min[2] = Convert.ToDouble(SQL_real.Rows[i]["TT2"]);
                        M3_min[3] = Convert.ToDouble(SQL_real.Rows[i]["TT3"]);
                        M3_min[4] = Convert.ToDouble(SQL_real.Rows[i]["TT4"]);
                        M3_min[5] = Convert.ToDouble(SQL_real.Rows[i]["TT5"]);
                        M3_min[6] = Convert.ToDouble(SQL_real.Rows[i]["TT6"]);
                        M3_min[7] = Convert.ToDouble(SQL_real.Rows[i]["TT7"]);
                        M3_min[8] = Convert.ToDouble(SQL_real.Rows[i]["TT8"]);
                        M3_min[9] = Convert.ToDouble(SQL_real.Rows[i]["TT9"]);
                        M3_min[10] = Convert.ToDouble(SQL_real.Rows[i]["TT10"]);
                        M3_min[11] = Convert.ToDouble(SQL_real.Rows[i]["TT11"]);
                        M3_min[12] = Convert.ToDouble(SQL_real.Rows[i]["TT12"]);
                        M3_min[13] = Convert.ToDouble(SQL_real.Rows[i]["TT13"]);
                        M3_min[14] = Convert.ToDouble(SQL_real.Rows[i]["TT14"]);
                        M3_min[15] = Convert.ToDouble(SQL_real.Rows[i]["TT15"]);
                        M3_min[16] = Convert.ToDouble(SQL_real.Rows[i]["TT16"]);
                    }
                    if (i == SQL_real.Rows.Count - 1)
                    {
                        M3_max[1] = Convert.ToDouble(SQL_real.Rows[i]["TT1"]);
                        M3_max[2] = Convert.ToDouble(SQL_real.Rows[i]["TT2"]);
                        M3_max[3] = Convert.ToDouble(SQL_real.Rows[i]["TT3"]);
                        M3_max[4] = Convert.ToDouble(SQL_real.Rows[i]["TT4"]);
                        M3_max[5] = Convert.ToDouble(SQL_real.Rows[i]["TT5"]);
                        M3_max[6] = Convert.ToDouble(SQL_real.Rows[i]["TT6"]);
                        M3_max[7] = Convert.ToDouble(SQL_real.Rows[i]["TT7"]);
                        M3_max[8] = Convert.ToDouble(SQL_real.Rows[i]["TT8"]);
                        M3_max[9] = Convert.ToDouble(SQL_real.Rows[i]["TT9"]);
                        M3_max[10] = Convert.ToDouble(SQL_real.Rows[i]["TT10"]);
                        M3_max[11] = Convert.ToDouble(SQL_real.Rows[i]["TT11"]);
                        M3_max[12] = Convert.ToDouble(SQL_real.Rows[i]["TT12"]);
                        M3_max[13] = Convert.ToDouble(SQL_real.Rows[i]["TT13"]);
                        M3_max[14] = Convert.ToDouble(SQL_real.Rows[i]["TT14"]);
                        M3_max[15] = Convert.ToDouble(SQL_real.Rows[i]["TT15"]);
                        M3_max[16] = Convert.ToDouble(SQL_real.Rows[i]["TT16"]);
                    }
                    DateTime Time_chung = Convert.ToDateTime(SQL_real.Rows[i]["Thoigian"]);
                    if (V1.Checked)
                    {
                        frmVan1.Series["VAN1"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL1"])));
                        if (Max[1] < Convert.ToDouble(SQL_real.Rows[i]["LL1"]))
                        {
                            Max[1] = Convert.ToDouble(SQL_real.Rows[i]["LL1"]);
                        }
                        if (Min[1] > Convert.ToDouble(SQL_real.Rows[i]["LL1"]))
                        {
                            Min[1] = Convert.ToDouble(SQL_real.Rows[i]["LL1"]);
                        }
                        Total[1] = Total[1] + Convert.ToDouble(SQL_real.Rows[i]["LL1"]);
                    }
                    if (V2.Checked)
                    {
                        frmVan1.Series["VAN2"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL2"])));
                        if (Max[2] < Convert.ToDouble(SQL_real.Rows[i]["LL2"]))
                        {
                            Max[2] = Convert.ToDouble(SQL_real.Rows[i]["LL2"]);
                        }
                        if (Min[2] > Convert.ToDouble(SQL_real.Rows[i]["LL2"]))
                        {
                            Min[2] = Convert.ToDouble(SQL_real.Rows[i]["LL2"]);
                        }
                        Total[2] = Total[2] + Convert.ToDouble(SQL_real.Rows[i]["LL2"]);
                    }
                    if (V3.Checked)
                    {
                        frmVan1.Series["VAN3"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL3"])));
                        if (Max[3] < Convert.ToDouble(SQL_real.Rows[i]["LL3"]))
                        {
                            Max[3] = Convert.ToDouble(SQL_real.Rows[i]["LL3"]);
                        }
                        if (Min[3] > Convert.ToDouble(SQL_real.Rows[i]["LL3"]))
                        {
                            Min[3] = Convert.ToDouble(SQL_real.Rows[i]["LL3"]);
                        }
                        Total[3] = Total[3] + Convert.ToDouble(SQL_real.Rows[i]["LL3"]);
                    }
                    if (V4.Checked)
                    {
                        frmVan1.Series["VAN4"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL4"])));
                        if (Max[4] < Convert.ToDouble(SQL_real.Rows[i]["LL4"]))
                        {
                            Max[4] = Convert.ToDouble(SQL_real.Rows[i]["LL4"]);
                        }
                        if (Min[4] > Convert.ToDouble(SQL_real.Rows[i]["LL4"]))
                        {
                            Min[4] = Convert.ToDouble(SQL_real.Rows[i]["LL4"]);
                        }
                        Total[4] = Total[4] + Convert.ToDouble(SQL_real.Rows[i]["LL4"]);
                    }
                    if (V5.Checked)
                    {
                        frmVan1.Series["VAN5"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL5"])));
                        if (Max[5] < Convert.ToDouble(SQL_real.Rows[i]["LL5"]))
                        {
                            Max[5] = Convert.ToDouble(SQL_real.Rows[i]["LL5"]);
                        }
                        if (Min[5] > Convert.ToDouble(SQL_real.Rows[i]["LL5"]))
                        {
                            Min[5] = Convert.ToDouble(SQL_real.Rows[i]["LL5"]);
                        }
                        Total[5] = Total[5] + Convert.ToDouble(SQL_real.Rows[i]["LL5"]);
                    }
                    if (V6.Checked)
                    {
                        frmVan1.Series["VAN6"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL6"])));
                        if (Max[6] < Convert.ToDouble(SQL_real.Rows[i]["LL6"]))
                        {
                            Max[6] = Convert.ToDouble(SQL_real.Rows[i]["LL6"]);
                        }
                        if (Min[6] > Convert.ToDouble(SQL_real.Rows[i]["LL6"]))
                        {
                            Min[6] = Convert.ToDouble(SQL_real.Rows[i]["LL6"]);
                        }
                        Total[6] = Total[6] + Convert.ToDouble(SQL_real.Rows[i]["LL6"]);
                    }
                    if (V7.Checked)
                    {
                        frmVan1.Series["VAN7"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL7"])));
                        if (Max[7] < Convert.ToDouble(SQL_real.Rows[i]["LL7"]))
                        {
                            Max[7] = Convert.ToDouble(SQL_real.Rows[i]["LL7"]);
                        }
                        if (Min[7] > Convert.ToDouble(SQL_real.Rows[i]["LL7"]))
                        {
                            Min[7] = Convert.ToDouble(SQL_real.Rows[i]["LL7"]);
                        }
                        Total[7] = Total[7] + Convert.ToDouble(SQL_real.Rows[i]["LL7"]);
                    }
                    if (V8.Checked)
                    {
                        frmVan1.Series["VAN8"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL8"])));
                        if (Max[8] < Convert.ToDouble(SQL_real.Rows[i]["LL8"]))
                        {
                            Max[8] = Convert.ToDouble(SQL_real.Rows[i]["LL8"]);
                        }
                        if (Min[8] > Convert.ToDouble(SQL_real.Rows[i]["LL8"]))
                        {
                            Min[8] = Convert.ToDouble(SQL_real.Rows[i]["LL8"]);
                        }
                        Total[8] = Total[8] + Convert.ToDouble(SQL_real.Rows[i]["LL8"]);
                    }
                    if (V9.Checked)
                    {
                        frmVan1.Series["VAN9"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL9"])));
                        if (Max[9] < Convert.ToDouble(SQL_real.Rows[i]["LL9"]))
                        {
                            Max[9] = Convert.ToDouble(SQL_real.Rows[i]["LL9"]);
                        }
                        if (Min[9] > Convert.ToDouble(SQL_real.Rows[i]["LL9"]))
                        {
                            Min[9] = Convert.ToDouble(SQL_real.Rows[i]["LL9"]);
                        }
                        Total[9] = Total[9] + Convert.ToDouble(SQL_real.Rows[i]["LL9"]);
                    }
                    if (V10.Checked)
                    {
                        frmVan1.Series["VAN10"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL10"])));
                        if (Max[10] < Convert.ToDouble(SQL_real.Rows[i]["LL10"]))
                        {
                            Max[10] = Convert.ToDouble(SQL_real.Rows[i]["LL10"]);
                        }
                        if (Min[10] > Convert.ToDouble(SQL_real.Rows[i]["LL10"]))
                        {
                            Min[10] = Convert.ToDouble(SQL_real.Rows[i]["LL10"]);
                        }
                        Total[10] = Total[10] + Convert.ToDouble(SQL_real.Rows[i]["LL10"]);
                    }
                    if (V11.Checked)
                    {
                        frmVan1.Series["VAN11"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL11"])));
                        if (Max[10] < Convert.ToDouble(SQL_real.Rows[i]["LL11"]))
                        {
                            Max[10] = Convert.ToDouble(SQL_real.Rows[i]["LL11"]);
                        }
                        if (Min[10] > Convert.ToDouble(SQL_real.Rows[i]["LL11"]))
                        {
                            Min[10] = Convert.ToDouble(SQL_real.Rows[i]["LL11"]);
                        }
                        Total[11] = Total[11] + Convert.ToDouble(SQL_real.Rows[i]["LL11"]);
                    }
                    if (V12.Checked)
                    {
                        frmVan1.Series["VAN12"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL12"])));
                        if (Max[12] < Convert.ToDouble(SQL_real.Rows[i]["LL12"]))
                        {
                            Max[12] = Convert.ToDouble(SQL_real.Rows[i]["LL12"]);
                        }
                        if (Min[12] > Convert.ToDouble(SQL_real.Rows[i]["LL12"]))
                        {
                            Min[12] = Convert.ToDouble(SQL_real.Rows[i]["LL12"]);
                        }
                        Total[12] = Total[12] + Convert.ToDouble(SQL_real.Rows[i]["LL12"]);
                    }
                    if (V13.Checked)
                    {
                        frmVan1.Series["VAN13"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL13"])));
                        if (Max[13] < Convert.ToDouble(SQL_real.Rows[i]["LL13"]))
                        {
                            Max[13] = Convert.ToDouble(SQL_real.Rows[i]["LL13"]);
                        }
                        if (Min[13] > Convert.ToDouble(SQL_real.Rows[i]["LL13"]))
                        {
                            Min[13] = Convert.ToDouble(SQL_real.Rows[i]["LL13"]);
                        }
                        Total[13] = Total[13] + Convert.ToDouble(SQL_real.Rows[i]["LL13"]);
                    }
                    if (V14.Checked)
                    {
                        frmVan1.Series["VAN14"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL14"])));
                        if (Max[14] < Convert.ToDouble(SQL_real.Rows[i]["LL14"]))
                        {
                            Max[14] = Convert.ToDouble(SQL_real.Rows[i]["LL14"]);
                        }
                        if (Min[14] > Convert.ToDouble(SQL_real.Rows[i]["LL14"]))
                        {
                            Min[14] = Convert.ToDouble(SQL_real.Rows[i]["LL14"]);
                        }
                        Total[14] = Total[14] + Convert.ToDouble(SQL_real.Rows[i]["LL14"]);
                    }
                    if (V15.Checked)
                    {
                        frmVan1.Series["VAN15"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL15"])));
                        if (Max[15] < Convert.ToDouble(SQL_real.Rows[i]["LL15"]))
                        {
                            Max[15] = Convert.ToDouble(SQL_real.Rows[i]["LL15"]);
                        }
                        if (Min[15] > Convert.ToDouble(SQL_real.Rows[i]["LL15"]))
                        {
                            Min[15] = Convert.ToDouble(SQL_real.Rows[i]["LL15"]);
                        }
                        Total[15] = Total[15] + Convert.ToDouble(SQL_real.Rows[i]["LL15"]);
                    }
                    if (V16.Checked)
                    {
                        frmVan1.Series["VAN16"].Points.Add(new SeriesPoint(Time_chung, Convert.ToDouble(SQL_real.Rows[i]["LL16"])));
                        if (Max[16] < Convert.ToDouble(SQL_real.Rows[i]["LL16"]))
                        {
                            Max[16] = Convert.ToDouble(SQL_real.Rows[i]["LL16"]);
                        }
                        if (Min[16] > Convert.ToDouble(SQL_real.Rows[i]["LL16"]))
                        {
                            Min[16] = Convert.ToDouble(SQL_real.Rows[i]["LL16"]);
                        }
                        Total[16] = Total[16] + Convert.ToDouble(SQL_real.Rows[i]["LL16"]);
                    }
                }
                if (V1.Checked)
                {
                    Max1.Text = "Max: " + Math.Round(Max[1], 3);
                    Min1.Text = "Min: " + Math.Round(Min[1], 3);
                    Avg1.Text = "Avg: " + Math.Round(Total[1] / SQL_real.Rows.Count, 3);
                    m31.Text = "m3: " + Math.Round(M3_max[1] - M3_min[1], 1);
                }
                else
                {
                    Max1.Text = "Max: ---.---";
                    Min1.Text = "Min: ---.---";
                    Avg1.Text = "Avg: ---.---";
                    m31.Text = "m3: -----.-";
                }

                if (V2.Checked)
                {
                    Max2.Text = "Max: " + Math.Round(Max[2], 3);
                    Min2.Text = "Min: " + Math.Round(Min[2], 3);
                    Avg2.Text = "Avg: " + Math.Round(Total[2] / SQL_real.Rows.Count, 3);
                    m32.Text = "m3: " + Math.Round(M3_max[2] - M3_min[2], 1);
                }
                else
                {
                    Max2.Text = "Max: ---.---";
                    Min2.Text = "Min: ---.---";
                    Avg2.Text = "Avg: ---.---";
                    m32.Text = "m3: -----.-";
                }

                if (V3.Checked)
                {
                    Max3.Text = "Max: " + Math.Round(Max[3], 3);
                    Min3.Text = "Min: " + Math.Round(Min[3], 3);
                    Avg3.Text = "Avg: " + Math.Round(Total[3] / SQL_real.Rows.Count, 3);
                    m33.Text = "m3: " + Math.Round(M3_max[3] - M3_min[3], 1);
                }
                else
                {
                    Max3.Text = "Max: ---.---";
                    Min3.Text = "Min: ---.---";
                    Avg3.Text = "Avg: ---.---";
                    m33.Text = "m3: -----.-";
                }

                if (V4.Checked)
                {
                    Max4.Text = "Max: " + Math.Round(Max[4], 3);
                    Min4.Text = "Min: " + Math.Round(Min[4], 3);
                    Avg4.Text = "Avg: " + Math.Round(Total[4] / SQL_real.Rows.Count, 3);
                    m34.Text = "m3: " + Math.Round(M3_max[4] - M3_min[4], 1);
                }
                else
                {
                    Max4.Text = "Max: ---.---";
                    Min4.Text = "Min: ---.---";
                    Avg4.Text = "Avg: ---.---";
                    m34.Text = "m3: -----.-";
                }

                if (V5.Checked)
                {
                    Max5.Text = "Max: " + Math.Round(Max[5], 3);
                    Min5.Text = "Min: " + Math.Round(Min[5], 3);
                    Avg5.Text = "Avg: " + Math.Round(Total[5] / SQL_real.Rows.Count, 3);
                    m35.Text = "m3: " + Math.Round(M3_max[5] - M3_min[5], 1);
                }
                else
                {
                    Max5.Text = "Max: ---.---";
                    Min5.Text = "Min: ---.---";
                    Avg5.Text = "Avg: ---.---";
                    m35.Text = "m3: -----.-";
                }

                if (V6.Checked)
                {
                    Max6.Text = "Max: " + Math.Round(Max[6], 3);
                    Min6.Text = "Min: " + Math.Round(Min[6], 3);
                    Avg6.Text = "Avg: " + Math.Round(Total[6] / SQL_real.Rows.Count, 3);
                    m36.Text = "m3: " + Math.Round(M3_max[6] - M3_min[6], 1);
                }
                else
                {
                    Max6.Text = "Max: ---.---";
                    Min6.Text = "Min: ---.---";
                    Avg6.Text = "Avg: ---.---";
                    m36.Text = "m3: -----.-";
                }
                if (V7.Checked)
                {
                    Max7.Text = "Max: " + Math.Round(Max[7], 3);
                    Min7.Text = "Min: " + Math.Round(Min[7], 3);
                    Avg7.Text = "Avg: " + Math.Round(Total[7] / SQL_real.Rows.Count, 3);
                    m37.Text = "m3: " + Math.Round(M3_max[7] - M3_min[7], 1);
                }
                else
                {
                    Max7.Text = "Max: ---.---";
                    Min7.Text = "Min: ---.---";
                    Avg7.Text = "Avg: ---.---";
                    m37.Text = "m3: -----.-";
                }
                if (V8.Checked)
                {
                    Max8.Text = "Max: " + Math.Round(Max[8], 3);
                    Min8.Text = "Min: " + Math.Round(Min[8], 3);
                    Avg8.Text = "Avg: " + Math.Round(Total[8] / SQL_real.Rows.Count, 3);
                    m38.Text = "m3: " + Math.Round(M3_max[8] - M3_min[8], 1);
                }
                else
                {
                    Max8.Text = "Max: ---.---";
                    Min8.Text = "Min: ---.---";
                    Avg8.Text = "Avg: ---.---";
                    m38.Text = "m3: -----.-";
                }
                if (V9.Checked)
                {
                    Max9.Text = "Max: " + Math.Round(Max[9], 3);
                    Min9.Text = "Min: " + Math.Round(Min[9], 3);
                    Avg9.Text = "Avg: " + Math.Round(Total[9] / SQL_real.Rows.Count, 3);
                    m39.Text = "m3: " + Math.Round(M3_max[9] - M3_min[9], 1);
                }
                else
                {
                    Max9.Text = "Max: ---.---";
                    Min9.Text = "Min: ---.---";
                    Avg9.Text = "Avg: ---.---";
                    m39.Text = "m3: -----.-";
                }
                if (V10.Checked)
                {
                    Max10.Text = "Max: " + Math.Round(Max[10], 3);
                    Min10.Text = "Min: " + Math.Round(Min[10], 3);
                    Avg10.Text = "Avg: " + Math.Round(Total[10] / SQL_real.Rows.Count, 3);
                    m310.Text = "m3: " + Math.Round(M3_max[10] - M3_min[10], 1);
                }
                else
                {
                    Max10.Text = "Max: ---.---";
                    Min10.Text = "Min: ---.---";
                    Avg10.Text = "Avg: ---.---";
                    m310.Text = "m3: -----.-";
                }
                if (V11.Checked)
                {
                    Max11.Text = "Max: " + Math.Round(Max[11], 3);
                    Min11.Text = "Min: " + Math.Round(Min[11], 3);
                    Avg11.Text = "Avg: " + Math.Round(Total[11] / SQL_real.Rows.Count, 3);
                    m311.Text = "m3: " + Math.Round(M3_max[11] - M3_min[11], 1);
                }
                else
                {
                    Max11.Text = "Max: ---.---";
                    Min11.Text = "Min: ---.---";
                    Avg11.Text = "Avg: ---.---";
                    m311.Text = "m3: -----.-";
                }
                if (V12.Checked)
                {
                    Max12.Text = "Max: " + Math.Round(Max[12], 3);
                    Min12.Text = "Min: " + Math.Round(Min[12], 3);
                    Avg12.Text = "Avg: " + Math.Round(Total[12] / SQL_real.Rows.Count, 3);
                    m312.Text = "m3: " + Math.Round(M3_max[12] - M3_min[12], 1);
                }
                else
                {
                    Max12.Text = "Max: ---.---";
                    Min12.Text = "Min: ---.---";
                    Avg12.Text = "Avg: ---.---";
                    m312.Text = "m3: -----.-";
                }
                if (V13.Checked)
                {
                    Max13.Text = "Max: " + Math.Round(Max[13], 3);
                    Min13.Text = "Min: " + Math.Round(Min[13], 3);
                    Avg13.Text = "Avg: " + Math.Round(Total[13] / SQL_real.Rows.Count, 3);
                    m313.Text = "m3: " + Math.Round(M3_max[13] - M3_min[13], 1);
                }
                else
                {
                    Max13.Text = "Max: ---.---";
                    Min13.Text = "Min: ---.---";
                    Avg13.Text = "Avg: ---.---";
                    m313.Text = "m3: -----.-";
                }
                if (V14.Checked)
                {
                    Max14.Text = "Max: " + Math.Round(Max[14], 3);
                    Min14.Text = "Min: " + Math.Round(Min[14], 3);
                    Avg14.Text = "Avg: " + Math.Round(Total[14] / SQL_real.Rows.Count, 3);
                    m314.Text = "m3: " + Math.Round(M3_max[14] - M3_min[14], 1);
                }
                else
                {
                    Max14.Text = "Max: ---.---";
                    Min14.Text = "Min: ---.---";
                    Avg14.Text = "Avg: ---.---";
                    m314.Text = "m3: -----.-";
                }
                if (V15.Checked)
                {
                    Max15.Text = "Max: " + Math.Round(Max[15], 3);
                    Min15.Text = "Min: " + Math.Round(Min[15], 3);
                    Avg15.Text = "Avg: " + Math.Round(Total[15] / SQL_real.Rows.Count, 3);
                    m315.Text = "m3: " + Math.Round(M3_max[15] - M3_min[15], 1);
                }
                else
                {
                    Max15.Text = "Max: ---.---";
                    Min15.Text = "Min: ---.---";
                    Avg15.Text = "Avg: ---.---";
                    m315.Text = "m3: -----.-";
                }
                if (V16.Checked)
                {
                    Max16.Text = "Max: " + Math.Round(Max[16], 3);
                    Min16.Text = "Min: " + Math.Round(Min[16], 3);
                    Avg16.Text = "Avg: " + Math.Round(Total[16] / SQL_real.Rows.Count, 3);
                    m316.Text = "m3: " + Math.Round(M3_max[16] - M3_min[16], 1);
                }
                else
                {
                    Max16.Text = "Max: ---.---";
                    Min16.Text = "Min: ---.---";
                    Avg16.Text = "Avg: ---.---";
                    m316.Text = "m3: -----.-";
                }
            }
            else
            {
                KN.Showalert("Chưa chọn biểu đồ hoặc không có dữ liệu");
            }

        }

        private void Bieudo_Load(object sender, EventArgs e)
        {
            tungay.EditValue = DateTime.Now.Date;
            denngay.EditValue = DateTime.Now.Date.AddDays(1);
            V1.Checked = true;
            V2.Checked = true;
            V3.Checked = true;
            V4.Checked = true;
            V5.Checked = true;
            V6.Checked = true;
            V7.Checked = true;
            V8.Checked = true;
            V9.Checked = true;
            V10.Checked = true;
            V11.Checked = true;
            V12.Checked = true;
            V13.Checked = true;
            V14.Checked = true;
            V15.Checked = true;
            V16.Checked = true;
            Dinh_dang1();
        }

        private void V1_CheckedChanged(object sender, EventArgs e)
        {
            if (V1.Checked)
            {
                V1.BackColor = Color.LimeGreen;
            }
            else
            {
                V1.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V2_CheckedChanged(object sender, EventArgs e)
        {
            if (V2.Checked)
            {
                V2.BackColor = Color.LimeGreen;
            }
            else
            {
                V2.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V3_CheckedChanged(object sender, EventArgs e)
        {
            if (V3.Checked)
            {
                V3.BackColor = Color.LimeGreen;
            }
            else
            {
                V3.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V4_CheckedChanged(object sender, EventArgs e)
        {
            if (V4.Checked)
            {
                V4.BackColor = Color.LimeGreen;
            }
            else
            {
                V4.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V5_CheckedChanged(object sender, EventArgs e)
        {
            if (V5.Checked)
            {
                V5.BackColor = Color.LimeGreen;
            }
            else
            {
                V5.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V6_CheckedChanged(object sender, EventArgs e)
        {
            if (V6.Checked)
            {
                V6.BackColor = Color.LimeGreen;
            }
            else
            {
                V6.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V7_CheckedChanged(object sender, EventArgs e)
        {
            if (V7.Checked)
            {
                V7.BackColor = Color.LimeGreen;
            }
            else
            {
                V7.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V8_CheckedChanged(object sender, EventArgs e)
        {
            if (V8.Checked)
            {
                V8.BackColor = Color.LimeGreen;
            }
            else
            {
                V8.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V9_CheckedChanged(object sender, EventArgs e)
        {
            if (V9.Checked)
            {
                V9.BackColor = Color.LimeGreen;
            }
            else
            {
                V9.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V10_CheckedChanged(object sender, EventArgs e)
        {
            if (V10.Checked)
            {
                V10.BackColor = Color.LimeGreen;
            }
            else
            {
                V10.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V11_CheckedChanged(object sender, EventArgs e)
        {
            if (V11.Checked)
            {
                V11.BackColor = Color.LimeGreen;
            }
            else
            {
                V11.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V12_CheckedChanged(object sender, EventArgs e)
        {
            if (V12.Checked)
            {
                V12.BackColor = Color.LimeGreen;
            }
            else
            {
                V12.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V13_CheckedChanged(object sender, EventArgs e)
        {
            if (V13.Checked)
            {
                V13.BackColor = Color.LimeGreen;
            }
            else
            {
                V13.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V14_CheckedChanged(object sender, EventArgs e)
        {
            if (V14.Checked)
            {
                V14.BackColor = Color.LimeGreen;
            }
            else
            {
                V14.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V15_CheckedChanged(object sender, EventArgs e)
        {
            if (V15.Checked)
            {
                V15.BackColor = Color.LimeGreen;
            }
            else
            {
                V15.BackColor = Color.FromArgb(255, 255, 192);
            }
        }

        private void V16_CheckedChanged(object sender, EventArgs e)
        {
            if (V16.Checked)
            {
                V16.BackColor = Color.LimeGreen;
            }
            else
            {
                V16.BackColor = Color.FromArgb(255, 255, 192);
            }
        }
    }
}