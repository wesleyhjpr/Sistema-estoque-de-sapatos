
USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_ConsultaTodosProdutos', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_ConsultaTodosProdutos;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_ConsultaTodosProdutos
AS
BEGIN

	SET NOCOUNT ON; 
		SELECT * FROM Produtos;
END
GO