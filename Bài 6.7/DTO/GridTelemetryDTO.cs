using System;

namespace DTO
{
    public class GridTelemetryDTO
    {
        public string SubstationCode { get; set; }
        public string SubstationName { get; set; }
        public DateTime Timestamp { get; set; }
        public double VoltageKV { get; set; }
        public int LoadPercent { get; set; }
        public int CycleCount { get; set; }
        public bool IsOverloaded => LoadPercent > 85;
    }
}