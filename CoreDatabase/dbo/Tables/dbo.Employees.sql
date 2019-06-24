CREATE TABLE [dbo].[Employees] (
    [EmployeeID]   NVARCHAR (10)   NOT NULL,
    [FirstName]    NVARCHAR (50)   NULL,
    [LastName]     NVARCHAR (50)   NULL,
    [Username]     NVARCHAR (50)   NULL,
    [PasswordHash] VARBINARY (MAX) NULL,
    [PasswordSalt] VARBINARY (MAX) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);

