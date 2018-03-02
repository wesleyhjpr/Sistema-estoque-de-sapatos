USE LojaSapatos
GO

-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_AtualizarFornecedor', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_AtualizarFornecedor;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE sp_AtualizarFornecedor(@CNPJ varchar(50),@Nome varchar(50),@Telefone varchar(50),@Endereco varchar(50))
AS
BEGIN

	SET NOCOUNT ON; 
	BEGIN TRANSACTION

	BEGIN TRY

	Update Fornecedor
		SET	   CNPJ = @CNPJ
			  ,Nome = @Nome
			  ,Telefone = @Telefone
			  ,Endereco = @Endereco
		  where CNPJ = @CNPJ
	COMMIT TRANSACTION

	END TRY
	BEGIN CATCH
	-- SE OCORRER ERRO TODAS AS ALTERERACOES DEVEM SER REVERTIDAS
	  ROLLBACK TRANSACTION 
	END CATCH 

END
GO
