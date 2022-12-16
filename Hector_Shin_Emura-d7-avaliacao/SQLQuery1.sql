USE [db_9];

CREATE TABLE avaliacao(
	Email	VARCHAR(255) NOT NULL UNIQUE,
	Senha	VARCHAR(255) NOT NULL
);

INSERT INTO avaliacao (Email, Senha)
VALUES ('admin@email.com', 'admin123');