
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/18/2018 19:34:54
-- Generated from EDMX file: C:\Users\zORg\Desktop\GenealogyResearchApp\GRApp\DB\GRDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GRDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PersonEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_PersonEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_EventPersons_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventPersons] DROP CONSTRAINT [FK_EventPersons_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_EventPersons_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventPersons] DROP CONSTRAINT [FK_EventPersons_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonMother]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_PersonMother];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonFather]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_PersonFather];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_PersonPlace];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonDeathPlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_PersonDeathPlace];
GO
IF OBJECT_ID(N'[dbo].[FK_PlacePlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Places] DROP CONSTRAINT [FK_PlacePlace];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Persons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persons];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[Places]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Places];
GO
IF OBJECT_ID(N'[dbo].[EventPersons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventPersons];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Persons'
CREATE TABLE [dbo].[Persons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [BirthDate] nvarchar(max)  NOT NULL,
    [DeathDate] nvarchar(max)  NOT NULL,
    [BirthPlaceId] int  NOT NULL,
    [DeathPlaceId] int  NOT NULL,
    [Mother_Id] int  NOT NULL,
    [Father_Id] int  NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [PersonId] int  NOT NULL,
    [Place_Id] int  NOT NULL
);
GO

-- Creating table 'Places'
CREATE TABLE [dbo].[Places] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PlaceId] int  NOT NULL
);
GO

-- Creating table 'EventPersons'
CREATE TABLE [dbo].[EventPersons] (
    [EventsAttented_Id] int  NOT NULL,
    [Attendees_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [PK_Persons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [PK_Places]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [EventsAttented_Id], [Attendees_Id] in table 'EventPersons'
ALTER TABLE [dbo].[EventPersons]
ADD CONSTRAINT [PK_EventPersons]
    PRIMARY KEY CLUSTERED ([EventsAttented_Id], [Attendees_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PersonId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_PersonEvent]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonEvent'
CREATE INDEX [IX_FK_PersonEvent]
ON [dbo].[Events]
    ([PersonId]);
GO

-- Creating foreign key on [EventsAttented_Id] in table 'EventPersons'
ALTER TABLE [dbo].[EventPersons]
ADD CONSTRAINT [FK_EventPersons_Event]
    FOREIGN KEY ([EventsAttented_Id])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Attendees_Id] in table 'EventPersons'
ALTER TABLE [dbo].[EventPersons]
ADD CONSTRAINT [FK_EventPersons_Person]
    FOREIGN KEY ([Attendees_Id])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventPersons_Person'
CREATE INDEX [IX_FK_EventPersons_Person]
ON [dbo].[EventPersons]
    ([Attendees_Id]);
GO

-- Creating foreign key on [Mother_Id] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_PersonMother]
    FOREIGN KEY ([Mother_Id])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonMother'
CREATE INDEX [IX_FK_PersonMother]
ON [dbo].[Persons]
    ([Mother_Id]);
GO

-- Creating foreign key on [Father_Id] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_PersonFather]
    FOREIGN KEY ([Father_Id])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonFather'
CREATE INDEX [IX_FK_PersonFather]
ON [dbo].[Persons]
    ([Father_Id]);
GO

-- Creating foreign key on [BirthPlaceId] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_PersonPlace]
    FOREIGN KEY ([BirthPlaceId])
    REFERENCES [dbo].[Places]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPlace'
CREATE INDEX [IX_FK_PersonPlace]
ON [dbo].[Persons]
    ([BirthPlaceId]);
GO

-- Creating foreign key on [DeathPlaceId] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_PersonDeathPlace]
    FOREIGN KEY ([DeathPlaceId])
    REFERENCES [dbo].[Places]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonDeathPlace'
CREATE INDEX [IX_FK_PersonDeathPlace]
ON [dbo].[Persons]
    ([DeathPlaceId]);
GO

-- Creating foreign key on [PlaceId] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [FK_PlacePlace]
    FOREIGN KEY ([PlaceId])
    REFERENCES [dbo].[Places]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlacePlace'
CREATE INDEX [IX_FK_PlacePlace]
ON [dbo].[Places]
    ([PlaceId]);
GO

-- Creating foreign key on [Place_Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_EventPlace]
    FOREIGN KEY ([Place_Id])
    REFERENCES [dbo].[Places]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventPlace'
CREATE INDEX [IX_FK_EventPlace]
ON [dbo].[Events]
    ([Place_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------