CREATE TABLE [dbo].[Assignments]
(
	[AssignmentId] INT NOT NULL PRIMARY KEY CLUSTERED IDENTITY, 
    [ProjectCode] NVARCHAR(6) NOT NULL, 
    [StudentNumber] INT NOT NULL, 
    [AssignmentDate] DATE NOT NULL, 
    CONSTRAINT [FK_Assignments_Projects] FOREIGN KEY (ProjectCode) REFERENCES Projects(ProjectCode), 
    CONSTRAINT [FK_Assignments_Students] FOREIGN KEY (StudentNumber) REFERENCES Students(StudentNumber) 
)
