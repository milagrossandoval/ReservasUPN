USE [BD_RESERVAS]
GO


CREATE TABLE [dbo].[Sancion](
	[id] [int] IDENTITY(1,1) NOT NULL primary key,
	[usuario] [int] NULL,
	[motivo] [varchar](1000) NULL,
	[fechainicio] [date] NOT NULL,
	[fechafin] [date] NULL,
	estado bit NOT NULL)


