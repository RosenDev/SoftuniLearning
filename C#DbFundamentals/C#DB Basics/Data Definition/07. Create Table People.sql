CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] nvarchar(200) NOT NULL,
Picture BINARY,
Height decimal(16,2),
Weight decimal(16,2),
Gender CHAR(1) NOT NULL,
Birthdate DATETIME NOT NULL,
Biography NTEXT 
)

INSERT INTO People(Name,Picture,Height,Weight,Gender,Birthdate,Biography)
VALUES ('PLayer1',202,2,3,'m','02.09.2018','some text here please!!!'),
('PLayer1',202,2,3,'m','02.09.2018','some text here please!!!'),
('PLayer1',202,2,3,'m','02.09.2018','some text here please!!!'),
('PLayer1',202,2,3,'m','02.09.2018','some text here please!!!'),
('PLayer1',202,2,3,'m','02.09.2018','some text here please!!!')