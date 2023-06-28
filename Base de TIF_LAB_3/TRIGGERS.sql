use TIF_LAB3
go

CREATE TRIGGER TR_CargarFacturacionUpdate
ON Suscripciones
after UPDATE 
AS
DECLARE  @fechaCompra datetime
SET @fechaCompra = DATEADD (month, 1, (select fechaCompra_Sus from inserted))

IF UPDATE(fechaCompra_Sus)
	begin
	set nocount on
	IF (@fechaCompra <= GETDATE())
	begin
	insert into Facturacion(IDCuenta_F,CodSus_F,Fecha_F,Importe_F)
	select Cuentas.IDCuenta, CodSus_Cu, GETDATE(),total_Sus
	from inserted 
		inner join Cuentas on
		CodSus_Cu = CodSus_Sus
		end
	end
go

select * from Facturacion


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



