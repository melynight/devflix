# devflix
## Proyecto Integrador Grupal para la materia Programación III
### Integrantes:
> Benetti, Guido Nehuen
>
> Bordon, Patricio Emiliano
>
> Dalama, Melany Nahir
>
> Rouco, Zoe
>
> Vitale, Luciano
## Descripción
``` 
DevFlix es una plataforma de streaming On Demand diseñada para la reproducción de películas y series.
La plataforma cuenta con un sistema de cuentas que establece una relación de uno a muchos, donde cada cuenta administradora
puede tener varios usuarios con cuentas de tipo usuario estandar.

Además, cada cuenta (sea administrador o no) tiene la capacidad de tener múltiples películas o series en la sección principal
 y en el apartado de favoritos, estableciendo así otra relación de uno a muchos, un usuario a muchas peliculas.
Existen dos tipos de cuentas en DevFlix: la cuenta Administrador y la cuenta Usuario.

ABML:
La cuenta Administrador tiene privilegios para realizar compras de suscripciones, cancelar suscripciones y cambiar el tipo de
suscripción, lo que implica un sistema de alta, baja y modificación (ABM). Por otro lado, la cuenta de tipo usuario tiene la
posibilidad de listar las películas y series disponibles en la plataforma.

En DevFlix, se implementa un Sistema de suscripciones por cuenta, donde el límite de usuarios permitidos depende del tipo de
suscripción seleccionada. Cada usuario puede crear una lista personalizada de películas de su interés.

El administrador tiene la facultad de agregar, eliminar y cambiar los nombres de los usuarios. Además, los ajustes y las
suscripciones estarán disponibles exclusivamente para los administradores.

El proceso de registro e inicio de sesión está abierto para los usuarios, quienes deberán seleccionar entre iniciar sesión con
una cuenta existente o crear un nuevo usuario en caso de no tener una cuenta previa. Durante el proceso de creación de usuario,
se deberá definir si se trata de una cuenta de administrador o de un usuario normal.

Disponemos de la tabla Historial, donde podremos tener registro trazable de las suscripciones de la cuenta a lo largo del tiempo.

Usamos C# .NET, T-SQL, HTML y CSS.
```
### Demostracion:

> https://github.com/PatricioBordon/devflix/assets/95234993/4d8f6051-ef06-4bd0-bc3e-5b2bccafbcbc
### Diagrama Entidad Relacion
<img width= "50%" src="https://github.com/PatricioBordon/devflix/assets/95234993/3fba5220-69c8-44d8-a85b-690fa5ec4138"/>

## Programas utilizados
### Gestión del flujo de trabajo del código
> <img width= "30px" src="https://github.com/PatricioBordon/devflix/assets/95234993/aaeb17f8-dee3-4dca-b53e-273be56b1ef0"/> SourceTree
>
>> <video autoplay loop src="https://github.com/PatricioBordon/devflix/assets/95234993/d47d64aa-21d5-4f25-859b-4fe156fec7aa"/>

### IDE
> <img width= "30px" src="https://github.com/PatricioBordon/devflix/assets/95234993/1a7b6698-da00-4c4d-825c-4fe14b636ad1"/> Visual Studio

### Sistema Gestor de Bases de Datos
><img width="25" alt="image" src="https://github.com/PatricioBordon/devflix/assets/95234993/4646bb99-83bd-439f-bb6f-632a73ff319f"> Microsoft SQL Management Studio [SQL Server 2019]
>
``
Nota Final: 10 (Diez)
``
