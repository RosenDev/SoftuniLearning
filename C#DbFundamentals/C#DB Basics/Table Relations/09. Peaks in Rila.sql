SELECT MountainRange, PeakName, Elevation FROM Mountains AS M JOIN Peaks AS P ON M.Id= P.MountainId
WHERE MountainRange= 'Rila'
ORDER BY Elevation DESC