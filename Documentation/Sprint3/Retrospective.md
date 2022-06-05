# Sprint 3 Retrospective

###### tags: `Sprint 3`

### Tablero de Miro DAKI

![Imágen DAKI sprint 3](https://media.discordapp.net/attachments/972236844907515964/982784232193658900/unknown.png)

### Drop

- **Effort a mano en tabla**: Utilizar herramientas que permitan registrar el esfuerzo de manera automática.
- **Github projects como herramienta principal**: Si bien consideramos que Github Projects es bueno para el manejo de issues, hay herramientas que podrían darnos más libertad para la administración de tareas. Sería conveniente tener alguna manera de asociar claramente las tareas con las historia (por ejemplo, asignandoles un color), pero no es una opción.

### Add

- **Herramientas de tracking de tareas (Toggl)**: Utilizar esta herramienta para registrar el esfuerzo de manera automática. De esta manera obtenemos una mayor exactitud y fácilidad a la hora de registrarlo.
- **Automatizar cálculo de métricas**: Buscar herramientas que nos ayuden a calcular métricas.
- **SQL en memoria para pruebas de integración**: Permitir utilizar la base de datos en memoria para realizar pruebas de integración y no tener que hostearla de forma separada.

### Keep

- **Github Copilot**: Continuar usando github copilot creación de codigo en frameworks con los cuales no estemos totalmente familiarizados.
- **Liveshare**: Continuar usando liveshare cuando se quiere hacer pair programming o se cincha el andon cord para que todos podamos ver y trabajar a la vez en el código.
- **Github actions**: Continuar el uso de acciones de github para acelerar los ciclos de feedback en casos de errores, ya sean por ambientes locales diferentes a los esperados llevando a que pasen pruebas solo en la máquina de un miembro del equipo.
- **Commitizen**: Continuar usando commitizen para crear commits con una estructura más ordenada.
- **Estándar en nombres de PR**: Continuear usando el estándar de nombres de PR para facilitar la lectura de los mismos cuando se muestra en una lista.
- **Checklist en PR**: Continuar usando la checklist de PR para asegurarnos de que no nos olvidemos de algunos pasos o revisiones manuales que son de importante realización antes de mergear la rama del PR.
- **Análisis de Metricas**: Continuar actualizando el documento de análisis de métricas para poder ver la evolución del proyecto a lo largo del sprint.
- **Reviews al final del sprint**: Continuar haciendo reviews al final del sprint y no en cada pull request para reducir los cuellos de botella al momento de desarrollar y fomentar el mergeo frecuente y continuo.
- **Baja cantidad de linters**: Mantener una baja cantidad de linters para que las warnings no se superpongan entre los mismos. En el primer sprint se usaron dos linters para backend, lo que resultada en una cantidad inmensa de warnings, por lo cual decidimos eliminar uno de los dos y configurarlo correctamente para seguir el estándar de codificación planteado.
- **Commits con colaboradores**: Continuar haciendo commits grupales que reflejen el trabajo que se hace en equipo, mostrando que el trabajo resultante de pair programming no solo pertence al que haga el commit, sino que es una parte de un trabajo en equipo.
- **Releases**: Mantener el uso de releases que determinan el trabajo que se hace en cada sprint.

### Improve

- **Estándar de codificación**: Desarrollar más los estándares de cofidicación y asegurar el que se sigan en todos los proyectos, ya sea backend, frontend o de prueba. Para esto se podría hacer uso de linters.
- **Linters**: Profundizar el uso de estos, a pesar de haber mejorado las configuraciones en este sprint. See nota que pueden tener más utilidad de la que estamos aprovechando.
- **Tareas con más partes**: Separar en más partes tareas grandes para fomentar la actualización de partes chicas y no el contenido dentro de las tarjetas grandes.
- **Uso de story points**: Aumentar el uso de story points para medir el trabajo que se hace en cada sprint, que por el momento se a hecho poco enfasis en su importancia para métricas.
- **Ignorar archivos autogenerados**: Ignorar archivos autogenerados por pruebas como las de la solución de pruebas de integración, ya que podrían autogenerarse diferente y llevar a cambios inesperados por solo correr las pruebas. 
- **HackMD**: Sincronizar HackMD con el repositorio de GitHub, ya que el estado desactualizado puede llevar a no querer ser el responsable de los cambios en caso de diferencias.
- **Readme por proyecto**: Crear un readme por proyecto que contenga información sobre el mismo.
- **Estimación de esfuerzo**: Mejorar la estimación de esfuerzo, haciendo más enfoque en la etapa de planificación para tener más tiempo para pensar sobre que podría necesitar el desarrollo de funcionalidades.

## Análisis de esfuerzo

![Imágen tabla sprint 3](https://cdn.discordapp.com/attachments/972236844907515964/982796943401025566/unknown.png)

| Etapa       | Estimación         | Real                |
| :---------- | ------------------ | :------------------ |
| Planifación | 9 horas persona    | 12 horas persona    |
| Ejecución   | 15 horas persona   | 57.55 horas persona |
| Control     | 16.5 horas persona | ~20.5 horas persona\* |

**Análisis**
En esta iteración se estimó por debajo el esfuerzo necesario para completar las funcionalidades de agregar y eliminar puntos de carga a lo largo de todo el proyecto.
En un principio se estimaba estar 15 horas por persona ya que las herramientas necesarias para el desarrollo restante ya habían sido utilizadas, pero no se tuvo en cuenta las posibles dificultades como la necesidad de implementar el obtener los puntos de carga o independizar las pruebas de integración entre sí.

Un factor que también tuvo influencia sobre el esfuerzo real, fue el feedback que se recibió con respecto a iteraciones previas, lo cual nos llevó a incluir tareas que no habíamos planificado en un principio.

Se terminó teniendo que realizar un esfuerzo de 280% más de lo esperado en la etapa de ejecución, ya que se esperaba un esfuerzo de 15 horas y se terminó desarrollando por 57.55 horas. Es importante tomar en cuenta que estas horas incluyen mantenimiento, documentación y algunos otros aspectos del proyecto que quizas en un principio no tuvimos en cuenta para las 15 horas planificadas.

Con respecto a la planificación, se trabajo un 33.33% más de lo esperado, ya que se esperaba un esfuerzo de 9 horas y se terminó planificando por 12 horas.

---
*Aún no se terminó el sprint 3 por lo cual no se puede calcular el tiempo real todavía.