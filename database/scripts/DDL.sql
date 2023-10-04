CREATE DATABASE HealthClinicRebeca;

USE HealthClinicRebeca;

CREATE TABLE Clinica
(
	IdClinica INT PRIMARY KEY IDENTITY,
	Endereco VARCHAR(30) NOT NULL,
	CNPJ VARCHAR(14) NOT NULL,
	NomeFantasia  VARCHAR(30) NOT NULL,
	RazaoSoial VARCHAR(50) NOT NULL,
	HorarioAbertura TIME NOT NULL,
	HorarioEncerramento TIME NOT NULL
);

CREATE TABLE TipoDeUsuario
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(30) NOT NULL
);

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoDeUsuario(IdTipoUsuario),
	Email VARCHAR(50) NOT NULL UNIQUE,
	Senha VARCHAR(50) NOT NULL
);

CREATE TABLE Especialidade
(
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	TipoEspecialidade VARCHAR(50) NOT NULL
);

CREATE TABLE Medico
(
	IdMedico INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) UNIQUE,
	NomeMedico VARCHAR(50) NOT NULL,
	IdEspecialidade INT FOREIGN KEY REFERENCES Especialidade(IdEspecialidade),
	CRM VARCHAR(6) NOT NULL
);

CREATE TABLE Paciente
(
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) UNIQUE,
	NomePaciente VARCHAR(50) NOT NULL,
	CPF VARCHAR(16) NOT NULL,
	Telefone VARCHAR(16) NOT NULL,
	Idade VARCHAR (3) NOT NULL
);

CREATE TABLE StatusConsulta
(
	IdStatusConsulta INT PRIMARY KEY IDENTITY,
	StatusConsulta VARCHAR(15) NOT NULL
);

CREATE TABLE Consulta
(
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica),
	IdStatusConsulta INT FOREIGN KEY REFERENCES StatusConsulta(IdStatusConsulta),
	IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico),
	IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente),
	DataConsulta DATE NOT NULL,
	Horario TIME NOT NULL,
	Descricao VARCHAR(100)
);

CREATE TABLE Prontuario
(
	IdProntuario INT PRIMARY KEY IDENTITY,
	IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico),
	IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente),
	DescricaoProntuario VARCHAR(500)
);

CREATE TABLE Comentario
(
	IdComentario INT PRIMARY KEY IDENTITY,
	IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente),
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica),
	Comentario VARCHAR(256)
);