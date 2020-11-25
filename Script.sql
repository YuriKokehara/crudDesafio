create database FrotaDeCarros
go
use FrotaDeCarros
go

create table Carros
(
  IdCarro		int				primary key   identity,
  Marca        nvarchar(30)		not null,
  Modelo       nvarchar(30)		not null,
  Cor			nvarchar(30)	not null,
  AnoFabric		int
)

CREATE PROCEDURE ExcluirCarroPorId
(
	@IdCarro int
)

as

begin
	Delete From Carros where IdCarro = @IdCarro
end


CREATE PROCEDURE AtualizarCarro
(
	@IdCarro int,
	@Marca nvarchar(30),
	@Modelo nvarchar(30),
	@Cor nvarchar(30),
	@AnoFabric int
)

as

begin
	Update Carros set Marca = @Marca, Modelo = @Modelo, 
						Cor = @Cor, AnoFabric = @AnoFabric
						where IdCarro = @IdCarro
end


CREATE PROCEDURE IncluirCarro
(
	@Marca nvarchar(30),
	@Modelo nvarchar(30),
	@Cor nvarchar(30),
	@AnoFabric int
)

as

begin
	Insert into Carros values (@Marca, @Modelo, @Cor, @AnoFabric)
end

CREATE PROCEDURE ListarCarros

as

begin
	Select IdCarro, Marca, Modelo, Cor, AnoFabric from Carros
end

