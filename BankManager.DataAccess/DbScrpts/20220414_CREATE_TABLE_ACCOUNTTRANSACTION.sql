CREATE TABLE AccountTransaction(
Id int PRIMARY KEY NOT NULL IDENTITY(1,1),
BankAccountId int FOREIGN KEY REFERENCES BankAccount(Id),
TransactionTypeId int FOREIGN KEY REFERENCES TransactionType(Id),
IsCharge numeric(18,0) default(0) NOT NULL,
Amount numeric(18,0) NOT NULL,
CreationDate datetime NOT NULL,
CreatorId int FOREIGN KEY REFERENCES Users(Id)
);