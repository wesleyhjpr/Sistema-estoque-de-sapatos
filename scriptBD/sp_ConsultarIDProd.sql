
USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_ConsultarIDProd', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_ConsultarIDProd;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE sp_ConsultarIDProd(@Categoria varchar(20),@Marca varchar(20),@Tamanho int,@QuantidadeProduto int,@ValorCompraProd decimal(10,2),@ValorVendaProd decimal(10,2),@QuantidadeMaxEstoque int,@QuantidadeMinEstoque int)
AS
BEGIN

	SET NOCOUNT ON; 


	SELECT	   IDProd			  
		  FROM Produtos
		  where Categoria = @Categoria 
			  and marca = @marca 
			  and Tamanho = @Tamanho
			  and QuantidadeProduto = @QuantidadeProduto
			  and ValorCompraProd = @ValorCompraProd
			  and QuantidadeMaxEstoque = @QuantidadeMaxEstoque
			  and QuantidadeMinEstoque = @QuantidadeMinEstoque
END
GO
select * from Produtos
--exec sp_ConsultarIDProd 'Sapato','Nike','34','1','1.00','1.00','1','1'
