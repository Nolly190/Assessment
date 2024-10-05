IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [BookReservations] (
    [Id] int NOT NULL IDENTITY,
    [BookId] int NOT NULL,
    [CustomerId] int NOT NULL,
    [Status] int NOT NULL,
    [ExpectedDateOfReturn] datetime2 NULL,
    [DateCreated] datetime2 NOT NULL,
    [LastModified] datetime2 NOT NULL,
    CONSTRAINT [PK_BookReservations] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Books] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Authur] nvarchar(100) NOT NULL,
    [DatePublished] datetime2 NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [LastModified] datetime2 NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(100) NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [PhoneNumber] nvarchar(15) NOT NULL,
    [CustomerType] int NOT NULL,
    [Salt] nvarchar(1000) NOT NULL,
    [Password] nvarchar(1000) NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [LastModified] datetime2 NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241002194845_first-migration', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [BookReservations] ADD [IsReturned] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241003050123_IsReturnedColumnAdded', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BookReservations]') AND [c].[name] = N'Status');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [BookReservations] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [BookReservations] DROP COLUMN [Status];
GO

ALTER TABLE [Users] ADD [LoginFailedCount] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Books] ADD [Status] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [BookReservationNotifications] (
    [Id] int NOT NULL IDENTITY,
    [BookId] int NOT NULL,
    [CustomerId] int NOT NULL,
    [IsNotified] bit NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [LastModified] datetime2 NOT NULL,
    CONSTRAINT [PK_BookReservationNotifications] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Permissions] (
    [Id] smallint NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Permissions] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [RolePermission] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] smallint NOT NULL,
    [PermissionId] smallint NOT NULL,
    [IsDeleted] bit NOT NULL,
    [DateDeleted] datetime2 NULL,
    [DateCreated] datetime2 NOT NULL,
    [LastModified] datetime2 NOT NULL,
    CONSTRAINT [PK_RolePermission] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [IsDeleted] bit NOT NULL,
    [DateDeleted] datetime2 NULL,
    [DateCreated] datetime2 NOT NULL,
    [LastModified] datetime2 NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [UserInRoles] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [RoleId] smallint NOT NULL,
    [IsDeleted] bit NOT NULL,
    [DateDeleted] datetime2 NULL,
    [DateCreated] datetime2 NOT NULL,
    [LastModified] datetime2 NOT NULL,
    CONSTRAINT [PK_UserInRoles] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Users_CustomerType] ON [Users] ([CustomerType]);
GO

CREATE INDEX [IX_Users_Email] ON [Users] ([Email]);
GO

CREATE INDEX [IX_Users_PhoneNumber] ON [Users] ([PhoneNumber]);
GO

CREATE INDEX [IX_Books_Authur] ON [Books] ([Authur]);
GO

CREATE INDEX [IX_Books_Name] ON [Books] ([Name]);
GO

CREATE INDEX [IX_BookReservations_BookId] ON [BookReservations] ([BookId]);
GO

CREATE INDEX [IX_BookReservations_CustomerId] ON [BookReservations] ([CustomerId]);
GO

CREATE INDEX [IX_Permissions_Name] ON [Permissions] ([Name]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241003193625_AddedAuthorizationTables', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsDeleted', N'Name') AND [object_id] = OBJECT_ID(N'[Permissions]'))
    SET IDENTITY_INSERT [Permissions] ON;
INSERT INTO [Permissions] ([Id], [IsDeleted], [Name])
VALUES (CAST(1 AS smallint), CAST(0 AS bit), N'AddBook'),
(CAST(2 AS smallint), CAST(0 AS bit), N'GetBook'),
(CAST(3 AS smallint), CAST(0 AS bit), N'SearchBook'),
(CAST(4 AS smallint), CAST(0 AS bit), N'BookReturn'),
(CAST(5 AS smallint), CAST(0 AS bit), N'ReservationNotification'),
(CAST(6 AS smallint), CAST(0 AS bit), N'BookCollection'),
(CAST(7 AS smallint), CAST(0 AS bit), N'ReserveBook');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsDeleted', N'Name') AND [object_id] = OBJECT_ID(N'[Permissions]'))
    SET IDENTITY_INSERT [Permissions] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'DateDeleted', N'IsDeleted', N'LastModified', N'PermissionId', N'RoleId') AND [object_id] = OBJECT_ID(N'[RolePermission]'))
    SET IDENTITY_INSERT [RolePermission] ON;
