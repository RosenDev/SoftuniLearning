SELECT E.EmployeeID,E.FirstName, M.EmployeeID AS ManagerID, M.FirstName  AS ManagerName
FROM Employees AS E
LEFT JOIN Employees AS M
ON M.EmployeeID = E.ManagerID
WHERE M.EmployeeID IN (3,7)
ORDER BY E.EmployeeID

