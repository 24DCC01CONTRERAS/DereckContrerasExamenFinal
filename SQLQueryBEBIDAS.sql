CREATE DATABASE Bebidas_Alcohol;
GO
USE Bebidas_Alcohol;
GO
create table loginapp(
username varchar (50) not null,
passsword varchar (50) not null,
);
insert into loginapp values ('Don bosco','2025')
select * from loginapp;


-- Tabla de productos
CREATE TABLE Bebidas (
    id_Bebidas INT IDENTITY(1,1) PRIMARY KEY,
    nombre_Bebidas NVARCHAR(150) NOT NULL,
    Tipo NVARCHAR(MAX),
    precio DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL DEFAULT 0,
    fecha_registro DATE DEFAULT GETDATE()
);

-- Insertar productos de ejemplo
INSERT INTO Bebidas(nombre_Bebidas, Tipo, precio, stock) VALUES
('Cerveza Gallo', 'Cerveza Nacional', 10.50, 100),
('XL', 'Licor Nacional', 60.00, 120),
('Ron Botran', 'Ron NAcional', 150.00, 100),
('Johny Walker', 'Wiskey Internacional', 300.00, 50);

select  * from Bebidas;

drop database Bebidas_Alcohol;
drop table Bebidas;