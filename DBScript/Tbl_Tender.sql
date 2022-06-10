USE [TrainingAngularDB]
GO

/****** Object:  Table [dbo].[Tenders]    Script Date: 10/06/2022 07.33.21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Tenders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [varchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [varchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[TenderID] [varchar](max) NULL,
	[ContractNo] [varchar](max) NULL,
	[TenderName] [varchar](max) NULL,
	[TenderValue] [decimal](18, 2) NOT NULL,
	[Description] [varchar](max) NULL,
	[ReleaseDate] [datetime2](7) NOT NULL,
	[ClosingDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Tenders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


