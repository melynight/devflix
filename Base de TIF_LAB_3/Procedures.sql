use TIF_LAB3
go

--------------------------------CUENTAS--------------------------------
CREATE PROCEDURE spVerCuentas
@estado bit
as
begin 
select * from Cuentas where Estado_Cu = @estado
end
go

CREATE PROCEDURE spEliminarUsuarios
(
@IDref INT 
)
AS
UPDATE Cuentas
SET Cuentas.Estado_Cu=0
WHERE IDRef_Cu=@IDref
RETURN
GO

CREATE PROCEDURE spEliminarCuenta
(
@IDCuenta INT
)
AS
 update Cuentas
 set Cuentas.Estado_Cu=0
 WHERE IDCuenta = @IDCuenta exec spEliminarUsuarios @IDCuenta
RETURN
go

CREATE PROCEDURE EliminarCuentaStandard
(
@IDcuenta int
)
AS
Update Cuentas
set Estado_Cu=0
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

INSERT INTO Cuentas
(
ID_Pais_Cu,CodSus_Cu,Email_Cu,Clave_Cu,Fecha_Suscripcion_Cu,
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
INSERT INTO Cuentas (Fecha_Suscripcion_Cu, Nombre_Cu,Edad_Cu,IDRef_Cu,Estado_Cu)
SELECT GETDATE(),@Nombre_Cu, @Edad_Cu, @IdRef_Cu,@Estado_Cu
RETURN
GO

-----------------------------------------------------------------------



--------------------------------Catalogo---------------------------------

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
-----------------------------------------------------------------------



--------------------------------GENERO---------------------------------
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


CREATE PROCEDURE spBusquedaPeliXGenero
(
@NombreGenero_Ge varchar(30)
)
AS
	SELECT TituloContenido_Cat, NombreGenero_Ge
	FROM Generos INNER JOIN Catalogos
	ON IDGenero_Ge = IDGenero_Cat
	WHERE NombreGenero_Ge = @NombreGenero_Ge
RETURN
GO

CREATE PROCEDURE spCantPelisXGenero
(
@NombreGenero_Ge varchar(30)
)
AS
	SELECT COUNT(IDContenido_Cat) AS [Cantidad Peliculas], NombreGenero_Ge
	FROM Generos INNER JOIN Catalogos 
	ON IDGenero_Cat = IDGenero_Ge
	WHERE NombreGenero_Ge = @NombreGenero_Ge
	GROUP BY NombreGenero_Ge
RETURN
GO
-----------------------------------------------------------------------




--------------------------------PAISES---------------------------------
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

CREATE PROCEDURE spBusquedaCuentaXPais
(
@Nombre_Pa varchar(30)
)
AS
	SELECT Email_Cu, Nombre_Pa
	FROM Paises INNER JOIN Cuentas
	ON IDPais_Pa = ID_Pais_Cu
	WHERE Nombre_Pa = @Nombre_Pa
RETURN
GO


CREATE PROCEDURE spCantPaisesXCuentas
(
@Nombre_Pa varchar(30)
)
AS
	SELECT COUNT(IDCuenta) AS [Cantidad Cuentas], Nombre_Pa
	FROM Paises INNER JOIN Cuentas 
	ON IDPais_Pa = ID_Pais_Cu
	WHERE Nombre_Pa = @Nombre_Pa
	GROUP BY Nombre_Pa
RETURN
GO
-----------------------------------------------------------------------



--------------------------------FAVORITOS------------------------------
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

CREATE PROCEDURE spCargarListViewFiltro
@Titulo varchar(50), @IDCuenta int
AS
SELECT * FROM Favoritos INNER JOIN Catalogos 
ON IDContenido_Cat = IDContenido_F 
WHERE TituloContenido_Cat LIKE '%' + @Titulo + '%' AND ID_cuenta = @IDCuenta
RETURN
GO
-----------------------------------------------------------------------


----------------------------TIPOSUSCRIPCIONES---------------------------
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
------------------------------------------------------------------------


------------------------------SUSCRIPCIONES------------------------------
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


CREATE PROCEDURE spMaxSuscripcion
AS
	SELECT Nombre_Ts, COUNT(CodTipo_Sus) AS [Cantidad de compras]
	FROM Suscripciones INNER JOIN TipoSuscripciones
	ON CodTipo_Sus = CodTipo_Ts
	GROUP BY Nombre_Ts
RETURN
GO
-----------------------------------------------------------------------


------------------------------FACTURACION------------------------------

CREATE PROCEDURE spSuscripcionXMes
AS
DECLARE @fechaCompra date
SET @fechaCompra = DATEADD (month, 1, (SELECT DISTINCT fechaCompra_Sus FROM Suscripciones)) -- las fechas siempre tienen el mismo valor
BEGIN
	IF (@fechaCompra <= GETDATE())
	BEGIN
		UPDATE Suscripciones SET fechaCompra_Sus = GETDATE()
	END
END
GO


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

CREATE PROCEDURE spBusquedaGastoXCuenta
(
@Email varchar(30)
)
AS
	SELECT Email_Cu, SUM(Importe_F) AS [Gasto Total]
	FROM Cuentas INNER JOIN  Facturacion
	ON IDCuenta = IDCuenta_F
	WHERE Email_Cu = @Email
	GROUP BY Email_Cu
RETURN
GO
-----------------------------------------------------------------------
