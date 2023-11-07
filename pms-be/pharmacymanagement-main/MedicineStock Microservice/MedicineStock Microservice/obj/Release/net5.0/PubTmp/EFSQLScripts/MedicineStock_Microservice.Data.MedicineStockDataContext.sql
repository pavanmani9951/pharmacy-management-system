﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824093551_IntialDB')
BEGIN
    CREATE TABLE [MedicineStock] (
        [Name] nvarchar(450) NOT NULL,
        [ChemicalComposition] VARCHAR(250) NULL,
        [TargetAilment] nvarchar(max) NULL,
        [DateOfExpiry] datetime2 NOT NULL,
        [NumberOfTabletsInStock] int NOT NULL,
        CONSTRAINT [PK_MedicineStock] PRIMARY KEY ([Name])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220824093551_IntialDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220824093551_IntialDB', N'5.0.12');
END;
GO

COMMIT;
GO

