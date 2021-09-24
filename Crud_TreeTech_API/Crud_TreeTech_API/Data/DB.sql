IF DB_ID('DB_TreeTech') IS NULL
BEGIN

	CREATE DATABASE DB_TreeTech

END
GO

USE DB_TreeTech

GO

/* Criando as Tabelas */
--Tabela de tipos de equipamentos
IF NOT EXISTS (SELECT 1 FROM sys.all_objects WHERE [name] = 'Tipo_Equipamento')
BEGIN

	CREATE TABLE Tipo_Equipamento (ID_Tipo_Equipamento INTEGER IDENTITY(1,1) NOT NULL,
								   NM_Tipo_Equipamento VARCHAR(255) NOT NULL,
								   Observacao          TEXT NULL
							   
	CONSTRAINT PK_ID_Tipo_Equipamento PRIMARY KEY (ID_Tipo_Equipamento))

END
GO

-- Tabela de equipamentos
IF NOT EXISTS (SELECT 1 FROM sys.all_objects WHERE [name] = 'Equipamentos')
BEGIN

	CREATE TABLE Equipamentos (ID_Equipamento      INTEGER IDENTITY(1,1) NOT NULL,
							   NM_Equipamento      VARCHAR(255) NOT NULL,
							   NO_Serie            INTEGER NOT NULL,
							   ID_Tipo_Equipamento INTEGER NOT NULL,
							   DT_Cadastro         DATETIME NOT NULL
						   
	CONSTRAINT PK_ID_Equipamento   PRIMARY KEY (ID_Equipamento),
	CONSTRAINT FK_Equipamento_Tipo FOREIGN KEY (ID_Tipo_Equipamento) REFERENCES Tipo_Equipamento(ID_Tipo_Equipamento),
	CONSTRAINT UQ_NO_Serie UNIQUE (NO_Serie))

END
GO

-- Tabela de Classificacao de alarme
IF NOT EXISTS (SELECT 1 FROM sys.all_objects WHERE [name] = 'Classificacao_Alarmes')
BEGIN

	CREATE TABLE Classificacao_Alarmes (ID_Classificacao_Alarme INTEGER IDENTITY(1,1) NOT NULL,
										NM_Classificacao_Alarme VARCHAR(255) NOT NULL,
										Enviar_Email            BIT NOT NULL DEFAULT 0,
										Observacao              TEXT NULL

	CONSTRAINT PK_ID_Classificacao_Alarme PRIMARY KEY (ID_Classificacao_Alarme))

END
GO

-- Tabela de Alarmes
IF NOT EXISTS (SELECT 1 FROM sys.all_objects WHERE [name] = 'Alarmes')
BEGIN

	CREATE TABLE Alarmes (ID_Alarme               INTEGER IDENTITY(1,1) NOT NULL,
						  NM_Alarme               VARCHAR(255) NOT NULL,
						  ID_Classificacao_Alarme INTEGER NOT NULL,
						  ID_Equipamento          INTEGER NOT NULL,
						  DT_Cadastro             DATETIME NOT NULL,
						  [Status]                BIT NOT NULL
					  
	CONSTRAINT PK_ID_Alarme PRIMARY KEY (ID_Alarme),
	CONSTRAINT FK_Classificacao_Alarme_Alarme FOREIGN KEY (ID_Classificacao_Alarme) REFERENCES Classificacao_Alarmes(ID_Classificacao_Alarme),
	CONSTRAINT FK_Classificacao_Alarme_Equipamento FOREIGN KEY (ID_Equipamento) REFERENCES Equipamentos(ID_Equipamento))

END
GO

-- Tabela de Alarmes atuados
IF NOT EXISTS (SELECT 1 FROM sys.all_objects WHERE [name] = 'Alarmes_Atuados')
BEGIN

	CREATE TABLE Alarmes_Atuados (ID_Alarme_Atuado INTEGER IDENTITY(1,1) NOT NULL,
								  DT_Entrada       DATETIME NOT NULL,
								  DT_Saida         DATETIME NOT NULL,
								  ID_Alarme        INTEGER NOT NULL
							  
	CONSTRAINT PK_ID_Alarme_Atuado PRIMARY KEY (ID_Alarme_Atuado),
	CONSTRAINT FK_Alarme_Atuado_Alarme FOREIGN KEY (ID_Alarme) REFERENCES Alarmes (ID_Alarme))

END
GO

/* Inserções nas tabelas de itens padronizados */
IF NOT EXISTS (SELECT 1 FROM Tipo_Equipamento)
BEGIN

	INSERT INTO Tipo_Equipamento (NM_Tipo_Equipamento)
	VALUES ('Tensão'),
		   ('Corrente'),
		   ('Óleo')

END
GO

IF NOT EXISTS (SELECT 1 FROM Classificacao_Alarmes)
BEGIN

	INSERT INTO Classificacao_Alarmes (NM_Classificacao_Alarme,Enviar_Email)
	VALUES ('Alto',1),
		   ('Médio',0),
		   ('Baixo',0)

END
GO

