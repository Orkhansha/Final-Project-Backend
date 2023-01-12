IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [Aksesuars] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Image] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Aksesuars] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [FullName] nvarchar(max) NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [Banners] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Image] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        CONSTRAINT [PK_Banners] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [Blogs] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Desc] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [Brands] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Image] nvarchar(max) NULL,
        CONSTRAINT [PK_Brands] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [Colors] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Name] nvarchar(max) NULL,
        [Count] int NOT NULL,
        CONSTRAINT [PK_Colors] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [Geyims] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Image] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Geyims] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [Qarishiqs] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Image] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Qarishiqs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [Services] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Name] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        [Icon] nvarchar(max) NULL,
        CONSTRAINT [PK_Services] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [Sizes] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Name] nvarchar(max) NULL,
        [Count] int NOT NULL,
        CONSTRAINT [PK_Sizes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [Sliders] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Image] nvarchar(max) NULL,
        CONSTRAINT [PK_Sliders] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [Uniformas] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Image] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Uniformas] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [UnudulmazlarCards] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Image] nvarchar(max) NULL,
        [Video] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Rutbe] nvarchar(max) NULL,
        [Birthday] nvarchar(max) NULL,
        CONSTRAINT [PK_UnudulmazlarCards] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Image] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        [Description] nvarchar(max) NULL,
        [ColorId] int NULL,
        [SizeId] int NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_Colors_ColorId] FOREIGN KEY ([ColorId]) REFERENCES [Colors] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Products_Sizes_SizeId] FOREIGN KEY ([SizeId]) REFERENCES [Sizes] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [BasketItems] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [ProductId] int NOT NULL,
        [AppUserId] nvarchar(450) NULL,
        [Count] int NOT NULL,
        CONSTRAINT [PK_BasketItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BasketItems_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_BasketItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [ProductCategories] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [ProductId] int NOT NULL,
        [CategoryId] int NOT NULL,
        CONSTRAINT [PK_ProductCategories] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductCategories_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProductCategories_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE TABLE [ProductImages] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Image] nvarchar(max) NULL,
        [IsMain] bit NOT NULL,
        [ProductId] int NOT NULL,
        [CategoryId] int NOT NULL,
        CONSTRAINT [PK_ProductImages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductImages_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE INDEX [IX_BasketItems_AppUserId] ON [BasketItems] ([AppUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE INDEX [IX_BasketItems_ProductId] ON [BasketItems] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE INDEX [IX_ProductCategories_CategoryId] ON [ProductCategories] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE INDEX [IX_ProductCategories_ProductId] ON [ProductCategories] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE INDEX [IX_ProductImages_ProductId] ON [ProductImages] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE INDEX [IX_Products_ColorId] ON [Products] ([ColorId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    CREATE INDEX [IX_Products_SizeId] ON [Products] ([SizeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221228172303_AddedAllTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221228172303_AddedAllTables', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221229143752_DeleteFullnameColumn')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'FullName');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [FullName];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221229143752_DeleteFullnameColumn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221229143752_DeleteFullnameColumn', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221230181943_AddColumnToUnudulmazlar')
BEGIN
    ALTER TABLE [UnudulmazlarCards] ADD [Haqqında] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221230181943_AddColumnToUnudulmazlar')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221230181943_AddColumnToUnudulmazlar', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221231102001_CreateUnudulmazlarVideoTable')
BEGIN
    CREATE TABLE [UnudulmazlarVideo] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Image] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Rutbe] nvarchar(max) NULL,
        [Haqqında] nvarchar(max) NULL,
        [Birthday] nvarchar(max) NULL,
        CONSTRAINT [PK_UnudulmazlarVideo] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221231102001_CreateUnudulmazlarVideoTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221231102001_CreateUnudulmazlarVideoTable', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221231102309_AddColumnUnudulmazlarVideoTable')
BEGIN
    ALTER TABLE [UnudulmazlarVideo] ADD [Video] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221231102309_AddColumnUnudulmazlarVideoTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221231102309_AddColumnUnudulmazlarVideoTable', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221231123249_AddColumCatId')
BEGIN
    ALTER TABLE [Uniformas] ADD [CatId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221231123249_AddColumCatId')
BEGIN
    ALTER TABLE [Qarishiqs] ADD [CatId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221231123249_AddColumCatId')
BEGIN
    ALTER TABLE [Geyims] ADD [CatId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221231123249_AddColumCatId')
BEGIN
    ALTER TABLE [Aksesuars] ADD [CatId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221231123249_AddColumCatId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221231123249_AddColumCatId', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230102092158_DeleteSizeColorColumns')
BEGIN
    ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_Colors_ColorId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230102092158_DeleteSizeColorColumns')
BEGIN
    ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_Sizes_SizeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230102092158_DeleteSizeColorColumns')
BEGIN
    DROP INDEX [IX_Products_ColorId] ON [Products];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230102092158_DeleteSizeColorColumns')
BEGIN
    DROP INDEX [IX_Products_SizeId] ON [Products];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230102092158_DeleteSizeColorColumns')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'ColorId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Products] DROP COLUMN [ColorId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230102092158_DeleteSizeColorColumns')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'SizeId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Products] DROP COLUMN [SizeId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230102092158_DeleteSizeColorColumns')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230102092158_DeleteSizeColorColumns', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230103111550_updatingentity')
BEGIN
    ALTER TABLE [UnudulmazlarCards] ADD [Surname] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230103111550_updatingentity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230103111550_updatingentity', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230103141136_updateproducts')
BEGIN
    ALTER TABLE [Products] ADD [Stock] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230103141136_updateproducts')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230103141136_updateproducts', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106142252_updateproducttable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230106142252_updateproducttable', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106143832_updateproducttabled')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'Image');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Products] DROP COLUMN [Image];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106143832_updateproducttabled')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductImages]') AND [c].[name] = N'CategoryId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ProductImages] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [ProductImages] DROP COLUMN [CategoryId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106143832_updateproducttabled')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductImages]') AND [c].[name] = N'Image');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [ProductImages] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [ProductImages] DROP COLUMN [Image];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106143832_updateproducttabled')
