CREATE DATABASE WebTwain
Go
Use WebTwain
Go
CREATE TABLE [dbo].[tblImage](
	[iImageID] [int] IDENTITY (1, 1) NOT NULL ,
	[strImageName] [nvarchar](255) NULL,
	[imgImageData] [image] NULL,
	[strExtraTxt] [nvarchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
