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
select *from Cuentas


ALTER TRIGGER TR_CargarFacturacionDelete
on cuentas
instead of Delete
AS
	begin
	set nocount on
	delete Facturacion
	where Facturacion.IDCuenta_F= (select deleted.IDCuenta from deleted)
	delete Favoritos where Favoritos.ID_cuenta = (select deleted.IDCuenta from deleted)
	delete Cuentas where IDCuenta= (select deleted.IDCuenta from deleted)
	end
go



