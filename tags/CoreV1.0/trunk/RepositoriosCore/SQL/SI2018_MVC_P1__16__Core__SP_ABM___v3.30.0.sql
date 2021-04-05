-- =====================================================
-- Author:		Dpto de Sistemas - IATASA
-- Create date: 01/06/2018 
-- Description:	16__Core__SP_ABM
-- =====================================================

--USE DB_MVC_P1
--GO

-- =====================================================
-- 16__Core__SP_ABM - Inicio
-- -------------------------




-- SP-TABLA: Actores - INICIO, --48
IF (OBJECT_ID('usp_Actores___delete_by_@id') IS NOT NULL) DROP PROCEDURE usp_Actores___delete_by_@id
GO
CREATE PROCEDURE usp_Actores___delete_by_@id
		@id								INT		
		
		,@UsuarioQueEjecuta_Id			INT						
		,@FechaDeEjecucion				DATETIME				
		,@ObsLog						VARCHAR(80) = 'DELETED'		
		
		,@sResSQL						VARCHAR(1000)			OUTPUT		
	AS
	BEGIN		
		EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Actores', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Actores'  
					,@FuncionDePagina = 'Delete'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			END

		IF @sResSQL = ''
			BEGIN
				SET @ObsLog = COALESCE(@ObsLog + '', '') + ' // Actor: ' + (SELECT Nombre FROM Actores WHERE id = @id)
				--SET @Existe = (SELECT id FROM Actores WHERE id = @id AND Contexto_Id = @Contexto_Id)
				DELETE Actores FROM Actores WHERE id = @id

				EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Delete  @RowCount = @@ROWCOUNT
				
				IF @sResSQL = ''
					BEGIN	-- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Actores'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '3', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog
					END
			END
	END
GO




IF (OBJECT_ID('usp_Actores___insert') IS NOT NULL) DROP PROCEDURE usp_Actores___insert
GO
CREATE PROCEDURE usp_Actores___insert
		@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@TipoDe_Actor_Id					INT	
		,@Codigo							VARCHAR(6)
		,@Nombre							VARCHAR(50)
		,@Email								VARCHAR(60)	= ''
		,@Email2							VARCHAR(60)	= ''
		,@Telefono							VARCHAR(50)	= ''
		,@Telefono2							VARCHAR(50)	= ''
		,@Direccion							VARCHAR(255) = ''
		,@Observaciones						VARCHAR(255) = ''
		,@sResSQL							VARCHAR(1000)			OUTPUT
		,@id								INT						OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Actores'  
					,@FuncionDePagina = 'Insert'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
		
		IF (@sResSQL = '')
			BEGIN
				-- Supervisión no es un verdadero TIPO
				EXEC @sResSQL = ufc_TipoDe_ActorNOEs_Supervision @TipoDe_Actor_Id = @TipoDe_Actor_Id
				IF (@sResSQL = '')
					BEGIN
						SET NOCOUNT ON
						INSERT INTO Actores
						(
							Contexto_Id	
							,TipoDe_Actor_Id	
							,Codigo			
							,Nombre			
							,Email				
							,Email2			
							,Telefono			
							,Telefono2			
							,Direccion			
							,Observaciones	
							,Activo
						)
						VALUES
						(
							(SELECT Contexto_Id FROM Usuarios WHERE id = @Usuario_Id)	
							,@TipoDe_Actor_Id	
							,@Codigo			
							,@Nombre			
							,@Email				
							,@Email2			
							,@Telefono			
							,@Telefono2			
							,@Direccion			
							,@Observaciones		
							,1
						)
						
						SET @id = SCOPE_IDENTITY()
						
						EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT
						
						IF @sResSQL = ''
							BEGIN	-- Registro el Log
								EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Actores'
								, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
							END
					END
			END
	END
GO




IF (OBJECT_ID('usp_Actores___update_by_@id') IS NOT NULL) DROP PROCEDURE usp_Actores___update_by_@id
GO
CREATE PROCEDURE usp_Actores___update_by_@id
		@id									INT	
		
		,@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@Nombre							VARCHAR(50)
		,@Email								VARCHAR(60)	
		,@Email2							VARCHAR(60)
		,@Telefono							VARCHAR(50)
		,@Telefono2							VARCHAR(50)
		,@Direccion							VARCHAR(255)
		,@Observaciones						VARCHAR(255)
		,@sResSQL							VARCHAR(1000)			OUTPUT
		,@Activo							Bit
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Actores', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Actores'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			END

		IF @sResSQL = ''
			BEGIN
				UPDATE Actores
				SET
					Nombre = @Nombre			
					,Email = @Email				
					,Email2 = @Email2			
					,Telefono = @Telefono			
					,Telefono2 = @Telefono2			
					,Direccion = @Direccion			
					,Observaciones = @Observaciones		
					,Activo = @Activo
				FROM Actores
				WHERE id = @id
				
				EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT
				
				IF @sResSQL = ''
					BEGIN	-- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Actores'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO
-- SP-TABLA: Actores - INICIO




-- SP-TABLA: Contextos - INICIO, --54
IF (OBJECT_ID('usp_Contextos___insert') IS NOT NULL) DROP PROCEDURE usp_Contextos___insert
GO
CREATE PROCEDURE usp_Contextos___insert
		@UsuarioQueEjecuta_Id					INT
		,@FechaDeEjecucion						DATETIME
		,@ObsLog								VARCHAR(80) = ''
		
		,@Nombre								VARCHAR(255)
		,@Codigo								VARCHAR(10)	
		,@Color_Id								INT
		,@CarpetaDe_Contenidos					VARCHAR(40)
		,@ImagenUrl								VARCHAR(MAX)
		,@Observaciones							VARCHAR(1000) = ''
		
		,@sResSQL								VARCHAR(1000)			OUTPUT
		,@id									INT						OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Contextos'  
					,@FuncionDePagina = 'Insert'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
		
		IF (@sResSQL = '')
			BEGIN
				DECLARE @NumeroSiguiente INT
				EXEC @NumeroSiguiente = [dbo].[ufc_Valor_Siguiente] @Tabla = 'Contextos', @Campo = 'Numero'
				
				SET NOCOUNT ON
				INSERT INTO Contextos
				(
					Numero				
					,Nombre				
					,Codigo				
					,Color_Id
					,CarpetaDe_Contenidos
					,ImagenUrl	
					,Observaciones	
				)
				VALUES
				(
					@NumeroSiguiente				
					,@Nombre				
					,@Codigo
					,@Color_Id
					,@CarpetaDe_Contenidos				
					,@ImagenUrl		
					,@Observaciones	
				)
				
				SET @id = SCOPE_IDENTITY()
				
				EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN	-- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Contextos'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END	
			END	
	END
GO




IF (OBJECT_ID('usp_Contextos___update_by_@id') IS NOT NULL) DROP PROCEDURE usp_Contextos___update_by_@id
GO
CREATE PROCEDURE usp_Contextos___update_by_@id
		@id										INT	
		
		,@UsuarioQueEjecuta_Id					INT
		,@FechaDeEjecucion						DATETIME
		,@ObsLog								VARCHAR(80) = ''
		
		,@Nombre								VARCHAR(255)
		,@Color_Id								INT
		,@ImagenUrl								VARCHAR(MAX)
		,@Observaciones							VARCHAR(1000)
		
		,@sResSQL								VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		-- Esta tabla no tiene Contexto_Id
		--EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Contextos', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		--IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			--BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Contextos'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			--END

		IF @sResSQL = '' 
			BEGIN
				UPDATE Contextos
				SET
					Nombre = @Nombre				
					,Color_Id = @Color_Id
					,ImagenUrl = CASE WHEN @ImagenUrl = '' THEN ImagenUrl 
									  WHEN 	@ImagenUrl <> '' THEN @ImagenUrl
									  END
					,Observaciones = @Observaciones	
				FROM Contextos
				WHERE id = @id

				EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN	-- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Contextos'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO
-- SP-TABLA: Contextos - FIN




