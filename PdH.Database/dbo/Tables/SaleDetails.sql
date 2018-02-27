CREATE TABLE [dbo].[SaleDetails] (
    [Id]        BIGINT          IDENTITY (1, 1) NOT NULL,
    [Units]     DECIMAL (6)     NOT NULL,
    [UnitPrice] DECIMAL (15, 8) NOT NULL,
    [Amount]    DECIMAL (15, 8) NULL,
    [SalesId]   BIGINT          NOT NULL,
    CONSTRAINT [PK_SaleDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SalesId] FOREIGN KEY ([SalesId]) REFERENCES [dbo].[Sales] ([Id])
);

