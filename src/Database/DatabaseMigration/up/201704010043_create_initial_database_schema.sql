CREATE TABLE [dbo].[BranchLocation] (
    [Id] [int] NOT NULL IDENTITY,
    [City] [nvarchar](20),
    [State] [nvarchar](20),
    CONSTRAINT [PK_dbo.BranchLocation] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Employee] (
    [Id] [int] NOT NULL IDENTITY,
    [FistName] [nvarchar](20),
    [LastName] [nvarchar](30),
    [JobTitle] [nvarchar](50),
    [Email] [nvarchar](50),
    [BranchLocation_BranchLocationId] [int],
    CONSTRAINT [PK_dbo.Employee] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_BranchLocation_Id] ON [dbo].[Employee]([BranchLocation_Id])
CREATE TABLE [dbo].[PhoneNumber] (
    [Id] [int] NOT NULL IDENTITY,
    [PhoneType] [int] NOT NULL,
    [Number] [nvarchar](20),
    [EmployeeModel_EmployeeId] [int],
    CONSTRAINT [PK_dbo.PhoneNumber] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_EmployeeModel_Id] ON [dbo].[PhoneNumber]([EmployeeModel_Id])
ALTER TABLE [dbo].[Employee] ADD CONSTRAINT [FK_dbo.Employee_dbo.BranchLocation_BranchLocation_Id] FOREIGN KEY ([BranchLocation_Id]) REFERENCES [dbo].[BranchLocation] ([Id])
ALTER TABLE [dbo].[PhoneNumber] ADD CONSTRAINT [FK_dbo.PhoneNumber_dbo.Employee_EmployeeModel_Id] FOREIGN KEY ([EmployeeModel_Id]) REFERENCES [dbo].[Employee] ([Id])