-- SP-TABLA: ExtensionesDeArchivos - INICIO
IF (OBJECT_ID('usp_ExtensionesDeArchivos___insert') IS NOT NULL) DROP PROCEDURE usp_ExtensionesDeArchivos___insert
GO
CREATE PROCEDURE usp_ExtensionesDeArchivos___insert
		@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@Extension							VARCHAR(6)
				
		,@sResSQL							VARCHAR(1000)			OUTPUT
		,@id								INT						OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'ExtensionesDeArchivos'  
					,@FuncionDePagina = 'Insert'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
		
		IF (@sResSQL = '')
			BEGIN

				SET @Id = (SELECT ID FROM ExtensionesDeArchivos WHERE Nombre = @Extension)
		
				IF @Id IS NULL
					BEGIN											
						INSERT INTO ExtensionesDeArchivos
							   (
							   Nombre
							   ,Icono_Id
							   ,Observaciones
							   )
						 VALUES
							   (
							   @Extension --, varchar(6),
							   ,0 --, int,
							   ,'' --, varchar(255),
							   )
			
						EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT
			
						IF 	@sResSQL = ''
							BEGIN
								SET @id = SCOPE_IDENTITY()
								IF @id IS NULL
									SET @sResSQL = 'No se pudo insertar la extensión ' + @Extension		
							END	 
					
						IF @sResSQL = ''
							BEGIN	-- Registro el Log
								EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'ExtensionesDeArchivos'
								, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
							END	
					
					END
			END
	END
GO
-- SP-TABLA: ExtensionesDeArchivos - FIN


		

-- SP-TABLA: LogErrores - INICIO, --16
IF (OBJECT_ID('usp_LogErrores___insert') IS NOT NULL) DROP PROCEDURE usp_LogErrores___insert
GO
CREATE PROCEDURE usp_LogErrores___insert
		@UsuarioQueEjecuta_Id				INT							
		,@FechaDeEjecucion					DATETIME					
		,@Tabla_Id							INT
		,@Pagina							VARCHAR(100)
		,@TipoDe_LogError_Id				INT
		,@Modulo							VARCHAR(100)				
		,@Metodo							VARCHAR(50)					
		,@Mensaje							VARCHAR(1000)				
		,@Observaciones						VARCHAR(255)
		
		,@sResSQL							VARCHAR(1000)			OUTPUT
		,@id								INT						OUTPUT	
	AS
	BEGIN
	-- En esta no validamos nada por q queremos q ingresen todos los errores
	--EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'LogErrores'  
					--,@FuncionDePagina = 'Insert'
					--,@AutorizadoA = 'OperarLaPagina'
					--,@sResSQL = @sResSQL OUTPUT
		
	--	IF (@sResSQL = '')
	--		BEGIN

		INSERT INTO LogErrores
		(
			UsuarioQueEjecuta_Id 
			,FechaDeEjecucion
			,Tabla_Id 
			,Pagina_Id 
			,TipoDe_LogError_Id
			,Modulo 
			,Metodo 
			,Mensaje 
			,Observaciones
		)
		VALUES
		(
			@UsuarioQueEjecuta_Id 
			,@FechaDeEjecucion
			,@Tabla_Id
			,COALESCE((SELECT id FROM Paginas WHERE Nombre = @Pagina),0)
			,@TipoDe_LogError_Id
			,@Modulo 
			,@Metodo 
			,@Mensaje 
			,@Observaciones
		)
		
		SET @id = SCOPE_IDENTITY()
		
		EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT		
	END
GO




IF (OBJECT_ID('usp_LogErrores___update_by_@id') IS NOT NULL) DROP PROCEDURE usp_LogErrores___update_by_@id
GO
CREATE PROCEDURE usp_LogErrores___update_by_@id
		@id							INT							
		
		,@UsuarioQueEjecuta_Id		INT							
		,@FechaDeEjecucion			DATETIME					
		
		,@EstadoDe_LogError_Id		INT
		,@Observaciones				VARCHAR(255)
		
		,@sResSQL					VARCHAR(1000)			OUTPUT		
	AS
	BEGIN
		--No valido esta
		--EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'LogErrores', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		--IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
		--	BEGIN
		--		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'LogErrores'  
					--,@FuncionDePagina = 'Update'
					--,@AutorizadoA = 'OperarLaPagina'
					--,@sResSQL = @sResSQL OUTPUT
		--	END

		UPDATE LogErrores
		SET	
			EstadoDe_LogError_Id = @EstadoDe_LogError_Id
			,Observaciones = @Observaciones
		FROM LogErrores
		WHERE id = @id
		
		EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT
	END
GO
-- SP-TABLA: LogErrores - FIN




-- SP-TABLA: LogRegistros - INICIO
	--LO CREO EN EL SCRIPT 06
-- SP-TABLA: LogRegistros - FIN




-- SP-TABLA: Paginas - INICIO, --22
IF (OBJECT_ID('usp_Paginas___insert___v2') IS NOT NULL) DROP PROCEDURE usp_Paginas___insert___v2
GO
CREATE PROCEDURE usp_Paginas___insert___v2
		@UsuarioQueEjecuta_Id								INT
		,@FechaDeEjecucion									DATETIME
		,@ObsLog											VARCHAR(80) = ''
					
		,@id												INT
		,@TipoDe_Pagina_Id									INT
		,@Tabla_Id											INT	
		,@FuncionDe_Pagina_Id								INT	
		,@ID_String_Roles_CargarLaPagina					VARCHAR(50)
		,@ID_String_Roles_OperarLaPagina					VARCHAR(50)
		,@ID_String_Roles_VerRegAnulados					VARCHAR(50)
		,@ID_String_Roles_OperarLaPagina_OperacionesSecundarias	VARCHAR(50)	
		,@Nombre											VARCHAR(100)
		,@Observaciones										VARCHAR(2000)	
			
		,@sResSQL											VARCHAR(1000)			OUTPUT		
AS
	BEGIN
		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Paginas'  
					,@FuncionDePagina = 'Insert'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
		
		IF (@sResSQL = '')
			BEGIN
					SET NOCOUNT ON
					INSERT INTO Paginas
					(
						id
						,TipoDe_Pagina_Id
						,Tabla_Id
						,FuncionDe_Pagina_Id
						,Nombre
						,Observaciones
					)
					VALUES
					(
						@id
						,@TipoDe_Pagina_Id
						,@Tabla_Id
						,@FuncionDe_Pagina_Id
						,@Nombre
						,@Observaciones
					)
			
					EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT

					IF @sResSQL = ''
						BEGIN	-- Registro el Log
							IF @ID_String_Roles_CargarLaPagina <> '' 
								OR @ID_String_Roles_OperarLaPagina <> '' 
								OR @ID_String_Roles_VerRegAnulados <> '' 
								OR @ID_String_Roles_OperarLaPagina_OperacionesSecundarias <> '' 
								-- Si viene vacío, esta página no tiene asignación de permisos
								BEGIN
									--EXEC RelAsig__RolesDeUsuarios__A__Paginas___insert @id, @ID_String_Roles
							
									EXEC RelAsig__RolesDeUsuarios__A__Paginas___insert___v2	 @id
																								,@ID_String_Roles_CargarLaPagina
																								,@ID_String_Roles_OperarLaPagina
																								,@ID_String_Roles_VerRegAnulados
																								,@ID_String_Roles_OperarLaPagina_OperacionesSecundarias
								END
					
							--ESTO LO COMENTÉ EL 11/03/2014, por q todavia no tengo usuario
							-- Registro el Log
							--EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Paginas'
							--, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					
							SELECT @id 
						END
			END
	END
