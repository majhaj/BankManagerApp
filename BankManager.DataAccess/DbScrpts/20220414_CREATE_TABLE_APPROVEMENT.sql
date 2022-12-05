CREATE TABLE Approvement(
Id int PRIMARY KEY NOT NULL IDENTITY(1,1),
ApprovementTypeId int FOREIGN KEY REFERENCES ApprovementType(Id),
ApproverId int FOREIGN KEY REFERENCES Users(Id),
ActionDate datetime,
Status numeric(18,0) NOT NULL,
ActionType numeric(18,0)
);