CREATE FUNCTION ufn_CashInUsersGames(@Name varchar(50))
RETURNS TABLE
RETURN(
SELECT SUM(SumCash) AS SumCash  FROM(
SELECT Cash as SumCash, G.Name AS NAME, DENSE_RANK() over(partition by g.Name order by Cash desc) as rank
FROM Games AS G
JOIN UsersGames AS UG
ON G.Id=UG.GameId)
AS A  

where NAME= @Name AND rank%2!=0
)
