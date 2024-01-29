Digitalizar Libros:

Esta es una solución API la cual se divide en varias capas, cada una con su propia particularidad, y una clase por función. Que permite llevar un control y registros de los libros

Como primera línea esta realizada en bajo .Net Core

Con modelo de datos coder First, Librería Entity Framework Core. SQL y Tool, posee también Identity como modelo de seguridad, se crearon de forma automática con esta herramienta tablas de 
roles, usuario y Usuario rol, 4 tablas dividas de la siguiente manera 3  sub tablas(Autor, Categoría, Editorial), una tabla principal libros.

La aplicación se dividió el proyecto en 4 Capas:

1 Capa Modelos: la cual es una Biblioteca de clases, que contiene dos carpetas, la primera carpeta contiene las entidades Creadas desde la Migración, una entidades usuarios que hereda de 
Identity User, y a la cual se agregó valores, para controlar el día de registro y pensando en una aplicación escalable un para activar  o desactivar usuarios, las otras cuatro entidades 
son Autor, Categoría que tiene un capo para activar y desactivar categorías,  Editorial de los libros, libros que contiene la relación con las otras sub tablas.

La siguiente carpeta contiene los View modelos que un servicio para los controladores y dar una capa de seguridad a la base de datos y otros modelos requeridos para usar entre la capa 
negocio y la API con sus controladores contiene  las entidades mas VMExportar para el Excel, VMCredenciales, RespuestaAunt para control de datos de token y correo, VMEmail para enviar 
los correos

2 Capa DAL o Data Access Layer en una Biblioteca de clases esta contiene 3 Excepciones que una carpeta pera personalizar los mensajes de error mediante dos clases , la    carpeta DBcontext
 es una carpeta que contiene un clases context para realizar la conexión de base de datos y declarar las tablas que están conectadas al modelo y las base de datos, adicionalmente contiene 
las as las biblioteca de clases de Entity Framework core SQL, Tool, Identity,  La carpeta Repository que contiene internamente dos carpetas mas una carpeta para los contratos e interfaz y 
la otra carpeta para los repositorios, en estas archivos contiene el contrato de interfaz contiene búsquedas por Id y completa, un método insertar, modificar y eliminar, existe un contrato
 Genérico para las tablas del negocio,”IGenericRepository”

3 Capa BLL o capa de Negocio  en esta capa en esta capa encontraremos dos carpetas una de contratos o interfaz por cada servicio y una de servicio por cada funcionalidad de negocio, las 
básicas que contiene son Autor, categoría, Editorial y libros en estos servicio existe una búsqueda por id, búsqueda completa y por nombre, adicionalmente agregar, modificar y eliminar, 
en el caso libros contiene las búsquedas por categoría, por autor.
En este capa también encontrara otros servicios DataSeeder que crea los roles y el usuario Administrador, llenando de forma automática los datos en la aplicación al momento de iniciarla 
por primera vez, EmailService contiene los servicios para integrar y enviar correos, ExportarDatos es el servicio que controla todos lo proceso de totalizar cada servicio para exportar a 
Excel, usuarios servicio contiene dos servicio para registrar y dar accesos a la alplicacion, token service es un función para generar un token luego de la sesión de usuarios

4 Capa API esta es un proyecto de API para, contiene el program contiene una conexión que llama Appsetting Json  que contiene la cadena SQL, una línea que simplifica las contraseña y roles
 de usuario, adicionalmente contiene las reglas Cors y sus permisos, configuración de token autorización del servicio JSON la inyección de Dependencia y la función de llenado automático, un
a carpeta de migración que contiene las migración de de coder first, appsetting  configuración de cadena de conexión, configuración del email, llave para generar el token, finalmente la 
carpeta de controladores que contiene los enpoind finales que muestran el servicio para cada funcionalidad, además el swangger que permite la documentación y testeo automáticos de la 
aplicación



Prueba Tecnica

| Rol               | Nombre               | Redes                                                                                                                             |
| :---------------- | :------------------- | :-------------------------------------------------------------------------------------------------------------------------------- |

| `Back End`        | Deivison Jiménez     | [![GitHub]](https://github.com/Deivison81) [![linkedin]](https://www.linkedin.com/in/deivison-jimenez/)                           |

## Stack Tecnológico


| Rama               | Tecnologías  

| Back End      | ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) 
| Base de datos | ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white) ![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)  
| Others        | ![GIT](https://img.shields.io/badge/Git-fc6d26?style=for-the-badge&logo=git&logoColor=white) ![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white) ![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)  