BEGIN
    ALTER TABLE [ProductImages] ADD [ImageUrl] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106143832_updateproducttabled')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230106143832_updateproducttabled', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106154921_AddOrderTable')
BEGIN
    CREATE TABLE [Order] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Region] nvarchar(max) NULL,
        [City] nvarchar(max) NOT NULL,
        [Apartment] nvarchar(max) NOT NULL,
        [PostCode] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        [BankTransfer] bit NOT NULL,
        [CheckPayments] bit NOT NULL,
        [Paypal] bit NOT NULL,
        [CashOnDelivery] bit NOT NULL,
        [Message] nvarchar(max) NULL,
        [Country] nvarchar(max) NULL,
        [Address] nvarchar(max) NOT NULL,
        [TotalPrice] float NOT NULL,
        [Date] datetime2 NOT NULL,
        [Status] bit NULL,
        [AppUserId] nvarchar(450) NULL,
        CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Order_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106154921_AddOrderTable')
BEGIN
    CREATE TABLE [OrderItems] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [Title] nvarchar(max) NULL,
        [Price] float NOT NULL,
        [ProduuctId] int NULL,
        [AppUserId] nvarchar(450) NULL,
        [OrderId] int NOT NULL,
        [ProductId] int NULL,
        CONSTRAINT [PK_OrderItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OrderItems_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_OrderItems_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106154921_AddOrderTable')
BEGIN
    CREATE INDEX [IX_Order_AppUserId] ON [Order] ([AppUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106154921_AddOrderTable')
BEGIN
    CREATE INDEX [IX_OrderItems_AppUserId] ON [OrderItems] ([AppUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106154921_AddOrderTable')
BEGIN
    CREATE INDEX [IX_OrderItems_OrderId] ON [OrderItems] ([OrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106154921_AddOrderTable')
BEGIN
    CREATE INDEX [IX_OrderItems_ProductId] ON [OrderItems] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106154921_AddOrderTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230106154921_AddOrderTable', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106162348_AddOrderTables')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderItems]') AND [c].[name] = N'ProduuctId');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [OrderItems] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [OrderItems] DROP COLUMN [ProduuctId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106162348_AddOrderTables')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderItems]') AND [c].[name] = N'Price');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [OrderItems] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [OrderItems] ALTER COLUMN [Price] decimal(18,2) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106162348_AddOrderTables')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Order]') AND [c].[name] = N'TotalPrice');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Order] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Order] ALTER COLUMN [TotalPrice] decimal(18,2) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230106162348_AddOrderTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230106162348_AddOrderTables', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230109002058_CreateBlogTables')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogs]') AND [c].[name] = N'Desc');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Blogs] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Blogs] DROP COLUMN [Desc];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230109002058_CreateBlogTables')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogs]') AND [c].[name] = N'Name');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Blogs] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Blogs] DROP COLUMN [Name];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230109002058_CreateBlogTables')
BEGIN
    ALTER TABLE [Blogs] ADD [CreatedDate] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230109002058_CreateBlogTables')
BEGIN
    ALTER TABLE [Blogs] ADD [Description] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230109002058_CreateBlogTables')
BEGIN
    ALTER TABLE [Blogs] ADD [Images] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230109002058_CreateBlogTables')
BEGIN
    ALTER TABLE [Blogs] ADD [Title] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230109002058_CreateBlogTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230109002058_CreateBlogTables', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230110121756_CreateBlogImagesTable')
BEGIN
    DROP TABLE [Sizes];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230110121756_CreateBlogImagesTable')
BEGIN
    CREATE TABLE [BlogImages] (
        [Id] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [ImageUrl] nvarchar(max) NULL,
        [IsMain] bit NOT NULL,
        [BlogId] int NOT NULL,
        CONSTRAINT [PK_BlogImages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BlogImages_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230110121756_CreateBlogImagesTable')
BEGIN
    CREATE INDEX [IX_BlogImages_BlogId] ON [BlogImages] ([BlogId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230110121756_CreateBlogImagesTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230110121756_CreateBlogImagesTable', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230110153214_imagebugfix')
BEGIN
    DROP TABLE [ProductImages];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230110153214_imagebugfix')
BEGIN
    ALTER TABLE [Products] ADD [Image] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230110153214_imagebugfix')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230110153214_imagebugfix', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230111150032_AddColumnBrandsTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230111150032_AddColumnBrandsTable', N'3.1.29');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230111162858_AddColumnBlogsTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230111162858_AddColumnBlogsTable', N'3.1.29');
END;

GO

