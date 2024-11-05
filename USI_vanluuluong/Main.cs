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
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();
        }
        public static SqlHelper db_main = new SqlHelper(KN.Chuoi);

        public static DataTable PLC_SQL;
        int k = 0;
        int min_now = DateTime.Now.Minute;
        int min_old = DateTime.Now.AddMinutes(-1).Minute;
        DateTime DT_dothi = DateTime.Now;
        private void Timer_update_Tick(object sender, EventArgs e)
        {
            DT_dothi = DateTime.Now;
            min_now = DateTime.Now.Minute;
            k++;
            try
            {
                lb_llv1.Text = Data.llv1.ToString();
                lb_llv2.Text = Data.llv2.ToString();
                lb_llv3.Text = Data.llv3.ToString();
                lb_llv4.Text = Data.llv4.ToString();
                lb_llv5.Text = Data.llv5.ToString();
                lb_llv6.Text = Data.llv6.ToString();
                lb_llv7.Text = Data.llv3.ToString();
                lb_llv8.Text = Data.llv4.ToString();
                lb_llv9.Text = Data.llv5.ToString();
                lb_llv10.Text = Data.llv6.ToString();


                lb_llv11.Text = Data.llv11.ToString(); // New for van 11
                lb_llv12.Text = Data.llv12.ToString(); // New for van 12
                lb_llv13.Text = Data.llv13.ToString(); // New for van 13
                lb_llv14.Text = Data.llv14.ToString(); // New for van 14
                lb_llv15.Text = Data.llv15.ToString(); // New for van 15
                lb_llv16.Text = Data.llv16.ToString(); // New for van 16


                lb_ttv1.Text = Data.ttv1.ToString();
                lb_ttv2.Text = Data.ttv2.ToString();
                lb_ttv3.Text = Data.ttv3.ToString();
                lb_ttv4.Text = Data.ttv4.ToString();
                lb_ttv5.Text = Data.ttv5.ToString();
                lb_ttv6.Text = Data.ttv6.ToString();
                lb_ttv7.Text = Data.ttv3.ToString();
                lb_ttv8.Text = Data.ttv4.ToString();
                lb_ttv9.Text = Data.ttv5.ToString();
                lb_ttv10.Text = Data.ttv6.ToString();



                lb_ttv11.Text = Data.ttv11.ToString(); // New for van 11
                lb_ttv12.Text = Data.ttv12.ToString(); // New for van 12
                lb_ttv13.Text = Data.ttv13.ToString(); // New for van 13
                lb_ttv14.Text = Data.ttv14.ToString(); // New for van 14
                lb_ttv15.Text = Data.ttv15.ToString(); // New for van 15
                lb_ttv16.Text = Data.ttv16.ToString(); // New for van 16


                // Set background color based on flow rates
                SetBackgroundColorForFlowRates();

                Dinh_dang1();

                // Update chart data
                UpdateChartData();

                min_old = min_now;

            }
            catch (Exception ex)
            {
                KN.Showalert(ex.Message);
            }
        }
        private void SetBackgroundColorForFlowRates()
        {
            for (int i = 1; i <= 16; i++)
            {
                var flowRate = (double)typeof(Data).GetField($"llv{i}").GetValue(null);
                var label = (LabelControl)Controls.Find($"lb_llv{i}", true).FirstOrDefault();
                if (label != null)
                {
                    label.BackColor = flowRate > 0 ? Color.LimeGreen : Color.White;
                }
            }
        }
        private void UpdateChartData()
        {
            if (frmVan1.Series["VAN1"].Points.Count < 30 || (frmVan1.Series["VAN1"].Points.Count >= 30 && min_now != min_old))
            {
                frmVan1.Series["VAN1"].Points.Add(new SeriesPoint(DT_dothi, Data.llv1));
            }

            if (frmVan1.Series["VAN1"].Points.Count > 30)
            {
                frmVan1.Series["VAN1"].Points.RemoveAt(0);
            }

            // Repeat for all other valves
            for (int i = 2; i <= 16; i++)
            {
                var series = frmVan1.Series[$"VAN{i}"];
                if (series != null)
                {
                    if (series.Points.Count < 30 || (series.Points.Count >= 30 && min_now != min_old))
                    {
                        series.Points.Add(new SeriesPoint(DT_dothi, (double)typeof(Data).GetField($"llv{i}").GetValue(null)));
                    }
                    if (series.Points.Count > 30)
                    {
                        series.Points.RemoveAt(0);
                    }
                }
                else
                {
                    // Xử lý khi series bị null (tùy vào cách bạn muốn xử lý)
                    Console.WriteLine($"Series VAN{i} không tồn tại.");
                }
            }

        }
        private void Dinh_dang1()
        {
            if (frmVan1?.Diagram is XYDiagram diagram_Van1)
            {
                diagram_Van1.AxisX.Label.TextPattern = "{A:hh:mm}";

                for (int i = 1; i <= 16; i++)
                {
                    var series = frmVan1.Series[$"VAN{i}"];
                    if (series != null)
                    {
                        series.ArgumentScaleType = ScaleType.DateTime;
                        series.ValueScaleType = ScaleType.Numerical;
                    }
                    else
                    {
                        // Xử lý trường hợp series bị null
                        Console.WriteLine($"Series VAN{i} bị null.");
                    }
                }

                DateTimeScaleOptions dateTimeScaleOptions = diagram_Van1.AxisX.DateTimeScaleOptions;
                dateTimeScaleOptions.WorkdaysOnly = false;
                dateTimeScaleOptions.ScaleMode = ScaleMode.Automatic;
                dateTimeScaleOptions.AggregateFunction = AggregateFunction.Average;
                dateTimeScaleOptions.GridSpacing = 1;
            }
            else
            {
                // Xử lý trường hợp Diagram bị null
                Console.WriteLine("frmVan1.Diagram bị null.");
            }
        }


    }
}