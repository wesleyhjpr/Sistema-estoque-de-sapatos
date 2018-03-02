
USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_ConsultarUser', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_ConsultarUser;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_ConsultarUser(@IDUser INT)
AS
BEGIN

	SET NOCOUNT ON; 


	SELECT	   IDUsuario
			  ,Nome
			  ,senha
			  ,sexo
			  ,telefone
			  ,email
			  ,endereco
			  ,cargo
			  ,datanasc
			  ,status
		  FROM Usuario
		  where IDUsuario = @IDUser


END
GO
exec sp_ConsultarUser 1