GO
	
	
	
	
IF (OBJECT_ID('usp_Paginas___update_by_@id') IS NOT NULL) DROP PROCEDURE usp_Paginas___update_by_@id
GO
CREATE PROCEDURE usp_Paginas___update_by_@id
		@id									INT	
		
		,@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@Tabla_Id							INT	
		,@FuncionDe_Pagina_Id				INT	
		,@Nombre							VARCHAR(100)
		,@Titulo							VARCHAR(100)
		,@Observaciones						VARCHAR(2000)
		,@Tips								VARCHAR(2000)
		
		,@sResSQL							VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		UPDATE Paginas
		SET
			Tabla_Id = @Tabla_Id
			,FuncionDe_Pagina_Id = @FuncionDe_Pagina_Id
			,Nombre = @Nombre
			,Titulo = @Titulo
			,Observaciones = @Observaciones
			,Tips = @Tips
		
		FROM Paginas
		WHERE id = @id

		EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

		IF @sResSQL = ''
			BEGIN	-- Registro el Log
				EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Paginas'
				, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
			END
	END
GO
-- SP-TABLA: Paginas - FIN




-- SP-TABLA: Publicaciones - INICIO
IF (OBJECT_ID('usp_Publicaciones___delete_by_@id') IS NOT NULL) DROP PROCEDURE usp_Publicaciones___delete_by_@id
GO
CREATE PROCEDURE usp_Publicaciones___delete_by_@id
		@id								INT		
		
		,@UsuarioQueEjecuta_Id			INT						
		,@FechaDeEjecucion				DATETIME				
		,@ObsLog						VARCHAR(80) = 'DELETED'		
		
		,@sResSQL						VARCHAR(1000)			OUTPUT				
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Publicaciones', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Publicaciones'  
					,@FuncionDePagina = 'Delete'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			END

		IF (@sResSQL = '')
			BEGIN
				SET @ObsLog = COALESCE(@ObsLog + '', '') + ' // Titulo: ' + (SELECT Titulo FROM Publicaciones WHERE id = @id)
		
				DELETE Publicaciones FROM Publicaciones WHERE id = @id

				EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Delete  @RowCount = @@ROWCOUNT
		
				IF @sResSQL = ''
					BEGIN	-- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Publicaciones'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '3', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog
					END
			END
	END
GO




IF (OBJECT_ID('usp_Publicaciones___insert') IS NOT NULL) DROP PROCEDURE usp_Publicaciones___insert
GO
CREATE PROCEDURE usp_Publicaciones___insert
		@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@Fecha								DATE
		,@Hora								TIME(0)
		,@Titulo							VARCHAR(40)
		,@NumeroDeVersion					VARCHAR(30)
		,@Realizada							BIT
		,@Observaciones						VARCHAR(8000)
		,@sResSQL							VARCHAR(1000)			OUTPUT
		,@id								INT						OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Publicaciones'  
					,@FuncionDePagina = 'Insert'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
		
		IF (@sResSQL = '')
			BEGIN
				SET NOCOUNT ON				
				INSERT INTO Publicaciones
				(
					Fecha
					,Hora
					,Titulo
					,NumeroDeVersion
					,Realizada
					,Observaciones														
				)
				VALUES
				(
					@Fecha
					,@Hora
					,@Titulo
					,@NumeroDeVersion
					,@Realizada
					,@Observaciones											
				)
						
				SET @id = SCOPE_IDENTITY()
						
				EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT
						
				IF @sResSQL = ''
					BEGIN	-- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Publicaciones'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO




IF (OBJECT_ID('usp_Publicaciones___update_by_@id') IS NOT NULL) DROP PROCEDURE usp_Publicaciones___update_by_@id
GO
CREATE PROCEDURE usp_Publicaciones___update_by_@id
		@id									INT 
		
		,@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@Fecha								DATE
		,@NumeroDeVersion					VARCHAR(30)
		,@Realizada							BIT
		,@Observaciones						VARCHAR(8000)
		,@Hora								TIME
		,@Titulo							VARCHAR(40)
		,@sResSQL							VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		--Esta tabla no tiene Contexto_Id
		--EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Publicaciones', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		--IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			--	BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Publicaciones'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			--	END

		IF @sResSQL = ''
			BEGIN				
				UPDATE Publicaciones
				SET
					Fecha = @Fecha
					,NumeroDeVersion = @NumeroDeVersion
					,Realizada = @Realizada			
					,Observaciones = @Observaciones		
					,Hora = @Hora
					,Titulo = @Titulo
				FROM Publicaciones
				WHERE id = @id
				
				EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT
				
				IF @sResSQL = ''
					BEGIN	-- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Publicaciones'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO
-- SP-TABLA: Publicaciones - FIN




-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Usuarios - INICIO, --26
IF (OBJECT_ID('usp_RelAsig__RolesDeUsuarios__A__Usuarios___delete_by_@Usuario_Id') IS NOT NULL) DROP PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Usuarios___delete_by_@Usuario_Id
GO
CREATE PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Usuarios___delete_by_@Usuario_Id
		@Usuario_Id						INT		
		
		,@UsuarioQueEjecuta_Id			INT						
		,@FechaDeEjecucion				DATETIME				
		,@ObsLog						VARCHAR(80) = 'DELETED'	
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		-- Acá lo valido contra la tabla Usuarios
		EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Usuarios', @Registro_Id = @Usuario_Id, @sResSQL = @sResSQL OUTPUT
		IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'RelAsig__RolesDeUsuarios__A__Usuarios'  
					,@FuncionDePagina = 'Delete'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			END

		IF (@sResSQL = '')
			BEGIN
				SET NOCOUNT ON
							
				DELETE RelAsig__RolesDeUsuarios__A__Usuarios 
				FROM RelAsig__RolesDeUsuarios__A__Usuarios RARU
					INNER JOIN RolesDeUsuarios RDU ON RARU.RolDe_Usuario_Id = RDU.id
				WHERE RARU.Usuario_Id = @Usuario_Id AND RDU.PermiteAsignacionDePermisos = 1
				
				--EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Delete  @RowCount = @@ROWCOUNT
				SET @sResSQL = ''
				--IF @sResSQL = ''
				--	BEGIN -- Registro el Log
				--		EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'RelAsig__RolesDeUsuarios__A__Usuarios'
				--		, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '3', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog
				--	END
			END
	END
GO




IF (OBJECT_ID('usp_RelAsig__RolesDeUsuarios__A__Usuarios___insert') IS NOT NULL) DROP PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Usuarios___insert
GO
CREATE PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Usuarios___insert
		@UsuarioQueEjecuta_Id					INT
		,@FechaDeEjecucion						DATETIME
		,@ObsLog								VARCHAR(80) = ''
				
		,@RolDe_Usuario_Id						INT	
		,@Usuario_Id							INT	
		,@FechaDesde							DATE
		,@FechaHasta							DATE	= NULL
		
		,@sResSQL								VARCHAR(1000)			OUTPUT
		,@id									INT						OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'RelAsig__RolesDeUsuarios__A__Usuarios'  
					,@FuncionDePagina = 'Insert'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT

		IF (@sResSQL = '')
			BEGIN
				SET NOCOUNT ON
				INSERT INTO RelAsig__RolesDeUsuarios__A__Usuarios
				(
					RolDe_Usuario_Id
					,Usuario_Id
					,FechaDesde
					,FechaHasta
				)
				VALUES
				(
					@RolDe_Usuario_Id
					,@Usuario_Id
					,@FechaDesde
					,@FechaHasta
				)
				
				SET @id = SCOPE_IDENTITY()
				
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'RelAsig__RolesDeUsuarios__A__Usuarios'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO




