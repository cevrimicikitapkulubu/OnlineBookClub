CREATE TABLE [Const].[Schools]
(
  [ID]          SMALLINT      NOT NULL    IDENTITY(1, 1),
  [Name]        NVARCHAR(128) NOT NULL,
  [DistrictID]  SMALLINT      NOT NULL,
  
  CONSTRAINT [PK_Schools]
    PRIMARY KEY ([ID])
    WITH(FILLFACTOR = 70),

  CONSTRAINT [PK_Schools_DistrictID_DistrictID]
    FOREIGN KEY ([DistrictID]) REFERENCES [Const].[Districts] ([ID])
    ON DELETE NO ACTION
    ON UPDATE CASCADE
);