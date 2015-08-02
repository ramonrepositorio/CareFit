
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/02/2015 20:01:16
-- Generated from EDMX file: D:\Ramon\CareFit\Workspace\CareFit\CareFit.Domain\Repository\CareFit.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CareFit];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Empresas_Imagens]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empresas] DROP CONSTRAINT [FK_Empresas_Imagens];
GO
IF OBJECT_ID(N'[dbo].[FK_Equipamentos_Empresas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipamentos] DROP CONSTRAINT [FK_Equipamentos_Empresas];
GO
IF OBJECT_ID(N'[dbo].[FK_Equipamentos_EquipamentoTipos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipamentos] DROP CONSTRAINT [FK_Equipamentos_EquipamentoTipos];
GO
IF OBJECT_ID(N'[dbo].[FK_Equipamentos_Salas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipamentos] DROP CONSTRAINT [FK_Equipamentos_Salas];
GO
IF OBJECT_ID(N'[dbo].[FK_Exercicio_Empresas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exercicios] DROP CONSTRAINT [FK_Exercicio_Empresas];
GO
IF OBJECT_ID(N'[dbo].[FK_Exercicio_ExercicioTipo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exercicios] DROP CONSTRAINT [FK_Exercicio_ExercicioTipo];
GO
IF OBJECT_ID(N'[dbo].[FK_ExercicioEquipamentos_Equipamentos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExercicioEquipamentos] DROP CONSTRAINT [FK_ExercicioEquipamentos_Equipamentos];
GO
IF OBJECT_ID(N'[dbo].[FK_ExercicioEquipamentos_Exercicios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExercicioEquipamentos] DROP CONSTRAINT [FK_ExercicioEquipamentos_Exercicios];
GO
IF OBJECT_ID(N'[dbo].[FK_Exercicios_Equipamentos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exercicios] DROP CONSTRAINT [FK_Exercicios_Equipamentos];
GO
IF OBJECT_ID(N'[dbo].[FK_Exercicios_GrupoMuscular]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Exercicios] DROP CONSTRAINT [FK_Exercicios_GrupoMuscular];
GO
IF OBJECT_ID(N'[dbo].[FK_Menus_Menus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Menus] DROP CONSTRAINT [FK_Menus_Menus];
GO
IF OBJECT_ID(N'[dbo].[FK_Menus_Permissoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Menus] DROP CONSTRAINT [FK_Menus_Permissoes];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaAmigos_Pessoas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaAmigos] DROP CONSTRAINT [FK_PessoaAmigos_Pessoas];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaAmigos_Pessoas1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaAmigos] DROP CONSTRAINT [FK_PessoaAmigos_Pessoas1];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaEmpresas_Empresas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaEmpresas] DROP CONSTRAINT [FK_PessoaEmpresas_Empresas];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaEmpresas_Pessoas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaEmpresas] DROP CONSTRAINT [FK_PessoaEmpresas_Pessoas];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaEmpresas_PessoaTipos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaEmpresas] DROP CONSTRAINT [FK_PessoaEmpresas_PessoaTipos];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaMensagens_Pessoas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaMensagens] DROP CONSTRAINT [FK_PessoaMensagens_Pessoas];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaMensagens_Pessoas1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaMensagens] DROP CONSTRAINT [FK_PessoaMensagens_Pessoas1];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaPosts_PessoaPostTipos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaPosts] DROP CONSTRAINT [FK_PessoaPosts_PessoaPostTipos];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaPosts_Pessoas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaPosts] DROP CONSTRAINT [FK_PessoaPosts_Pessoas];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaProfessor_Pessoas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaProfessor] DROP CONSTRAINT [FK_PessoaProfessor_Pessoas];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaProfessor_Pessoas1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaProfessor] DROP CONSTRAINT [FK_PessoaProfessor_Pessoas1];
GO
IF OBJECT_ID(N'[dbo].[FK_Pessoas_Imagens]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pessoas] DROP CONSTRAINT [FK_Pessoas_Imagens];
GO
IF OBJECT_ID(N'[dbo].[FK_Pessoas_Pessoas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pessoas] DROP CONSTRAINT [FK_Pessoas_Pessoas];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaSolicitacaoAmizades_Pessoas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaSolicitacaoAmizades] DROP CONSTRAINT [FK_PessoaSolicitacaoAmizades_Pessoas];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaSolicitacaoAmizades_PessoaSolicitacoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaSolicitacaoAmizades] DROP CONSTRAINT [FK_PessoaSolicitacaoAmizades_PessoaSolicitacoes];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaSolicitacaoEmpresa_Empresas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaSolicitacaoEmpresa] DROP CONSTRAINT [FK_PessoaSolicitacaoEmpresa_Empresas];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaSolicitacaoEmpresa_PessoaSolicitacoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaSolicitacaoEmpresa] DROP CONSTRAINT [FK_PessoaSolicitacaoEmpresa_PessoaSolicitacoes];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaSolicitacoes_Pessoas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaSolicitacoes] DROP CONSTRAINT [FK_PessoaSolicitacoes_Pessoas];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaSolicitacoes_PessoaSolicitacaoTipo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaSolicitacoes] DROP CONSTRAINT [FK_PessoaSolicitacoes_PessoaSolicitacaoTipo];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaTipoPermissoes_Permissoes1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaTipoPermissoes] DROP CONSTRAINT [FK_PessoaTipoPermissoes_Permissoes1];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaTipoPermissoes_PessoaTipos1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaTipoPermissoes] DROP CONSTRAINT [FK_PessoaTipoPermissoes_PessoaTipos1];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaToken_Pessoas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaToken] DROP CONSTRAINT [FK_PessoaToken_Pessoas];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaTreino_Pessoas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaTreino] DROP CONSTRAINT [FK_PessoaTreino_Pessoas];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaTreino_Treinos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaTreino] DROP CONSTRAINT [FK_PessoaTreino_Treinos];
GO
IF OBJECT_ID(N'[dbo].[FK_PessoaTreinoEfetuado_PessoaTreino]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PessoaTreinoEfetuado] DROP CONSTRAINT [FK_PessoaTreinoEfetuado_PessoaTreino];
GO
IF OBJECT_ID(N'[dbo].[FK_Salas_Empresas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Salas] DROP CONSTRAINT [FK_Salas_Empresas];
GO
IF OBJECT_ID(N'[dbo].[FK_TreinoEmpresa_Empresas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TreinoEmpresa] DROP CONSTRAINT [FK_TreinoEmpresa_Empresas];
GO
IF OBJECT_ID(N'[dbo].[FK_TreinoEmpresa_Treinos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TreinoEmpresa] DROP CONSTRAINT [FK_TreinoEmpresa_Treinos];
GO
IF OBJECT_ID(N'[dbo].[FK_TreinoExercicios_Exercicios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TreinoExercicios] DROP CONSTRAINT [FK_TreinoExercicios_Exercicios];
GO
IF OBJECT_ID(N'[dbo].[FK_TreinoExercicios_Treinos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TreinoExercicios] DROP CONSTRAINT [FK_TreinoExercicios_Treinos];
GO
IF OBJECT_ID(N'[dbo].[FK_TreinoProfessor_Pessoas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TreinoProfessor] DROP CONSTRAINT [FK_TreinoProfessor_Pessoas];
GO
IF OBJECT_ID(N'[dbo].[FK_TreinoProfessor_Treinos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TreinoProfessor] DROP CONSTRAINT [FK_TreinoProfessor_Treinos];
GO
IF OBJECT_ID(N'[dbo].[FK_Treinos_Pessoas1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treinos] DROP CONSTRAINT [FK_Treinos_Pessoas1];
GO
IF OBJECT_ID(N'[dbo].[FK_Treinos_TreinoTipos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treinos] DROP CONSTRAINT [FK_Treinos_TreinoTipos];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Empresas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empresas];
GO
IF OBJECT_ID(N'[dbo].[Equipamentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipamentos];
GO
IF OBJECT_ID(N'[dbo].[EquipamentoTipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EquipamentoTipos];
GO
IF OBJECT_ID(N'[dbo].[ExercicioEquipamentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExercicioEquipamentos];
GO
IF OBJECT_ID(N'[dbo].[Exercicios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Exercicios];
GO
IF OBJECT_ID(N'[dbo].[ExercicioTipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExercicioTipos];
GO
IF OBJECT_ID(N'[dbo].[GrupoMuscular]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GrupoMuscular];
GO
IF OBJECT_ID(N'[dbo].[Imagens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Imagens];
GO
IF OBJECT_ID(N'[dbo].[Menus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Menus];
GO
IF OBJECT_ID(N'[dbo].[Permissoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permissoes];
GO
IF OBJECT_ID(N'[dbo].[PessoaAmigos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaAmigos];
GO
IF OBJECT_ID(N'[dbo].[PessoaEmpresas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaEmpresas];
GO
IF OBJECT_ID(N'[dbo].[PessoaMensagens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaMensagens];
GO
IF OBJECT_ID(N'[dbo].[PessoaPosts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaPosts];
GO
IF OBJECT_ID(N'[dbo].[PessoaPostTipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaPostTipos];
GO
IF OBJECT_ID(N'[dbo].[PessoaProfessor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaProfessor];
GO
IF OBJECT_ID(N'[dbo].[Pessoas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pessoas];
GO
IF OBJECT_ID(N'[dbo].[PessoaSolicitacaoAmizades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaSolicitacaoAmizades];
GO
IF OBJECT_ID(N'[dbo].[PessoaSolicitacaoEmpresa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaSolicitacaoEmpresa];
GO
IF OBJECT_ID(N'[dbo].[PessoaSolicitacaoTipo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaSolicitacaoTipo];
GO
IF OBJECT_ID(N'[dbo].[PessoaSolicitacoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaSolicitacoes];
GO
IF OBJECT_ID(N'[dbo].[PessoaTipoPermissoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaTipoPermissoes];
GO
IF OBJECT_ID(N'[dbo].[PessoaTipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaTipos];
GO
IF OBJECT_ID(N'[dbo].[PessoaToken]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaToken];
GO
IF OBJECT_ID(N'[dbo].[PessoaTreino]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaTreino];
GO
IF OBJECT_ID(N'[dbo].[PessoaTreinoEfetuado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaTreinoEfetuado];
GO
IF OBJECT_ID(N'[dbo].[Salas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Salas];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TreinoEmpresa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TreinoEmpresa];
GO
IF OBJECT_ID(N'[dbo].[TreinoExercicios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TreinoExercicios];
GO
IF OBJECT_ID(N'[dbo].[TreinoProfessor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TreinoProfessor];
GO
IF OBJECT_ID(N'[dbo].[Treinos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treinos];
GO
IF OBJECT_ID(N'[dbo].[TreinoTipos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TreinoTipos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Empresas'
CREATE TABLE [dbo].[Empresas] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(50)  NOT NULL,
    [ImagemID] bigint  NULL
);
GO

-- Creating table 'Equipamentos'
CREATE TABLE [dbo].[Equipamentos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(100)  NOT NULL,
    [Descricao] varchar(1000)  NOT NULL,
    [EmpresaId] int  NOT NULL,
    [SalaId] int  NULL,
    [Primario] bit  NOT NULL,
    [Ativo] bit  NOT NULL,
    [Secundario] bit  NOT NULL,
    [EquipamentoTipoId] int  NOT NULL,
    [Identificacao] varchar(50)  NULL
);
GO

-- Creating table 'EquipamentoTipos'
CREATE TABLE [dbo].[EquipamentoTipos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Descricao] varchar(50)  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'ExercicioEquipamentos'
CREATE TABLE [dbo].[ExercicioEquipamentos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [EquipamentoID] int  NOT NULL,
    [ExercicioId] int  NOT NULL
);
GO

-- Creating table 'Exercicios'
CREATE TABLE [dbo].[Exercicios] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(50)  NOT NULL,
    [Descricao] varchar(500)  NOT NULL,
    [ExercicioTipoId] int  NOT NULL,
    [RepousoMinimo] int  NOT NULL,
    [EmpresaId] int  NOT NULL,
    [Ativo] bit  NOT NULL,
    [GrupoMuscularId] int  NOT NULL,
    [EquipamentoId] int  NULL
);
GO

-- Creating table 'ExercicioTipos'
CREATE TABLE [dbo].[ExercicioTipos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Descricao] varchar(50)  NOT NULL
);
GO

-- Creating table 'GrupoMuscular'
CREATE TABLE [dbo].[GrupoMuscular] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Descricao] varchar(50)  NOT NULL
);
GO

-- Creating table 'Imagens'
CREATE TABLE [dbo].[Imagens] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [Url] varchar(200)  NOT NULL,
    [Cadastro] datetime  NOT NULL
);
GO

-- Creating table 'Menus'
CREATE TABLE [dbo].[Menus] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Titulo] varchar(50)  NOT NULL,
    [ToolTip] varchar(200)  NOT NULL,
    [Icon] varchar(40)  NULL,
    [Controller] varchar(50)  NULL,
    [Action] varchar(50)  NULL,
    [PermisaoId] int  NOT NULL,
    [MenuId] int  NULL,
    [Ordem] varchar(12)  NOT NULL
);
GO

-- Creating table 'Permissoes'
CREATE TABLE [dbo].[Permissoes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Chave] varchar(100)  NOT NULL,
    [Descricao] varchar(100)  NOT NULL
);
GO

-- Creating table 'PessoaAmigos'
CREATE TABLE [dbo].[PessoaAmigos] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [PessoaId] bigint  NOT NULL,
    [PessoaAmigoId] bigint  NOT NULL,
    [Cadastro] datetime  NOT NULL
);
GO

-- Creating table 'PessoaEmpresas'
CREATE TABLE [dbo].[PessoaEmpresas] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [PessoaId] bigint  NOT NULL,
    [EmpresaId] int  NOT NULL,
    [PessoaTipoId] int  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'PessoaMensagens'
CREATE TABLE [dbo].[PessoaMensagens] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [PessoaRemetenteId] bigint  NOT NULL,
    [PessoaDestinatarioId] bigint  NOT NULL,
    [Mensagem] varchar(max)  NOT NULL,
    [DataEnvio] datetime  NOT NULL,
    [DataVisualizado] datetime  NULL
);
GO

-- Creating table 'PessoaPosts'
CREATE TABLE [dbo].[PessoaPosts] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [PessoaId] bigint  NOT NULL,
    [PessoaPostTipoId] int  NOT NULL,
    [DataPost] datetime  NOT NULL,
    [Post] varchar(max)  NOT NULL
);
GO

-- Creating table 'PessoaPostTipos'
CREATE TABLE [dbo].[PessoaPostTipos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(50)  NOT NULL
);
GO

-- Creating table 'PessoaProfessor'
CREATE TABLE [dbo].[PessoaProfessor] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [PessoaId] bigint  NOT NULL,
    [ProfessorPeopleId] bigint  NOT NULL,
    [Inicio] datetime  NOT NULL,
    [Termino] datetime  NULL
);
GO

-- Creating table 'Pessoas'
CREATE TABLE [dbo].[Pessoas] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [Nome] varchar(100)  NOT NULL,
    [Sobrenome] varchar(100)  NOT NULL,
    [Email] varchar(200)  NOT NULL,
    [Login] varchar(50)  NULL,
    [Senha] varchar(32)  NOT NULL,
    [Cadastro] datetime  NOT NULL,
    [Cpf] varchar(14)  NULL,
    [RG] varchar(12)  NULL,
    [Nascimento] datetime  NOT NULL,
    [Telefone] varchar(20)  NULL,
    [Celular] varchar(20)  NULL,
    [Cep] varchar(9)  NULL,
    [Endereco] varchar(300)  NULL,
    [EnderecoNumero] varchar(10)  NULL,
    [EnderecoComplemento] varchar(30)  NULL,
    [Cidade] varchar(100)  NULL,
    [Estado] varchar(2)  NULL,
    [Bairro] varchar(100)  NULL,
    [ProfessorPessoaId] bigint  NULL,
    [ImagemId] bigint  NULL
);
GO

-- Creating table 'PessoaSolicitacaoAmizades'
CREATE TABLE [dbo].[PessoaSolicitacaoAmizades] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [PessoaAmigoId] bigint  NOT NULL,
    [Aceito] bit  NULL,
    [PessoaSolicitacaoId] bigint  NOT NULL
);
GO

-- Creating table 'PessoaSolicitacaoEmpresa'
CREATE TABLE [dbo].[PessoaSolicitacaoEmpresa] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [PessoaSolicitacaoId] bigint  NOT NULL,
    [EmpresaId] int  NOT NULL,
    [Resposta] bit  NOT NULL
);
GO

-- Creating table 'PessoaSolicitacaoTipo'
CREATE TABLE [dbo].[PessoaSolicitacaoTipo] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Descricao] varchar(100)  NOT NULL
);
GO

-- Creating table 'PessoaSolicitacoes'
CREATE TABLE [dbo].[PessoaSolicitacoes] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [PessoaId] bigint  NOT NULL,
    [Titulo] varchar(200)  NOT NULL,
    [Descricao] varchar(500)  NOT NULL,
    [DataSolicitacao] datetime  NOT NULL,
    [DataResposta] datetime  NULL,
    [PessoaSolicitacaoTipoId] int  NOT NULL
);
GO

-- Creating table 'PessoaTipoPermissoes'
CREATE TABLE [dbo].[PessoaTipoPermissoes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PermissaoID] int  NOT NULL,
    [PessoaTipoID] int  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'PessoaTipos'
CREATE TABLE [dbo].[PessoaTipos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Descricao] varchar(50)  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'PessoaToken'
CREATE TABLE [dbo].[PessoaToken] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [PessoaId] bigint  NOT NULL,
    [Token] varchar(50)  NOT NULL,
    [Cadastro] datetime  NOT NULL,
    [Vencimento] datetime  NOT NULL
);
GO

-- Creating table 'PessoaTreino'
CREATE TABLE [dbo].[PessoaTreino] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [PessoaId] bigint  NOT NULL,
    [TreinoId] bigint  NOT NULL,
    [Inicio] datetime  NOT NULL,
    [Termino] datetime  NULL
);
GO

-- Creating table 'PessoaTreinoEfetuado'
CREATE TABLE [dbo].[PessoaTreinoEfetuado] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [PessoaTreinoId] bigint  NOT NULL,
    [Marcacao] datetime  NOT NULL
);
GO

-- Creating table 'Salas'
CREATE TABLE [dbo].[Salas] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(100)  NOT NULL,
    [EmpresaId] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TreinoEmpresa'
CREATE TABLE [dbo].[TreinoEmpresa] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [EmpresaId] int  NOT NULL,
    [TreinoId] bigint  NOT NULL,
    [Cadastro] datetime  NOT NULL,
    [Cancelamento] datetime  NULL
);
GO

-- Creating table 'TreinoExercicios'
CREATE TABLE [dbo].[TreinoExercicios] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ExercicioId] int  NOT NULL,
    [TreinoId] bigint  NOT NULL,
    [Repeticoes] int  NOT NULL,
    [Ciclos] int  NOT NULL,
    [Carga] int  NULL,
    [Descanso] int  NOT NULL
);
GO

-- Creating table 'TreinoProfessor'
CREATE TABLE [dbo].[TreinoProfessor] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [PessoaId] bigint  NOT NULL,
    [Cadastro] datetime  NOT NULL,
    [Cancelado] datetime  NULL,
    [TreinoId] bigint  NOT NULL
);
GO

-- Creating table 'Treinos'
CREATE TABLE [dbo].[Treinos] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [Repeticoes] int  NOT NULL,
    [RepousoMinimo] int  NOT NULL,
    [TreinoTipoId] int  NOT NULL,
    [PessoaCadastroTreino] bigint  NOT NULL,
    [Titulo] varchar(50)  NOT NULL,
    [Descricao] varchar(100)  NULL,
    [Cor] varchar(7)  NULL
);
GO

-- Creating table 'TreinoTipos'
CREATE TABLE [dbo].[TreinoTipos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Descricao] varchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [PK_Empresas]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Equipamentos'
ALTER TABLE [dbo].[Equipamentos]
ADD CONSTRAINT [PK_Equipamentos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'EquipamentoTipos'
ALTER TABLE [dbo].[EquipamentoTipos]
ADD CONSTRAINT [PK_EquipamentoTipos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ExercicioEquipamentos'
ALTER TABLE [dbo].[ExercicioEquipamentos]
ADD CONSTRAINT [PK_ExercicioEquipamentos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Exercicios'
ALTER TABLE [dbo].[Exercicios]
ADD CONSTRAINT [PK_Exercicios]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ExercicioTipos'
ALTER TABLE [dbo].[ExercicioTipos]
ADD CONSTRAINT [PK_ExercicioTipos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'GrupoMuscular'
ALTER TABLE [dbo].[GrupoMuscular]
ADD CONSTRAINT [PK_GrupoMuscular]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Imagens'
ALTER TABLE [dbo].[Imagens]
ADD CONSTRAINT [PK_Imagens]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [PK_Menus]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Permissoes'
ALTER TABLE [dbo].[Permissoes]
ADD CONSTRAINT [PK_Permissoes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaAmigos'
ALTER TABLE [dbo].[PessoaAmigos]
ADD CONSTRAINT [PK_PessoaAmigos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaEmpresas'
ALTER TABLE [dbo].[PessoaEmpresas]
ADD CONSTRAINT [PK_PessoaEmpresas]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaMensagens'
ALTER TABLE [dbo].[PessoaMensagens]
ADD CONSTRAINT [PK_PessoaMensagens]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaPosts'
ALTER TABLE [dbo].[PessoaPosts]
ADD CONSTRAINT [PK_PessoaPosts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaPostTipos'
ALTER TABLE [dbo].[PessoaPostTipos]
ADD CONSTRAINT [PK_PessoaPostTipos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaProfessor'
ALTER TABLE [dbo].[PessoaProfessor]
ADD CONSTRAINT [PK_PessoaProfessor]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Pessoas'
ALTER TABLE [dbo].[Pessoas]
ADD CONSTRAINT [PK_Pessoas]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaSolicitacaoAmizades'
ALTER TABLE [dbo].[PessoaSolicitacaoAmizades]
ADD CONSTRAINT [PK_PessoaSolicitacaoAmizades]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaSolicitacaoEmpresa'
ALTER TABLE [dbo].[PessoaSolicitacaoEmpresa]
ADD CONSTRAINT [PK_PessoaSolicitacaoEmpresa]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaSolicitacaoTipo'
ALTER TABLE [dbo].[PessoaSolicitacaoTipo]
ADD CONSTRAINT [PK_PessoaSolicitacaoTipo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaSolicitacoes'
ALTER TABLE [dbo].[PessoaSolicitacoes]
ADD CONSTRAINT [PK_PessoaSolicitacoes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaTipoPermissoes'
ALTER TABLE [dbo].[PessoaTipoPermissoes]
ADD CONSTRAINT [PK_PessoaTipoPermissoes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaTipos'
ALTER TABLE [dbo].[PessoaTipos]
ADD CONSTRAINT [PK_PessoaTipos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaToken'
ALTER TABLE [dbo].[PessoaToken]
ADD CONSTRAINT [PK_PessoaToken]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaTreino'
ALTER TABLE [dbo].[PessoaTreino]
ADD CONSTRAINT [PK_PessoaTreino]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PessoaTreinoEfetuado'
ALTER TABLE [dbo].[PessoaTreinoEfetuado]
ADD CONSTRAINT [PK_PessoaTreinoEfetuado]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Salas'
ALTER TABLE [dbo].[Salas]
ADD CONSTRAINT [PK_Salas]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'TreinoEmpresa'
ALTER TABLE [dbo].[TreinoEmpresa]
ADD CONSTRAINT [PK_TreinoEmpresa]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TreinoExercicios'
ALTER TABLE [dbo].[TreinoExercicios]
ADD CONSTRAINT [PK_TreinoExercicios]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TreinoProfessor'
ALTER TABLE [dbo].[TreinoProfessor]
ADD CONSTRAINT [PK_TreinoProfessor]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Treinos'
ALTER TABLE [dbo].[Treinos]
ADD CONSTRAINT [PK_Treinos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TreinoTipos'
ALTER TABLE [dbo].[TreinoTipos]
ADD CONSTRAINT [PK_TreinoTipos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ImagemID] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [FK_Empresas_Imagens]
    FOREIGN KEY ([ImagemID])
    REFERENCES [dbo].[Imagens]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Empresas_Imagens'
CREATE INDEX [IX_FK_Empresas_Imagens]
ON [dbo].[Empresas]
    ([ImagemID]);
GO

-- Creating foreign key on [EmpresaId] in table 'Equipamentos'
ALTER TABLE [dbo].[Equipamentos]
ADD CONSTRAINT [FK_Equipamentos_Empresas]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Equipamentos_Empresas'
CREATE INDEX [IX_FK_Equipamentos_Empresas]
ON [dbo].[Equipamentos]
    ([EmpresaId]);
GO

-- Creating foreign key on [EmpresaId] in table 'Exercicios'
ALTER TABLE [dbo].[Exercicios]
ADD CONSTRAINT [FK_Exercicio_Empresas]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Exercicio_Empresas'
CREATE INDEX [IX_FK_Exercicio_Empresas]
ON [dbo].[Exercicios]
    ([EmpresaId]);
GO

-- Creating foreign key on [EmpresaId] in table 'PessoaEmpresas'
ALTER TABLE [dbo].[PessoaEmpresas]
ADD CONSTRAINT [FK_PessoaEmpresas_Empresas]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaEmpresas_Empresas'
CREATE INDEX [IX_FK_PessoaEmpresas_Empresas]
ON [dbo].[PessoaEmpresas]
    ([EmpresaId]);
GO

-- Creating foreign key on [EmpresaId] in table 'PessoaSolicitacaoEmpresa'
ALTER TABLE [dbo].[PessoaSolicitacaoEmpresa]
ADD CONSTRAINT [FK_PessoaSolicitacaoEmpresa_Empresas]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaSolicitacaoEmpresa_Empresas'
CREATE INDEX [IX_FK_PessoaSolicitacaoEmpresa_Empresas]
ON [dbo].[PessoaSolicitacaoEmpresa]
    ([EmpresaId]);
GO

-- Creating foreign key on [EmpresaId] in table 'Salas'
ALTER TABLE [dbo].[Salas]
ADD CONSTRAINT [FK_Salas_Empresas]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Salas_Empresas'
CREATE INDEX [IX_FK_Salas_Empresas]
ON [dbo].[Salas]
    ([EmpresaId]);
GO

-- Creating foreign key on [EmpresaId] in table 'TreinoEmpresa'
ALTER TABLE [dbo].[TreinoEmpresa]
ADD CONSTRAINT [FK_TreinoEmpresa_Empresas]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreinoEmpresa_Empresas'
CREATE INDEX [IX_FK_TreinoEmpresa_Empresas]
ON [dbo].[TreinoEmpresa]
    ([EmpresaId]);
GO

-- Creating foreign key on [EquipamentoTipoId] in table 'Equipamentos'
ALTER TABLE [dbo].[Equipamentos]
ADD CONSTRAINT [FK_Equipamentos_EquipamentoTipos]
    FOREIGN KEY ([EquipamentoTipoId])
    REFERENCES [dbo].[EquipamentoTipos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Equipamentos_EquipamentoTipos'
CREATE INDEX [IX_FK_Equipamentos_EquipamentoTipos]
ON [dbo].[Equipamentos]
    ([EquipamentoTipoId]);
GO

-- Creating foreign key on [SalaId] in table 'Equipamentos'
ALTER TABLE [dbo].[Equipamentos]
ADD CONSTRAINT [FK_Equipamentos_Salas]
    FOREIGN KEY ([SalaId])
    REFERENCES [dbo].[Salas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Equipamentos_Salas'
CREATE INDEX [IX_FK_Equipamentos_Salas]
ON [dbo].[Equipamentos]
    ([SalaId]);
GO

-- Creating foreign key on [EquipamentoID] in table 'ExercicioEquipamentos'
ALTER TABLE [dbo].[ExercicioEquipamentos]
ADD CONSTRAINT [FK_ExercicioEquipamentos_Equipamentos]
    FOREIGN KEY ([EquipamentoID])
    REFERENCES [dbo].[Equipamentos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExercicioEquipamentos_Equipamentos'
CREATE INDEX [IX_FK_ExercicioEquipamentos_Equipamentos]
ON [dbo].[ExercicioEquipamentos]
    ([EquipamentoID]);
GO

-- Creating foreign key on [EquipamentoId] in table 'Exercicios'
ALTER TABLE [dbo].[Exercicios]
ADD CONSTRAINT [FK_Exercicios_Equipamentos]
    FOREIGN KEY ([EquipamentoId])
    REFERENCES [dbo].[Equipamentos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Exercicios_Equipamentos'
CREATE INDEX [IX_FK_Exercicios_Equipamentos]
ON [dbo].[Exercicios]
    ([EquipamentoId]);
GO

-- Creating foreign key on [ExercicioId] in table 'ExercicioEquipamentos'
ALTER TABLE [dbo].[ExercicioEquipamentos]
ADD CONSTRAINT [FK_ExercicioEquipamentos_Exercicios]
    FOREIGN KEY ([ExercicioId])
    REFERENCES [dbo].[Exercicios]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExercicioEquipamentos_Exercicios'
CREATE INDEX [IX_FK_ExercicioEquipamentos_Exercicios]
ON [dbo].[ExercicioEquipamentos]
    ([ExercicioId]);
GO

-- Creating foreign key on [ExercicioTipoId] in table 'Exercicios'
ALTER TABLE [dbo].[Exercicios]
ADD CONSTRAINT [FK_Exercicio_ExercicioTipo]
    FOREIGN KEY ([ExercicioTipoId])
    REFERENCES [dbo].[ExercicioTipos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Exercicio_ExercicioTipo'
CREATE INDEX [IX_FK_Exercicio_ExercicioTipo]
ON [dbo].[Exercicios]
    ([ExercicioTipoId]);
GO

-- Creating foreign key on [GrupoMuscularId] in table 'Exercicios'
ALTER TABLE [dbo].[Exercicios]
ADD CONSTRAINT [FK_Exercicios_GrupoMuscular]
    FOREIGN KEY ([GrupoMuscularId])
    REFERENCES [dbo].[GrupoMuscular]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Exercicios_GrupoMuscular'
CREATE INDEX [IX_FK_Exercicios_GrupoMuscular]
ON [dbo].[Exercicios]
    ([GrupoMuscularId]);
GO

-- Creating foreign key on [ExercicioId] in table 'TreinoExercicios'
ALTER TABLE [dbo].[TreinoExercicios]
ADD CONSTRAINT [FK_TreinoExercicios_Exercicios]
    FOREIGN KEY ([ExercicioId])
    REFERENCES [dbo].[Exercicios]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreinoExercicios_Exercicios'
CREATE INDEX [IX_FK_TreinoExercicios_Exercicios]
ON [dbo].[TreinoExercicios]
    ([ExercicioId]);
GO

-- Creating foreign key on [ImagemId] in table 'Pessoas'
ALTER TABLE [dbo].[Pessoas]
ADD CONSTRAINT [FK_Pessoas_Imagens]
    FOREIGN KEY ([ImagemId])
    REFERENCES [dbo].[Imagens]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pessoas_Imagens'
CREATE INDEX [IX_FK_Pessoas_Imagens]
ON [dbo].[Pessoas]
    ([ImagemId]);
GO

-- Creating foreign key on [MenuId] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [FK_Menus_Menus]
    FOREIGN KEY ([MenuId])
    REFERENCES [dbo].[Menus]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Menus_Menus'
CREATE INDEX [IX_FK_Menus_Menus]
ON [dbo].[Menus]
    ([MenuId]);
GO

-- Creating foreign key on [PermisaoId] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [FK_Menus_Permissoes]
    FOREIGN KEY ([PermisaoId])
    REFERENCES [dbo].[Permissoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Menus_Permissoes'
CREATE INDEX [IX_FK_Menus_Permissoes]
ON [dbo].[Menus]
    ([PermisaoId]);
GO

-- Creating foreign key on [PermissaoID] in table 'PessoaTipoPermissoes'
ALTER TABLE [dbo].[PessoaTipoPermissoes]
ADD CONSTRAINT [FK_PessoaTipoPermissoes_Permissoes1]
    FOREIGN KEY ([PermissaoID])
    REFERENCES [dbo].[Permissoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaTipoPermissoes_Permissoes1'
CREATE INDEX [IX_FK_PessoaTipoPermissoes_Permissoes1]
ON [dbo].[PessoaTipoPermissoes]
    ([PermissaoID]);
GO

-- Creating foreign key on [PessoaId] in table 'PessoaAmigos'
ALTER TABLE [dbo].[PessoaAmigos]
ADD CONSTRAINT [FK_PessoaAmigos_Pessoas]
    FOREIGN KEY ([PessoaId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaAmigos_Pessoas'
CREATE INDEX [IX_FK_PessoaAmigos_Pessoas]
ON [dbo].[PessoaAmigos]
    ([PessoaId]);
GO

-- Creating foreign key on [PessoaAmigoId] in table 'PessoaAmigos'
ALTER TABLE [dbo].[PessoaAmigos]
ADD CONSTRAINT [FK_PessoaAmigos_Pessoas1]
    FOREIGN KEY ([PessoaAmigoId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaAmigos_Pessoas1'
CREATE INDEX [IX_FK_PessoaAmigos_Pessoas1]
ON [dbo].[PessoaAmigos]
    ([PessoaAmigoId]);
GO

-- Creating foreign key on [PessoaId] in table 'PessoaEmpresas'
ALTER TABLE [dbo].[PessoaEmpresas]
ADD CONSTRAINT [FK_PessoaEmpresas_Pessoas]
    FOREIGN KEY ([PessoaId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaEmpresas_Pessoas'
CREATE INDEX [IX_FK_PessoaEmpresas_Pessoas]
ON [dbo].[PessoaEmpresas]
    ([PessoaId]);
GO

-- Creating foreign key on [PessoaTipoId] in table 'PessoaEmpresas'
ALTER TABLE [dbo].[PessoaEmpresas]
ADD CONSTRAINT [FK_PessoaEmpresas_PessoaTipos]
    FOREIGN KEY ([PessoaTipoId])
    REFERENCES [dbo].[PessoaTipos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaEmpresas_PessoaTipos'
CREATE INDEX [IX_FK_PessoaEmpresas_PessoaTipos]
ON [dbo].[PessoaEmpresas]
    ([PessoaTipoId]);
GO

-- Creating foreign key on [PessoaRemetenteId] in table 'PessoaMensagens'
ALTER TABLE [dbo].[PessoaMensagens]
ADD CONSTRAINT [FK_PessoaMensagens_Pessoas]
    FOREIGN KEY ([PessoaRemetenteId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaMensagens_Pessoas'
CREATE INDEX [IX_FK_PessoaMensagens_Pessoas]
ON [dbo].[PessoaMensagens]
    ([PessoaRemetenteId]);
GO

-- Creating foreign key on [PessoaDestinatarioId] in table 'PessoaMensagens'
ALTER TABLE [dbo].[PessoaMensagens]
ADD CONSTRAINT [FK_PessoaMensagens_Pessoas1]
    FOREIGN KEY ([PessoaDestinatarioId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaMensagens_Pessoas1'
CREATE INDEX [IX_FK_PessoaMensagens_Pessoas1]
ON [dbo].[PessoaMensagens]
    ([PessoaDestinatarioId]);
GO

-- Creating foreign key on [PessoaPostTipoId] in table 'PessoaPosts'
ALTER TABLE [dbo].[PessoaPosts]
ADD CONSTRAINT [FK_PessoaPosts_PessoaPostTipos]
    FOREIGN KEY ([PessoaPostTipoId])
    REFERENCES [dbo].[PessoaPostTipos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaPosts_PessoaPostTipos'
CREATE INDEX [IX_FK_PessoaPosts_PessoaPostTipos]
ON [dbo].[PessoaPosts]
    ([PessoaPostTipoId]);
GO

-- Creating foreign key on [PessoaId] in table 'PessoaPosts'
ALTER TABLE [dbo].[PessoaPosts]
ADD CONSTRAINT [FK_PessoaPosts_Pessoas]
    FOREIGN KEY ([PessoaId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaPosts_Pessoas'
CREATE INDEX [IX_FK_PessoaPosts_Pessoas]
ON [dbo].[PessoaPosts]
    ([PessoaId]);
GO

-- Creating foreign key on [PessoaId] in table 'PessoaProfessor'
ALTER TABLE [dbo].[PessoaProfessor]
ADD CONSTRAINT [FK_PessoaProfessor_Pessoas]
    FOREIGN KEY ([PessoaId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaProfessor_Pessoas'
CREATE INDEX [IX_FK_PessoaProfessor_Pessoas]
ON [dbo].[PessoaProfessor]
    ([PessoaId]);
GO

-- Creating foreign key on [ProfessorPeopleId] in table 'PessoaProfessor'
ALTER TABLE [dbo].[PessoaProfessor]
ADD CONSTRAINT [FK_PessoaProfessor_Pessoas1]
    FOREIGN KEY ([ProfessorPeopleId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaProfessor_Pessoas1'
CREATE INDEX [IX_FK_PessoaProfessor_Pessoas1]
ON [dbo].[PessoaProfessor]
    ([ProfessorPeopleId]);
GO

-- Creating foreign key on [ProfessorPessoaId] in table 'Pessoas'
ALTER TABLE [dbo].[Pessoas]
ADD CONSTRAINT [FK_Pessoas_Pessoas]
    FOREIGN KEY ([ProfessorPessoaId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pessoas_Pessoas'
CREATE INDEX [IX_FK_Pessoas_Pessoas]
ON [dbo].[Pessoas]
    ([ProfessorPessoaId]);
GO

-- Creating foreign key on [PessoaAmigoId] in table 'PessoaSolicitacaoAmizades'
ALTER TABLE [dbo].[PessoaSolicitacaoAmizades]
ADD CONSTRAINT [FK_PessoaSolicitacaoAmizades_Pessoas]
    FOREIGN KEY ([PessoaAmigoId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaSolicitacaoAmizades_Pessoas'
CREATE INDEX [IX_FK_PessoaSolicitacaoAmizades_Pessoas]
ON [dbo].[PessoaSolicitacaoAmizades]
    ([PessoaAmigoId]);
GO

-- Creating foreign key on [PessoaId] in table 'PessoaSolicitacoes'
ALTER TABLE [dbo].[PessoaSolicitacoes]
ADD CONSTRAINT [FK_PessoaSolicitacoes_Pessoas]
    FOREIGN KEY ([PessoaId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaSolicitacoes_Pessoas'
CREATE INDEX [IX_FK_PessoaSolicitacoes_Pessoas]
ON [dbo].[PessoaSolicitacoes]
    ([PessoaId]);
GO

-- Creating foreign key on [PessoaId] in table 'PessoaToken'
ALTER TABLE [dbo].[PessoaToken]
ADD CONSTRAINT [FK_PessoaToken_Pessoas]
    FOREIGN KEY ([PessoaId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaToken_Pessoas'
CREATE INDEX [IX_FK_PessoaToken_Pessoas]
ON [dbo].[PessoaToken]
    ([PessoaId]);
GO

-- Creating foreign key on [PessoaId] in table 'PessoaTreino'
ALTER TABLE [dbo].[PessoaTreino]
ADD CONSTRAINT [FK_PessoaTreino_Pessoas]
    FOREIGN KEY ([PessoaId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaTreino_Pessoas'
CREATE INDEX [IX_FK_PessoaTreino_Pessoas]
ON [dbo].[PessoaTreino]
    ([PessoaId]);
GO

-- Creating foreign key on [PessoaId] in table 'TreinoProfessor'
ALTER TABLE [dbo].[TreinoProfessor]
ADD CONSTRAINT [FK_TreinoProfessor_Pessoas]
    FOREIGN KEY ([PessoaId])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreinoProfessor_Pessoas'
CREATE INDEX [IX_FK_TreinoProfessor_Pessoas]
ON [dbo].[TreinoProfessor]
    ([PessoaId]);
GO

-- Creating foreign key on [PessoaCadastroTreino] in table 'Treinos'
ALTER TABLE [dbo].[Treinos]
ADD CONSTRAINT [FK_Treinos_Pessoas1]
    FOREIGN KEY ([PessoaCadastroTreino])
    REFERENCES [dbo].[Pessoas]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Treinos_Pessoas1'
CREATE INDEX [IX_FK_Treinos_Pessoas1]
ON [dbo].[Treinos]
    ([PessoaCadastroTreino]);
GO

-- Creating foreign key on [PessoaSolicitacaoId] in table 'PessoaSolicitacaoAmizades'
ALTER TABLE [dbo].[PessoaSolicitacaoAmizades]
ADD CONSTRAINT [FK_PessoaSolicitacaoAmizades_PessoaSolicitacoes]
    FOREIGN KEY ([PessoaSolicitacaoId])
    REFERENCES [dbo].[PessoaSolicitacoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaSolicitacaoAmizades_PessoaSolicitacoes'
CREATE INDEX [IX_FK_PessoaSolicitacaoAmizades_PessoaSolicitacoes]
ON [dbo].[PessoaSolicitacaoAmizades]
    ([PessoaSolicitacaoId]);
GO

-- Creating foreign key on [PessoaSolicitacaoId] in table 'PessoaSolicitacaoEmpresa'
ALTER TABLE [dbo].[PessoaSolicitacaoEmpresa]
ADD CONSTRAINT [FK_PessoaSolicitacaoEmpresa_PessoaSolicitacoes]
    FOREIGN KEY ([PessoaSolicitacaoId])
    REFERENCES [dbo].[PessoaSolicitacoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaSolicitacaoEmpresa_PessoaSolicitacoes'
CREATE INDEX [IX_FK_PessoaSolicitacaoEmpresa_PessoaSolicitacoes]
ON [dbo].[PessoaSolicitacaoEmpresa]
    ([PessoaSolicitacaoId]);
GO

-- Creating foreign key on [PessoaSolicitacaoTipoId] in table 'PessoaSolicitacoes'
ALTER TABLE [dbo].[PessoaSolicitacoes]
ADD CONSTRAINT [FK_PessoaSolicitacoes_PessoaSolicitacaoTipo]
    FOREIGN KEY ([PessoaSolicitacaoTipoId])
    REFERENCES [dbo].[PessoaSolicitacaoTipo]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaSolicitacoes_PessoaSolicitacaoTipo'
CREATE INDEX [IX_FK_PessoaSolicitacoes_PessoaSolicitacaoTipo]
ON [dbo].[PessoaSolicitacoes]
    ([PessoaSolicitacaoTipoId]);
GO

-- Creating foreign key on [PessoaTipoID] in table 'PessoaTipoPermissoes'
ALTER TABLE [dbo].[PessoaTipoPermissoes]
ADD CONSTRAINT [FK_PessoaTipoPermissoes_PessoaTipos1]
    FOREIGN KEY ([PessoaTipoID])
    REFERENCES [dbo].[PessoaTipos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaTipoPermissoes_PessoaTipos1'
CREATE INDEX [IX_FK_PessoaTipoPermissoes_PessoaTipos1]
ON [dbo].[PessoaTipoPermissoes]
    ([PessoaTipoID]);
GO

-- Creating foreign key on [TreinoId] in table 'PessoaTreino'
ALTER TABLE [dbo].[PessoaTreino]
ADD CONSTRAINT [FK_PessoaTreino_Treinos]
    FOREIGN KEY ([TreinoId])
    REFERENCES [dbo].[Treinos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaTreino_Treinos'
CREATE INDEX [IX_FK_PessoaTreino_Treinos]
ON [dbo].[PessoaTreino]
    ([TreinoId]);
GO

-- Creating foreign key on [PessoaTreinoId] in table 'PessoaTreinoEfetuado'
ALTER TABLE [dbo].[PessoaTreinoEfetuado]
ADD CONSTRAINT [FK_PessoaTreinoEfetuado_PessoaTreino]
    FOREIGN KEY ([PessoaTreinoId])
    REFERENCES [dbo].[PessoaTreino]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaTreinoEfetuado_PessoaTreino'
CREATE INDEX [IX_FK_PessoaTreinoEfetuado_PessoaTreino]
ON [dbo].[PessoaTreinoEfetuado]
    ([PessoaTreinoId]);
GO

-- Creating foreign key on [TreinoId] in table 'TreinoEmpresa'
ALTER TABLE [dbo].[TreinoEmpresa]
ADD CONSTRAINT [FK_TreinoEmpresa_Treinos]
    FOREIGN KEY ([TreinoId])
    REFERENCES [dbo].[Treinos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreinoEmpresa_Treinos'
CREATE INDEX [IX_FK_TreinoEmpresa_Treinos]
ON [dbo].[TreinoEmpresa]
    ([TreinoId]);
GO

-- Creating foreign key on [TreinoId] in table 'TreinoExercicios'
ALTER TABLE [dbo].[TreinoExercicios]
ADD CONSTRAINT [FK_TreinoExercicios_Treinos]
    FOREIGN KEY ([TreinoId])
    REFERENCES [dbo].[Treinos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreinoExercicios_Treinos'
CREATE INDEX [IX_FK_TreinoExercicios_Treinos]
ON [dbo].[TreinoExercicios]
    ([TreinoId]);
GO

-- Creating foreign key on [TreinoId] in table 'TreinoProfessor'
ALTER TABLE [dbo].[TreinoProfessor]
ADD CONSTRAINT [FK_TreinoProfessor_Treinos]
    FOREIGN KEY ([TreinoId])
    REFERENCES [dbo].[Treinos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TreinoProfessor_Treinos'
CREATE INDEX [IX_FK_TreinoProfessor_Treinos]
ON [dbo].[TreinoProfessor]
    ([TreinoId]);
GO

-- Creating foreign key on [TreinoTipoId] in table 'Treinos'
ALTER TABLE [dbo].[Treinos]
ADD CONSTRAINT [FK_Treinos_TreinoTipos]
    FOREIGN KEY ([TreinoTipoId])
    REFERENCES [dbo].[TreinoTipos]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Treinos_TreinoTipos'
CREATE INDEX [IX_FK_Treinos_TreinoTipos]
ON [dbo].[Treinos]
    ([TreinoTipoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------