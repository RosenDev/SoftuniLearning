 select EmployeeID, FirstName,LastName, d.Name 
 from Employees as e
 join Departments as d
 on e.DepartmentID=d.DepartmentID
 where d.Name='Sales'
 order by EmployeeID