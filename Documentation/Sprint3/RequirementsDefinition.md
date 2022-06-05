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
### Escenarios (Criterios de aceptación)
1. #### Agregar punto de carga sin estar logueado
 
    + **Dado** un nuevo punto de carga
        **Punto de carga**
        | Nombre               | Dirección      | Región               | Descripción    |
        | -------------------- | -------------- | -------------------- | -------------- |
        | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
    - **Cuando** intenta agregar el punto de carga
    - **Entonces** no el usuario no tiene permiso de crear el punto de carga
    
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
    - **Y** una dirección {Dirección}
    - **Y** una Región {Región}
    - **Y** una descripción {Descripción}
    - **Cuando** intenta agregar el punto de carga
    - **Entonces** debería mostrarse el mensaje de error {Error}
    
      **Punto de carga**
        | Nombre              | Dirección         | Región               | Descripción    | Error                                                            |
        | ------------------- | ----------------- | -------------------- | -------------- | ---------------------------------------------------------------- |
        | Cargar parada @$#%# | General Flores    | Región Metropolitana | Punto de carga | El nombre debería ser alfanumérico de 20 caracteres máximo.      |
        | Cargar parada 2     | Dirección @2 !..% | Región Metropolitana | Punto de carga | La dirección debería ser alfanumérica de 30 caracteres máximo.   |
        | Cargar parada 2     | General Flores    | Región Metropolitana | Desc @[][]??   | La descripción debería ser alfanumérica de 60 caracteres máximo. |
    
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
 
    - **Y** un punto de carga con nombre {Nombre}
    - **Y** una dirección {Dirección}
    - **Y** una Región {Region}
    - **Y** una descripción {Descripción}
    - **Cuando** intenta agregar el punto de carga
    - **Entonces** debería mostrarse el mensaje de error {Error}
 
        **Punto de carga**
        | Nombre                            | Dirección                    | Región               | Descripción                  | Error                                                            |
        | --------------------------------- | ---------------------------- | -------------------- | ---------------------------- | ---------------------------------------------------------------- |
        | Cargar parada 223 mas de 20 chars | General Flores               | Región Metropolitana | Punto de carga               | El nombre debería ser alfanumérico de 20 caracteres máximo.      |
        | Cargar parada 2                   | {+30 caracteres alfabéticos} | Región Metropolitana | Punto de carga               | La dirección debería ser alfanumérica de 30 caracteres máximo.   |
        | Cargar parada 2                   | General Flores               | Región Metropolitana | {+60 caracteres alfabéticos} | La descripción debería ser alfanumérica de 60 caracteres máximo. |
 
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
 
    - **Y** un punto de carga con nombre {Nombre}
    - **Y** una dirección {Dirección}
    - **Y** una Región {Region}
    - **Y** una descripción {Descripción}
    - **Cuando** intenta agregar el punto de carga
    - **Entonces** no debería crearse el punto de carga
        
        **Punto de carga**
        | Nombre          | Dirección      | Región            | Descripción    |
        | --------------- | -------------- | ----------------- | -------------- |
        | Cargar parada 2 | General Flores | {Región NoExiste} | Punto de carga |
    
5. #### Agregar punto de carga con datos válidos
    * **Dado** un usuario logueado como administrador
        **Usuario**
        | Email            | Contraseña |
        | ---------------- | ---------- |
        | matias@admin.com | admin      |
    
    + **Y** una región existente
        **Región**
        | Id  | Nombre               |
        | --- | -------------------- |
        | 1   | Región Metropolitana |
    
    + **Y** un punto de carga con los datos
        **Punto de carga**
        | Nombre          | Dirección      | Región               | Descripción    |
        | --------------- | -------------- | -------------------- | -------------- |
        | Cargar parada 1 | General Flores | Región Metropolitana | Punto de carga |
    * **Cuando** intenta agregar el punto de carga
    * **Entonces** debería agregarse a la lista de puntos de carga
 