/* Criando Procedures Para Seleção,Inserção,Atualização e Remoção de registros */
-- Select de todos os registros da tabela de tipo de equipamentos
CREATE OR ALTER PROCEDURE SelectAll_Tipo_Equipamento
AS
BEGIN

	SELECT *
	FROM Tipo_Equipamento

END
GO

-- Select de um registro da tabela de tipo de equipamentos
CREATE OR ALTER PROCEDURE Select_Tipo_Equipamento(

	@ID_Tipo_Equipamento INTEGER

) 
AS
BEGIN

	SELECT *
	FROM Tipo_Equipamento 
	WHERE ID_Tipo_Equipamento = @ID_Tipo_Equipamento

END
GO

-- Insert da tabela de Tipos equipamentos
CREATE OR ALTER PROCEDURE Insert_Tipo_Equipamento(

	@NM_Tipo_Equipamento VARCHAR(255),
	@Observacao Text

) AS
BEGIN

	INSERT INTO Tipo_Equipamento(NM_Tipo_Equipamento,Observacao) 
	VALUES (@NM_Tipo_Equipamento,@Observacao)

END
GO

-- Update da tabela de tipos de equipamentos
CREATE OR ALTER PROCEDURE Update_Tipo_Equipamento(
	
	@ID_Tipo_Equipamento INTEGER,
	@NM_Tipo_Equipamento VARCHAR(255),
	@Observacao Text

) AS
BEGIN

	UPDATE Tipo_Equipamento
	SET NM_Tipo_Equipamento =  @NM_Tipo_Equipamento,
	    Observacao = @Observacao
	WHERE ID_Tipo_Equipamento = @ID_Tipo_Equipamento

END
GO

-- Delete da tabela de tipos de equipamentos
CREATE OR ALTER PROCEDURE Delete_Tipo_Equipamento(
	
	@ID_Tipo_Equipamento INTEGER

) AS
BEGIN
	
	DELETE 
	FROM Tipo_Equipamento
	WHERE ID_Tipo_Equipamento = @ID_Tipo_Equipamento

END
GO

-- Select de todos os registro da tabela de classificação de alarmes
CREATE OR ALTER PROCEDURE SelectAll_Classificacao_Alarmes
AS
BEGIN

	SELECT *
	FROM Classificacao_Alarmes

END
GO

-- Select de um registro da tabela de classificação de alarmes
CREATE OR ALTER PROCEDURE Select_Classificacao_Alarmes(
	
	@ID_Classificacao_Alarme INTEGER

)
AS
BEGIN

	SELECT *
	FROM Classificacao_Alarmes
	WHERE ID_Classificacao_Alarme = @ID_Classificacao_Alarme

END
GO

-- Inserção na tabela de classificação de alarmes
CREATE OR ALTER PROCEDURE Insert_Classificacao_Alarmes(

	@NM_Classificacao_Alarme VARCHAR(255),
	@Enviar_Email BIT,
	@Observacao TEXT

)
AS
BEGIN

	INSERT INTO Classificacao_Alarmes (NM_Classificacao_Alarme,Enviar_Email,Observacao)
	VALUES (@NM_Classificacao_Alarme,@Enviar_Email,@Observacao)

END
GO

-- Update na tabela de classificação de alarmes
CREATE OR ALTER PROCEDURE Update_Classificacao_Alarmes(

	@ID_Classficacao_Alarme INTEGER,
	@NM_Classificacao_Alarme VARCHAR(255),
	@Enviar_Email BIT,
	@Observacao TEXT

)
AS
BEGIN

	UPDATE Classificacao_Alarmes
	SET NM_Classificacao_Alarme = @NM_Classificacao_Alarme,
	    Enviar_Email = @Enviar_Email,
		Observacao = @Observacao
	WHERE ID_Classificacao_Alarme = @ID_Classficacao_Alarme

END
GO

-- Delete da tabela de classificação de alarmes
CREATE OR ALTER PROCEDURE Delete_Classificacao_Alarmes(

	@ID_Classficacao_Alarme INTEGER

)
AS
BEGIN

	DELETE 
	FROM Classificacao_Alarmes
	WHERE ID_Classificacao_Alarme = @ID_Classficacao_Alarme

END
GO

-- Select de todos os registroS da tabela de equipamentos
CREATE OR ALTER PROCEDURE SelectAll_Equipamentos
AS
BEGIN

	SELECT *
	FROM Equipamentos

END
GO

-- Select de um registro da tabela de equipamentos
CREATE OR ALTER PROCEDURE Select_Equipamentos(

	@ID_Equipamento INTEGER

)
AS
BEGIN

	SELECT *
	FROM Equipamentos
	WHERE ID_Equipamento = @ID_Equipamento

END
GO

-- Insert de um registro da tabela de equipamentos
CREATE OR ALTER PROCEDURE Insert_Equipamentos(

	@NM_Equipamento VARCHAR(255),
	@NO_Serie INTEGER,
	@ID_Tipo_Equipamento INTEGER,
	@DT_Cadastro DATETIME

)
AS
BEGIN

	INSERT INTO Equipamentos (NM_Equipamento,NO_Serie,ID_Tipo_Equipamento,DT_Cadastro)
	VALUES (@NM_Equipamento,@NO_Serie,@ID_Tipo_Equipamento,@DT_Cadastro)

