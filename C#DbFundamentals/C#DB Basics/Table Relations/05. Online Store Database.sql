CREATE TABLE Cities(

CityID INT PRIMARY KEY,
Name VARCHAR(50)

)
CREATE TABLE Customers(
CustomerID int primary key,
Name VARCHAR(50),
Birthday date,
CityID int foreign key references Cities(CityID)

)

CREATE TABLE Orders(

OrderID int primary key,
CustomerID int foreign key references Customers(CustomerID),



)
CREATE TABLE ItemTypes(
ItemTypeID int primary key,
Name VARCHAR(50)

)
CREATE TABLE Items(
ItemID int primary key,
Name VARCHAR(50),
ItemTypeID int foreign key references ItemTypes(ItemTypeID) 
)

CREATE TABLE OrderItems(
OrderID int not null,
ItemID int not null,
CONSTRAINT PK_OrderItems
primary key (OrderID,ItemID),
constraint FK_OI_Orders foreign key (OrderID) references Orders(OrderID),
constraint FK_OI_Items foreign key (ItemID) references Items(ItemID)

)


