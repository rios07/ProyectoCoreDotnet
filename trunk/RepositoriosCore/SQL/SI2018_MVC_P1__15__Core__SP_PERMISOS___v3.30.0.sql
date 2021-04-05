-- =====================================================
-- Author:		Dpto de Sistemas - IATASA
-- Create date: 01/06/2018 
-- Description:	15__Core__SP_PERMISOS - DB_MVC_P1
-- =====================================================

USE DB_MVC_P1
GO

-- =====================================================
-- 15__Core__SP_PERMISOS - Inicio
-- -------------------------




-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Paginas - INICIO
	IF (OBJECT_ID('RelAsig__RolesDeUsuarios__A__Paginas___insert___v2') IS NOT NULL) DROP PROCEDURE RelAsig__RolesDeUsuarios__A__Paginas___insert___v2
	GO
	CREATE PROCEDURE RelAsig__RolesDeUsuarios__A__Paginas___insert___v2
			@Pagina_Id										INT
			,@ID_String_Roles_CargarLaPagina				VARCHAR(50)
			,@ID_String_Roles_OperarLaPagina				VARCHAR(50)
			,@ID_String_Roles_VerRegAnulados				VARCHAR(50)
			,@ID_String_Roles_OperarLaPagina_OperacionesSecundarias	VARCHAR(50)
		AS
		BEGIN
			-- Si alguno de los @ID_String... viene = '0' -- Quiere decir q tiene permiso para todos los roles
						
			-- 1ero creo todos los registros, para todos los roles con BIT = 0 para todo
			INSERT INTO RelAsig__RolesDeUsuarios__A__Paginas 
				(
					RolDe_Usuario_Id
					,Pagina_Id
					,AutorizadoACargarLaPagina
					,AutorizadoAOperarLaPagina
					,AutorizadoAVerRegAnulados
					,AutorizadoAOperacionesSecundarias 
				) 
			SELECT	id			
					,@Pagina_Id		
					,'0'						
					,'0'					
					,'0'
					,'0'
			FROM RolesDeUsuarios 
			WHERE id > 0 -- o sea, todos
		
		
			--2do, Modifico c/u de los q me pasen
			
			--A)  CargarLaPagina
			UPDATE RelAsig__RolesDeUsuarios__A__Paginas 
			SET AutorizadoACargarLaPagina = 1
			WHERE 
				(Pagina_Id = @Pagina_Id)
				AND
				(
					(RolDe_Usuario_Id IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_Roles_CargarLaPagina)))
					OR
					(@ID_String_Roles_CargarLaPagina = '0') -- o sea, todos los roles
				)
				
			--B)  OperarLaPagina
			UPDATE RelAsig__RolesDeUsuarios__A__Paginas 
			SET AutorizadoAOperarLaPagina = 1
			WHERE 
				(Pagina_Id = @Pagina_Id)
				AND
				(
					(RolDe_Usuario_Id IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_Roles_OperarLaPagina)))
					OR
					(@ID_String_Roles_OperarLaPagina = '0') -- o sea, todos los roles
				)
				
			--C)  VerRegAnulados
			UPDATE RelAsig__RolesDeUsuarios__A__Paginas 
			SET AutorizadoAVerRegAnulados = 1
			WHERE 
				(Pagina_Id = @Pagina_Id)
				AND
				(
					(RolDe_Usuario_Id IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_Roles_VerRegAnulados)))
					OR
					(@ID_String_Roles_VerRegAnulados = '0') -- o sea, todos los roles
				)
				
			--D)  OperarLaPagina_OperacionesSecundarias
			UPDATE RelAsig__RolesDeUsuarios__A__Paginas 
			SET AutorizadoAOperacionesSecundarias = 1
			WHERE 
				(Pagina_Id = @Pagina_Id)
				AND
				(
					(RolDe_Usuario_Id IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_Roles_OperarLaPagina_OperacionesSecundarias)))
					OR
					(@ID_String_Roles_OperarLaPagina_OperacionesSecundarias = '0') -- o sea, todos los roles
				)
		END
	GO
-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Paginas - FIN




-- SP-TABLA: - INICIO
--IF (OBJECT_ID('usp_PermisoDel_Usuario_Sobre_Paginas___cargar_permisos') IS NOT NULL) DROP PROCEDURE usp_PermisoDel_Usuario_Sobre_Paginas___cargar_permisos
--GO
--CREATE PROCEDURE usp_PermisoDel_Usuario_Sobre_Paginas___cargar_permisos
--		@Usuario_Id			INT
--		,@Pagina			VARCHAR(100)
--	AS
--	BEGIN
	
--		--DECLARE		@Pagina_Id		INT
--		--SET @Pagina_Id = (SELECT id FROM Paginas WHERE Nombre = @Pagina)
		