IF (OBJECT_ID('usp_RelAsig__RolesDeUsuarios__A__Usuarios___update_by_@Usuario_Id') IS NOT NULL) DROP PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Usuarios___update_by_@Usuario_Id
GO
CREATE PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Usuarios___update_by_@Usuario_Id
		@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@Usuario_Id						INT
		,@ID_String_RolesA_Agregar			VARCHAR(255)	
		,@ID_String_RolesA_Eliminar			VARCHAR(255)	
		
		,@sResSQL							VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		-- Esta es diferente, la valido con Usuarios
		EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Usuarios', @Registro_Id = @Usuario_id, @sResSQL = @sResSQL OUTPUT
		IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'RelAsig__RolesDeUsuarios__A__Usuarios'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			END
		
		IF @sResSQL = '' 
			BEGIN
				SET NOCOUNT ON
				-- 1ero elimino todos
				DELETE RelAsig__RolesDeUsuarios__A__Usuarios 
				FROM RelAsig__RolesDeUsuarios__A__Usuarios 
				WHERE 
					(Usuario_Id = @Usuario_Id)
					AND
					(RolDe_Usuario_Id IN (SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_RolesA_Eliminar)))
			
				-- LO SIGUIENTE NO APLICA EN ESTA FUNCION
				--EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				--IF @sResSQL = ''
				--	BEGIN
				
				-- 2do, agrego
						INSERT INTO RelAsig__RolesDeUsuarios__A__Usuarios (RolDe_Usuario_Id, Usuario_Id)
							SELECT id, @Usuario_Id  FROM ufc_IDs_String_ToTable_INT(@ID_String_RolesA_Agregar)
					--END		
				
				--EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'RelAsig__RolesDeUsuarios__A__Usuarios'
				--, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
				SET @sResSQL = ''			
			END
	END
GO
-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Usuarios - FIN




-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Paginas - INICIO, --25
IF (OBJECT_ID('usp_RelAsig__RolesDeUsuarios__A__Paginas___insert') IS NOT NULL) DROP PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Paginas___insert
GO
CREATE PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Paginas___insert
		@UsuarioQueEjecuta_Id					INT
		,@FechaDeEjecucion						DATETIME
		,@ObsLog								VARCHAR(80) = ''
				
		,@RolDe_Usuario_Id								INT	
		,@Pagina_Id										INT	
		,@AutorizadoACargarLaPagina					BIT	
		,@AutorizadoAOperarLaPagina					BIT
		,@AutorizadoAVerRegAnulados				BIT		
		,@AutorizadoAOperacionesSecundarias	BIT	
		
		,@sResSQL										VARCHAR(1000)			OUTPUT
		,@id											INT						OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'RelAsig__RolesDeUsuarios__A__Paginas'  
					,@FuncionDePagina = 'Insert'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT

		IF (@sResSQL = '')
			BEGIN
				SET NOCOUNT ON
				INSERT INTO RelAsig__RolesDeUsuarios__A__Paginas
				(
					RolDe_Usuario_Id
					,Pagina_Id
					,AutorizadoACargarLaPagina	
					,AutorizadoAOperarLaPagina	
					,AutorizadoAVerRegAnulados
					,AutorizadoAOperacionesSecundarias
				)
				VALUES
				(
					@RolDe_Usuario_Id
					,@Pagina_Id
					,@AutorizadoACargarLaPagina	
					,@AutorizadoAOperarLaPagina	
					,@AutorizadoAVerRegAnulados
					,@AutorizadoAOperacionesSecundarias
				)
				
				SET @id = SCOPE_IDENTITY()
				
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'RelAsig__RolesDeUsuarios__A__Paginas'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO




IF (OBJECT_ID('usp_RelAsig__RolesDeUsuarios__A__Paginas___update_by_@id') IS NOT NULL) DROP PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Paginas___update_by_@id
GO
CREATE PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Paginas___update_by_@id
		@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@id								INT	
		,@AutorizadoACargarLaPagina			BIT	
		,@AutorizadoAOperarLaPagina			BIT
		,@AutorizadoAVerRegAnulados			BIT
		,@AutorizadoAOperacionesSecundarias	BIT
		
		,@sResSQL							VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		--La tabla no tiene Contexto_Id por eso no puedo validar lo siguiente
		--EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Usuarios', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		--IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
		--	BEGIN
			EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'RelAsig__RolesDeUsuarios__A__Usuarios'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
		--END

		IF @sResSQL = '' 
			BEGIN
				SET NOCOUNT ON
				UPDATE RelAsig__RolesDeUsuarios__A__Paginas
				SET
					AutorizadoACargarLaPagina	= @AutorizadoACargarLaPagina
					,AutorizadoAOperarLaPagina	= @AutorizadoAOperarLaPagina
					,AutorizadoAVerRegAnulados = @AutorizadoAVerRegAnulados
					,AutorizadoAOperacionesSecundarias = @AutorizadoAOperacionesSecundarias
				FROM RelAsig__RolesDeUsuarios__A__Paginas
				WHERE id = @id
				
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'RelAsig__RolesDeUsuarios__A__Paginas'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO
-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Paginas - FIN




-- SP-TABLA: RelAsig__Subsistemas__A__Publicaciones - INICIO, --35
IF (OBJECT_ID('usp_RelAsig__Subsistemas__A__Publicaciones___delete') IS NOT NULL) DROP PROCEDURE usp_RelAsig__Subsistemas__A__Publicaciones___delete
GO
CREATE PROCEDURE usp_RelAsig__Subsistemas__A__Publicaciones___delete
		@Subsistema_Id					INT		
		,@Publicacion_Id				INT
		
		,@UsuarioQueEjecuta_Id			INT						
		,@FechaDeEjecucion				DATETIME				
		,@ObsLog						VARCHAR(80) = 'DELETED'		
		
		,@sResSQL						VARCHAR(1000)			OUTPUT		
	AS
	BEGIN		
		-- No tiene Contexto_Id, no valido
		--EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = '', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		--IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
		--	BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Publicaciones'  
					,@FuncionDePagina = 'Delete'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			--END

		IF (@sResSQL = '')
			BEGIN
				SET @ObsLog = COALESCE(@ObsLog + '', '') + ' // SubSitema_Id: ' + CAST(@Subsistema_Id AS VARCHAR) + ' - Publicacion_Id: ' + CAST(@Publicacion_Id AS VARCHAR)
				--SET @Existe = (SELECT id FROM RelAsig__Subsistemas__A__Publicaciones WHERE id = @id AND Contexto_Id = @Contexto_Id)

				DECLARE @id		INT -- Lo necesito para el registro
				SELECT @id = id FROM RelAsig__Subsistemas__A__Publicaciones WHERE Subsistema_Id = @Subsistema_Id AND Publicacion_Id = @Publicacion_Id

				--DELETE RelAsig__Subsistemas__A__Publicaciones FROM RelAsig__Subsistemas__A__Publicaciones WHERE Subsistema_Id = @Subsistema_Id AND Publicacion_Id = @Publicacion_Id
				DELETE RelAsig__Subsistemas__A__Publicaciones FROM RelAsig__Subsistemas__A__Publicaciones WHERE id = @id

				EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Delete  @RowCount = @@ROWCOUNT
				
				IF @sResSQL = ''
					BEGIN	-- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'RelAsig__Subsistemas__A__Publicaciones'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '3', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog
					END
			END
	END
GO




IF (OBJECT_ID('usp_RelAsig__Subsistemas__A__Publicaciones___insert') IS NOT NULL) DROP PROCEDURE usp_RelAsig__Subsistemas__A__Publicaciones___insert
GO
CREATE PROCEDURE usp_RelAsig__Subsistemas__A__Publicaciones___insert
		@UsuarioQueEjecuta_Id			INT
		,@FechaDeEjecucion				DATETIME
		,@ObsLog						VARCHAR(80) = ''
			
		,@Subsistema_Id					INT							
		,@Publicacion_Id				INT							
		,@Usuario_Id					INT							
		,@NumeroDeVersion				VARCHAR(30)					
		,@SVN							INT							
		,@Ubicacion						VARCHAR(255)
		,@Observaciones					VARCHAR(255)	

		,@sResSQL						VARCHAR(1000)			OUTPUT
		,@id							INT						OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'RelAsig__Subsistemas__A__Publicaciones'  
					,@FuncionDePagina = 'Insert'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT

		IF (@sResSQL = '')
			BEGIN
				SET NOCOUNT ON
				INSERT INTO RelAsig__Subsistemas__A__Publicaciones
				(
					Subsistema_Id
					,Publicacion_Id
					,Usuario_Id
					,NumeroDeVersion
					,SVN
					,Ubicacion
					,Observaciones
				)
				VALUES
				(
					@Subsistema_Id
					,@Publicacion_Id
					,@Usuario_Id
					,@NumeroDeVersion
					,@SVN
					,@Ubicacion
					,@Observaciones
				)
			
				SET @id = SCOPE_IDENTITY()
			
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'RelAsig__Subsistemas__A__Publicaciones'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
		END
