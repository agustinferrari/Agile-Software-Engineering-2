# BDD Guide

El tablero de kanban del proyecto, utilizado en el sprint 2 y 3 contiene las siguientes columnas:

- Sprint Backlog:
  - Contiene todas las tareas planeadas para el sprint que aún no han sido comenzadas, entre estas están también aquellas que fueron validadas y se definieron sus requerimientos siguiendo CCC:
    - Requirements Definition (CCC):
      - **Card**: El product owner escribe el título y la narrativa de la historia
      - **Conversation**: El equipo de desarrollo entrevista al product owner para entender el alcance de la historia. Luego de la conversación escriben los criterios de aceptación (mediante escenarios, utilizando el lenguaje GHERKIN)
      - **Confirmation**: El product owner valida o modifica lo especificado en los criterios de aceptación
- Doing:
  - Contiene toda tarea que se esté realizando y no encaje en el ciclo de BDD presente en el resto de las columnas
- Test Cases Implementation:
  - Contiene las tareas para las cuales se están implementado tests automáticos a partir de los requerimientos definidos en CCC
- Application Implementation:
  - Contiene las tareas que están recibiendo implementación de código para pasar los casos de pruebas que fallan
- Refactoring:
  - Contiene tareas cuyos casos de prueba pasan pero que están recibiendo refactors para mejorar el código
- Waiting for Review
  - Contiene las tareas que hayan sido terminadas y estén esperando por revisión
- Done
  - Contiene las tareas que ya estén revisadas

Por aún estar experimentando con BDD y ser la primera vez que desarrollamos código siguiéndolo, decidimos dejar abierta la posibilidad de cambiar algún aspecto del tablero (como separar tareas o modificar columnas) si lo veíamos realmente necesario una vez empezáramos a utilizar el kanban.

El atributo de asignados a una tarea se usa para tareas relacionadas con BDD para indicar no los que estén participando en el momento sino aquellos que puedan participar, para distinguir entre el product owner y desarrolladores de la tarea.

El proyecto de desarrollo de bdd utiliza los packages de nuget:

- SpecFlow
- SpecFlow.mstest
- SpecFlow.Tools.MSBuild.Generation

Logramos hacerlo correr en dotnet core 3.1 con MSTest a pesar de que en un principio tuvimos que desarrollar usando NUnit.

A partir del sprint 3 se comenzó a desarrollar haciendo automatizaciones de testing funcional siguiendo BDD. Para esto se combinó el uso de SpecFlow de la iteración 2 con la herramienta Selenium en C# en una nueva solución [IntegrationTests](../Source/IntegrationTests/) dentro de la carpeta Source, que al estar aislada de la solución del backend, decidimos utilizar dotnet 6.0 para las pruebas, ya que teníamos mayor experiencia de utilizar selenium con el mismo. Esta sería la solución para pruebas de testing funcional de BDD de ahora en adelante y las pruebas previas en la solución de backend se dejarían a modo de histórico de lo realizado además de pruebas del backend completo.

Se define que la narrativa de las funcionalidades junto a sus escenarios debe previamente definirse en un documento .md del sprint, y luego pasado a gherkin en el proyecto de tests de integración. Estos tests deben incluir un Como, Quiero, Para como narrativa de la funcionalidad.

La estructura de la solución de pruebas de integración es la siguiente:

- Un directorio "/Features" donde se encuentran los archivos .feature de los tests de funcionalidad
- Un directorio "/Steps" donde se encuentran todos los step definitions para los tests de funcionalidad, incluyendo uno por cada funcionalidad y un common donde se implementaron pasos utilizados por varias funcionalidades.
- Un directorio "./Models" donde se encuentran modelos de entidades para poder convertir fácilmente lo recibido en las tablas de examples de los .feature.
- Utils que contiene herramientas para facilitar la creación de pruebas, donde está contenido el SeleniumTestHelper al que le asignamos la responsabilidad de esperar por elementos, hacer click sobre elementos, y algunas acciones que se veían repetidas en pasos diferentes como llenar forms.
