
SELECT  PeakName,RiverName,LOWER(CONCAT(left(PeakName,LEN(PeakName)-1),RiverName)) AS Mix from Peaks, Rivers WHERE RIGHT(PeakName,1)=LEFT(RiverName,1) ORDER BY Mix
