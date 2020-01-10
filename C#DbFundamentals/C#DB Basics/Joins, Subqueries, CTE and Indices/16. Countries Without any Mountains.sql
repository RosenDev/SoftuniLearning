SELECT COUNT(c.CountryCode) as country_count FROM Countries as c
LEFT JOIN MountainsCountries as m_c ON c.CountryCode = m_c.CountryCode
WHERE m_c.MountainId IS NULL;