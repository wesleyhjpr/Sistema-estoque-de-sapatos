create database LojaSapatos;
go
use LojaSapatos;
go
create table Usuario
(	
	IDUsuario int identity not null primary key,
	Nome varchar(50) not null,
	Senha varchar(10) not null,
	Sexo char(1) not null,
	Telefone varchar(50) not null,
	Email varchar(50),
	Endereco varchar(50) NOT NULL,
	Cargo varchar(10) not null, 
	Datanasc date not null,
	Status char(1) not null
)
go
create table Produtos
(
	IDProd int identity not null primary key,
	Categoria varchar(20) not null,
	Marca varchar(20) not null,
	Tamanho int not null,
	QuantidadeProduto int not null,
	ValorCompraProd decimal(10,2) not null,
	ValorVendaProd decimal(10,2) not null,
	QuantidadeMaxEstoque int not null,
	QuantidadeMinEstoque int not null
)
go
create table Fornecedor
(
	CNPJ varchar(50) primary key,
	Nome varchar(50)not null,
	Telefone varchar(50) not null,
	Endereco varchar(50) NOT NULL
)
go
create table Forn_Prod
(
	IDForn_Prod int identity not null primary key,
	CNPJ varchar(50) references Fornecedor(CNPJ) not null,
	IDProd int references Produtos(IDProd) not null
)
go
create table Venda
( 
	IDVenda int identity not null primary key,
	IDUsuario int references Usuario(IDUsuario) not null,
	IDForn_Prod int references Forn_Prod(IDForn_Prod) not null,
	DataVenda date not null,
	TotalDaVenda float not null	
)
go
create table Relatorio
(
	CodRelatorio int not null primary key identity,
	IDVenda int references Venda(IDVenda)not null,
	QuantidadeProdComprados int not null,
	QuantidadeProdVendidos int not null,
	TotalDeVenda float not null
)
go
 select * from Venda;
 select * from Relatorio;
 select * from Fornecedor;
 select * from Usuario;
 select * from Produtos;
 select * from Forn_Prod;