use DevFlixDB
go



SELECT Nombre_Ts, CodSus_Sus FROM Suscripciones
inner join TipoSuscripciones
on CodTipo_Sus= CodTipo_Ts
where estado_Sus =1
go

CREATE PROCEDURE spEliminarUsuarios
(
@IDref INT 
)
AS
DELETE Cuentas
WHERE IDRef_Cu=@IDref
RETURN
GO

CREATE PROCEDURE spEliminarCuenta
(
@IDCuenta INT
)
AS
 delete Cuentas
 WHERE IDCuenta = @IDCuenta exec spEliminarUsuarios @IDCuenta
RETURN
go

/*alter PROCEDURE spModificarUser
(
@Nombre_Cu varchar(50)
)
AS
update Cuentas
set Nombre_Cu=@Nombre_Cu
RETURN
GO

exec spModificarUser dada123*/

CREATE PROCEDURE EliminarCuentaStandard
(
@IDcuenta int
)
AS
delete Cuentas
where IDCuenta=@IDcuenta
RETURN 
GO

CREATE PROCEDURE ModificarNombreCuentaStandard
(
@IDcuenta int,
@Nombre_Cu varchar(50)
)
AS
Update Cuentas
set Nombre_Cu=@Nombre_Cu
where IDCuenta=@IDcuenta
RETURN 
GO

CREATE PROCEDURE ModificarEdadCuentaStandard
(
@IDcuenta int,
@Edad_Cu int
)
AS
Update Cuentas
set Edad_Cu=@Edad_Cu
where IDCuenta=@IDcuenta
RETURN 
GO

CREATE PROCEDURE ModificarURLCuentaStandard
(
@IDcuenta int,
@URLimg varchar(50)
)
AS
Update Cuentas
set URLImagenDefault=@URLimg
where IDCuenta=@IDcuenta
RETURN 
GO

CREATE PROCEDURE spActualizarContrasenia
(
@IDCuenta INT,
@ContraseniaNueva varchar(20) 
)
AS 
UPDATE Cuentas
SET Clave_Cu=@ContraseniaNueva
WHERE IDCuenta=@IDCuenta
RETURN
GO


CREATE PROCEDURE spAgregarCuenta
(
@ID_Pais_Cu char(10) , 
@CodSus_Cu INT,
@Email_Cu VARCHAR(30),
@Clave_Cu VARCHAR(20),
@Nombre_Cu VARCHAR(50),
@PIN_Cu VARCHAR(4),
@Edad_Cu INT,
@IDRef_Cu INT ,
@NROTarjeta_Cu VARCHAR(16),
@Estado_Cu BIT 
)
AS

INSERT INTO Cuentas(ID_Pais_Cu,CodSus_Cu,Email_Cu,Clave_Cu,FechaCreacion_Cu,
Nombre_Cu,PIN_Cu,Edad_Cu,IDRef_Cu,NROTarjeta_Cu,Estado_Cu
)
SELECT @ID_Pais_Cu , @CodSus_Cu, @Email_Cu ,@Clave_Cu ,GETDATE() ,@Nombre_Cu ,
@PIN_Cu ,@Edad_Cu ,@IDRef_Cu ,@NROTarjeta_Cu ,@Estado_Cu  
RETURN
GO

CREATE PROCEDURE spAgregarUsuario
(
@Nombre_Cu varchar(50),
@Edad_Cu int ,
@IdRef_Cu int,
@Estado_Cu bit
)
AS
INSERT INTO Cuentas (FechaCreacion_Cu, Nombre_Cu,Edad_Cu,IDRef_Cu,Estado_Cu)
SELECT GETDATE(),@Nombre_Cu, @Edad_Cu, @IdRef_Cu,@Estado_Cu
RETURN
GO

create procedure spEliminarCatalogo
(

@idContenido char(10)

)
as
delete from Catalogos where Catalogos.IDContenido_Cat=  @idContenido;
RETURN
GO

create procedure spAgregarCatalogo
(
@IDContenido_Cat char(10),
@IDGenero_Cat char(10),
@CodTipo_Cat char(10),
@Sinopsis_Cat varchar(500),
@Duracion_Cat int,
@URLPortada_Cat varchar(100),
@TituloContenido_Cat varchar(50),
@Season_Cat int,
@URLVideo_Cat varchar(100),
@Clasif_Edad_Cat int,
@Estado_Cat bit

)
as
INSERT INTO Catalogos (IDContenido_Cat, IDGenero_Cat, CodTipo_Cat, Sinopsis_Cat,
Duracion_Cat,
URLPortada_Cat,
TituloContenido_Cat,
Season_Cat,
URLVideo_Cat,
Clasif_Edad_Cat,
Estado_Cat)
SELECT @IDContenido_Cat, @IDGenero_Cat, @CodTipo_Cat, @Sinopsis_Cat,
@Duracion_Cat,
@URLPortada_Cat,
@TituloContenido_Cat,
@Season_Cat,
@URLVideo_Cat,
@Clasif_Edad_Cat,
@Estado_Cat
RETURN
GO
-----------------------Genero------------------------
Create procedure spAgregarGenero
(
@IDGenero_Ge CHAR(10),
@NombreGenero_Ge varchar(30)
)
AS INSERT INTO Generos(IDGenero_Ge,NombreGenero_Ge)
select @IDGenero_Ge,@NombreGenero_Ge
return

