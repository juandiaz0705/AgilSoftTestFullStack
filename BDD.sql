USE [master]
GO
/****** Object:  Database [Bsis_AgilSoft_JuanDiaz]    Script Date: 21-11-2020 16:17:06 ******/
CREATE DATABASE [Bsis_AgilSoft_JuanDiaz]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bsis_AgilSoft_JuanDiaz', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Bsis_AgilSoft_JuanDiaz.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Bsis_AgilSoft_JuanDiaz_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Bsis_AgilSoft_JuanDiaz_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bsis_AgilSoft_JuanDiaz].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET RECOVERY FULL 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET  MULTI_USER 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Bsis_AgilSoft_JuanDiaz', N'ON'
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET QUERY_STORE = OFF
GO
USE [Bsis_AgilSoft_JuanDiaz]
GO
/****** Object:  Table [dbo].[TBL_ESTADO_TAREAS]    Script Date: 21-11-2020 16:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_ESTADO_TAREAS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_PERFILES]    Script Date: 21-11-2020 16:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_PERFILES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_TAREAS]    Script Date: 21-11-2020 16:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_TAREAS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[ESTADO] [int] NOT NULL,
	[DESCRIPCION] [varchar](150) NULL,
	[USUARIO_ASIGNADO] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_USUARIOS]    Script Date: 21-11-2020 16:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_USUARIOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USER_NAME] [varchar](50) NOT NULL,
	[PASSWORD] [varchar](50) NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
	[ESTADO] [int] NOT NULL,
	[PERFIL] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_ESTADO_TAREAS] ON 

INSERT [dbo].[TBL_ESTADO_TAREAS] ([ID], [DESCRIPCION]) VALUES (1, N'No Resuelto')
INSERT [dbo].[TBL_ESTADO_TAREAS] ([ID], [DESCRIPCION]) VALUES (2, N'Resuelto')
SET IDENTITY_INSERT [dbo].[TBL_ESTADO_TAREAS] OFF
GO
SET IDENTITY_INSERT [dbo].[TBL_PERFILES] ON 

INSERT [dbo].[TBL_PERFILES] ([ID], [DESCRIPCION]) VALUES (1, N'Administrador')
INSERT [dbo].[TBL_PERFILES] ([ID], [DESCRIPCION]) VALUES (2, N'Usuario General')
INSERT [dbo].[TBL_PERFILES] ([ID], [DESCRIPCION]) VALUES (3, N'Usuarios Pruebas')
SET IDENTITY_INSERT [dbo].[TBL_PERFILES] OFF
GO
SET IDENTITY_INSERT [dbo].[TBL_TAREAS] ON 

INSERT [dbo].[TBL_TAREAS] ([ID], [NOMBRE], [ESTADO], [DESCRIPCION], [USUARIO_ASIGNADO]) VALUES (1, N'Tarea 1', 0, N'Prueba de tarea 1', N'1')
INSERT [dbo].[TBL_TAREAS] ([ID], [NOMBRE], [ESTADO], [DESCRIPCION], [USUARIO_ASIGNADO]) VALUES (2, N'Tarea 2', 2, N'Prueba 2 editar', N'1')
SET IDENTITY_INSERT [dbo].[TBL_TAREAS] OFF
GO
SET IDENTITY_INSERT [dbo].[TBL_USUARIOS] ON 

INSERT [dbo].[TBL_USUARIOS] ([ID], [USER_NAME], [PASSWORD], [NOMBRE], [ESTADO], [PERFIL]) VALUES (1, N'jdiaz@agilsoft.cl', N'329946C98666543BAB1177CB65DC7D29', N'Juan Diaz', 1, 1)
SET IDENTITY_INSERT [dbo].[TBL_USUARIOS] OFF
GO
/****** Object:  StoredProcedure [dbo].[SVA_PERFIL]    Script Date: 21-11-2020 16:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SVA_PERFIL]
	@ID INT, @PERFIL VARCHAR(50)
AS
BEGIN

	INSERT INTO [dbo].[TBL_PERFILES]
			([DESCRIPCION])
		VALUES
			(@PERFIL)

END
GO
/****** Object:  StoredProcedure [dbo].[SVA_TAREAS]    Script Date: 21-11-2020 16:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SVA_TAREAS]
	@ID INT, @NOMBRE VARCHAR(50), @ESTADO INT, @DESCRIPCION VARCHAR(150), @USUARIO_ASIGNADO VARCHAR(50)
AS
BEGIN
	IF(@ID = 0)
		BEGIN
			INSERT INTO [dbo].[TBL_TAREAS]
				([NOMBRE]
				,[ESTADO]
				,[DESCRIPCION]
				,[USUARIO_ASIGNADO])
			VALUES
				(@NOMBRE
				,@ESTADO
				,@DESCRIPCION
				,@USUARIO_ASIGNADO)
			END
	ELSE
		BEGIN
			UPDATE [dbo].[TBL_TAREAS]
			SET [NOMBRE] = @NOMBRE
				,[ESTADO] = @ESTADO
				,[DESCRIPCION] = @DESCRIPCION
				,[USUARIO_ASIGNADO] = @USUARIO_ASIGNADO
			WHERE ID = @ID
		END
END
GO
/****** Object:  StoredProcedure [dbo].[SVA_USUARIOS]    Script Date: 21-11-2020 16:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SVA_USUARIOS]
	@ID INT, @USER_NAME VARCHAR(50), @PASSWORD VARCHAR(50), @NOMBRE VARCHAR(100), @ESTADO INT, @PERFIL INT
AS
BEGIN

	IF(@ID = 0)
		BEGIN
			INSERT INTO [dbo].[TBL_USUARIOS]
				([USER_NAME]
				,[PASSWORD]
				,[NOMBRE]
				,[ESTADO]
				,[PERFIL])
			VALUES
				(@USER_NAME
				,HashBytes('MD5',@PASSWORD)
				,@NOMBRE
				,@ESTADO
				,@PERFIL)
		END
	ELSE	
		BEGIN
			UPDATE [dbo].[TBL_USUARIOS]
			SET [USER_NAME] = @USER_NAME
				,[NOMBRE] = @NOMBRE
				,[ESTADO] = @ESTADO
				,[PERFIL] = @PERFIL
			WHERE ID = @ID
		END
END
GO
/****** Object:  StoredProcedure [dbo].[SVC_GET_TAREAS]    Script Date: 21-11-2020 16:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- SVC_GET_TAREAS 1
CREATE PROCEDURE [dbo].[SVC_GET_TAREAS] 
	@USER_ID INT
AS
BEGIN
	DECLARE @PERFIL INT = (SELECT PERFIL FROM TBL_USUARIOS WHERE ID = @USER_ID);

	IF( @PERFIL = 1)
		BEGIN
			SELECT T1.[ID]
				,T1.[NOMBRE]
				,T1.[ESTADO]
				,T1.[DESCRIPCION]
				,T2.DESCRIPCION AS 'ESTADO_DESCRIPCION'
				,T1.USUARIO_ASIGNADO
				,T3.NOMBRE AS 'NOMBRE_USUARIO'
			FROM [Bsis_AgilSoft_JuanDiaz].[dbo].[TBL_TAREAS] T1
			INNER JOIN TBL_ESTADO_TAREAS T2 ON T1.ESTADO = T2.ID
			INNER JOIN TBL_USUARIOS T3 ON T1.USUARIO_ASIGNADO = T3.ID
			WHERE T1.ESTADO <> 0
		END
	ELSE	
		BEGIN
			SELECT T1.[ID]
				,T1.[NOMBRE]
				,T1.[ESTADO]
				,T1.[DESCRIPCION]
				,T2.DESCRIPCION AS 'ESTADO_DESCRIPCION'
				,T1.USUARIO_ASIGNADO
				,T3.NOMBRE AS 'NOMBRE_USUARIO'
			FROM [Bsis_AgilSoft_JuanDiaz].[dbo].[TBL_TAREAS] T1
			INNER JOIN TBL_ESTADO_TAREAS T2 ON T1.ESTADO = T2.ID
			INNER JOIN TBL_USUARIOS T3 ON T1.USUARIO_ASIGNADO = T3.ID
			WHERE T1.ESTADO <> 0 AND T1.USUARIO_ASIGNADO = @USER_ID
		END

	SELECT [ID]
      ,[NOMBRE]
  FROM [Bsis_AgilSoft_JuanDiaz].[dbo].[TBL_USUARIOS]
  WHERE ESTADO = 1
END
GO
/****** Object:  StoredProcedure [dbo].[SVC_GET_USUARIO]    Script Date: 21-11-2020 16:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SVC_GET_USUARIO]
	@USER VARCHAR(50), @PASS VARCHAR(100)
AS
BEGIN
	SELECT [ID]
	  ,[NOMBRE]
      ,[PERFIL]
  FROM [Bsis_AgilSoft_JuanDiaz].[dbo].[TBL_USUARIOS] t1
  WHERE ESTADO = 1 and t1.USER_NAME = @USER AND t1.PASSWORD = CONVERT(VARCHAR(32), HashBytes('MD5', '19354842'), 2) --AND USER_NAME = @USER
END
GO
/****** Object:  StoredProcedure [dbo].[SVC_GET_USUARIOS]    Script Date: 21-11-2020 16:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SVC_GET_USUARIOS] 
AS
BEGIN

	SELECT T1.[ID]
		,[USER_NAME]
		,[NOMBRE]
		,[ESTADO]
		, CASE WHEN ESTADO = 1 THEN 'ACTIVO' ELSE 'INACTIVO' END AS ESTADO_DESCRIPCION
		,[PERFIL]
		,T2.DESCRIPCION AS 'PERFIL_DESCRIPCION'
	FROM [Bsis_AgilSoft_JuanDiaz].[dbo].[TBL_USUARIOS] T1
	INNER JOIN TBL_PERFILES T2 ON T1.PERFIL = T2.ID

	SELECT ID, DESCRIPCION FROM TBL_PERFILES
END
GO
USE [master]
GO
ALTER DATABASE [Bsis_AgilSoft_JuanDiaz] SET  READ_WRITE 
GO
