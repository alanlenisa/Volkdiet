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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [LAFParameters] (
        [ID] int NOT NULL IDENTITY,
        [LAF_Alg] varchar(1) NOT NULL,
        [LAF_Sex] varchar(1) NOT NULL,
        [LAF_AgeMin] int NOT NULL,
        [LAF_AgeMax] int NOT NULL,
        [LAF_Lvl] int NOT NULL,
        [LAF_Value] float NOT NULL,
        CONSTRAINT [PK_LAFParameters] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [Languages] (
        [ID] int NOT NULL IDENTITY,
        [LAN_Name] varchar(50) NULL,
        [LAN_Culture] varchar(50) NULL,
        [LAN_ImageName] varchar(200) NULL,
        [LAN_DisplayOrder] int NULL,
        CONSTRAINT [PK_Languages] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [Libraries] (
        [ID] int NOT NULL IDENTITY,
        [LIB_Desc] varchar(50) NULL,
        CONSTRAINT [PK_Libraries] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [Roles] (
        [ID] int NOT NULL IDENTITY,
        [ROL_Desc] varchar(50) NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [LocalizedStrings] (
        [ID] int NOT NULL IDENTITY,
        [LAN_ID] int NULL,
        [RES_Name] varchar(250) NULL,
        [RES_Value] varchar(max) NULL,
        CONSTRAINT [PK_LocalizedStrings] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_LocalizedStrings_Languages] FOREIGN KEY ([LAN_ID]) REFERENCES [Languages] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [LocalizedTables] (
        [ID] int NOT NULL IDENTITY,
        [LAN_ID] int NULL,
        [LTB_Table] varchar(50) NULL,
        [LTB_Property] varchar(50) NULL,
        [LTB_RecordID] int NULL,
        [LTB_Value] varchar(max) NULL,
        CONSTRAINT [PK_LocalizedTables] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_LocalizedTables_Languages] FOREIGN KEY ([LAN_ID]) REFERENCES [Languages] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [Categories] (
        [ID] int NOT NULL IDENTITY,
        [LIB_ID] int NOT NULL,
        [CAT_Desc] varchar(50) NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Categories_Libraries] FOREIGN KEY ([LIB_ID]) REFERENCES [Libraries] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [Tenants] (
        [ID] int NOT NULL IDENTITY,
        [LIB_ID] int NULL,
        [IsDeleted] bit NOT NULL,
        [TEN_Desc] varchar(200) NULL,
        [TEN_IsTemplate] bit NOT NULL,
        CONSTRAINT [PK_Tenants] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Tenants_Libraries] FOREIGN KEY ([LIB_ID]) REFERENCES [Libraries] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [RolesClaims] (
        [ID] int NOT NULL IDENTITY,
        [ROL_ID] int NULL,
        [RCL_Name] varchar(max) NULL,
        [RCL_Value] varchar(max) NULL,
        CONSTRAINT [PK_RolesClaims] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_RolesClaims_Roles] FOREIGN KEY ([ROL_ID]) REFERENCES [Roles] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [Aliments] (
        [ID] int NOT NULL IDENTITY,
        [ALI_Desc] varchar(250) NULL,
        [LIB_ID] int NULL,
        [CAT_ID] int NULL,
        [ALI_K] float NULL DEFAULT (((100))),
        [ALI_LastMod] datetime NULL,
        [ALI_KCal] float NULL,
        [ALI_Protein] float NULL,
        [ALI_Lipids] float NULL,
        [ALI_Choleterol] float NULL,
        [ALI_Glucides] float NULL,
        [ALI_Starch] float NULL,
        [ALI_Fiber] float NULL,
        [ALI_FibelSol] float NULL,
        [ALI_Alcool] float NULL,
        [ALI_Water] float NULL,
        [ALI_Iron] float NULL,
        [ALI_Calcium] float NULL,
        [ALI_Sodium] float NULL,
        [ALI_Potassium] float NULL,
        [ALI_Phosphorus] float NULL,
        [ALI_Zinc] float NULL,
        [ALI_Magnesium] float NULL,
        [ALI_Copper] float NULL,
        [ALI_Selenium] float NULL,
        [ALI_Chlorine] float NULL,
        [ALI_Iudium] float NULL,
        [ALI_TiaminaB1] float NULL,
        [ALI_RiboflavinaB2] float NULL,
        [ALI_VitC] float NULL,
        [ALI_NiacinaB3] float NULL,
        [ALI_VitB6] float NULL,
        [ALI_VitB12] float NULL,
        [ALI_VitAReteq] float NULL,
        [ALI_VitEReteq] float NULL,
        [ALI_VitE] float NULL,
        [ALI_ASatur] float NULL,
        [ALI_APoly] float NULL,
        [ALI_AMono] float NULL,
        [ALI_Glucose] float NULL,
        [ALI_Fructose] float NULL,
        [ALI_Galactose] float NULL,
        [ALI_Sucrose] float NULL,
        [ALI_Maltose] float NULL,
        [ALI_Lactose] float NULL,
        CONSTRAINT [PK_Aliments] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Aliments_Categories] FOREIGN KEY ([CAT_ID]) REFERENCES [Categories] ([ID]),
        CONSTRAINT [FK_Aliments_Libraries] FOREIGN KEY ([LIB_ID]) REFERENCES [Libraries] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [Meals] (
        [ID] int NOT NULL IDENTITY,
        [TEN_ID] int NOT NULL,
        [MEA_Desc] varchar(50) NULL,
        CONSTRAINT [PK_Meals] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Meals_Tenants1] FOREIGN KEY ([TEN_ID]) REFERENCES [Tenants] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [Users] (
        [ID] int NOT NULL IDENTITY,
        [IsDeleted] bit NOT NULL,
        [TEN_ID] int NOT NULL,
        [LAN_ID] int NULL,
        [USR_Login] varchar(50) NULL,
        [USR_Email] varchar(100) NULL,
        [USR_DtReg] datetime NULL,
        [USR_Step] varchar(1) NULL,
        [USR_PwdHash] varchar(100) NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Users_Languages] FOREIGN KEY ([LAN_ID]) REFERENCES [Languages] ([ID]),
        CONSTRAINT [FK_Users_Tenants] FOREIGN KEY ([TEN_ID]) REFERENCES [Tenants] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [DietTemplates] (
        [ID] int NOT NULL IDENTITY,
        [TEN_ID] int NOT NULL,
        [TEM_Desc] varchar(100) NULL,
        [TEM_PercCarbs] float NULL,
        [TEM_PercProts] float NULL,
        [TEM_PercFats] float NULL,
        CONSTRAINT [PK_DietTemplates] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_DietTemplates_Meals] FOREIGN KEY ([TEN_ID]) REFERENCES [Meals] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [Checkups] (
        [ID] int NOT NULL IDENTITY,
        [USR_ID] int NOT NULL,
        [CUP_Date] datetime NULL,
        [CUP_Heigth] float NULL,
        [CUP_Weight] float NULL,
        [CUP_LeanMass] float NULL,
        [CUP_FatMass] float NULL,
        [CUP_Mis1] float NULL,
        [CUP_Mis2] float NULL,
        [CUP_Mis3] float NULL,
        [CUP_Mis4] float NULL,
        CONSTRAINT [PK_Checkups] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Checkups_Users] FOREIGN KEY ([USR_ID]) REFERENCES [Users] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [Diets] (
        [ID] int NOT NULL IDENTITY,
        [TEN_ID] int NOT NULL,
        [USR_ID] int NOT NULL,
        [DIE_Desc] varchar(100) NULL,
        [DIE_Note] varchar(200) NULL,
        [DIE_Requirement] int NULL,
        [DIE_LastMod] datetime NULL,
        [DIE_PerCarbs] float NULL,
        [DIE_PerProts] float NULL,
        [DIE_PerFats] float NULL,
        CONSTRAINT [PK_Diets] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_Diets_Tenants] FOREIGN KEY ([TEN_ID]) REFERENCES [Tenants] ([ID]),
        CONSTRAINT [FK_Diets_Users] FOREIGN KEY ([USR_ID]) REFERENCES [Users] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [FoodIntollerances] (
        [ID] int NOT NULL IDENTITY,
        [USR_ID] int NOT NULL,
        [FIN_Desc] varchar(max) NOT NULL,
        [FIN_Severity] int NOT NULL,
        CONSTRAINT [PK_FoodIntollerances] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_FoodIntollerances_Users] FOREIGN KEY ([USR_ID]) REFERENCES [Users] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [UsersRoles] (
        [ID] int NOT NULL IDENTITY,
        [USR_ID] int NULL,
        [ROL_ID] int NULL,
        CONSTRAINT [PK_UsersRoles] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_UsersRoles_Roles] FOREIGN KEY ([ROL_ID]) REFERENCES [Roles] ([ID]),
        CONSTRAINT [FK_UsersRoles_Users] FOREIGN KEY ([USR_ID]) REFERENCES [Users] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [DietTemplateDetails] (
        [ID] int NOT NULL IDENTITY,
        [TEM_ID] int NOT NULL,
        [TED_Day] int NOT NULL,
        [MEA_ID] int NOT NULL,
        [TED_PercKCal] float NOT NULL,
        CONSTRAINT [PK_DietTemplateDetails] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_DietTemplateDetails_DietTemplates] FOREIGN KEY ([TEM_ID]) REFERENCES [DietTemplates] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [DietDailyMeals] (
        [ID] int NOT NULL IDENTITY,
        [DIE_ID] int NOT NULL,
        [DME_Day] int NOT NULL,
        [MEA_ID] int NOT NULL,
        [DME_Date] datetime NULL,
        CONSTRAINT [PK_DietDailyMeals] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_DietDailyMeals_Diets] FOREIGN KEY ([DIE_ID]) REFERENCES [Diets] ([ID]),
        CONSTRAINT [FK_DietDailyMeals_Meals] FOREIGN KEY ([MEA_ID]) REFERENCES [Meals] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE TABLE [DietDailyDetails] (
        [ID] int NOT NULL IDENTITY,
        [DME_ID] int NOT NULL,
        [ALI_ID] int NOT NULL,
        [DDE_Qty] float NOT NULL,
        CONSTRAINT [PK_DietDailyDetails] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_DietDailyDetails_Aliments] FOREIGN KEY ([ALI_ID]) REFERENCES [Aliments] ([ID]),
        CONSTRAINT [FK_DietDailyDetails_DietDailyMeals] FOREIGN KEY ([DME_ID]) REFERENCES [DietDailyMeals] ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_Aliments_CAT_ID] ON [Aliments] ([CAT_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_Aliments_LIB_ID] ON [Aliments] ([LIB_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_Categories_LIB_ID] ON [Categories] ([LIB_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_Checkups_USR_ID] ON [Checkups] ([USR_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_DietDailyDetails_ALI_ID] ON [DietDailyDetails] ([ALI_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_DietDailyDetails_DME_ID] ON [DietDailyDetails] ([DME_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_DietDailyMeals_DIE_ID] ON [DietDailyMeals] ([DIE_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_DietDailyMeals_MEA_ID] ON [DietDailyMeals] ([MEA_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_Diets_TEN_ID] ON [Diets] ([TEN_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_Diets_USR_ID] ON [Diets] ([USR_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_DietTemplateDetails_TEM_ID] ON [DietTemplateDetails] ([TEM_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_DietTemplates_TEN_ID] ON [DietTemplates] ([TEN_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_FoodIntollerances_USR_ID] ON [FoodIntollerances] ([USR_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_LocalizedStrings] ON [LocalizedStrings] ([LAN_ID], [RES_Name]) WHERE [LAN_ID] IS NOT NULL AND [RES_Name] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_LocalizedTables_LAN_ID] ON [LocalizedTables] ([LAN_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_Meals_TEN_ID] ON [Meals] ([TEN_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_RolesClaims_ROL_ID] ON [RolesClaims] ([ROL_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_Tenants_LIB_ID] ON [Tenants] ([LIB_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_Users_LAN_ID] ON [Users] ([LAN_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_Users_TEN_ID] ON [Users] ([TEN_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_UsersRoles_ROL_ID] ON [UsersRoles] ([ROL_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    CREATE INDEX [IX_UsersRoles_USR_ID] ON [UsersRoles] ([USR_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220719082417_InitialDbMsSql')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220719082417_InitialDbMsSql', N'6.0.7');
END;
GO

COMMIT;
GO

