
ALTER TABLE dbo.AccountTransactionApprovement
ADD FOREIGN KEY (ApprovementId) REFERENCES Approvement(Id);

ALTER TABLE dbo.AccountTransactionApprovement
ADD FOREIGN KEY ([TransactionId]) REFERENCES AccountTransaction(Id);
