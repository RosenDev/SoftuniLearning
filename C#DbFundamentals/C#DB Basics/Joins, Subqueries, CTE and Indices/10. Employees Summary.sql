  SELECT TOP(50) E.EmployeeID, E.FirstName+' '+E.LastName AS EmployeeName,EE.FirstName+' '+EE.LastName AS ManagerName,D.Name AS DepartmentName 
  FROM Employees AS E
  LEFT JOIN Employees AS EE
  ON EE.EmployeeID= E.ManagerID
  
    JOIN Departments AS D
  ON D.DepartmentID= E.DepartmentID
  ORDER BY E.EmployeeID