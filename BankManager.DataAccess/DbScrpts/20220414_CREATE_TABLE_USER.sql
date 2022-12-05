CREATE TABLE Users(
Id int PRIMARY KEY NOT NULL IDENTITY(1,1),
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(50) NOT NULL,
Email nvarchar(50) NOT NULL,
Birthday datetime NOT NULL,
IsContractor numeric(18,0) default(0) NOT NULL
);