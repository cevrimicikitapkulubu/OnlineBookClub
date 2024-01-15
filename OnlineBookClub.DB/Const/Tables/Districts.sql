CREATE TABLE [Const].[Districts]
(
  [ID]          SMALLINT      NOT NULL    IDENTITY(1, 1),
  [Name]        NVARCHAR(32)  NOT NULL,
  [CityID]      SMALLINT      NOT NULL,

  CONSTRAINT [PK_Districts]
    PRIMARY KEY ([ID])
    WITH (FILLFACTOR = 70),

  CONSTRAINT [FK_Districts_CityID_Cities]
    FOREIGN KEY ([CityID]) REFERENCES [Const].[Cities]([ID])
    ON DELETE NO ACTION
    ON UPDATE CASCADE
);
