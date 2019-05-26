CREATE TABLE [dbo].[Users] (
    [UserID]       NVARCHAR (10)   NOT NULL,
    [UserRole]     NVARCHAR (10)   NOT NULL,
    [FirstName]    NVARCHAR (50)   NULL,
    [LastName]     NVARCHAR (50)   NULL,
    [Username]     NVARCHAR (50)   NULL,
    [PasswordHash] VARBINARY (MAX) NULL,
    [PasswordSalt] VARBINARY (MAX) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

