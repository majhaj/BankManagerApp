ALTER TABLE dbo.Approvement
ADD CreatorId int NOT NULL FOREIGN KEY REFERENCES Users(Id)

ALTER TABLE dbo.Approvement
ALTER COLUMN ApprovementTypeId int NOT NULL

ALTER TABLE dbo.Approvement
ALTER COLUMN ApproverId int NOT NULL

ALTER TABLE dbo.Approvement
ALTER COLUMN Status int