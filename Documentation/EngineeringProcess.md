# Proceso de Ingeniería

## División de sprints

Para cada entrega del obligatorio vamos a realizar un sprint, lo que implica una duración de sprint de dos semanas y un total de 3 sprints.

## Estándares de codificación

Para continuar el estilo de codificación presente en el proyecto a mantener, decidimos continuar escribiendo el código en inglés.

Esto es igual en los issues, pull requests, commits y todo lo que refiere al manejo de git para favorecer la mantenibilidad del proyecto y mantener el estándar presente en el material recibido.

Además tenemos la intención de utilizar linters para mantener un estándar de codificación como la cantidad de caracteres por línea, la cantidad de líneas por método, cantidad de líneas por clase, si los espaciados se harían con tabs o con espacios, y cuántos de ellos, entre otros.

En esta iteración buscamos instalar linters que nos funcionen a todos, siendo estos eslint para el frontend y stylecop con sonarlint para el backend. La configuración de estos al estándar de codificación del material del obligatorio será realizado en iteraciones siguientes, por lo cual hay presentes grandes cantidades de errores de estilo por preferencias en el estilo de programación.

## Criterios

### Criterios de ramas

Siguiendo lo dado en clase, tomamos la decisión de aplicar trunk-based lo que implicaría que estas ramas sean cortas y no duren más de un día. Esto evitaría o reduciría la cantidad de conflictos al mergear ya que se estaría menos tiempo separado del trunk que recibe cambios.

Algunos nombres de ramas:

- “main” sería la rama principal o el trunk del proyecto
- “feature/[ejemplo-X]” sería una rama que implementa la funcionalidad X.
- “refactor/[ejemplo-X]” sería una rama que modifica código pero no arregla ningún bug ni agrega ninguna feature.
- “fix/[ejemplo-Y]” sería una rama que arregla uno o más bugs asociados a Y.
- “style/[ejemplo-X]” sería una rama que no modifica código, únicamente estilos y/o configuración de linters.
- “docs/[ejemplo-Z]” sería una rama que agrega documentación sobre el aspecto Z.
- “test/[ejemplo-N]” sería una rama en la que unicamente se realizan tests.

### Criterios de Commit

