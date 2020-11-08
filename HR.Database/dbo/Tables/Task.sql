CREATE TABLE [dbo].[Task] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (500) NULL,
    [EmployeeId]  NVARCHAR (128) NULL,
    [ManagerId]   NVARCHAR (128) NULL,
    [CreateDate]  DATETIME       NULL,
    [UpdateDate]  DATETIME       NULL,
    [StatusCode]  TINYINT        NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Task_AspNetUsers] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Task_AspNetUsers1] FOREIGN KEY ([ManagerId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

