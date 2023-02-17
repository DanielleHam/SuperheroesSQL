CREATE TABLE SuperheroPower(
	SuperheroId int NOT NULL FOREIGN KEY(SuperheroId) REFERENCES Superhero(SuperheroId),
	PowerId int NOT NULL FOREIGN KEY(PowerId) REFERENCES Power(PowerId), 
	CONSTRAINT PK_SuperheroIdPowerId PRIMARY KEY(SuperheroId, PowerId),
);