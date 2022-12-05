ALTER TABLE dbo.BankAccount
ADD OwnerId int FOREIGN KEY REFERENCES Users(Id),
	CurrencyId int

ALTER TABLE dbo.BankAccount
ADD FOREIGN KEY (CurrencyId) REFERENCES Currency(Id);