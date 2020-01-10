CREATE PROC usp_CalculateFutureValueForAccount
@AccountId int,@percent decimal(18,2)
AS

SELECT A.Id, FirstName, LastName,Balance, dbo.ufn_CalculateFutureValue(Balance,@percent,5) as BalanceAfter5Years
FROM AccountHolders AS AH
JOIN Accounts AS A
ON AH.Id=A.AccountHolderId
where a.Id= @AccountId
