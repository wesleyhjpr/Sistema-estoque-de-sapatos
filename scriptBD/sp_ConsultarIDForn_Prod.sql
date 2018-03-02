
USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_ConsultarIDForn_Prod', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_ConsultarIDForn_Prod;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE sp_ConsultarIDForn_Prod(@IDProd INT)
AS
BEGIN

	SET NOCOUNT ON; 


	SELECT	   IDForn_prod
		  FROM Forn_Prod
		  where IDProd = @IDProd


END
GO
--exec sp_ConsultarIDForn_Prod 1
