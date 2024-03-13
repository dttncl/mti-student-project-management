CREATE TABLE [dbo].[Projects]
(
	[ProjectCode] NVARCHAR(6) NOT NULL PRIMARY KEY, 
    [ProjectTitle] NVARCHAR(100) NOT NULL, 
    [DueDate] DATE NOT NULL
)