INSERT INTO [RolePermission] ([Id], [DateCreated], [DateDeleted], [IsDeleted], [LastModified], [PermissionId], [RoleId])
VALUES (1, '2024-10-04T03:54:17.1153725Z', NULL, CAST(0 AS bit), '2024-10-04T03:54:17.1153726Z', CAST(1 AS smallint), CAST(1 AS smallint)),
(2, '2024-10-04T03:54:17.1153729Z', NULL, CAST(0 AS bit), '2024-10-04T03:54:17.1153729Z', CAST(2 AS smallint), CAST(1 AS smallint)),
(3, '2024-10-04T03:54:17.1153731Z', NULL, CAST(0 AS bit), '2024-10-04T03:54:17.1153731Z', CAST(3 AS smallint), CAST(1 AS smallint)),
(4, '2024-10-04T03:54:17.1153732Z', NULL, CAST(0 AS bit), '2024-10-04T03:54:17.1153733Z', CAST(4 AS smallint), CAST(1 AS smallint)),
(5, '2024-10-04T03:54:17.1153734Z', NULL, CAST(0 AS bit), '2024-10-04T03:54:17.1153734Z', CAST(5 AS smallint), CAST(1 AS smallint)),
(6, '2024-10-04T03:54:17.1153737Z', NULL, CAST(0 AS bit), '2024-10-04T03:54:17.1153737Z', CAST(2 AS smallint), CAST(2 AS smallint)),
(7, '2024-10-04T03:54:17.1153738Z', NULL, CAST(0 AS bit), '2024-10-04T03:54:17.1153738Z', CAST(3 AS smallint), CAST(2 AS smallint)),
(8, '2024-10-04T03:54:17.1153740Z', NULL, CAST(0 AS bit), '2024-10-04T03:54:17.1153740Z', CAST(7 AS smallint), CAST(2 AS smallint)),
(9, '2024-10-04T03:54:17.1153741Z', NULL, CAST(0 AS bit), '2024-10-04T03:54:17.1153742Z', CAST(5 AS smallint), CAST(2 AS smallint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'DateDeleted', N'IsDeleted', N'LastModified', N'PermissionId', N'RoleId') AND [object_id] = OBJECT_ID(N'[RolePermission]'))
    SET IDENTITY_INSERT [RolePermission] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'DateDeleted', N'IsDeleted', N'LastModified', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Id], [DateCreated], [DateDeleted], [IsDeleted], [LastModified], [Name])
VALUES (1, '2024-10-04T03:54:17.1154158Z', NULL, CAST(0 AS bit), '2024-10-04T03:54:17.1154159Z', N'Admin'),
(2, '2024-10-04T03:54:17.1154162Z', NULL, CAST(0 AS bit), '2024-10-04T03:54:17.1154162Z', N'User');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'DateDeleted', N'IsDeleted', N'LastModified', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'DateDeleted', N'IsDeleted', N'LastModified', N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[UserInRoles]'))
    SET IDENTITY_INSERT [UserInRoles] ON;
