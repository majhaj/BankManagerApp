ALTER TABLE dbo.Notifications
ALTER COLUMN NotifiedByApp bit

ALTER TABLE dbo.Notifications
ALTER COLUMN NotifiedByService bit

ALTER TABLE dbo.Notifications
ADD LastModificationDate datetime