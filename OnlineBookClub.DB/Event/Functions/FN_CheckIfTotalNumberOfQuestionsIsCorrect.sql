CREATE FUNCTION [Event].[FN_CheckIfTotalNumberOfQuestionsIsCorrect]
(
    @pEventID   INT
)
RETURNS BIT
AS
BEGIN
    DECLARE @vResult BIT    = 0;

    IF (SELECT COUNT(1) FROM Event.EventSubjects AS es WHERE es.EventID = @pEventID) BETWEEN 0 AND 5
        SET @vResult = 1;

    RETURN @vResult;
END
