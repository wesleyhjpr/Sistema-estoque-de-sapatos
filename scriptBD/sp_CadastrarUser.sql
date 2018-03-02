USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_CadastrarUser', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_CadastrarUser;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE sp_CadastrarUser(@Nome varchar(50),@Senha varchar(50),@Sexo varchar(1),@Telefone varchar(50),@Email varchar(50),@Endereco varchar(50),@Cargo varchar(50),@Datanasc date,@Status varchar(1))
AS
BEGIN

	SET NOCOUNT ON; 
	BEGIN TRANSACTION
	BEGIN TRY

	insert into  Usuario
	          (
			   nome  
			  ,senha 
			  ,sexo  
			  ,telefone  
			  ,email  
			  ,endereco 
			  ,cargo  
			  ,datanasc 
			  ,status 
			  )values(@Nome,@Senha,@Sexo,@Telefone,@Email,@Endereco,@Cargo,@Datanasc,@Status) 
			  COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
	-- SE OCORRER ERRO TODAS AS ALTERERACOES DEVEM SER REVERTIDAS
	  ROLLBACK TRANSACTION 
	END CATCH  
END
GO
exec sp_CadastrarUser 'admin','123','M','(22)2222-2222','m@dfxm1','R lkadlakdl','Gerente','2015-11-01','A'

select * from Usuario 

--exec sp_CadastrarUser 'ssssssss','123','M','(11)1111-1111','1231213','2112312','Vendedor','2015/11/30','A'