---
---
## Título: Eliminar punto de carga
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
### Escenarios (Criterios de aceptación)
1. #### Eliminar punto de carga sin estar logueado
    - **Dada** una región existente
        **Región**
        | Id  | Nombre               |
        | --- | -------------------- |
        | 1   | Región Metropolitana |
    
    + **Y** los puntos de carga
        **Puntos de carga**
        | Id  | Nombre               | Dirección      | Región               | Descripción    |
        | --- | -------------------- | -------------- | -------------------- | -------------- |
        | 1   | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
        
    - **Cuando** intenta eliminar el punto de carga
        **Punto de carga**
        | Nombre               |
        | -------------------- |
        | Cargar frente al mar |
 
    - **Entonces** el punto de carga no puede ser borrado
 
2. #### Eliminar punto de carga con datos incorrectos
    * **Dado** un usuario logueado como administrador
        
        **Usuario**
        | Email            | Contraseña |
        | ---------------- | ---------- |
        | matias@admin.com | admin      |
        
    + **Y** una región existente
        
        **Región**
        | Id  | Nombre               |
        | --- | -------------------- |
        | 1   | Región Metropolitana |
        
    + **Y** los puntos de carga
        **Puntos de carga**
        | Id  | Nombre               | Dirección      | Región               | Descripción    |
        | --- | -------------------- | -------------- | -------------------- | -------------- |
        | 1   | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
        
    - **Cuando** intenta eliminar el punto de carga
        **Punto de carga**
        | Nombre      |
        | ----------- |
        | Inexistente |
     
    - **Entonces** los puntos de carga para ese/esos nombre/s no pueden ser borrados
 
3. #### Eliminar punto de carga logueado como administrador
    * **Dado** un usuario logueado como administrador
        
        **Usuario**
        | Email            | Contraseña |
        | ---------------- | ---------- |
        | matias@admin.com | admin      |
        
    + **Y** una región existente
        
        **Región**
        | Id  | Nombre               |
        | --- | -------------------- |
        | 1   | Región Metropolitana |
    
    + **Y** un punto de carga existente con datos
        **Punto de carga**
        | Id  | Nombre               | Dirección      | Región               | Descripción    |
        | --- | -------------------- | -------------- | -------------------- | -------------- |
        | 1   | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
    * **Cuando** intenta eliminar el punto de carga
    * **Entonces** debería eliminarse de la lista de puntos de carga
---
---
## Título: Obtener todos los puntos de carga
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
**Para** saber donde puedo cargar mi auto eléctrico
### Escenarios (Criterios de aceptación)
1. #### Obtener todos los puntos de carga sin tener ninguno agregado
      + **Dado** una región existente
        
        **Región**
        | Id  | Nombre   |
        | --- | -------- |
        | 1   | SurOeste |
        
    + **Y** ningún punto de carga
    * **Cuando** se pide la lista de todos los puntos de carga
    - **Entonces** debería mostrarse el mensaje de error "No hay puntos de carga cargados en el sistema"
 
2. #### Obtener todos los puntos de carga
      + **Dado** una región existente
        
        **Región**
        | Id  | Nombre               |
        | --- | -------------------- |
        | 1   | Región Metropolitana |
    
    + **Y** los siguientes puntos de carga existentes
        **Punto de carga**
        | Id  | Nombre               | Dirección      | Región               | Descripción      |
        | --- | -------------------- | -------------- | -------------------- | ---------------- |
        | 1   | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga 1 |
        | 2   | Cargar dentro        | 18 de julio    | Región Metropolitana | Punto de carga 2 |
        
    * **Cuando** se pide la lista de todos los puntos de carga
    * **Entonces** debería mostrarse una lista conteniendo los puntos de carga existentes
---
 
### Aclaraciones:
- Asumimos que en la letra de Definition of Done Sprint 2 cuando se escribe alfabéticos se refiere a alfanuméricos ya que sino no podría ponerse número de puerta para calles
- Asumimos que cuando se menciona una variable de X caracteres en la Definition of Done Sprint 2 se refiere al máximo y no a una cantidad fija a respetar

