USE LojaSapatos
GO
-- VERIFICA SE A PROCEDURE JA EXISTE E SE EXISTIR APAGA A MESMA DO BANCO
IF OBJECT_ID ( 'sp_AtualizarUser', 'P' ) IS NOT NULL 
    DROP PROCEDURE sp_AtualizarUser;
GO


SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON 
GO

CREATE PROCEDURE sp_AtualizarUser(@IDUser INT,@Nome varchar(50),@Senha varchar(50),@Sexo varchar(1),@Telefone varchar(50),@Email varchar(50),@Endereco varchar(50),@Cargo varchar(50),@Datanasc date,@Status varchar(1))
AS
BEGIN

	SET NOCOUNT ON; 
	BEGIN TRANSACTION

	BEGIN TRY

	Update Usuario
		SET	   nome = @Nome
			  ,senha = @Senha
			  ,sexo = @Sexo
			  ,telefone = @Telefone
			  ,email = @Email
			  ,endereco = @Endereco
			  ,cargo = @Cargo
			  ,datanasc =@Datanasc
			  ,status = @Status
		  where IDUsuario = @IDUser
	COMMIT TRANSACTION

	END TRY
	BEGIN CATCH
	-- SE OCORRER ERRO TODAS AS ALTERERACOES DEVEM SER REVERTIDAS
	  ROLLBACK TRANSACTION 
	END CATCH 

END
GO
--exec sp_AtualizarUser 3,'p','321','F','(22)2222-2222','m@dfxm','R lkadlakdl','Caixa','2015-11-01','I'
