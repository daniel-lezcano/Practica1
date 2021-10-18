/*
Script de implementación para DBPRac1

Una herramienta generó este código.
Los cambios realizados en este archivo podrían generar un comportamiento incorrecto y se perderán si
se vuelve a generar el código.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DBPRac1"
:setvar DefaultFilePrefix "DBPRac1"
:setvar DefaultDataPath "C:\Users\Cross\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Cross\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detectar el modo SQLCMD y deshabilitar la ejecución del script si no se admite el modo SQLCMD.
Para volver a habilitar el script después de habilitar el modo SQLCMD, ejecute lo siguiente:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'El modo SQLCMD debe estar habilitado para ejecutar correctamente este script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Quitando Clave externa [dbo].[FK_INSCRITO_ALUMNO]...';


GO
ALTER TABLE [dbo].[INSCRITO] DROP CONSTRAINT [FK_INSCRITO_ALUMNO];


GO
PRINT N'Quitando Clave externa [dbo].[FK_APODERADO_ALUMNO]...';


GO
ALTER TABLE [dbo].[APODERADO] DROP CONSTRAINT [FK_APODERADO_ALUMNO];


GO
PRINT N'Quitando Clave externa [dbo].[FK_INSCRITO_CURSO]...';


GO
ALTER TABLE [dbo].[INSCRITO] DROP CONSTRAINT [FK_INSCRITO_CURSO];


GO
PRINT N'Iniciando recompilación de la tabla [dbo].[ALUMNO]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ALUMNO] (
    [Id]     INT           NOT NULL,
    [Nombre] NVARCHAR (50) NOT NULL,
    [Ciudad] NVARCHAR (50) NOT NULL,
    [Edad]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ALUMNO])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_ALUMNO] ([Id], [Nombre], [Ciudad], [Edad])
        SELECT   [Id],
                 [Nombre],
                 [Ciudad],
                 [Edad]
        FROM     [dbo].[ALUMNO]
        ORDER BY [Id] ASC;
    END

DROP TABLE [dbo].[ALUMNO];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ALUMNO]', N'ALUMNO';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Iniciando recompilación de la tabla [dbo].[APODERADO]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_APODERADO] (
    [Id]        INT           NOT NULL,
    [Nombre]    NVARCHAR (50) NOT NULL,
    [Telefono]  NVARCHAR (50) NOT NULL,
    [Id_Alumno] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[APODERADO])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_APODERADO] ([Id], [Nombre], [Telefono], [Id_Alumno])
        SELECT   [Id],
                 [Nombre],
                 [Telefono],
                 [Id_Alumno]
        FROM     [dbo].[APODERADO]
        ORDER BY [Id] ASC;
    END

DROP TABLE [dbo].[APODERADO];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_APODERADO]', N'APODERADO';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Iniciando recompilación de la tabla [dbo].[CURSO]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_CURSO] (
    [Cod]          INT           NOT NULL,
    [Nombre]       NVARCHAR (50) NOT NULL,
    [Fecha_Inicio] NVARCHAR (50) NOT NULL,
    [Duracion]     INT           NOT NULL,
    [Valor]        INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Cod] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[CURSO])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_CURSO] ([Cod], [Nombre], [Fecha_Inicio], [Duracion], [Valor])
        SELECT   [Cod],
                 [Nombre],
                 [Fecha_Inicio],
                 [Duracion],
                 [Valor]
        FROM     [dbo].[CURSO]
        ORDER BY [Cod] ASC;
    END

DROP TABLE [dbo].[CURSO];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_CURSO]', N'CURSO';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creando Clave externa [dbo].[FK_INSCRITO_ALUMNO]...';


GO
ALTER TABLE [dbo].[INSCRITO] WITH NOCHECK
    ADD CONSTRAINT [FK_INSCRITO_ALUMNO] FOREIGN KEY ([Id_Alumno]) REFERENCES [dbo].[ALUMNO] ([Id]);


GO
PRINT N'Creando Clave externa [dbo].[FK_APODERADO_ALUMNO]...';


GO
ALTER TABLE [dbo].[APODERADO] WITH NOCHECK
    ADD CONSTRAINT [FK_APODERADO_ALUMNO] FOREIGN KEY ([Id_Alumno]) REFERENCES [dbo].[ALUMNO] ([Id]);


GO
PRINT N'Creando Clave externa [dbo].[FK_INSCRITO_CURSO]...';


GO
ALTER TABLE [dbo].[INSCRITO] WITH NOCHECK
    ADD CONSTRAINT [FK_INSCRITO_CURSO] FOREIGN KEY ([Cod_Curso]) REFERENCES [dbo].[CURSO] ([Cod]);


GO
PRINT N'Comprobando los datos existentes con las restricciones recién creadas';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[INSCRITO] WITH CHECK CHECK CONSTRAINT [FK_INSCRITO_ALUMNO];

ALTER TABLE [dbo].[APODERADO] WITH CHECK CHECK CONSTRAINT [FK_APODERADO_ALUMNO];

ALTER TABLE [dbo].[INSCRITO] WITH CHECK CHECK CONSTRAINT [FK_INSCRITO_CURSO];


GO
PRINT N'Actualización completada.';


GO
