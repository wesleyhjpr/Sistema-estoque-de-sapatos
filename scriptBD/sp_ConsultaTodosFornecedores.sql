
USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_ConsultaTodosFornecedores', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_ConsultaTodosFornecedores;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE sp_ConsultaTodosFornecedores
AS
BEGIN

	SET NOCOUNT ON;
		SELECT CNPJ
			  ,Nome
			  ,Telefone
			  ,Endereco
		  FROM Fornecedor;
END
GO
