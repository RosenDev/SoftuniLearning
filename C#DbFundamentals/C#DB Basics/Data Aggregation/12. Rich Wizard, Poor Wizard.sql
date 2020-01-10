SELECT SUM(DP-D) AS SumDifference  FROM(SELECT WD.Id, WD.FirstName, WD.DepositAmount AS DP,(SELECT W.DepositAmount FROM WizzardDeposits AS W WHERE W.Id= WD.Id+1) AS D
 FROM WizzardDeposits AS WD) AS T