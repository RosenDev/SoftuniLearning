SELECT C.CountryCode,COUNT(MountainRange)
 FROM Countries AS C
 JOIN MountainsCountries AS MC
 ON C.CountryCode= MC.CountryCode
 JOIN Mountains AS M
 ON MC.MountainId= M.Id
 WHERE C.CountryCode IN('US','RU','BG')
 GROUP BY C.CountryCode
