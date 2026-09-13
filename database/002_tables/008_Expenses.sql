IF NOT EXISTS (SELECT 1 FROM sys.tables t JOIN sys.schemas s ON t.schema_id = s.schema_id WHERE s.name = 'agritrack' AND t.name = 'Expenses')
BEGIN
    CREATE TABLE agritrack.Expenses
    (
        Id           UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_agritrack_Expenses PRIMARY KEY,
        UserId       UNIQUEIDENTIFIER NOT NULL,
        CropCycleId  UNIQUEIDENTIFIER NOT NULL,
        Category     NVARCHAR(30)     NOT NULL, -- Seeds | Fertilizer | Pesticide | Labor | Irrigation | Equipment | Other
        Amount       DECIMAL(10,2)    NOT NULL,
        ExpenseDate  DATE             NOT NULL,
        Notes        NVARCHAR(1000)   NULL,
        CreatedAt    DATETIME2        NOT NULL CONSTRAINT DF_agritrack_Expenses_CreatedAt DEFAULT (SYSUTCDATETIME()),
        UpdatedAt    DATETIME2        NOT NULL CONSTRAINT DF_agritrack_Expenses_UpdatedAt DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_agritrack_Expenses_CropCycles FOREIGN KEY (CropCycleId) REFERENCES agritrack.CropCycles (Id),
        CONSTRAINT FK_agritrack_Expenses_Users FOREIGN KEY (UserId) REFERENCES agritrack.Users (Id)
    );
    CREATE INDEX IX_agritrack_Expenses_CropCycleId ON agritrack.Expenses (CropCycleId);
    CREATE INDEX IX_agritrack_Expenses_UserId ON agritrack.Expenses (UserId);
END
GO
