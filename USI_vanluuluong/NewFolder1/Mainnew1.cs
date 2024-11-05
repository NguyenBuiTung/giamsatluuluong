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
    public partial class Mainnew1 : DevExpress.XtraEditors.XtraForm
    {
        public Mainnew1()
        {
            InitializeComponent();
        }

        private void Mainnew_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void timer1_refresh_Tick(object sender, EventArgs e)
        {
            lb_llv1.Text = Data.llv1.ToString();
            lb_llv2.Text = Data.llv2.ToString();
            lb_llv3.Text = Data.llv3.ToString();
            lb_llv4.Text = Data.llv4.ToString();
            lb_llv5.Text = Data.llv5.ToString();
            lb_llv6.Text = Data.llv6.ToString();

            lb_ttv1.Text = Data.ttv1.ToString();
            lb_ttv2.Text = Data.ttv2.ToString();
            lb_ttv3.Text = Data.ttv3.ToString();
            lb_ttv4.Text = Data.ttv4.ToString();
            lb_ttv5.Text = Data.ttv5.ToString();
            lb_ttv6.Text = Data.ttv6.ToString();

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

            if (Data.llvT > 0)
            {
                lb_llvT.BackColor = Color.LimeGreen;
            }
            else
            {
                lb_llvT.BackColor = Color.White;
            }

        }
    }
}