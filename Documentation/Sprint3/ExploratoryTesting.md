### Testing exploratorio
#### Objetivo: Encontrar errores en los inputs de crear punto turistico
#### Tiempo: 20 minutos
#### Pruebas
- Escenario 1 - Crear punto turistico caracteres especiales nombre
  - Prueba: Ingreso de caracteres especiales en el nombre de punto turistico.
  - Resultado: El sistema muestra el error "Invalid tourist point name - only alphanumeric en un alert".
- Escenario 2 - Crear punto turistico caracteres especiales descripción
  - Prueba: Ingreso de caracteres especiales en la descripción de un punto turistico.
  - Resultado: El sistema crea el punto de carga exitosamente.
- Escenario 3 - Crear punto turistico sin foto
  - Prueba: Crear un punto turistico sin foto.
  - Resultado: El sistema muestra el error "Es necesario especificar una imágen". Error de ortografía.
- Escenario 4 - Crear punto turistico sin región
  - Prueba: Crear un punto turistico sin región
  - Resultado: El sistema muestra el error "Es necesario especificar una región".
- Escenario 5 - Crear punto turistico sin categoria
  - Prueba: Crear un punto turistico sin categoria.
  - Resultado: El sistema muestra el error "Es necesario especificar al menos una categoría".
- Escenario 6 - Crear punto turistico con nombre largo
  - Prueba: Crear punto turistico con nombre de mas de 1000 caracteres.
  - Resultado: El sistema crea el punto de carga exitosamente. Error debería checkearse el largo del nombre.
- Escenario 7 - Crear punto turistico con descripción largas
  - Prueba: Crear punto turistico con descripción de mas de 1000 caracteres.
  - Resultado: El sistema crea el punto de carga exitosamente. Error debería checkearse el largo de la descripción.
- Escenario 8 - Crear punto turistico con zip en lugar de imagen
  - Prueba:  Crear punto turistico con zip en lugar de imagen.
  - Resultado: El sistema no muestra ningun mensaje. En la consola se muestra una excepción "Failed to load resource: net::ERR_CONNECTION_RESET". Error deberia ser catcheada.
