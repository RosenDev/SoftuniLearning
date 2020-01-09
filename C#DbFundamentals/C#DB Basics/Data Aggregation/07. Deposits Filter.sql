SELECT DepositGroup FROM WizzardDeposits
WHERE MagicWandCreator= 'Ollivander family'
GROUP BY DepositGroup, DepositAmount
HAVING DepositAmount <150000
ORDER BY DepositAmount DESC