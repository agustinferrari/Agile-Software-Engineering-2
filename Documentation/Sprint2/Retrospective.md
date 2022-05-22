# Sprint 2 Retrospective
###### tags: `Sprint 2`
### Tablero de Miro DAKI
![Imágen DAKI sprint 2](https://media.discordapp.net/attachments/972236844907515964/978004008822276126/unknown.png?width=568&height=460)

### Drop
- **Eliminar uno de los linters en Backend**: Notamos que la cantidad de warnings por los linters distraen más de lo que ayudan al tener tantas sobre aspectos que hay que configurar. El que tengamos dos solo vuelve el configurarlos una tarea más tediosa, por lo cual tener uno funcional sería mejor que dos no configurados.
- **Eliminar Checklist de Pull Request**: Se repite información en las labels que agregamos en los pull request y la checklist que aparece en su descripción. Ambos informan sobre el tipo de cambio (bug solucionado, añadido de documentación, entre otros) por lo cual no es necesario mantener ambos.

### Add
- **Registro de lo realizado por fecha**: Al usar los proyectos de github no queda un registro claro en que fecha terminamos cada tarea.
- **Uso de Releases en Github**: Para poder ver la evolución del proyecto a lo largo de los sprints.
- **Github Actions de Frontend**: Agregar un workflow para buildear el frontend y correr tests en caso de agregarlos.
- **Controles de Pull Request si falla action**: Agregar un control que no permita mergear el pull request en caso de que haya un problema con el action que esta utilizando.
- **Agregar a Kanban controles y planificación**: Agregar las tareas de contorles y planificación para poder al final evaluar los estimados vs el esfuerzo real por ejemplo.

### Keep
- **Github Actions**: Mantener el uso de las github actions para poder encontrar errores antes de mergear a trunk y ver la cobertura de los tests en cada pull request.
- **Comittizen**: Continuar usando commitizen para tener un formato de commits consistente en todo el repositorio.
- **Live share pair programming**: Seguir haciendo pair programming con live share para poder entender nuevas herramientas (como SpecFlow en esta iteración) y luego poder trabajar en paralelo.
- **Documentación en .md**: Seguir haciendo la documentación en formato md para no tener que convertir los documentos y tener información separada en muchos lugares.
- **Seguir estándar de codificación:** Mantener el estándar de código que se venía utilizando para no romper con la uniformidad.
- **Uso de Miró**: Continuar usando Miró para realizar una lluvia de ideas para la Retrospective. Encontramos que fue más sencillo y visual escribirlas en un tablero y no directamente en un documento.
- **Uso de HackMD**: Continuar usando HackMD para realizar los documentos en formato Markdown. Es muy útil considerando que nos permite escribir en simultáneo y ver, a su vez, cómo va quedando el documento en tiempo real.

### Improve
- **Actualizar README continuamente**: Mejorar el actualizado del readme README de uno por iteración a cada vez que sea necesario, de forma que se actualizaría a medida que se agregan archivos que deberían ser mencionados, o para ocasiones especiales que se deben considerar en equipo.
- **Actualizar esfuerzo continuamente**: Mejorar el actualizado de esfuerzo, ya que en algunas ocasiones se tuvo que agregar esfuerzo de tareas ya completadas despues de cerrar la rama asociada y esto podría llevar a que registros de esfuerzos no sean registrados.
- **Definir estándar de nombrado de PRs**: Mejorar el uso de Pull Requests al definir un estándar ya que algunos títulos se autogeneran a partir del último commit o el nombre de la rama dependiendo de si hay más de un commit en el PR. Se debería definir un estándar de nombre de pull request para el uso de mayúsculas y situaciones de commits individuales.
- **No desarrollar todo al final**: Mejorar el progreso de del desarrollo de las funcionalidades, ya que lo realizamos hacia el final de la iteración. Consideramos que a futuro sería bueno progresar constantemente con el desarrollo pero esta iteración se vio afectada por:
    - Entregas y/o parciales fuera de la materia en cuestión
    - Dudas sobre el uso de specflow que se resolvieron en la segunda semana de la iteración
- **Linters**: Configurar los linters de acuerdo a los estándares de codificación del proyecto.
- **Definir estándar de issues para asignados:** Agregar al encargado de resolver un issue en la plantilla.
- **Seguir estándar de commits**: Considerar el uso de pre-commit de commitzen para forzar un control antes de commitear.
- **Revisar issues para evitar duplicados** Revisar issues antes de agregar nuevos ya que una vez agregado no puede ser eliminado el issue.
- **Estimaciones de esfuerzo**: Mejorar la estimación de esfuerzo requerido para las tareas ya que esta iteración volvimos a pasarnos en tiempo real. Es entendible que por ser la primera vez en que utilizó specflow y gherkin que tuvimos que realizar varios spikes que aumentaron el esfuerzo que en próximas iteraciones no se repetirá.

## Análisis de esfuerzo
![Imágen tabla sprint 2](https://media.discordapp.net/attachments/972236844907515964/978004880818049054/unknown.png?width=960&height=441)

| Etapa       | Estimación       | Real               |
|:----------- | ---------------- |:------------------ |
| Planifación | 12 horas persona | 15 horas persona   |
| Ejecución   | 25 horas persona | 31.5 horas persona |
| Control     | 13 horas persona | 14.5 horas persona |

**Análisis**
En esta iteración mejoramos nuestras estimaciones, ya que en la anterior el esfuerzo real fue más del doble del estimado y en esta a pesar de superar el estimado, fue un 25% mayor y no 100%. En particular notamos malas estimaciones en la ejecución por requerir spikes para aprender las herramientas relacionadas a BDD como SpecFlow y Gherkin. En la etapa de planificación no tomamos en cuenta el tiempo que llevaria la definición de requerimientos lo cual vió un esfuerzo real levemente mayor.
Cabe mencionar que entre las tareas de ejecución incluímos el arreglar los linters pero no pudimos completarlas, por lo cual para el esfuerzo real de ejecución no se pudo incluir estas.

Consideramos que a pesar de haber mejorado en estimar el esfuerzo, aún podemos mejorar en este aspecto ya que un requeriemto de 25% extra de esfuerzo en un contexto real de 8 horas de trabajo diario, implicaría por cada persona 20 horas más de esfuerzo. Esto implicaría más de dos días extra de trabajo lo cuál no sería aceptable como estimación.


