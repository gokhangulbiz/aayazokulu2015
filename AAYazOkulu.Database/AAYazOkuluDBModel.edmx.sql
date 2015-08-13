
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/13/2015 13:17:45
-- Generated from EDMX file: C:\Users\Gokhan\Documents\GitHub\gokhangulbiz\AAYazOkulu\AAYazOkulu.Database\AAYazOkuluDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AAYazOkuluDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductCategory_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductCategory] DROP CONSTRAINT [FK_ProductCategory_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductCategory_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductCategory] DROP CONSTRAINT [FK_ProductCategory_Category];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO
IF OBJECT_ID(N'[dbo].[CategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategorySet];
GO
IF OBJECT_ID(N'[dbo].[ProductCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCategory];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [AddedDate] datetime  NOT NULL
);
GO

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductCategory'
CREATE TABLE [dbo].[ProductCategory] (
    [Products_Id] int  NOT NULL,
    [Categories_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Products_Id], [Categories_Id] in table 'ProductCategory'
ALTER TABLE [dbo].[ProductCategory]
ADD CONSTRAINT [PK_ProductCategory]
    PRIMARY KEY CLUSTERED ([Products_Id], [Categories_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Products_Id] in table 'ProductCategory'
ALTER TABLE [dbo].[ProductCategory]
ADD CONSTRAINT [FK_ProductCategory_Product]
    FOREIGN KEY ([Products_Id])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Categories_Id] in table 'ProductCategory'
ALTER TABLE [dbo].[ProductCategory]
ADD CONSTRAINT [FK_ProductCategory_Category]
    FOREIGN KEY ([Categories_Id])
    REFERENCES [dbo].[CategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCategory_Category'
CREATE INDEX [IX_FK_ProductCategory_Category]
ON [dbo].[ProductCategory]
    ([Categories_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------