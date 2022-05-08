# Proceso de Ingeniería
## División de sprints
En cada entrega del obligatorio vamos a realizar un sprint, por lo cual cada sprint nos va a llevar dos semanas y en total serían tres sprints

## Estándares de codificación
Para continuar el estilo de codificación presente en el proyecto a mantener, decidimos continuar escribiendo el código en inglés.

Esto es igual que los issues, pull requests, commits y todo lo que refiere al manejo de git para favorecer la mantenibilidad del proyecto y mantener el estándar presente en el material recibido. 

Además tenemos la intención de utilizar linters para mantener un estándar de codificación como la cantidad de caracteres por línea, la cantidad de líneas por método, cantidad de líneas por clase, si los espaciados se harían con tabs o con espacios, y cuántos de ellos, entre otros.

En esta iteración buscamos instalar linters que nos funcionen a todos, siendo estos eslint para el frontend y stylecop con sonarlint para el backend. La configuración de estos al estándar de codificación del material del obligatorio será realizado en iteraciones siguientes, por lo cual hay presentes grandes cantidades de errores de estilo por preferencias en el estilo de programación.

## Criterios
### Criterios de ramas

Siguiendo lo dado en clase, tomamos la decisión de aplicar trunk-based lo que implicaría que estas ramas sean cortas y no duren más de un día. Esto evitaría o reduciría la cantidad de conflictos al mergear ya que se estaría menos tiempo separado del trunk que recibe cambios.

Algunos nombres de ramas:
- “main” sería la rama principal o el trunk del proyecto
- “feature/[ejemplo]” sería una rama que implementa la funcionalidad X.
- “refactor/[ejemplo]” sería una rama que modifica codigo pero no arregla ningún bug ni agrega ninguna feature.
- “fix/[ejemplo]” sería una rama que arregla uno o más bugs asociados a Y.
- “style/[ejemplo]” sería una rama no cambia codigo, unicamente estilos y/o configuración de linters.
- “docs/[ejemplo]” sería una rama que agrega documentación sobre el aspecto Z


### Criterios de Commit

Desde un principio planteamos el uso de la herramienta de [commitizen](https://commitizen-tools.github.io/commitizen/) que brinda la oportunidad de manejar un estándar de commits entre todos los intregrantes. 

Además los commits no deben desestabilizar el código por lo cual en cada commit las pruebas unitarias deben pasar.

El tamaño de los commits debería mantenerse pequeño de manera que posibles errores puedan ser fácilmente encontrados.

### Criterios de Pull Request

Consideramos que para facilitar y evitar pérdidas de tiempo a la hora de mergear podría ser útil el uso de [template](/.github/pull_request_template.md) para pull request. Estos evitarían falta de información importante cuando se pida una review por parte de otra persona.

Para realizar merge a la rama principal debe pasar este por un pull request y no por otro medio como la consola de git.

Al igual que los commit, los pull request deben ser cortos de manera que futuras revisiones sobre estos no requieran una investigación profunda para encontrar posibles errores.

Los Code Reviews lo consideramos una herramienta para circumstancias especiales y una obligación para cada pull request porque podría volverse un cuello de botella y perder la importancia que tienen estos cuando realmente se necesitan.



### Criterios de issues

Al igual que para los pull requests, consideramos que el crear un issue debería ser sencillo para favorecer el reporte constante de los problemas que se encuentren. Por lo tanto también utilizamos un [template](/.github/ISSUE_TEMPLATE/bug_report.md) para los issues, basado en el template de github con modificaciones realizadas por nosotros.


###  Labels

Para los labels decidimos crear dos tipos:
- type
    - bug
    - documentation
    - configuration
    - duplicate
    - enhancement
    - invalid
- priority
    - high
    - medium
    - low

## Ceremonias

Las ceremonias que utilizaremos son: 
### Sprint Planning

Para la Sprint Planning nos basamos en SCRUM, aunque no utilizaremos todas las reglas definidas en el mismo.
Cada Sprint Planning estará compuesta por las siguientes partes:

* Objetivos del Sprint
* Sprint Backlog
* Definition of Done
    - Para todas las actividades
    - Para el sprint en general
* Esfuerzo y duración de etapas
* Capacidad

### Sprint Retrospective

La Sprint Retrospective será realizada siguiendo el formato DAKI y basándose en datos de las acciones realizadas en el Sprint para la toma de decisiones y discusiones.

## Artefactos
- Definition of Done
- Sprint y Product Backlog
- Tablero de Kanban
    - Incluye a quien se le asigno una actividad
    - Tiempo estimado de actividad
    - Prioridad de actividad en el sprint

## Herramientas y Frameworks
- Commitizen
- HackMD
- Visual Studio
- Docker
- Visual Studio Code
- Selenium
- Specflow
- Angular
- Dotnet Core
- Azure Data Studio y SSMS (SQL Server Manager Studio)
- Linters
    - ESLint
    - SonarLint
    - StyleCop


----



