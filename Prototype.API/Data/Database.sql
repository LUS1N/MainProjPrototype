USE master;
ALTER DATABASE [Prototype] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE [Prototype] ;

create database Prototype

use Prototype


CREATE TABLE [dbo].[Owner]
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](200) NOT NULL,
	CONSTRAINT [UQ_Name] UNIQUE NONCLUSTERED 
	(
		[Name] ASC
	)
); 

CREATE TABLE [dbo].[Server]
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](100)  NOT NULL UNIQUE,
	[Ip] [nvarchar](100) NOT NULL UNIQUE,
	[Os] [nvarchar](60) NOT NULL,
	[OwnerId] [INT] NOT NULL
		CONSTRAINT [FK_Server_Owner]
			REFERENCES dbo.[Owner](Id),

);

CREATE TABLE [dbo].[Site]
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](445) NOT NULL,
	[ServerId] [int] NOT NULL
		CONSTRAINT [FK_Site_2_Server]
			REFERENCES Server(Id) ON DELETE CASCADE,
	[OwnerId] [INT] NOT NULL
		CONSTRAINT [FK_Site_Owner]
			REFERENCES dbo.[Owner](Id), 

	CONSTRAINT [UQ_ServerSites] UNIQUE NONCLUSTERED 
	(
		[ServerId] ASC,
		[Name] ASC
	)
);


CREATE TABLE [dbo].[Database]
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](200) NOT NULL,
	[ServerId] [int] NOT NULL
		 CONSTRAINT [FK_Database_2_Server]
			REFERENCES Server(Id) ON DELETE CASCADE,
	[OwnerId] [INT] NOT NULL
		CONSTRAINT [FK_Database_Owner]
			REFERENCES dbo.[Owner](Id), 
	CONSTRAINT [UQ_ServerDatabases] UNIQUE NONCLUSTERED 
	(
		[ServerId] ASC,
		[Name] ASC
	)
);

CREATE TABLE Site_To_Database
(
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[SiteId] [int] NOT NULL
		 CONSTRAINT [FK_STD_2_Site]
			REFERENCES Site(Id) ON DELETE CASCADE,
	[DatabaseId] [int] NOT NULL
		CONSTRAINT [FK_STD_2_Db]
			REFERENCES dbo.[Database](Id),
	CONSTRAINT [UQ_Site_DB_Conn] UNIQUE NONCLUSTERED 
	(
		SiteId ASC,
		DatabaseId ASC
	)
);


INSERT INTO [dbo].[Owner] (Name) VALUES ('Unassigned')
