CREATE TABLE [dbo].[BranchLocation] (
    [BranchLocationId] [int] NOT NULL IDENTITY,
    [City] [nvarchar](20),
    [State] [nvarchar](20),
    CONSTRAINT [PK_dbo.BranchLocation] PRIMARY KEY ([BranchLocationId])
)
CREATE TABLE [dbo].[Employee] (
    [EmployeeId] [int] NOT NULL IDENTITY,
    [FistName] [nvarchar](20),
    [LastName] [nvarchar](30),
    [JobTitle] [nvarchar](50),
    [Email] [nvarchar](50),
    [BranchLocation_BranchLocationId] [int],
    CONSTRAINT [PK_dbo.Employee] PRIMARY KEY ([EmployeeId])
)
CREATE INDEX [IX_BranchLocation_BranchLocationId] ON [dbo].[Employee]([BranchLocation_BranchLocationId])
CREATE TABLE [dbo].[PhoneNumber] (
    [PhoneNumberId] [int] NOT NULL IDENTITY,
    [PhoneType] [int] NOT NULL,
    [Number] [nvarchar](20),
    [EmployeeModel_EmployeeId] [int],
    CONSTRAINT [PK_dbo.PhoneNumber] PRIMARY KEY ([PhoneNumberId])
)
CREATE INDEX [IX_EmployeeModel_EmployeeId] ON [dbo].[PhoneNumber]([EmployeeModel_EmployeeId])
ALTER TABLE [dbo].[Employee] ADD CONSTRAINT [FK_dbo.Employee_dbo.BranchLocation_BranchLocation_BranchLocationId] FOREIGN KEY ([BranchLocation_BranchLocationId]) REFERENCES [dbo].[BranchLocation] ([BranchLocationId])
ALTER TABLE [dbo].[PhoneNumber] ADD CONSTRAINT [FK_dbo.PhoneNumber_dbo.Employee_EmployeeModel_EmployeeId] FOREIGN KEY ([EmployeeModel_EmployeeId]) REFERENCES [dbo].[Employee] ([EmployeeId])
