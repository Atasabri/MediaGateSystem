
CREATE TABLE [dbo].[Accessories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Serial_Number] [nvarchar](100) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Weight] [float] NOT NULL,
	[Entry_Data] [date] NOT NULL,
	[Departure_Date] [date] NOT NULL,
	[Work_In] [nvarchar](max) NOT NULL,
	[Buy_Date] [date] NOT NULL,
	[Special_Prop] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Cat_ID] [int] NOT NULL,
	[Stat_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/19/2019 9:51:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[colors]    Script Date: 11/19/2019 9:51:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[colors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Acc_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Statues]    Script Date: 11/19/2019 9:51:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statues](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/19/2019 9:51:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accessories] ON 

GO
INSERT [dbo].[Accessories] ([ID], [Name], [Serial_Number], [Model], [Weight], [Entry_Data], [Departure_Date], [Work_In], [Buy_Date], [Special_Prop], [Quantity], [Cat_ID], [Stat_ID], [User_ID]) VALUES (4, N'Ata Sabri ata', N'as', N'2012-2013', 13.9, CAST(0x673D0B00 AS Date), CAST(0x8C3D0B00 AS Date), N'test work', CAST(0x933D0B00 AS Date), N'test prop', 12, 1, 1, 1)
GO
INSERT [dbo].[Accessories] ([ID], [Name], [Serial_Number], [Model], [Weight], [Entry_Data], [Departure_Date], [Work_In], [Buy_Date], [Special_Prop], [Quantity], [Cat_ID], [Stat_ID], [User_ID]) VALUES (5, N'TEST', N'as', N'2012-2013', 13.9, CAST(0x5D3D0B00 AS Date), CAST(0x643D0B00 AS Date), N'test work', CAST(0x6D3D0B00 AS Date), N'test prop', 12, 2, 4, 1)
GO
SET IDENTITY_INSERT [dbo].[Accessories] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

GO
INSERT [dbo].[Categories] ([ID], [Name]) VALUES (1, N'Category 1')
GO
INSERT [dbo].[Categories] ([ID], [Name]) VALUES (2, N'Category 2')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[colors] ON 

GO
INSERT [dbo].[colors] ([ID], [Name], [Acc_ID]) VALUES (12, N'move', 4)
GO
INSERT [dbo].[colors] ([ID], [Name], [Acc_ID]) VALUES (13, N'red', 5)
GO
SET IDENTITY_INSERT [dbo].[colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Statues] ON 

GO
INSERT [dbo].[Statues] ([ID], [Name]) VALUES (1, N'Good')
GO
INSERT [dbo].[Statues] ([ID], [Name]) VALUES (2, N'Very Good')
GO
INSERT [dbo].[Statues] ([ID], [Name]) VALUES (3, N'New')
GO
INSERT [dbo].[Statues] ([ID], [Name]) VALUES (4, N'Excellent')
GO
SET IDENTITY_INSERT [dbo].[Statues] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([ID], [UserName], [Password], [Email], [Phone]) VALUES (1, N'Ata Sabri', N'asdFGH', N'ataeldon@gmail.com', 1142229025)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Accessories]  WITH CHECK ADD  CONSTRAINT [FK__Accessori__Cat_I__164452B1] FOREIGN KEY([Cat_ID])
REFERENCES [dbo].[Categories] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accessories] CHECK CONSTRAINT [FK__Accessori__Cat_I__164452B1]
GO
ALTER TABLE [dbo].[Accessories]  WITH CHECK ADD  CONSTRAINT [FK__Accessori__Stat___173876EA] FOREIGN KEY([Stat_ID])
REFERENCES [dbo].[Statues] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accessories] CHECK CONSTRAINT [FK__Accessori__Stat___173876EA]
GO
ALTER TABLE [dbo].[Accessories]  WITH CHECK ADD  CONSTRAINT [FK__Accessori__User___182C9B23] FOREIGN KEY([User_ID])
REFERENCES [dbo].[Users] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accessories] CHECK CONSTRAINT [FK__Accessori__User___182C9B23]
GO
ALTER TABLE [dbo].[colors]  WITH CHECK ADD  CONSTRAINT [FK__colors__Acc_ID__1B0907CE] FOREIGN KEY([Acc_ID])
REFERENCES [dbo].[Accessories] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[colors] CHECK CONSTRAINT [FK__colors__Acc_ID__1B0907CE]
GO
USE [master]
GO
ALTER DATABASE [Accessories] SET  READ_WRITE 
GO
