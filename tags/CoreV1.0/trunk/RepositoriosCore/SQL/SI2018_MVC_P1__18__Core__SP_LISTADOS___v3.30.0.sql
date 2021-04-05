-- =====================================================
-- Author:		Dpto de Sistemas - IATASA
-- Create date: 01/06/2018 
-- Description:	18__Core__SP_LISTADOS
-- =====================================================

--USE DB_MVC_P1
--GO

-- =====================================================
-- 18__Core__SP_LISTADOS - Inicio
-- -------------------------


-- SP-TABLA: Actores - INICIO, -- 48
IF (OBJECT_ID('usp_Actores___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_Actores___listado_cFiltros
GO
CREATE PROCEDURE usp_Actores___listado_cFiltros
		@UsuarioQueEjecuta_Id		INT
		
		,@OrdenarPor				VARCHAR(50)
		,@Sentido					BIT
		,@Filtro					VARCHAR(50)
		,@Activo					BIT	= 1
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT 
		
		IF @sResSQL = ''
			BEGIN
				SELECT  ACT.id
						,TDACT.Nombre AS TipoDe_Actor
						,ACT.Codigo			
						,ACT.Nombre
				FROM Actores ACT
					INNER JOIN TiposDe_Actores TDACT ON ACT.TipoDe_Actor_Id = TDACT.id
				WHERE  
					(ACT.Contexto_Id = @Contexto_Id)
					AND	(ACT.Activo = @Activo)
					AND	(
						(@Filtro = '')
						OR (ACT.Nombre LIKE '%' + @Filtro + '%')
						OR (ACT.Codigo LIKE '%' + @Filtro + '%')
						OR (TDACT.Nombre LIKE '%' + @Filtro + '%')
						)
				ORDER BY CASE 
					WHEN @OrdenarPor = 'Nombre' AND @Sentido = '0' THEN RANK() OVER (ORDER BY ACT.Nombre)
					WHEN @OrdenarPor = 'Nombre' AND @Sentido = '1' THEN RANK() OVER (ORDER BY ACT.Nombre DESC)
					WHEN @OrdenarPor = 'Código' AND @Sentido = '0' THEN RANK() OVER (ORDER BY ACT.Codigo)
					WHEN @OrdenarPor = 'Código' AND @Sentido = '1' THEN RANK() OVER (ORDER BY ACT.Codigo DESC)
					WHEN @OrdenarPor = 'Tipo de actor' AND @Sentido = '0' THEN RANK() OVER (ORDER BY TDACT.Nombre)
					WHEN @OrdenarPor = 'Tipo de actor' AND @Sentido = '1' THEN RANK() OVER (ORDER BY TDACT.Nombre DESC)
					END	
			END
		--END
	END
GO



IF (OBJECT_ID('usp_Actores___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_Actores___listado_DDL_o_CBXL
GO
CREATE PROCEDURE usp_Actores___listado_DDL_o_CBXL 
--	@Formato_Listado 
--		=-2 : Rearmar 'Seleccionar' y ADD 'Todos'
--		=-1 : Con 'Todos' Sin 'Seleccionar'
--		=0	: Rearmar 'Seleccionar'
--		=1	: "Tabla Entera"
--		=2	: "Sin el 0"
		@UsuarioQueEjecuta_Id		INT
		
		,@Formato_Listado			SMALLINT = 1
		,@Activo					BIT	= 1
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
		
		IF @Contexto_Id = 0
			SET @sResSQL = ''
		
		DECLARE @Actor_UsuarioQueEjecuta_Id INT
		
		SELECT @Actor_UsuarioQueEjecuta_Id = Actor_Id FROM Usuarios WHERE id = @UsuarioQueEjecuta_Id
		
		IF @sResSQL = '' 
			BEGIN
				DECLARE @MinId AS INT
				EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado
				SELECT	 id
						,Data 
				FROM ufc_Adds_To_DDLs(@Formato_Listado)
				
				UNION
				
				SELECT	ACT.id
						,ACT.Nombre + ' (' + TDACT.Nombre + ')'  AS Data
				FROM Actores ACT
					INNER JOIN TiposDe_Actores TDACT ON ACT.TipoDe_Actor_Id = TDACT.id
				WHERE 
					(ACT.Contexto_Id = @Contexto_Id)
					AND 
					(ACT.id >= @MinId)
					AND	(ACT.Activo = @Activo)
					AND (ACT.id > 1 OR ACT.id = @Actor_UsuarioQueEjecuta_Id)
				ORDER BY id
			END
		--ENDIF
	END
GO




IF (OBJECT_ID('usp_Actores___listado_DDL_o_CBXL_by_@TipoDe_Actor_Id') IS NOT NULL) DROP PROCEDURE usp_Actores___listado_DDL_o_CBXL_by_@TipoDe_Actor_Id
GO
CREATE PROCEDURE usp_Actores___listado_DDL_o_CBXL_by_@TipoDe_Actor_Id 
--	@Formato_Listado 
--		=-2 : Rearmar 'Seleccionar' y ADD 'Todos'
--		=-1 : Con 'Todos' Sin 'Seleccionar'
--		=0	: Rearmar 'Seleccionar'
--		=1	: "Tabla Entera"
--		=2	: "Sin el 0"
		@UsuarioQueEjecuta_Id		INT
		
		,@Formato_Listado			SMALLINT = 1
		,@Activo					BIT	= 1
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
		
		,@TipoDe_Actor_Id			INT
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
		
		IF @sResSQL = ''
			BEGIN
				DECLARE @MinId AS INT
				EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado
				SELECT	 id
						,Data 
				FROM ufc_Adds_To_DDLs(@Formato_Listado)

				UNION

				SELECT	ACT.id
						,ACT.Nombre + ' (' + TDACT.Nombre + ')'  AS Data
				FROM Actores ACT
					INNER JOIN TiposDe_Actores TDACT ON ACT.TipoDe_Actor_Id = TDACT.id
				WHERE 
					(ACT.Contexto_Id = @Contexto_Id)
					AND (ACT.id >= @MinId)
					AND	(ACT.Activo = @Activo)
					AND (@TipoDe_Actor_Id = -1 OR TipoDe_Actor_Id = @TipoDe_Actor_Id)
				ORDER BY id
			END
		--ENDIF
	END
GO




IF (OBJECT_ID('usp_Actores___listado_DDL_o_CBXL_by_@Actor_Id') IS NOT NULL) DROP PROCEDURE usp_Actores___listado_DDL_o_CBXL_by_@Actor_Id
GO
CREATE PROCEDURE usp_Actores___listado_DDL_o_CBXL_by_@Actor_Id 
--	@Formato_Listado 
--		=-2 : Rearmar 'Seleccionar' y ADD 'Todos'
--		=-1 : Con 'Todos' Sin 'Seleccionar'
--		=0	: Rearmar 'Seleccionar'
--		=1	: "Tabla Entera"
--		=2	: "Sin el 0"
		@UsuarioQueEjecuta_Id		INT
		
		,@Formato_Listado			SMALLINT = 1
		,@Activo					BIT	= 1
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
		
		,@Actor_Id					INT
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
		DECLARE @TipoDe_Actor_Id INT
		SET @TipoDe_Actor_Id = (SELECT TipoDe_Actor_Id FROM Actores WHERE id = @Actor_Id)
		IF @sResSQL = ''
			BEGIN
				DECLARE @MinId AS INT
				EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado
				SELECT	 id
						,Data 
				FROM ufc_Adds_To_DDLs(@Formato_Listado)
				
				UNION
				
				SELECT	ACT.id
						,ACT.Nombre + ' (' + TDACT.Nombre + ')'  AS Data
				FROM Actores ACT
					INNER JOIN TiposDe_Actores TDACT ON ACT.TipoDe_Actor_Id = TDACT.id
				WHERE 
					(Contexto_Id = @Contexto_Id)
					AND (ACT.id >= @MinId)
					AND	(ACT.Activo = @Activo)
					AND (ACT.TipoDe_Actor_Id <> @TipoDe_Actor_Id OR @TipoDe_Actor_Id IS NULL)
					--1 SUPERVISOR
					--2 CONTRATISTA
					--3 COMITENTE
					AND (ACT.TipoDe_Actor_Id = 1 OR @TipoDe_Actor_Id = 1 OR @TipoDe_Actor_Id IS NULL)
				ORDER BY id
			END
		--ENDIF
	END
GO




IF (OBJECT_ID('usp_Actores___listado_cFiltros_cPag') IS NOT NULL) DROP PROCEDURE usp_Actores___listado_cFiltros_cPag
GO
CREATE PROCEDURE usp_Actores___listado_cFiltros_cPag
		@OrdenarPor						VARCHAR(50)
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		
		,@Activo						BIT = NULL
		
		,@RegistrosPorPagina			INT = -1
		,@NumeroDePagina				INT = 1
		,@TotalDeRegistros				INT	= 0			OUTPUT		

        ,@sResSQL						VARCHAR(1000)	OUTPUT
        ,@UsuarioQueEjecuta_Id			INT
    AS
	BEGIN
	DECLARE @Contexto_Id INT
	EXEC @Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT 
	
    --SET @sResSQL = ''
	IF @RegistrosPorPagina = -1  -- Sin paginación
		BEGIN
			
			SELECT  ACT.id
					,TDACT.Nombre AS TipoDe_Actor
					,ACT.Codigo			
					,ACT.Nombre
				,0 AS 'TotalDeRegistros'
				--,Activo
			FROM Actores ACT
				INNER JOIN TiposDe_Actores TDACT ON ACT.TipoDe_Actor_Id = TDACT.id
			WHERE  
				--(ACT.Contexto_Id = @Contexto_Id)
				(ACT.Activo = @Activo)
				AND	(
					(@Filtro = '')
					OR (ACT.Nombre LIKE '%' + @Filtro + '%')
					OR (ACT.Codigo LIKE '%' + @Filtro + '%')
					OR (TDACT.Nombre LIKE '%' + @Filtro + '%')
					)

			ORDER BY id
		END
	ELSE
		BEGIN
			SELECT * INTO #TempTable
			FROM
			(
				SELECT  ACT.id
						,TDACT.Nombre AS TipoDe_Actor
						,ACT.Codigo			
						,ACT.Nombre
						,ROW_NUMBER() OVER 
						(
							-- VER QUE PARA PONER VARIOS CAMPOS --> VARIAS LINEAS CON EL MISMO WHEN
							ORDER BY  
								CASE WHEN @OrdenarPor = 'Fecha' AND @Sentido = '0' THEN ACT.Nombre END
								,CASE WHEN @OrdenarPor = 'Fecha' AND @Sentido = '1' THEN ACT.Nombre END DESC
									
						) AS NumeroDeRegistro
				
				FROM Actores ACT
					INNER JOIN TiposDe_Actores TDACT ON ACT.TipoDe_Actor_Id = TDACT.id
				WHERE  
					(ACT.Contexto_Id = @Contexto_Id)
					AND	(ACT.Activo = @Activo)
					AND	(
						(@Filtro = '')
						OR (ACT.Nombre LIKE '%' + @Filtro + '%')
						OR (ACT.Codigo LIKE '%' + @Filtro + '%')
						OR (TDACT.Nombre LIKE '%' + @Filtro + '%')
						)
			) Query
			SELECT	id
					,TipoDe_Actor
					,Codigo
					,Nombre
					,(SELECT MAX(NumeroDeRegistro) FROM #TempTable) AS 'TotalDeRegistros'
			 
			FROM  #TempTable
			WHERE NumeroDeRegistro BETWEEN ((@NumeroDePagina - 1) * @RegistrosPorPagina) + 1 AND @RegistrosPorPagina * (@NumeroDePagina)
			
			SET @TotalDeRegistros = (SELECT	COUNT(*) FROM  #TempTable)
			DROP TABLE #TempTable
		END
		--ENDIF
    END
GO
-- SP-TABLA: Actores - FIN




---- SP-TABLA: Ambitos - INICIO, -- 46
--IF (OBJECT_ID('usp_Ambitos___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_Ambitos___listado_cFiltros
--GO
--CREATE PROCEDURE usp_Ambitos___listado_cFiltros
--		@UsuarioQueEjecuta_Id			INT

--		,@OrdenarPor					VARCHAR(50)
--		,@Sentido						BIT
--		,@Filtro						VARCHAR(50)
--		,@Activo						BIT	= 1
		
--		,@sResSQL						VARCHAR(1000)			OUTPUT
--	AS
--	BEGIN
--		DECLARE @Contexto_Id	INT
--		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
		
--		IF @sResSQL = ''
--			BEGIN
--				SELECT  AMB.id
--						,SUP.Nombre AS Supervisor
--						,COALESCE(CONT.Nombre, '-') AS Contratista
--						,AMB.Codigo			
--						,AMB.Nombre
--				FROM Ambitos AMB
--					INNER JOIN Actores SUP ON AMB.Supervision_Id = SUP.id
--					LEFT JOIN Actores CONT ON AMB.Contratista_Id = CONT.id
--				WHERE
--					(AMB.Contexto_Id = @Contexto_Id)
--					AND	(AMB.Activo = @Activo)
--					AND	(
--						(@Filtro = '')
--						OR (AMB.Nombre LIKE '%' + @Filtro + '%')
--						OR (AMB.Codigo LIKE '%' + @Filtro + '%')
--						OR (SUP.Nombre LIKE '%' + @Filtro + '%')
--						OR (CONT.Nombre LIKE '%' + @Filtro + '%')
--						)
--				ORDER BY CASE 
--					WHEN @OrdenarPor = 'Nombre' AND @Sentido = '0' THEN RANK() OVER (ORDER BY AMB.Nombre)
--					WHEN @OrdenarPor = 'Nombre' AND @Sentido = '1' THEN RANK() OVER (ORDER BY AMB.Nombre DESC)
--					WHEN @OrdenarPor = 'Código' AND @Sentido = '0' THEN RANK() OVER (ORDER BY AMB.Codigo)
--					WHEN @OrdenarPor = 'Código' AND @Sentido = '1' THEN RANK() OVER (ORDER BY AMB.Codigo DESC)
--					WHEN @OrdenarPor = 'Supervisor' AND @Sentido = '0' THEN RANK() OVER (ORDER BY SUP.Nombre)
--					WHEN @OrdenarPor = 'Supervisor' AND @Sentido = '1' THEN RANK() OVER (ORDER BY SUP.Nombre DESC)
--					WHEN @OrdenarPor = 'Contratista' AND @Sentido = '0' THEN RANK() OVER (ORDER BY CONT.Nombre)
--					WHEN @OrdenarPor = 'Contratista' AND @Sentido = '1' THEN RANK() OVER (ORDER BY CONT.Nombre DESC)
--					END	

--			END
--		--ENDIF
--	END
--GO




--IF (OBJECT_ID('usp_Ambitos___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_Ambitos___listado_DDL_o_CBXL
--GO
--CREATE PROCEDURE usp_Ambitos___listado_DDL_o_CBXL 
----	@Formato_Listado 
----		=-2 : Rearmar 'Seleccionar' y ADD 'Todos'
----		=-1 : Con 'Todos' Sin 'Seleccionar'
----		=0	: Rearmar 'Seleccionar'
----		=1	: "Tabla Entera"
----		=2	: "Sin el 0"
--		@UsuarioQueEjecuta_Id		INT
		
--		,@Formato_Listado			SMALLINT = 1
--		,@Activo					BIT	= 1
		
--		,@sResSQL					VARCHAR(1000)			OUTPUT
--	AS
--	BEGIN
--		DECLARE @Contexto_Id	INT
--		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT
		
--		IF @sResSQL = ''
--			BEGIN
--				DECLARE @MinId AS INT
--				EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado
--				SELECT	 id
--						,Data 
--				FROM ufc_Adds_To_DDLs(@Formato_Listado)
				
--				UNION
				
--				SELECT	id
--						,Nombre  AS Data
--				FROM Ambitos
--				WHERE 
--					(Contexto_Id = @Contexto_Id)
--					AND	(id >= @MinId)
--					AND	(Activo = @Activo)
--				ORDER BY id
--			END
--	END
--GO	




--IF (OBJECT_ID('usp_Ambitos___listado_DDL_o_CBXL_by_@ID_String_Actores') IS NOT NULL) DROP PROCEDURE usp_Ambitos___listado_DDL_o_CBXL_by_@ID_String_Actores
--GO
--CREATE PROCEDURE usp_Ambitos___listado_DDL_o_CBXL_by_@ID_String_Actores 
----	@Formato_Listado 
----		=-2 : Rearmar 'Seleccionar' y ADD 'Todos'
----		=-1 : Con 'Todos' Sin 'Seleccionar'
----		=0	: Rearmar 'Seleccionar'
----		=1	: "Tabla Entera"
----		=2	: "Sin el 0"

--		@UsuarioQueEjecuta_Id		INT
		
--		,@Formato_Listado			SMALLINT = 1
--		,@Activo					BIT	= 1
		
--		,@sResSQL					VARCHAR(1000)			OUTPUT
		
--		,@ID_String_Actores			VARCHAR(100)
--	AS
--	BEGIN
--		DECLARE @Contexto_Id	INT
--		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT
		
--		DECLARE @Contratista_Id INT
--		DECLARE @Supervision_Id INT
		
--		SET @Contratista_Id =	(SELECT id FROM Actores 
--									WHERE	TipoDe_Actor_Id = 2 
--											AND id IN (SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_Actores))
--								)
								
--		SET @Supervision_Id =	(SELECT id FROM Actores 
--									WHERE	TipoDe_Actor_Id = 1 
--											AND id IN (SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_Actores))
--								)
		
--		IF @sResSQL = ''
--			BEGIN
--				DECLARE @MinId AS INT
--				EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado
--				SELECT	 id
--						,Data 
						
--				FROM ufc_Adds_To_DDLs(@Formato_Listado)
--				UNION
--				SELECT	id
--						,Nombre  AS Data
						
--				FROM Ambitos
--				WHERE 
--					(Contexto_Id = @Contexto_Id)
--					AND	(id >= @MinId)
--					AND	(Activo = @Activo)
--					AND (@Contratista_Id IS NULL OR Contratista_Id = @Contratista_Id) 
--					AND (@Supervision_Id IS NULL OR Supervision_Id = @Supervision_Id) 
--				ORDER BY id
--			END
--	END
--GO
---- SP-TABLA: Ambitos - FIN




-- SP-TABLA: Colores - INICIO, -- 41
IF (OBJECT_ID('usp_Colores___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_Colores___listado_cFiltros
GO
CREATE PROCEDURE usp_Colores___listado_cFiltros
		@UsuarioQueEjecuta_Id		INT

		,@OrdenarPor				VARCHAR(50)
		,@Sentido					BIT
		,@Filtro					VARCHAR(50)
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		SELECT	id
				,Nombre
				,CodigoHexadecimal
								
		FROM Colores
		WHERE 
			(
				(@Filtro = '')
				OR (Nombre LIKE '%' + @Filtro + '%')
				OR (CodigoHexadecimal LIKE '%' + @Filtro + '%')
			)
		ORDER BY CASE 
			WHEN @OrdenarPor = 'Nombre' AND @Sentido = '0' THEN RANK() OVER (ORDER BY Nombre)
			WHEN @OrdenarPor = 'Nombre' AND @Sentido = '1' THEN RANK() OVER (ORDER BY Nombre DESC)
			END	
	END
GO




IF (OBJECT_ID('usp_Colores___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_Colores___listado_DDL_o_CBXL 
GO
CREATE PROCEDURE usp_Colores___listado_DDL_o_CBXL 
		@UsuarioQueEjecuta_Id		INT
		
		,@Formato_Listado			SMALLINT = 1
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		DECLARE @MinId AS INT
		EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado

		SET @sResSQL = ''
		--	SELECT    'Return Value' = @return_value
		--SET @MinId = (SELECT ufc_MinimoId_inDDLs(@Formato_Listado))
		
		SELECT	 id
				,Data 
				,'#000000' AS Color
		
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
						
		UNION
		SELECT	id
				,Nombre  AS Data
				,'#' + CodigoHexadecimal AS Color
				
		FROM Colores
		WHERE id >= @MinId
			--AND
		ORDER BY Data
	END
GO
-- SP-TABLA: Colores - FIN




-- SP-TABLA: Contextos - INICIO, -- 54
IF (OBJECT_ID('usp_Contextos___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_Contextos___listado_cFiltros
GO
CREATE PROCEDURE usp_Contextos___listado_cFiltros
		@UsuarioQueEjecuta_Id		INT
		
		,@OrdenarPor				VARCHAR(50)
		,@Sentido					BIT
		,@Filtro					VARCHAR(50)
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT
		
		IF @sResSQL = ''
			BEGIN
		
				SELECT  CONT.id
						,CONT.Numero
						,CONT.Codigo			
						,CONT.Nombre
						,CONT.Observaciones
						--,ADM.LogonName AS Administrador
				FROM Contextos CONT
				--INNER JOIN Usuarios ADM ON CONT.Administrador_Id = ADM.id

				WHERE  
					(
						(@Filtro = '')
						OR (CONT.Nombre LIKE '%' + @Filtro + '%')
						OR (CONT.Codigo LIKE '%' + @Filtro + '%')
						OR (CONT.Numero LIKE '%' + @Filtro + '%')
						--OR (ADM.LogonName LIKE '%' + @Filtro + '%')
					)
					AND
						(CONT.id = @Contexto_Id) -- OR (@Contexto_Id = 0 AND dbo.ufc_UsuarioEs_MasterAdmin(@UsuarioQueEjecuta_Id) = 1)) 
					AND 
						(CONT.id > 0)
						
				UNION
				
				SELECT  CONT.id
						,CONT.Numero
						,CONT.Codigo			
						,CONT.Nombre
						,CONT.Observaciones
						--,ADM.LogonName AS Administrador
				FROM Contextos CONT
				INNER JOIN LogRegistros LOGREG ON LOGREG.Tabla_Id = 54 --TABLA Contextos
												AND LOGREG.Registro_Id = CONT.id 
												AND LOGREG.UsuarioQueEjecuta_Id = @UsuarioQueEjecuta_Id
												AND LOGREG.TipoDe_LogRegistro_Id = 1 --CREADO
				
				ORDER BY CONT.id --CASE 
				--	WHEN @OrdenarPor = 'Nombre' AND @Sentido = '0' THEN RANK() OVER (ORDER BY CONT.Nombre)
				--	WHEN @OrdenarPor = 'Nombre' AND @Sentido = '1' THEN RANK() OVER (ORDER BY CONT.Nombre DESC)
				--	WHEN @OrdenarPor = 'Código' AND @Sentido = '0' THEN RANK() OVER (ORDER BY CONT.Codigo)
				--	WHEN @OrdenarPor = 'Código' AND @Sentido = '1' THEN RANK() OVER (ORDER BY CONT.Codigo DESC)
				--	WHEN @OrdenarPor = 'Número' AND @Sentido = '0' THEN RANK() OVER (ORDER BY CONT.Numero)
				--	WHEN @OrdenarPor = 'Número' AND @Sentido = '1' THEN RANK() OVER (ORDER BY CONT.Numero DESC)
					--WHEN @OrdenarPor = 'Administrador' AND @Sentido = '0' THEN RANK() OVER (ORDER BY ADM.LogonName, CONT.Numero)
					--WHEN @OrdenarPor = 'Administrador' AND @Sentido = '1' THEN RANK() OVER (ORDER BY ADM.LogonName DESC, CONT.Numero DESC)
					--END	
			END

	END
GO
-- SP-TABLA: Contextos - FIN




-- SP-TABLA: EstadosDeLogErrores - INICIO, -- 9
IF (OBJECT_ID('usp_EstadosDeLogErrores___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_EstadosDeLogErrores___listado_DDL_o_CBXL
GO
CREATE PROCEDURE usp_EstadosDeLogErrores___listado_DDL_o_CBXL 
		@UsuarioQueEjecuta_Id		INT
		
		,@Formato_Listado			SMALLINT = 1
		,@Activo			BIT = 1
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		SET @sResSQL = ''
		DECLARE @MinId AS INT
		EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado

		--	SELECT    'Return Value' = @return_value
		--SET @MinId = (SELECT ufc_MinimoId_inDDLs(@Formato_Listado))
		
		SELECT	 id
				,Data 
		
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
						
		UNION
		SELECT	id
				,Nombre	AS Data
				
		FROM EstadosDeLogErrores
		ORDER BY id
	END
GO
-- SP-TABLA: EstadosDeLogErrores - FIN




-- SP-TABLA: EstadosDeSoporte - INICIO, -- 10
IF (OBJECT_ID('usp_EstadosDeSoporte___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_EstadosDeSoporte___listado_DDL_o_CBXL
GO
CREATE PROCEDURE usp_EstadosDeSoporte___listado_DDL_o_CBXL 
		@UsuarioQueEjecuta_Id		INT
		
		,@Formato_Listado			SMALLINT = 1
		,@Activo			BIT = 1
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		SET @sResSQL = ''
		DECLARE @MinId AS INT
		EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado

		--	SELECT    'Return Value' = @return_value
		--SET @MinId = (SELECT ufc_MinimoId_inDDLs(@Formato_Listado))
		
		SELECT	 id
				,Data 
		
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
						
		UNION
		SELECT	id
				,Nombre	AS Data
				
		FROM EstadosDeSoporte
		ORDER BY id
	END
GO
-- SP-TABLA: EstadosDeSoporte - FIN




-- SP-TABLA: GradosDeImportancia - INICIO, -- 12
IF (OBJECT_ID('usp_GradosDeImportancia___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_GradosDeImportancia___listado_cFiltros
GO
CREATE PROCEDURE usp_GradosDeImportancia___listado_cFiltros
		@UsuarioQueEjecuta_Id			INT
		
		,@OrdenarPor					VARCHAR(50)	
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		,@Activo			BIT = 1
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		SET @sResSQL = ''
		SELECT	Codigo
				,Codigo + N' (' + Nombre + N')' AS Data
				,Orden
				
		FROM GradosDeImportancia
		WHERE Codigo <> N'0'
			--(Activo = '1')
			--AND
		ORDER BY Orden DESC
	END
GO




IF (OBJECT_ID('usp_GradosDeImportancia___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_GradosDeImportancia___listado_DDL_o_CBXL
GO
CREATE PROCEDURE usp_GradosDeImportancia___listado_DDL_o_CBXL 
		@UsuarioQueEjecuta_Id		INT
		
		,@Formato_Listado			SMALLINT = 1
		,@Activo			BIT = 1
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		SET @sResSQL = ''
		SELECT	 Codigo
				,Data 
				,'1000' AS Orden
		
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
						
		UNION
		SELECT	Codigo
				,Codigo + N' (' + Nombre + N')' AS Data
				,Orden
				
		FROM GradosDeImportancia
		WHERE Codigo <> N'0'
			--(Activo = '1')
			--AND
		ORDER BY Orden DESC
	END
GO
-- SP-TABLA: GradosDeImportancia - FIN




-- SP-TABLA: Iconos - INICIO, -- 45
IF (OBJECT_ID('usp_Iconos___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_Iconos___listado_DDL_o_CBXL
GO
CREATE PROCEDURE usp_Iconos___listado_DDL_o_CBXL 
		@UsuarioQueEjecuta_Id		INT
		
		,@Formato_Listado			SMALLINT = 1
		,@Activo			BIT = 1
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		SET @sResSQL = ''
		DECLARE @MinId AS INT
		EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado
		SELECT	 id
				,Data 
				
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
		UNION
		SELECT	id
				,Ruta AS Data
				
		FROM Iconos
		WHERE id >= @MinId
			--(Activo = '1')
			--AND
		ORDER BY id
	END
GO
-- SP-TABLA: Iconos - FIN




-- SP-TABLA: Informes - INICIO
IF (OBJECT_ID('usp_Informes___listado') IS NOT NULL) DROP PROCEDURE usp_Informes___listado
GO
CREATE PROCEDURE usp_Informes___listado
		@OrdenarPor					VARCHAR(50)
		,@Sentido					BIT
		,@Filtro					VARCHAR(50)
		,@Activo					BIT	= NULL
	 
        ,@sResSQL					VARCHAR(1000)			OUTPUT
        ,@UsuarioQueEjecuta_Id		INT
    AS
BEGIN
    SET @sResSQL = ''
		SELECT INF.id 
				,U.Apellido + N', ' + U.Nombre AS NombreDeUsuario
				,INF.Titulo 
				,CDINF.Categoria
				,INF.Texto
				,INF.FechaDe_Informe  
				,(SELECT COUNT(id) FROM AdjuntosDe_Informes WHERE Informe_Id = INF.id) AS CantidadDe_Adjuntos
								
		FROM Informes INF
			INNER JOIN Usuarios U ON INF.Usuario_Id = U.id
			INNER JOIN CategoriasDe_Informes CDINF on INF.Categoria_id = CDINF.id
		WHERE 
			(INF.Activo = @Activo OR @Activo IS NULL)
			AND
			(
				(@Filtro = '')
				OR (U.Apellido + N', ' + U.Nombre LIKE '%' + @Filtro + '%')
				OR (INF.Titulo LIKE '%' + @Filtro + '%')
				OR (INF.Texto LIKE '%' + @Filtro + '%')
			)
		ORDER BY CASE 
			WHEN @OrdenarPor = 'Fecha' AND @Sentido = '0' THEN RANK() OVER (ORDER BY INF.FechaDe_Informe, U.Nombre, U.Apellido)
			WHEN @OrdenarPor = 'Fecha' AND @Sentido = '1' THEN RANK() OVER (ORDER BY INF.FechaDe_Informe DESC, U.Nombre, U.Apellido)  
			WHEN @OrdenarPor = 'Titulo' AND @Sentido = '0' THEN RANK() OVER (ORDER BY INF.Titulo,  U.Nombre, U.Apellido)
			WHEN @OrdenarPor = 'Titulo' AND @Sentido = '1' THEN RANK() OVER (ORDER BY INF.Titulo DESC,  U.Nombre, U.Apellido)  
			WHEN @OrdenarPor = 'Autor' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U.Nombre, U.Apellido, INF.FechaDe_Informe)
			WHEN @OrdenarPor = 'Autor' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U.Nombre DESC, U.Apellido DESC, INF.FechaDe_Informe)
			END	
	END
GO



IF (OBJECT_ID('usp_Informes___listado_cFiltros_cPag') IS NOT NULL) DROP PROCEDURE usp_Informes___listado_cFiltros_cPag
GO
CREATE PROCEDURE usp_Informes___listado_cFiltros_cPag
		@OrdenarPor					VARCHAR(50)
		,@Sentido					BIT
		,@Filtro					VARCHAR(50)
		
		,@Categoria_Id				INT = -1
		,@Activo					BIT = NULL
		
		
		,@RegistrosPorPagina		INT = -1
		,@NumeroDePagina			INT = 1
		,@TotalDeRegistros			INT	= 0			OUTPUT		
        ,@sResSQL					VARCHAR(1000)			OUTPUT
        ,@UsuarioQueEjecuta_Id		INT
    AS
	BEGIN
    SET @sResSQL = ''
    
    DECLARE @Contexto_Id	INT
	EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT 
    	
    IF @RegistrosPorPagina = -1  -- Sin paginación
		BEGIN
			SELECT INF.id 
					,U.Apellido + N', ' + U.Nombre AS NombreDeUsuario
					,INF.Titulo 
					,CDINF.Categoria
					,INF.Texto
					,INF.FechaDe_Informe  
					,(SELECT COUNT(id) FROM AdjuntosDe_Informes WHERE Informe_Id = INF.id) AS CantidadDe_Adjuntos
					,0 AS 'TotalDeRegistros' -- Lo necesito solo p/ q NO de error.
													
			FROM Informes INF
				INNER JOIN Usuarios U ON INF.Usuario_Id = U.id
				INNER JOIN CategoriasDe_Informes CDINF on INF.Categoria_id = CDINF.id
			WHERE 
				(INF.Activo = @Activo OR @Activo IS NULL)
				AND INF.Contexto_Id = @Contexto_Id
				AND ( INF.Categoria_Id = @Categoria_Id OR @Categoria_Id = -1)
				AND
				(
					(@Filtro = '')
					OR (U.Apellido + N', ' + U.Nombre LIKE '%' + @Filtro + '%')
					OR (INF.Titulo LIKE '%' + @Filtro + '%')
					OR (INF.Texto LIKE '%' + @Filtro + '%')
				)																	
			ORDER BY CASE
				WHEN @OrdenarPor = 'FechaDe_Informe' AND @Sentido = '0' THEN RANK() OVER (ORDER BY INF.FechaDe_Informe, U.Nombre, U.Apellido)
				WHEN @OrdenarPor = 'FechaDe_Informe' AND @Sentido = '1' THEN RANK() OVER (ORDER BY INF.FechaDe_Informe DESC, U.Nombre, U.Apellido)  
				WHEN @OrdenarPor = 'Titulo' AND @Sentido = '0' THEN RANK() OVER (ORDER BY INF.Titulo,  U.Nombre, U.Apellido)
				WHEN @OrdenarPor = 'Titulo' AND @Sentido = '1' THEN RANK() OVER (ORDER BY INF.Titulo DESC,  U.Nombre, U.Apellido)  
				WHEN @OrdenarPor = 'Autor' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U.Nombre, U.Apellido, INF.FechaDe_Informe)
				WHEN @OrdenarPor = 'Autor' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U.Nombre DESC, U.Apellido DESC, INF.FechaDe_Informe)
			END	
			 
		END
    ELSE
		BEGIN
			SELECT * INTO #TempTable
			FROM
			(
			   SELECT INF.id 
						,U.Apellido + N', ' + U.Nombre AS NombreDeUsuario
						,INF.Titulo 
						,CDINF.Categoria
						,INF.Texto
						,INF.FechaDe_Informe  
						,(SELECT COUNT(id) FROM AdjuntosDe_Informes WHERE Informe_Id = INF.id) AS CantidadDe_Adjuntos
						,ROW_NUMBER() OVER 
							(
								ORDER BY 
								CASE WHEN @OrdenarPor = 'FechaDe_Informe' AND @Sentido = '0' THEN  INF.FechaDe_Informe END
								,CASE WHEN @OrdenarPor = 'FechaDe_Informe' AND @Sentido = '1' THEN  INF.FechaDe_Informe END DESC
								,CASE WHEN @OrdenarPor = 'Titulo' AND @Sentido = '0' THEN  INF.Titulo END
								,CASE WHEN @OrdenarPor = 'Titulo' AND @Sentido = '1' THEN  INF.Titulo END DESC
								,CASE WHEN @OrdenarPor = 'Autor' AND @Sentido = '0' THEN  U.Apellido END
								,CASE WHEN @OrdenarPor = 'Autor' AND @Sentido = '1' THEN  U.Apellido END DESC
							) 
						AS NumeroDeRegistro
													
				FROM Informes INF
					INNER JOIN Usuarios U ON INF.Usuario_Id = U.id
					INNER JOIN CategoriasDe_Informes CDINF on INF.Categoria_id = CDINF.id
				WHERE 
					(INF.Activo = @Activo OR @Activo IS NULL)
					AND INF.Contexto_Id = @Contexto_Id
					AND ( INF.Categoria_Id = @Categoria_Id OR @Categoria_Id = -1)
					AND
					(
						(@Filtro = '')
						OR (U.Apellido + N', ' + U.Nombre LIKE '%' + @Filtro + '%')
						OR (INF.Titulo LIKE '%' + @Filtro + '%')
						OR (INF.Texto LIKE '%' + @Filtro + '%')
					)
			) Query
	
			SELECT	id
					,NombreDeUsuario
					,Titulo
					,Categoria
					,Texto
					,FechaDe_Informe
					,CantidadDe_Adjuntos
					,(SELECT MAX(NumeroDeRegistro) FROM #TempTable) AS 'TotalDeRegistros'
			 
			FROM  #TempTable
			WHERE NumeroDeRegistro BETWEEN ((@NumeroDePagina - 1) * @RegistrosPorPagina) + 1
											AND @RegistrosPorPagina * (@NumeroDePagina)
		
			SET @TotalDeRegistros = (SELECT	COUNT(*) FROM  #TempTable)
			
			DROP TABLE #TempTable
		END
    END
GO

-- SP-TABLA: Informes - FIN




-- SP-TABLA: LogErrores - INICIO, -- 16
IF (OBJECT_ID('usp_LogErrores___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_LogErrores___listado_cFiltros
GO
CREATE PROCEDURE usp_LogErrores___listado_cFiltros 
		@UsuarioQueEjecuta_Id			INT
		
		,@OrdenarPor					VARCHAR(50)	
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		SET @sResSQL = ''
		SELECT LERR.id
			,U.LogonName
			,LERR.FechaDeEjecucion
			,T.Nombre AS Tabla 
			,PAG.Nombre AS Pagina
			,TDLERR.Nombre AS TipoDe_LogError
			,EDLERR.Nombre AS EstadoDe_LogError 
			,LERR.Modulo 
			,LERR.Metodo 
			,LERR.Mensaje 
			,LERR.Observaciones
			
			
		FROM LogErrores LERR
			INNER JOIN Tablas T ON LERR.Tabla_Id = T.id
			INNER JOIN Paginas PAG ON LERR.Pagina_Id = PAG.id
			INNER JOIN TiposDeLogErrores TDLERR ON LERR.TipoDe_LogError_Id = TDLERR.id
			INNER JOIN EstadosDeLogErrores EDLERR ON LERR.EstadoDe_LogError_Id = EDLERR.id
			INNER JOIN Usuarios U ON LERR.UsuarioQueEjecuta_Id = U.id
		WHERE 
			(
				(@Filtro = '')
				OR (T.Nombre LIKE '%' + @Filtro + '%')
				OR (PAG.Nombre LIKE '%' + @Filtro + '%')
				OR (TDLERR.Nombre LIKE '%' + @Filtro + '%')
				OR (EDLERR.Nombre LIKE '%' + @Filtro + '%')
				OR (LERR.Modulo LIKE '%' + @Filtro + '%')
				OR (LERR.Metodo LIKE '%' + @Filtro + '%')
				OR (LERR.Mensaje LIKE '%' + @Filtro + '%')
				OR (LERR.Observaciones LIKE '%' + @Filtro + '%')
			)
		ORDER BY CASE 
			WHEN @OrdenarPor = 'Fecha de ejecución' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LERR.FechaDeEjecucion, U.LogonName, T.Nombre, PAG.Nombre)  
			WHEN @OrdenarPor = 'Fecha de ejecución' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LERR.FechaDeEjecucion DESC, U.LogonName DESC, T.Nombre DESC, PAG.Nombre DESC)
			WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U.LogonName, LERR.FechaDeEjecucion, T.Nombre, PAG.Nombre)  
			WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U.LogonName DESC, LERR.FechaDeEjecucion DESC, T.Nombre DESC, PAG.Nombre DESC)
			WHEN @OrdenarPor = 'Tabla' AND @Sentido = '0' THEN RANK() OVER (ORDER BY T.Nombre, LERR.FechaDeEjecucion, U.LogonName, PAG.Nombre)  
			WHEN @OrdenarPor = 'Tabla' AND @Sentido = '1' THEN RANK() OVER (ORDER BY T.Nombre DESC, LERR.FechaDeEjecucion DESC, U.LogonName DESC, PAG.Nombre DESC)
			WHEN @OrdenarPor = 'Página' AND @Sentido = '0' THEN RANK() OVER (ORDER BY PAG.Nombre, LERR.FechaDeEjecucion, U.LogonName, T.Nombre)  
			WHEN @OrdenarPor = 'Página' AND @Sentido = '1' THEN RANK() OVER (ORDER BY PAG.Nombre DESC, LERR.FechaDeEjecucion DESC, U.LogonName DESC, T.Nombre DESC)
			WHEN @OrdenarPor = 'Tipo de Error' AND @Sentido = '0' THEN RANK() OVER (ORDER BY TDLERR.Nombre, LERR.FechaDeEjecucion, U.LogonName, T.Nombre, PAG.Nombre)  
			WHEN @OrdenarPor = 'Tipo de Error' AND @Sentido = '1' THEN RANK() OVER (ORDER BY TDLERR.Nombre DESC)
			WHEN @OrdenarPor = 'Estado del Error' AND @Sentido = '0' THEN RANK() OVER (ORDER BY EDLERR.Nombre, LERR.FechaDeEjecucion, U.LogonName, T.Nombre, PAG.Nombre)  
			WHEN @OrdenarPor = 'Estado del Error' AND @Sentido = '1' THEN RANK() OVER (ORDER BY EDLERR.Nombre DESC, LERR.FechaDeEjecucion DESC, U.LogonName DESC, T.Nombre DESC, PAG.Nombre DESC)
			WHEN @OrdenarPor = 'Módulo' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LERR.Modulo, LERR.FechaDeEjecucion, U.LogonName, T.Nombre, PAG.Nombre)  
			WHEN @OrdenarPor = 'Módulo' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LERR.Modulo DESC, LERR.FechaDeEjecucion DESC, U.LogonName DESC, T.Nombre DESC, PAG.Nombre DESC)
			WHEN @OrdenarPor = 'Método' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LERR.Metodo, LERR.FechaDeEjecucion, U.LogonName, T.Nombre, PAG.Nombre)  
			WHEN @OrdenarPor = 'Método' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LERR.Metodo DESC, LERR.FechaDeEjecucion DESC, U.LogonName DESC, T.Nombre DESC, PAG.Nombre DESC)
			WHEN @OrdenarPor = 'Mensaje' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LERR.Mensaje, LERR.FechaDeEjecucion, U.LogonName, T.Nombre, PAG.Nombre)  
			WHEN @OrdenarPor = 'Mensaje' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LERR.Mensaje DESC, LERR.FechaDeEjecucion DESC, U.LogonName DESC, T.Nombre DESC, PAG.Nombre DESC)
			WHEN @OrdenarPor = 'Observaciones' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LERR.Observaciones)  
			WHEN @OrdenarPor = 'Observaciones' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LERR.Observaciones DESC)
			WHEN 1=1 THEN RANK() OVER (ORDER BY T.Nombre) END -- CASE ELSE
	END
GO




IF (OBJECT_ID('usp_LogErrores___listado_cFiltros_cPag') IS NOT NULL) DROP PROCEDURE usp_LogErrores___listado_cFiltros_cPag
GO
CREATE PROCEDURE usp_LogErrores___listado_cFiltros_cPag
		@OrdenarPor						VARCHAR(50)
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		
		,@Activo						BIT = NULL
		
		,@RegistrosPorPagina			INT = -1
		,@NumeroDePagina				INT = 1
		,@TotalDeRegistros				INT	= 0			OUTPUT		

        ,@sResSQL						VARCHAR(1000)	OUTPUT
        ,@UsuarioQueEjecuta_Id			INT
    AS
	BEGIN
    SET @sResSQL = ''
    	IF @RegistrosPorPagina = -1  -- Sin paginación
			BEGIN
				
				SELECT LERR.id
					,U.LogonName
					,LERR.FechaDeEjecucion
					,T.Nombre AS Tabla 
					,PAG.Nombre AS Pagina
					,TDLERR.Nombre AS TipoDe_LogError
					,EDLERR.Nombre AS EstadoDe_LogError 
					,LERR.Modulo 
					,LERR.Metodo 
					,LERR.Mensaje 
					,LERR.Observaciones
					,0 AS 'TotalDeRegistros'
					--,Activo
									
				FROM LogErrores LERR
					INNER JOIN Tablas T ON LERR.Tabla_Id = T.id
					INNER JOIN Paginas PAG ON LERR.Pagina_Id = PAG.id
					INNER JOIN TiposDeLogErrores TDLERR ON LERR.TipoDe_LogError_Id = TDLERR.id
					INNER JOIN EstadosDeLogErrores EDLERR ON LERR.EstadoDe_LogError_Id = EDLERR.id
					INNER JOIN Usuarios U ON LERR.UsuarioQueEjecuta_Id = U.id
				WHERE 
					(
						(@Filtro = '')
						OR (T.Nombre LIKE '%' + @Filtro + '%')
						OR (PAG.Nombre LIKE '%' + @Filtro + '%')
						OR (TDLERR.Nombre LIKE '%' + @Filtro + '%')
						OR (EDLERR.Nombre LIKE '%' + @Filtro + '%')
						OR (LERR.Modulo LIKE '%' + @Filtro + '%')
						OR (LERR.Metodo LIKE '%' + @Filtro + '%')
						OR (LERR.Mensaje LIKE '%' + @Filtro + '%')
						OR (LERR.Observaciones LIKE '%' + @Filtro + '%')
					)
				ORDER BY CASE 
					WHEN @OrdenarPor = 'Fecha de ejecución' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LERR.FechaDeEjecucion, U.LogonName, T.Nombre, PAG.Nombre)  
					WHEN @OrdenarPor = 'Fecha de ejecución' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LERR.FechaDeEjecucion DESC, U.LogonName DESC, T.Nombre DESC, PAG.Nombre DESC)
					WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U.LogonName, LERR.FechaDeEjecucion, T.Nombre, PAG.Nombre)  
					WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U.LogonName DESC, LERR.FechaDeEjecucion DESC, T.Nombre DESC, PAG.Nombre DESC)
					WHEN @OrdenarPor = 'Tabla' AND @Sentido = '0' THEN RANK() OVER (ORDER BY T.Nombre, LERR.FechaDeEjecucion, U.LogonName, PAG.Nombre)  
					WHEN @OrdenarPor = 'Tabla' AND @Sentido = '1' THEN RANK() OVER (ORDER BY T.Nombre DESC, LERR.FechaDeEjecucion DESC, U.LogonName DESC, PAG.Nombre DESC)
					WHEN @OrdenarPor = 'Página' AND @Sentido = '0' THEN RANK() OVER (ORDER BY PAG.Nombre, LERR.FechaDeEjecucion, U.LogonName, T.Nombre)  
					WHEN @OrdenarPor = 'Página' AND @Sentido = '1' THEN RANK() OVER (ORDER BY PAG.Nombre DESC, LERR.FechaDeEjecucion DESC, U.LogonName DESC, T.Nombre DESC)
					WHEN @OrdenarPor = 'Tipo de Error' AND @Sentido = '0' THEN RANK() OVER (ORDER BY TDLERR.Nombre, LERR.FechaDeEjecucion, U.LogonName, T.Nombre, PAG.Nombre)  
					WHEN @OrdenarPor = 'Tipo de Error' AND @Sentido = '1' THEN RANK() OVER (ORDER BY TDLERR.Nombre DESC)
					WHEN @OrdenarPor = 'Estado del Error' AND @Sentido = '0' THEN RANK() OVER (ORDER BY EDLERR.Nombre, LERR.FechaDeEjecucion, U.LogonName, T.Nombre, PAG.Nombre)  
					WHEN @OrdenarPor = 'Estado del Error' AND @Sentido = '1' THEN RANK() OVER (ORDER BY EDLERR.Nombre DESC, LERR.FechaDeEjecucion DESC, U.LogonName DESC, T.Nombre DESC, PAG.Nombre DESC)
					WHEN @OrdenarPor = 'Módulo' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LERR.Modulo, LERR.FechaDeEjecucion, U.LogonName, T.Nombre, PAG.Nombre)  
					WHEN @OrdenarPor = 'Módulo' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LERR.Modulo DESC, LERR.FechaDeEjecucion DESC, U.LogonName DESC, T.Nombre DESC, PAG.Nombre DESC)
					WHEN @OrdenarPor = 'Método' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LERR.Metodo, LERR.FechaDeEjecucion, U.LogonName, T.Nombre, PAG.Nombre)  
					WHEN @OrdenarPor = 'Método' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LERR.Metodo DESC, LERR.FechaDeEjecucion DESC, U.LogonName DESC, T.Nombre DESC, PAG.Nombre DESC)
					WHEN @OrdenarPor = 'Mensaje' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LERR.Mensaje, LERR.FechaDeEjecucion, U.LogonName, T.Nombre, PAG.Nombre)  
					WHEN @OrdenarPor = 'Mensaje' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LERR.Mensaje DESC, LERR.FechaDeEjecucion DESC, U.LogonName DESC, T.Nombre DESC, PAG.Nombre DESC)
					WHEN @OrdenarPor = 'Observaciones' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LERR.Observaciones)  
					WHEN @OrdenarPor = 'Observaciones' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LERR.Observaciones DESC)
					WHEN 1=1 THEN RANK() OVER (ORDER BY T.Nombre) END -- CASE ELSE
			END
		ELSE
			BEGIN
				WITH YourCTE AS 
				(
					SELECT LERR.id
							,U.LogonName
							,LERR.FechaDeEjecucion
							,T.Nombre AS Tabla 
							,PAG.Nombre AS Pagina
							,TDLERR.Nombre AS TipoDe_LogError
							,EDLERR.Nombre AS EstadoDe_LogError 
							,LERR.Modulo 
							,LERR.Metodo 
							,LERR.Mensaje 
							,LERR.Observaciones
							,ROW_NUMBER() OVER 
							(
								-- VER QUE PARA PONER VARIOS CAMPOS --> VARIAS LINEAS CON EL MISMO WHEN
								ORDER BY  
									CASE WHEN @OrdenarPor = 'Fecha de ejecución' AND @Sentido = '0' THEN LERR.FechaDeEjecucion END
										,CASE WHEN @OrdenarPor = 'Fecha de ejecución' AND @Sentido = '0' THEN U.LogonName END
										,CASE WHEN @OrdenarPor = 'Fecha de ejecución' AND @Sentido = '0' THEN T.Nombre END
										,CASE WHEN @OrdenarPor = 'Fecha de ejecución' AND @Sentido = '0' THEN PAG.Nombre END
									,CASE WHEN @OrdenarPor = 'Fecha de ejecución' AND @Sentido = '1' THEN LERR.FechaDeEjecucion END DESC
										,CASE WHEN @OrdenarPor = 'Fecha de ejecución' AND @Sentido = '1' THEN U.LogonName END DESC
										,CASE WHEN @OrdenarPor = 'Fecha de ejecución' AND @Sentido = '1' THEN T.Nombre END DESC
										,CASE WHEN @OrdenarPor = 'Fecha de ejecución' AND @Sentido = '1' THEN PAG.Nombre END DESC
									
									,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN U.LogonName END
										,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN LERR.FechaDeEjecucion END
										,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN T.Nombre END
										,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN PAG.Nombre END
									,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN U.LogonName END DESC
										,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN LERR.FechaDeEjecucion END DESC
										,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN T.Nombre END DESC
										,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN PAG.Nombre END DESC
										
									,CASE WHEN @OrdenarPor = 'Tabla' AND @Sentido = '0' THEN T.Nombre END
										,CASE WHEN @OrdenarPor = 'Tabla' AND @Sentido = '0' THEN LERR.FechaDeEjecucion END
										,CASE WHEN @OrdenarPor = 'Tabla' AND @Sentido = '0' THEN U.LogonName END
										,CASE WHEN @OrdenarPor = 'Tabla' AND @Sentido = '0' THEN PAG.Nombre END
									,CASE WHEN @OrdenarPor = 'Tabla' AND @Sentido = '1' THEN T.Nombre END DESC
										,CASE WHEN @OrdenarPor = 'Tabla' AND @Sentido = '1' THEN LERR.FechaDeEjecucion END DESC
										,CASE WHEN @OrdenarPor = 'Tabla' AND @Sentido = '1' THEN U.LogonName END DESC
										,CASE WHEN @OrdenarPor = 'Tabla' AND @Sentido = '1' THEN PAG.Nombre END DESC
										
									,CASE WHEN @OrdenarPor = 'Página' AND @Sentido = '0' THEN PAG.Nombre END
										,CASE WHEN @OrdenarPor = 'Página' AND @Sentido = '0' THEN LERR.FechaDeEjecucion END
										,CASE WHEN @OrdenarPor = 'Página' AND @Sentido = '0' THEN U.LogonName END
										,CASE WHEN @OrdenarPor = 'Página' AND @Sentido = '0' THEN T.Nombre END
									,CASE WHEN @OrdenarPor = 'Página' AND @Sentido = '1' THEN PAG.Nombre END DESC
										,CASE WHEN @OrdenarPor = 'Página' AND @Sentido = '1' THEN LERR.FechaDeEjecucion END DESC
										,CASE WHEN @OrdenarPor = 'Página' AND @Sentido = '1' THEN U.LogonName END DESC
										,CASE WHEN @OrdenarPor = 'Página' AND @Sentido = '1' THEN T.Nombre END DESC
										
							) AS NumeroDeRegistro
					
					FROM LogErrores LERR
						INNER JOIN Tablas T ON LERR.Tabla_Id = T.id
						INNER JOIN Paginas PAG ON LERR.Pagina_Id = PAG.id
						INNER JOIN TiposDeLogErrores TDLERR ON LERR.TipoDe_LogError_Id = TDLERR.id
						INNER JOIN EstadosDeLogErrores EDLERR ON LERR.EstadoDe_LogError_Id = EDLERR.id
						INNER JOIN Usuarios U ON LERR.UsuarioQueEjecuta_Id = U.id
					WHERE 
						(
							(@Filtro = '')
							OR (T.Nombre LIKE '%' + @Filtro + '%')
							OR (PAG.Nombre LIKE '%' + @Filtro + '%')
							OR (TDLERR.Nombre LIKE '%' + @Filtro + '%')
							OR (EDLERR.Nombre LIKE '%' + @Filtro + '%')
							OR (LERR.Modulo LIKE '%' + @Filtro + '%')
							OR (LERR.Metodo LIKE '%' + @Filtro + '%')
							OR (LERR.Mensaje LIKE '%' + @Filtro + '%')
							OR (LERR.Observaciones LIKE '%' + @Filtro + '%')
						)
				)
				SELECT	id
						,LogonName
						,FechaDeEjecucion
						,Tabla 
						,Pagina
						,TipoDe_LogError
						,EstadoDe_LogError 
						,Modulo 
						,Metodo 
						,Mensaje 
						,Observaciones
						,(SELECT MAX(NumeroDeRegistro) FROM YourCTE) AS 'TotalDeRegistros'
				 
				FROM  YourCTE
				WHERE NumeroDeRegistro BETWEEN ((@NumeroDePagina - 1) * @RegistrosPorPagina) + 1 AND @RegistrosPorPagina * (@NumeroDePagina)
			END
		--ENDIF
    END
