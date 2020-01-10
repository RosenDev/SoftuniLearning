CREATE PROC usp_GetHoldersWithBalanceHigherThan
@number DECIMAL(18,4)
AS
SELECT FirstName, LastName
FROM AccountHolders AS AH
JOIN Accounts AS A 
ON AH.Id= A.AccountHolderId
GROUP BY FirstName, LastName
HAVING SUM(Balance)> @number
ORDER BY FirstName,LastName




