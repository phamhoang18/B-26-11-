CREATE DATABASE PowerGridScadaDB;
GO
USE PowerGridScadaDB;
GO

-- Bảng danh mục Trạm biến áp
CREATE TABLE Substations (
    SubstationCode VARCHAR(20) PRIMARY KEY,
    SubstationName NVARCHAR(150) NOT NULL,
    NominalVoltageKV FLOAT NOT NULL
);
GO

-- Bảng lưu lịch sử sự cố quá tải (> 85%)
CREATE TABLE OverloadLogs (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    SubstationCode VARCHAR(20) NOT NULL,
    RecordedTime DATETIME NOT NULL DEFAULT GETDATE(),
    VoltageKV FLOAT NOT NULL,
    LoadPercent INT NOT NULL,
    WarningMessage NVARCHAR(255) NOT NULL,
    FOREIGN KEY (SubstationCode) REFERENCES Substations(SubstationCode)
);
GO

-- Dữ liệu mẫu trạm biến áp
INSERT INTO Substations (SubstationCode, SubstationName, NominalVoltageKV) VALUES
('TBA-HD110', N'Trạm biến áp 110kV Hà Đông', 110.0),
('TBA-CH220', N'Trạm biến áp 220kV Chèm', 220.0),
('TBA-LB110', N'Trạm biến áp 110kV Long Biên', 110.0);
GO