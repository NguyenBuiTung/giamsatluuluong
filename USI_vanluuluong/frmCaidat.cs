using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Threading;
using S7.Net;
using DevExpress.XtraEditors;

namespace USI_vanluuluong
{
    public partial class frmCaidat : DevExpress.XtraEditors.XtraForm
    {
        public frmCaidat()
        {
            InitializeComponent();
        }


        private void frmCaidat_Load(object sender, EventArgs e)
        {
            txt_IPPLC.Text = USI_vanluuluong.Properties.Settings.Default.PLCip;
        }

        private void bt_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                USI_vanluuluong.Properties.Settings.Default.PLCip = txt_IPPLC.Text;
                USI_vanluuluong.Properties.Settings.Default.Save();
                DATA_PLC.write_data = Convert.ToInt32(id_read.Text);
                DATA_PLC.write_length = Convert.ToInt16(id_length.Text);
                DATA_PLC.write_return = Convert.ToInt16(write_return.Text);
                DATA_PLC.plc_write = true;
            }
            catch
            {
                id_read.Text = "0";
                id_length.Text = "0";
            }

        }
    }
}