CREATE TABLE [Auth].[Users]
(
    ID              INT                 NOT NULL    IDENTITY(1, 1),
    FirstName       NVARCHAR(48)        NOT NULL,
    LastName        NVARCHAR(48)        NOT NULL,
    UserName        NVARCHAR(24)        NOT NULL,
    Email           NVARCHAR(320)       NOT NULL,
    PhoneNumber     CHAR(11)            NOT NULL CONSTRAINT [CHK_Users_PhoneNumber] CHECK (PhoneNumber NOT LIKE '%[^0-9]%' AND LEN(PhoneNumber) = 11),
    DepartmentID    SMALLINT            NOT NULL,
    UserRoleID      TINYINT             NOT NULL,
    Gender          dbo.Gender          NOT NULL,
    SchoolID        SMALLINT            NOT NULL,
    SchoolNo        VARCHAR(8)          NULL,
    Level           TINYINT             NULL,
    Point           SMALLINT            NULL,
    -- Audit Columns
    IsActive      BIT             NOT NULL  CONSTRAINT [DF_Users_IsActive] DEFAULT ((1)),
    IsDeleted     BIT             NOT NULL  CONSTRAINT [DF_Users_IsDeleted] DEFAULT ((0)),
    CreatedDate   DATETIMEOFFSET  NOT NULL  CONSTRAINT [DF_Users_CreatedDate] DEFAULT (GETUTCDATE()),
    ModifiedDate  DATETIMEOFFSET  NULL,

    CONSTRAINT [PK_Users]
        PRIMARY KEY CLUSTERED ([ID])
        WITH (FILLFACTOR = 100),

     CONSTRAINT [FK_Users_DepartmentID_Departments]
        FOREIGN KEY ([DepartmentID]) REFERENCES [Const].[Departments]([ID])
        ON DELETE NO ACTION
        ON UPDATE CASCADE,

     CONSTRAINT [FK_Users_UserRoleID_UserRoles]
        FOREIGN KEY ([UserRoleID]) REFERENCES [Auth].[UserRoles]([ID])
        ON DELETE NO ACTION
        ON UPDATE CASCADE,

    CONSTRAINT [FK_Users_SchoolID_Schools]
        FOREIGN KEY ([SchoolID]) REFERENCES [Const].[Schools]([ID])
        ON DELETE NO ACTION
        ON UPDATE CASCADE,

    CONSTRAINT [FK_Users_Level_Levels]
        FOREIGN KEY ([Level]) REFERENCES [Const].[Levels]([Level])
        ON DELETE NO ACTION
        ON UPDATE CASCADE
);
GO

CREATE NONCLUSTERED INDEX [IX_Users_SchoolID]
ON [Auth].[Users] ([SchoolID])
INCLUDE (FirstName, LastName, Gender, SchoolNo, IsActive, IsDeleted, CreatedDate, ModifiedDate)
WHERE ([IsDeleted] = 0)
WITH (FILLFACTOR = 70);
GO

CREATE NONCLUSTERED INDEX [IX_Users_SchoolNo]
ON [Auth].[Users] ([SchoolNo])
INCLUDE (FirstName, LastName, Gender, SchoolID, IsActive, IsDeleted, CreatedDate, ModifiedDate)
WHERE ([IsDeleted] = 0)
WITH (FILLFACTOR = 70);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UX_Users_PhoneNumber]
ON [Auth].[Users] ([PhoneNumber] ASC)
WHERE ([IsDeleted] = 0)
WITH (FILLFACTOR = 70)
GO

CREATE UNIQUE NONCLUSTERED INDEX [UX_Users_UserName]
ON [Auth].[Users] ([UserName] ASC)
WHERE ([IsDeleted] = 0)
WITH (FILLFACTOR = 70)
GO

CREATE UNIQUE NONCLUSTERED INDEX [UX_Users_Email]
ON [Auth].[Users] ([Email] ASC)
WHERE ([IsDeleted] = 0)
WITH (FILLFACTOR = 70)
GO