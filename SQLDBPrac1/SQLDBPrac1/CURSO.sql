CREATE TABLE [dbo].[CURSO]
(
	[Cod] INT IDENTITY (1,1) NOT NULL, 
    [Nombre] NVARCHAR(50) NOT NULL, 
    [Fecha_Inicio] NVARCHAR(50) NOT NULL, 
    [Duracion] INT NOT NULL, 
    [Valor] INT NOT NULL
    PRIMARY KEY CLUSTERED ([cod] ASC)
)
