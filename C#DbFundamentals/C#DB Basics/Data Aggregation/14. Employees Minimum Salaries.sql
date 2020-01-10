SELECT e.DepartmentID, MIN(Salary) AS MinimumSalary
FROM Employees AS e
WHERE e.DepartmentID IN (2, 5, 7)
GROUP BY e.DepartmentID