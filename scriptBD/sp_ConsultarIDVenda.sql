
USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_ConsultarIDVenda', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_ConsultarIDVenda;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE sp_ConsultarIDVenda(@IDUsuario INT,@IDForn_prod INT,@DataVenda date,@TotalDaVenda Decimal(10,2))
AS
BEGIN

	SET NOCOUNT ON; 


	SELECT	    IDVenda
		  FROM Venda
		  where IDUsuario = @IDUsuario and IDForn_prod = @IDForn_prod and DataVenda = @DataVenda and TotalDaVenda = @TotalDaVenda


END
GO
--exec sp_ConsultarIDVenda'1','1','2015/11/16','36'
