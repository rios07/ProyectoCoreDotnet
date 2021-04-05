-- =====================================================
-- Author:		Dpto de Sistemas - IATASA
-- Create date: 01/06/2018 
-- Description:	17__Core__SP_REGISTROS - DB_MVC_P1
-- =====================================================

USE DB_MVC_P1
GO

-- =====================================================
-- 17__Core__SP_REGISTROS - Inicio
-- -------------------------




-- SP-TABLA: Ambitos - INICIO, -- 46
IF (OBJECT_ID('usp_Ambitos___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_Ambitos___registro_by_@id
GO
CREATE PROCEDURE usp_Ambitos___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = [dbo].[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
		
		IF @sResSQL = ''
			BEGIN
				DECLARE @Resultado		VARCHAR(1000)
				EXEC usp_LogRegistros___listado_HistoriaDeUnRegistro	@Registro_Id = @id
																		,@Tabla = 'Ambitos'
																		,@Resultado = @Resultado OUTPUT
				SELECT 	id
						,Contexto_Id
						,Supervision_Id
						,Contratista_Id
						,Codigo		
						,Nombre		
						,Observaciones
						,Activo
						,@Resultado AS Historia
						
				FROM Ambitos
				WHERE id = @id AND Contexto_Id = @Contexto_Id
			END
	END
GO
-- SP-TABLA: Ambitos - FIN




-- SP-TABLA: Actores - INICIO, -- 48
IF (OBJECT_ID('usp_Actores___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_Actores___registro_by_@id
GO
CREATE PROCEDURE usp_Actores___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = [dbo].[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
		
		IF @sResSQL = ''
			BEGIN
				DECLARE @Resultado		VARCHAR(1000)
				EXEC usp_LogRegistros___listado_HistoriaDeUnRegistro	@Registro_Id = @id
																		,@Tabla = 'Actores'
																		,@Resultado = @Resultado OUTPUT
				SELECT 	ACT.id
						,ACT.Contexto_Id
						--,CONT.Nombre AS Contexto
						,ACT.TipoDe_Actor_Id
						,ACT.Codigo			
						,ACT.Nombre			
						,ACT.Email			
						,ACT.Email2			
						,ACT.Telefono		
						,ACT.Telefono2		
						,ACT.Direccion		
						,ACT.Observaciones	
						,ACT.Activo			
						,@Resultado AS Historia
						
				FROM Actores ACT
					--INNER JOIN Contextos CONT ON ACT.Contexto_Id = CONT.id
				WHERE ACT.id = @id
					AND ACT.Contexto_Id = @Contexto_Id
			END
	END
GO
-- SP-TABLA: Actores - FIN




-- SP-TABLA: AdjuntosDeInformes - INICIO
IF (OBJECT_ID('usp_AdjuntosDeInformes___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_AdjuntosDeInformes___registro_by_@id
GO
 CREATE PROCEDURE usp_AdjuntosDeInformes___registro_by_@id
		@id							INT	
	    ,@sResSQL						VARCHAR(1000)			OUTPUT 
    ,@UsuarioQueEjecuta_Id		INT
    AS
	BEGIN
    SET @sResSQL = ''
		DECLARE @Resultado		VARCHAR(1000)
		EXEC usp_LogRegistros___listado_HistoriaDeUnRegistro	@Registro_Id = @id
																,@Tabla = 'AdjuntosDeInformes'
																,@Resultado = @Resultado OUTPUT
		SELECT 	id
				,Informe_Id
				,UbicacionDeCarpeta_Id
				,Nombre
				,ExtensionDeArchivo_Id
				,Orden
				,Texto				 
				,@Resultado AS Historia
				
		FROM AdjuntosDeInformes
		WHERE id = @id
	END
GO
-- SP-TABLA: AdjuntosDeInformes - FIN




-- SP-TABLA: Colores - INICIO, -- 41
IF (OBJECT_ID('usp_Colores___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_Colores___registro_by_@id
GO
CREATE PROCEDURE usp_Colores___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		DECLARE @Resultado		VARCHAR(1000)
		EXEC usp_LogRegistros___listado_HistoriaDeUnRegistro	@Registro_Id = @id
																,@Tabla = 'Colores'
																,@Resultado = @Resultado OUTPUT
		SELECT 	id
				,Nombre
				,CodigoHexadecimal
				,@Resultado AS Historia
				
		FROM Colores
		WHERE id = @id
	END
GO
-- SP-TABLA: Colores - FIN




-- SP-TABLA: Contextos - INICIO, -- 54
IF (OBJECT_ID('usp_Contextos___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_Contextos___registro_by_@id
GO
CREATE PROCEDURE usp_Contextos___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = [dbo].[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
		
		IF @sResSQL = ''
			BEGIN
				DECLARE @Resultado		VARCHAR(1000)
				EXEC usp_LogRegistros___listado_HistoriaDeUnRegistro	@Registro_Id = @id
																		,@Tabla = 'Contextos'
																		,@Resultado = @Resultado OUTPUT
				SELECT 	id
						--,Administrador_Id	
						,Numero				
						,Nombre				
						,Codigo				
						,Observaciones
						,Color_Id
						,ImagenUrl
						,@Resultado AS Historia
						
				FROM Contextos
				WHERE id = @id AND (id = @Contexto_Id OR @Contexto_Id = 0)
			END
	END
GO
-- SP-TABLA: Contextos - FIN




-- SP-TABLA: LogErrores - INICIO, -- 16
IF (OBJECT_ID('usp_LogErrores___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_LogErrores___registro_by_@id
GO
CREATE PROCEDURE usp_LogErrores___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		SELECT 	LERR.id 
				,T.Nombre AS NombreDe_Tabla
				,PAG.Nombre AS NombreDe_Pagina
				,TDLERR.Nombre AS TipoDe_LogError
				,LERR.EstadoDe_LogError_Id
				,LERR.Modulo
				,LERR.Metodo
				,LERR.Mensaje
				,LERR.Observaciones
				
		FROM LogErrores LERR
			INNER JOIN Paginas PAG ON LERR.Pagina_Id = PAG.id
			INNER JOIN Tablas T ON LERR.Tabla_Id = T.id
			INNER JOIN TiposDeLogErrores TDLERR ON LERR.TipoDe_LogError_Id = TDLERR.id
		WHERE LERR.id = @id
	END
GO
-- SP-TABLA: LogErrores - FIN




-- SP-TABLA: LogRegistros - INICIO, -- 19
IF (OBJECT_ID('usp_LogRegistros___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_LogRegistros___registro_by_@id
GO
CREATE PROCEDURE usp_LogRegistros___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		SELECT 	LREG.id 
				,U.LogonName
				,LREG.FechaDeEjecucion
				,T.Nombre
				,LREG.Registro_Id
				,TDLREG.Nombre
				,LREG.ObsLog
				
		FROM LogRegistros LREG
			INNER JOIN Usuarios U ON LREG.UsuarioQueEjecuta_Id = U.id
			INNER JOIN Tablas T ON LREG.Tabla_Id = T.id
			INNER JOIN TiposDeLogRegistros TDLREG ON LREG.TipoDe_LogRegistro_Id = TDLREG.id
		WHERE LREG.id = @id
	END
GO
-- SP-TABLA: LogRegistros - FIN




-- SP-TABLA: Paginas - INICIO, -- 22
IF (OBJECT_ID('usp_Paginas___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_Paginas___registro_by_@id
GO
CREATE PROCEDURE usp_Paginas___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
	
		SELECT 	id 
				,Nombre 
				,Observaciones
				,Tabla_Id
				,FuncionDe_Pagina_Id
				,Titulo
				,Tips
				,PermiteAsignacionDePermisos
				
		FROM Paginas
		WHERE id = @id
	END
GO
-- SP-TABLA: Paginas - FIN




-- SP-TABLA: Paridades - INICIO, -- 23
--
-- SP-TABLA: Paridades - FIN




-- SP-TABLA: Prioridades - INICIO, -- 24
--
-- SP-TABLA: Prioridades - FIN




-- SP-TABLA: Publicaciones - INICIO
IF (OBJECT_ID('usp_Publicaciones___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_Publicaciones___registro_by_@id
GO
CREATE PROCEDURE usp_Publicaciones___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = [dbo].[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
		
		IF @sResSQL = ''
			BEGIN
				DECLARE @Resultado		VARCHAR(1000)
				EXEC usp_LogRegistros___listado_HistoriaDeUnRegistro	@Registro_Id = @id
																		,@Tabla = 'Publicaciones'
																		,@Resultado = @Resultado OUTPUT
				SELECT 	PUB.id
							,dbo.ufc_FormatoFecha(PUB.Fecha) AS Fecha
							,CAST(PUB.Hora AS CHAR(5)) AS Hora
							,PUB.Titulo
							,PUB.NumeroDeVersion
							,PUB.Realizada
							,PUB.Observaciones
							,COALESCE(STUFF((SELECT ', ' + 'Nº ' + CAST(SOP.Numero AS VARCHAR)
								FROM Soporte SOP
								WHERE SOP.Publicacion_Id = PUB.id FOR XML PATH('')),1,1,''), '-') AS Soportes
							,COALESCE(STUFF((SELECT ', ' + SS.Nombre
								FROM RelAsig__Subsistemas__A__Publicaciones RASaP
									INNER JOIN SubSistemas SS ON RASaP.Subsistema_Id = SS.id
								WHERE RASaP.Publicacion_Id = PUB.id FOR XML PATH('')),1,1,''), '-') AS SubSistemas
							--,PUB.Contexto_Id
							--,CONT.Nombre AS Contexto
							,@Resultado AS Historia
						
				FROM Publicaciones PUB
					--INNER JOIN Contextos CONT ON ACT.Contexto_Id = CONT.id
				WHERE PUB.id = @id
					--AND PUB.Contexto_Id = @Contexto_Id
			END
	END
GO
-- SP-TABLA: Publicaciones - FIN




-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Usuarios - INICIO, -- 26
IF (OBJECT_ID('usp_RelAsig__RolesDeUsuarios__A__Usuarios___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Usuarios___registro_by_@id
GO
CREATE PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Usuarios___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		
		DECLARE @Resultado		VARCHAR(1000)
		EXEC usp_LogRegistros___listado_HistoriaDeUnRegistro	@Registro_Id = @id
																,@Tabla = 'RelAsig__RolesDeUsuarios__A__Usuarios'
																,@Resultado = @Resultado OUTPUT
		
		SELECT 	RARU.id
				,RDU.Nombre AS RolDeUsuario				
				,U.Apellido + N', ' + U.Nombre AS NombreDeUsuario
				,RARU.RolDe_Usuario_Id 
				,@Resultado AS Historia
		FROM RelAsig__RolesDeUsuarios__A__Usuarios RARU
			INNER JOIN RolesDeUsuarios RDU ON RARU.RolDe_Usuario_Id = RDU.id
			INNER JOIN Usuarios U ON RARU.Usuario_Id = U.id
		WHERE (RARU.id = @id) 
	END
GO
-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Usuarios - FIN




-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Paginas - INICIO, -- 25
IF (OBJECT_ID('usp_RelAsig__RolesDeUsuarios__A__Paginas___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Paginas___registro_by_@id
GO
CREATE PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Paginas___registro_by_@id
		--@ID_String_ExclusionesDe_RolesDeUsuarios	VARCHAR(50)	='1,11'
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		
		DECLARE @Resultado		VARCHAR(1000)
		EXEC usp_LogRegistros___listado_HistoriaDeUnRegistro	@Registro_Id = @id
																,@Tabla = 'RelAsig__RolesDeUsuarios__A__Paginas'
																,@Resultado = @Resultado OUTPUT
		DECLARE @EsMA			VARCHAR(1000)														
		EXEC usp_VAL_Contexto_Id__by__MasterAdmin @UsuarioQueEjecuta_Id, @EsMA OUTPUT
		
		SELECT 	RPRP.id
				,RDU.Nombre AS RolDe_Usuario
				,PAG.Nombre	AS Pagina
				,PAG.PermiteAsignacionDePermisos
				,RPRP.AutorizadoACargarLaPagina
				,RPRP.AutorizadoAOperarLaPagina
				,RPRP.AutorizadoAVerRegAnulados
				,RPRP.AutorizadoAOperacionesSecundarias
				,@Resultado AS Historia
				
		FROM RelAsig__RolesDeUsuarios__A__Paginas RPRP
			INNER JOIN RolesDeUsuarios RDU ON RPRP.RolDe_Usuario_Id = RDU.id
			INNER JOIN Paginas PAG ON RPRP.Pagina_Id = PAG.id
		WHERE 
			--(
			--	RDU.id NOT IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_ExclusionesDe_RolesDeUsuarios))
			--) 
			--AND
			(
				RPRP.id = @id
			) 
			AND
			(
				RDU.PermiteAsignacionDePermisos = 1 OR @EsMA = ''
			)
	END
GO
-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Paginas - FIN




-- SP-TABLA: RolesDe_Usuario - INICIO
IF (OBJECT_ID('usp_RolesDeUsuarios___campos_@Observaciones_by_@id') IS NOT NULL) DROP PROCEDURE usp_RolesDeUsuarios___campos_@Observaciones_by_@id
GO
CREATE PROCEDURE usp_RolesDeUsuarios___campos_@Observaciones_by_@id

		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@Observaciones				VARCHAR(255)			OUTPUT
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''		
				
		SELECT @Observaciones =	RDU.Observaciones
		FROM RolesDeUsuarios RDU			 
		WHERE (RDU.id = @id) 
		
	END
GO
-- SP-TABLA: RolesDe_Usuario - FIN




-- SP-TABLA: Soporte - INICIO, -- 29
IF (OBJECT_ID('usp_Soporte___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_Soporte___registro_by_@id
GO
CREATE PROCEDURE usp_Soporte___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		DECLARE @Resultado		VARCHAR(1000)
		DECLARE @Tabla_Soporte_Id INT
		SET @Tabla_Soporte_Id = (SELECT id FROM Tablas WHERE Nombre = 'Soporte')
		EXEC usp_LogRegistros___listado_HistoriaDeUnRegistro	@Registro_Id = @id, @Tabla = 'Soporte', @Resultado = @Resultado OUTPUT
						
		SELECT 	SOP.id
				,UCREO.LogonName AS UsuarioQueEjecuta
				,UCREO.Email AS EmailUsuarioQueCreo
				,USOL.LogonName AS UsuarioQueSolicita
				,USOL.Email AS EmailUsuarioQueSolicito
				,SOP.FechaDeEjecucion
				,UCERRO.LogonName AS UsuarioQueCerro
				,SOP.Numero
				,SOP.FechaDeCierre
				,SOP.Texto
				,SOP.EstadoDe_Soporte_Id
				,EDS.Nombre AS EstadoDe_Soporte
				,EDS.Observaciones AS ObservacionesDeEstadoDe_Soporte
				,SOP.Prioridad_Id
				,PRIO.Nombre AS Prioridad
				,SOP.Observaciones
				,SOP.ObservacionesPrivadas
				,SOP.Cerrado
				,SOP.Activo
				,N'images/cbx/imgRealizado_' + CONVERT(VARCHAR(5), SOP.Cerrado) + N'.png' AS img_Cerrado
				,REPLACE(REPLACE(SOP.Cerrado, '1', 'Pedido Cerrado'), '0', 'Pedido Pendiente') AS TextoCerrado
				,@Resultado AS Historia
				
		FROM Soporte SOP
			INNER JOIN LogRegistros LREG ON LREG.Tabla_Id = @Tabla_Soporte_Id AND LREG.Registro_Id = SOP.id AND LREG.TipoDe_LogRegistro_Id = 1 -- 1:CREADO
				INNER JOIN Usuarios UCREO ON LREG.UsuarioQueEjecuta_Id = UCREO.id
			INNER JOIN Usuarios USOL ON SOP.UsuarioQueSolicita_Id = USOL.id
			INNER JOIN Usuarios UCERRO ON SOP.UsuarioQueCerro_Id = UCERRO.id
			INNER JOIN Prioridades PRIO ON SOP.Prioridad_Id = PRIO.id
			INNER JOIN EstadosDeSoporte EDS ON SOP.EstadoDe_Soporte_Id = EDS.id
		WHERE (SOP.id = @id) AND (SOP.FechaDeCierre IS NOT NULL)
	END
GO
-- SP-TABLA: Soporte - FIN


-- SP-TABLA: TareasPendientes  - INICIO, -- 39
IF (OBJECT_ID('usp_TareasPendientes___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_TareasPendientes___registro_by_@id
GO
CREATE PROCEDURE usp_TareasPendientes___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		--DECLARE @Contexto_Id	INT
		--EXEC	@Contexto_Id = [dbo].[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
		SET @sResSQL = ''
		IF @sResSQL = ''
			BEGIN
				DECLARE @Resultado		VARCHAR(1000)
				EXEC usp_LogRegistros___listado_HistoriaDeUnRegistro	@Registro_Id = @id
																		,@Tabla = 'TareasPendientes'
																		,@Resultado = @Resultado OUTPUT
				SELECT 	id
						,COALESCE (UsuarioAsignado_Id, -3) AS UsuarioAsignado_Id
						,Nombre
						,Estado_Id
						,COALESCE (Tabla_Id, -3) AS Tabla_Id
						,COALESCE(Pagina_Id, -3) AS Pagina_Id
						,Prioridad_Id
						,Texto
						,FechaDeCreacion
						,FechaDeCumplimiento
						,@Resultado AS Historia
						
				FROM TareasPendientes
				WHERE id = @id 
				--AND Contexto_Id = @Contexto_Id
			END
	END
GO
-- SP-TABLA: TareasPendientes - FIN



-- SP-TABLA: Tablas - INICIO, -- 30
IF (OBJECT_ID('usp_Tablas___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_Tablas___registro_by_@id
GO
CREATE PROCEDURE usp_Tablas___registro_by_@id
		@id							INT	
	AS
	BEGIN
		SELECT 	id 
				,Nombre
				,Nomenclatura
				,Observaciones
				
		FROM Tablas
		WHERE id = @id
	END
GO
-- SP-TABLA: Tablas - FIN




-- SP-TABLA: TiposDeActores - INICIO, -- 49
IF (OBJECT_ID('usp_TiposDeActores___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_TiposDeActores___registro_by_@id
GO
CREATE PROCEDURE usp_TiposDeActores___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		DECLARE @Resultado		VARCHAR(1000)
		EXEC usp_LogRegistros___listado_HistoriaDeUnRegistro	@Registro_Id = @id
																,@Tabla = 'TiposDeActores'
																,@Resultado = @Resultado OUTPUT
		SELECT 	id
				,Nombre
				,Observaciones
				,@Resultado AS Historia
				
		FROM TiposDeActores
		WHERE id = @id
	END
GO
-- SP-TABLA: TiposDeActores - FIN




-- SP-TABLA: TiposDeLogErrores - INICIO, -- 32
IF (OBJECT_ID('usp_TiposDeLogErrores___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_TiposDeLogErrores___registro_by_@id
GO
CREATE PROCEDURE usp_TiposDeLogErrores___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		SELECT 	id 
				,Nombre

				
		FROM TiposDeLogErrores
		WHERE id = @id
	END
GO
-- SP-TABLA: TiposDeLogErrores - FIN




-- SP-TABLA: TiposDeLogRegistros - INICIO, -- 34
IF (OBJECT_ID('usp_TiposDeLogRegistros___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_TiposDeLogRegistros___registro_by_@id
GO
CREATE PROCEDURE usp_TiposDeLogRegistros___registro_by_@id
		@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		SELECT 	id 
				,Nombre

				
		FROM TiposDeLogRegistros
		WHERE id = @id
	END
GO
-- SP-TABLA: TiposDeLogRegistros - FIN




-- SP-TABLA: Usuarios - INICIO, -- 39
IF (OBJECT_ID('usp_Usuarios___registro_by_@id') IS NOT NULL) DROP PROCEDURE usp_Usuarios___registro_by_@id
GO
CREATE PROCEDURE usp_Usuarios___registro_by_@id
		@ID_String_ExclusionesDe_RolesDeUsuarios			VARCHAR(50)	= ''	
		,@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		DECLARE @Resultado		VARCHAR(1000)
		EXEC usp_LogRegistros___listado_HistoriaDeUnRegistro @Registro_Id = @id, @Tabla = 'Usuarios', @Resultado = @Resultado OUTPUT
		
		SELECT 	U.id 
				,U.LogonName 
				,CON.Codigo
				,U.LogonName + '@' + CON.Codigo AS UserName 
				,U.Nombre
				,U.Apellido
				,U.Apellido + N', ' + U.Nombre AS NombreCompleto
				,U.Email
				,U.Email2
				,U.Telefono
				,U.Telefono2
				,U.Direccion
				,U.Observaciones
				,U.Activo
				,CON.Nombre AS Contexto
				,@Resultado AS Historia
				
		FROM Usuarios U
			INNER JOIN Contextos CON ON U.Contexto_Id = CON.id
			INNER JOIN RelAsig__RolesDeUsuarios__A__Usuarios RARU ON RARU.Usuario_Id = U.id
			INNER JOIN RolesDeUsuarios RDU ON RDU.id = RARU.RolDe_Usuario_Id 
		WHERE 
			(U.UsuarioDeSistema = 0)
			AND 
			(RDU.id NOT IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_ExclusionesDe_RolesDeUsuarios)))
			AND
			(U.id = @id)
		GROUP BY U.id ,U.LogonName,CON.Codigo,U.Nombre,U.Apellido,U.Email,U.Email2,U.Telefono,U.Telefono2,U.Direccion,U.Observaciones,U.Activo,CON.Nombre
	END
GO




IF (OBJECT_ID('usp_Usuarios___Campos_@DatosDelUsuario_by_@id') IS NOT NULL) DROP PROCEDURE usp_Usuarios___Campos_@DatosDelUsuario_by_@id
GO
CREATE PROCEDURE usp_Usuarios___Campos_@DatosDelUsuario_by_@id
		@ID_String_ExclusionesDe_RolesDeUsuarios			VARCHAR(50)	= '1'	
		,@UsuarioQueEjecuta_Id		INT
		,@id						INT	
		,@sResSQL					VARCHAR(1000)			OUTPUT
		,@DatosDelUsuario			VARCHAR(100)			OUTPUT
	AS
	BEGIN
		SELECT @DatosDelUsuario = (U.Apellido  + N', ' + U.Nombre   + N' (' +  U.LogonName  + N')') 
		FROM Usuarios U
			INNER JOIN RelAsig__RolesDeUsuarios__A__Usuarios RARU ON RARU.Usuario_Id = U.id
			INNER JOIN RolesDeUsuarios RDU ON RDU.id = RARU.RolDe_Usuario_Id 
		WHERE 
			(U.UsuarioDeSistema = 0)
			AND 
			(RDU.id NOT IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_ExclusionesDe_RolesDeUsuarios)))
			AND
			(U.id = @id)
		GROUP BY U.id, U.Apellido, U.Nombre, U.LogonName

		IF @DatosDelUsuario IS NOT NULL
			BEGIN
				SET @sResSQL = ''
			END
		ELSE
			BEGIN
				SET @sResSQL = 'No se encontró el usuario'
			END
	END
GO
-- SP-TABLA: Usuarios - FIN




-- ---------------------------------
-- 17__Core__SP_REGISTROS - Fin de la creacion
-- =====================================================