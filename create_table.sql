USE [TodoDB]
GO
/****** Object:  Table [dbo].[Details]    Script Date: 4/10/2020 9:03:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Details](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[PercentCompleteness] [int] NULL,
	[ExpiryDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[Status] [varchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_tbDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Details] ON 

INSERT [dbo].[Details] ([ID], [Title], [Description], [PercentCompleteness], [ExpiryDate], [ModifiedDate], [ModifiedBy], [Status], [IsDelete]) VALUES (1, N'Test Title', N'Description Tes', 30, CAST(N'2020-05-11T00:00:00.000' AS DateTime), NULL, NULL, N'Pending', 0)
INSERT [dbo].[Details] ([ID], [Title], [Description], [PercentCompleteness], [ExpiryDate], [ModifiedDate], [ModifiedBy], [Status], [IsDelete]) VALUES (4, N'Title 2', N'Description 2', 40, CAST(N'2020-05-10T00:00:00.000' AS DateTime), NULL, NULL, N'Pending', 0)
INSERT [dbo].[Details] ([ID], [Title], [Description], [PercentCompleteness], [ExpiryDate], [ModifiedDate], [ModifiedBy], [Status], [IsDelete]) VALUES (5, N'Testing Title', N'Description', 70, CAST(N'2020-06-03T00:00:00.000' AS DateTime), NULL, NULL, N'Pending', 0)
INSERT [dbo].[Details] ([ID], [Title], [Description], [PercentCompleteness], [ExpiryDate], [ModifiedDate], [ModifiedBy], [Status], [IsDelete]) VALUES (6, N'Try Id', N'This is description', 45, CAST(N'2020-04-19T00:00:00.000' AS DateTime), NULL, NULL, N'Done', 1)
SET IDENTITY_INSERT [dbo].[Details] OFF
