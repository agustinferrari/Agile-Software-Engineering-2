# Requirements Definition Sprint 3
###### tags: `Sprint 3`

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

    + **Dado** un usuario no logueado
    + **Y** un punto de carga con los datos
        **Punto de carga**
        | Nombre               | Dirección      | Region               | Descripción    |
        |:-------------------- |:-------------- |:-------------------- |:-------------- |
        | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
    - **Cuando** intenta agregar el punto de carga
    - **Entonces** debería mostrarse un mensaje de error, que diga que es necesario estar logueado como administrador para agregar un punto de carga.
    
2. #### Agregar punto de carga con caracteres inválidos
    + **Dado** un usuario logueado como administrador
        **Usuario**
        | Email            | Contraseña |
        |:---------------- |:---------- |
        | matias@admin.com | admin      |
        
    + **Y** una región existente
        **Región**
        | Id  | Nombre               |
        | --- |:-------------------- |
        | 1   | Región Metropolitana |
    
    - **Y** un punto de carga con nombre {Nombre}
    - **Y** una dirección {Direccion}
    - **Y** una Región de id {RegionId}
    - **Y** una descripción {Descripcion}
        **Punto de carga**
        | Nombre              | Dirección         | Región               |  Descripción   | Error                                                            |
        |:------------------- |:----------------- |:-------------------- |:--------------:|:---------------------------------------------------------------- |
        | Cargar parada @$#%# | General Flores    | Región Metropolitana | Punto de carga | El nombre debría ser alfanumérica de 20 caracteres máximo.       |
        | Cargar parada 2     | Direccion @2 !..% | Región Metropolitana | Punto de carga | La dirección debería ser alfanumérica de 30 caracteres máximo.   |
        | Cargar parada 2     | General Flores    | Región Metropolitana |  Desc @[][]??  | La descripción debería ser alfanumérica de 60 caracteres máximo. |
    - **Cuando** intenta agregar el punto de carga
    - **Entonces** debería mostrarse el mensaje de error {Error}
    
3. #### Agregar punto de carga con largos inválidos
    * **Dado** un usuario logueado como administrador
        **Usuario**
        | Email            | Contraseña |
        |:---------------- |:---------- |
        | matias@admin.com | admin      |
    
    + **Y** una región existente
        
        **Región**
        | Id  | Nombre               |
        | --- | -------------------- |
        | 1   | Región Metropolitana |

    - **Y** un punto de carga con Nombre {Nombre}
    - **Y** una dirección {Direccion}
    - **Y** una Región de id {RegionId}
    - **Y** una descripción {Descripcion}
        **Punto de carga**
        | Nombre                            |          Dirección           | Región               |         Descripción          | Error                                                            |
        |:--------------------------------- |:----------------------------:|:-------------------- |:----------------------------:|:---------------------------------------------------------------- |
        | Cargar parada 223 mas de 20 chars |        General Flores        | Región Metropolitana |        Punto de carga        | El nombre debría ser alfanumérica de 20 caracteres máximo.       |
        | Cargar parada 2                   | {+30 caracteres alfabéticos} | Región Metropolitana |        Punto de carga        | La dirección debería ser alfanumérica de 30 caracteres máximo.   |
        | Cargar parada 2                   |        General Flores        | Región Metropolitana | {+60 caracteres alfabéticos} | La descripción debería ser alfanumérica de 60 caracteres máximo. |
    - **Cuando** intenta agregar el punto de carga
    - **Entonces** debería mostrarse el mensaje de error {Error}

4. #### Agregar punto de carga con región inexistente
    + **Dado** un usuario logueado como administrador
        **Usuario**
        | Email            | Contraseña |
        |:---------------- |:---------- |
        | matias@admin.com | admin      |
    
    + **Y** una región existente
        **Región**
        | Id  | Nombre               |
        | --- | -------------------- |
        | 1   | Región Metropolitana |

    - **Y** un punto de carga con Nombre {Nombre}
    - **Y** una dirección {Direccion}
    - **Y** una Región de id {RegionId}
    - **Y** una descripción {Descripcion}
        **Punto de carga**
        | Nombre          |   Dirección    | Región            |  Descripción   | Error                                                         |
        |:--------------- |:--------------:|:----------------- |:--------------:|:------------------------------------------------------------- |
        | Cargar parada 2 | General Flores | {Región NoExiste} | Punto de carga | La región debería estar previamente registrada en el sistema. |
    - **Cuando** intenta agregar el punto de carga
    - **Entonces** debería mostrarse el mensaje de error {Error}
    
