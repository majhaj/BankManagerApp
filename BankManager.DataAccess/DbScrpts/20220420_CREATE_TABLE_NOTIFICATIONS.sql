CREATE TABLE Notifications(
Id int PRIMARY KEY NOT NULL IDENTITY(1,1),
NotifiedByApp int default(0) NOT NULL, 
NotifiedByService int default(0) NOT NULL,
Description nvarchar(50) NOT NULL,
CreatorId int NOT NULL,
CreationDate datetime NOT NULL,
UserToNotifyId int FOREIGN KEY REFERENCES Users(Id) NOT NULL
);