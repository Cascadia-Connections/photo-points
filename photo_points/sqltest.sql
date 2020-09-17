IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [PhotoPoints] (
    [PhotoPointID] bigint NOT NULL IDENTITY,
    [LocationName] nvarchar(max) NOT NULL,
    [Feature] int NOT NULL,
    CONSTRAINT [PK_PhotoPoints] PRIMARY KEY ([PhotoPointID])
);

GO

CREATE TABLE [Users] (
    [UserID] bigint NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NULL,
    [Role] int NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserID])
);

GO

CREATE TABLE [Captures] (
    [CaptureID] bigint NOT NULL IDENTITY,
    [Photo] varbinary(max) NOT NULL,
    [CaptureDate] datetime2 NOT NULL,
    [Approval] int NOT NULL,
    [UserID] bigint NULL,
    [PhotoPointID] bigint NULL,
    CONSTRAINT [PK_Captures] PRIMARY KEY ([CaptureID]),
    CONSTRAINT [FK_Captures_PhotoPoints_PhotoPointID] FOREIGN KEY ([PhotoPointID]) REFERENCES [PhotoPoints] ([PhotoPointID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Captures_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Datas] (
    [DataID] bigint NOT NULL IDENTITY,
    [Type] nvarchar(max) NULL,
    [Value] nvarchar(max) NULL,
    [Comment] nvarchar(max) NULL,
    [CaptureID] bigint NULL,
    CONSTRAINT [PK_Datas] PRIMARY KEY ([DataID]),
    CONSTRAINT [FK_Datas_Captures_CaptureID] FOREIGN KEY ([CaptureID]) REFERENCES [Captures] ([CaptureID]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Notes] (
    [noteID] bigint NOT NULL IDENTITY,
    [noteComment] nvarchar(max) NULL,
    [CaptureID] bigint NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY ([noteID]),
    CONSTRAINT [FK_Notes_Captures_CaptureID] FOREIGN KEY ([CaptureID]) REFERENCES [Captures] ([CaptureID]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Tags] (
    [TagID] bigint NOT NULL IDENTITY,
    [TagName] nvarchar(max) NOT NULL,
    [UserID] bigint NULL,
    [CaptureID] bigint NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([TagID]),
    CONSTRAINT [FK_Tags_Captures_CaptureID] FOREIGN KEY ([CaptureID]) REFERENCES [Captures] ([CaptureID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Tags_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Captures_PhotoPointID] ON [Captures] ([PhotoPointID]);

GO

CREATE INDEX [IX_Captures_UserID] ON [Captures] ([UserID]);

GO

CREATE INDEX [IX_Datas_CaptureID] ON [Datas] ([CaptureID]);

GO

CREATE INDEX [IX_Notes_CaptureID] ON [Notes] ([CaptureID]);

GO

CREATE INDEX [IX_Tags_CaptureID] ON [Tags] ([CaptureID]);

GO

CREATE INDEX [IX_Tags_UserID] ON [Tags] ([UserID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200608190944_initial migration', N'3.1.3');

GO

ALTER TABLE [Tags] DROP CONSTRAINT [FK_Tags_Users_UserID];

GO

DROP INDEX [IX_Tags_UserID] ON [Tags];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tags]') AND [c].[name] = N'UserID');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Tags] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Tags] DROP COLUMN [UserID];

GO

CREATE TABLE [UserTags] (
    [TagID] bigint NOT NULL,
    [UserID] bigint NOT NULL,
    CONSTRAINT [PK_UserTags] PRIMARY KEY ([UserID], [TagID]),
    CONSTRAINT [FK_UserTags_Tags_TagID] FOREIGN KEY ([TagID]) REFERENCES [Tags] ([TagID]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserTags_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_UserTags_TagID] ON [UserTags] ([TagID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200610013739_usertagstable', N'3.1.3');

GO

