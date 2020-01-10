CREATE  FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50) ,@word VARCHAR(50))
RETURNS BIT
BEGIN

DECLARE @i  INT;
DECLARE @Char VARCHAR(1)
DECLARE @CountSuccessed INT;
SET @CountSuccessed= 0;
SET @i=1;
WHILE (@i<=LEN(@word))
begin
SET @Char = SUBSTRING(@word,@i,1)

IF(CHARINDEX(@Char,@setOfLetters)<>0)
BEGIN
set @CountSuccessed+=1
END
SET @i= @i+1;
end
return IIF(@CountSuccessed=LEN(@word),1,0)
END