INSERT INTO [UserInRoles] ([Id], [DateCreated], [DateDeleted], [IsDeleted], [LastModified], [RoleId], [UserId])
VALUES (1, '2024-10-04T03:54:17.1155146Z', NULL, CAST(0 AS bit), '2024-10-04T03:54:17.1155147Z', CAST(1 AS smallint), 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'DateDeleted', N'IsDeleted', N'LastModified', N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[UserInRoles]'))
    SET IDENTITY_INSERT [UserInRoles] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241004035417_seedData', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Books].[Authur]', N'Author', N'COLUMN';
GO

EXEC sp_rename N'[Books].[IX_Books_Authur]', N'IX_Books_Author', N'INDEX';
GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-04T04:38:19.8147685Z', [LastModified] = '2024-10-04T04:38:19.8147685Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-04T04:38:19.8147688Z', [LastModified] = '2024-10-04T04:38:19.8147688Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-04T04:38:19.8147690Z', [LastModified] = '2024-10-04T04:38:19.8147690Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-04T04:38:19.8147691Z', [LastModified] = '2024-10-04T04:38:19.8147691Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-04T04:38:19.8147695Z', [LastModified] = '2024-10-04T04:38:19.8147695Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-04T04:38:19.8147699Z', [LastModified] = '2024-10-04T04:38:19.8147700Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-04T04:38:19.8147701Z', [LastModified] = '2024-10-04T04:38:19.8147701Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-04T04:38:19.8147702Z', [LastModified] = '2024-10-04T04:38:19.8147703Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-04T04:38:19.8147705Z', [LastModified] = '2024-10-04T04:38:19.8147705Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'DateDeleted', N'IsDeleted', N'LastModified', N'PermissionId', N'RoleId') AND [object_id] = OBJECT_ID(N'[RolePermission]'))
    SET IDENTITY_INSERT [RolePermission] ON;
INSERT INTO [RolePermission] ([Id], [DateCreated], [DateDeleted], [IsDeleted], [LastModified], [PermissionId], [RoleId])
VALUES (10, '2024-10-04T04:38:19.8147698Z', NULL, CAST(0 AS bit), '2024-10-04T04:38:19.8147698Z', CAST(6 AS smallint), CAST(1 AS smallint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'DateDeleted', N'IsDeleted', N'LastModified', N'PermissionId', N'RoleId') AND [object_id] = OBJECT_ID(N'[RolePermission]'))
    SET IDENTITY_INSERT [RolePermission] OFF;
GO

UPDATE [Roles] SET [DateCreated] = '2024-10-04T04:38:19.8148029Z', [LastModified] = '2024-10-04T04:38:19.8148030Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Roles] SET [DateCreated] = '2024-10-04T04:38:19.8148032Z', [LastModified] = '2024-10-04T04:38:19.8148032Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [UserInRoles] SET [DateCreated] = '2024-10-04T04:38:19.8148919Z', [LastModified] = '2024-10-04T04:38:19.8148919Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241004043820_AuthorColumnRenamed', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsDeleted', N'Name') AND [object_id] = OBJECT_ID(N'[Permissions]'))
    SET IDENTITY_INSERT [Permissions] ON;
INSERT INTO [Permissions] ([Id], [IsDeleted], [Name])
VALUES (CAST(8 AS smallint), CAST(0 AS bit), N'GetReservation'),
(CAST(9 AS smallint), CAST(0 AS bit), N'GetAllReservations'),
(CAST(10 AS smallint), CAST(0 AS bit), N'GetAllReservationNotifications'),
(CAST(11 AS smallint), CAST(0 AS bit), N'GetAllUsers'),
(CAST(12 AS smallint), CAST(0 AS bit), N'GetSingleUser'),
(CAST(13 AS smallint), CAST(0 AS bit), N'BlockUser'),
(CAST(14 AS smallint), CAST(0 AS bit), N'CreateRole'),
(CAST(15 AS smallint), CAST(0 AS bit), N'UsersInRole'),
(CAST(16 AS smallint), CAST(0 AS bit), N'AddUserToRole'),
(CAST(17 AS smallint), CAST(0 AS bit), N'ViewAllPermission'),
(CAST(18 AS smallint), CAST(0 AS bit), N'RemoveUserFromRole'),
(CAST(19 AS smallint), CAST(0 AS bit), N'ViewAllRoles'),
(CAST(20 AS smallint), CAST(0 AS bit), N'RemoveRole');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsDeleted', N'Name') AND [object_id] = OBJECT_ID(N'[Permissions]'))
    SET IDENTITY_INSERT [Permissions] OFF;
GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:20:03.3090050Z', [LastModified] = '2024-10-05T08:20:03.3090051Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:20:03.3090053Z', [LastModified] = '2024-10-05T08:20:03.3090053Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:20:03.3090055Z', [LastModified] = '2024-10-05T08:20:03.3090055Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:20:03.3090057Z', [LastModified] = '2024-10-05T08:20:03.3090057Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:20:03.3090058Z', [LastModified] = '2024-10-05T08:20:03.3090059Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:20:03.3090083Z', [LastModified] = '2024-10-05T08:20:03.3090084Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:20:03.3090085Z', [LastModified] = '2024-10-05T08:20:03.3090085Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:20:03.3090086Z', [LastModified] = '2024-10-05T08:20:03.3090087Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:20:03.3090088Z', [LastModified] = '2024-10-05T08:20:03.3090088Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:20:03.3090061Z', [LastModified] = '2024-10-05T08:20:03.3090062Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'DateDeleted', N'IsDeleted', N'LastModified', N'PermissionId', N'RoleId') AND [object_id] = OBJECT_ID(N'[RolePermission]'))
    SET IDENTITY_INSERT [RolePermission] ON;
INSERT INTO [RolePermission] ([Id], [DateCreated], [DateDeleted], [IsDeleted], [LastModified], [PermissionId], [RoleId])
VALUES (11, '2024-10-05T08:20:03.3090063Z', NULL, CAST(0 AS bit), '2024-10-05T08:20:03.3090063Z', CAST(9 AS smallint), CAST(1 AS smallint)),
(12, '2024-10-05T08:20:03.3090064Z', NULL, CAST(0 AS bit), '2024-10-05T08:20:03.3090065Z', CAST(10 AS smallint), CAST(1 AS smallint)),
(13, '2024-10-05T08:20:03.3090066Z', NULL, CAST(0 AS bit), '2024-10-05T08:20:03.3090066Z', CAST(11 AS smallint), CAST(1 AS smallint)),
(14, '2024-10-05T08:20:03.3090069Z', NULL, CAST(0 AS bit), '2024-10-05T08:20:03.3090069Z', CAST(12 AS smallint), CAST(1 AS smallint)),
(15, '2024-10-05T08:20:03.3090070Z', NULL, CAST(0 AS bit), '2024-10-05T08:20:03.3090071Z', CAST(13 AS smallint), CAST(1 AS smallint)),
(16, '2024-10-05T08:20:03.3090072Z', NULL, CAST(0 AS bit), '2024-10-05T08:20:03.3090072Z', CAST(14 AS smallint), CAST(1 AS smallint)),
(17, '2024-10-05T08:20:03.3090073Z', NULL, CAST(0 AS bit), '2024-10-05T08:20:03.3090074Z', CAST(15 AS smallint), CAST(1 AS smallint)),
(18, '2024-10-05T08:20:03.3090075Z', NULL, CAST(0 AS bit), '2024-10-05T08:20:03.3090075Z', CAST(16 AS smallint), CAST(1 AS smallint)),
(19, '2024-10-05T08:20:03.3090077Z', NULL, CAST(0 AS bit), '2024-10-05T08:20:03.3090077Z', CAST(17 AS smallint), CAST(1 AS smallint)),
(20, '2024-10-05T08:20:03.3090078Z', NULL, CAST(0 AS bit), '2024-10-05T08:20:03.3090078Z', CAST(18 AS smallint), CAST(1 AS smallint)),
(21, '2024-10-05T08:20:03.3090080Z', NULL, CAST(0 AS bit), '2024-10-05T08:20:03.3090080Z', CAST(19 AS smallint), CAST(1 AS smallint)),
(22, '2024-10-05T08:20:03.3090082Z', NULL, CAST(0 AS bit), '2024-10-05T08:20:03.3090082Z', CAST(20 AS smallint), CAST(1 AS smallint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'DateDeleted', N'IsDeleted', N'LastModified', N'PermissionId', N'RoleId') AND [object_id] = OBJECT_ID(N'[RolePermission]'))
    SET IDENTITY_INSERT [RolePermission] OFF;
