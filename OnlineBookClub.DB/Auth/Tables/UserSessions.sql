CREATE TABLE [Auth].[UserSessions]
(
	UserID			    INT					    NOT NULL,
	Token               UNIQUEIDENTIFIER        NOT NULL,
    IPAddress           VARCHAR(15)             NOT NULL,
    LoginDate           DATETIMEOFFSET          NOT NULL,

	CONSTRAINT [PK_UserSessions_UserID]
        PRIMARY KEY CLUSTERED ([UserID])
        WITH (FILLFACTOR = 100),
    
    CONSTRAINT [FK_UserSessions_UserID]
        FOREIGN KEY ([UserID]) REFERENCES [Auth].[Users]([ID])
        ON DELETE NO ACTION
        ON UPDATE CASCADE,
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UX_UserSessions_Token]
ON [Auth].[UserSessions] ([Token] ASC)
WITH (FILLFACTOR = 70)
GO