--		SELECT
--			RPRP.AutorizadoACargarLaPagina AS AutorizadoACargarLaPagina
--			,RPRP.AutorizadoAOperarLaPagina AS AutorizadoAOperarLaPagina
--			,RPRP.AutorizadoAVerRegAnulados AS AutorizadoAVerRegAnulados
--			,RPRP.AutorizadoAOperacionesSecundarias AS AutorizadoAOperacionesSecundarias

--		FROM RelAsig__RolesDeUsuarios__A__Usuarios RARU
--			INNER JOIN RelAsig__RolesDeUsuarios__A__Paginas RPRP ON RARU.RolDe_Usuario_Id = RPRP.RolDe_Usuario_Id 
--		WHERE RARU.Usuario_Id = @Usuario_Id AND RPRP.Pagina_Id = (SELECT id FROM Paginas WHERE Nombre = @Pagina)
--	END
--GO




IF (OBJECT_ID('usp_PrecargaInicialDeUnaPagina') IS NOT NULL) DROP PROCEDURE usp_PrecargaInicialDeUnaPagina
GO
CREATE PROCEDURE usp_PrecargaInicialDeUnaPagina
		@UsuarioQueEjecuta_Id			INT
		,@FechaDeEjecucion				DATETIME

		,@Tabla							VARCHAR(100)
		,@FuncionDePagina				VARCHAR(100)
		,@sResSQL						VARCHAR(1000) OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''

		DECLARE @FuncionDePagina_Id INT
		SELECT @FuncionDePagina_Id = id FROM FuncionesDe_Paginas WHERE NombreEnASPX = @FuncionDePagina

		DECLARE @Tabla_Id INT
		SELECT @Tabla_Id = id FROM Tablas WHERE Nombre = @Tabla

		DECLARE @Pagina_Id INT
		SELECT @Pagina_Id = id FROM Paginas WHERE Tabla_Id = @Tabla_Id AND FuncionDe_Pagina_Id = @FuncionDePagina_Id

		-- Necesito tener al menos 1 columna con la que relacionar las tablas --> Rel
		SELECT *
		FROM
		(
			SELECT
				1 AS Rel
				,MAX(CAST(RPRP.AutorizadoA_CargarLaPagina AS INT)) AS AutorizadoACargarLaPagina
				,MAX(CAST(RPRP.AutorizadoA_OperarLaPagina AS INT)) AS AutorizadoAOperarLaPagina
				,MAX(CAST(RPRP.AutorizadoA_VerRegAnulados AS INT)) AS AutorizadoAVerRegAnulados
				,MAX(CAST(RPRP.AutorizadoA_OperacionesSecundarias AS INT)) AS AutorizadoAOperacionesSecundarias

			FROM Rel_Asig__RolesDe_Usuarios__A__Usuarios RARU
				INNER JOIN Rel_Asig__RolesDe_Usuarios__A__Paginas RPRP ON RARU.RolDe_Usuario_Id = RPRP.RolDe_Usuario_Id
			WHERE 
				RARU.Usuario_Id = @UsuarioQueEjecuta_Id AND RPRP.Pagina_Id = @Pagina_Id
				AND RARU.FechaDesde <= @FechaDeEjecucion
				AND	(RARU.FechaHasta IS NULL OR RARU.FechaHasta >= @FechaDeEjecucion)
		) AS T1
		INNER JOIN
		(
			SELECT 
				1 AS Rel
				,(CASE WHEN P.Titulo IS NULL OR P.Titulo = '' THEN T.NombreAMostrar + ' - ' + FP.NombreAMostrar
					ELSE P.Titulo END) AS Titulo
				,P.Observaciones AS Notas
				,COALESCE(P.Tips, '') AS Tips
				 
			FROM Paginas P
				INNER JOIN Tablas T ON P.Tabla_Id = T.id
				INNER JOIN FuncionesDe_Paginas FP ON P.FuncionDe_Pagina_Id = FP.id 
			WHERE
				P.id = @Pagina_Id
		) AS T2 ON T1.Rel = T2.Rel

		--IF @FuncionDePagina = 'Create' OR @FuncionDePagina = 'Details' OR @FuncionDePagina = 'Update'
		--	BEGIN
		--		--SI ES ADD O SELECTED LE AGREGO ESTAS NOTAS GENERICA
		--		SET @Notas = '(*): Campos obligatorios.' + 
		--						' <br> (#): Campos obligatorios que no pueden modificarse una vez asignados.' + 
		--						--' <br> Se indica al final de cada campo entre conchetes, el tamaño máximo de su texto.' + 
		--						' <br> ABM: Alta, Baja y Modificación de Registros.'
		--	END
			
		--SET @Notas = '<br><br><b>Notas:</b><br>' + @Notas +
		--				'<br> Si tiene permiso, puede revisar los Roles que tiene asignados en la siguiente página: ' +
		--					'<a target="_blank" href="Asignacion__Roles__A__Usuarios_Selected.aspx?Registro=' + 
		--					CAST(@UsuarioQueEjecuta_Id AS VARCHAR) + '">Roles Asignados</a>'
	END
