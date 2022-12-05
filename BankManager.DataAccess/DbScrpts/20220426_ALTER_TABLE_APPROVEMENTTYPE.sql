ALTER TABLE dbo.ApprovementType
ALTER COLUMN Code int

ALTER TABLE dbo.ApprovementType
ADD CreatorId int FOREIGN KEY REFERENCES Users(Id)

ALTER TABLE dbo.ApprovementType
ALTER COLUMN CreatorId int NOT NULL