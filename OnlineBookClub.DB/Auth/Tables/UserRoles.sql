CREATE TABLE [Auth].[UserRoles]
(
  [ID]          TINYINT       NOT NULL    IDENTITY(1, 1),
  [Name]        VARCHAR(16)   NOT NULL,

  CONSTRAINT [PK_UserRoles]
    PRIMARY KEY ([ID] ASC)
)
