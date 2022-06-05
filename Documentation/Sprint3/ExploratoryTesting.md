### Testing exploratorio
#### Objetivo: Encontrar errores en los inputs de crear punto turístico
#### Tiempo: 20 minutos
#### Pruebas
- Escenario 1 - Crear punto turístico caracteres especiales nombre
  - Prueba: Ingreso de caracteres especiales en el nombre de punto turístico.
  - Resultado: El sistema muestra el error "Invalid tourist point name - only alphanumeric en un alert".
- Escenario 2 - Crear punto turístico caracteres especiales descripción
  - Prueba: Ingreso de caracteres especiales en la descripción de un punto turístico.
  - Resultado: El sistema crea el punto de carga exitosamente.
- Escenario 3 - Crear punto turístico sin foto
  - Prueba: Crear un punto turístico sin foto.
  - Resultado: El sistema muestra el error "Es necesario especificar una imágen". Error de ortografía.
- Escenario 4 - Crear punto turístico sin región
  - Prueba: Crear un punto turístico sin región
  - Resultado: El sistema muestra el error "Es necesario especificar una región".
- Escenario 5 - Crear punto turístico sin categoría
  - Prueba: Crear un punto turístico sin categoría.
  - Resultado: El sistema muestra el error "Es necesario especificar al menos una categoría".
- Escenario 6 - Crear punto turístico con nombre largo
  - Prueba: Crear punto turístico con nombre de más de 1000 caracteres.
  - Resultado: El sistema crea el punto de carga exitosamente. Error debería chequearse el largo del nombre.
- Escenario 7 - Crear punto turístico con descripción largas
  - Prueba: Crear punto turístico con descripción de más de 1000 caracteres.
  - Resultado: El sistema crea el punto de carga exitosamente. Error debería chequearse el largo de la descripción.
- Escenario 8 - Crear punto turístico con zip en lugar de imagen
  - Prueba:  Crear punto turístico con zip en lugar de imagen.
  - Resultado: El sistema no muestra ningún mensaje. En la consola se muestra una excepción "Failed to load resource: net::ERR_CONNECTION_RESET". Error debería ser catcheada.

