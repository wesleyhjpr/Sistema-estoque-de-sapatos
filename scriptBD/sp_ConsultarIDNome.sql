
USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_ConsultarIDNome', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_ConsultarIDNome;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE sp_ConsultarIDNome(@email varchar(50))
AS
BEGIN

	SET NOCOUNT ON; 


	SELECT	   IDUsuario
			  ,nome
		  FROM Usuario
		  where email = @email


END
GO
--exec sp_ConsultarIDNome '1'
--exec sp_ConsultarIDNome "rafamascote@hotmail.com"
--exec sp_ConsultarUser '6'