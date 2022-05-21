# BDD Development Guide
###### tags: `Sprint 2`

En esta iteración se realizaron cambios al tablero kanban de Github Actions por la presencia del desarrollo usando BDD.

Como se mencionó en el sprint planning, optamos por la siguiente configuración del tablero:

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


Por aún estar experimentando con BDD y ser la primera vez que desarollamos código siguiendolo, decidimos dejar abierta la posibilidad de cambiar algún aspecto del tablero (como separar tareas o modificar columnas) si lo veíamos realmente necesario una vez empezaramos a utilizar el kanban.

El atributo de asignados a una tarea se usa para tareas relacionadas con BDD para indicar no los que esten participando en el momento sino aquellos que puedan participar, para distinguir entre el product owner y desarrolladores de la tarea.

El proyecto de desarrollo de bdd utiliza los packages de nuget:
- SpecFlow
- SpecFlow.mstest
- SpecFlow.Tools.MSBuild.Generation

Logramos hacerlo correr en dotnet core 3.1 con mstest a pesar de que en un principio tuvimos que desarrollar usando NUnit.