USE HealthClinicRebeca;

--LISTA TODAS AS INFORMA��ES DA CONSULTA:
SELECT 
NomeFantasia AS Clinica, 
CONCAT(NomeMedico,' - ',TipoEspecialidade) AS [M�dico & Especialidade], 
NomePaciente AS Paciente, 
DataConsulta AS [Data da Consulta], 
Horario AS [Hor�rio da Consulta], 
Descricao AS [Descri��o da Consulta] , 
StatusConsulta AS [Status]

FROM 
Consulta

INNER JOIN Clinica ON Consulta.IdClinica = Clinica.IdClinica
INNER JOIN Medico ON Consulta.IdMedico = Medico.IdMedico
INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
INNER JOIN Paciente ON Consulta.IdPaciente = Paciente.IdPaciente
INNER JOIN StatusConsulta ON Consulta.IdStatusConsulta = StatusConsulta.IdStatusConsulta

--LISTA M�DICO, PACIENTE E PRONTU�RIO DA CONSULTA:
SELECT 
CONCAT(NomeMedico,' - ',TipoEspecialidade) AS [M�dico & Especialidade], 
NomePaciente AS Paciente,
DescricaoProntuario AS [Descri��o do Prontu�rio]

FROM 
Prontuario

LEFT JOIN Medico ON Prontuario.IdMedico = Medico.IdMedico
INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
LEFT JOIN Paciente ON Prontuario.IdPaciente = Paciente.IdPaciente


--LISTA PACIENTE E COMENT�RIO:
SELECT  
NomePaciente AS Paciente,	
Comentario.Comentario AS Coment�rio
FROM 
Comentario

INNER JOIN Paciente ON Comentario.IdPaciente = Paciente.IdPaciente


--CRIADA FUN��O DE DESAFIO 1
CREATE FUNCTION QNTDMedico(@IdEspecialidade INT)
RETURNS TABLE
AS 
RETURN
(SELECT 
Medico.NomeMedico AS [Nome do M�dico], 
Especialidade.TipoEspecialidade AS [Especialidade]
FROM 
Medico
INNER JOIN Especialidade ON Especialidade.IdEspecialidade =  Medico.IdEspecialidade
WHERE Medico.IdEspecialidade = @IdEspecialidade
)

SELECT * FROM QNTDMedico(2)
SELECT * FROM QNTDMedico(3)