GO



	
IF (OBJECT_ID('usp_RelAsig__Subsistemas__A__Publicaciones___update') IS NOT NULL) DROP PROCEDURE usp_RelAsig__Subsistemas__A__Publicaciones___update
GO
CREATE PROCEDURE usp_RelAsig__Subsistemas__A__Publicaciones___update
	@UsuarioQueEjecuta_Id			INT
	,@FechaDeEjecucion				DATETIME
	,@ObsLog						VARCHAR(80) = ''

	,@Subsistema_Id					INT							
	,@Publicacion_Id				INT							
	,@Usuario_Id					INT							
	,@NumeroDeVersion				VARCHAR(30)					
	,@SVN							INT							
	,@Ubicacion						VARCHAR(255)
	,@Observaciones					VARCHAR(255)

	,@sResSQL						VARCHAR(1000)			OUTPUT
	
	AS
	BEGIN
		-- NO tiene Conexto_Id
		--EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = '', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		--IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
		--	BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Publicaciones'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			--END
		IF @sResSQL = '' 
			BEGIN
				SET NOCOUNT ON
				
				DECLARE @id		INT -- Lo necesito para el registro
				SELECT @id = id FROM RelAsig__Subsistemas__A__Publicaciones WHERE Subsistema_Id = @Subsistema_Id AND Publicacion_Id = @Publicacion_Id
				
				UPDATE RelAsig__Subsistemas__A__Publicaciones
				SET
					Usuario_Id = @Usuario_Id
					,NumeroDeVersion = @NumeroDeVersion
					,SVN = @SVN
					,Ubicacion = @Ubicacion
					,Observaciones = @Observaciones
					
				FROM RelAsig__Subsistemas__A__Publicaciones
				WHERE id = @id
				
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'RelAsig__Subsistemas__A__Publicaciones'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO
-- SP-TABLA: RelAsig__Subsistemas__A__Publicaciones - FIN




-- SP-TABLA: RolesDeUsuarios - INICIO, -- 27
IF (OBJECT_ID('usp_RolesDeUsuarios___update_by_@id') IS NOT NULL) DROP PROCEDURE usp_RolesDeUsuarios___update_by_@id
GO
CREATE PROCEDURE usp_RolesDeUsuarios___update_by_@id
		@id									INT	
		
		,@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@Nombre							VARCHAR(30)	
		,@Observaciones						VARCHAR(255)
		
		,@sResSQL							VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		-- NO TIENE CONTEXTO_ID
		--EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = '', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		--IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
		--	BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'RolesDeUsuarios'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			--END

		IF @sResSQL = ''
			BEGIN
				SET NOCOUNT ON
				UPDATE RolesDeUsuarios
				SET
					Nombre = @Nombre
					,Observaciones = @Observaciones
				FROM RolesDeUsuarios
				WHERE id = @id
		
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'RolesDeUsuarios'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO




IF (OBJECT_ID('usp_RolesDeUsuarios___update_Campos_@Activo_by_@id') IS NOT NULL) DROP PROCEDURE usp_RolesDeUsuarios___update_Campos_@Activo_by_@id
GO
CREATE PROCEDURE usp_RolesDeUsuarios___update_Campos_@Activo_by_@id
		@id								INT		
		
		,@Activo						BIT
		
		,@UsuarioQueEjecuta_Id			INT						
		,@FechaDeEjecucion				DATETIME				
		,@ObsLog						VARCHAR(80) = ''			
		
		,@sResSQL						VARCHAR(1000)			OUTPUT	
	AS
	BEGIN
		-- NO TIENE CONTEXTO_ID
		--EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = '', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		--IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
		--	BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'RolesDeUsuarios'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			--END

		IF @sResSQL = ''
			BEGIN
				DECLARE @TipoDe_LogRegistro_Id AS INT
				EXEC @TipoDe_LogRegistro_Id = ufc_TiposDeLogRegistros_EstadoDe_Registro @Activo = @Activo
	
				UPDATE RolesDeUsuarios
				SET Activo = @Activo
				FROM RolesDeUsuarios
				WHERE id = @id

				SET @ObsLog = COALESCE(@ObsLog + '', '') + ' // Update Activo = ' + CAST(@Activo AS VARCHAR)
		
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'RolesDeUsuarios'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = @TipoDe_LogRegistro_Id, @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog
					END
			END
	END
GO
-- SP-TABLA: RolesDeUsuarios - FIN




-- SP-TABLA: Soporte - INICIO, -- 29
IF (OBJECT_ID('usp_Soporte___insert') IS NOT NULL) DROP PROCEDURE usp_Soporte___insert
GO
CREATE PROCEDURE usp_Soporte___insert
		@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@UsuarioQueCerro_Id				INT = 0
		,@UsuarioQueSolicita_Id				INT
		,@FechaDeCierre						DATETIME = 0
		,@Texto								VARCHAR(max)	
		,@Prioridad_Id						INT
		
		,@sResSQL							VARCHAR(1000)			OUTPUT
		,@id								INT						OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Soporte'  
					,@FuncionDePagina = 'Insert'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT

		IF (@sResSQL = '')
			BEGIN
				DECLARE @NumeroSiguiente INT
				EXEC @NumeroSiguiente = [dbo].[ufc_Valor_Siguiente] @Tabla = 'Soporte', @Campo = 'Numero'	
				
				SET NOCOUNT ON
				INSERT INTO Soporte
				(
					Contexto_Id
					,FechaDeEjecucion
					,UsuarioQueCerro_Id
					,UsuarioQueSolicita_Id
					,FechaDeCierre
					,Numero
					,Texto
					,Prioridad_Id
				)
				VALUES
				(
					@Contexto_Id
					,@FechaDeEjecucion
					,@UsuarioQueCerro_Id
					,@UsuarioQueSolicita_Id
					,@FechaDeCierre
					,@NumeroSiguiente
					,@Texto
					,@Prioridad_Id
				)
				
				SET @id = SCOPE_IDENTITY()
				
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Soporte'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO




IF (OBJECT_ID('usp_Soporte___update_by_@id') IS NOT NULL) DROP PROCEDURE usp_Soporte___update_by_@id
GO
CREATE PROCEDURE usp_Soporte___update_by_@id
		@id									INT	
		
		,@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@EstadoDe_Soporte_Id				INT
		,@Prioridad_Id						INT
		,@Observaciones						VARCHAR(max)	
		,@ObservacionesPrivadas				VARCHAR(max)	
		,@Cerrado							BIT		
		
		,@sResSQL							VARCHAR(1000)			OUTPUT			
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Soporte', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Soporte'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			END

		IF @sResSQL = ''
			BEGIN
				IF @Cerrado = 1  
					BEGIN
						IF  (SELECT Cerrado FROM Soporte Where id = @id) = 0
							-- Si estaba Abierto y Ahora viene Cerrado --> impacto quien lo realizó
							BEGIN
								UPDATE Soporte
								SET
									UsuarioQueCerro_Id = @UsuarioQueEjecuta_Id
									,FechaDeCierre = @FechaDeEjecucion
									,EstadoDe_Soporte_Id = @EstadoDe_Soporte_Id
									,Prioridad_Id = @Prioridad_Id
									,Observaciones = @Observaciones
									,ObservacionesPrivadas = @ObservacionesPrivadas
									,Cerrado = 1
							
								FROM Soporte
								WHERE id = @id
							END
						ELSE
							-- YA ESTABA CERRADO, LO ÚNICO ACTUALIZABLE SON LAS OBS PRIVADAS
							BEGIN
								UPDATE Soporte
								SET
									ObservacionesPrivadas = @ObservacionesPrivadas
						
								FROM Soporte
								WHERE id = @id
							END
						--ENDIF
					END
				ELSE
					-- SIGUE ABIERTO
					BEGIN
						UPDATE Soporte
						SET
							EstadoDe_Soporte_Id = @EstadoDe_Soporte_Id
							,Prioridad_Id = @Prioridad_Id
							,Observaciones = @Observaciones
							,ObservacionesPrivadas = @ObservacionesPrivadas
										
						FROM Soporte
						WHERE id = @id
					END
				--ENDIF
		
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Soporte'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO




