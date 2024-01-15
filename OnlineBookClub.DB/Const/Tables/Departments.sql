CREATE TABLE [Const].[Departments]
(
  [ID]        SMALLINT        NOT NULL    IDENTITY(1, 1),
  [Name]      NVARCHAR(48)    NOT NULL,

  CONSTRAINT [PK_Departments]
    PRIMARY KEY ([ID])
    WITH (FILLFACTOR = 100)
);