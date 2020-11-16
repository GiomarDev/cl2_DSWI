USE BD_EDITORIAL
GO

IF OBJECT_ID('SP_LISTALIBRO') IS NOT NULL 
	DROP PROC SP_LISTALIBRO
GO 
CREATE PROC SP_LISTALIBRO
AS 
	SELECT P.IDE_LIB,P.AUT_LIB,P.TIT_LIB,P.EDI_LIB,P.COS_LIB,P.CAN_LIB,P.FOT_LIB
		FROM dbo.LIBRO P
GO

--select * from LIBRO

/*****************************************************/
	/* L I S T A      A U T O R E S*/
/*****************************************************/
IF OBJECT_ID('SP_LISTAAUTORES') IS NOT NULL 
	DROP PROC SP_LISTAAUTORES
GO
CREATE PROC SP_LISTAAUTORES
AS
	SELECT A.IDE_AUT,
		   A.NOM_AUT,
		   P.NOM_PAI,
		   A.COR_AUT,
		   A.FON_AUT
		FROM AUTOR A JOIN PAIS P ON
			A.IDE_PAI=P.IDE_PAI
GO
/*****************************************************/
	/* L I S T A      P A I S E S*/
/*****************************************************/
IF OBJECT_ID('SP_LISTAPAISES') IS NOT NULL 
	DROP PROC SP_LISTAPAISES
GO
CREATE PROC SP_LISTAPAISES
AS
	SELECT P.IDE_PAI, P.NOM_PAI
	FROM PAIS P 
GO
/*****************************************************/
	/* R E G I S T R A      A U T O R*/
/*****************************************************/
IF OBJECT_ID('SP_NUEVOAUTOR') IS NOT NULL 
	DROP PROC SP_NUEVOAUTOR
GO
CREATE PROC SP_NUEVOAUTOR(@NOM_AUT VARCHAR(40), @IDE_PAI INT, @COR_AUT VARCHAR(50), @FON_AUT VARCHAR(25))
AS
	INSERT INTO AUTOR(NOM_AUT, IDE_PAI, COR_AUT, FON_AUT) 
		VALUES(@NOM_AUT, @IDE_PAI, @COR_AUT, @FON_AUT)
GO
/*****************************************************/
	/* A C T U A L I Z A      A U T O R*/
/*****************************************************/
IF OBJECT_ID('SP_ACTUALIZAAUTOR') IS NOT NULL 
	DROP PROC SP_ACTUALIZAAUTOR
GO
CREATE PROC SP_ACTUALIZAAUTOR(@IDE_AUT INT, @NOM_AUT VARCHAR(40), @IDE_PAI INT, @COR_AUT VARCHAR(50), @FON_AUT VARCHAR(25))
AS
	UPDATE AUTOR
		SET NOM_AUT=@NOM_AUT,IDE_PAI=@IDE_PAI,COR_AUT=@COR_AUT,FON_AUT=@FON_AUT
		WHERE IDE_AUT=@IDE_AUT
GO
/*****************************************************/
	/* E L I M I N A      A U T O R*/
/*****************************************************/
IF OBJECT_ID('SP_ELIMINAAUTOR') IS NOT NULL 
	DROP PROC SP_ELIMINAAUTOR
GO
CREATE PROC SP_ELIMINAAUTOR(@IDE INT)
AS
	DELETE FROM AUTOR WHERE IDE_AUT=@IDE
GO
/*****************************************************/
	/* L I S T A      A U T O R      O R I G I N A L*/
/*****************************************************/
IF OBJECT_ID('SP_AUTOR') IS NOT NULL 
	DROP PROC SP_AUTOR
GO
CREATE PROC SP_AUTOR
AS
	SELECT * FROM AUTOR
GO