END
GO

-- Update da tabela de equipamentos
CREATE OR ALTER PROCEDURE Update_Equipamentos(

	@ID_Equipamento INTEGER,
	@NM_Equipamento VARCHAR(255),
	@NO_Serie INTEGER,
	@ID_Tipo_Equipamento INTEGER

)
AS
BEGIN

	UPDATE Equipamentos
	SET NM_Equipamento = @NM_Equipamento,
	    NO_Serie = @NO_Serie,
		ID_Tipo_Equipamento = @ID_Tipo_Equipamento
	WHERE ID_Equipamento = @ID_Equipamento

END
GO

-- Delete da tabela de equipamentos
CREATE OR ALTER PROCEDURE Delete_Equipamentos(

	@ID_Equipamento INTEGER

)
AS
BEGIN

	DELETE 
	FROM Equipamentos
	WHERE ID_Equipamento = @ID_Equipamento

END
GO

-- Select de todos registros da tabela de alarmes
CREATE OR ALTER PROCEDURE SelectAll_Alarmes
AS
BEGIN

	SELECT * 
	FROM Alarmes

END
GO

-- Select de um registro da tabela de alarmes
CREATE OR ALTER PROCEDURE Select_Alarmes(

	@ID_Alarme INTEGER

)
AS
BEGIN

	SELECT * 
	FROM Alarmes
	WHERE ID_Alarme = @ID_Alarme

END
GO

-- Insert da tabela de alarmes
CREATE OR ALTER PROCEDURE Insert_Alarmes(

	@NM_Alarme VARCHAR(255),
	@ID_Classificacao_Alarme INTEGER,
	@ID_Equipamento INTEGER,
	@DT_Cadastro DATETIME

)
AS
BEGIN

	INSERT INTO Alarmes (NM_Alarme,ID_Classificacao_Alarme,ID_Equipamento,DT_Cadastro,[Status])
	VALUES (@NM_Alarme,@ID_Classificacao_Alarme,@ID_Equipamento,@DT_Cadastro,0)

END
GO

-- Update da tabela de alarmes
CREATE OR ALTER PROCEDURE Update_Alarmes(

	@ID_Alarme INTEGER,
	@NM_Alarme VARCHAR(255),
	@ID_Classificacao_Alarme INTEGER,
	@ID_Equipamento INTEGER,
	@Status BIT 

)
AS
BEGIN

	UPDATE Alarmes
	SET NM_Alarme = @NM_Alarme,
	    ID_Classificacao_Alarme = @ID_Classificacao_Alarme,
		ID_Equipamento = @ID_Equipamento,
		[Status] = @Status
	WHERE ID_Alarme = @ID_Alarme

END
GO

-- Delete da tabela de alarmes
CREATE OR ALTER PROCEDURE Delete_Alarmes(

	@ID_Alarme INTEGER

)
AS
BEGIN

	DELETE
	FROM Alarmes
	WHERE ID_Alarme = @ID_Alarme

END
GO

-- Select de todos registros da tabela de alarmes atuados
CREATE OR ALTER PROCEDURE SelectAll_Alarmes_Atuados
AS
BEGIN

	SELECT * 
	FROM Alarmes_Atuados

END
GO

-- Select de um registro da tabela de alarmes atuados
CREATE OR ALTER PROCEDURE Select_Alarmes_Atuados(

	@ID_Alarme_Atuado INTEGER

)
AS
BEGIN

	SELECT * 
	FROM Alarmes_Atuados
	WHERE ID_Alarme_Atuado = @ID_Alarme_Atuado

END
GO

-- Insert da tabela de alarmes atuados
CREATE OR ALTER PROCEDURE Insert_Alarmes_Atuados(

	@DT_Entrada DATETIME,
	@DT_Saida DATETIME,
	@ID_Alarme INTEGER

)
AS
BEGIN

	INSERT INTO Alarmes_Atuados(DT_Entrada,DT_Saida,ID_Alarme)
	VALUES (@DT_Entrada,@DT_Saida,@ID_Alarme)

END
GO

-- Update da tabela de alarmes atuados
CREATE OR ALTER PROCEDURE Update_Alarmes_Atuados(

	@ID_Alarme_Atuado INTEGER,
	@DT_Saida DATETIME

)
AS
BEGIN

	UPDATE Alarmes_Atuados
	SET DT_Saida = @DT_Saida
	WHERE ID_Alarme = @ID_Alarme_Atuado

END
GO

-- Delete da tabela de alarmes atuados
CREATE OR ALTER PROCEDURE Delete_Alarmes_Atuados(

	@ID_Alarme_Atuado INTEGER

)
AS
BEGIN

	DELETE
	FROM Alarmes_Atuados
	WHERE ID_Alarme_Atuado = @ID_Alarme_Atuado

END
GO