GO
-- SP-TABLA: LogErrores - FIN




-- SP-TABLA: LogLogins - INICIO, -- 17
IF (OBJECT_ID('usp_LogLogins___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_LogLogins___listado_cFiltros
GO
CREATE PROCEDURE usp_LogLogins___listado_cFiltros 
		@UsuarioQueEjecuta_Id			INT
		
		,@OrdenarPor					VARCHAR(50)
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		SET @sResSQL = ''
		SELECT LLOG.id
			,LLOG.Fecha
			,U.LogonName AS LogonName
			,LLOG.UserName AS Nombre_Ingresado
			,TDLLOG.Nombre AS TipoDe_LogLogin
			
		FROM LogLogins LLOG
			INNER JOIN TiposDeLogLogins TDLLOG ON LLOG.TipoDe_LogLogin_Id = TDLLOG.id
			INNER JOIN Usuarios U ON LLOG.Usuario_Id = U.id
		WHERE
			(
				(@Filtro = '')
				OR (LLOG.Fecha LIKE '%' + @Filtro + '%')
				OR (U.LogonName LIKE '%' + @Filtro + '%')
				OR (TDLLOG.Nombre LIKE '%' + @Filtro + '%')
			)

		ORDER BY CASE 
			WHEN @OrdenarPor = 'Fecha' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LLOG.Fecha, U.LogonName, TDLLOG.Nombre)  
			WHEN @OrdenarPor = 'Fecha' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LLOG.Fecha DESC, U.LogonName DESC, TDLLOG.Nombre DESC)
			WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U.LogonName, LLOG.Fecha, TDLLOG.Nombre)  
			WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U.LogonName DESC, LLOG.Fecha DESC, TDLLOG.Nombre DESC)
			WHEN @OrdenarPor = 'Nombre Ingresado' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LLOG.UserName, LLOG.Fecha, TDLLOG.Nombre)  
			WHEN @OrdenarPor = 'Nombre Ingresado' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LLOG.UserName DESC, LLOG.Fecha DESC, TDLLOG.Nombre DESC)
			WHEN @OrdenarPor = 'Tipo de Log' AND @Sentido = '0' THEN RANK() OVER (ORDER BY TDLLOG.Nombre, LLOG.Fecha, U.LogonName)  
			WHEN @OrdenarPor = 'Tipo de Log' AND @Sentido = '1' THEN RANK() OVER (ORDER BY TDLLOG.Nombre DESC, LLOG.Fecha DESC, U.LogonName DESC)
			WHEN 1=1 THEN RANK() OVER (ORDER BY LLOG.Fecha) END -- CASE ELSE
	END
