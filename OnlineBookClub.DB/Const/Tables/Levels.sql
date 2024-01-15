CREATE TABLE [Const].[Levels]
(
  [Level]					TINYINT		NOT NULL,
  [ExperiencePoint]		    SMALLINT	NOT NULL,

  CONSTRAINT [PK_Levels]
    PRIMARY KEY ([Level])
    WITH (FILLFACTOR = 70),
);