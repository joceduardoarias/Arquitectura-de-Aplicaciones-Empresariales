# Arquitectura de Aplicaciones Empresariales

Este repositorio contiene un proyecto de práctica correspondiente al curso de Arquitectura de Aplicaciones Empresariales utilizando .NET 7.

## Estructura del Proyecto

El proyecto está organizado en varias capas, incluyendo:

- **Application**: Contiene DTOs y la lógica de aplicación.
- **Domain**: Define las entidades y la lógica de dominio.
- **Infraestructura**: Incluye la configuración de la base de datos y los repositorios.
- **Services.WebApi**: Contiene los controladores y la configuración de la API.

### Diagrama de la Arquitectura

![Diagrama de la Arquitectura de Aplicaciones Empresariales](https://showme.redstarplugin.com/d/PHL4JztP)

- **Application**: La capa de aplicación que utiliza la lógica de dominio.
- **Domain**: Define las entidades y la lógica de dominio.
- **Infraestructura**: Incluye la configuración de la base de datos y los repositorios.
- **Services.WebApi**: Contiene los controladores y la configuración de la API.
- **Client**: El cliente que consume los servicios expuestos.

## Requisitos

- .NET 7
- Base de datos compatible (por ejemplo, SQL Server)

## Cómo Empezar

1. Clonar el repositorio.
2. Restaurar los paquetes NuGet.
3. Configurar la cadena de conexión a la base de datos en `appsettings.json`.
4. Ejecutar el proyecto desde Visual Studio o utilizando `dotnet run`.

## Contribuir

Si deseas contribuir al proyecto, por favor, crea una rama y envía una solicitud de extracción (pull request).

## Licencia

Este proyecto está bajo la licencia MIT. Consulta el archivo LICENSE para más detalles.

## Contacto

Si tienes alguna pregunta o comentario, no dudes en contactarme.

---

Hecho con ❤️ por Jeam.
