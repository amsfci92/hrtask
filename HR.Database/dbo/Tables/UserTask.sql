CREATE TABLE [dbo].[UserTask] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [TaskId]     BIGINT         NULL,
    [UserId]     NVARCHAR (128) NULL,
    [ManagerId]  NVARCHAR (128) NULL,
    [CreateDate] DATETIME       NULL,
    CONSTRAINT [PK_UserTask] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserTask_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