go


CREATE PROCEDURE spEliminarGenero
(
@NombreGenero_Ge varchar(30)
)
AS
 update Generos
 set estado_GE=0
 WHERE NombreGenero_Ge = @NombreGenero_Ge
RETURN
go
---------------------------------------------------


-------------Paises---------------------------------
Create procedure spAgregarPais
(
@Nombre_Pa varchar(30)
)
AS INSERT INTO Paises(Nombre_Pa)
select @Nombre_Pa
return

go


CREATE PROCEDURE spEliminarPais
(
@Nombre_Pa varchar(30)
)
AS
 update Paises
 set estado_PA=0
 WHERE Nombre_Pa = @Nombre_Pa
RETURN
go
----------------------------------------------------

-------------Favoritos------------------------------
Create procedure spAgregarFavorito
(
@IDContenido_F char(10),
@ID_cuenta int
)
AS INSERT INTO Favoritos(IDContenido_F,ID_cuenta)
select @IDContenido_F, @ID_cuenta
return

go


CREATE PROCEDURE spEliminarFavorito
(
@IDContenido_F char(10),
@ID_cuenta int 
)
AS
DELETE Favoritos
WHERE IDContenido_F = @IDContenido_F AND ID_cuenta = @ID_cuenta
RETURN
go

CREATE PROCEDURE spCargarListViewFavoritos
@IDcuenta int
AS
SELECT TituloContenido_Cat, URLPortada_Cat, IDContenido_F
FROM Favoritos INNER JOIN Catalogos ON IDContenido_Cat = IDContenido_F
WHERE ID_cuenta = @IDcuenta
RETURN
GO

----------------------------------------------------
--Facturacion
----------------------------------------------------


CREATE PROCEDURE spEliminarFacturacion
(
@IDFacturacion int
)
AS
 update Facturacion
 set Estado_F=0
 WHERE IDFacturacion = @IDFacturacion
RETURN
go


CREATE PROCEDURE spAgregarFacturacion
(
@IDFacturacion int ,
@IDCuenta_F int,
@CodSus_F int ,
@Importe_F decimal
)
AS
INSERT INTO Facturacion(
IDFacturacion,
IDCuenta_F,
CodSus_F ,
Fecha_F,
Importe_F 
)
SELECT @IDFacturacion ,
@IDCuenta_F ,
@CodSus_F ,
GETDATE() ,
@Importe_F 
RETURN
GO

--TIPOSUSCRIPCIONES:
CREATE PROCEDURE spEliminarTipoSuscripcion
@CodTipo int
AS
UPDATE TipoSuscripciones SET Estado_Ts= 0 WHERE CodTipo_Ts = @CodTipo
RETURN
GO

CREATE PROCEDURE spAgregarTipoSuscripcion
@CodTipo char(10), @nombre varchar(20), @precio decimal(18,2), @beneficios varchar(200), @cantu int, @estado bit
AS
INSERT INTO TipoSuscripciones(CodTipo_Ts, Nombre_Ts, Precio_Ts, Beneficios_Ts, CantUsuarios_Ts, Estado_Ts)
SELECT @CodTipo, @nombre, @precio, @beneficios, @cantu, @estado
RETURN
GO

--SUSCRIPCIONES:
CREATE PROCEDURE spEliminarSuscripcion
@CodSus int
AS
UPDATE Suscripciones SET estado_Sus = 0 WHERE CodSus_Sus = @CodSus
RETURN
GO

CREATE PROCEDURE spAgregarSuscripcion
@CodTipo char(10), @total decimal (18,2), @fechaCompra date, @estado bit
AS
INSERT INTO Suscripciones(CodTipo_Sus, total_Sus, fechaCompra_Sus, estado_Sus)
SELECT @CodTipo, @total, @fechaCompra, @estado
RETURN
GO

CREATE PROCEDURE spCambiarPlan
(@CodSus int, @Email varchar(30))
AS
UPDATE Cuentas SET CodSus_Cu = @CodSus WHERE Email_Cu = @Email
RETURN
GO

------------------------------------------------------------------------------------------
--REPORTES
------------------------------------------------------------------------------------------

/*ALTER PROC spCantUsuarioxFecha(
@fechaInicio date,
@fechaFin date
)
as

	BEGIN
	select * from Cuentas
	where FechaCreacion_Cu >= @fechaInicio and FechaCreacion_Cu <= @fechaFin 
	and Estado_Cu=1 and Email_Cu <> null 
	END


RETURN 
GO*/
