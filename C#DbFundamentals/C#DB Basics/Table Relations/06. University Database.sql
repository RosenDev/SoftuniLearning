CREATE TABLE Majors(
MajorID int primary key,
Name VARCHAR(50)

)


CREATE TABLE Students(
StudentID int primary key,
StudentNumber int ,
StudentName  VARCHAR(50)
,MajorID int foreign key references Majors(MajorID)
)

CREATE TABLE Payments(
PaymentID int primary key,
PaymentDate date,
PaymentAmount decimal(18,2)
,StudentID int foreign key references Students(StudentID)


)

CREATE TABLE Subjects(
SubjectID int primary key
,SubjectName varchar(50)
)

CREATE TABLE Agenda(
StudentID int not null,
SubjectID int not null,
constraint PK_Agenda primary key (StudentID,SubjectID),
constraint FK_Agenda_Subjects
foreign key (SubjectID)references Subjects(SubjectID),
foreign key (StudentID) references Students(StudentID)
)
