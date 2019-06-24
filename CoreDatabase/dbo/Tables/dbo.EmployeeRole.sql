CREATE TABLE [dbo].[EmployeeRole] (
    [EmployeeRoleID] NVARCHAR (10) NOT NULL,
    [EmployeeID]     NVARCHAR (10) NOT NULL,
    [RoleID]         NVARCHAR (10) NOT NULL,
    CONSTRAINT [PK_EmployeeRoleID] PRIMARY KEY CLUSTERED ([EmployeeRoleID] ASC),
    CONSTRAINT [FK_EmployeeRole_Employees] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Roles] ([RoleID])
);

