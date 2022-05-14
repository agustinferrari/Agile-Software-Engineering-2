# Planning Meeting Sprint 2 <!-- omit in toc --> 
###### tags: `Sprint 2` `Planning` <!-- omit in toc --> 


<!-- omit in toc --> 
## Índice <!-- omit in toc --> 
- [Características Sprint](#características-sprint)
- [Objetivos](#objetivos)
- [Sprint Backlog](#sprint-backlog)
  - [Planificación](#planificación)
  - [Ejecución](#ejecución)
  - [Control](#control)
- [Definition of Done](#definition-of-done)
  - [Para las actividades](#para-las-actividades)
  - [Para el sprint](#para-el-sprint)
- [Esfuerzo y duración de etapas](#esfuerzo-y-duración-de-etapas)
- [Capacidad](#capacidad)

## Características Sprint
A diferencia del sprint anterior, este está enfocado en agregar nueva funcionalidad siguiendo BDD (Behaviour Driven Development) y arreglar bugs e issues conocidos manteniendo el proyecto.

Para esto debemos actualizar el tablero de kanban usado en la sección de Github Projects para incluir estas nuevas columnas de las tareas:

- Sprint Backlog:
    - Contiene todas las tareas planeadas para el sprint que aún no han sido comenzadas, entre estas están tambien aquellas que fueron válidadas y se definieron sus requerimientos siguiendo CCC:
        - Requirements Definition (CCC):
            - **Card**: El product owner escribe el título y la narrativa de la historia
            - **Conversation**: El equipo de desarrollo entrevista al product owner para entender el alcance de la historia. Luego de la conversación escriben los criterios de aceptación (mediante escenarios, utilizando el lenguaje GHERKIN)
            - **Confirmation**: El product owner valida o modifica lo especificado en los criterios de aceptación
- Doing:
    - Contiene toda tarea que se esté realizando y no encaje en el ciclo de BDD presente en el resto de las columnas
- Test Cases Implementation:
    - Contiene las tareas para las cuales se están implementado tests automáticos a partir de los requerimientos definidos en CCC
- Application Implementation:
    - Contiene las tareas que estan recibiendo implementación de código para pasar los casos de pruebas que fallan
- Refactoring:
    - Contiene tareas cuyos casos de prueba pasan pero que estan recibiendo refactors para mejorar el código
- Waiting for Review
    -  Contiene las tareas que hayan sido terminadas y estén esperando por revisión
- Done
    - Contiene las tareas que ya estén revisadas

Tenemos planeado permitirnos el agregar tareas o modificar aspectos del tablero si lo consideramos necesario, ya que puede tener defectos que no hayamos previsto por ser la primera vez que seguimos BDD para implementar código funcional.

Otro cambio con respecto a la iteración anterior es el paso a tareas con un enfoque más individual de desarrollo y no documentación grupal. No quita el hecho de que vamos a documentar lo realizado y que van a haber tareas grupales, sino que el enfoque pasó a un trabajo más en paralelo.

Para mantenernos informados de lo que están trabajando nuestros compañeros vamos a realizar periodic meetings en las que comentarmos problemas, descubrimientos y opiniones del trabajo en progreso.

## Objetivos
Cumplir con lo esperado de este sprint, siendo esto el arreglar dos issues de más severidad, agregar la funcionalidesn de alta y baja de puntos de carga de autos eléctricos y una guía de la configuración de la pipeline del proyecto.

## Sprint Backlog
### Planificación
- Sprint Planning
- Requirements Definition (CCC)

### Ejecución
- Configuracion de linters:
    - Frontend
    - Backend
- Configuración de pipeline (Github Actions Workflows):
    - Backend
        - Build
        - Test
    - Automatización de issues con kanban
    - Guía de pipeline
- Implementación a backend siguiendo BDD:
    - Agregar un punto de carga
        - Descripción: Poder agregar un punto de carga de autos eléctricos
        - Product Owner: **Joaquín Meerhoff**
    - Elminar un punto de carga
        - Descripción: Poder eliminar un punto de carga de autos eléctricos existente
        - Product Owner: **Sofía Decuadra**
    - Guía de desarrollo con BDD
- Mantenimiento arreglando issues de mayor prioridad
    - [**"Unnecesary data in database"**](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/34)
        - Descripción: Cuando se remueve un hospedaje, la base datos mantiene guardada la imágen a pesar de ser innecesario
        - Product Owner: **Sofia Decuadra**
    - ["**Unable to create reservation starting from today**"](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/25)
        - Descripción: Cuando se intenta crear una reserva que comienza el día en el que se crea, la IU muestra un error que indica que las reservas no pueden arrancar ayer.
        - Product Owner: **Agustín Ferrari**

### Control
- Sprint Review
    - Estimación: 6 horas persona
- Sprint Retrospective
    - Estimación: 3 hora persona
- Sprint Report
    - Estimación: 4 horas persona

## Definition of Done
### Para las actividades
- Estimación de tiempo para realizar la tarea en caso de que no sea una tarea repetitiva (como encontrar issues, ya que no tiene un fin). Las estimaciones serían medidas en horas ideales
- Estimación de tiempo para realizar una columna específica de una tarea si sigue BDD
- Tiempo real que llevó el realizar la tarea una vez completada
- Miembros del equipo asignados a la tarea o que participaron en ella
- Prioridad de la tarea con respecto a las demás en una escala de "low", "medium" y "high"
- Si incluye implementación de código, debe pasar por una review con el Product Owner asignado.
- Sería considerada terminada una vez que esta llegue a la columna de done en el tablero de kanban de github projects

### Para el sprint
- El mantenmiento del proyecto al arreglar dos issues a decidir
- La implementación de la funcionalidad de Backend sobre los puntos de carga para autos eléctricos, incluyendo el alta y baja de estos.
- Guía de la configuración de la pipeline del proyecto en archivo markdown
- Review de los Product Owners de las funcionalidades arregladas o agregadas
- Uso de issues en github para reportar bugs utilizando labels definidas por nosotros para organizar
- Detalle de registro de esfuerzo por tarea e integrantes.
- Retrospectiva basada en DAKI


## Esfuerzo y duración de etapas

|          | Planificación    |    Ejecución     | Control          |
|:--------:|:---------------- |:----------------:|:---------------- |
| Esfuerzo | 12 horas persona | 25 horas persona | 13 horas persona |
| Duración | 4 horas reales   | 14 horas reales  | 4.5 horas reales |

## Capacidad

|    Integrante    | Horas ideales | Horas reales |
|:----------------:|:-------------:|:------------:|
|  Sofía Decuadra  |      20       |      17      |
| Agustín Ferrari  |      20       |      17      |
| Joaquín Meerhoff |      20       |      17      |






