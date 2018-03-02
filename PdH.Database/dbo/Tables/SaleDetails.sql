CREATE TABLE [dbo].[SaleDetails] (
    [Id]              BIGINT          IDENTITY (1, 1) NOT NULL,
    [ProductId]       BIGINT          NOT NULL,
    [SaleId]          BIGINT          NOT NULL,
    [ProductQuantity] BIGINT          NOT NULL,
    [ProductAmount]   DECIMAL (15, 8) NOT NULL,
    [SaleDate]        DATETIME2 (7)   NOT NULL,
    CONSTRAINT [PK_SaleDetails] PRIMARY KEY CLUSTERED ([Id] ASC, [SaleId] ASC),
    CONSTRAINT [FK_SaleDetails_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_SaleDetails_Sales] FOREIGN KEY ([SaleId]) REFERENCES [dbo].[Sales] ([Id])
);






GO
CREATE UNIQUE NONCLUSTERED INDEX [UNIQUE_ProductId_SaleId]
    ON [dbo].[SaleDetails]([ProductId] ASC, [SaleId] ASC);