GO




IF (OBJECT_ID('usp_LogLogins___listado_cFiltros_by_@Usuario_Id') IS NOT NULL) DROP PROCEDURE usp_LogLogins___listado_cFiltros_by_@Usuario_Id
GO
CREATE PROCEDURE usp_LogLogins___listado_cFiltros_by_@Usuario_Id
		@UsuarioQueEjecuta_Id			INT
		
		,@OrdenarPor					VARCHAR(50)	
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
		
		,@Usuario_Id					INT
	AS
	BEGIN
		SET @sResSQL = ''

		SELECT LLOG.id
			,LLOG.Fecha
			,U.LogonName AS LogonName
			,LLOG.UserName AS Nombre_Ingresado
			,TDLLOG.Nombre AS TipoDe_LogLogin
			
		FROM LogLogins LLOG
			INNER JOIN TiposDeLogLogins TDLLOG ON LLOG.TipoDe_LogLogin_Id = TDLLOG.id
			INNER JOIN Usuarios U ON LLOG.Usuario_Id = U.id
		WHERE
			(
				(@Filtro = '')
				OR (LLOG.Fecha LIKE '%' + @Filtro + '%')
				OR (U.LogonName LIKE '%' + @Filtro + '%')
				OR (TDLLOG.Nombre LIKE '%' + @Filtro + '%')
			)
			AND
			(
				@Usuario_Id = '-1' OR LLOG.Usuario_Id = @Usuario_Id
			)

		ORDER BY CASE 
			WHEN @OrdenarPor = 'Fecha' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LLOG.Fecha, U.LogonName, TDLLOG.Nombre)  
			WHEN @OrdenarPor = 'Fecha' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LLOG.Fecha DESC, U.LogonName DESC, TDLLOG.Nombre DESC)
			WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U.LogonName, LLOG.Fecha, TDLLOG.Nombre)  
			WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U.LogonName DESC, LLOG.Fecha DESC, TDLLOG.Nombre DESC)
			WHEN @OrdenarPor = 'Nombre Ingresado' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LLOG.UserName, LLOG.Fecha, TDLLOG.Nombre)  
			WHEN @OrdenarPor = 'Nombre Ingresado' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LLOG.UserName DESC, LLOG.Fecha DESC, TDLLOG.Nombre DESC)
			WHEN @OrdenarPor = 'Tipo de Log' AND @Sentido = '0' THEN RANK() OVER (ORDER BY TDLLOG.Nombre, LLOG.Fecha, U.LogonName)  
			WHEN @OrdenarPor = 'Tipo de Log' AND @Sentido = '1' THEN RANK() OVER (ORDER BY TDLLOG.Nombre DESC, LLOG.Fecha DESC, U.LogonName DESC)
			WHEN 1=1 THEN RANK() OVER (ORDER BY LLOG.Fecha) END -- CASE ELSE
	END
