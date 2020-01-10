CREATE FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS varchar(10)
as
BEGIN
DECLARE @result varchar(10);
IF (@Salary<30000)
SET @result = 'Low';
ELSE IF(@Salary<=50000)
SET @result = 'Average';
ELSE
SET @result = 'High';
RETURN @result
END