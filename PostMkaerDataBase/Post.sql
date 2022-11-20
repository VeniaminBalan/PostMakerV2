CREATE TABLE [dbo].[Post]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Author] nvarchar(50),
	[Content] nvarchar(50),
	[Created] datetime default GETDATE()
)
