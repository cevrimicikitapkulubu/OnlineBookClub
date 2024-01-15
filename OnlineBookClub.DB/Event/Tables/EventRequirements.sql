CREATE TABLE [Event].[EventRequirements]
(
  [EventID]         INT               NOT NULL,
  [SchoolID]        SMALLINT          NOT NULL,
  [DepartmentID]    SMALLINT          NULL,
  [UserRoleID]      TINYINT           NULL,
  [Gender]          dbo.Gender        NULL,

  -- Audit Columns
  [IsActive]        BIT               NOT NULL    CONSTRAINT [DF_EventRequirements_IsActive] DEFAULT ((1)),
  [IsDeleted]       BIT               NOT NULL    CONSTRAINT [DF_EventRequirements_IsDeleted] DEFAULT ((0)),
  [CreatedDate]     DATETIMEOFFSET    NOT NULL    CONSTRAINT [DF_EventRequirements_CreatedDate] DEFAULT (GETUTCDATE()),
  [CreatedUserID]   INT               NOT NULL,
  [ModifiedDate]    DATETIMEOFFSET    NULL,
  [ModifiedUserID]  INT               NULL,

  CONSTRAINT [PK_EventRequirements]
    PRIMARY KEY ([EventID] ASC)
    WITH (FILLFACTOR = 70),

  CONSTRAINT [FK_EventRequirements_SchoolID_Schools]
    FOREIGN KEY ([SchoolID]) REFERENCES [Const].[Schools]([ID])
    ON DELETE NO ACTION
    ON UPDATE CASCADE,

  CONSTRAINT [FK_EventRequirements_DepartmentID_Departments]
    FOREIGN KEY ([DepartmentID]) REFERENCES [Const].[Departments]([ID])
    ON DELETE NO ACTION
    ON UPDATE CASCADE,

  CONSTRAINT [FK_EventRequirements_UserRoleID_UserRoles]
    FOREIGN KEY ([UserRoleID]) REFERENCES [Auth].[UserRoles]([ID])
    ON DELETE NO ACTION
    ON UPDATE CASCADE,

  CONSTRAINT [FK_EventRequirements_CreatedUserID_Users]
    FOREIGN KEY ([CreatedUserID]) REFERENCES [Auth].[Users] ([ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,

  CONSTRAINT [FK_EventRequirements_ModifiedUserID_Users]
    FOREIGN KEY ([ModifiedUserID]) REFERENCES [Auth].[Users] ([ID])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);
