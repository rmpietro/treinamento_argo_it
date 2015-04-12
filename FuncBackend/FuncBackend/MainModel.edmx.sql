
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/08/2015 08:37:42
-- Generated from EDMX file: c:\users\rampsoft\documents\visual studio 2013\Projects\FuncBackend\FuncBackend\MainModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Argo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ContatoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContatoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ContatoSet'
CREATE TABLE [dbo].[ContatoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(150)  NOT NULL,
    [Email] nvarchar(200)  NOT NULL,
    [Departamento] nvarchar(100)  NOT NULL,
    [Solicitacao] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FuncionarioSet'
CREATE TABLE [dbo].[FuncionarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Telefone] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ContatoSet'
ALTER TABLE [dbo].[ContatoSet]
ADD CONSTRAINT [PK_ContatoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FuncionarioSet'
ALTER TABLE [dbo].[FuncionarioSet]
ADD CONSTRAINT [PK_FuncionarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------