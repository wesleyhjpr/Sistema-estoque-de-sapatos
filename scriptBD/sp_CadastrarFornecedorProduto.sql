USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_CadastrarFornecedorProduto', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_CadastrarFornecedorProduto;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE sp_CadastrarFornecedorProduto(@Categoria varchar(50),@Marca varchar(50),@Tamanho int,@QuantidadeProduto int,@ValorCompraProd decimal(10,2),@ValorVendaProd decimal(10,2),@QuantidadeMaxEstoque int,@QuantidadeMinEstoque int)
AS
BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
	BEGIN TRY

	insert into  Produtos
	          (Categoria
			  ,Marca  
			  ,Tamanho
			  ,QuantidadeProduto 
			  ,ValorCompraProd 
			  ,ValorVendaProd 
			  ,QuantidadeMaxEstoque 
			  ,QuantidadeMinEstoque
			  )values(@Categoria,@Marca,@Tamanho,@QuantidadeProduto,@ValorCompraProd,@ValorVendaProd,@QuantidadeMaxEstoque,@QuantidadeMinEstoque) 
			  COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
	-- SE OCORRER ERRO TODAS AS ALTERERACOES DEVEM SER REVERTIDAS
	  ROLLBACK TRANSACTION 
	END CATCH  
END
GO
--exec sp_CadastrarFornecedorProduto '00,000,000/0000-00','fornec','(22)2222-2222','R lkadlakdl'

--select * from sp_CadastrarFornecedorProduto
--exec sp_CadastrarUser 'ssssssss','123','M','(11)1111-1111','1231213','2112312','Vendedor','2015/11/30','A'