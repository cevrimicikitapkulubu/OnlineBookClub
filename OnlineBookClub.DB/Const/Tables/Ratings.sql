CREATE TABLE [Const].[Ratings]
(
  [Rate]      TINYINT     NOT NULL CONSTRAINT [CHK_Ratings_Rate] CHECK ([Rate] BETWEEN 1 AND 5),
  [Point]     TINYINT     NOT NULL,

  CONSTRAINT [PK_Ratings]
    PRIMARY KEY ([Rate])
    WITH (FILLFACTOR = 70),
);