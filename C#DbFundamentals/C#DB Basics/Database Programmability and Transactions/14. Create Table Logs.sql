
CREATE TRIGGER tr_LogBalanceChange
ON Accounts
AFTER UPDATE
AS
BEGIN
	INSERT Logs(AccountId, OldSum, NewSum)
	SELECT inserted.Id, deleted.Balance, inserted.Balance
	FROM deleted, inserted
END