
USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_ConsultarTodosUsers', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_ConsultarTodosUsers;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE sp_ConsultarTodosUsers
AS
BEGIN

	SET NOCOUNT ON; 


	SELECT	   IDUsuario
			  ,Nome
			  ,email
			  ,cargo
			  ,datanasc
			  ,status
		  FROM Usuario;
END
GO