GO




IF (OBJECT_ID('usp_LogLogins___listado_cFiltros_cPag') IS NOT NULL) DROP PROCEDURE usp_LogLogins___listado_cFiltros_cPag
GO
CREATE PROCEDURE usp_LogLogins___listado_cFiltros_cPag
		@OrdenarPor						VARCHAR(50)
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		
		,@Activo						BIT = NULL
		,@Usuario_Id					INT
		
		,@RegistrosPorPagina			INT = -1
		,@NumeroDePagina				INT = 1
		,@TotalDeRegistros				INT	= 0			OUTPUT		

        ,@sResSQL						VARCHAR(1000)	OUTPUT
        ,@UsuarioQueEjecuta_Id			INT
    AS
	BEGIN
    SET @sResSQL = ''
    	IF @RegistrosPorPagina = -1  -- Sin paginación
			BEGIN
				
				SELECT LLOG.id
					,LLOG.Fecha
					,U.LogonName AS LogonName
					,LLOG.UserName AS Nombre_Ingresado
					,TDLLOG.Nombre AS TipoDe_LogLogin
					,0 AS 'TotalDeRegistros'
					--,Activo
									
				FROM LogLogins LLOG
					INNER JOIN TiposDeLogLogins TDLLOG ON LLOG.TipoDe_LogLogin_Id = TDLLOG.id
					INNER JOIN Usuarios U ON LLOG.Usuario_Id = U.id
				WHERE
					(
						(@Filtro = '')
						OR (LLOG.Fecha LIKE '%' + @Filtro + '%')
						OR (U.LogonName LIKE '%' + @Filtro + '%')
						OR (TDLLOG.Nombre LIKE '%' + @Filtro + '%')
					)
					AND
					(
						@Usuario_Id = '-1' OR LLOG.Usuario_Id = @Usuario_Id
					)

				ORDER BY CASE 
					WHEN @OrdenarPor = 'Fecha' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LLOG.Fecha, U.LogonName, TDLLOG.Nombre)  
					WHEN @OrdenarPor = 'Fecha' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LLOG.Fecha DESC, U.LogonName DESC, TDLLOG.Nombre DESC)
					WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U.LogonName, LLOG.Fecha, TDLLOG.Nombre)  
					WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U.LogonName DESC, LLOG.Fecha DESC, TDLLOG.Nombre DESC)
					WHEN @OrdenarPor = 'Nombre Ingresado' AND @Sentido = '0' THEN RANK() OVER (ORDER BY LLOG.UserName, LLOG.Fecha, TDLLOG.Nombre)  
					WHEN @OrdenarPor = 'Nombre Ingresado' AND @Sentido = '1' THEN RANK() OVER (ORDER BY LLOG.UserName DESC, LLOG.Fecha DESC, TDLLOG.Nombre DESC)
					WHEN @OrdenarPor = 'Tipo de Log' AND @Sentido = '0' THEN RANK() OVER (ORDER BY TDLLOG.Nombre, LLOG.Fecha, U.LogonName)  
					WHEN @OrdenarPor = 'Tipo de Log' AND @Sentido = '1' THEN RANK() OVER (ORDER BY TDLLOG.Nombre DESC, LLOG.Fecha DESC, U.LogonName DESC)
					WHEN 1=1 THEN RANK() OVER (ORDER BY LLOG.Fecha) END -- CASE ELSE
			END
		ELSE
			BEGIN
				WITH YourCTE AS 
				(
					SELECT LLOG.id
							,LLOG.Fecha
							,U.LogonName AS LogonName
							,LLOG.UserName AS Nombre_Ingresado
							,TDLLOG.Nombre AS TipoDe_LogLogin
							,ROW_NUMBER() OVER 
							(
								-- VER QUE PARA PONER VARIOS CAMPOS --> VARIAS LINEAS CON EL MISMO WHEN
								ORDER BY  
									CASE WHEN @OrdenarPor = 'Fecha' AND @Sentido = '0' THEN LLOG.Fecha END
										,CASE WHEN @OrdenarPor = 'Fecha' AND @Sentido = '0' THEN U.LogonName END
										,CASE WHEN @OrdenarPor = 'Fecha' AND @Sentido = '0' THEN TDLLOG.Nombre END
									,CASE WHEN @OrdenarPor = 'Fecha' AND @Sentido = '1' THEN LLOG.Fecha END DESC
										,CASE WHEN @OrdenarPor = 'Fecha' AND @Sentido = '1' THEN U.LogonName END DESC
										,CASE WHEN @OrdenarPor = 'Fecha' AND @Sentido = '1' THEN TDLLOG.Nombre END DESC
									
									,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN U.LogonName END
										,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN LLOG.Fecha END
										,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN TDLLOG.Nombre END
									,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN U.LogonName END DESC
										,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN LLOG.Fecha END DESC
										,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN TDLLOG.Nombre END DESC
										
									,CASE WHEN @OrdenarPor = 'Nombre Ingresado' AND @Sentido = '0' THEN LLOG.UserName END
										,CASE WHEN @OrdenarPor = 'Nombre Ingresado' AND @Sentido = '0' THEN LLOG.Fecha END
										,CASE WHEN @OrdenarPor = 'Nombre Ingresado' AND @Sentido = '0' THEN TDLLOG.Nombre END
									,CASE WHEN @OrdenarPor = 'Nombre Ingresado' AND @Sentido = '1' THEN LLOG.UserName END DESC
										,CASE WHEN @OrdenarPor = 'Nombre Ingresado' AND @Sentido = '1' THEN LLOG.Fecha END DESC
										,CASE WHEN @OrdenarPor = 'Nombre Ingresado' AND @Sentido = '1' THEN TDLLOG.Nombre END DESC
										
									,CASE WHEN @OrdenarPor = 'Tipo de Log' AND @Sentido = '0' THEN TDLLOG.Nombre END
										,CASE WHEN @OrdenarPor = 'Tipo de Log' AND @Sentido = '0' THEN LLOG.Fecha END
										,CASE WHEN @OrdenarPor = 'Tipo de Log' AND @Sentido = '0' THEN U.LogonName END
									,CASE WHEN @OrdenarPor = 'Tipo de Log' AND @Sentido = '1' THEN TDLLOG.Nombre END DESC
										,CASE WHEN @OrdenarPor = 'Tipo de Log' AND @Sentido = '1' THEN LLOG.Fecha END DESC
										,CASE WHEN @OrdenarPor = 'Tipo de Log' AND @Sentido = '1' THEN U.LogonName END DESC
										
										
							) AS NumeroDeRegistro
					
					FROM LogLogins LLOG
						INNER JOIN TiposDeLogLogins TDLLOG ON LLOG.TipoDe_LogLogin_Id = TDLLOG.id
						INNER JOIN Usuarios U ON LLOG.Usuario_Id = U.id
					WHERE
						(
							(@Filtro = '')
							OR (LLOG.Fecha LIKE '%' + @Filtro + '%')
							OR (U.LogonName LIKE '%' + @Filtro + '%')
							OR (TDLLOG.Nombre LIKE '%' + @Filtro + '%')
						)
						AND
						(
							@Usuario_Id = '-1' OR LLOG.Usuario_Id = @Usuario_Id
						)
				)
				SELECT	id
						,Fecha
						,LogonName
						,Nombre_Ingresado
						,TipoDe_LogLogin
						,(SELECT MAX(NumeroDeRegistro) FROM YourCTE) AS 'TotalDeRegistros'
				 
				FROM  YourCTE
				WHERE NumeroDeRegistro BETWEEN ((@NumeroDePagina - 1) * @RegistrosPorPagina) + 1 AND @RegistrosPorPagina * (@NumeroDePagina)
			END
		--ENDIF
    END
GO
-- SP-TABLA: LogLogins - FIN




-- SP-TABLA: LogRegistros - INICIO, -- 19
	-- VAN EN EL SP DE LOGREGISTROS
-- SP-TABLA: LogRegistros - FIN




