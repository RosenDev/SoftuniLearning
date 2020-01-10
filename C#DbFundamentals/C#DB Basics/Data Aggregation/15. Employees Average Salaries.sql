SELECT * 
INTO NewEmployees
FROM Employees
WHERE Employees.Salary > 30000
DELETE FROM NewEmployees
WHERE NewEmployees.ManagerID = 42

UPDATE NewEmployees
SET Salary += 5000
WHERE NewEmployees.DepartmentID = 1

SELECT ne.DepartmentID, AVG(Salary) AS AverageSalary
FROM NewEmployees AS ne
GROUP BY ne.DepartmentID

DROP TABLE NewEmployees