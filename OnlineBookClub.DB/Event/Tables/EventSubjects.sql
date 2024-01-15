CREATE TABLE [Event].[EventSubjects]
(
  [EventID]       INT               NOT NULL,
  [RowNumber]     TINYINT           NOT NULL    CONSTRAINT [CHK_EventSubjects] CHECK ([RowNumber] BETWEEN 1 AND 5),
  [Question]      NVARCHAR(512)     NOT NULL,

  -- Audit Columns
  IsActive        BIT               NOT NULL    CONSTRAINT [DF_EventSubjects_IsActive] DEFAULT ((1)),
  IsDeleted       BIT               NOT NULL    CONSTRAINT [DF_EventSubjects_IsDeleted] DEFAULT ((0)),
  CreatedDate     DATETIMEOFFSET    NOT NULL    CONSTRAINT [DF_EventSubjects_CreatedDate] DEFAULT (GETUTCDATE()),
  CreatedUserID   INT               NOT NULL,
  ModifiedDate    DATETIMEOFFSET    NULL,
  ModifiedUserID  INT               NULL,

  CONSTRAINT [PK_EventSubjects]
    PRIMARY KEY ([EventID] ASC, [RowNumber] ASC)
    WITH (FILLFACTOR = 70),

  CONSTRAINT [CHK_EventSubjects_CheckIfTotalNumberOfQuestionsIsCorrect]
    CHECK (Event.FN_CheckIfTotalNumberOfQuestionsIsCorrect(EventID) = 1),

  CONSTRAINT [FK_EventSubjects_EventID_Events]
    FOREIGN KEY ([EventID]) REFERENCES [Event].[Events] ([ID])
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UX_EventSubjects_EventID_Question]
ON [Event].[EventSubjects] ([EventID] ASC, [Question] ASC)
WHERE ([IsActive] = 1 AND [IsDeleted] = 0)
WITH (FILLFACTOR = 70)

