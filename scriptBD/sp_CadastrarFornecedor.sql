USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_CadastrarFornecedor', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_CadastrarFornecedor;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE sp_CadastrarFornecedor(@CNPJ varchar(50),@Nome varchar(50),@Telefone varchar(50),@Endereco varchar(50))
AS
BEGIN

	SET NOCOUNT ON;
	BEGIN TRANSACTION
	BEGIN TRY

	insert into  Fornecedor
	          (CNPJ
			  ,Nome  
			  ,Telefone
			  ,Endereco 
			  )values(@CNPJ,@Nome,@Telefone,@Endereco) 
			  COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
	-- SE OCORRER ERRO TODAS AS ALTERERACOES DEVEM SER REVERTIDAS
	  ROLLBACK TRANSACTION 
	END CATCH  
END
GO
--exec sp_CadastrarFornecedor '00,000,000/0000-00','fornec','(22)2222-2222','R lkadlakdl'

select * from Fornecedor
--exec sp_CadastrarUser 'ssssssss','123','M','(11)1111-1111','1231213','2112312','Vendedor','2015/11/30','A'