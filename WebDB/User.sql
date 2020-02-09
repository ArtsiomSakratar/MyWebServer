CREATE TABLE [dbo].[User]
(
	[ID] INT NOT NULL PRIMARY KEY,
	Email varchar(50),
	Role int NOT NULL,
	FirstName varchar(50),
	LastName varchar(50),
	Password varchar(50)

)
