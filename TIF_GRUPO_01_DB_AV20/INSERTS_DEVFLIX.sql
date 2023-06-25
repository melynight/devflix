
USE DevFlixDB
go

INSERT INTO Paises (IDPais_Pa,Nombre_PA)
select 'ARG','Argentina' union
select 'BRA','Brasil' union
select 'URU','Uruguay'
go

INSERT INTO Generos (IDGenero_Ge, NombreGenero_GE)
select 'G001','Acción'  union
select 'G002','Romance' union
select 'G003','Infantil'union
select 'G004','Terror'  
go

INSERT INTO TipoSuscripciones(CodTipo_Ts,Nombre_Ts,Precio_Ts,Beneficios_Ts,CantUsuarios_Ts,Estado_Ts)
SELECT 'PPremi','PREMIUM',2399.99 ,'-Calidad de video ULTRA HD (4K)',4,1
UNION
SELECT 'PEstan','ESTANDAR',1399.99 ,'-Calidad de video FULL HD (1080p)',2,1
UNION
SELECT 'PBasic','BASICO',799.99 ,'-Buena calidad de video en HD (720p)',1,1
UNION
SELECT 'PUNIVERSAL','FULL',0,'ACCESO ILIMITADO',0,1 
GO

INSERT INTO Suscripciones(CodTipo_Sus, total_Sus, fechaCompra_Sus, estado_Sus)
SELECT 'PPremi', 2399.99, GETDATE(), 1 UNION
SELECT 'PBasic', 799.99, GETDATE(), 1 UNION 
SELECT 'PEstan', 1399.99, GETDATE(), 1 
GO

INSERT INTO Cuentas(ID_Pais_Cu,CodSus_Cu,Email_Cu,Clave_Cu,FechaCreacion_Cu,
Nombre_Cu,PIN_Cu,Edad_Cu,IDRef_Cu,NROTarjeta_Cu,Estado_Cu)
SELECT 'ARG',1,'ejemplo1@gmail.com','dada123',GETDATE(),'Ejemplo1','2211',20,NULL,'2344322212349865',1
INSERT INTO Cuentas(ID_Pais_Cu,CodSus_Cu,Email_Cu,Clave_Cu,FechaCreacion_Cu,
Nombre_Cu,PIN_Cu,Edad_Cu,IDRef_Cu,NROTarjeta_Cu,Estado_Cu)
SELECT NULL,NULL,NULL,NULL,GETDATE(),'USUARIO1',NULL,18,1,NULL,1 
INSERT INTO Cuentas(ID_Pais_Cu,CodSus_Cu,Email_Cu,Clave_Cu,FechaCreacion_Cu,
Nombre_Cu,PIN_Cu,Edad_Cu,IDRef_Cu,NROTarjeta_Cu,Estado_Cu)
SELECT NULL,NULL,NULL,NULL,GETDATE(),'USUARIO2',NULL,14,1,NULL,1 
INSERT INTO Cuentas(ID_Pais_Cu,CodSus_Cu,Email_Cu,Clave_Cu,FechaCreacion_Cu,
Nombre_Cu,PIN_Cu,Edad_Cu,IDRef_Cu,NROTarjeta_Cu,Estado_Cu)
SELECT 'ARG',2,'ejemplo2@gmail.com','123456',GETDATE(),'Ejemplo2','2331',20,NULL,'2333332212332165',1 
INSERT INTO Cuentas(ID_Pais_Cu,CodSus_Cu,Email_Cu,Clave_Cu,FechaCreacion_Cu,
Nombre_Cu,PIN_Cu,Edad_Cu,IDRef_Cu,NROTarjeta_Cu,Estado_Cu)
SELECT NULL,NULL,NULL,NULL,GETDATE(),'USUARIO1',NULL,22,4,NULL,1 
INSERT INTO Cuentas(ID_Pais_Cu,CodSus_Cu,Email_Cu,Clave_Cu,FechaCreacion_Cu,
Nombre_Cu,PIN_Cu,Edad_Cu,IDRef_Cu,NROTarjeta_Cu,Estado_Cu)
SELECT NULL,NULL,NULL,NULL,GETDATE(),'USUARIO2',NULL,24,4,NULL,1
GO

--ULTIMOS INSERTS CATALOGOS--


