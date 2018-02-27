USE [PdH]
GO

/****** Object:  Table [dbo].[SaleDetails]    Script Date: 27/02/2018 15:39:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SaleDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Units] [decimal](6, 0) NOT NULL,
	[UnitPrice] [decimal](15, 8) NOT NULL,
	[Amount] [decimal](15, 8) NULL,
	[SalesId] [bigint] NOT NULL,
 CONSTRAINT [PK_SaleDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SaleDetails]  WITH CHECK ADD  CONSTRAINT [FK_SalesId] FOREIGN KEY([SalesId])
REFERENCES [dbo].[Sales] ([Id])
GO

ALTER TABLE [dbo].[SaleDetails] CHECK CONSTRAINT [FK_SalesId]
GO


