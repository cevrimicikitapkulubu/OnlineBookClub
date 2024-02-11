CREATE TABLE [Const].[Achievements]
(
  [ID]				INT					NOT NULL		IDENTITY(1, 1),
  [Title]			NVARCHAR(16)		NOT NULL,
  [EventCount]		SMALLINT			NULL,
  [Level]			TINYINT				NULL,

  CONSTRAINT [PK_Achievements]
        PRIMARY KEY ([ID] ASC)
        WITH (FILLFACTOR = 70),

  CONSTRAINT [FK_Achievements_Level_Levels]
        FOREIGN KEY ([Level]) REFERENCES [Const].[Levels] ([Level]),
);