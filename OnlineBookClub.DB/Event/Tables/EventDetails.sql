CREATE TABLE [Event].[EventDetails]
(
  [EventID]       INT             NOT NULL,
  [Description]   NVARCHAR(4000)  NOT NULL,

  CONSTRAINT [PK_EventDetails]
    PRIMARY KEY ([EventID] ASC),

  CONSTRAINT [FK_EventDetails_EventID_Events]
    FOREIGN KEY ([EventID]) REFERENCES [Event].[Events] ([ID])
);
