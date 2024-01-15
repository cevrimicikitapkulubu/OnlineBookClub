CREATE TABLE [Event].[Events]
(
  ID              INT               NOT NULL    IDENTITY(1, 1),
  ISBN            CHAR(13)          NOT NULL    CONSTRAINT [CHK_Events_ISBN] CHECK (ISBN NOT LIKE '%[^0-9]%' AND LEN(ISBN) = 13),
  Title           NVARCHAR(64)      NOT NULL,
  StartDate       DATETIMEOFFSET    NOT NULL,
  SchoolID        SMALLINT          NOT NULL,
  LocationID      INT               NOT NULL,
  -- Audit Columns
  IsActive        BIT               NOT NULL    CONSTRAINT [DF_Events_IsActive] DEFAULT ((1)),
  IsDeleted       BIT               NOT NULL    CONSTRAINT [DF_Events_IsDeleted] DEFAULT ((0)),
  CreatedDate     DATETIMEOFFSET    NOT NULL    CONSTRAINT [DF_Events_CreatedDate] DEFAULT (GETUTCDATE()),
  CreatedUserID   INT               NOT NULL,
  ModifiedDate    DATETIMEOFFSET    NULL,
  ModifiedUserID  INT               NULL,

  CONSTRAINT [PK_Events]
    PRIMARY KEY ([ID])
    WITH (FILLFACTOR = 70),

  CONSTRAINT [FK_Events_SchoolID_Schools]
    FOREIGN KEY ([SchoolID]) REFERENCES Const.Schools ([ID])
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
    
  CONSTRAINT [FK_Events_LocationID_Locations]
    FOREIGN KEY ([LocationID]) REFERENCES Event.Locations ([ID])
    ON DELETE NO ACTION
    ON UPDATE CASCADE,

  CONSTRAINT [FK_Events_CreatedUserID_Users]
    FOREIGN KEY ([CreatedUserID]) REFERENCES Auth.Users ([ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,

  CONSTRAINT [FK_Events_ModifiedUserID_Users]
    FOREIGN KEY ([ModifiedUserID]) REFERENCES Auth.Users ([ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);
GO

CREATE NONCLUSTERED INDEX [IX_Events_StartDate_SchoolID_LocationID]
ON [Event].[Events] ([StartDate] ASC, [SchoolID] ASC, [LocationID] ASC)
INCLUDE (ISBN) 
WHERE ([IsActive] = 1 AND [IsDeleted] = 0)
WITH (FILLFACTOR = 70);

