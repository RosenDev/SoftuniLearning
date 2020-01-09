SELECT w.DepositGroup, w.IsDepositExpired, AVG(w.DepositInterest) AS AverageInterest
FROM WizzardDeposits AS w
WHERE w.DepositStartDate > '1985/01/01'
GROUP BY w.IsDepositExpired, w.DepositGroup
ORDER BY w.DepositGroup DESC, w.IsDepositExpired