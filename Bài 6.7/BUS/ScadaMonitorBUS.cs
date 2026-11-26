using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class ScadaMonitorBUS
    {
        private readonly SubstationDAL _substationDal = new SubstationDAL();
        private readonly GridLogDAL _logDal = new GridLogDAL();

        public List<SubstationDTO> GetSubstations()
        {
            try
            {
                return _substationDal.GetAllSubstations();
            }
            catch
            {
                // Dữ liệu dự phòng nếu máy chưa cấu hình SQL Server
                return new List<SubstationDTO>
                {
                    new SubstationDTO { SubstationCode = "TBA-HD110", SubstationName = "Trạm 110kV Hà Đông", NominalVoltageKV = 110.0 },
                    new SubstationDTO { SubstationCode = "TBA-CH220", SubstationName = "Trạm 220kV Chèm", NominalVoltageKV = 220.0 },
                    new SubstationDTO { SubstationCode = "TBA-LB110", SubstationName = "Trạm 110kV Long Biên", NominalVoltageKV = 110.0 }
                };
            }
        }

        /// <summary>
        /// Vòng lặp nền SCADA thu thập thông số mỗi 2 giây
        /// </summary>
        public Task StartPollingLoopAsync(
            SubstationDTO substation,
            Action<GridTelemetryDTO> onDataReceivedCallback,
            CancellationToken token)
        {
            return Task.Run(async () =>
            {
                Random rnd = new Random();
                int cycle = 0;

                while (!token.IsCancellationRequested)
                {
                    cycle++;

                    // Sinh ngẫu nhiên Điện áp (108.0kV - 115.0kV) và Mức tải (50% - 98%)
                    double voltage = Math.Round(108.0 + rnd.NextDouble() * 7.0, 2);
                    int loadPercent = rnd.Next(50, 99);

                    var telemetry = new GridTelemetryDTO
                    {
                        SubstationCode = substation.SubstationCode,
                        SubstationName = substation.SubstationName,
                        Timestamp = DateTime.Now,
                        VoltageKV = voltage,
                        LoadPercent = loadPercent,
                        CycleCount = cycle
                    };

                    // Nếu quá tải (> 85%), ghi log sự cố xuống SQL Server ngay trên luồng nền
                    if (telemetry.IsOverloaded)
                    {
                        try
                        {
                            string msg = $"CẢNH BÁO QUÁ TẢI: Tải đạt {telemetry.LoadPercent}% (Ngưỡng > 85%)";
                            _logDal.InsertOverloadLog(telemetry, msg);
                        }
                        catch { /* Bỏ qua lỗi DB nếu chạy offline */ }
                    }

                    // Kích hoạt callback gửi gói tin về tầng GUI (đang chạy trên Background Thread)
                    onDataReceivedCallback?.Invoke(telemetry);

                    // Chờ định kỳ 2 giây cho chu kỳ quét tiếp theo
                    try
                    {
                        await Task.Delay(2000, token);
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }
                }
            }, token);
        }
    }
}