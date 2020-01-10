SELECT  TOP(10)FirstName, LastName, DepartmentID FROM(SELECT   E.FirstName, E.LastName, E.DepartmentID, Salary FROM Employees AS E
WHERE Salary >(SELECT AVG(Salary) FROM Employees AS EM WHERE DepartmentID = E.DepartmentID)) AS EC
ORDER BY DepartmentID