CREATE TABLE Users(
Id  BIGINT PRIMARY KEY IDENTITY,
Username varchar(30) NOT NULL,
Password varchar(26) NOT NULL,
ProfilePicture BINARY,
LastLoginTime TIME,
IsDeleted BIT


)


INSERT INTO Users(Username,Password,ProfilePicture,LastLoginTime,IsDeleted) VALUES ('User21','pass',378,'12:30',0),
('User21','pass',378,'12:30',0),('User21','pass',378,'12:30',0),('User21','pass',378,'12:30',0),('User21','pass',378,'12:30',0)