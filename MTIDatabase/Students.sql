CREATE TABLE [dbo].[Students]
(
	[StudentNumber] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(MAX) NOT NULL
)
