USE [PdH]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 01/03/2018 09:46:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](15) NULL,
	[Name] [nvarchar](512) NULL,
	[Material] [nvarchar](128) NULL,
	[Color] [nvarchar](128) NULL,
	[Size] [nvarchar](20) NULL,
	[Stock] [bigint] NULL,
	[Price] [decimal](15, 8) NULL,
	[Category] [nvarchar](128) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](128) NOT NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


