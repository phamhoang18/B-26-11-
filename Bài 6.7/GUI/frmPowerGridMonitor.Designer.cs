namespace GUI
{
    partial class frmPowerGridMonitor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Label lblSelectStation;
        private System.Windows.Forms.ComboBox cboSubstations;
        private System.Windows.Forms.Button btnStartScada;
        private System.Windows.Forms.Button btnStopScada;
        private System.Windows.Forms.GroupBox grpDashboard;
        private System.Windows.Forms.Label lblVoltageTitle;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Label lblLoadTitle;
        private System.Windows.Forms.Label lblLoadPercent;
        private System.Windows.Forms.Label lblWarningBanner;
        private System.Windows.Forms.GroupBox grpLogs;
        private System.Windows.Forms.DataGridView dgvGridLogs;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionState;
        private System.Windows.Forms.ToolStripStatusLabel lblLastPacketTime;
        private System.Windows.Forms.ToolStripStatusLabel lblCycleCounter;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.lblSelectStation = new System.Windows.Forms.Label();
            this.cboSubstations = new System.Windows.Forms.ComboBox();
            this.btnStartScada = new System.Windows.Forms.Button();
            this.btnStopScada = new System.Windows.Forms.Button();
            this.grpDashboard = new System.Windows.Forms.GroupBox();
            this.lblVoltageTitle = new System.Windows.Forms.Label();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.lblLoadTitle = new System.Windows.Forms.Label();
            this.lblLoadPercent = new System.Windows.Forms.Label();
            this.lblWarningBanner = new System.Windows.Forms.Label();
            this.grpLogs = new System.Windows.Forms.GroupBox();
            this.dgvGridLogs = new System.Windows.Forms.DataGridView();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lblConnectionState = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLastPacketTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCycleCounter = new System.Windows.Forms.ToolStripStatusLabel();

            this.grpControl.SuspendLayout();
            this.grpDashboard.SuspendLayout();
            this.grpLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGridLogs)).BeginInit();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();

            this.grpControl.Controls.Add(this.btnStopScada);
            this.grpControl.Controls.Add(this.btnStartScada);
            this.grpControl.Controls.Add(this.cboSubstations);
            this.grpControl.Controls.Add(this.lblSelectStation);
            this.grpControl.Location = new System.Drawing.Point(15, 12);
            this.grpControl.Size = new System.Drawing.Size(850, 75);
            this.grpControl.Text = "Điều khiển Kết nối SCADA";

            this.lblSelectStation.AutoSize = true;
            this.lblSelectStation.Location = new System.Drawing.Point(15, 33);
            this.lblSelectStation.Text = "Chọn Trạm biến áp:";

            this.cboSubstations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubstations.Location = new System.Drawing.Point(145, 29);
            this.cboSubstations.Size = new System.Drawing.Size(270, 24);

            this.btnStartScada.BackColor = System.Drawing.Color.SeaGreen;
            this.btnStartScada.ForeColor = System.Drawing.Color.White;
            this.btnStartScada.Location = new System.Drawing.Point(435, 25);
            this.btnStartScada.Size = new System.Drawing.Size(210, 32);
            this.btnStartScada.Text = "Bắt đầu Giám sát SCADA";
            this.btnStartScada.UseVisualStyleBackColor = false;
            this.btnStartScada.Click += new System.EventHandler(this.btnStartScada_Click);

            this.btnStopScada.BackColor = System.Drawing.Color.Firebrick;
            this.btnStopScada.Enabled = false;
            this.btnStopScada.ForeColor = System.Drawing.Color.White;
            this.btnStopScada.Location = new System.Drawing.Point(660, 25);
            this.btnStopScada.Size = new System.Drawing.Size(170, 32);
            this.btnStopScada.Text = "Ngắt Kết nối";
            this.btnStopScada.UseVisualStyleBackColor = false;
            this.btnStopScada.Click += new System.EventHandler(this.btnStopScada_Click);

            this.grpDashboard.Controls.Add(this.lblWarningBanner);
            this.grpDashboard.Controls.Add(this.lblLoadPercent);
            this.grpDashboard.Controls.Add(this.lblLoadTitle);
            this.grpDashboard.Controls.Add(this.lblVoltage);
            this.grpDashboard.Controls.Add(this.lblVoltageTitle);
            this.grpDashboard.Location = new System.Drawing.Point(15, 98);
            this.grpDashboard.Size = new System.Drawing.Size(850, 145);
            this.grpDashboard.Text = "Bảng thông số vận hành thời gian thực (Real-time Telemetry)";

            this.lblVoltageTitle.AutoSize = true;
            this.lblVoltageTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVoltageTitle.Location = new System.Drawing.Point(65, 30);
            this.lblVoltageTitle.Text = "ĐIỆN ÁP THANH CÁI (kV)";

            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Font = new System.Drawing.Font("Consolas", 26F, System.Drawing.FontStyle.Bold);
            this.lblVoltage.ForeColor = System.Drawing.Color.Navy;
            this.lblVoltage.Location = new System.Drawing.Point(60, 58);
            this.lblVoltage.Text = "---.-- kV";

            this.lblLoadTitle.AutoSize = true;
            this.lblLoadTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLoadTitle.Location = new System.Drawing.Point(390, 30);
            this.lblLoadTitle.Text = "MỨC MANG TẢI MÁY BIẾN ÁP (%)";

            this.lblLoadPercent.AutoSize = true;
            this.lblLoadPercent.Font = new System.Drawing.Font("Consolas", 26F, System.Drawing.FontStyle.Bold);
            this.lblLoadPercent.ForeColor = System.Drawing.Color.Green;
            this.lblLoadPercent.Location = new System.Drawing.Point(385, 58);
            this.lblLoadPercent.Text = "-- %";

            this.lblWarningBanner.AutoSize = true;
            this.lblWarningBanner.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblWarningBanner.ForeColor = System.Drawing.Color.DimGray;
            this.lblWarningBanner.Location = new System.Drawing.Point(65, 112);
            this.lblWarningBanner.Text = "Trạng thái vận hành: Chưa kích hoạt luồng đo lường";

            this.grpLogs.Controls.Add(this.dgvGridLogs);
            this.grpLogs.Location = new System.Drawing.Point(15, 255);
            this.grpLogs.Size = new System.Drawing.Size(850, 260);
            this.grpLogs.Text = "Nhật ký Sự cố Quá tải Lưới điện (Ngưỡng > 85%)";

            this.dgvGridLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGridLogs.Location = new System.Drawing.Point(3, 19);
            this.dgvGridLogs.Size = new System.Drawing.Size(844, 238);

            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblConnectionState, this.lblLastPacketTime, this.lblCycleCounter
            });
            this.statusStripMain.Location = new System.Drawing.Point(0, 526);
            this.statusStripMain.Size = new System.Drawing.Size(880, 25);

            this.lblConnectionState.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblConnectionState.ForeColor = System.Drawing.Color.DarkRed;
            this.lblConnectionState.Text = "SCADA: Ngắt kết nối  ";

            this.lblLastPacketTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblLastPacketTime.Text = "  Gói tin cuối: --:--:--  ";

            this.lblCycleCounter.Spring = true;
            this.lblCycleCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCycleCounter.Text = "Tổng chu kỳ đã quét: 0";

            this.ClientSize = new System.Drawing.Size(880, 551);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.grpLogs);
            this.Controls.Add(this.grpDashboard);
            this.Controls.Add(this.grpControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPowerGridMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRUNG TÂM ĐIỀU ĐỘ & GIÁM SÁT LƯỚI ĐIỆN THỜI GIAN THỰC (SCADA)";
            this.Load += new System.EventHandler(this.frmPowerGridMonitor_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPowerGridMonitor_FormClosing);

            this.grpControl.ResumeLayout(false);
            this.grpControl.PerformLayout();
            this.grpDashboard.ResumeLayout(false);
            this.grpDashboard.PerformLayout();
            this.grpLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGridLogs)).EndInit();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
