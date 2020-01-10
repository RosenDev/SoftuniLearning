select top(50) FirstName,LastName,t.Name,AddressText
 from Employees as e 
 join Addresses as a
 on e.AddressID= a.AddressID 
 join Towns as t
 on a.TownID = t.TownID
 order by FirstName, LastName