CREATE TABLE [dbo].[Product] (
    [Id]        BIGINT          IDENTITY (1, 1) NOT NULL,
    [Code]      VARCHAR (15)    NULL,
    [Name]      NVARCHAR (512)  NULL,
    [Material]  NVARCHAR (128)  NULL,
    [Color]     NVARCHAR (128)  NULL,
    [Size]      NVARCHAR (20)   NULL,
    [Price]     DECIMAL (15, 8) NULL,
    [Category]  NVARCHAR (128)  NULL,
    [IsActive]  BIT             NULL,
    [CreatedOn] DATETIME2 (7)   NOT NULL,
    [CreatedBy] NVARCHAR (128)  NOT NULL,
    [UpdatedOn] DATETIME2 (7)   NOT NULL,
    [UpdatedBy] NVARCHAR (128)  NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
);





