CREATE TABLE [Event].[EventRatings]
(
  [EventID]       INT               NOT NULL,
  [UserID]        INT               NOT NULL,
  [Rating]        TINYINT           NULL        CONSTRAINT [CHK_EventRatings_Rating] CHECK ([Rating] BETWEEN 1 AND 5),
  [Description]   NVARCHAR(256)     NULL,

  [CreatedDate]   DATETIMEOFFSET    NOT NULL    CONSTRAINT [DF_EventRatings_CreatedDate] DEFAULT (GETUTCDATE()),

  CONSTRAINT [PK_EventRatings]
    PRIMARY KEY ([EventID] ASC, [UserID] ASC)
    WITH (FILLFACTOR = 70),

  CONSTRAINT [FK_EventRatings_EventID_Events]
    FOREIGN KEY ([EventID]) REFERENCES [Event].[Events] ([ID])
);