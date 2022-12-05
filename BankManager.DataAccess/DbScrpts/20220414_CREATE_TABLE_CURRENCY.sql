CREATE TABLE Currency(
Id int PRIMARY KEY NOT NULL IDENTITY(1,1),
Name nvarchar(50) NOT NULL,
Code nvarchar(50) NOT NULL,
CreationDate datetime NOT NULL,
CreatorId int FOREIGN KEY REFERENCES Users(Id)
);