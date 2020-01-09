select DepositGroup, SUM(DepositAmount)AS TotalSum  from WizzardDeposits
GROUP BY DepositGroup , MagicWandCreator
HAVING MagicWandCreator='Ollivander family'