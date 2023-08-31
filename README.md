# Tienda_ChePlay
Proyecto creado para simular un e-commerce de videojuegos.
A modo de práctica, cree una tienda web de videojuegos en ADO.NET, utiliza las siguientes tecnologías:
* .Net Framework 4.8
* Base de datos relacional SQL server.

El proyecto está compuesto mediante cuatro capas:
* Datos: Se encarga del CRUD a la base datos, maneja consultas SQL.
* Entidades: Contiene todas las entidades utilizadas en el proyecto.
* Negocio: Aquí se crea la lógca de negocio, abstrae la capa de Datos para un mejor control de la información. Procesa y maneja las estructutas de datos que serán utilizadas en las vistas.
* Vistas: Contiene las vistas diseñadas con HTML y CSS. Controla las interacciones del cliente, utiliza variables Session para conservar la información del usuario, como por ejemplo el carrito de comptas y datos propios.

  Base de datos:
Se adjunta script correspondiente.
Contiene tablas con contenido ya creado.
Utiliza Store Procedure y Triggers para la admionistración de la información de las ventas y videojuegos.
