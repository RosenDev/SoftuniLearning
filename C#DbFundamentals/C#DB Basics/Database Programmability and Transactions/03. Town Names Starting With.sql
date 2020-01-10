CREATE PROC usp_GetTownsStartingWith 
@StartString nvarchar(50)
as
SELECT Name as Town
FROM Towns
WHERE Name like @StartString +'%'