CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY,
DirectorName varchar(30) NOT NULL,
Notes varchar(50) NOT NULL
)
CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
GenreName varchar(30) NOT NULL,
Notes varchar(50) NOT NULL
)
CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName varchar(30) NOT NULL,
Notes varchar(50) NOT NULL
)
CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title varchar(30) NOT NULL,
DirectorId int NOT NULL foreign key references Directors,
CopyrightYear DATE,
Length int,
GenreId int NOT NULL foreign key references Genres,
CategoryId  int NOT NULL foreign key references Categories,
Rating int,
Notes varchar(23)

)

INSERT INTO Directors (DirectorName,Notes) VALUES('Dir1','note1'),('Dir2','note2'),('Dir3','note3'),('Dir4','note4'),('Dir5','note5')
INSERT INTO Genres(GenreName,Notes) VALUES('Genre1','note1'),('Genre2','note2'),('Genre3','note3'),('Genre4','note4'),('Genre5','note5')
INSERT INTO Categories (CategoryName,Notes) VALUES  ('C1','note1'),('C2','note2'),('C3','note3'),('C4','note4'),('C5','note5')
INSERT INTO Movies (Title,DirectorId,CopyrightYear,Length,GenreId,CategoryId,Rating,Notes) VALUES('Title1',1,'1990-12-12',35,1,1,5,'none'),('Title1',2,'1990-12-12',35,2,2,5,'none'),('Title1',3,'1990-12-12',35,3,3,5,'none'),('Title1',4,'1990-12-12',35,4,4,5,'none'),('Title1',5,'1990-12-12',35,5,5,5,'none')