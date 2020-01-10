SELECT TOP 5 CountryName,MAX(Elevation) AS HighestPeakElevation, MAX(Length) AS LongestRiverLength
FROM Countries AS C
LEFT JOIN MountainsCountries AS MC
ON C.CountryCode= MC.CountryCode
LEFT JOIN Mountains AS M
ON MC.MountainId=M.Id
LEFT JOIN Peaks AS P
ON M.Id= P.MountainId
LEFT JOIN CountriesRivers AS CR
ON C.CountryCode= CR.CountryCode
LEFT JOIN Rivers AS R
ON CR.RiverId= R.Id
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC,CountryName