INSERT INTO Catalogos (IDContenido_Cat, IDGenero_Cat, CodTipo_Cat, Sinopsis_Cat,
Duracion_Cat,
URLPortada_Cat,
TituloContenido_Cat,
Season_Cat,
URLVideo_Cat,
Clasif_Edad_Cat,
Estado_Cat)
SELECT 'P001', 'G001' , 'PUNIVERSAL', '"Transformers" es una franquicia de acción y ciencia ficción sobre una guerra entre los Autobots y los Decepticons, dos razas alienígenas robóticas. 
Los Autobots llegan a la Tierra en busca de la AllSpark, una fuente de energía, mientras los Decepticons buscan utilizarla para conquistar el universo. Los humanos se unen a la batalla para proteger a la humanidad.
Hay intensas batallas entre los Transformers en tierra y en el espacio.', 2, 'Recursos/Imagenes/Portadas/Accion1_Transformers.JPG','Transformers: 
El despertar de las bestias', 0, 'https://www.youtube.com/watch?v=s6yBw1CXSMA', 13, 1 UNION
SELECT 'P002', 'G003' , 'PUNIVERSAL', 'Tras descubrirse la identidad secreta de Peter Parker como Spider-Man, la vida del joven se vuelve una locura. 
Peter le pide ayuda al Doctor Strange para recuperar su vida, pero algo sale mal y provoca una fractura en el multiverso.', 2, 
'Recursos/Imagenes/Portadas/accion2_Spiderman.JPG','Spiderman', 0, 'https://www.youtube.com/watch?v=oBmazlyP220', 13, 1 UNION
SELECT 'P003', 'G001', 'PUNIVERSAL', 'Tras sabotear un reactor nuclear iraní, el agente de la CIA Tom Harris (Gerard Butler) 
descubre que su identidad ha sido revelada a los medios después de que un informante expusiera la implicación de la CIA en 
la destrucción del reactor. Harris dispone de sólo 30 horas para llegar al aeropuerto de Kandahar (Afganistán) y evitar su 
muerte y captura.', 3, 'Recursos/Imagenes/Portadas/accion3_Kandahar.JPG', 'Kandahar', 0, 'https://www.youtube.com/watch?v=0r6-YSKzKf4', 16, 1 UNION
SELECT 'P004', 'G001', 'PUNIVERSAL', 'Un veterano militar y enfermo de estrés postraumático se enfrenta a unos terroristas armados que se han infiltrado
en un Hospital de Veteranos y han tomado rehenes, entre ellos a su esposa y a un general condecorado.', 2, 
'Recursos/Imagenes/Portadas/accion4_Asalto_Al_Hospital.JPG', 'Asalto al Hospital', 0, 'https://www.youtube.com/watch?v=MJZ1DESg5JY', 16, 1 UNION
SELECT 'P005', 'G001', 'PUNIVERSAL', 'Hace un año que Dominic y Brian fueron indultados y pudieron regresar a los Estados Unidos. Después de su llegada
desean adaptarse a su nueva vida dentro de la legalidad, pero las cosas no son tan fáciles.', 3, 'Recursos/Imagenes/Portadas/accion5_Rapidos_y_Furiosos.JPG', 
'Rápidos y furiosos 7', 0, 'https://www.youtube.com/watch?v=GE3GS7NM6ho', 16, 1 UNION
SELECT 'P006', 'G003', 'PUNIVERSAL', 'La sirena Ariel está fascinada por el mundo de los humanos, pero su padre le prohíbe relacionarse con ellos. En un viaje secreto, se enamora de un humano y recurre a una perversa hechicera para que, mediante un conjuro, su amor triunfe.',
2, 'Recursos/Imagenes/Portadas/infantiles5_la_Sirenita.JPG', 
'La Sirenita', 0, 'https://www.youtube.com/watch?v=1RP1bOeCyyM', 3, 1 
UNION
SELECT 'P007', 'G003', 'PUNIVERSAL', 'Elina vive en un mundo llamado Fairytopia al lado de otras hadas y la malvada Laverna desea convertirse en la reina del lugar secuestrando a siete guardianes para absorber el poder de sus collares y lograr su propósito.',
2, 'Recursos/Imagenes/Portadas/infantiles3_Barbie_Fairytopia.JPG', 
'Barbie Fairytopia', 0, 'https://www.youtube.com/embed/2gaJF7k7L6Y', 3, 1 
UNION
SELECT 'P008', 'G003', 'PUNIVERSAL',' Después de que una fuerza oscura conquista Canterlot, las Mane 6 se embarcan en un viaje inolvidable más allá de Equestria para salvar su patria. Allí conocerán a nuevos amigos, como Capper, La Reina Novo y su hija Skystar, o la Capitana Gelaeno, y se enfrentarán a desafíos emocionantes.',
2, 'Recursos/Imagenes/Portadas/series3_infantil_My_Little_Pony.JPG', 
'My Little Pony', 0, 'https://www.youtube.com/watch?v=1lKCcxK5OHk', 3, 1 
UNION
SELECT 'P009', 'G003', 'PUNIVERSAL','La vida de dos niños rebeldes que pretenden llamar la atención de sus padres haciendo la vida imposible a todas las niñeras, se verá alterada con la llegada de Mary Poppins, una institutriz que baja de las nubes usando su paraguas como paracaídas.',
2, 'Recursos/Imagenes/Portadas/infantiles1_Mary_PoppinsJPG.JPG', 
'Mary Poppins', 0, 'https://www.youtube.com/watch?v=-3jsfXDZLIY', 3, 1 
UNION
SELECT 'P010', 'G002', 'PUNIVERSAL','Un hombre de negocios se enamora de una joven estudiante y disfraza sus sentimientos con mentiras, hasta el punto de fingir ser una persona humilde.',
3, 'Recursos/Imagenes/Portadas/romantica_4_Ricos_De_Amor_2.JPG', 
'Ricos de amor', 0, 'https://www.youtube.com/watch?v=w7W3Lizzr9E', 16, 1 
UNION
SELECT 'P011', 'G002', 'PUNIVERSAL','¿Qué pasaría si un mensaje de texto al azar te condujera al amor de tu vida? En esta comedia romántica, ante la pérdida de su prometido, Mira Ray envía una serie de mensajes de texto románticos a su antiguo número de teléfono... sin darse cuenta de que el número había sido reasignado al nuevo teléfono del trabajo de Rob Burns.',
3, 'Recursos/Imagenes/Portadas/romantica1_Amor_a_Primer_Mensaje.JPG', 
'Amor a primer mensaje', 0, 'https://www.youtube.com/watch?v=92sPGlhGbNs', 16, 1 
UNION
SELECT 'P012', 'G002', 'PUNIVERSAL','Basada en el bestseller del New York Times. La vida de A.J. Fikry, propietario de una librería, no está resultando como él esperaba. No ha superado la trágica muerte de su mujer y ha tocado fondo con el robo de su posesión más preciada.',
3, 'Recursos/Imagenes/Portadas/romantica2_La_Historia_De_Vida_De_AJ_Fikry.JPG', 
'La Historia De Vida De AJ Fikry', 0, 'https://www.youtube.com/watch?v=-GgYCjuo4Kc', 16, 1 
UNION
SELECT 'P013', 'G002', 'PUNIVERSAL','Surge una nueva historia de amor cuando la joven celestina Kitty se reencuentra con su novio a distancia en el mismo internado en el que estudió su difunta madre. Ve todo lo que quieras.',
3, 'Recursos/Imagenes/Portadas/series4_romance_Besos_Kitty.JPG', 
'Besos Kitty', 0, 'https://www.youtube.com/watch?v=g40ODSkvemI', 16, 1 
UNION
SELECT 'P014', 'G004' , 'PUNIVERSAL','El padre Lamont es el encargado de investigar la muerte del padre Merrin y la causa de la posesión diabólica de la joven Regan. Lamont viajará a África para investigar otro caso de posesión demoníaca. Cuando regresa a Nueva York, Regan está nuevamente poseída pero, en esta ocasión, por la máquina hipnótica del doctor Gene Tuskin.',
3, 'Recursos/Imagenes/Portadas/terror5_El_Exorcista_II.JPG', 
'EL EXORCISTA II', 0, 'https://www.youtube.com/watch?v=LDraTxCzewY', 18, 1 
UNION
SELECT 'P015', 'G004' , 'PUNIVERSAL','Durante su estancia en las Bermudas, Ellen Brody se da cuenta de que el tiburón que mató a su hijo la está acechando.',
3, 'Recursos/Imagenes/Portadas/terror4_Tiburon_4.JPG', 
'TIBURON 4', 0, 'https://www.youtube.com/watch?v=RVgZR-v2qHo', 18, 1 
UNION
SELECT 'P016', 'G004' , 'PUNIVERSAL','En los años cincuenta, una nave espacial se estrella contra la Tierra expulsando un peligroso organismo extraterrestre. Un joven ve una extraña luz que procede del lugar y se acerca para comprobar de qué se trata, pero al instante el chico desaparece. Veintisiete años después, dos universitarios roban un cadáver congelado de la facultad de medicina, que resulta ser el del joven desaparecido, y lo descongelan.',
3, 'Recursos/Imagenes/Portadas/terror3_El_Terror_Llama_A_Su_Puerta.JPG', 
'EL TERROR LLAMA A SU PUERTA', 0, 'https://www.youtube.com/watch?v=HShJXeYAGrw', 18, 1 
UNION
SELECT 'P017', 'G004' , 'PUNIVERSAL',' El destino del mundo está en manos de Damien, un niño con rostro angelical que, en realidad, es la encarnación del Anticristo.',
3, 'Recursos/Imagenes/Portadas/terror2_la_profecia.JPG', 
'LA PROFECIA', 0, 'https://www.youtube.com/watch?v=AiwP5udhskk', 18, 1 
UNION
SELECT 'P018', 'G003', 'PUNIVERSAL','Vinland Saga es una serie anime que gira en torno a Thorfinn, el hijo del mejor de los guerreros en un mundo ambientado a finales del primer milenio donde los vikingos era la tribu más poderosa y atroz y la que había luchado sin cesar hasta el final.',
3, 'Recursos/Imagenes/Portadas/Serie2Accion_VINLANDSAGA.JPG', 
'Vinland Saga', 0, 'https://www.youtube.com/watch?v=n2VuKI0yT8w', 16, 1 
GO
USE DevFlixDB
go

