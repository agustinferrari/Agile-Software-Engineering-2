# Environment Guide <!-- omit in toc -->
### Índice <!-- omit in toc -->
- [Versiones de herramientas](#versiones-de-herramientas)
- [Gestión de datos para escenarios](#gestión-de-datos-para-escenarios)
- [Creación automática de entornos tipo producción](#creación-automática-de-entornos-tipo-producción)
 
## Versiones de herramientas
En un principio no se definieron las versiones específicas a utilizar para correr las diferentes partes del proyecto, ya sea el frontend o el backend ya que se aprovechaba la retrocompatibilidad entre versiones de node, dotnet, npm y angular.
 
Se tuvo problemas en algunos casos que llevaron a tener que reinstalar angular o node para que funcione adecuadamente el proyecto, por lo cual se define en este documento las versiones a utilizar para cada una de las partes, tomando en cuenta que no son específicamente las mismas en las que se implementó el código del material del obligatorio, pero que si fueron usadas y probadas a lo largo del proyecto DevOps por nosotros.
 
| Herramienta | Versión                             |
| ----------- | ----------------------------------- |
| Dotnet      | 6.0.202                             |
| Node        | 16.15.0                             |
| NPM         | 8.5.5                               |
| Angular     | 10.2.0 (local al proyecto frontend) |
 
## Gestión de datos para escenarios
 
Las pruebas unitarias corridas de forma local o por la github action no requieren de un ambiente preparado por fuera por correrse en memoria.
 
Las pruebas automáticas de funcionalidad corridas con Selenium si requieren de un previo setup del ambiente haciendo uso de una base de datos. Para ello se mantiene actualizado los .bak y .sql con datos de pruebas necesarios y esperados en estas pruebas de integración. Se deben correr en MSSMS (Microsoft SQL Server Management Studio) en windows o Azure Data Studio en MacOS uno de los archivos para asegurarse de tener el ambiente esperado para las pruebas.
 
## Creación automática de entornos tipo producción
 
En este proyecto no se automatizó la creación de entornos tipo producción para el uso de los desarrolladores, ya que quedaba fuera del alcance del obligatorio.
 
Esto no quita que los workflows ejecutados en los pull requests a main por la github action incluyen la creación de un ambiente tipo producción con todo lo necesario para ejecutar los tests unitarios del backend.
 
En caso de automatizar la creación de ambientes de frontend y backend, se debería respetar las versiones presentadas en este documento.