USE HealthClinicRebeca;

INSERT INTO Clinica(Endereco, CNPJ, NomeFantasia, RazaoSoial, HorarioAbertura, HorarioEncerramento)
VALUES ('Rua Niterói - 180','12345678901234','HC','Health Clinic','06:00:00','22:00:00')

INSERT INTO TipoDeUsuario(TituloTipoUsuario)
VALUES ('Administrador'),('Médico'), ('Paciente')

INSERT INTO Usuario(IdTipoUsuario, Email, Senha)
VALUES (1,'administrador@adm.com','1234'),
	   (2,'gustavo@lindo.com','rebecameuamor'),
	   (3,'rebeca@linda.com','gustavomeuamor')

INSERT INTO Especialidade(TipoEspecialidade)
VALUES ('Cardiologista'),('Oftalmologista'),('Pediatra')

--MÉDICO 1
INSERT INTO Medico(IdUsuario, NomeMedico, IdEspecialidade, CRM)
VALUES (2,'Gustavo Magalhães',2,'123456')

--MÉDICO 2
INSERT INTO Medico(IdUsuario, NomeMedico, IdEspecialidade, CRM)
VALUES (3,'Ana Liz',3,'654321')

--PACIENTE 1
INSERT INTO Paciente(IdUsuario,NomePaciente, CPF, Telefone, Idade)
VALUES (3,'Rebeca','222.444.666-88','(11)99999-8889','16')

--PACIENTE 2
INSERT INTO Paciente(IdUsuario,NomePaciente, CPF, Telefone, Idade)
VALUES (2,'Lulu','123.456.789-10','(11)11111-2222','20')

INSERT INTO StatusConsulta(StatusConsulta)
VALUES ('Concluído'), ('Cancelada'), ('Agendada')

--CONSULTA 1
INSERT INTO Consulta(IdClinica, IdMedico, IdPaciente, DataConsulta, Horario, Descricao,  IdStatusConsulta)
VALUES(1,1,1,'2023-08-15','13:00:00','Consulta de urgência',3)

--CONSULTA 2
INSERT INTO Consulta(IdClinica, IdMedico, IdPaciente, DataConsulta, Horario, Descricao,  IdStatusConsulta)
VALUES(1,3,6,'2023-08-20','09:00:00','Consulta de rotina',3)

--PRONTUÁRIO 1
INSERT INTO Prontuario(IdMedico,IdPaciente,DescricaoProntuario)
VALUES(1,1,'Realizado exames, paciente desenvolveu Conjutivite e iniciou tratamento!')

--PRONTUÁRIO 2
INSERT INTO Prontuario(IdMedico,IdPaciente,DescricaoProntuario)
VALUES(3,6,'Nenhuma ameaça detectada nos exames de rotina!')

--COMENTÁRIO 1
INSERT INTO Comentario(IdClinica,IdPaciente,Comentario)
VALUES(1,1,'Estou respeitando a medicação e espero melhorar em breve!')

--COMENTÁRIO 2
INSERT INTO Comentario(IdClinica,IdPaciente,Comentario)
VALUES(1,6,'Permaneço saudável!')

DELETE FROM Comentario WHERE IdPaciente = '1';

SELECT * FROM Paciente
SELECT * FROM Medico

SELECT * FROM Consulta