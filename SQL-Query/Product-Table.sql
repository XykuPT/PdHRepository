CREATE TABLE [dbo].[Product](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NULL,
	[Color] [nvarchar](128) NULL,
	[Size] [nvarchar](20) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](128) NOT NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL
)