GO

UPDATE [Roles] SET [DateCreated] = '2024-10-05T08:20:03.3090453Z', [LastModified] = '2024-10-05T08:20:03.3090453Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Roles] SET [DateCreated] = '2024-10-05T08:20:03.3090456Z', [LastModified] = '2024-10-05T08:20:03.3090456Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [UserInRoles] SET [DateCreated] = '2024-10-05T08:20:03.3091496Z', [LastModified] = '2024-10-05T08:20:03.3091497Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241005082003_permissionExtention', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879719Z', [LastModified] = '2024-10-05T08:23:13.3879719Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879721Z', [LastModified] = '2024-10-05T08:23:13.3879722Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879723Z', [LastModified] = '2024-10-05T08:23:13.3879723Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879725Z', [LastModified] = '2024-10-05T08:23:13.3879725Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879726Z', [LastModified] = '2024-10-05T08:23:13.3879726Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879757Z', [LastModified] = '2024-10-05T08:23:13.3879757Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879759Z', [LastModified] = '2024-10-05T08:23:13.3879759Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879760Z', [LastModified] = '2024-10-05T08:23:13.3879760Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879761Z', [LastModified] = '2024-10-05T08:23:13.3879762Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879729Z', [LastModified] = '2024-10-05T08:23:13.3879729Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879732Z', [LastModified] = '2024-10-05T08:23:13.3879732Z'
WHERE [Id] = 11;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879740Z', [LastModified] = '2024-10-05T08:23:13.3879740Z'
WHERE [Id] = 12;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879742Z', [LastModified] = '2024-10-05T08:23:13.3879742Z'
WHERE [Id] = 13;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879743Z', [LastModified] = '2024-10-05T08:23:13.3879744Z'
WHERE [Id] = 14;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879745Z', [LastModified] = '2024-10-05T08:23:13.3879745Z'
WHERE [Id] = 15;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879746Z', [LastModified] = '2024-10-05T08:23:13.3879746Z'
WHERE [Id] = 16;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879748Z', [LastModified] = '2024-10-05T08:23:13.3879748Z'
WHERE [Id] = 17;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879749Z', [LastModified] = '2024-10-05T08:23:13.3879749Z'
WHERE [Id] = 18;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879750Z', [LastModified] = '2024-10-05T08:23:13.3879751Z'
WHERE [Id] = 19;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879752Z', [LastModified] = '2024-10-05T08:23:13.3879752Z'
WHERE [Id] = 20;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879754Z', [LastModified] = '2024-10-05T08:23:13.3879755Z'
WHERE [Id] = 21;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T08:23:13.3879756Z', [LastModified] = '2024-10-05T08:23:13.3879756Z'
WHERE [Id] = 22;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'DateDeleted', N'IsDeleted', N'LastModified', N'PermissionId', N'RoleId') AND [object_id] = OBJECT_ID(N'[RolePermission]'))
    SET IDENTITY_INSERT [RolePermission] ON;
