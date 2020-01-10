CREATE PROC usp_GetEmployeesSalaryAboveNumber 
@SalaryLimit DECIMAL(18,4)
AS

SELECT FirstName, LastName FROM Employees
WHERE Salary>=@SalaryLimit