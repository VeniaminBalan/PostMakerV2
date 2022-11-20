CREATE TABLE [dbo].[User_Account]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Email] nvarchar(50),
	[Password] nvarchar(50),
	[Name] nvarchar(50)
)
