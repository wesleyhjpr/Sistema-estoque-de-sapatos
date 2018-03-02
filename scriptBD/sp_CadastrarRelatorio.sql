USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_CadastrarRelatorio', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_CadastrarRelatorio;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE sp_CadastrarRelatorio(@IDVenda int,@QuantidadeProdComprados int,@QuantidadeProdVendidos int,@TotalDaVenda Decimal(10,2))
AS
BEGIN

	SET NOCOUNT ON; 
	BEGIN TRANSACTION
	BEGIN TRY

	insert into  Relatorio
	          (IDVenda
			  ,QuantidadeProdComprados
			  ,QuantidadeProdVendidos
			  ,TotalDeVenda			     
			  )values(@IDVenda,@QuantidadeProdComprados,@QuantidadeProdVendidos,@TotalDaVenda) 
			  COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
	-- SE OCORRER ERRO TODAS AS ALTERERACOES DEVEM SER REVERTIDAS
	  ROLLBACK TRANSACTION 
	END CATCH  
END
GO