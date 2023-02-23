USE SuperherosDB
CREATE TABLE Superhero(
	SuperheroId int IDENTITY(1, 1) PRIMARY KEY,
 	SuperheroName nvarchar(30) NOT NULL, 
	SuperheroAlias nvarchar(15) NOT NULL,
	SuperheroOrigin nvarchar(30) NOT NULL
);

CREATE TABLE Assistant(
	AssistantId int IDENTITY(1, 1) PRIMARY KEY,
 	AssistantName nvarchar(30) NOT NULL, 
);

CREATE TABLE Power(
	PowerId int IDENTITY(1, 1) PRIMARY KEY,
 	PowerName nvarchar(30) NOT NULL, 
	PowerDescription nvarchar(80) NOT NULL
);