GO

--IF (OBJECT_ID('usp_Usuarios___Permisos_SobrePaginas') IS NOT NULL) DROP PROCEDURE usp_Usuarios___Permisos_SobrePaginas
--GO
--CREATE PROCEDURE usp_Usuarios___Permisos_SobrePaginas
--		@UsuarioQueEjecuta_Id			INT
--		,@Pagina						VARCHAR(100)
		
--		,@Titulo						VARCHAR(100) = ''		OUTPUT
--		,@Notas							VARCHAR(2000) = ''		OUTPUT
--		,@Tips							VARCHAR(2000) = ''		OUTPUT
--		,@sResSQL						VARCHAR(1000) OUTPUT
--	AS
--	BEGIN
--		DECLARE @FuncionDePagina	INT
--		SET @sResSQL = ''
--		SELECT
--			MAX(CAST(RPRP.AutorizadoACargarLaPagina AS INT)) AS AutorizadoACargarLaPagina
--			,MAX(CAST(RPRP.AutorizadoAOperarLaPagina AS INT)) AS AutorizadoAOperarLaPagina
--			,MAX(CAST(RPRP.AutorizadoAVerRegAnulados AS INT)) AS AutorizadoAVerRegAnulados
--			,MAX(CAST(RPRP.AutorizadoAOperacionesSecundarias AS INT)) AS AutorizadoAOperacionesSecundarias

--		FROM RelAsig__RolesDeUsuarios__A__Usuarios RARU
--			INNER JOIN RelAsig__RolesDeUsuarios__A__Paginas RPRP ON RARU.RolDe_Usuario_Id = RPRP.RolDe_Usuario_Id
--		WHERE 
--			RARU.Usuario_Id = @UsuarioQueEjecuta_Id AND RPRP.Pagina_Id = (SELECT id FROM Paginas WHERE Nombre = @Pagina)
--			AND
--			(
--					RARU.FechaDesde <= GETDATE()
--				AND
--					(RARU.FechaHasta IS NULL OR RARU.FechaHasta >= GETDATE())
--			)
		
--		SELECT 
--				@Titulo = (CASE WHEN P.Titulo IS NULL OR P.Titulo = '' THEN T.NombreAMostrar + ' - ' + FP.NombreAMostrar
--					ELSE P.Titulo END)
--				,@Notas = P.Observaciones
--				,@Tips = COALESCE(P.Tips, '')
--				,@FuncionDePagina = P.FuncionDe_Pagina_Id
				 
--			FROM Paginas P
--				INNER JOIN Tablas T ON P.Tabla_Id = T.id
--				INNER JOIN FuncionesDe_Paginas FP ON P.FuncionDe_Pagina_Id = FP.id 
--			WHERE
--				P.Nombre = @Pagina
		
--		IF @FuncionDePagina = 1 OR @FuncionDePagina = 3
--			BEGIN
--				--SI ES ADD O SELECTED LE AGREGO ESTAS NOTAS GENERICA
--				SET @Notas = '(*): Campos obligatorios.' + 
--								' <br> (#): Campos obligatorios que no pueden modificarse una vez asignados.' + 
--								--' <br> Se indica al final de cada campo entre conchetes, el tamaño máximo de su texto.' + 
--								' <br> ABM: Alta, Baja y Modificación de Registros.'
--			END
		
--		--IF @Notas = ''
--		--	BEGIN
--		--		SET @Notas = '<br><br><b>No hay Notas.</b>'
--		--	END
--		--ELSE
--		--	BEGIN
--		--		SET @Notas = '<br><br><b>Notas: </b><br>' + @Notas
--		--	END
			
--		SET @Notas = '<br><br><b>Notas:</b><br>' + @Notas +
--						'<br> Si tiene permiso, puede revisar los Roles que tiene asignados en la siguiente página: ' +
--							'<a target="_blank" href="Asignacion__Roles__A__Usuarios_Selected.aspx?Registro=' + 
--							CAST(@UsuarioQueEjecuta_Id AS VARCHAR) + '">Roles Asignados</a>'
--	END
--GO
-- SP-TABLA:  - FIN

-- ---------------------------------
-- 15__Core__SP_PERMISOS - Fin de la creacion
-- =====================================================