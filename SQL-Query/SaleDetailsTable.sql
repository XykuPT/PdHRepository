USE [PdH]
GO

/****** Object:  Table [dbo].[SaleDetails]    Script Date: 06/03/2018 09:45:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SaleDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[SaleId] [bigint] NOT NULL,
	[ProductQuantity] [bigint] NOT NULL,
	[ProductAmount] [decimal](15, 8) NOT NULL,
	[SaleDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_SaleDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[SaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SaleDetails]  WITH CHECK ADD  CONSTRAINT [FK_SaleDetails_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[SaleDetails] CHECK CONSTRAINT [FK_SaleDetails_Product]
GO

ALTER TABLE [dbo].[SaleDetails]  WITH CHECK ADD  CONSTRAINT [FK_SaleDetails_Sales] FOREIGN KEY([SaleId])
REFERENCES [dbo].[Sales] ([Id])
GO

ALTER TABLE [dbo].[SaleDetails] CHECK CONSTRAINT [FK_SaleDetails_Sales]
GO


