CREATE TABLE [dbo].[Product] (
    [Id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (512) NULL,
    [IsActive]  BIT            NULL,
    [CreatedOn] DATETIME2 (7)  NOT NULL,
    [CreatedBy] NVARCHAR (128) NOT NULL,
    [UpdatedOn] DATETIME2 (7)  NOT NULL,
    [UpdatedBy] NVARCHAR (128) NOT NULL
);

