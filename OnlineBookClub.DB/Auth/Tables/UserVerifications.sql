CREATE TABLE [Auth].[UserVerifications]
(
    UserID			    INT					NOT NULL,
    GUID				UNIQUEIDENTIFIER	NOT NULL,
    IsConfirmed		    BIT					NOT NULL	CONSTRAINT [DF_UserVerifications_IsConfirmed] DEFAULT ((0)),
    ExpirationDate	    DATETIMEOFFSET		NOT NULL,
    ConfirmedDate		DATETIMEOFFSET		NULL,
    CreateDate		    DATETIMEOFFSET		NOT NULL	CONSTRAINT [DF_UserVerifications_CreatedDate] DEFAULT (GETUTCDATE()),

    CONSTRAINT [PK_UserVerifications_UserID]
        PRIMARY KEY CLUSTERED ([UserID], [GUID])
        WITH (FILLFACTOR = 100),
    
    CONSTRAINT [FK_UserVerifications_UserID]
        FOREIGN KEY ([UserID]) REFERENCES [Auth].[Users]([ID])
        ON DELETE NO ACTION
        ON UPDATE CASCADE,
);
GO

CREATE NONCLUSTERED INDEX [IX_UserVerifications_GUID_UserID]
ON [Auth].[UserVerifications] ([GUID], [UserID])
WITH (FILLFACTOR = 70);
GO