Desde un principio planteamos el uso de la herramienta de [commitizen](https://commitizen-tools.github.io/commitizen/) que brinda la oportunidad de manejar un estándar de commits entre todos los intregrantes.

Además, los commits no deben desestabilizar el código por lo cual en cada commit las pruebas unitarias deben pasar.

El tamaño de los commits debería mantenerse pequeño de manera que posibles errores puedan ser fácilmente encontrados.

### Criterios de Pull Request

Consideramos que para facilitar y evitar pérdidas de tiempo a la hora de mergear podría ser útil el uso de un [template](/.github/pull_request_template.md) para pull requests. Estos evitarían falta de información importante cuando se pida una review por parte de otra persona.

Para realizar merge a la rama principal debe pasar este por un pull request y no por otro medio como la consola de git.

Al igual que los commit, los pull request deben ser cortos de manera que futuras revisiones sobre estos no requieran una investigación profunda para encontrar posibles errores.

Los Code Reviews lo consideramos una herramienta para circunstancias especiales y no una obligación para cada pull request porque podría volverse un cuello de botella y perder la importancia que tienen estos cuando realmente se necesitan.

### Criterios de issues

Al igual que para los pull requests, consideramos que el crear un issue debería ser sencillo para favorecer el reporte constante de los problemas que se encuentren. Por lo tanto, también utilizamos un [template](/.github/ISSUE_TEMPLATE/bug_report.md) para los issues, basado en el template de github con modificaciones realizadas por nosotros.

### Criterios de Labels

Para los labels decidimos crear dos tipos:

- type
  - bug
  - documentation
  - configuration
  - duplicate
  - enhancement
  - invalid
- priority
  - low
  - medium
  - high

### Criterios de Programación

Ya que no había un estándar de programación presentado en un principio por el material del obligatorio, se tuvo que presentar estándares para el frontend y backend.

#### Backend

Aprovechando la presencia del linter Sonarlint, se hace uso de las [convenciones de programacion de Microsoft para C#](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions). Algunos de los aspectos principales:

| Atributo                                           | Estándar                               | Descripción o Ejemplo  | Solución                              |
| :------------------------------------------------- | :------------------------------------- | :--------------------- | :------------------------------------ |
| Nombre de clases                                   | Pascal case                            | Data Service           | DataService                           |
| Nombre de interfaces                               | I + Pascal case                        | Worker Queue Interface | IWorkerQueue                          |
| Nombre atributos publicos                          | Pascal Case                            | User Name              | UserName                              |
| Nombre de variables locales                        | Camel case                             | Current Number         | currentNumber                         |
| Nombre de variables privadas, estáticas o internal | \_ + Camel case                        | Worker Queue           | \_workerQueue                         |
| Uso de tipo var para variables                     | Solo cuando es claro por la asignación | Variable `"hola"`      | `var1 = "This is clearly a string.";` |
| Nombre de proyectos en la solución MinTur          | MinTur. + Pascal case                  | Charging Spot          | MinTur.ChargingSpot                   |

#### Frontend

El estándar del frontend se realizo a partir del estado del código presente en el material de obligatorio. Esto llevo a seguir los siguientes aspectos:

| Atributo                         | Estándar              | Descripción o Ejemplo    | Solución               |
| :------------------------------- | :-------------------- | :----------------------- | :--------------------- |
| Nombre de clases                 | Pascal case           | Data Service             | DataService            |
| Nombre de interfaces             | I + Pascal case       | Worker Queue Interface   | IWorkerQueue           |
| Nombre atributos publicos        | Pascal Case           | User Name                | UserName               |
| Nombre de métodos publicos       | Camel Case            | Delete One Administrator | deleteOneAdministrator |
| Nombre de variables locales      | Camel Case            | New Administrator        | newAdministrator       |
| Nombres de carpetas y archivos   | Kebab Case            | Charging Spot List       | ./charging-spot-list   |
| Nombres de archivos de servicios | Kebab Case + .service | Admin Service            | admin.service.ts       |

#### Comentarios

Se planteó presentar un estándar de columnas por línea pero por la variedad en largo por todo el código del material, no se ha definido un estándar.

## Ceremonias

Las ceremonias que utilizaremos son:

### Sprint Planning

Para la Sprint Planning nos basamos en SCRUM, aunque no utilizaremos todas las reglas definidas en el mismo.
Cada Sprint Planning estará compuesta por las siguientes partes:

- Objetivos del Sprint
- Sprint Backlog
- Definition of Done
  - Para todas las actividades
  - Para el sprint en general
- Esfuerzo y duración de etapas
- Capacidad

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

| Herramienta                      | Descripción                                                                           |
| :------------------------------- | :------------------------------------------------------------------------------------ |
| Commitizen                       | Ayuda a mantener estándares en commits                                                |
| HackMD                           | Colaboración como Google Docs para archivos Markdown                                  |
| Visual Studio                    | IDE                                                                                   |
| Visual Studio Code               | IDE                                                                                   |
| Live Share                       | Extensión de Visual studio code que permite colaborar como en google docs             |
| Docker                           | Levantar contenedores con imágen de base de datos SQL Server                          |
| Selenium                         | Automatización de pruebas funcionales en el frontend                                  |
| SpecFlow                         | Desarrollo en BDD                                                                     |
| Angular                          | Framework usado para el desarrollo del Frontend                                       |
| Dotnet Core                      | Framework usado para el desarrollo del Backend                                        |
| SQL Server Manager Studio (SSMS) | Consultas y manejo de datos de prueba en base de datos SQL server                     |
| Azure Data Studio                | Consultas y manejo de datos de prueba en base de datos SQL server en MacOS            |
| Linter: ESLint                   | Linter utilizado en Frontend                                                          |
| Linter: SonarLint                | Linter utilizado en Backend                                                           |
| Github Copilot                   | Asistente de Github para pair programming que recomienda código a partir del contexto |
