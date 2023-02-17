USE SuperherosDB
CREATE TABLE Superhero(
	SuperheroId int IDENTITY(1, 1) PRIMARY KEY,
 	SuperheroName varchar(30) NOT NULL, 
	SuperheroAlias varchar(15) NOT NULL,
	SuperheroOrigin varchar(30) NOT NULL
);

CREATE TABLE Assistant(
	AssistantId int IDENTITY(1, 1) PRIMARY KEY,
 	AssistantName varchar(30) NOT NULL, 
);

CREATE TABLE Power(
	PowerId int IDENTITY(1, 1) PRIMARY KEY,
 	PowerName varchar(30) NOT NULL, 
	PowerDescription varchar(80) NOT NULL
);