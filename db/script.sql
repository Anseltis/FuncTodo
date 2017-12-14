-- Script Date: 12/8/2017 5:08 PM  - ErikEJ.SqlCeScripting version 3.5.2.74
-- Database information:
-- Locale Identifier: 1033
-- Encryption Mode: 
-- Case Sensitive: False
-- Database: d:\Projects\FuncTodo\db\tododb.sdf
-- ServerVersion: 4.0.8876.1
-- DatabaseSize: 128 KB
-- SpaceAvailable: 3.999 GB
-- Created: 12/1/2017 1:41 PM

-- User Table information:
-- Number of tables: 2
-- Category: 2 row(s)
-- Todo: 4 row(s)

SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [Category] (
  [Id] INTEGER  NOT NULL
, [Name] nvarchar(100)  NOT NULL
, [Color] int  NULL
, [Order] int  NOT NULL
, CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
CREATE TABLE [Todo] (
  [Id] INTEGER  NOT NULL
, [Title] nvarchar(100)  NOT NULL
, [Desc] nvarchar(200)  NULL
, [Deadline] datetime NULL
, [CategoryId] int  NULL
, [Checked] bit DEFAULT 0 NOT NULL
, [Order] int  NOT NULL
, CONSTRAINT [PK_Todo] PRIMARY KEY ([Id])
, FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE NO ACTION ON UPDATE CASCADE
);
INSERT INTO [Category] ([Id],[Name],[Color],[Order]) VALUES (
3,'Two plus',-16751616,1);
INSERT INTO [Category] ([Id],[Name],[Color],[Order]) VALUES (
4,'Three',-5952982,0);
INSERT INTO [Todo] ([Id],[Title],[Desc],[Deadline],[CategoryId],[Checked],[Order]) VALUES (
1,'324324','3423','2016-01-27 13:26:38.587',3,1,1);
INSERT INTO [Todo] ([Id],[Title],[Desc],[Deadline],[CategoryId],[Checked],[Order]) VALUES (
2,'cxvcxbvc','vcxbcvb','2016-01-27 13:30:23.847',4,1,0);
INSERT INTO [Todo] ([Id],[Title],[Desc],[Deadline],[CategoryId],[Checked],[Order]) VALUES (
3,'Category',NULL,NULL,3,0,2);
INSERT INTO [Todo] ([Id],[Title],[Desc],[Deadline],[CategoryId],[Checked],[Order]) VALUES (
4,'Second category',NULL,'2016-02-22 00:00:00.000',NULL,0,3);
COMMIT;