INSERT INTO [RolePermission] ([Id], [DateCreated], [DateDeleted], [IsDeleted], [LastModified], [PermissionId], [RoleId])
VALUES (23, '2024-10-05T08:23:13.3879730Z', NULL, CAST(0 AS bit), '2024-10-05T08:23:13.3879730Z', CAST(8 AS smallint), CAST(1 AS smallint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateCreated', N'DateDeleted', N'IsDeleted', N'LastModified', N'PermissionId', N'RoleId') AND [object_id] = OBJECT_ID(N'[RolePermission]'))
    SET IDENTITY_INSERT [RolePermission] OFF;
GO

UPDATE [Roles] SET [DateCreated] = '2024-10-05T08:23:13.3880075Z', [LastModified] = '2024-10-05T08:23:13.3880076Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Roles] SET [DateCreated] = '2024-10-05T08:23:13.3880078Z', [LastModified] = '2024-10-05T08:23:13.3880078Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [UserInRoles] SET [DateCreated] = '2024-10-05T08:23:13.3880988Z', [LastModified] = '2024-10-05T08:23:13.3880989Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241005082313_addedReservationPermissionToAdmin', N'8.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Users] ADD [IsBanned] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737450Z', [LastModified] = '2024-10-05T12:28:05.3737450Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737453Z', [LastModified] = '2024-10-05T12:28:05.3737453Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737455Z', [LastModified] = '2024-10-05T12:28:05.3737455Z'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737457Z', [LastModified] = '2024-10-05T12:28:05.3737457Z'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737459Z', [LastModified] = '2024-10-05T12:28:05.3737459Z'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737487Z', [LastModified] = '2024-10-05T12:28:05.3737487Z'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737488Z', [LastModified] = '2024-10-05T12:28:05.3737489Z'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737490Z', [LastModified] = '2024-10-05T12:28:05.3737490Z'
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737492Z', [LastModified] = '2024-10-05T12:28:05.3737492Z'
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737462Z', [LastModified] = '2024-10-05T12:28:05.3737462Z'
WHERE [Id] = 10;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737465Z', [LastModified] = '2024-10-05T12:28:05.3737466Z'
WHERE [Id] = 11;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737467Z', [LastModified] = '2024-10-05T12:28:05.3737467Z'
WHERE [Id] = 12;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737470Z', [LastModified] = '2024-10-05T12:28:05.3737470Z'
WHERE [Id] = 13;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737471Z', [LastModified] = '2024-10-05T12:28:05.3737472Z'
WHERE [Id] = 14;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737473Z', [LastModified] = '2024-10-05T12:28:05.3737473Z'
WHERE [Id] = 15;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737475Z', [LastModified] = '2024-10-05T12:28:05.3737475Z'
WHERE [Id] = 16;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737476Z', [LastModified] = '2024-10-05T12:28:05.3737477Z'
WHERE [Id] = 17;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737478Z', [LastModified] = '2024-10-05T12:28:05.3737478Z'
WHERE [Id] = 18;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737480Z', [LastModified] = '2024-10-05T12:28:05.3737480Z'
WHERE [Id] = 19;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737481Z', [LastModified] = '2024-10-05T12:28:05.3737482Z'
WHERE [Id] = 20;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737484Z', [LastModified] = '2024-10-05T12:28:05.3737484Z'
WHERE [Id] = 21;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737485Z', [LastModified] = '2024-10-05T12:28:05.3737486Z'
WHERE [Id] = 22;
SELECT @@ROWCOUNT;

GO

UPDATE [RolePermission] SET [DateCreated] = '2024-10-05T12:28:05.3737464Z', [LastModified] = '2024-10-05T12:28:05.3737464Z'
WHERE [Id] = 23;
SELECT @@ROWCOUNT;

GO

UPDATE [Roles] SET [DateCreated] = '2024-10-05T12:28:05.3737958Z', [LastModified] = '2024-10-05T12:28:05.3737958Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Roles] SET [DateCreated] = '2024-10-05T12:28:05.3737961Z', [LastModified] = '2024-10-05T12:28:05.3737961Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [UserInRoles] SET [DateCreated] = '2024-10-05T12:28:05.3739060Z', [LastModified] = '2024-10-05T12:28:05.3739061Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_BookReservationNotifications_BookId] ON [BookReservationNotifications] ([BookId]);
GO

CREATE INDEX [IX_BookReservationNotifications_CustomerId] ON [BookReservationNotifications] ([CustomerId]);
GO

ALTER TABLE [BookReservationNotifications] ADD CONSTRAINT [FK_BookReservationNotifications_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [BookReservationNotifications] ADD CONSTRAINT [FK_BookReservationNotifications_Users_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [BookReservations] ADD CONSTRAINT [FK_BookReservations_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [BookReservations] ADD CONSTRAINT [FK_BookReservations_Users_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241005122805_configuredEntityRelationship', N'8.0.8');
GO

COMMIT;
GO

