SELECT TOP 5 E.EmployeeID, FirstName, CASE
WHEN YEAR(P.StartDate)>=2005 THEN
NULL
ELSE
P.Name
END  AS ProjectName 
FROM Employees AS E
JOIN EmployeesProjects AS EP
ON E.EmployeeID= EP.EmployeeID
LEFT JOIN Projects AS P
ON EP.ProjectID= P.ProjectID
WHERE EP.EmployeeID=24

ORDER BY E.EmployeeID