IF (OBJECT_ID('usp_Soporte___update_Campos_@Activo_by_@id') IS NOT NULL) DROP PROCEDURE usp_Soporte___update_Campos_@Activo_by_@id
GO
CREATE PROCEDURE usp_Soporte___update_Campos_@Activo_by_@id
		@id								INT		
		
		,@Activo				BIT
		
		,@UsuarioQueEjecuta_Id			INT						
		,@FechaDeEjecucion				DATETIME				
		,@ObsLog						VARCHAR(80) = ''	
		
		,@sResSQL						VARCHAR(1000)			OUTPUT						
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Soporte', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Soporte'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			END

		IF @sResSQL = ''
			BEGIN
				DECLARE @TipoDe_LogRegistro_Id AS INT
				EXEC @TipoDe_LogRegistro_Id = ufc_TiposDeLogRegistros_EstadoDe_Registro @Activo = @Activo
		
				UPDATE Soporte
				SET Activo = @Activo
				FROM Soporte
				WHERE id = @id

				SET @ObsLog = COALESCE(@ObsLog + '', '') + ' // Update Activo = ' + CAST(@Activo AS VARCHAR)
		
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Soporte'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = @TipoDe_LogRegistro_Id, @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog
					END
			END
	END
GO




IF (OBJECT_ID('usp_Soporte___update_Campos_@Publicacion_Id_by_@id') IS NOT NULL) DROP PROCEDURE usp_Soporte___update_Campos_@Publicacion_Id_by_@id
GO
CREATE PROCEDURE usp_Soporte___update_Campos_@Publicacion_Id_by_@id
		@id								INT		
		
		,@Publicacion_Id				INT
		
		,@UsuarioQueEjecuta_Id			INT						
		,@FechaDeEjecucion				DATETIME				
		,@ObsLog						VARCHAR(80) = ''	
		
		,@sResSQL						VARCHAR(1000)			OUTPUT						
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Soporte', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Soporte'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			END

		IF @sResSQL = ''
			BEGIN
				IF @Publicacion_Id = -1
					BEGIN
						SET @Publicacion_Id = NULL
					END
			
				UPDATE Soporte
				SET Publicacion_Id = @Publicacion_Id
				FROM Soporte
				WHERE id = @id

				SET @ObsLog = COALESCE(@ObsLog + '', '') + ' // Update Publicacion_Id = ' + CAST(@Publicacion_Id AS VARCHAR)
		
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
				BEGIN -- Registro el Log
					EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Soporte'
					, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog
				END
			END
	END
GO
-- SP-TABLA: Soporte - FIN




-- SP-TABLA: Tablas - INICIO, -- 30
IF (OBJECT_ID('usp_Tablas___insert') IS NOT NULL) DROP PROCEDURE usp_Tablas___insert
GO
CREATE PROCEDURE usp_Tablas___insert
		@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
				
		,@Nombre							VARCHAR(80)
		,@Nomenclatura						VARCHAR(12)	
		,@Observaciones						VARCHAR(255)
		
		,@sResSQL							VARCHAR(1000)			OUTPUT
		,@id								INT						OUTPUT							
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Tablas'  
					,@FuncionDePagina = 'Insert'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT

		IF (@sResSQL = '')
			BEGIN
				SET NOCOUNT ON
				INSERT INTO Tablas
				(
					Nombre
					,Nomenclatura
					,Observaciones
				)
				VALUES
				(
					@Nombre
					,UPPER(@Nomenclatura)
					,@Observaciones
				)
		
				SET @id = SCOPE_IDENTITY()
		
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Tablas'
						,@Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO




IF (OBJECT_ID('usp_Tablas___update_by_@id') IS NOT NULL) DROP PROCEDURE usp_Tablas___update_by_@id
GO
CREATE PROCEDURE usp_Tablas___update_by_@id
		@id									INT	
		
		,@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@Nombre							VARCHAR(80)
		,@Nomenclatura						VARCHAR(12)	
		,@Observaciones						VARCHAR(255)
		
		,@sResSQL							VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		-- NO TIENE CONTEXTO
		--EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Tablas', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		--IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
		--	BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Tablas'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			--END

		IF @sResSQL = ''
			BEGIN
				UPDATE Tablas
				SET
					Nombre = @Nombre
					,Nomenclatura = UPPER(@Nomenclatura)
					,Observaciones = @Observaciones
		
				FROM Tablas
				WHERE id = @id

				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Tablas'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO
-- SP-TABLA: Tablas - FIN




-- SP-TABLA: TiposDeActores - INICIO, -- 44
IF (OBJECT_ID('usp_TiposDeActores___insert') IS NOT NULL) DROP PROCEDURE usp_TiposDeActores___insert
GO
CREATE PROCEDURE usp_TiposDeActores___insert
		@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
				
		,@Nombre							VARCHAR(40)
		,@Observaciones						VARCHAR(80)		
		
		,@sResSQL							VARCHAR(1000)			OUTPUT
		,@id								INT						OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'TiposDeActores'  
					,@FuncionDePagina = 'Insert'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT

		IF (@sResSQL = '')
			BEGIN
				SET NOCOUNT ON
				INSERT INTO TiposDeActores
				(
					Nombre
					,Observaciones
				)
				VALUES
				(
					@Nombre
					,@Observaciones
				)
		
				SET @id = SCOPE_IDENTITY()
		
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'TiposDeActores'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO




IF (OBJECT_ID('usp_TiposDeActores___update_by_@id') IS NOT NULL) DROP PROCEDURE usp_TiposDeActores___update_by_@id
GO
CREATE PROCEDURE usp_TiposDeActores___update_by_@id
		@id									INT	
		
		,@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@Nombre							VARCHAR(40)
		,@Observaciones						VARCHAR(80)	
		
		,@sResSQL							VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'TiposDeActores', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'TiposDeActores'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			END

		IF @sResSQL = ''
			BEGIN
				SET NOCOUNT ON
				UPDATE TiposDeActores
				SET
					Nombre = @Nombre
					,Observaciones = @Observaciones
		
				FROM TiposDeActores
				WHERE id = @id
		
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'TiposDeActores'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO
-- SP-TABLA: TiposDeActores - FIN




-- SP-TABLA: TiposDeLogErrores - INICIO, -- 32
IF (OBJECT_ID('usp_TiposDeLogErrores___insert') IS NOT NULL) DROP PROCEDURE usp_TiposDeLogErrores___insert
GO
CREATE PROCEDURE usp_TiposDeLogErrores___insert
		@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
				
		,@Nombre							VARCHAR(40)
		,@Observaciones						VARCHAR(80)	
		
		,@sResSQL							VARCHAR(1000)			OUTPUT
		,@id								INT						OUTPUT
	AS
	BEGIN
		--NO VALIDO ACÁ
		--EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'TiposDeLogErrores'  
					--,@FuncionDePagina = 'Insert'
					--,@AutorizadoA = 'OperarLaPagina'
					--,@sResSQL = @sResSQL OUTPUT

		--IF (@sResSQL = '')
		--	BEGIN
		SET NOCOUNT ON
		INSERT INTO TiposDeLogErrores
		(
			Nombre
			,Observaciones
		)
		VALUES
		(
			@Nombre
			,UPPER(@Observaciones)
		)
		
		SET @id = SCOPE_IDENTITY()
		
		EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT

		IF @sResSQL = ''
			BEGIN -- Registro el Log
				EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'TiposDeLogErrores'
				, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
			END
	END
GO




