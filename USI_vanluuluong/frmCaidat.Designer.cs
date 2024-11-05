namespace USI_vanluuluong
{
    partial class frmCaidat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.TBA1 = new DevExpress.XtraBars.BarButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.id_read = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bt_Luu = new System.Windows.Forms.Button();
            this.txt_IPPLC = new DevExpress.XtraEditors.TextEdit();
            this.laPLC = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_PLC = new System.Windows.Forms.Button();
            this.PLC_READ = new System.Windows.Forms.Timer(this.components);
            this.id_length = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.write_return = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_read.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_IPPLC.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id_length.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.write_return.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.TBA1});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1358, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 728);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1358, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 728);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1358, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 728);
            // 
            // TBA1
            // 
            this.TBA1.Caption = "TBA1";
            this.TBA1.Id = 0;
            this.TBA1.Name = "TBA1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1358, 728);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.write_return);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.id_length);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.id_read);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.bt_Luu);
            this.panel1.Controls.Add(this.txt_IPPLC);
            this.panel1.Controls.Add(this.laPLC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(507, 267);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 244);
            this.panel1.TabIndex = 24;
            // 
            // id_read
            // 
            this.id_read.EditValue = "0";
            this.id_read.Location = new System.Drawing.Point(122, 57);
            this.id_read.Name = "id_read";
            this.id_read.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_read.Properties.Appearance.Options.UseFont = true;
            this.id_read.Properties.Appearance.Options.UseTextOptions = true;
            this.id_read.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.id_read.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.id_read.Properties.AutoHeight = false;
            this.id_read.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.id_read.Size = new System.Drawing.Size(181, 28);
            this.id_read.TabIndex = 27;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.Location = new System.Drawing.Point(36, 57);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(1);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 28);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "ID_10";
            // 
            // bt_Luu
            // 
            this.bt_Luu.BackColor = System.Drawing.Color.LawnGreen;
            this.bt_Luu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Luu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Luu.Location = new System.Drawing.Point(206, 191);
            this.bt_Luu.Name = "bt_Luu";
            this.bt_Luu.Size = new System.Drawing.Size(96, 35);
            this.bt_Luu.TabIndex = 25;
            this.bt_Luu.Text = "Lưu";
            this.bt_Luu.UseVisualStyleBackColor = false;
            this.bt_Luu.Click += new System.EventHandler(this.bt_Luu_Click);
            // 
            // txt_IPPLC
            // 
            this.txt_IPPLC.Location = new System.Drawing.Point(121, 12);
            this.txt_IPPLC.Name = "txt_IPPLC";
            this.txt_IPPLC.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IPPLC.Properties.Appearance.Options.UseFont = true;
            this.txt_IPPLC.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_IPPLC.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_IPPLC.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txt_IPPLC.Properties.AutoHeight = false;
            this.txt_IPPLC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txt_IPPLC.Size = new System.Drawing.Size(181, 28);
            this.txt_IPPLC.TabIndex = 24;
            // 
            // laPLC
            // 
            this.laPLC.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.laPLC.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laPLC.Appearance.ForeColor = System.Drawing.Color.White;
            this.laPLC.Appearance.Options.UseBackColor = true;
            this.laPLC.Appearance.Options.UseFont = true;
            this.laPLC.Appearance.Options.UseForeColor = true;
            this.laPLC.Appearance.Options.UseTextOptions = true;
            this.laPLC.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.laPLC.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.laPLC.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.laPLC.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.laPLC.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.laPLC.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.laPLC.Location = new System.Drawing.Point(35, 12);
            this.laPLC.Margin = new System.Windows.Forms.Padding(1);
            this.laPLC.Name = "laPLC";
            this.laPLC.Size = new System.Drawing.Size(76, 28);
            this.laPLC.TabIndex = 22;
            this.laPLC.Text = "PLC";
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 3);
            this.panel2.Controls.Add(this.lb_PLC);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1352, 44);
            this.panel2.TabIndex = 1;
            // 
            // lb_PLC
            // 
            this.lb_PLC.BackColor = System.Drawing.Color.Red;
            this.lb_PLC.FlatAppearance.BorderSize = 0;
            this.lb_PLC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.lb_PLC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.lb_PLC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_PLC.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_PLC.ForeColor = System.Drawing.Color.White;
            this.lb_PLC.Image = global::USI_vanluuluong.Properties.Resources.calendar_24px;
            this.lb_PLC.Location = new System.Drawing.Point(5, 1);
            this.lb_PLC.Margin = new System.Windows.Forms.Padding(0);
            this.lb_PLC.Name = "lb_PLC";
            this.lb_PLC.Size = new System.Drawing.Size(119, 36);
            this.lb_PLC.TabIndex = 11;
            this.lb_PLC.Text = "  PLC";
            this.lb_PLC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.lb_PLC.UseVisualStyleBackColor = false;
            // 
            // PLC_READ
            // 
            this.PLC_READ.Enabled = true;
            this.PLC_READ.Interval = 2000;
            // 
            // id_length
            // 
            this.id_length.EditValue = "0";
            this.id_length.Location = new System.Drawing.Point(122, 104);
            this.id_length.Name = "id_length";
            this.id_length.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id_length.Properties.Appearance.Options.UseFont = true;
            this.id_length.Properties.Appearance.Options.UseTextOptions = true;
            this.id_length.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.id_length.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.id_length.Properties.AutoHeight = false;
            this.id_length.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.id_length.Size = new System.Drawing.Size(181, 28);
            this.id_length.TabIndex = 29;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl2.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl2.Location = new System.Drawing.Point(36, 104);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(1);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(76, 28);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "Length";
            // 
            // write_return
            // 
            this.write_return.EditValue = "0";
            this.write_return.Location = new System.Drawing.Point(122, 151);
            this.write_return.Name = "write_return";
            this.write_return.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.write_return.Properties.Appearance.Options.UseFont = true;
            this.write_return.Properties.Appearance.Options.UseTextOptions = true;
            this.write_return.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.write_return.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.write_return.Properties.AutoHeight = false;
            this.write_return.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.write_return.Size = new System.Drawing.Size(181, 28);
            this.write_return.TabIndex = 31;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl3.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl3.Location = new System.Drawing.Point(36, 151);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(1);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 28);
            this.labelControl3.TabIndex = 30;
            this.labelControl3.Text = "Return";
            // 
            // frmCaidat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 728);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmCaidat";
            this.Text = "frmCaidat";
            this.Load += new System.EventHandler(this.frmCaidat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.id_read.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_IPPLC.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.id_length.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.write_return.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem TBA1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer PLC_READ;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button lb_PLC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_Luu;
        private DevExpress.XtraEditors.TextEdit txt_IPPLC;
        private DevExpress.XtraEditors.LabelControl laPLC;
        private DevExpress.XtraEditors.TextEdit id_read;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit id_length;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit write_return;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}