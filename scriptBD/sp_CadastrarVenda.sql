USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_CadastrarVenda', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_CadastrarVenda;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE sp_CadastrarVenda(@IDUsuario int,@IDForn_Prod int,@DataVenda date,@TotalDaVenda Decimal(10,2))
AS
BEGIN

	SET NOCOUNT ON; 
	BEGIN TRANSACTION
	BEGIN TRY

	insert into  Venda
	          (IDUsuario
			  ,IDForn_Prod
			  ,DataVenda
			  ,TotalDaVenda			     
			  )values(@IDUsuario,@IDForn_Prod,@DataVenda,@TotalDaVenda) 
			  COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
	-- SE OCORRER ERRO TODAS AS ALTERERACOES DEVEM SER REVERTIDAS
	  ROLLBACK TRANSACTION 
	END CATCH  
END
GO
--exec sp_CadastrarFornIDProd '1','00,000,000/0000-00'

--select * from sp_CadastrarFornIDProd
--exec sp_CadastrarUser 'ssssssss','123','M','(11)1111-1111','1231213','2112312','Vendedor','2015/11/30','A'