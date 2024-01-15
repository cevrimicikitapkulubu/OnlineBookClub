CREATE TABLE [Auth].[UserPasswords]
(
	UserID			    INT					NOT NULL,
	PasswordHash		VARCHAR(256)		NOT NULL,
	PasswordSalt		VARCHAR(256)		NOT NULL,

	CONSTRAINT [PK_UserPasswords_UserID]
        PRIMARY KEY CLUSTERED ([UserID])
        WITH (FILLFACTOR = 100),
    
    CONSTRAINT [FK_UserPasswords_UserID]
        FOREIGN KEY ([UserID]) REFERENCES [Auth].[Users]([ID])
        ON DELETE NO ACTION
        ON UPDATE CASCADE,
);
GO