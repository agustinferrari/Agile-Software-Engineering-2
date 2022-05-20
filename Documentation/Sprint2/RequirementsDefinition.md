# Requirements Definition<!-- omit in toc --> 
###### tags: `Sprint 2`<!-- omit in toc --> 

- [Titulo: Agregar punto de carga](#titulo-agregar-punto-de-carga)
  - [Tamaño:](#tamaño)
  - [Product Owner:](#product-owner)
  - [Developers:](#developers)
  - [Narrativa:](#narrativa)
  - [Escenarios (Criterios de aceptacion)](#escenarios-criterios-de-aceptacion)
- [Titulo: Eliminar punto de carga](#titulo-eliminar-punto-de-carga)
  - [Tamaño:](#tamaño-1)
  - [Product Owner:](#product-owner-1)
  - [Developers:](#developers-1)
  - [Narrativa:](#narrativa-1)
  - [Escenarios (Criterios de aceptacion)](#escenarios-criterios-de-aceptacion-1)
  - [Aclaraciones:](#aclaraciones)

---
## Titulo: Agregar punto de carga
### Tamaño: 
- 3 Story Points
### Product Owner:
- Joaquín Meerhoff
### Developers:
- Sofía Decuadra
- Agustín Ferrari
### Narrativa:
**Como** administrador
**Quiero** poder agregar un punto de carga de autos eléctricos
**Para** que turistas con autos eléctricos sepan de la presencia de estos
### Escenarios (Criterios de aceptacion)
1. #### Agregar punto de carga sin estar logueado
    * **Dado** un usuario no logueado
    - **Y** un punto de carga:
        | Id  | Nombre               | Dirección      | RegionId   | Descripción    |
        |:--- |:-------------------- |:-------------- |:-------- |:-------------- |
        | 1   | Cargar frente al mar | General Flores | 1 | Punto de carga |
    - **Cuando** intenta agregar el nuevo punto de carga
    - **Entonces** debería mostrarse un mensaje de error, que diga que es necesario estar logueado como administrador para agregar un punto de carga.
2. #### Agregar punto de carga con datos invalidos
    * **Dado** un usuario logueado como administrador
        **Usuario**
        | Email            | Contraseña |
        |:---------------- |:---------- |
        | matias@admin.com | admin      |

        **Punto de carga**
        | Id    | Nombre                            |          Dirección           |        Región        |         Descripción          | Error                                                                                                     |
        |:----- |:--------------------------------- |:----------------------------:|:--------------------:|:----------------------------:|:--------------------------------------------------------------------------------------------------------- |
        | Id1   | Cargar parada 2                   |        General Flores        |       SurOeste       |        Punto de carga        | El id debería ser un numero de 4 dígitos máximo.                                                          |
        | 12345 | Cargar parada 2                   |        General Flores        |       SurOeste       |        Punto de carga        | El id debería ser un numero de 4 dígitos máximo.                                                          |
        | 1     | Cargar parada 223 mas de 20 chars |        General Flores        |       SurOeste       |        Punto de carga        | El nombre debría ser alfanumérica de 20 caracteres máximo.                                                |
        | 1     | Cargar parada @$#%#               |        General Flores        |       SurOeste       |        Punto de carga        | El nombre debría ser alfanumérica de 20 caracteres máximo.                                                |
        | 1     | Cargar parada 2                   | {+30 caracteres alfabéticos} |       SurOeste       |        Punto de carga        | La dirección debería ser alfanumérica de 30 caracteres máximo.                                            |
        | 1     | Cargar parada 2                   |      Direccion @2 !..%       |       SurOeste       |        Punto de carga        | La dirección debería ser alfanumérica de 30 caracteres máximo.                                            |
        | 1     | Cargar parada 2                   |        General Flores        | {Región Inexistente} |        Punto de carga        | La región debería estar previamente registrada en el sistema, no se puede encontrar 'Región Inexistente'. |
        | 1     | Cargar parada 2                   |        General Flores        |       SurOeste       | {+60 caracteres alfabéticos} | La descripción debería ser alfanumérica de 60 caracteres máximo.                                          |
        | 1     | Cargar parada 2                   |        General Flores        |       SurOeste       |         Desc @[][]??         | La descripción debería ser alfanumérica de 60 caracteres máximo.                                          |
    - **Cuando** intenta agregar un punto de carga con {Datos}
    - **Entonces** debería mostrarse el mensaje de error {Error}
3. #### Agregar punto de carga con datos válidos
    - **Dado** un usuario logueado como administrador y region SurOeste cargada y el siguiente punto de carga:
        
        **Usuario**
        | Email            | Contraseña |
        |:---------------- |:---------- |
        | matias@admin.com | admin      |
        
        **Punto de carga**
        | Id  | Nombre               | Dirección      | Región   | Descripción    |
        |:--- |:-------------------- |:-------------- |:-------- |:-------------- |
        | 1   | Cargar frente al mar | General Flores | SurOeste | Punto de carga |
    * **Cuando** intenta agregar un punto de carga
    * **Entonces** debería agregarse a la lista de puntos de carga

---
---
## Titulo: Eliminar punto de carga
### Tamaño: 
- 1 Story Points
### Product Owner:
- Sofía Decuadra
### Developers:
- Joaquín Meerhoff
- Agustín Ferrari
### Narrativa:
**Como** administrador
**Quiero** poder eliminar un punto de carga de autos eléctricos
**Para** que turistas con autos eléctricos no busquen un punto que se haya dado de baja
### Escenarios (Criterios de aceptacion)
1. #### Eliminar punto de carga sin estar logueado
    * **Dado** un usuario no logueado
        **Datos de Prueba**
        | Id punto de carga | Error                                                |
        |:----------------- |:-----------------------------------------------------|
        | 1                 | Debes estar logueado para eliminar un punto de carga |
    * **Cuando** intenta eliminar el punto de carga para {Id punto de carga}
    * **Entonces** debería mostrarse el mensaje de error {Error}
2. #### Eliminar punto de carga con datos incorrectos
    * **Dado** un usuario logueado como administrador y un id de punto de carga:
        
        **Usuario**
        | Email            | Contraseña |
        |:---------------- |:---------- |
        | matias@admin.com | admin      |
        
        **Datos de Prueba**
        | Id punto de carga | Error                                                                             |
        |:----------------- |:--------------------------------------------------------------------------------- |
        | 1                 | No se puede eliminar el punto de carga porque no existe punto para el id recibido |
     
    * **Cuando** intenta eliminar el punto de carga con id {Id punto de carga}
    * **Entonces** debería mostrarse el error {Error}
3. #### Eliminar punto de carga logueado como administrador
    * **Dado** un usuario logueado como administrador y region SurOeste carga:
        
        **Usuario**
        | Email            | Contraseña |
        |:---------------- |:---------- |
        | matias@admin.com | admin      |
        
        **Punto de carga**
        | Id  | Nombre               | Dirección      | Región   | Descripción    |
        |:--- |:-------------------- |:-------------- |:-------- |:-------------- |
        | 1   | Cargar frente al mar | General Flores | SurOeste | Punto de carga |
        
    * **Cuando** intenta eliminar el punto de carga para {Id}
    * **Entonces** debería eliminarse de la lista de puntos de carga
---

### Aclaraciones:
- Asumimos que en la letra de Definition of Done Sprint 2 cuando se escribe alfabéticos se refiere a alfanuméricos ya que sino no podría ponerse número de puerta para calles
- Asumimos que cuando se menciona una variable de X caracteres en la Definition of Done Sprint 2 se refiere al máximo y no a una cantidad fija a respetar