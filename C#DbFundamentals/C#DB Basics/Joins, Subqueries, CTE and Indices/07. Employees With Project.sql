SELECT TOP 5 E.EmployeeID, FirstName, P.Name AS ProjectName 
FROM Employees AS E
JOIN EmployeesProjects AS EP
ON E.EmployeeID= EP.EmployeeID
LEFT JOIN Projects AS P
ON EP.ProjectID= P.ProjectID
WHERE P.StartDate>'2002-02-13' AND EndDate IS NULL
ORDER BY E.EmployeeID