IF (OBJECT_ID('usp_TiposDeLogErrores___update_by_@id') IS NOT NULL) DROP PROCEDURE usp_TiposDeLogErrores___update_by_@id
GO
CREATE PROCEDURE usp_TiposDeLogErrores___update_by_@id
		@id									INT	
		
		,@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@Nombre							VARCHAR(40)
		,@Observaciones						VARCHAR(80)	
		,@sResSQL							VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		-- NO TIENE CONTEXTO
		--EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'TiposDeLogErrores', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		--IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
		--	BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'TiposDeLogErrores'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			--END

		IF @sResSQL = ''
			BEGIN
				UPDATE TiposDeLogErrores
				SET
					Nombre = @Nombre
					,Observaciones = UPPER(@Observaciones)
		
				FROM TiposDeLogErrores
				WHERE id = @id
		
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'TiposDeLogErrores'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO
-- SP-TABLA: TiposDeLogErrores - FIN




-- SP-TABLA: TiposDeLogRegistro - INICIO, -- 34
IF (OBJECT_ID('usp_TiposDeLogRegistros___insert') IS NOT NULL) DROP PROCEDURE usp_TiposDeLogRegistros___insert
GO
CREATE PROCEDURE usp_TiposDeLogRegistros___insert
		@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
				
		,@Nombre							VARCHAR(12)
		,@Observaciones						VARCHAR(80)	
		
		,@sResSQL							VARCHAR(1000)			OUTPUT
		,@id								INT						OUTPUT
	AS
	BEGIN
		--NO VALIDO ACÁ
		--EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'TiposDeLogRegistros'  
					--,@FuncionDePagina = 'Insert'
					--,@AutorizadoA = 'OperarLaPagina'
					--,@sResSQL = @sResSQL OUTPUT

		--IF (@sResSQL = '')
		--	BEGIN
		SET NOCOUNT ON
		INSERT INTO TiposDeLogRegistros
		(
			Nombre
			,Observaciones
		)
		VALUES
		(
			@Nombre
			,UPPER(@Observaciones)
		)
		
		SET @id = SCOPE_IDENTITY()
		
		EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT

		IF @sResSQL = ''
			BEGIN -- Registro el Log
				EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'TiposDeLogRegistros'
				, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
			END
	END
GO




IF (OBJECT_ID('usp_TiposDeLogRegistros___update_by_@id') IS NOT NULL) DROP PROCEDURE usp_TiposDeLogRegistros___update_by_@id
GO
CREATE PROCEDURE usp_TiposDeLogRegistros___update_by_@id
		@id									INT	
		
		,@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@Nombre							VARCHAR(12)
		,@Observaciones						VARCHAR(80)
		,@sResSQL							VARCHAR(1000)			OUTPUT	
	AS
	BEGIN
		-- NO TIENE CONTEXTO
		--EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'TiposDeLogRegistros', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		--IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
		--	BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'TiposDeLogRegistros'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			--END

		IF @sResSQL = ''
			BEGIN
				UPDATE TiposDeLogRegistros
				SET
					Nombre = @Nombre
					,Observaciones = UPPER(@Observaciones)
		
				FROM TiposDeLogRegistros
				WHERE id = @id
		
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'TiposDeLogRegistros'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO
-- SP-TABLA: TiposDeLogRegistros - FIN




-- SP-TABLA: UbicacionesDeCarpetas - INICIO
IF (OBJECT_ID('usp_UbicacionesDeCarpetas___insert') IS NOT NULL) DROP PROCEDURE usp_UbicacionesDeCarpetas___insert
GO
CREATE PROCEDURE usp_UbicacionesDeCarpetas___insert
		@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@Ubicacion							VARCHAR(150)
				
		,@sResSQL							VARCHAR(1000)			OUTPUT
		,@id								INT						OUTPUT
	AS
	BEGIN
		-- DESCRIPCION: DEVUELVE EL ID DE UBICACION DE LA TABLA UbicacionesDeCarpetas Y EN CASO DE NO EXISTIR SE AGREGA
		-- Y SE DEVUELVE EL ID DEL REGISTRO AGREGADO

		--NO VALIDO ACÁ
		--EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'UbicacionesDeCarpetas'  
		--			,@FuncionDePagina = 'Insert'
		--			,@AutorizadoA = 'OperarLaPagina'
		--			,@sResSQL = @sResSQL OUTPUT

		--IF (@sResSQL = '')
		--	BEGIN

		DECLARE @TipoDe_Ubicacion_Id INT
		SET @sResSQL = ''
		
		-- SE LE QUITA LOS CARACTERES ~							  (TAMBIEN SE PUEDE CAMBIAR POR SUBSTRING)
				SET @Ubicacion = (SELECT REPLACE (@Ubicacion, '~/', ''))
		
		-- VALOR UTILIZADO ACTUALMENTE: 1, EN CASO DE AGREGARSE MAS TIPOS DE UBICACIONES DEBERÁ ASIGNARSELE LA CORRESPONDIENTE
		SET @TipoDe_Ubicacion_Id = 1	
			
		SET @Id = (SELECT ID FROM UbicacionesDeCarpetas WHERE Ubicacion = @Ubicacion)
		
		
		IF @Id IS NULL
			BEGIN
				INSERT INTO UbicacionesDeCarpetas
					   (
					   Ubicacion
					   ,TipoDe_Ubicacion_Id
					   )
				VALUES
					   (
					   @Ubicacion
					   ,@TipoDe_Ubicacion_Id
					   )
			
				SET @id = SCOPE_IDENTITY()
			
				IF 	@id	IS NULL	 
					SET @sResSQL = 'No se pudo insertar la ubicación ' + @Ubicacion		
				ELSE 
					EXEC	@sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT
			
				IF @sResSQL = ''
					BEGIN	-- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'UbicacionesDeCarpetas'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END	
					
			END
	END
GO
-- SP-TABLA: UbicacionesDeCarpetas - FIN




-- SP-TABLA: Usuarios - INICIO, -- 39
IF (OBJECT_ID('usp_Usuarios___insert') IS NOT NULL) DROP PROCEDURE usp_Usuarios___insert
GO
CREATE PROCEDURE usp_Usuarios___insert
		@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
				
		,@LogonName							VARCHAR(64)	
		,@Pass								VARCHAR(40)	
		,@Nombre							VARCHAR(40)
		,@Apellido							VARCHAR(40)
		,@Email								VARCHAR(60)							
		,@Email2							VARCHAR(60)							
		,@Telefono							VARCHAR(50)							
		,@Telefono2							VARCHAR(50)							
		,@Direccion							VARCHAR(255)						
		,@Observaciones						VARCHAR(255)						
		,@Activo							BIT			
		,@UltimoLoginSesionId				VARCHAR(24) = ''
		,@Actor_Id							INT
		,@RolDe_Usuario_Id					INT
		,@sResSQL							VARCHAR(1000)			OUTPUT
		,@id								INT						OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Usuarios'  
					,@FuncionDePagina = 'Insert'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT

		IF (@sResSQL = '')
			BEGIN
				SET NOCOUNT ON
				INSERT INTO Usuarios
				(
					Contexto_Id
					,Actor_Id
					,LogonName
					,Pass	
					,Nombre
					,Apellido
					,Email	
					,Email2
					,Telefono
					,Telefono2
					,Direccion	
					,Observaciones
					,Activo
					,UltimoLoginSesionId
				)
				VALUES
				(
					(SELECT Contexto_Id FROM Usuarios WHERE id = @UsuarioQueEjecuta_Id)
					,@Actor_Id
					,LOWER(@LogonName)
					,@Pass	
					,@Nombre
					,@Apellido
					,@Email	
					,@Email2
					,@Telefono
					,@Telefono2
					,@Direccion	
					,@Observaciones
					,@Activo
					,CAST(@FechaDeEjecucion AS VARCHAR)
				)
				
				SET @id = SCOPE_IDENTITY()
				
				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Insert  @RowCount = @@ROWCOUNT


				-- REVISAR SI VA LO SIGUIENTE:


				----  sincronizar con dispositivos -------
				update Tablas_A_Sincronizar_Con_Dispositivos 
				set Sincronizar = 1
				from Tablas_A_Sincronizar_Con_Dispositivos 				  
				where Tabla_Id = 32
			   --'Usuarios'
				------ fin sincronizar con dispositivos-----
				IF @sResSQL = ''
					BEGIN -- Agrego el rol inicial y Registro el Log
						INSERT INTO Rel_Asig__RolesDe_Usuarios__A__Usuarios (RolDe_Usuario_Id, Usuario_Id, FechaDesde ) VALUES (@RolDe_Usuario_Id, @id, @FechaDeEjecucion)
					
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Usuarios'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '1', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
		ELSE
			BEGIN
				SET @id = -1
			END
	END
