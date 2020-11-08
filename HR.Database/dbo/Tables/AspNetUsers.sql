CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128)  NOT NULL,
    [Email]                NVARCHAR (256)  NULL,
    [EmailConfirmed]       BIT             NOT NULL,
    [PasswordHash]         NVARCHAR (MAX)  NULL,
    [SecurityStamp]        NVARCHAR (MAX)  NULL,
    [PhoneNumber]          NVARCHAR (MAX)  NULL,
    [PhoneNumberConfirmed] BIT             NOT NULL,
    [TwoFactorEnabled]     BIT             NOT NULL,
    [LockoutEndDateUtc]    DATETIME        NULL,
    [LockoutEnabled]       BIT             NOT NULL,
    [AccessFailedCount]    INT             NOT NULL,
    [UserName]             NVARCHAR (256)  NOT NULL,
    [FirstName]            NVARCHAR (100)  NULL,
    [LastName]             NVARCHAR (100)  NULL,
    [Salary]               DECIMAL (18, 2) NULL,
    [ImageUrl]             NVARCHAR (500)  NULL,
    [ManagerId]            NVARCHAR (128)  NULL,
    [DepartementId]        INT             NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AspNetUsers_Department] FOREIGN KEY ([DepartementId]) REFERENCES [dbo].[Department] ([Id]),
    CONSTRAINT [FK_AspNetUsers_Manager] FOREIGN KEY ([ManagerId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([UserName] ASC);

