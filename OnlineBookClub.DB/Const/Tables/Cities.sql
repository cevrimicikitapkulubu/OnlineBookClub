CREATE TABLE [Const].[Cities] 
(
    [ID]        SMALLINT         NOT NULL     IDENTITY (1, 1),
    [Name]      NVARCHAR (32)    NOT NULL,

    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([ID] ASC) WITH (FILLFACTOR = 70)
);