GO




IF (OBJECT_ID('usp_Usuarios___update_by_@id') IS NOT NULL) DROP PROCEDURE usp_Usuarios___update_by_@id
GO
CREATE PROCEDURE usp_Usuarios___update_by_@id
		@id									INT	
		
		,@UsuarioQueEjecuta_Id				INT
		,@FechaDeEjecucion					DATETIME
		,@ObsLog							VARCHAR(80) = ''
		
		,@LogonName							VARCHAR(64)	
		,@Nombre							VARCHAR(40)
		,@Apellido							VARCHAR(40)
		,@Email								VARCHAR(60)							
		,@Email2							VARCHAR(60)							
		,@Telefono							VARCHAR(50)							
		,@Telefono2							VARCHAR(50)							
		,@Direccion							VARCHAR(255)						
		,@Observaciones						VARCHAR(255)						
		,@Activo							BIT	
		
		--CAMPOS DEL MODELO QUE NO SE USAN EN ESTE SP
		,@Pass								VARCHAR(40) = ''
		,@Actor_Id							INT = 0
		,@RolDe_Usuario_Id					INT = 0
		
		,@sResSQL							VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Usuarios', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Usuarios'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			END

		IF @sResSQL = ''
			BEGIN
				UPDATE Usuarios
				SET
					LogonName = LOWER(@LogonName)
					,Nombre = @Nombre
					,Apellido = @Apellido
					,Email = @Email
					,Email2 = @Email2
					,Telefono = @Telefono
					,Telefono2 = @Telefono2
					,Direccion = @Direccion
					,Observaciones = @Observaciones
					--,Activo = @Activo
				
				FROM Usuarios
				WHERE id = @id

				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Usuarios'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
				----  sincronizar con dispositivos -------
				update Tablas_A_Sincronizar_Con_Dispositivos 
				set Sincronizar = 1
				from Tablas_A_Sincronizar_Con_Dispositivos 				  
				where Tabla_Id = 32
			   --'Usuarios'
				------ fin sincronizar con dispositivos-----
			END
	END
GO




IF (OBJECT_ID('usp_Usuarios___update_Campos_@Activo_by_@id') IS NOT NULL) DROP PROCEDURE usp_Usuarios___update_Campos_@Activo_by_@id
GO
CREATE PROCEDURE usp_Usuarios___update_Campos_@Activo_by_@id
		@id								INT									
		
		,@UsuarioQueEjecuta_Id			INT
		,@FechaDeEjecucion				DATETIME
		,@ObsLog						VARCHAR(80) = 'Modifica Activo'						

		,@Activo						BIT
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Usuarios', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Usuarios'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			END

		IF @sResSQL = ''
			BEGIN
				UPDATE Usuarios
				SET
					Activo = @Activo
				
				FROM Usuarios
				WHERE id = @id

				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
				BEGIN -- Registro el Log
					EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Usuarios'
					, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
				END
				----  sincronizar con dispositivos -------
				update Tablas_A_Sincronizar_Con_Dispositivos 
				set Sincronizar = 1
				from Tablas_A_Sincronizar_Con_Dispositivos 				  
				where Tabla_Id = 32
			   --'Usuarios'
				------ fin sincronizar con dispositivos-----
			END
	END
GO




IF (OBJECT_ID('usp_Usuarios___update_Campos_Cambiar_Pass') IS NOT NULL) DROP PROCEDURE usp_Usuarios___update_Campos_Cambiar_Pass
GO
CREATE PROCEDURE usp_Usuarios___update_Campos_Cambiar_Pass
		@id								INT									
		
		,@UsuarioQueEjecuta_Id			INT
		,@FechaDeEjecucion				DATETIME
		,@ObsLog						VARCHAR(80) = 'Update Password'	
		
		,@PassActual					VARCHAR(40)	 						
		,@PassNuevo						VARCHAR(40)	
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		-- acá es el propio usuario el q se lo cambia --> no valido nada
		--EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Usuarios', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		--IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
		--	BEGIN
		--		EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Usuarios'  
		--			,@FuncionDePagina = 'Update'
		--			,@AutorizadoA = 'OperarLaPagina'
		--			,@sResSQL = @sResSQL OUTPUT
		--	END

		-- Solo valido que sea él mismo el q ejecuta
		IF NOT @id = @UsuarioQueEjecuta_Id
			BEGIN
				EXEC	@sResSQL = [dbo].ufc_Respuesta__NoTienePermiso -- Solo puede actualizar la contraseña el propio usuario.
			END
		ELSE
			BEGIN
				IF 	(SELECT COUNT(*) FROM Usuarios WHERE (id = @id)	AND (Pass = @PassActual)) = 1 
					BEGIN
						--EXEC dbo.usp_VAL_UsuarioPerteneceAlContextoDe_@Usuario2_Id  @Usuario_Id = @UsuarioQueEjecuta_Id, @Usuario2_Id = @id, @sResSQL = @sResSQL OUTPUT
						
						SET @sResSQL = '' 
						UPDATE Usuarios
						SET	Pass = @PassNuevo
						FROM Usuarios
						WHERE id = @id

						IF @@ROWCOUNT > 0
							BEGIN
								EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Usuarios'
								,@Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
							END	
						ELSE
							BEGIN
								SET @sResSQL = 'Se produjo un error y no se pudo actualizar la contraseña.'
							END
					END
				ELSE
					BEGIN
						SET @sResSQL = 'No se actualizó la contraseña, porque no coincide la contraseña anterior.'
					END
			END
	END
GO




IF (OBJECT_ID('usp_Usuarios___update_Campos_Reset_Pass') IS NOT NULL) DROP PROCEDURE usp_Usuarios___update_Campos_Reset_Pass
GO
CREATE PROCEDURE usp_Usuarios___update_Campos_Reset_Pass
		@id								INT									
		
		,@UsuarioQueEjecuta_Id			INT
		,@FechaDeEjecucion				DATETIME
		,@ObsLog						VARCHAR(80) = 'Reset Password'							

		,@PassNuevo						VARCHAR(40)	
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		EXEC [dbo].[usp_VAL_UsuarioPerteneceAlContextoDelRegistro]  @Usuario_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Usuarios', @Registro_Id = @id, @sResSQL = @sResSQL OUTPUT
		IF (@sResSQL = '')  -- VERIFICO SI TIENE PERMISO P ESTA ACCIÓN
			BEGIN
				EXEC [dbo].[usp_VAL_AutorizadoA] @Usuario_Id = @UsuarioQueEjecuta_Id, @FechaDeEjecucion = @FechaDeEjecucion, @Tabla = 'Usuarios'  
					,@FuncionDePagina = 'Update'
					,@AutorizadoA = 'OperarLaPagina'
					,@sResSQL = @sResSQL OUTPUT
			END
		
		IF (@sResSQL = '')
			BEGIN
				SET @sResSQL = ''
				UPDATE Usuarios
				SET	Pass = @PassNuevo
				FROM Usuarios
				WHERE id = @id

				EXEC @sResSQL = [dbo].ufc_ResultadoOperacion__Update  @RowCount = @@ROWCOUNT

				IF @sResSQL = ''
					BEGIN -- Registro el Log
						EXEC usp_LogRegistros___insert @UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id, @Tabla = 'Usuarios'
						, @Registro_Id = @id, @TipoDe_LogRegistro_Id = '2', @FechaDeEjecucion = @FechaDeEjecucion, @ObsLog = @ObsLog 
					END
			END
	END
GO
---- SP-TABLA: Usuarios - FIN




-- ---------------------------------
-- 16__Core__SP_ABM - Fin de la creacion
-- =====================================================