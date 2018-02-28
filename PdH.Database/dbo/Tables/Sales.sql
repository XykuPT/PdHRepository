CREATE TABLE [dbo].[Sales] (
    [Id]          BIGINT        IDENTITY (1, 1) NOT NULL,
    [ProductId]   BIGINT        NOT NULL,
    [SaleId]      BIGINT        NOT NULL,
    [CustomerKey] BIGINT        NULL,
    [SaleDate]    DATETIME2 (7) NULL,
    CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [UK_Sales] UNIQUE NONCLUSTERED ([ProductId] ASC, [SaleId] ASC)
);

