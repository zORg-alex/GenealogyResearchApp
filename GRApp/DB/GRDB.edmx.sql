
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/27/2018 16:08:16
-- Generated from EDMX file: C:\Users\AUljanovs\Documents\GitHub\GenealogyResearchApp\GRApp\DB\GRDB.edmx
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
IF OBJECT_ID(N'[dbo].[FK_EventPlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_EventPlace];
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

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Persons'
CREATE TABLE [dbo].[Persons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [BirthDate] datetime  NOT NULL,
    [DeathDate] datetime  NOT NULL,
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
    [Parent_Id] int  NULL
);
GO

-- Creating table 'EventPerson'
CREATE TABLE [dbo].[EventPerson] (
    [EventsAttended_Id] int  NOT NULL,
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

-- Creating primary key on [EventsAttended_Id], [Attendees_Id] in table 'EventPerson'
ALTER TABLE [dbo].[EventPerson]
ADD CONSTRAINT [PK_EventPerson]
    PRIMARY KEY CLUSTERED ([EventsAttended_Id], [Attendees_Id] ASC);
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

-- Creating foreign key on [Parent_Id] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [FK_PlacePlace]
    FOREIGN KEY ([Parent_Id])
    REFERENCES [dbo].[Places]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlacePlace'
CREATE INDEX [IX_FK_PlacePlace]
ON [dbo].[Places]
    ([Parent_Id]);
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

-- Creating foreign key on [EventsAttended_Id] in table 'EventPerson'
ALTER TABLE [dbo].[EventPerson]
ADD CONSTRAINT [FK_EventPerson_Event]
    FOREIGN KEY ([EventsAttended_Id])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Attendees_Id] in table 'EventPerson'
ALTER TABLE [dbo].[EventPerson]
ADD CONSTRAINT [FK_EventPerson_Person]
    FOREIGN KEY ([Attendees_Id])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventPerson_Person'
CREATE INDEX [IX_FK_EventPerson_Person]
ON [dbo].[EventPerson]
    ([Attendees_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------