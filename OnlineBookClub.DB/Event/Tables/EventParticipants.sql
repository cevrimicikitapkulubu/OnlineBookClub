CREATE TABLE [Event].[EventParticipants]
(
  [EventID]       INT               NOT NULL,
  [UserID]        INT               NOT NULL,
  [Rating]        TINYINT           NULL,
  [Description]   NVARCHAR(256)     NULL,

  [CreatedDate]   DATETIMEOFFSET    NOT NULL    CONSTRAINT [DF_EventParticipants_CreatedDate] DEFAULT (GETUTCDATE()),
  [ModifiedDate]  DATETIMEOFFSET    NOT NULL,

  CONSTRAINT [PK_EventParticipants]
    PRIMARY KEY ([EventID] ASC, [UserID] ASC)
    WITH (FILLFACTOR = 70),

    CONSTRAINT [FK_EventParticipants_EventID_Events]
        FOREIGN KEY ([EventID]) REFERENCES [Event].[Events] ([ID]),

    CONSTRAINT [FK_EventParticipants_Rating_Ratings]
        FOREIGN KEY ([Rating]) REFERENCES [Const].[Ratings] ([Rate])
);

--TODO: a check constraint will be added to check the requiretements between user and event