-- SP-TABLA: Paginas - INICIO, -- 22
IF (OBJECT_ID('usp_Paginas___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_Paginas___listado_cFiltros
GO
CREATE PROCEDURE usp_Paginas___listado_cFiltros 
		@UsuarioQueEjecuta_Id			INT
		
		,@OrdenarPor					VARCHAR(50)	
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		SET @sResSQL = ''
		SELECT id 
				,Nombre
				,Observaciones
		FROM Paginas

		WHERE 
			(Activo = 1)
			AND
			(
				((@Filtro = '')
				OR (Nombre LIKE '%' + @Filtro + '%')
				OR (Observaciones LIKE '%' + @Filtro + '%'))
			)
		ORDER BY CASE 
			WHEN @OrdenarPor = 'Nombre' AND @Sentido = '0' THEN RANK() OVER (ORDER BY Nombre)
			WHEN @OrdenarPor = 'Nombre' AND @Sentido = '1' THEN RANK() OVER (ORDER BY Nombre DESC)  
			WHEN @OrdenarPor = 'Observaciones' AND @Sentido = '0' THEN RANK() OVER (ORDER BY Observaciones)
			WHEN @OrdenarPor = 'Observaciones' AND @Sentido = '1' THEN RANK() OVER (ORDER BY Observaciones DESC)
			WHEN 1=1 THEN RANK() OVER (ORDER BY Nombre) END -- CASE ELSE
	END
GO



IF (OBJECT_ID('usp_Paginas___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_Paginas___listado_DDL_o_CBXL
GO
CREATE PROCEDURE usp_Paginas___listado_DDL_o_CBXL
		@UsuarioQueEjecuta_Id			INT
		
		,@Formato_Listado				SMALLINT = 1 
		,@Activo						BIT = 0
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		
		DECLARE @Es_MasterAdmin	VARCHAR(1000)
		EXEC	dbo.usp_VAL_Contexto_Id__by__MasterAdmin  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @Es_MasterAdmin OUTPUT
		
		SELECT	 id
				,Data 
				,-1 AS Orden
		
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
						
		UNION
		
		SELECT	id
				,Nombre	AS Data
				,ROW_NUMBER() OVER (ORDER BY Nombre) AS Orden
				
		FROM Paginas
		ORDER BY Orden
	END
GO

IF (OBJECT_ID('usp_Paginas___listado_cFiltros_cPag') IS NOT NULL) DROP PROCEDURE usp_Paginas___listado_cFiltros_cPag
GO
CREATE PROCEDURE usp_Paginas___listado_cFiltros_cPag
		@OrdenarPor						VARCHAR(50)
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		
		,@Activo						BIT = NULL
		
		,@RegistrosPorPagina			INT = -1
		,@NumeroDePagina				INT = 1
		,@TotalDeRegistros				INT	= 0			OUTPUT		

        ,@sResSQL						VARCHAR(1000)	OUTPUT
        ,@UsuarioQueEjecuta_Id			INT
    AS
	BEGIN
	--DECLARE @Contexto_Id INT
	--EXEC @Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT 
	
    SET @sResSQL = ''
	IF @RegistrosPorPagina = -1  -- Sin paginación
		BEGIN
			
			SELECT  PAG.id 
					,PAG.Nombre
					,PAG.Observaciones
					,PAG.Titulo
					,PAG.Tips
					,TAB.Nombre AS Tabla
					,FD_PAG.NombreAMostrar AS FuncionDePagina
					,0 AS 'TotalDeRegistros'
					--,Activo
			FROM Paginas PAG
			INNER JOIN Tablas TAB ON PAG.Tabla_Id = TAB.Id
			INNER JOIN FuncionesDe_Paginas FD_PAG ON PAG.FuncionDe_Pagina_Id = FD_PAG.Id
			WHERE  
				(
				(@Filtro = '')
				OR (PAG.Nombre LIKE '%' + @Filtro + '%')
				)

			ORDER BY id
		END
	ELSE
		BEGIN
			SELECT * INTO #TempTable
			FROM
			(
				SELECT  PAG.id 
						,PAG.Nombre
						,PAG.Observaciones
						,PAG.Titulo
						,PAG.Tips
						,TAB.Nombre AS Tabla
						,FD_PAG.NombreAMostrar AS FuncionDePagina
						,ROW_NUMBER() OVER 
						(
							-- VER QUE PARA PONER VARIOS CAMPOS --> VARIAS LINEAS CON EL MISMO WHEN
							ORDER BY  
								CASE WHEN @OrdenarPor = 'Nombre' AND @Sentido = '0' THEN PAG.Nombre END
								,CASE WHEN @OrdenarPor = 'Nombre' AND @Sentido = '1' THEN PAG.Nombre END DESC
									
						) AS NumeroDeRegistro
				
				FROM Paginas PAG
				INNER JOIN Tablas TAB ON PAG.Tabla_Id = TAB.Id
				INNER JOIN FuncionesDe_Paginas FD_PAG ON PAG.FuncionDe_Pagina_Id = FD_PAG.Id
				WHERE  
					(
					(@Filtro = '')
					OR (PAG.Nombre LIKE '%' + @Filtro + '%')
					)
			) Query
			SELECT	id
					,Nombre
					,Titulo
					,Tips
					,Observaciones
					,Tabla
					,FuncionDePagina
					,(SELECT MAX(NumeroDeRegistro) FROM #TempTable) AS 'TotalDeRegistros'
			 
			FROM  #TempTable
			WHERE NumeroDeRegistro BETWEEN ((@NumeroDePagina - 1) * @RegistrosPorPagina) + 1 AND @RegistrosPorPagina * (@NumeroDePagina)
			
			SET @TotalDeRegistros = (SELECT	COUNT(*) FROM  #TempTable)
			DROP TABLE #TempTable
		END
		--ENDIF
    END
GO

-- SP-TABLA: Paginas - FIN




-- SP-TABLA: Paridades - INICIO, -- 23
IF (OBJECT_ID('usp_Paridades___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_Paridades___listado_DDL_o_CBXL
GO
CREATE PROCEDURE usp_Paridades___listado_DDL_o_CBXL 
		@UsuarioQueEjecuta_Id			INT
		
		,@Formato_Listado				SMALLINT = 1
		,@Activo			BIT = 1
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		SET @sResSQL = ''
		--DECLARE @MinId AS INT
		--EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado

		--	SELECT    'Return Value' = @return_value
		--SET @MinId = (SELECT ufc_MinimoId_inDDLs(@Formato_Listado))
		
		SELECT	 Codigo
				,Data 
		
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
						
		UNION
		SELECT	Codigo
				,Nombre AS Data
				
		FROM Paridades
		--WHERE 
			--(Activo = '1')
			--AND
		ORDER BY Data
	END
GO
-- SP-TABLA: Paridades - FIN




-- SP-TABLA: Prioridades - INICIO, -- 24
IF (OBJECT_ID('usp_Prioridades___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_Prioridades___listado_DDL_o_CBXL
GO
CREATE PROCEDURE usp_Prioridades___listado_DDL_o_CBXL 
		@UsuarioQueEjecuta_Id			INT
		
		,@Formato_Listado				SMALLINT = 1
		,@Activo			BIT = 1
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		SET @sResSQL = ''
		DECLARE @MinId AS INT
		EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado

		--	SELECT    'Return Value' = @return_value
		--SET @MinId = (SELECT ufc_MinimoId_inDDLs(@Formato_Listado))
		
		SELECT	 id
				,Data 
		
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
						
		UNION
		SELECT	id
				,Nombre	AS Data
				
		FROM Prioridades
		ORDER BY id
	END
GO
-- SP-TABLA: Prioridades - FIN




-- SP-TABLA: Publicaciones - INICIO
IF (OBJECT_ID('usp_Publicaciones___listado_cFiltros_by_@Realizada') IS NOT NULL) DROP PROCEDURE usp_Publicaciones___listado_cFiltros_by_@Realizada
GO
CREATE PROCEDURE usp_Publicaciones___listado_cFiltros_by_@Realizada
		@OrdenarPor					VARCHAR(50)
		,@Sentido					BIT
		,@Filtro					VARCHAR(50)
		,@Activo					BIT = NULL
		
		,@Realizada					BIT = NULL
		
	    ,@sResSQL					VARCHAR(1000)			OUTPUT
        ,@UsuarioQueEjecuta_Id		INT
    AS
	BEGIN
    SET @sResSQL = ''
		SELECT	PUB.id
				,PUB.Fecha
				--,Activo
				,CAST(PUB.Hora AS CHAR(5)) AS Hora
				,PUB.Titulo
				,PUB.NumeroDeVersion
				--,Realizada
				,COALESCE(STUFF((SELECT ', ' + 'Nº ' + CAST(SOP.Numero AS VARCHAR)
					FROM Soporte SOP
					WHERE SOP.Publicacion_Id = PUB.id FOR XML PATH('')),1,1,''), '-') AS Soportes
				,COALESCE(STUFF((SELECT ', ' + SS.Nombre
					FROM RelAsig__Subsistemas__A__Publicaciones RASaP
						INNER JOIN SubSistemas SS ON RASaP.Subsistema_Id = SS.id
					WHERE RASaP.Publicacion_Id = PUB.id FOR XML PATH('')),1,1,''), '-') AS SubSistemas
					
				,N'images/cbx/img_' + convert(varchar(5), Realizada) + N'.jpg' AS imgRealizada
				--,CAST(PUB.Observaciones AS VARCHAR(80)) + N' ...' AS Observaciones_Cortadas
				,PUB.Observaciones
								
		FROM Publicaciones PUB
		WHERE 
			(PUB.Realizada = @Realizada OR @Realizada IS NULL)
		--	AND
		--	(
		--		(@Filtro = '')
		--		OR (Nombre LIKE '%' + @Filtro + '%')
		--	)
		ORDER BY CASE 
			WHEN @OrdenarPor = 'Fecha' AND @Sentido = '0' THEN RANK() OVER (ORDER BY Fecha, Hora)
			WHEN @OrdenarPor = 'Fecha' AND @Sentido = '1' THEN RANK() OVER (ORDER BY Fecha DESC, Hora DESC)
			END	
	END
GO
-- SP-TABLA: Publicaciones - FIN




-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Paginas - INICIO, -- 25
IF (OBJECT_ID('usp_RelAsig__RolesDeUsuarios__A__Paginas___listado_by_@Pagina_Id') IS NOT NULL) DROP PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Paginas___listado_by_@Pagina_Id
GO
CREATE PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Paginas___listado_by_@Pagina_Id 
		@UsuarioQueEjecuta_Id			INT
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
		
		,@Pagina_Id						INT
	AS
	BEGIN
		SET @sResSQL = ''
		SELECT	RPRP.id 
				,RPRP.Pagina_Id 
				,RPRP.RolDe_Usuario_Id 
				,RPRP.AutorizadoACargarLaPagina
				,RPRP.AutorizadoAOperarLaPagina
				,RPRP.AutorizadoAVerRegAnulados
				,RPRP.AutorizadoAOperacionesSecundarias
			
		FROM RelAsig__RolesDeUsuarios__A__Paginas RPRP
			INNER JOIN Paginas PAG ON RPRP.Pagina_Id = PAG.id
		WHERE PAG.id = @Pagina_Id
		ORDER BY PAG.Nombre 
	END
GO




IF (OBJECT_ID('usp_RelAsig__RolesDeUsuarios__A__Paginas___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Paginas___listado_cFiltros
GO
CREATE PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Paginas___listado_cFiltros
		@UsuarioQueEjecuta_Id			INT
		
		,@OrdenarPor					VARCHAR(50)	
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		
		,@RolDe_Usuario_Id				INT = -1
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
	
		--DECLARE @Es_MasterAdmin	BIT
		--EXEC	@Es_MasterAdmin = dbo.[ufc_UsuarioEs_MasterAdmin]  @Usuario_Id = @UsuarioQueEjecuta_Id
		
		-- ME PARECE MEJOR LISTAR TODO, ES SOLO UN LISTADO, QUE PUEDE SERVIR PARA ENTENDER Q PERMISOS TENGO
		
		SELECT RPRP.id 
				,RDU.Nombre AS RolDeUsuario
				,PAG.Nombre AS Pagina
				,N'images/cbx/img_' + convert(varchar(5), RPRP.AutorizadoACargarLaPagina) + N'.jpg' AS imgTrueFalse_AutorizadoACargarLaPagina
				,N'images/cbx/img_' + convert(varchar(5), RPRP.AutorizadoAOperarLaPagina) + N'.jpg' AS imgTrueFalse_AutorizadoAOperarLaPagina
				,N'images/cbx/img_' + convert(varchar(5), RPRP.AutorizadoAVerRegAnulados) + N'.jpg' AS imgTrueFalse_AutorizadoAVerRegAnulados
				,N'images/cbx/img_' + convert(varchar(5), RPRP.AutorizadoAOperacionesSecundarias) + N'.jpg' AS imgTrueFalse_AutorizadoAOperacionesSecundarias
								
		FROM RelAsig__RolesDeUsuarios__A__Paginas RPRP
			INNER JOIN RolesDeUsuarios RDU ON RPRP.RolDe_Usuario_Id = RDU.id
			INNER JOIN Paginas PAG ON RPRP.Pagina_Id = PAG.id
		WHERE 
			--(
			--	RDU.id NOT IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_ExclusionesDe_RolesDeUsuarios))
			--) 
			--AND
			(
				(@Filtro = '')
				OR (RDU.Nombre LIKE '%' + @Filtro + '%')
				OR (PAG.Nombre LIKE '%' + @Filtro + '%')
			)
			AND
			(
				RPRP.RolDe_Usuario_Id = @RolDe_Usuario_Id OR @RolDe_Usuario_Id = -1
			)
			--AND
			--(
			--	PAG.PermiteAsignacionDePermisos = 1
			--)
			--AND
			--(
			--	RDU.PermiteAsignacionDePermisos = 1
			--)
		ORDER BY CASE 
			WHEN @OrdenarPor = 'Página' AND @Sentido = '0' THEN RANK() OVER (ORDER BY PAG.Nombre, RDU.Nombre)
			WHEN @OrdenarPor = 'Página' AND @Sentido = '1' THEN RANK() OVER (ORDER BY PAG.Nombre DESC, RDU.Nombre)
			WHEN @OrdenarPor = 'Rol de LogonName' AND @Sentido = '0' THEN RANK() OVER (ORDER BY RDU.Nombre, PAG.Nombre)
			WHEN @OrdenarPor = 'Rol de LogonName' AND @Sentido = '1' THEN RANK() OVER (ORDER BY RDU.Nombre DESC, PAG.Nombre)  
			WHEN 1=1 THEN RANK() OVER (ORDER BY RDU.Nombre) END -- CASE ELSE
	END
GO




IF (OBJECT_ID('usp_RelAsig__RolesDeUsuarios__A__Paginas___listado_cFiltros_cPag') IS NOT NULL) DROP PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Paginas___listado_cFiltros_cPag
GO
CREATE PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Paginas___listado_cFiltros_cPag
		@OrdenarPor					VARCHAR(50)
		,@Sentido					BIT
		,@Filtro					VARCHAR(50)
		
		,@Activo					BIT = NULL
		,@RolDe_Usuario_Id			INT = -1
		
		,@RegistrosPorPagina		INT = -1
		,@NumeroDePagina			INT = 1
		,@TotalDeRegistros			INT	= 0			OUTPUT		
        ,@sResSQL					VARCHAR(1000)			OUTPUT
        ,@UsuarioQueEjecuta_Id		INT
    AS
	BEGIN
    SET @sResSQL = ''
	DECLARE @Contexto_Id INT
	EXEC @Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT 
		
    	IF @RegistrosPorPagina = -1  -- Sin paginación
			BEGIN
				
				SELECT RPRP.id 
					,RDU.Nombre AS RolDeUsuario
					,PAG.Nombre AS Pagina
					,N'images/cbx/img_' + convert(varchar(5), RPRP.AutorizadoACargarLaPagina) + N'.jpg' AS imgTrueFalse_AutorizadoACargarLaPagina
					,N'images/cbx/img_' + convert(varchar(5), RPRP.AutorizadoAOperarLaPagina) + N'.jpg' AS imgTrueFalse_AutorizadoAOperarLaPagina
					,N'images/cbx/img_' + convert(varchar(5), RPRP.AutorizadoAVerRegAnulados) + N'.jpg' AS imgTrueFalse_AutorizadoAVerRegAnulados
					,N'images/cbx/img_' + convert(varchar(5), RPRP.AutorizadoAOperacionesSecundarias) + N'.jpg' AS imgTrueFalse_AutorizadoAOperacionesSecundarias
					,0 AS 'TotalDeRegistros'
					--,Activo
									
				FROM RelAsig__RolesDeUsuarios__A__Paginas RPRP
					INNER JOIN RolesDeUsuarios RDU ON RPRP.RolDe_Usuario_Id = RDU.id
					INNER JOIN Paginas PAG ON RPRP.Pagina_Id = PAG.id
				WHERE 
					--(
					--	RDU.id NOT IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_ExclusionesDe_RolesDeUsuarios))
					--) 
					--AND
					(
						(@Filtro = '')
						OR (RDU.Nombre LIKE '%' + @Filtro + '%')
						OR (PAG.Nombre LIKE '%' + @Filtro + '%')
					)
					AND
					(
						RPRP.RolDe_Usuario_Id = @RolDe_Usuario_Id OR @RolDe_Usuario_Id = -1
					)
					
				ORDER BY CASE 
					WHEN @OrdenarPor = 'RolDeUsuario' AND @Sentido = '0' THEN RANK() OVER (ORDER BY RDU.Nombre)
					WHEN @OrdenarPor = 'RolDeUsuario' AND @Sentido = '1' THEN RANK() OVER (ORDER BY RDU.Nombre DESC)
					WHEN @OrdenarPor = 'Pagina' AND @Sentido = '0' THEN RANK() OVER (ORDER BY PAG.Nombre)
					WHEN @OrdenarPor = 'Pagina' AND @Sentido = '1' THEN RANK() OVER (ORDER BY PAG.Nombre DESC)
					END	
			END
		ELSE
			BEGIN
				WITH YourCTE AS 
				(
					SELECT RPRP.id 
							,RDU.Nombre AS RolDeUsuario
							,PAG.Nombre AS Pagina
							,N'images/cbx/img_' + convert(varchar(5), RPRP.AutorizadoACargarLaPagina) + N'.jpg' AS imgTrueFalse_AutorizadoACargarLaPagina
							,N'images/cbx/img_' + convert(varchar(5), RPRP.AutorizadoAOperarLaPagina) + N'.jpg' AS imgTrueFalse_AutorizadoAOperarLaPagina
							,N'images/cbx/img_' + convert(varchar(5), RPRP.AutorizadoAVerRegAnulados) + N'.jpg' AS imgTrueFalse_AutorizadoAVerRegAnulados
							,N'images/cbx/img_' + convert(varchar(5), RPRP.AutorizadoAOperacionesSecundarias) + N'.jpg' AS imgTrueFalse_AutorizadoAOperacionesSecundarias
							,ROW_NUMBER() OVER 
									(
										-- VER QUE PARA PONER VARIOS CAMPOS --> VARIAS LINEAS CON EL MISMO WHEN
										ORDER BY  
											CASE WHEN @OrdenarPor = 'RolDeUsuario' AND @Sentido = '0' THEN RDU.Nombre END
											,CASE WHEN @OrdenarPor = 'RolDeUsuario' AND @Sentido = '1' THEN RDU.Nombre END DESC
											
											,CASE WHEN @OrdenarPor = 'Pagina' AND @Sentido = '0' THEN PAG.Nombre END
											,CASE WHEN @OrdenarPor = 'Pagina' AND @Sentido = '1' THEN PAG.Nombre END DESC
									) AS NumeroDeRegistro
					
					FROM RelAsig__RolesDeUsuarios__A__Paginas RPRP
						INNER JOIN RolesDeUsuarios RDU ON RPRP.RolDe_Usuario_Id = RDU.id
						INNER JOIN Paginas PAG ON RPRP.Pagina_Id = PAG.id
					WHERE 
						--(
						--	RDU.id NOT IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_ExclusionesDe_RolesDeUsuarios))
						--) 
						--AND
						(
							(@Filtro = '')
							OR (RDU.Nombre LIKE '%' + @Filtro + '%')
							OR (PAG.Nombre LIKE '%' + @Filtro + '%')
						)
						AND
						(
							RPRP.RolDe_Usuario_Id = @RolDe_Usuario_Id OR @RolDe_Usuario_Id = -1
						)
				)
				SELECT	id
						,RolDeUsuario
						,Pagina
						,imgTrueFalse_AutorizadoACargarLaPagina
						,imgTrueFalse_AutorizadoAOperarLaPagina
						,imgTrueFalse_AutorizadoAVerRegAnulados
						,imgTrueFalse_AutorizadoAOperacionesSecundarias
						,(SELECT MAX(NumeroDeRegistro) FROM YourCTE) AS 'TotalDeRegistros'
				 
				FROM  YourCTE
				WHERE NumeroDeRegistro BETWEEN ((@NumeroDePagina - 1) * @RegistrosPorPagina) + 1 AND @RegistrosPorPagina * (@NumeroDePagina)
			END
		--ENDIF
    END
GO

-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Paginas - FIN




-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Usuarios - INICIO, -- 26
IF (OBJECT_ID('usp_RelAsig__RolesDeUsuarios__A__Usuarios___listado_by_@Usuario_Id') IS NOT NULL) DROP PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Usuarios___listado_by_@Usuario_Id
GO
CREATE PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Usuarios___listado_by_@Usuario_Id
		@UsuarioQueEjecuta_Id			INT
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
		
		,@Usuario_Id					INT
	AS
	BEGIN
		
		--EXEC dbo.usp_VAL_UsuarioPerteneceAlContextoDe_@Usuario2_Id  @Usuario_Id = @UsuarioQueEjecuta_Id, @Usuario2_Id = @Usuario_Id, @sResSQL = @sResSQL OUTPUT
		
		--IF @sResSQL = ''
		--	EXEC usp_VAL_Contexto_Id__by__MasterAdmin_o_Administrador @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
		SET @sResSQL = ''
		--IF @sResSQL = ''
		--	BEGIN
				SELECT RARU.id 
					,RDU.id AS RolDe_Usuario_Id
					,RDU.Nombre AS Rol
					,(CASE WHEN RARU.Usuario_Id = @Usuario_Id
								AND (
										RARU.FechaHasta >= GETDATE()
										OR RARU.FechaHasta IS NULL
									) THEN 1
							ELSE 0 END) AS Asignado
					,(CASE WHEN RARU.Usuario_Id = @Usuario_Id
								AND (
										RARU.FechaHasta >= GETDATE()
										OR RARU.FechaHasta IS NULL
									) THEN dbo.ufc_FormatoFecha(RARU.FechaDesde)
							ELSE NULL END) AS FechaDesde
					,(CASE WHEN RARU.Usuario_Id = @Usuario_Id
								AND (
										RARU.FechaHasta >= GETDATE()
										OR RARU.FechaHasta IS NULL
									) THEN dbo.ufc_FormatoFecha(RARU.FechaHasta)
							ELSE NULL END) AS FechaHasta
					,RDU.PermiteAsignacionDePermisos AS PermiteEdicion
					--,dbo.ufc_FormatoFecha(RARU.FechaDesde) AS FechaDesde
					--,dbo.ufc_FormatoFecha(RARU.FechaHasta) AS FechaHasta
					
				FROM RolesDeUsuarios RDU 
					LEFT JOIN RelAsig__RolesDeUsuarios__A__Usuarios RARU ON RARU.RolDe_Usuario_Id = RDU.id AND RARU.Usuario_Id = @Usuario_Id
																			
				WHERE	RDU.Activo = 1
					AND 
						RDU.PermiteAsignacionDePermisos = 1
					AND
					(
						--SI ES UN ROL QUE ESTARÁ ACTIVO EN EL FUTURO LO MUESTRO TAMBIEN
						--NO VALIDO QUE LA FECHA DE INICIO SEA MENOR A LA FECHA ACTUAL
							--RARU.FechaDesde <= GETDATE()
						--AND 
						(
							RARU.FechaHasta >= GETDATE()
							OR RARU.FechaHasta IS NULL
						)
						OR
							RARU.id IS NULL
					)
					AND
					(
						RDU.id <> dbo.ufc_RolDe_Usuario_MasterAdmin() 
						OR 
						(SELECT id FROM RelAsig__RolesDeUsuarios__A__Usuarios 
						WHERE 
						RolDe_Usuario_Id = dbo.ufc_RolDe_Usuario_MasterAdmin()  
						AND Usuario_Id = @UsuarioQueEjecuta_Id)  IS NOT NULL
					)
						
				--	ORDER BY RDU.Nombre // Si lo ordenamos x nombre, no funca el asignar rol
				ORDER BY RDU.id
			END
	--END
GO




IF (OBJECT_ID('usp_RelAsig__RolesDeUsuarios__A__Usuarios___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Usuarios___listado_cFiltros
GO
CREATE PROCEDURE usp_RelAsig__RolesDeUsuarios__A__Usuarios___listado_cFiltros 
		@UsuarioQueEjecuta_Id			INT
		
		,@OrdenarPor					VARCHAR(50)	
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id
														, @sResSQL = @sResSQL OUTPUT
		
		
		--!! rEVISAR, Q DEVUELVE Contexto_ID = 0 Y NO SE PUEDE OPERAR SOBRE EL
		
		IF @sResSQL = '' OR @Contexto_Id = 0
			EXEC usp_VAL_Contexto_Id__by__MasterAdmin_o_Administrador @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
		
		
		IF @sResSQL = ''
			BEGIN
				SELECT RARU.id 
					,U.LogonName
					,U.Apellido + N', ' + U.Nombre AS NombreCompleto
					,RDU.id AS RolDe_Usuario_Id
							
				FROM RelAsig__RolesDeUsuarios__A__Usuarios RARU
					INNER JOIN RolesDeUsuarios RDU ON RARU.RolDe_Usuario_Id = RDU.id
					INNER JOIN Usuarios U ON RARU.Usuario_Id = U.id
				WHERE
					(U.Contexto_Id = @Contexto_Id )
					AND
					--(
					--	RDU.id NOT IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_ExclusionesDe_RolesDeUsuarios))
					--) 
					--AND
					(
						(@Filtro = '')
						OR (RDU.Nombre LIKE '%' + @Filtro + '%')
						OR (U.LogonName LIKE '%' + @Filtro + '%')
						OR (U.Nombre LIKE '%' + @Filtro + '%')
						OR (U.Apellido LIKE '%' + @Filtro + '%')
					)
					AND
					(
						RDU.PermiteAsignacionDePermisos = 1
					)
				--	ORDER BY RDU.Nombre // Si lo ordenamos x nombre, no funca el asignar rol
				ORDER BY RDU.id
			END
	END
GO
-- SP-TABLA: RelAsig__RolesDeUsuarios__A__Usuarios - FIN




-- SP-TABLA: RolesDeUsuarios - INICIO, -- 27
IF (OBJECT_ID('usp_RolesDeUsuarios___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_RolesDeUsuarios___listado_DDL_o_CBXL
GO
CREATE PROCEDURE usp_RolesDeUsuarios___listado_DDL_o_CBXL
		@UsuarioQueEjecuta_Id			INT
		
		,@Formato_Listado				SMALLINT = 1 
		,@Activo						BIT = 1
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		
		DECLARE @Es_MasterAdmin	VARCHAR(1000)
		EXEC	dbo.usp_VAL_Contexto_Id__by__MasterAdmin  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @Es_MasterAdmin OUTPUT
		
		SELECT	 id
				,Data 
		
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
						
		UNION
		
		SELECT	RDU.id
				,RDU.Nombre	AS Data
				
		FROM RolesDeUsuarios RDU
		WHERE --(RDU.id NOT IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_ExclusionesDe_RolesDeUsuarios)))
			--AND
			(RDU.PermiteAsignacionDePermisos = 1)
				OR
			 (@Es_MasterAdmin = '')
		ORDER BY Data
	END
GO




IF (OBJECT_ID('usp_RolesDe_Usuarios___listado_cFiltros_cPag') IS NOT NULL) DROP PROCEDURE usp_RolesDe_Usuarios___listado_cFiltros_cPag
GO
CREATE PROCEDURE usp_RolesDe_Usuarios___listado_cFiltros_cPag
		@OrdenarPor						VARCHAR(50)
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		
		,@Activo						BIT = NULL
		
		,@RegistrosPorPagina			INT = -1
		,@NumeroDePagina				INT = 1
		,@TotalDeRegistros				INT	= 0			OUTPUT		

        ,@sResSQL						VARCHAR(1000)	OUTPUT
        ,@UsuarioQueEjecuta_Id			INT
    AS
	BEGIN
	--DECLARE @Contexto_Id INT
	--EXEC @Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT 
	
    SET @sResSQL = ''
	IF @RegistrosPorPagina = -1  -- Sin paginación
		BEGIN
			
			SELECT  RDU.id
					,RDU.Nombre
					,RDU.Observaciones
					,RDU.PermiteAsignacionDePermisos
					,RDU.Activo
				,0 AS 'TotalDeRegistros'
				--,Activo
			FROM RolesDe_Usuarios RDU
			WHERE  
				(RDU.Activo = @Activo)
				AND	(
					(@Filtro = '')
					OR (RDU.Nombre LIKE '%' + @Filtro + '%')
					OR (RDU.Nombre LIKE '%' + @Filtro + '%')
					)

			ORDER BY id
		END
	ELSE
		BEGIN
			SELECT * INTO #TempTable
			FROM
			(
				SELECT  RDU.id
						,RDU.Nombre
						,RDU.Observaciones
						,RDU.PermiteAsignacionDePermisos
						,RDU.Activo
						,ROW_NUMBER() OVER 
						(
							-- VER QUE PARA PONER VARIOS CAMPOS --> VARIAS LINEAS CON EL MISMO WHEN
							ORDER BY  
								CASE WHEN @OrdenarPor = 'Nombre' AND @Sentido = '0' THEN RDU.Nombre END
								,CASE WHEN @OrdenarPor = 'Nombre' AND @Sentido = '1' THEN RDU.Nombre END DESC
									
						) AS NumeroDeRegistro
				
				FROM RolesDe_Usuarios RDU
				WHERE  
					(RDU.Activo = @Activo)
					AND	(
						(@Filtro = '')
						OR (RDU.Nombre LIKE '%' + @Filtro + '%')
						OR (RDU.Nombre LIKE '%' + @Filtro + '%')
						)
			) Query
			SELECT	id
					,Nombre
					,Observaciones
					,PermiteAsignacionDePermisos
					,Activo
					,(SELECT MAX(NumeroDeRegistro) FROM #TempTable) AS 'TotalDeRegistros'
			 
			FROM  #TempTable
			WHERE NumeroDeRegistro BETWEEN ((@NumeroDePagina - 1) * @RegistrosPorPagina) + 1 AND @RegistrosPorPagina * (@NumeroDePagina)
			
			SET @TotalDeRegistros = (SELECT	COUNT(*) FROM  #TempTable)
			DROP TABLE #TempTable
		END
		--ENDIF
    END
GO
-- SP-TABLA: RolesDeUsuarios - FIN




-- SP-TABLA: Sentidos - INICIO, -- 28
IF (OBJECT_ID('usp_Sentidos___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_Sentidos___listado_DDL_o_CBXL
GO
CREATE PROCEDURE usp_Sentidos___listado_DDL_o_CBXL 
		@UsuarioQueEjecuta_Id			INT
		
		,@Formato_Listado				SMALLINT = 1
		,@Activo			BIT = 1
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		SET @sResSQL = ''
		SELECT	 Codigo
				,Data 
		
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
						
		UNION
		SELECT	Codigo
				,Nombre AS Data
				
		FROM Sentidos
		--WHERE 
			--(Activo = '1')
			--AND
		ORDER BY Data
	END
GO
-- SP-TABLA: Sentidos - FIN




-- SP-TABLA: Soporte - INICIO, -- 29
IF (OBJECT_ID('usp_Soporte___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_Soporte___listado_cFiltros
GO
CREATE PROCEDURE usp_Soporte___listado_cFiltros
		@UsuarioQueEjecuta_Id			INT
		
		,@OrdenarPor					VARCHAR(50)	
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		,@Activo						BIT = NULL
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
	
		DECLARE @Tabla_Soporte_Id INT
		SET @Tabla_Soporte_Id = (SELECT id FROM Tablas WHERE Nombre = 'Soporte')
	
		SELECT	SOP.id 
				,U.Apellido + N', ' + U.Nombre AS UsuarioQueCreo
				,SOP.FechaDeEjecucion
				,U2.Apellido + N', ' + U2.Nombre AS UsuarioQueCerro
				,SOP.FechaDeCierre
				,SOP.Numero
				,SOP.Texto
				,EDSOP.Nombre AS Estado
				,PRI.Nombre AS Prioridad
				,N'images/cbx/img_' + convert(varchar(5),SOP.Activo) + N'.jpg' AS imgActivo
				
		FROM Soporte SOP
			INNER JOIN LogRegistros LREG ON LREG.Tabla_Id = @Tabla_Soporte_Id AND LREG.Registro_Id = SOP.id AND LREG.TipoDe_LogRegistro_Id = 1 -- 1:CREADO
			INNER JOIN Usuarios U ON LREG.UsuarioQueEjecuta_Id = U.id
			INNER JOIN Usuarios U2 ON SOP.UsuarioQueCerro_Id = U2.id
			INNER JOIN EstadosDeSoporte EDSOP ON SOP.EstadoDe_Soporte_Id = EDSOP.id
			INNER JOIN Prioridades PRI ON SOP.Prioridad_Id = PRI.id
		WHERE 
			(SOP.Activo = @Activo OR @Activo IS NULL)
			AND
			(
				(@Filtro = '')
				OR (SOP.Numero LIKE '%' + @Filtro + '%')
				OR (U.Apellido + N', ' + U.Nombre LIKE '%' + @Filtro + '%')
				OR (U2.Apellido + N', ' + U2.Nombre LIKE '%' + @Filtro + '%')
				OR (SOP.Texto LIKE '%' + @Filtro + '%')
				OR (SOP.Observaciones LIKE '%' + @Filtro + '%')
			)
		ORDER BY CASE 
			WHEN @OrdenarPor = 'Número' AND @Sentido = '0' THEN RANK() OVER (ORDER BY SOP.Numero)
			WHEN @OrdenarPor = 'Número' AND @Sentido = '1' THEN RANK() OVER (ORDER BY SOP.Numero DESC)
			WHEN @OrdenarPor = 'Fecha' AND @Sentido = '0' THEN RANK() OVER (ORDER BY SOP.FechaDeEjecucion)
			WHEN @OrdenarPor = 'Fecha' AND @Sentido = '1' THEN RANK() OVER (ORDER BY SOP.FechaDeEjecucion DESC)
			WHEN @OrdenarPor = 'Solicitante' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U.Apellido , U.Nombre, SOP.FechaDeEjecucion)
			WHEN @OrdenarPor = 'Solicitante' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U.Apellido DESC, U.Nombre DESC, SOP.FechaDeEjecucion)  
			WHEN @OrdenarPor = 'Prioridad' AND @Sentido = '0' THEN RANK() OVER (ORDER BY PRI.Orden, SOP.FechaDeEjecucion, PRI.Nombre, U.Apellido , U.Nombre)
			WHEN @OrdenarPor = 'Prioridad' AND @Sentido = '1' THEN RANK() OVER (ORDER BY PRI.Orden DESC, SOP.FechaDeEjecucion, PRI.Nombre DESC, U.Apellido , U.Nombre)
			WHEN @OrdenarPor = 'Estado' AND @Sentido = '0' THEN RANK() OVER (ORDER BY EDSOP.Nombre, SOP.FechaDeEjecucion)
			WHEN @OrdenarPor = 'Estado' AND @Sentido = '1' THEN RANK() OVER (ORDER BY EDSOP.Nombre DESC, SOP.FechaDeEjecucion)
			WHEN 1=1 THEN RANK() OVER (ORDER BY U.Apellido , U.Nombre) END -- CASE ELSE
	END
GO




IF (OBJECT_ID('usp_Soporte___listado_cFiltros_by_@EstadoDe_Soporte_Id@Prioridad_Id') IS NOT NULL) DROP PROCEDURE usp_Soporte___listado_cFiltros_by_@EstadoDe_Soporte_Id@Prioridad_Id
GO
CREATE PROCEDURE usp_Soporte___listado_cFiltros_by_@EstadoDe_Soporte_Id@Prioridad_Id
		@UsuarioQueEjecuta_Id			INT
		
		,@OrdenarPor					VARCHAR(50)	
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		,@Activo						BIT = NULL
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
		
		,@EstadoDe_Soporte_Id			INT
		,@Prioridad_Id					INT
		
	AS
	BEGIN
		SET @sResSQL = ''
	
		DECLARE @Tabla_Soporte_Id INT
		SET @Tabla_Soporte_Id = (SELECT id FROM Tablas WHERE Nombre = 'Soporte')
	
		SELECT SOP.id 
				,U.Apellido + N', ' + U.Nombre AS UsuarioQueCreo
				,SOP.FechaDeEjecucion
				,U2.Apellido + N', ' + U2.Nombre AS UsuarioQueCerro
				,SOP.FechaDeCierre
				,SOP.Numero
				,SOP.Texto
				,EDSOP.Nombre AS Estado
				,PRI.Nombre AS Prioridad
				,N'images/cbx/imgRealizado_' + CONVERT(VARCHAR(5), SOP.Cerrado) + N'.png' AS img_Cerrado
				,N'images/cbx/img_' + convert(varchar(5),SOP.Activo) + N'.jpg' AS imgActivo
				
		FROM Soporte SOP
			INNER JOIN LogRegistros LREG ON LREG.Tabla_Id = @Tabla_Soporte_Id AND LREG.Registro_Id = SOP.id AND LREG.TipoDe_LogRegistro_Id = 1 -- 1:CREADO
			INNER JOIN Usuarios U ON LREG.UsuarioQueEjecuta_Id = U.id
			INNER JOIN Usuarios U2 ON SOP.UsuarioQueCerro_Id = U2.id
			INNER JOIN EstadosDeSoporte EDSOP ON SOP.EstadoDe_Soporte_Id = EDSOP.id
			INNER JOIN Prioridades PRI ON SOP.Prioridad_Id = PRI.id
		WHERE 
			(SOP.Activo = @Activo OR @Activo IS NULL)
			AND(@EstadoDe_Soporte_Id = '-1' OR SOP.EstadoDe_Soporte_Id = @EstadoDe_Soporte_Id)
			AND(@Prioridad_Id = '-1' OR SOP.Prioridad_Id = @Prioridad_Id)
			AND
			(
				(@Filtro = '')
				OR (SOP.Numero LIKE '%' + @Filtro + '%')
				OR (U.Apellido + N', ' + U.Nombre LIKE '%' + @Filtro + '%')
				OR (U2.Apellido + N', ' + U2.Nombre LIKE '%' + @Filtro + '%')
				OR (SOP.Texto LIKE '%' + @Filtro + '%')
				OR (SOP.Observaciones LIKE '%' + @Filtro + '%')
			)
		ORDER BY CASE 
			WHEN @OrdenarPor = 'Número' AND @Sentido = '0' THEN RANK() OVER (ORDER BY SOP.Numero)
			WHEN @OrdenarPor = 'Número' AND @Sentido = '1' THEN RANK() OVER (ORDER BY SOP.Numero DESC)
			WHEN @OrdenarPor = 'Fecha' AND @Sentido = '0' THEN RANK() OVER (ORDER BY SOP.FechaDeEjecucion)
			WHEN @OrdenarPor = 'Fecha' AND @Sentido = '1' THEN RANK() OVER (ORDER BY SOP.FechaDeEjecucion DESC)
			WHEN @OrdenarPor = 'Solicitante' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U.Apellido , U.Nombre, SOP.FechaDeEjecucion)
			WHEN @OrdenarPor = 'Solicitante' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U.Apellido DESC, U.Nombre DESC, SOP.FechaDeEjecucion)  
			WHEN @OrdenarPor = 'Prioridad' AND @Sentido = '0' THEN RANK() OVER (ORDER BY PRI.Orden, SOP.FechaDeEjecucion, PRI.Nombre, U.Apellido , U.Nombre)
			WHEN @OrdenarPor = 'Prioridad' AND @Sentido = '1' THEN RANK() OVER (ORDER BY PRI.Orden DESC, SOP.FechaDeEjecucion, PRI.Nombre DESC, U.Apellido , U.Nombre)
			WHEN @OrdenarPor = 'Estado' AND @Sentido = '0' THEN RANK() OVER (ORDER BY EDSOP.Nombre, SOP.FechaDeEjecucion)
			WHEN @OrdenarPor = 'Estado' AND @Sentido = '1' THEN RANK() OVER (ORDER BY EDSOP.Nombre DESC, SOP.FechaDeEjecucion)
			WHEN 1=1 THEN RANK() OVER (ORDER BY U.Apellido , U.Nombre) END -- CASE ELSE
	END
GO




IF (OBJECT_ID('usp_Soporte___listado_cFiltros_by_@Cerrado@EstadoDe_Soporte_Id@Prioridad_Id') IS NOT NULL) DROP PROCEDURE usp_Soporte___listado_cFiltros_by_@Cerrado@EstadoDe_Soporte_Id@Prioridad_Id
GO
CREATE PROCEDURE usp_Soporte___listado_cFiltros_by_@Cerrado@EstadoDe_Soporte_Id@Prioridad_Id
		@UsuarioQueEjecuta_Id			INT
		
		,@OrdenarPor					VARCHAR(50)	
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		,@Activo						BIT = NULL
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
		
		,@EstadoDe_Soporte_Id			INT
		,@Prioridad_Id					INT
		,@Cerrado						BIT = NULL
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT 
		
		IF @sResSQL = ''
			BEGIN
				DECLARE @Tabla_Soporte_Id INT
				SET @Tabla_Soporte_Id = (SELECT id FROM Tablas WHERE Nombre = 'Soporte')
			
				SELECT SOP.id 
						--,U.Apellido + N', ' + U.Nombre AS UsuarioQueCreo
						--,U2.Apellido + N', ' + U2.Nombre AS UsuarioQueCerro
						,U3.Apellido + N', ' + U3.Nombre AS UsuarioQueSolicito
						,SOP.FechaDeEjecucion
						--,SOP.FechaDeCierre
						,SOP.Numero
						,SOP.Texto
						,EDSOP.Nombre AS Estado
						,PRI.Nombre AS Prioridad
						,N'images/cbx/imgRealizado_' + CONVERT(VARCHAR(5), SOP.Cerrado) + N'.png' AS img_Cerrado
						,REPLACE(REPLACE(SOP.Cerrado, '1', 'Pedido Cerrado'), '0', 'Pedido Pendiente') AS TextoCerrado  -- Va como Tooltip
						,N'images/cbx/img_' + convert(varchar(5),SOP.Activo) + N'.jpg' AS imgActivo
						,(CASE WHEN PUBLI.NumeroDeVersion IS NULL THEN '' ELSE PUBLI.NumeroDeVersion END) AS Publicacion
						
				FROM Soporte SOP
					INNER JOIN LogRegistros LREG ON LREG.Tabla_Id = @Tabla_Soporte_Id AND LREG.Registro_Id = SOP.id AND LREG.TipoDe_LogRegistro_Id = 1 -- 1:CREADO
					--INNER JOIN Usuarios U ON LREG.UsuarioQueEjecuta_Id = U.id
					--INNER JOIN Usuarios U2 ON SOP.UsuarioQueCerro_Id = U2.id
					INNER JOIN Usuarios U3 ON SOP.UsuarioQueSolicita_Id = U3.id
					INNER JOIN EstadosDeSoporte EDSOP ON SOP.EstadoDe_Soporte_Id = EDSOP.id
					INNER JOIN Prioridades PRI ON SOP.Prioridad_Id = PRI.id
					LEFT JOIN Publicaciones PUBLI ON SOP.Publicacion_Id = PUBLI.id
					
				WHERE 
					(SOP.Activo = @Activo OR @Activo IS NULL)
					AND(@EstadoDe_Soporte_Id = '-1' OR SOP.EstadoDe_Soporte_Id = @EstadoDe_Soporte_Id)
					AND(@Prioridad_Id = '-1' OR SOP.Prioridad_Id = @Prioridad_Id)
					AND(SOP.Cerrado = @Cerrado OR @Cerrado IS NULL)
					AND(SOP.Contexto_Id = @Contexto_Id)
					AND
					(
						(@Filtro = '')
						OR (SOP.Numero LIKE '%' + @Filtro + '%')
						OR (SOP.Texto LIKE '%' + @Filtro + '%')
						--OR (SOP.Observaciones LIKE '%' + @Filtro + '%')
					)
				ORDER BY CASE 
					WHEN @OrdenarPor = 'Número' AND @Sentido = '0' THEN RANK() OVER (ORDER BY SOP.Numero)
					WHEN @OrdenarPor = 'Número' AND @Sentido = '1' THEN RANK() OVER (ORDER BY SOP.Numero DESC)
					WHEN @OrdenarPor = 'Fecha' AND @Sentido = '0' THEN RANK() OVER (ORDER BY SOP.FechaDeEjecucion)
					WHEN @OrdenarPor = 'Fecha' AND @Sentido = '1' THEN RANK() OVER (ORDER BY SOP.FechaDeEjecucion DESC)
					WHEN @OrdenarPor = 'Solicitante' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U3.Apellido , U3.Nombre, SOP.FechaDeEjecucion)
					WHEN @OrdenarPor = 'Solicitante' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U3.Apellido DESC, U3.Nombre DESC, SOP.FechaDeEjecucion)  
					WHEN @OrdenarPor = 'Prioridad' AND @Sentido = '0' THEN RANK() OVER (ORDER BY PRI.Orden, SOP.FechaDeEjecucion, PRI.Nombre)
					WHEN @OrdenarPor = 'Prioridad' AND @Sentido = '1' THEN RANK() OVER (ORDER BY PRI.Orden DESC, SOP.FechaDeEjecucion, PRI.Nombre DESC)
					WHEN @OrdenarPor = 'Estado' AND @Sentido = '0' THEN RANK() OVER (ORDER BY EDSOP.Nombre, SOP.FechaDeEjecucion)
					WHEN @OrdenarPor = 'Estado' AND @Sentido = '1' THEN RANK() OVER (ORDER BY EDSOP.Nombre DESC, SOP.FechaDeEjecucion)
					WHEN 1=1 THEN RANK() OVER (ORDER BY SOP.Numero DESC) END -- CASE ELSE
			END
	END
GO




IF (OBJECT_ID('usp_Soporte___Listado_DDL_o_CBXL_by_@Publicacion_Id') IS NOT NULL) DROP PROCEDURE usp_Soporte___Listado_DDL_o_CBXL_by_@Publicacion_Id
GO
CREATE PROCEDURE usp_Soporte___Listado_DDL_o_CBXL_by_@Publicacion_Id
	 @UsuarioQueEjecuta_Id		INT
	 ,@Formato_Listado			SMALLINT = 1
	 
	 ,@Publicacion_Id			INT
	 
	 ,@sResSQL					VARCHAR(1000)			OUTPUT	
	 
	AS 
	BEGIN
		SET @sResSQL = ''
		--EXEC	usp_VAL_UsuarioPerteneceAlContextoDe_@Comunicacion_Id  @Usuario_Id = @UsuarioQueEjecuta_Id,@Comunicacion_Id = @Comunicacion_Id ,@sResSQL = @sResSQL OUTPUT
		
		IF @sResSQL = ''
			BEGIN
				-- Listo todas los Soportes Cerrados, TODOS, Pero solo marco chk=1 los que son de esta publicación.
				SELECT	SOP.id
						--CASE WHEN SOP.Publicacion_Id IS NULL THEN 0
						-- WHEN SOP.Publicacion_Id = @Publicacion_Id THEN 1
						,CASE WHEN NOT SOP.Publicacion_Id IS NULL AND SOP.Publicacion_Id = @Publicacion_Id THEN 1
								ELSE 0 END AS chk
						,N'Nº ' + CAST(SOP.Numero AS VARCHAR) 
							+ N' - Pedido: ' + SOP.Texto + N'<br><br>'
							+ N' - Respuesta: ' + SOP.Observaciones + N'<br><br>' AS Data
							
						,SOP.Numero AS Orden
						
				FROM Soporte SOP
				WHERE 
					(SOP.Cerrado = 1)
					AND
					(
						(SOP.Publicacion_Id IS NULL)
						OR 
						(SOP.Publicacion_Id = @Publicacion_Id)
					)
				
				ORDER BY chk DESC, SOP.FechaDeCierre
			END	
	END
GO



			   
IF (OBJECT_ID('usp_Soporte___Listado_DDL_o_CBXL_ParaPublicaciones') IS NOT NULL) DROP PROCEDURE usp_Soporte___Listado_DDL_o_CBXL_ParaPublicaciones
GO
CREATE PROCEDURE usp_Soporte___Listado_DDL_o_CBXL_ParaPublicaciones
		@UsuarioQueEjecuta_Id			INT
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		
		DECLARE @Es_MasterAdmin	VARCHAR(1000)
		EXEC	dbo.usp_VAL_Contexto_Id__by__MasterAdmin  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @Es_MasterAdmin OUTPUT
		
		SELECT	id
				,N'Nº ' + CAST(SOP.Numero AS VARCHAR) 
					+ N' - Pedido: ' + SOP.Texto + N'<br><br>'
					+ N' - Respuesta: ' + SOP.Observaciones + N'<br><br>' AS Data
					
				,SOP.Numero AS Orden
				
		FROM Soporte SOP
		WHERE 
			(SOP.Cerrado = 1)
			AND
			(SOP.Publicacion_Id IS NULL)
		
		ORDER BY SOP.FechaDeCierre
	END
GO
-- SP-TABLA: Soporte - FIN




-- SP-TABLA: SubSistemas - INICIO
IF (OBJECT_ID('usp_SubSistemas___listado') IS NOT NULL) DROP PROCEDURE usp_SubSistemas___listado 
GO
CREATE PROCEDURE usp_SubSistemas___listado 
		@OrdenarPor					VARCHAR(50)	
		,@Sentido					BIT
		,@Filtro					VARCHAR(50)
		
		,@Activo					BIT = NULL
	    
	    ,@sResSQL					VARCHAR(1000)			OUTPUT
        ,@UsuarioQueEjecuta_Id		INT
    AS
	BEGIN
    SET @sResSQL = ''
		SELECT	SUBS.id
				,SUBS.Nombre					
				,SUBS.Observaciones
				
		FROM SubSistemas SUBS
			
		WHERE 
				(
				(@Filtro = '')
				OR (SUBS.Nombre LIKE '%' + @Filtro + '%')
				)
				AND
				(SUBS.Activo = @Activo OR @Activo IS NULL)
		ORDER BY CASE 
			WHEN @OrdenarPor = 'Nombre' AND @Sentido = '0' THEN RANK() OVER (ORDER BY SUBS.Nombre)
			WHEN @OrdenarPor = 'Nombre' AND @Sentido = '1' THEN RANK() OVER (ORDER BY SUBS.Nombre DESC)
			WHEN 1=1 THEN RANK() OVER (ORDER BY SUBS.Nombre) END -- CASE ELSE
	END
GO




IF (OBJECT_ID('usp_SubSistemas___listado_ParaPublicaciones') IS NOT NULL) DROP PROCEDURE usp_SubSistemas___listado_ParaPublicaciones
GO
CREATE PROCEDURE usp_SubSistemas___listado_ParaPublicaciones
		@Activo						BIT = 1
	    
	    ,@sResSQL					VARCHAR(1000)			OUTPUT
        ,@UsuarioQueEjecuta_Id		INT
    AS
	BEGIN
    SET @sResSQL = ''
		SELECT	SUBS.id
				,SUBS.Nombre					
				,SUBS.Observaciones
				
		FROM SubSistemas SUBS
			
		WHERE (SUBS.Activo = @Activo OR @Activo IS NULL)
		
		ORDER BY SUBS.Nombre
	END
GO




IF (OBJECT_ID('usp_SubSistemas___listado_ParaPublicaciones_by_@Publicacion_Id') IS NOT NULL) DROP PROCEDURE usp_SubSistemas___listado_ParaPublicaciones_by_@Publicacion_Id
GO
CREATE PROCEDURE usp_SubSistemas___listado_ParaPublicaciones_by_@Publicacion_Id
		@Activo						BIT = 1
		
		,@Publicacion_Id			INT
	    
	    ,@sResSQL					VARCHAR(1000)			OUTPUT
        ,@UsuarioQueEjecuta_Id		INT
    AS
	BEGIN
    SET @sResSQL = ''
    
    	SELECT	RASaP.Subsistema_Id
    			,RASaP.Usuario_Id
    			,RASaP.NumeroDeVersion
    			,RASaP.SVN
    			,RASaP.Ubicacion
    			,RASaP.Observaciones
				
		FROM RelAsig__Subsistemas__A__Publicaciones RASaP
			
		WHERE RASaP.Publicacion_Id = @Publicacion_Id
	END
GO
-- SP-TABLA: SubSistemas - FIN




-- SP-TABLA: Tablas - INICIO, -- 30
IF (OBJECT_ID('usp_Tablas___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_Tablas___listado_cFiltros
GO
CREATE PROCEDURE usp_Tablas___listado_cFiltros 
		@UsuarioQueEjecuta_Id			INT
		
		,@OrdenarPor					VARCHAR(50)	
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
	
		SELECT id 
				,Nombre
				,Nomenclatura
				,Observaciones
		FROM Tablas

		WHERE 
			--(Activo = 1)
			--AND
			(
				((@Filtro = '')
				OR (Nombre LIKE '%' + @Filtro + '%')
				OR (Nomenclatura LIKE '%' + @Filtro + '%')
				OR (Observaciones LIKE '%' + @Filtro + '%'))
			)
		ORDER BY CASE 
			WHEN @OrdenarPor = 'Nombre' AND @Sentido = '0' THEN RANK() OVER (ORDER BY Nombre)
			WHEN @OrdenarPor = 'Nombre' AND @Sentido = '1' THEN RANK() OVER (ORDER BY Nombre DESC)  
			WHEN @OrdenarPor = 'Nomenclatura' AND @Sentido = '0' THEN RANK() OVER (ORDER BY Nomenclatura)
			WHEN @OrdenarPor = 'Nomenclatura' AND @Sentido = '1' THEN RANK() OVER (ORDER BY Nomenclatura DESC)  
			WHEN @OrdenarPor = 'Observaciones' AND @Sentido = '0' THEN RANK() OVER (ORDER BY Observaciones)
			WHEN @OrdenarPor = 'Observaciones' AND @Sentido = '1' THEN RANK() OVER (ORDER BY Observaciones DESC)
			WHEN 1=1 THEN RANK() OVER (ORDER BY Nombre) END -- CASE ELSE
	END
GO




IF (OBJECT_ID('usp_Tablas___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_Tablas___listado_DDL_o_CBXL
GO
CREATE PROCEDURE usp_Tablas___listado_DDL_o_CBXL
		@UsuarioQueEjecuta_Id			INT
		
		,@Formato_Listado				SMALLINT = 1 
		,@Activo						BIT = 0
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		
		DECLARE @Es_MasterAdmin	VARCHAR(1000)
		EXEC	dbo.usp_VAL_Contexto_Id__by__MasterAdmin  @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @Es_MasterAdmin OUTPUT
		
		SELECT	 id
				,Data 
				,-1 AS Orden
		
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
						
		UNION
		
		SELECT	id
				,Nombre	AS Data
				,ROW_NUMBER() OVER (ORDER BY Nombre) AS Orden
				
		FROM Tablas
		ORDER BY Orden
	END
GO
-- SP-TABLA: Tablas - FIN


-- SP-TABLA: TareasPendientes - INICIO  -- 39
IF (OBJECT_ID('usp_EstadosDeTareasPendientes___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_EstadosDeTareasPendientes___listado_DDL_o_CBXL
GO
CREATE PROCEDURE usp_EstadosDeTareasPendientes___listado_DDL_o_CBXL 
		@UsuarioQueEjecuta_Id		INT
		
		,@Formato_Listado			SMALLINT = 1
		,@Activo			BIT = 1
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		SET @sResSQL = ''
		DECLARE @MinId AS INT
		EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado

		--	SELECT    'Return Value' = @return_value
		--SET @MinId = (SELECT ufc_MinimoId_inDDLs(@Formato_Listado))
		
		SELECT	 id
				,Data 
		
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
						
		UNION
		SELECT	id
				,Nombre	AS Data
				
		FROM EstadosDeTareasPendientes
		ORDER BY id
	END
GO



IF (OBJECT_ID('usp_TareasPendientes___listado_cFiltros_by_@EstadoDe_TareasPendientes_Id@Prioridad_Id') IS NOT NULL) DROP PROCEDURE usp_TareasPendientes___listado_cFiltros_by_@EstadoDe_TareasPendientes_Id@Prioridad_Id
GO
CREATE PROCEDURE usp_TareasPendientes___listado_cFiltros_by_@EstadoDe_TareasPendientes_Id@Prioridad_Id
		@UsuarioQueEjecuta_Id			INT
		
		,@OrdenarPor					VARCHAR(50)	
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		
		,@EstadoDe_TareasPendientes_Id	INT
		,@Prioridad_Id					INT
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
		
		-- no se usan
		,@Activo						BIT = NULL
		--,@Cerrado						BIT = NULL
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT 
		
		IF @sResSQL = ''
			BEGIN
				--DECLARE @Tabla_TareasPendientes_Id INT
				--SET @Tabla_TareasPendientes_Id = (SELECT id FROM Tablas WHERE Nombre = 'TareasPendientes')
			
				SELECT	TARPEND.id 
						,COALESCE(U.Apellido + N', ' + U.Nombre, 'Sin asignar') AS Usuario_Asignado
						,TARPEND.Nombre
						,TARPEND.Texto
						,PRI.Nombre AS Prioridad
						,TAB.Nombre AS Tabla
						,PAG.Nombre AS Pagina
						,EDTARPEND.Nombre AS Estado
						,TARPEND.FechaDeCreacion as FechaDeCreacion
						,TARPEND.FechaDeCumplimiento as FechaDeCumplimiento
						
				FROM TareasPendientes TARPEND
				--	INNER JOIN LogRegistros LREG ON LREG.Tabla_Id = @Tabla_TareasPendientes_Id AND LREG.Registro_Id = TARPEND.id AND LREG.TipoDe_LogRegistro_Id = 1 -- 1:CREADO
					LEFT JOIN Usuarios U ON TARPEND.UsuarioAsignado_Id = U.id
				--	INNER JOIN Usuarios U ON LREG.UsuarioQueEjecuta_Id = U.id
				--	INNER JOIN Usuarios U3 ON TARPEND.UsuarioQueSolicita_Id = U3.id
					INNER JOIN EstadosDeTareasPendientes EDTARPEND ON TARPEND.Estado_Id = EDTARPEND.id
					INNER JOIN Prioridades PRI ON TARPEND.Prioridad_Id = PRI.id
					LEFT JOIN Tablas TAB ON TAB.id = TARPEND.Tabla_Id
					LEFT JOIN Paginas PAG ON PAG.id = TARPEND.Pagina_Id
					
				WHERE 
					(@EstadoDe_TareasPendientes_Id = '-1' OR TARPEND.Estado_Id = @EstadoDe_TareasPendientes_Id)
					AND(@Prioridad_Id = '-1' OR TARPEND.Prioridad_Id = @Prioridad_Id)
					AND
					(
						(@Filtro = '')
						OR (TARPEND.Nombre LIKE '%' + @Filtro + '%')
						OR (TARPEND.Texto LIKE '%' + @Filtro + '%')
						--OR (TARPEND.Observaciones LIKE '%' + @Filtro + '%')
					)
				ORDER BY CASE
					WHEN @OrdenarPor = 'Fecha de creacion' AND @Sentido = '0' THEN RANK() OVER (ORDER BY TARPEND.FechaDeCreacion)
					WHEN @OrdenarPor = 'Fecha de creacion' AND @Sentido = '1' THEN RANK() OVER (ORDER BY TARPEND.FechaDeCreacion DESC)
					WHEN @OrdenarPor = 'Nombre' AND @Sentido = '0' THEN RANK() OVER (ORDER BY TARPEND.Nombre)
					WHEN @OrdenarPor = 'Nombre' AND @Sentido = '1' THEN RANK() OVER (ORDER BY TARPEND.Nombre DESC)
					WHEN @OrdenarPor = 'Usuario asignado' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U.Apellido , U.Nombre)
					WHEN @OrdenarPor = 'Usuario asignado' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U.Apellido DESC, U.Nombre DESC)  
					WHEN @OrdenarPor = 'Prioridad' AND @Sentido = '0' THEN RANK() OVER (ORDER BY PRI.Orden, PRI.Nombre)
					WHEN @OrdenarPor = 'Prioridad' AND @Sentido = '1' THEN RANK() OVER (ORDER BY PRI.Orden DESC, PRI.Nombre DESC)
					WHEN @OrdenarPor = 'Estado' AND @Sentido = '0' THEN RANK() OVER (ORDER BY EDTARPEND.Nombre)
					WHEN @OrdenarPor = 'Estado' AND @Sentido = '1' THEN RANK() OVER (ORDER BY EDTARPEND.Nombre DESC)
					WHEN 1=1 THEN RANK() OVER (ORDER BY TARPEND.FechaDeCreacion DESC) END -- CASE ELSE
			END
	END
GO



IF (OBJECT_ID('usp_TareasPendientes___listado_Exportar') IS NOT NULL) DROP PROCEDURE usp_TareasPendientes___listado_Exportar
GO
CREATE PROCEDURE usp_TareasPendientes___listado_Exportar
		@UsuarioQueEjecuta_Id			INT
		
		,@OrdenarPor					VARCHAR(50)	
		,@Sentido						BIT
		,@Filtro						VARCHAR(50)
		,@EstadoDe_TareasPendientes_Id	INT
		,@Prioridad_Id					INT
		
		,@sResSQL						VARCHAR(1000)			OUTPUT
		
		
	AS
	BEGIN
		--DECLARE @Contexto_Id	INT
		--EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT 
		SET @sResSQL = ''
		
		IF @sResSQL = ''
			BEGIN
				--DECLARE @Tabla_TareasPendientes_Id INT
				--SET @Tabla_TareasPendientes_Id = (SELECT id FROM Tablas WHERE Nombre = 'TareasPendientes')
			
				SELECT * FROM 
						(SELECT	--TARPEND.id 
						COALESCE(U.Apellido + N', ' + U.Nombre, 'Sin asignar') AS [Usuario Asignado]
						,TARPEND.Nombre as Nombre
						,dbo.ufc_HTML_to_Varchar (TARPEND.Texto) as Texto
						,PRI.Nombre AS Prioridad
						,COALESCE(TAB.Nombre, '') AS Tabla
						,COALESCE(PAG.Nombre, '') AS Pagina
						,EDTARPEND.Nombre AS Estado
						,TARPEND.FechaDeCreacion AS [Fecha de creacion]
						,TARPEND.FechaDeCumplimiento AS [Fecha de cumplimiento]
												
				FROM TareasPendientes TARPEND
				--	INNER JOIN LogRegistros LREG ON LREG.Tabla_Id = @Tabla_TareasPendientes_Id AND LREG.Registro_Id = TARPEND.id AND LREG.TipoDe_LogRegistro_Id = 1 -- 1:CREADO
					LEFT JOIN Usuarios U ON TARPEND.UsuarioAsignado_Id = U.id
				--	INNER JOIN Usuarios U ON LREG.UsuarioQueEjecuta_Id = U.id
				--	INNER JOIN Usuarios U3 ON TARPEND.UsuarioQueSolicita_Id = U3.id
					INNER JOIN EstadosDeTareasPendientes EDTARPEND ON TARPEND.Estado_Id = EDTARPEND.id
					INNER JOIN Prioridades PRI ON TARPEND.Prioridad_Id = PRI.id
					LEFT JOIN Tablas TAB ON TAB.id = TARPEND.Tabla_Id
					LEFT JOIN Paginas PAG ON PAG.id = TARPEND.Pagina_Id
					
				WHERE 
					(@EstadoDe_TareasPendientes_Id = '-1' OR TARPEND.Estado_Id = @EstadoDe_TareasPendientes_Id)
					AND(@Prioridad_Id = '-1' OR TARPEND.Prioridad_Id = @Prioridad_Id)
					AND
					(
						(@Filtro = '')
						OR (TARPEND.Nombre LIKE '%' + @Filtro + '%')
						OR (TARPEND.Texto LIKE '%' + @Filtro + '%')
						--OR (TARPEND.Observaciones LIKE '%' + @Filtro + '%')
					) 
					)AS tmp
					ORDER BY tmp.[Fecha de creacion] DESC
				--ORDER BY CASE
				--	WHEN @OrdenarPor = 'Fecha de creacion' AND @Sentido = '0' THEN RANK() OVER (ORDER BY TARPEND.FechaDeCreacion)
				--	WHEN @OrdenarPor = 'Fecha de creacion' AND @Sentido = '1' THEN RANK() OVER (ORDER BY TARPEND.FechaDeCreacion DESC)
				--	WHEN @OrdenarPor = 'Nombre' AND @Sentido = '0' THEN RANK() OVER (ORDER BY TARPEND.Nombre)
				--	WHEN @OrdenarPor = 'Nombre' AND @Sentido = '1' THEN RANK() OVER (ORDER BY TARPEND.Nombre DESC)
				--	WHEN @OrdenarPor = 'Usuario asignado' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U.Apellido , U.Nombre)
				--	WHEN @OrdenarPor = 'Usuario asignado' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U.Apellido DESC, U.Nombre DESC)  
				--	WHEN @OrdenarPor = 'Prioridad' AND @Sentido = '0' THEN RANK() OVER (ORDER BY PRI.Orden, PRI.Nombre)
				--	WHEN @OrdenarPor = 'Prioridad' AND @Sentido = '1' THEN RANK() OVER (ORDER BY PRI.Orden DESC, PRI.Nombre DESC)
				--	WHEN @OrdenarPor = 'Estado' AND @Sentido = '0' THEN RANK() OVER (ORDER BY EDTARPEND.Nombre)
				--	WHEN @OrdenarPor = 'Estado' AND @Sentido = '1' THEN RANK() OVER (ORDER BY EDTARPEND.Nombre DESC)
				--	WHEN 1=1 THEN RANK() OVER (ORDER BY TARPEND.FechaDeCreacion DESC) END -- CASE ELSE
				END
		END 
GO

-- SP-TABLA: TareasPendientes - INICIO  -- 39


-- SP-TABLA: TiposDeActores - INICIO, -- 49
IF (OBJECT_ID('usp_TiposDeActores___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_TiposDeActores___listado_cFiltros
GO
CREATE PROCEDURE usp_TiposDeActores___listado_cFiltros
		@UsuarioQueEjecuta_Id		INT
		
		,@OrdenarPor				VARCHAR(50)
		,@Sentido					BIT
		,@Filtro					VARCHAR(50)
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
	
		SET @sResSQL = ''
		SELECT  id
				,Observaciones			
				,Nombre
		FROM TiposDeActores

		WHERE  
			(
				(@Filtro = '')
				OR (Nombre LIKE '%' + @Filtro + '%')
				OR (Observaciones LIKE '%' + @Filtro + '%')
			)
		ORDER BY CASE 
			WHEN @OrdenarPor = 'Nombre' AND @Sentido = '0' THEN RANK() OVER (ORDER BY Nombre)
			WHEN @OrdenarPor = 'Nombre' AND @Sentido = '1' THEN RANK() OVER (ORDER BY Nombre DESC)
			END	

	END
GO




IF (OBJECT_ID('usp_TiposDeActores___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_TiposDeActores___listado_DDL_o_CBXL 
GO
CREATE PROCEDURE usp_TiposDeActores___listado_DDL_o_CBXL 
		@UsuarioQueEjecuta_Id		INT
		
		,@Formato_Listado			SMALLINT = 1
		,@OcultarActoresUnicos		BIT = 0
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		DECLARE @MinId AS INT
		EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado
		
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT 
		
		--	SELECT    'Return Value' = @return_value
		--SET @MinId = (SELECT ufc_MinimoId_inDDLs(@Formato_Listado))
		
		SELECT	 id
				,Data 
				
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
						
		UNION
		SELECT	id
				,Nombre AS Data
				
		FROM TiposDeActores
		WHERE id >= @MinId
			AND (
					@OcultarActoresUnicos = 0 
					OR 
					(--CHEQUEO QUE NO EXISTA COMITENTE PARA LISTAR COMITENTE
						(SELECT COUNT(id) FROM Actores WHERE TipoDe_Actor_Id = 3 AND Contexto_Id = @Contexto_Id) = 0
						AND
						id = 3
					)
					OR 
					(--CHEQUEO QUE NO EXISTA SUPERVISION PARA LISTAR SUPERVISION
						(SELECT COUNT(id) FROM Actores WHERE TipoDe_Actor_Id = 1 AND Contexto_Id = @Contexto_Id) = 0
						AND
						id = 1
					)
					OR 
					(--SIEMPRE LISTO CONTRATISTA Y EXTERNO
						id <> 1 AND id <> 3
					)
				)
		ORDER BY Data
	END
GO
-- SP-TABLA: TiposDeActores - FIN




-- SP-TABLA: TiposDeDatos - INICIO,  -- 44 
IF (OBJECT_ID('usp_TiposDeDatos___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_TiposDeDatos___listado_cFiltros
GO
CREATE PROCEDURE usp_TiposDeDatos___listado_cFiltros
		@UsuarioQueEjecuta_Id		INT
		
		,@OrdenarPor				VARCHAR(50)
		,@Sentido					BIT
		,@Filtro					VARCHAR(50)
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
		
		
	AS
	BEGIN
	
		SET @sResSQL = ''
		SELECT	TDDATOS.id
				,TDDATOS.NombreSQL
				,TDDATOS.NombreDotNET
				,TDDATOS.Observaciones
		FROM TiposDeDatos TDDATOS
		WHERE 
			(
				(@Filtro = '')
				OR (TDDATOS.NombreSQL LIKE '%' + @Filtro + '%')
				OR (TDDATOS.NombreDotNET LIKE '%' + @Filtro + '%')
			)
		ORDER BY CASE 
			WHEN @OrdenarPor = 'Nombre' AND @Sentido = '0' THEN RANK() OVER (ORDER BY TDDATOS.NombreSQL)
			WHEN @OrdenarPor = 'Nombre' AND @Sentido = '1' THEN RANK() OVER (ORDER BY TDDATOS.NombreSQL DESC)
			WHEN @OrdenarPor = 'Observaciones' AND @Sentido = '0' THEN RANK() OVER (ORDER BY TDDATOS.Observaciones)
			WHEN @OrdenarPor = 'Observaciones' AND @Sentido = '1' THEN RANK() OVER (ORDER BY TDDATOS.Observaciones DESC)
			END	
	END
GO




IF (OBJECT_ID('usp_TiposDeDatos___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_TiposDeDatos___listado_DDL_o_CBXL 
GO
CREATE PROCEDURE usp_TiposDeDatos___listado_DDL_o_CBXL 
		@UsuarioQueEjecuta_Id		INT
		
		,@Formato_Listado			SMALLINT = 1
		,@Activo			BIT = 1
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
		
		
	AS
	BEGIN
	
		SET @sResSQL = ''
		DECLARE @MinId AS INT
		EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado

		--	SELECT    'Return Value' = @return_value
		--SET @MinId = (SELECT ufc_MinimoId_inDDLs(@Formato_Listado))
		
		SELECT	 id
				,Data 
				
		FROM ufc_Adds_To_DDLs(@Formato_Listado)
						
		UNION
		SELECT	TDDATOS.id
				,TDDATOS.NombreDotNET + ' / ' + TDDATOS.NombreSQL AS Data
				
		FROM TiposDeDatos	TDDATOS
		WHERE TDDATOS.id >= @MinId
		ORDER BY Data
	END
GO
-- SP-TABLA: TiposDeDatos - FIN




-- SP-TABLA: TiposDeLogErrores - INICIO, -- 32

-- SP-TABLA: TiposDeLogErrores - FIN




-- SP-TABLA: TiposDeLogLogins - INICIO, -- 33

-- SP-TABLA: TiposDeLogLogins - FIN




-- SP-TABLA: TiposDeLogRegistros - INICIO, -- 34

-- SP-TABLA: TiposDeLogRegistros - FIN




-- SP-TABLA: TiposDePaginas - INICIO, -- 35

-- SP-TABLA: TiposDePaginas - FIN




-- SP-TABLA: Usuarios - INICIO, -- 39
IF (OBJECT_ID('usp_Usuarios___listado_cFiltros') IS NOT NULL) DROP PROCEDURE usp_Usuarios___listado_cFiltros
GO
CREATE PROCEDURE usp_Usuarios___listado_cFiltros
		@UsuarioQueEjecuta_Id							INT
		
		,@OrdenarPor									VARCHAR(50)	
		,@Sentido										BIT
		,@Filtro										VARCHAR(50)
		
		,@Activo										BIT = NULL
		
		,@sResSQL										VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT 
		
		--IF @sResSQL = '' OR @Contexto_Id = 0
		--	EXEC usp_VAL_Contexto_Id__by__MasterAdmin_o_Administrador @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
		SET @sResSQL = ''
		--IF @sResSQL = ''
		--	BEGIN
				SELECT U.id 
						,U.LogonName + '@' + CON.Codigo AS UserName 
						,U.Apellido + N', ' + U.Nombre AS NombreCompleto
						,U.Email
						,ACT.Nombre AS Actor
						,N'images/cbx/img_' + convert(varchar(5),U.Activo) + N'.jpg' AS imgActivo
						
				FROM Usuarios U
					INNER JOIN RelAsig__RolesDeUsuarios__A__Usuarios RARU ON RARU.Usuario_Id = U.id
					INNER JOIN RolesDeUsuarios RDU ON RDU.id = RARU.RolDe_Usuario_Id 
					INNER JOIN Actores ACT ON U.Actor_Id = ACT.id
					INNER JOIN Contextos CON ON CON.id = U.Contexto_Id
									
				WHERE
					(U.Contexto_Id = @Contexto_Id)
					AND
					(U.UsuarioDeSistema = 0)
					AND
					(U.Activo = @Activo OR @Activo IS NULL)
					--AND 
					--(RDU.id NOT IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_ExclusionesDe_RolesDeUsuarios)))
					AND
					(
						(@Filtro = '')
						OR (U.LogonName LIKE '%' + @Filtro + '%')
						OR (U.Nombre LIKE '%' + @Filtro + '%')
						OR (U.Apellido LIKE '%' + @Filtro + '%')
						OR (U.Email LIKE '%' + @Filtro + '%')
					)
				GROUP BY U.id, U.LogonName, CON.Codigo, U.Apellido, U.Nombre, U.Email, U.Activo,ACT.Nombre
				ORDER BY CASE 
					WHEN @OrdenarPor = 'Actor' AND @Sentido = '0' THEN RANK() OVER (ORDER BY ACT.Nombre, U.LogonName)  
					WHEN @OrdenarPor = 'Actor' AND @Sentido = '1' THEN RANK() OVER (ORDER BY ACT.Nombre DESC, U.LogonName DESC)  
					WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U.LogonName)  
					WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U.LogonName DESC)  
					WHEN @OrdenarPor = 'Nombre Completo' AND @Sentido = '0' THEN RANK() OVER (ORDER BY U.Apellido, U.Nombre)  
					WHEN @OrdenarPor = 'Nombre Completo' AND @Sentido = '1' THEN RANK() OVER (ORDER BY U.Apellido DESC, U.Nombre DESC, U.LogonName DESC)  
					WHEN 1=1 THEN RANK() OVER (ORDER BY U.LogonName) END -- CASE ELSE
			END
	--END
GO




IF (OBJECT_ID('usp_Usuarios___listado_DeNotas') IS NOT NULL) DROP PROCEDURE usp_Usuarios___listado_DeNotas
GO
CREATE PROCEDURE usp_Usuarios___listado_DeNotas 
		@UsuarioQueEjecuta_Id		INT
		
		--,@OrdenarPor				VARCHAR(50)
		--,@Sentido					BIT
		--,@Filtro					VARCHAR(50)
		
		,@sResSQL					VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT
		
		IF @sResSQL = ''
			BEGIN
				DECLARE @Orden	INT
				SELECT  @Orden = Orden
				FROM EstadosDeContextos EDC
					INNER JOIN Contextos CONT ON EDC.id = CONT.EstadoDe_Contexto_Id 
				WHERE  (CONT.id = @Contexto_Id)
				
				DECLARE @MostrarNotas		BIT
				SELECT @MostrarNotas = 
					CASE
						WHEN @Orden IS NULL THEN 0
						WHEN @Orden < 100 THEN 1
						ELSE 0
					END
					
				IF @MostrarNotas = 1
					BEGIN
						SELECT EDC.id
								,EDC.Nombre AS NombreDe_EstadoDe_Contexto
								,PAG.Nombre AS Pagina
								
						FROM EstadosDeContextos EDC
							INNER JOIN Contextos CONT ON EDC.id = CONT.EstadoDe_Contexto_Id 
							INNER JOIN Paginas PAG ON EDC.Pagina_Id = PAG.id 
							
						WHERE  (CONT.id = @Contexto_Id)
					END
				ELSE
					BEGIN
						SET @sResSQL = 'No hay notas para mostrar.' 
					END
			END
	END
GO



			   
IF (OBJECT_ID('usp_Usuarios___listado_DDL_o_CBXL_by_@RolDe_Usuario_Id') IS NOT NULL) DROP PROCEDURE usp_Usuarios___listado_DDL_o_CBXL_by_@RolDe_Usuario_Id
GO
CREATE PROCEDURE usp_Usuarios___listado_DDL_o_CBXL_by_@RolDe_Usuario_Id
		@UsuarioQueEjecuta_Id							INT
		
		,@Formato_Listado								SMALLINT = 1
		
		,@sResSQL										VARCHAR(1000)			OUTPUT
		
		,@Activo										BIT = 1
		,@RolDe_Usuario_Id								INT
		
		,@AgregarSinAsignar								BIT = 0
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT 
		
		--IF @sResSQL = '' OR @Contexto_Id = 0
		--	EXEC usp_VAL_Contexto_Id__by__MasterAdmin_o_Administrador @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
				
		IF @sResSQL = ''
			BEGIN
				DECLARE @MinId AS INT
				EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado
			
				SELECT	 id
						,Data 
			
				FROM ufc_Adds_To_DDLs(@Formato_Listado)
				
				UNION
				
				SELECT -3 AS id
						,'- Sin Asignar -' AS Data
				WHERE @AgregarSinAsignar = 1
			
				UNION
				SELECT	U.id, 
						U.Apellido  + N', ' + U.Nombre   + N' - (' +  U.LogonName + '@' + CON.Codigo + N')' AS Data
					
				FROM Usuarios U
					INNER JOIN RelAsig__RolesDeUsuarios__A__Usuarios RARU ON RARU.Usuario_Id = U.id
					INNER JOIN RolesDeUsuarios RDU ON RDU.id = RARU.RolDe_Usuario_Id
					INNER JOIN Contextos CON ON CON.id = U.Contexto_Id
									 
				WHERE (U.id >= @MinId)
					AND
					(U.Contexto_Id = @Contexto_Id)
					AND
					(U.UsuarioDeSistema = 0)
					--AND
					--(RDU.id NOT IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_ExclusionesDe_RolesDeUsuarios)))
					AND
					(U.id IN (SELECT Usuario_Id FROM RelAsig__RolesDeUsuarios__A__Usuarios WHERE RolDe_Usuario_Id = @RolDe_Usuario_Id))
					AND
					(U.Activo = 1 OR @Activo = 0)
				GROUP BY U.id, U.Apellido, U.Nombre, U.LogonName, CON.Codigo
				ORDER BY Data
			END
	END
GO




IF (OBJECT_ID('usp_Usuarios___listado_DDL_o_CBXL') IS NOT NULL) DROP PROCEDURE usp_Usuarios___listado_DDL_o_CBXL
GO
CREATE PROCEDURE usp_Usuarios___listado_DDL_o_CBXL
		@UsuarioQueEjecuta_Id							INT
		
		,@Formato_Listado								SMALLINT = 1
		
		,@Activo										BIT = 1
		
		,@sResSQL										VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		DECLARE @Contexto_Id	INT
		EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT 
		
		--IF @sResSQL = '' OR @Contexto_Id = 0
		--	EXEC usp_VAL_Contexto_Id__by__MasterAdmin_o_Administrador @Usuario_Id = @UsuarioQueEjecuta_Id, @sResSQL = @sResSQL OUTPUT
		SET @sResSQL = ''
		--IF @sResSQL = ''
		--	BEGIN
				DECLARE @MinId AS INT
				EXEC    @MinId = dbo.[ufc_MinimoId_inDDLs]	@Formato_Listado = @Formato_Listado
			
				SELECT	 id
						,Data 
			
				FROM ufc_Adds_To_DDLs(@Formato_Listado)
			
				UNION
				SELECT	U.id, 
						U.Apellido  + N', ' + U.Nombre   + N' - (' +  U.LogonName + '@' + CON.Codigo + N')' AS Data
					
				FROM Usuarios U
					INNER JOIN Contextos CON ON CON.id = U.Contexto_Id
					--INNER JOIN RelAsig__RolesDeUsuarios__A__Usuarios RARU ON RARU.Usuario_Id = U.id
					--INNER JOIN RolesDeUsuarios RDU ON RDU.id = RARU.RolDe_Usuario_Id 
				WHERE (U.id >= @MinId)
					AND
					(U.Contexto_Id = @Contexto_Id)
					AND
					(U.UsuarioDeSistema = 0)
					AND
					(U.Activo = 1 OR @Activo = 0)
					--AND
					--(RDU.id NOT IN(SELECT id FROM ufc_IDs_String_ToTable_INT(@ID_String_ExclusionesDe_RolesDeUsuarios)))
					--AND
					--(@Rol_Id = '-1' OR U.id IN (SELECT Usuario_Id FROM RelAsig__RolesDeUsuarios__A__Usuarios WHERE RolDe_Usuario_Id = @Rol_Id))
				GROUP BY U.id, U.Apellido, U.Nombre, U.LogonName, CON.Codigo
				ORDER BY Data
			END
	--END
GO




IF (OBJECT_ID('usp_Usuarios___listado_DDL_o_CBXL_Todos') IS NOT NULL) DROP PROCEDURE usp_Usuarios___listado_DDL_o_CBXL_Todos
GO
CREATE PROCEDURE usp_Usuarios___listado_DDL_o_CBXL_Todos
		@UsuarioQueEjecuta_Id							INT
		
		,@Formato_Listado								SMALLINT = 1		-- No se usa
		,@Activo			BIT = 1		-- No se usa
		
		,@sResSQL										VARCHAR(1000)			OUTPUT
	AS
	BEGIN
		SET @sResSQL = ''
		
		SELECT	 '-1' AS id
				,' - Todos - ' AS Data
		UNION
		
		SELECT	 '0' AS id
				,' - Error de Login - ' AS Data
	
		UNION
		SELECT	U.id, 
				U.Apellido  + N', ' + U.Nombre   + N' (' +  U.LogonName + '@' + CON.Codigo + N')' AS Data
			
		FROM Usuarios U
			INNER JOIN RelAsig__RolesDeUsuarios__A__Usuarios RARU ON RARU.Usuario_Id = U.id
			INNER JOIN RolesDeUsuarios RDU ON RDU.id = RARU.RolDe_Usuario_Id
			INNER JOIN Contextos CON ON CON.id = U.Contexto_Id 
		WHERE (U.id >= '0')
			AND
			(U.UsuarioDeSistema = 0)
		GROUP BY U.id, U.Apellido, U.Nombre, U.LogonName, CON.Codigo
		ORDER BY id
	END
GO




IF (OBJECT_ID('usp_Usuarios___listado_cFiltros_cPag') IS NOT NULL) DROP PROCEDURE usp_Usuarios___listado_cFiltros_cPag
GO
CREATE PROCEDURE usp_Usuarios___listado_cFiltros_cPag
		@OrdenarPor					VARCHAR(50)
		,@Sentido					BIT
		,@Filtro					VARCHAR(50)
		
		,@Activo					BIT = NULL
		
		,@RegistrosPorPagina		INT = -1
		,@NumeroDePagina			INT = 1
		,@TotalDeRegistros			INT	= 0			OUTPUT		
        ,@sResSQL					VARCHAR(1000)			OUTPUT
        ,@UsuarioQueEjecuta_Id		INT
    AS
	BEGIN
    SET @sResSQL = ''
    
    DECLARE @Contexto_Id	INT
	EXEC	@Contexto_Id = dbo.[usp_VAL_Contexto_Id__by__Usuario_Id]  @Usuario_Id = @UsuarioQueEjecuta_Id,  @sResSQL = @sResSQL OUTPUT 
    	
    IF @RegistrosPorPagina = -1  -- Sin paginación
		BEGIN
			SELECT	U.id
						,A.Nombre AS Actor
						,U.LogonName
						,U.Apellido + ', ' + U.Nombre AS NombreCompleto
						,U.Email
						,U.Email2
						,U.Telefono
						,U.Telefono2
						,U.Direccion
						,U.Observaciones
						,N'images/cbx/img_' + convert(varchar(5),U.Activo) + N'.jpg' AS imgActivo
						,0 AS 'TotalDeRegistros' -- Lo necesito solo p/ q NO de error.
													
				FROM Usuarios U
				INNER JOIN Actores A ON U.Actor_Id = A.Id
				WHERE 
					(U.id > '0')
					AND(U.Activo = @Activo OR @Activo IS NULL)
					AND U.Contexto_Id = @Contexto_Id
					AND
					(
						(@Filtro = '')
						OR (A.Nombre LIKE '%' + @Filtro + '%')
						OR (U.LogonName LIKE '%' + @Filtro + '%')
						OR (U.Apellido + ', ' + U.Nombre LIKE '%' + @Filtro + '%')
						OR (U.Email LIKE '%' + @Filtro + '%')
					)
			ORDER BY 
				CASE WHEN @OrdenarPor = 'Actor' AND @Sentido = '0' THEN  A.Nombre END
				,CASE WHEN @OrdenarPor = 'Actor' AND @Sentido = '1' THEN  A.Nombre END DESC
				,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN  U.LogonName END
				,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN  U.LogonName END DESC
						
			 
		END
    ELSE
		BEGIN
			SELECT * INTO #TempTable
			FROM
			(
			   SELECT	U.id
						,A.Nombre AS Actor
						,U.LogonName
						,U.Apellido + ', ' + U.Nombre AS NombreCompleto
						,U.Email
						,U.Email2
						,U.Telefono
						,U.Telefono2
						,U.Direccion
						,U.Observaciones
						,N'images/cbx/img_' + convert(varchar(5),U.Activo) + N'.jpg' AS imgActivo
						,ROW_NUMBER() OVER 
							(
								ORDER BY 
								CASE WHEN @OrdenarPor = 'Actor' AND @Sentido = '0' THEN  A.Nombre END
								,CASE WHEN @OrdenarPor = 'Actor' AND @Sentido = '1' THEN  A.Nombre END DESC
								,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '0' THEN  U.LogonName END
								,CASE WHEN @OrdenarPor = 'LogonName' AND @Sentido = '1' THEN  U.LogonName END DESC
								,CASE WHEN @OrdenarPor = 'Email' AND @Sentido = '0' THEN  U.Email END
								,CASE WHEN @OrdenarPor = 'Email' AND @Sentido = '1' THEN  U.Email END DESC
							) 
						AS NumeroDeRegistro
													
				FROM Usuarios U
				INNER JOIN Actores A ON U.Actor_Id = A.Id
				WHERE 
					(U.id > '0')
					AND(U.Activo = @Activo OR @Activo IS NULL)
					AND U.Contexto_Id = @Contexto_Id
					AND
					(
						(@Filtro = '')
						OR (A.Nombre LIKE '%' + @Filtro + '%')
						OR (U.LogonName LIKE '%' + @Filtro + '%')
						OR (U.Apellido + ', ' + U.Nombre LIKE '%' + @Filtro + '%')
						OR (U.Email LIKE '%' + @Filtro + '%')
					)
			) Query
	
			SELECT	id
					,Actor
					,LogonName
					,NombreCompleto
					,Email
					,Email2
					,Telefono
					,Telefono2
					,Direccion
					,Observaciones
					,imgActivo
					,(SELECT MAX(NumeroDeRegistro) FROM #TempTable) AS 'TotalDeRegistros'
			 
			FROM  #TempTable
			WHERE NumeroDeRegistro BETWEEN ((@NumeroDePagina - 1) * @RegistrosPorPagina) + 1
											AND @RegistrosPorPagina * (@NumeroDePagina)
											
		
			SET @TotalDeRegistros = (SELECT	COUNT(*) FROM  #TempTable)
			DROP TABLE #TempTable
		END
    END
GO
-- SP-TABLA: Usuarios - FIN


-- ---------------------------------
-- 18__Core__SP_LISTADOS - Fin de la creacion
-- =====================================================

