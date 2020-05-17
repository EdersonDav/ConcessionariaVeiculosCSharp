# ConcessionariaVeiculosCSharp
🚗 Concessionaria de veículos criada em windows form c# 🚓
# Banco de dados utilizado 🪑🎲
## 🐘 pgAdmin4
## Comandos banco de dados
CREATE DATABASE dbveiculos <br>
 WITH <br>
    OWNER = postgres <br>
    ENCODING = 'UTF8' <br>
    LC_COLLATE = 'Portuguese_Brazil.1252' <br>
    LC_CTYPE = 'Portuguese_Brazil.1252' <br>
    TABLESPACE = pg_default <br>
    CONNECTION LIMIT = -1; <br>

CREATE TABLE fabricante( <br>
	codigo serial primary key not null, <br>
	nome varchar(50) <br>
) <br>

CREATE TABLE veiculo( <br>
  codigo serial primary key not null, <br>
	placa varchar (10), <br>
	id_fabricante serial, <br>
	modelo varchar(100), <br>
	ano int, <br>
	preco_tabela decimal, <br>
	CONSTRAINT idfabricante_fk FOREIGN KEY(id_fabricante) REFERENCES fabricante(codigo) <br>
)

