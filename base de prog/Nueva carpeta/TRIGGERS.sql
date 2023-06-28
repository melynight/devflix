use DevFlixDB
go

CREATE TRIGGER TR_CargarFacturacionUpdate
ON Cuentas
after UPDATE 
AS
IF UPDATE(CodSus_Cu)
	begin
	set nocount on
	insert into Facturacion(IDCuenta_F,CodSus_F,Fecha_F,Importe_F)
	select inserted.IDCuenta, inserted.CodSus_Cu, GETDATE(),Suscripciones.total_Sus
	from inserted 
		--aca valido si hubo un verdadero cambio de suscripcion por que tuve el problema de que cuando hacia update y seteaba la misma suscripcion generaba otro registro
		inner join deleted on 
		deleted.IDCuenta = inserted.IDCuenta 
		inner join Suscripciones on
		inserted.CodSus_Cu = Suscripciones.CodSus_Sus
		where deleted.CodSus_Cu <> inserted.CodSus_Cu
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
    -- Eliminar registros de Facturacion correspondientes a las filas eliminadas en Cuentas
    update f
	set f.Estado_F=0
    FROM Facturacion as f
    INNER JOIN deleted as d ON f.IDCuenta_F = d.IDCuenta

	UPDATE fv
	set fv.estado_FA =0
    FROM Favoritos as fv
    INNER JOIN deleted as d ON fv.ID_cuenta = d.IDCuenta

    -- Eliminar las filas de Cuentas
    update Cuentas
	set cuentas.Estado_Cu= 0
    WHERE IDCuenta IN (SELECT IDCuenta FROM deleted);
END
GO

