USE master
GO 

CREATE DATABASE DevFlixDB
go

Use DevFlixDB
go

CREATE TABLE Paises (
IDPais_Pa  char(10) not null,
Nombre_Pa VARCHAR(30) not null UNIQUE,
estado_PA BIT not null default 1,
CONSTRAINT PK_PAISES PRIMARY KEY (IDPais_Pa)
)
GO

create table Generos 
(
IDGenero_Ge char(10) not null,
NombreGenero_Ge varchar(30) unique not null,
estado_GE BIT not null default 1,
CONSTRAINT PK_Generos PRIMARY KEY (IDGenero_Ge)
)
go


CREATE TABLE TipoSuscripciones
(
CodTipo_Ts char(10) NOT NULL,
Nombre_Ts varchar(20) UNIQUE NOT NULL,
Precio_Ts DECIMAL (18,2) NOT NULL DEFAULT 0,
Beneficios_Ts varchar(200) NOT NULL ,
CantUsuarios_Ts INT NOT NULL DEFAULT 1,
Estado_Ts BIT NOT NULL DEFAULT 1,
CONSTRAINT PK_TipoSuscripcion PRIMARY KEY (CodTipo_Ts)
)
GO

CREATE TABLE Catalogos
(
IDContenido_Cat char(10) NOT NULL,
IDGenero_Cat char(10) NOT NULL,
CodTipo_Cat char(10) NOT NULL,
Sinopsis_Cat varchar(500) NOT NULL,
Duracion_Cat int NOT NULL,
URLPortada_Cat varchar(100) NOT NULL,
TituloContenido_Cat varchar(50) NOT NULL,
Season_Cat int NOT NULL,
URLVideo_Cat varchar(100) NOT NULL,
Clasif_Edad_Cat int NOT NULL,
Estado_Cat bit NOT NULL default 1

CONSTRAINT PK_CATALOGOS PRIMARY KEY (IDContenido_Cat),
CONSTRAINT FK_CATALOGOS_GENEROS FOREIGN KEY (IDGenero_Cat) REFERENCES Generos (IDGenero_Ge),
CONSTRAINT FK_CATALOGOS_TIPOSUSCRIPCION_ FOREIGN KEY (CodTipo_Cat) REFERENCES TipoSuscripciones (CodTipo_Ts)

)
go

CREATE TABLE Suscripciones
(
CodSus_Sus int identity(1,1) NOT NULL,
CodTipo_Sus	char(10) NOT NULL,
total_Sus decimal (18,2) NOT NULL DEFAULT 0,
fechaCompra_Sus	date NOT NULL,
estado_Sus bit NOT NULL DEFAULT 1,
CONSTRAINT PK_Suscripciones PRIMARY KEY (CodSus_Sus),
CONSTRAINT FK_Suscripciones_Tipo FOREIGN KEY (CodTipo_Sus)
REFERENCES TipoSuscripciones (CodTipo_Ts)
)
GO

create table Cuentas
(
IDCuenta int identity(1,1) not null,
ID_Pais_Cu char(10) null,
CodSus_Cu int null,
Email_Cu varchar(30) null,
Clave_Cu varchar(20) null,
FechaCreacion_Cu DATE not null,
Nombre_Cu varchar (50) not null,
PIN_Cu varchar(4) null,
Edad_Cu int not null,
IDRef_Cu int null,
NROTarjeta_Cu varchar(16) null,
URLImagenDefault varchar(100) DEFAULT 'Recursos/Imagenes/usuario.png',
Estado_Cu bit not null,
CONSTRAINT PK_Cuentas PRIMARY KEY (IDCuenta),
CONSTRAINT PK_Cuentas_x_Pais FOREIGN KEY(ID_Pais_Cu)
REFERENCES Paises(IDPais_Pa),
CONSTRAINT FK_Cuentas_x_Suscripciones FOREIGN KEY (CodSus_Cu) 
REFERENCES Suscripciones(CodSus_Sus)
)
go

CREATE TABLE Facturacion
(
IDFacturacion int identity(1,1),
IDCuenta_F int not null,
CodSus_F int not null,
Fecha_F date not null,
Importe_F decimal (18,2) not null,
Estado_F bit default 1,
constraint PK_Facturacion primary key (IDFacturacion),
constraint FK_Facturacion_X_Cuenta foreign key (IDCuenta_F)
references Cuentas(IDCuenta),
constraint FK_Facturacion_X_Suscripcion foreign key(CodSus_F)
references Suscripciones(CodSus_Sus)
)
go

create table Favoritos(
IDContenido_F char(10) not null,
ID_cuenta int not null,
estado_FA BIT not null default 1,
constraint PK_Favoritos PRIMARY KEY (IDContenido_F,ID_cuenta),
constraint FK_Favoritos_Catalogos FOREIGN KEY (IDContenido_F) REFERENCES Catalogos (IDContenido_Cat),
constraint FK_Favoritos_Cuentas FOREIGN KEY (ID_cuenta) REFERENCES Cuentas (IDCuenta)
)
go
