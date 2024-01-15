CREATE TABLE [Event].[Locations]
(
  ID              INT               NOT NULL    IDENTITY(1, 1),
  IsOnline        BIT               NOT NULL,
  Title           NVARCHAR(32)      NOT NULL,
  Description     NVARCHAR(MAX)     NOT NULL,
  Geography       GEOGRAPHY         NULL,

  CONSTRAINT [PK_Locations]
    PRIMARY KEY ([ID])
    WITH (FILLFACTOR = 70, OPTIMIZE_FOR_SEQUENTIAL_KEY = ON)
)
