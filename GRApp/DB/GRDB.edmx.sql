
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/20/2019 18:47:58
-- Generated from EDMX file: C:\Users\zORg\Source\Repos\GenealogyResearchApp\GRApp\DB\GRDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GenealogyResearchAppDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EventPersonAttended_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventPerson] DROP CONSTRAINT [FK_EventPersonAttended_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_EventPersonAttended_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventPerson] DROP CONSTRAINT [FK_EventPersonAttended_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_EventPlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_EventPlace];
GO
IF OBJECT_ID(N'[dbo].[FK_FirstNamePerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_FirstNamePerson];
GO
IF OBJECT_ID(N'[dbo].[FK_LastNamePerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_LastNamePerson];
GO
IF OBJECT_ID(N'[dbo].[FK_MiddleNamePerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_MiddleNamePerson];
GO
IF OBJECT_ID(N'[dbo].[FK_NameNameGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Names] DROP CONSTRAINT [FK_NameNameGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonBirthPlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_PersonBirthPlace];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonDeathPlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_PersonDeathPlace];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonFather]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_PersonFather];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonMother]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_PersonMother];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonsEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_PersonsEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_PlaceSubPlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Places] DROP CONSTRAINT [FK_PlaceSubPlace];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EventPerson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventPerson];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[NameGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NameGroups];
GO
IF OBJECT_ID(N'[dbo].[Names]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Names];
GO
IF OBJECT_ID(N'[dbo].[Persons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persons];
GO
IF OBJECT_ID(N'[dbo].[Places]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Places];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [PersonId] int  NOT NULL,
    [Place_Id] int  NOT NULL
);
GO

-- Creating table 'NameGroups'
CREATE TABLE [dbo].[NameGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PrimeName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Names'
CREATE TABLE [dbo].[Names] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameGroupId] int  NULL,
    [NameRaw] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Persons'
CREATE TABLE [dbo].[Persons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstnameRaw] nvarchar(max)  NOT NULL,
    [MiddlenameRaw] nvarchar(max)  NOT NULL,
    [LastnameRaw] nvarchar(max)  NOT NULL,
    [FirstNameId] int  NULL,
    [MiddleNameId] int  NULL,
    [LastNameId] int  NULL,
    [BirthDate] datetime  NULL,
    [DeathDate] datetime  NULL,
    [BirthPlaceId] int  NULL,
    [DeathPlaceId] int  NULL,
    [FatherId] int  NULL,
    [MotherId] int  NULL,
    [Gender] tinyint  NULL
);
GO

-- Creating table 'Places'
CREATE TABLE [dbo].[Places] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Parent_Id] int  NULL
);
GO

-- Creating table 'Documents'
CREATE TABLE [dbo].[Documents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [YearFrom] int  NOT NULL,
    [YearTo] int  NOT NULL
);
GO

-- Creating table 'DocumentLines'
CREATE TABLE [dbo].[DocumentLines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DocumentId] int  NOT NULL,
    [JSON] nvarchar(max)  NOT NULL
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

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NameGroups'
ALTER TABLE [dbo].[NameGroups]
ADD CONSTRAINT [PK_NameGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Names'
ALTER TABLE [dbo].[Names]
ADD CONSTRAINT [PK_Names]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [PK_Persons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [PK_Places]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [PK_Documents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocumentLines'
ALTER TABLE [dbo].[DocumentLines]
ADD CONSTRAINT [PK_DocumentLines]
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

-- Creating foreign key on [PersonId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_PersonsEvent]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonsEvent'
CREATE INDEX [IX_FK_PersonsEvent]
ON [dbo].[Events]
    ([PersonId]);
GO

-- Creating foreign key on [NameGroupId] in table 'Names'
ALTER TABLE [dbo].[Names]
ADD CONSTRAINT [FK_NameNameGroup]
    FOREIGN KEY ([NameGroupId])
    REFERENCES [dbo].[NameGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NameNameGroup'
CREATE INDEX [IX_FK_NameNameGroup]
ON [dbo].[Names]
    ([NameGroupId]);
GO

-- Creating foreign key on [FirstNameId] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_FirstNamePerson]
    FOREIGN KEY ([FirstNameId])
    REFERENCES [dbo].[Names]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FirstNamePerson'
CREATE INDEX [IX_FK_FirstNamePerson]
ON [dbo].[Persons]
    ([FirstNameId]);
GO

-- Creating foreign key on [LastNameId] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_LastNamePerson]
    FOREIGN KEY ([LastNameId])
    REFERENCES [dbo].[Names]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LastNamePerson'
CREATE INDEX [IX_FK_LastNamePerson]
ON [dbo].[Persons]
    ([LastNameId]);
GO

-- Creating foreign key on [MiddleNameId] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_MiddleNamePerson]
    FOREIGN KEY ([MiddleNameId])
    REFERENCES [dbo].[Names]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MiddleNamePerson'
CREATE INDEX [IX_FK_MiddleNamePerson]
ON [dbo].[Persons]
    ([MiddleNameId]);
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

-- Creating foreign key on [BirthPlaceId] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_PersonBirthPlace]
    FOREIGN KEY ([BirthPlaceId])
    REFERENCES [dbo].[Places]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonBirthPlace'
CREATE INDEX [IX_FK_PersonBirthPlace]
ON [dbo].[Persons]
    ([BirthPlaceId]);
GO

-- Creating foreign key on [Parent_Id] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [FK_PlaceSubPlace]
    FOREIGN KEY ([Parent_Id])
    REFERENCES [dbo].[Places]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlaceSubPlace'
CREATE INDEX [IX_FK_PlaceSubPlace]
ON [dbo].[Places]
    ([Parent_Id]);
GO

-- Creating foreign key on [EventsAttended_Id] in table 'EventPerson'
ALTER TABLE [dbo].[EventPerson]
ADD CONSTRAINT [FK_EventPersonAttended_Event]
    FOREIGN KEY ([EventsAttended_Id])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Attendees_Id] in table 'EventPerson'
ALTER TABLE [dbo].[EventPerson]
ADD CONSTRAINT [FK_EventPersonAttended_Person]
    FOREIGN KEY ([Attendees_Id])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventPersonAttended_Person'
CREATE INDEX [IX_FK_EventPersonAttended_Person]
ON [dbo].[EventPerson]
    ([Attendees_Id]);
GO

-- Creating foreign key on [DeathPlaceId] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_PersonFather]
    FOREIGN KEY ([DeathPlaceId])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonFather'
CREATE INDEX [IX_FK_PersonFather]
ON [dbo].[Persons]
    ([DeathPlaceId]);
GO

-- Creating foreign key on [MotherId] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_PersonMother]
    FOREIGN KEY ([MotherId])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonMother'
CREATE INDEX [IX_FK_PersonMother]
ON [dbo].[Persons]
    ([MotherId]);
GO

-- Creating foreign key on [DocumentId] in table 'DocumentLines'
ALTER TABLE [dbo].[DocumentLines]
ADD CONSTRAINT [FK_DocumentLineDocument]
    FOREIGN KEY ([DocumentId])
    REFERENCES [dbo].[Documents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentLineDocument'
CREATE INDEX [IX_FK_DocumentLineDocument]
ON [dbo].[DocumentLines]
    ([DocumentId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------