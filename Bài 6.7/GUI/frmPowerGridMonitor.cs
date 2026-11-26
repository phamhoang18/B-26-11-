using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmPowerGridMonitor : Form
    {
        private readonly ScadaMonitorBUS _bus = new ScadaMonitorBUS();
        private CancellationTokenSource _cts;

        public frmPowerGridMonitor()
        {
            InitializeComponent();
        }

        private void frmPowerGridMonitor_Load(object sender, EventArgs e)
        {
            ConfigureLogGridView();
            LoadSubstationComboBox();
        }

        /// <summary>
        /// Cấu hình DataGridView nhật ký sự cố thủ công bằng code
        /// </summary>
        private void ConfigureLogGridView()
        {
            dgvGridLogs.Columns.Clear();
            dgvGridLogs.AllowUserToAddRows = false;
            dgvGridLogs.ReadOnly = true;
            dgvGridLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGridLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGridLogs.RowHeadersVisible = false;

            dgvGridLogs.Columns.Add("colTime", "Thời điểm sự cố");
            dgvGridLogs.Columns.Add("colStation", "Trạm biến áp");
            dgvGridLogs.Columns.Add("colVoltage", "Điện áp (kV)");
            dgvGridLogs.Columns.Add("colLoad", "Mức tải (%)");
            dgvGridLogs.Columns.Add("colMessage", "Nội dung cảnh báo");

            dgvGridLogs.Columns["colTime"].FillWeight = 18;
            dgvGridLogs.Columns["colStation"].FillWeight = 24;
            dgvGridLogs.Columns["colVoltage"].FillWeight = 14;
            dgvGridLogs.Columns["colLoad"].FillWeight = 14;
            dgvGridLogs.Columns["colMessage"].FillWeight = 30;
        }

        private void LoadSubstationComboBox()
        {
            cboSubstations.DataSource = _bus.GetSubstations();
            cboSubstations.DisplayMember = "SubstationName";
            cboSubstations.ValueMember = "SubstationCode";
        }

        private void btnStartScada_Click(object sender, EventArgs e)
        {
            if (!(cboSubstations.SelectedItem is SubstationDTO selectedStation))
                return;

            btnStartScada.Enabled = false;
            cboSubstations.Enabled = false;
            btnStopScada.Enabled = true;

            lblConnectionState.Text = $"SCADA: Đang giám sát [{selectedStation.SubstationCode}]  ";
            lblConnectionState.ForeColor = Color.DarkGreen;

            _cts = new CancellationTokenSource();

            // Khởi chạy vòng lặp ngầm ở BUS, truyền callback UpdateTelemetryUI
            _bus.StartPollingLoopAsync(selectedStation, UpdateTelemetryUI, _cts.Token);
        }

        /// <summary>
        /// Hàm nhận dữ liệu từ Background Thread và cập nhật lên UI an toàn (Thread-Safe)
        /// </summary>
        private void UpdateTelemetryUI(GridTelemetryDTO data)
        {
            // Kiểm tra Form đã bị hủy chưa để tránh ObjectDisposedException khi đóng cửa sổ đột ngột
            if (this.IsDisposed || !this.IsHandleCreated)
                return;

            // BẮT BUỘC: Kiểm tra InvokeRequired vì hàm này được gọi từ Thread phụ (Task.Run)
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateTelemetryUI(data)));
                return;
            }

            // --- ĐOẠN CODE DƯỚI ĐÂY CHẠY AN TOÀN TRÊN MAIN UI THREAD ---
            lblVoltage.Text = $"{data.VoltageKV:0.00} kV";
            lblLoadPercent.Text = $"{data.LoadPercent} %";

            if (data.IsOverloaded) // Vượt ngưỡng > 85%
            {
                lblLoadPercent.ForeColor = Color.Red;
                lblWarningBanner.ForeColor = Color.Red;
                lblWarningBanner.Text = $"CẢNH BÁO NGUY HIỂM: Trạm {data.SubstationName} đang QUÁ TẢI ({data.LoadPercent}%)!";

                // Thêm dòng cảnh báo mới lên đầu DataGridView
                dgvGridLogs.Rows.Insert(0,
                    data.Timestamp.ToString("HH:mm:ss dd/MM/yyyy"),
                    data.SubstationName,
                    $"{data.VoltageKV:0.00}",
                    $"{data.LoadPercent}%",
                    "Quá tải đường dây (> 85%)"
                );

                dgvGridLogs.Rows[0].DefaultCellStyle.ForeColor = Color.DarkRed;
                dgvGridLogs.Rows[0].DefaultCellStyle.BackColor = Color.MistyRose;
            }
            else
            {
                lblLoadPercent.ForeColor = Color.Green;
                lblWarningBanner.ForeColor = Color.DarkGreen;
                lblWarningBanner.Text = "Trạng thái vận hành: Ổn định trong ngưỡng an toàn (<= 85%)";
            }

            // Cập nhật StatusStrip
            lblLastPacketTime.Text = $"  Gói tin cuối: {data.Timestamp:HH:mm:ss}  ";
            lblCycleCounter.Text = $"Tổng chu kỳ đã quét: {data.CycleCount}";
        }

        private void btnStopScada_Click(object sender, EventArgs e)
        {
            StopMonitoring();
        }

        private void StopMonitoring()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }

            btnStartScada.Enabled = true;
            cboSubstations.Enabled = true;
            btnStopScada.Enabled = false;

            lblConnectionState.Text = "SCADA: Đã ngắt kết nối  ";
            lblConnectionState.ForeColor = Color.DarkRed;
            lblWarningBanner.ForeColor = Color.DimGray;
            lblWarningBanner.Text = "Trạng thái vận hành: Đã dừng giám sát";
        }

        private void frmPowerGridMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hủy luồng nền ngay khi người dùng nhấn nút X đóng Form
            _cts?.Cancel();
        }
    }
}