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

namespace USI_vanluuluong
{
    public partial class Mainnew : DevExpress.XtraEditors.XtraForm
    {
        public Mainnew()
        {
            InitializeComponent();
        }

        private void timer1_refresh_Tick(object sender, EventArgs e)
        {
            lb_llv1.Text = Data.llv1.ToString();
            lb_llv2.Text = Data.llv2.ToString();
            lb_llv3.Text = Data.llv3.ToString();
            lb_llv4.Text = Data.llv4.ToString();
            lb_llv5.Text = Data.llv5.ToString();
            lb_llv6.Text = Data.llv6.ToString();
            lb_llv7.Text = Data.llv7.ToString();
            lb_llv8.Text = Data.llv8.ToString();
            lb_llv9.Text = Data.llv9.ToString();
            lb_llv10.Text = Data.llv10.ToString();

            lb_llv11.Text = Data.llv11.ToString();  // Thêm van 11
            lb_llv12.Text = Data.llv12.ToString();  // Thêm van 12
            lb_llv13.Text = Data.llv13.ToString();  // Thêm van 13
            lb_llv14.Text = Data.llv14.ToString();  // Thêm van 14
            lb_llv15.Text = Data.llv15.ToString();  // Thêm van 15
            lb_llv16.Text = Data.llv16.ToString();  // Thêm van 16


            lb_ttv1.Text = Data.ttv1.ToString();
            lb_ttv2.Text = Data.ttv2.ToString();
            lb_ttv3.Text = Data.ttv3.ToString();
            lb_ttv4.Text = Data.ttv4.ToString();
            lb_ttv5.Text = Data.ttv5.ToString();
            lb_ttv6.Text = Data.ttv6.ToString();
            lb_ttv7.Text = Data.ttv7.ToString();
            lb_ttv8.Text = Data.ttv8.ToString();
            lb_ttv9.Text = Data.ttv9.ToString();
            lb_ttv10.Text = Data.ttv10.ToString();

            lb_ttv11.Text = Data.ttv11.ToString();  // Thêm ttv 11
            lb_ttv12.Text = Data.ttv12.ToString();  // Thêm ttv 12
            lb_ttv13.Text = Data.ttv13.ToString();  // Thêm ttv 13
            lb_ttv14.Text = Data.ttv14.ToString();  // Thêm ttv 14
            lb_ttv15.Text = Data.ttv15.ToString();  // Thêm ttv 15
            lb_ttv16.Text = Data.ttv16.ToString();  // Thêm ttv 16

            lb_llvT.Text = Data.llvT.ToString();
            lb_ttvT.Text = Data.ttvT.ToString();



            if (Data.llv1 > 0)
            {
                lb_llv1.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv1.BackColor = Color.White;
            }

            if (Data.llv2 > 0)
            {
                lb_llv2.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv2.BackColor = Color.White;
            }

            if (Data.llv3 > 0)
            {
                lb_llv3.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv3.BackColor = Color.White;
            }

            if (Data.llv4 > 0)
            {
                lb_llv4.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv4.BackColor = Color.White;
            }

            if (Data.llv5 > 0)
            {
                lb_llv5.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv5.BackColor = Color.White;
            }

            if (Data.llv6 > 0)
            {
                lb_llv6.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv6.BackColor = Color.White;
            }

            if (Data.llv7 > 0)
            {
                lb_llv7.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv7.BackColor = Color.White;
            }

            if (Data.llv8 > 0)
            {
                lb_llv8.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv8.BackColor = Color.White;
            }

            if (Data.llv9 > 0)
            {
                lb_llv9.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv9.BackColor = Color.White;
            }

            if (Data.llv10 > 0)
            {
                lb_llv10.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv10.BackColor = Color.White;
            }
            if (Data.llv11 > 0)
            {
                lb_llv11.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv11.BackColor = Color.White;
            }
            if (Data.llv12 > 0)
            {
                lb_llv12.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv12.BackColor = Color.White;
            }
            if (Data.llv13 > 0)
            {
                lb_llv13.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv13.BackColor = Color.White;
            }
            if (Data.llv14 > 0)
            {
                lb_llv14.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv14.BackColor = Color.White;
            }
            if (Data.llv15 > 0)
            {
                lb_llv15.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv15.BackColor = Color.White;
            }
            if (Data.llv16 > 0)
            {
                lb_llv16.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llv16.BackColor = Color.White;
            }
            if (Data.llvT > 0)
            {
                lb_llvT.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llvT.BackColor = Color.White;
            }
        }

        //private void label10_Click(object sender, EventArgs e)
        //{

        //}
    }
}