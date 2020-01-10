SELECT TOP 5 EmployeeID, FirstName, Salary, D.Name
FROM Employees AS E 
JOIN Departments AS D
ON E.DepartmentID=D.DepartmentID
ORDER BY E.DepartmentID