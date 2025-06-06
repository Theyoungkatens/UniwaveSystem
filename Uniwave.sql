USE [Uniwave]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/18/2025 4:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 5/18/2025 4:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Tags] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 5/18/2025 4:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogisticRoutes]    Script Date: 5/18/2025 4:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogisticRoutes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromLocation] [nvarchar](max) NOT NULL,
	[ToLocation] [nvarchar](max) NOT NULL,
	[ExtraPricePer0_1Kg] [decimal](18, 2) NOT NULL,
	[BasePricePerKg] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_LogisticRoutes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShippingOrders]    Script Date: 5/18/2025 4:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingOrders](
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[CargoType] [nvarchar](max) NOT NULL,
	[PickupAddress] [nvarchar](max) NOT NULL,
	[DeliveryAddress] [nvarchar](max) NOT NULL,
	[WeightKg] [float] NOT NULL,
	[LogisticRouteId] [int] NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[Id] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ShippingOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/18/2025 4:53:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[LogisticRoutes] ADD  DEFAULT ((0.0)) FOR [BasePricePerKg]
GO
ALTER TABLE [dbo].[ShippingOrders] ADD  DEFAULT ((0.0)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[ShippingOrders] ADD  DEFAULT ('') FOR [Id]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [Role]
GO
ALTER TABLE [dbo].[ShippingOrders]  WITH CHECK ADD  CONSTRAINT [FK_ShippingOrders_LogisticRoutes_LogisticRouteId] FOREIGN KEY([LogisticRouteId])
REFERENCES [dbo].[LogisticRoutes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShippingOrders] CHECK CONSTRAINT [FK_ShippingOrders_LogisticRoutes_LogisticRouteId]
GO
