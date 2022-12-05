ALTER TABLE dbo.Users
ALTER COLUMN  IsContractor bit

ALTER TABLE dbo.Users
ADD CreationDate datetime,
	LastModificationDate datetime 

ALTER TABLE dbo.Users
ADD DeletionDate datetime

UPDATE dbo.Users 
SET CreationDate = 0 WHERE CreationDate IS NULL;

ALTER TABLE dbo.Users
ALTER COLUMN  CreationDate datetime NOT NULL