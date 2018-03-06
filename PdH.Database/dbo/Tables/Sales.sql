CREATE TABLE [dbo].[Sales] (
    [Id]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [TotalAmount] DECIMAL (15, 8) NOT NULL,
    [TotalUnits]  BIGINT          NOT NULL,
    [CustomerKey] BIGINT          NOT NULL,
    [SaleDate]    DATETIME2 (7)   NOT NULL,
    [DeliveryAddress] NVARCHAR(512) NULL, 
    [DeliveryCod_Postal] NVARCHAR(8) NULL, 
    [DeliveryLocation] NVARCHAR(128) NULL, 
    [DeliveryStatus] NVARCHAR(128) NULL, 
    CONSTRAINT [PK_Sales_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);





