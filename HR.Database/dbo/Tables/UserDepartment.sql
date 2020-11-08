CREATE TABLE [dbo].[UserDepartment] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [UserId]        NVARCHAR (128) NULL,
    [DepartementId] INT            NULL,
    CONSTRAINT [PK_UserDepartment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserDepartment_Department] FOREIGN KEY ([DepartementId]) REFERENCES [dbo].[Department] ([Id])
);

