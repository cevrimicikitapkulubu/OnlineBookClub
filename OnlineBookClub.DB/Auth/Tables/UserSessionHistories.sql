CREATE TABLE [Auth].[UserSessionHistories]
(
	UserID			    INT					    NOT NULL,
	Token               UNIQUEIDENTIFIER        NOT NULL,
    IPAddress           VARCHAR(15)             NOT NULL,
    IsLogin             BIT                     NOT NULL,

	CONSTRAINT [PK_UserSessionHistories_UserID]
        PRIMARY KEY CLUSTERED ([UserID])
        WITH (FILLFACTOR = 100),
    
    CONSTRAINT [FK_UserSessionHistories_UserID]
        FOREIGN KEY ([UserID]) REFERENCES [Auth].[Users]([ID])
        ON DELETE NO ACTION
        ON UPDATE CASCADE,
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UX_UserSessionHistories_Token]
ON [Auth].[UserSessionHistories] ([Token] ASC)
WITH (FILLFACTOR = 70)
GO