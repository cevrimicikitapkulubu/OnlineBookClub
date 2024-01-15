CREATE TABLE [Const].[UserAchievements]
(
    [UserID]                INT                     NOT NULL,
    [AchievementID]         INT                     NOT NULL,
    [EventID]               INT                     NOT NULL,
    [CreateDate]            DATETIMEOFFSET          NOT NULL        CONSTRAINT [DF_UserAchievements_CreatedDate] DEFAULT (GETUTCDATE())

    CONSTRAINT [FK_UserAchievements_ID_Users]
        FOREIGN KEY ([UserID]) REFERENCES [Auth].[Users] ([ID]),

    CONSTRAINT [FK_UserAchievements_AchievementID_Achievements]
        FOREIGN KEY ([AchievementID]) REFERENCES [Const].[Achievements] ([ID]),

    CONSTRAINT [FK_UserAchievements_EventID_Events]
        FOREIGN KEY ([EventID]) REFERENCES [Event].[Events] ([ID])
);