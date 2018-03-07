USE [PdH]
GO

/****** Object:  Table [dbo].[Sales]    Script Date: 06/03/2018 15:25:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sales](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TotalAmount] [decimal](15, 8) NOT NULL,
	[TotalQuantity] [bigint] NOT NULL,
	[CustomerKey] [bigint] NOT NULL,
	[SaleDate] [datetime2](7) NOT NULL,
	[DeliveryAddress] [nvarchar](512) NULL,
	[DeliveryCod_Postal] [nvarchar](8) NULL,
	[DeliveryLocation] [nvarchar](128) NULL,
	[DeliveryStatus] [nvarchar](128) NULL,
 CONSTRAINT [PK_Sales_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


