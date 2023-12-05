CREATE TABLE Productos(
ProductID int not null primary key,
Descripcion varchar (100) not null,
PrecioVenta decimal not null,
Saldo float not null
);

CREATE TABLE Inventario(
Folio int not null primary key,
Fecha datetime not null,
Total decimal not null,
TipoMovimiento varchar(20) not null
);

CREATE TABLE InventarioDetalle(
Llave int identity (1,1) not null primary key,
Folio int not null,
ProductID int not null,
Cantidad int not null,
FOREIGN KEY (ProductID) REFERENCES Productos(ProductID),
FOREIGN KEY (Folio) REFERENCES Inventario(Folio)
);