5. #### Agregar punto de carga con datos válidos
    * **Dado** un usuario logueado como administrador
        **Usuario**
        | Email            | Contraseña |
        |:---------------- |:---------- |
        | matias@admin.com | admin      |
    
    + **Y** una región existente
        **Región**
        | Id  | Nombre               |
        | --- |:-------------------- |
        | 1   | Región Metropolitana |
    
    + **Y** un punto de carga con los datos
        **Punto de carga**
        | Nombre               | Dirección      | Región               | Descripción    |
        |:-------------------- |:-------------- |:-------------------- |:-------------- |
        | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
    * **Cuando** intenta agregar el punto de carga
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
    - **Dado** un usuario no logueado
    - **Y** una región existente
        **Región**
        | Id  | Nombre               |
        | --- |:-------------------- |
        | 1   | Región Metropolitana |
    
    + **Y** un punto de carga existente con datos
        **Punto de carga**
        | Id  | Nombre               | Dirección      |        Region        | Descripción    |
        |:--- |:-------------------- |:-------------- |:--------------------:|:-------------- |
        | 1   | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
    
    - **Y** un punto de carga con id {Id}
        **Datos de Prueba**
        | Id  | Error                                                |
        |:--- |:---------------------------------------------------- |
        | 1   | Debes estar logueado para eliminar un punto de carga |
    - **Cuando** intenta eliminar el punto de carga
    - **Entonces** debería mostrarse el mensaje de error {Error}

2. #### Eliminar punto de carga con datos incorrectos
    * **Dado** un usuario logueado como administrador
        
        **Usuario**
        | Email            | Contraseña |
        |:---------------- |:---------- |
        | matias@admin.com | admin      |
        
    + **Y** una región existente
        
        **Región**
        | Id  | Nombre               |
        | --- |:-------------------- |
        | 1   | Región Metropolitana |
        
    + **Y** un punto de carga existente con datos
        **Punto de carga**
        | Id  | Nombre               | Dirección      |        Region        | Descripción    |
        |:--- |:-------------------- |:-------------- |:--------------------:|:-------------- |
        | 1   | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
        
    + **Y** un punto de carga a borrar de id {Id}
        **Datos de Prueba**
        | Id  | Error                                                                             |
        |:--- |:--------------------------------------------------------------------------------- |
        | 2   | No se puede eliminar el punto de carga porque no existe punto para el id recibido |
     
    * **Cuando** intenta eliminar el punto de carga
    - **Entonces** debería mostrarse el mensaje de error {Error}

3. #### Eliminar punto de carga logueado como administrador
    * **Dado** un usuario logueado como administrador
        
        **Usuario**
        | Email            | Contraseña |
        |:---------------- |:---------- |
        | matias@admin.com | admin      |
        
    + **Y** una región existente
        
        **Región**
        | Id  | Nombre               |
        | --- |:-------------------- |
        | 1   | Región Metropolitana |
    
    + **Y** un punto de carga existente con datos
        **Punto de carga**
        | Id  | Nombre               | Dirección      |        Region        | Descripción    |
        |:--- |:-------------------- |:-------------- |:--------------------:|:-------------- |
        | 1   | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
        
    + **Y** un punto de carga a borrar con id {Id}
        **Datos de Prueba**
        | Id  |
        |:--- |
        | 1   |
        
    * **Cuando** intenta eliminar el punto de carga
    * **Entonces** debería eliminarse de la lista de puntos de carga
---
---
## Titulo: Obtener todos los puntos de carga
### Tamaño: 
- 1 Story Points
### Product Owner:
- Sofía Decuadra
### Developers:
- Joaquín Meerhoff
- Agustín Ferrari
### Narrativa:
**Como** usuario
**Quiero** poder obtener los datos de los puntos de carda disponibles
**Para** saber donde puedo cargar mi auto electrico
### Escenarios (Criterios de aceptacion)
1. #### Obtener todos los puntos de carga sin tener ninguno agregado
      + **Dado** una región existente
        
        **Región**
        | Id  |        Nombre        |
        | --- |:--------------------:|
        | 1   | Región Metropolitana |
        
    + **Y** ningún punto de carga
    * **Cuando** se pide la lista de todos los puntos de carga
    - **Entonces** debería mostrarse el mensaje de error "No hay puntos de carga cargados en el sistema"

2. #### Obtener todos los puntos de carga
      + **Dado** una región existente
        
        **Región**
        | Id  |        Nombre        |
        | --- |:--------------------:|
        | 1   | Región Metropolitana |
    
    + **Y** los siguientes puntos de carga existentes
        **Punto de carga**
        | Id  | Nombre               | Dirección      |        Region        |   Descripción    |
        |:--- |:-------------------- |:-------------- |:--------------------:|:----------------:|
        | 1   | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga 1 |
        | 2   | Cargar centro        | 18 de julio    | Región Metropolitana | Punto de carga 2 |
        
    * **Cuando** se pide la lista de todos los puntos de carga
    * **Entonces** debería mostrarse una lista conteniendo los puntos de carga existentes
---

### Aclaraciones:
- Asumimos que en la letra de Definition of Done Sprint 2 cuando se escribe alfabéticos se refiere a alfanuméricos ya que sino no podría ponerse número de puerta para calles
- Asumimos que cuando se menciona una variable de X caracteres en la Definition of Done Sprint 2 se refiere al máximo y no a una cantidad fija a respetar