use TIF_LAB3
go

--------------------------------CUENTAS--------------------------------
CREATE TRIGGER TR_CargarFacturacionUpdateSuscripcion
ON Cuentas
after UPDATE 
AS
IF UPDATE(CodSus_Cu)
	begin
	set nocount on
	insert into Facturacion(IDCuenta_F,CodSus_F,Fecha_F,Importe_F)
	select inserted.IDCuenta, inserted.CodSus_Cu, GETDATE(),Suscripciones.total_Sus
	from inserted 
		inner join deleted on 
		deleted.IDCuenta = inserted.IDCuenta 
		inner join Suscripciones on
		inserted.CodSus_Cu = Suscripciones.CodSus_Sus
		where deleted.CodSus_Cu <> inserted.CodSus_Cu
	end
go



CREATE TRIGGER TR_CargarFacturacionUpdateFecha
ON Cuentas
after UPDATE 
AS
IF UPDATE(Fecha_Suscripcion_Cu)
	begin
	set nocount on
	insert into Facturacion(IDCuenta_F,CodSus_F,Fecha_F,Importe_F)
	select inserted.IDCuenta, inserted.CodSus_Cu, inserted.Fecha_Suscripcion_Cu,Suscripciones.total_Sus
	from inserted 
		inner join deleted on 
		deleted.IDCuenta = inserted.IDCuenta 
		inner join Suscripciones on
		inserted.CodSus_Cu = Suscripciones.CodSus_Sus
		where deleted.Fecha_Suscripcion_Cu <> inserted.Fecha_Suscripcion_Cu
	end
go



CREATE TRIGGER TR_CargarFacturacionInsert
ON Cuentas
after INSERT 
AS
	begin
	set nocount on
	insert into Facturacion(IDCuenta_F,CodSus_F,Fecha_F,Importe_F)
	select inserted.IDCuenta, inserted.CodSus_Cu, GETDATE(),Suscripciones.total_Sus
	from inserted 
		inner join Suscripciones on
		inserted.CodSus_Cu = Suscripciones.CodSus_Sus
		where inserted.CodSus_Cu<>0 -- aca solo se van a agregar registros de admin por q si agrega usuario,
		--el registro de usuario no va a tener codSus y va a cargar null en Facturacion
		-- Con la condicion IDRef_Cu = null funciona cuando se da de alta el admin y no se agrega otro registro cuando agrega usuario
	end
go


CREATE TRIGGER TR_DeleteCuenta
ON Cuentas
INSTEAD OF DELETE
AS
BEGIN
SET NOCOUNT ON

	UPDATE Favoritos
	set Favoritos.estado_FA =0
    FROM Favoritos
    INNER JOIN deleted ON Favoritos.ID_cuenta = deleted.IDCuenta

    -- Eliminar las filas de Cuentas
    update Cuentas
	set cuentas.Estado_Cu= 0
    WHERE IDCuenta IN (SELECT IDCuenta FROM deleted);
END
GO
-----------------------------------------------------------------------

CREATE TRIGGER TR_CuentasValidarMail
ON Cuentas
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @contarMails INT
    SET @contarMails = (SELECT COUNT(Cuentas.IDCuenta) FROM Cuentas  WHERE Cuentas.Email_Cu = (SELECT Email_Cu FROM inserted))

    IF (@contarMails > 0)
    BEGIN
        PRINT 'El correo electrónico ya existe en la tabla.'
        RETURN
    END
    ELSE
	BEGIN
	INSERT INTO Cuentas(ID_Pais_Cu,CodSus_Cu,Email_Cu,Clave_Cu,Fecha_Suscripcion_Cu,Nombre_Cu,PIN_Cu,Edad_Cu,IDRef_Cu,NROTarjeta_Cu,Estado_Cu)
	Select inserted.ID_Pais_Cu,inserted.CodSus_Cu,inserted.Email_Cu,inserted.Clave_Cu,inserted.Fecha_Suscripcion_Cu,inserted.Nombre_Cu,inserted.PIN_Cu,inserted.Edad_Cu,inserted.IDRef_Cu,inserted.NROTarjeta_Cu,inserted.Estado_Cu from inserted
	END
END

--test oa

INSERT INTO Cuentas(ID_Pais_Cu,CodSus_Cu,Email_Cu,Clave_Cu,Fecha_Suscripcion_Cu,
Nombre_Cu,PIN_Cu,Edad_Cu,IDRef_Cu,NROTarjeta_Cu,Estado_Cu)
SELECT 'BRA',2,'melany@gmail.com','123456',GETDATE(),'Melany','2331',20,NULL,'2333332212332165',1 

select * from cuentas

