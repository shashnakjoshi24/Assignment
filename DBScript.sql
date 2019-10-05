CREATE TABLE [dbo].[BookDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookTitle] [nvarchar](500) NOT NULL,
	[ISBN] [nvarchar](25) NOT NULL,
	[PublishingYear] [char](4) NOT NULL,
	[Price] [decimal](12, 6) NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[Image] [image] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_BookDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BorrowerDetails]    Script Date: 2/2/2016 12:50:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[LastName] [nvarchar](250) NOT NULL,
	[MobileNumber] [nvarchar](11) NOT NULL,
	[NationalId] [nvarchar](11) NOT NULL,
	[EmailId] [nvarchar](250) NOT NULL,
	
 CONSTRAINT [PK_BorrowerDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CheckOutStatusDescription]    Script Date: 2/2/2016 12:50:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckOutSummery](
	[ID] [int] NOT NULL,
	[Book] [int] NOT NULL,
	[User] [int] NOT NULL,
	[CheckOutDate] datetime NOT NULL,
	[CheckInDate] datetime NULL,
	[NumberOfDays] int,
	[IsOverDue] bit 
 CONSTRAINT [PK_CheckOutStatusDescription] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[Error](
	[ErrorID] [int] NOT NULL,
	[ErrorDateTime] datetime NOT NULL,
	[ErrorMessage] nvarchar(MAX) NOT NULL,
	[ErrorDescription] nvarchar(MAX) NOT NULL,
	[UserID] int NULL,
	[NumberOfDays] int,
	[IsOverDue] bit 
 CONSTRAINT [PK_CheckOutStatusDescription] PRIMARY KEY CLUSTERED 
(
	[ErrorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
