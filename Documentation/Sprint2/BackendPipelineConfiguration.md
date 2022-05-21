# Backend Pipeline Configuration

###### tags: `Sprint 2`

## Github Actions

En esta iteración hicimos uso de las herramientas de github actions para configurar un pipeline en particular para el backend del proyecto.

Esta pipeline resulto en un workflow con un solo job bajo el nombre "build", que es ejecutado cuando se pushea o hace un pull request a la rama main, o a ramas que sigan el formato feature/** o fix/**.

El job corre en ubuntu-latest y usa de base la github action de .Net, la cual ejecuta un build y un test de todas las pruebas del proyecto de backend haciendo uso de otras actions como checkout.

Las adiciones a este workflow default fueron:

- Cuando se ejecuta dotnet test que se guarde el coverage de las pruebas, tomando en cuenta el archivo SettingsCoverage.xml que se encuentra dentro del directorio [Source/MinTurBackend](../../Source/MinTurBackend/SettingsCoverage.xml) para ignorar los archivos de migraciones. Esto nos pasa de un code coverage menor a 90& al esperado de 93%.
  ```yml
  - name: Dotnet coverage
      run: dotnet tool install --global dotnet-coverage

  ```
  ```yml
  - name: coverage
    working-directory: ./Source/MinTurBackend/
    run: dotnet test --no-build --verbosity normal --collect:"XPlat Code Coverage" --settings SettingsCoverage.xml --logger trx --results-directory coverage
  ```
- Dado que tenemos varios proyectos de testing, nos encontramos con el problema de varios code coverage separados, lo cual usamos la herramienta de dotnet-coverage para juntarlos en un único archivo, el cual subimos como artefacto en caso de que a futuro se quiera revisar.
  ```yml
  - name: Combine coverage files
    working-directory: ./Source/MinTurBackend/
    run: dotnet-coverage merge --remove-input-files -r --output-format cobertura ./coverage/*/coverage.cobertura.xml
    - name: Upload combined coverage files
    uses: actions/upload-artifact@v3
    with:
        name: Combined_Test_Coverage
        path: ./Source/MinTurBackend/output.cobertura.xml
  ```
- Luego de poder obtener el code coverage a partir del workflow y juntarlos con la herramienta dotnet-coverage, decidimos usar la herramienta [CodeCoverageSummary](https://github.com/irongut/CodeCoverageSummary) para poder exportar el coverage a un archivo .md que luego podríamos insertar facilmente en un pull request para ver como evoluciona el coverage en cada rama.
  El problema que encontramos fue que el archivo .xml en formato cobertura que obteniamos combinando todos los coverages, no era compatible con la versión de [CodeCoverageSummary](https://github.com/irongut/CodeCoverageSummary) publicada en el marketplace, pero al investigar un poco mas, vimos que habían un issue de otro usuario con el mismo problema que nosotros y ya habia sido solucionado pero no se había hecho una release con el parche.
  Es por esto que decidimos hacer una release y publicarla en el [marketplace](https://github.com/marketplace/actions/code-coverage-report-temp), aprovechando que el codigo se encuentra bajo licencia MIT, de todas formas una vez la release oficial se haga o se termine el proyecto, nuestra release será borrada del marketplace.
  ```yml
  - name: Code coverage summary report test
    uses: agustinferrari/CodeSummaryReportTemp@v1.3.0
    with:
        filename: ./Source/MinTurBackend/output.cobertura.xml
        badge: true
        format: markdown
        output: both
    - name: Add coverage PR comment
    uses: marocchino/sticky-pull-request-comment@v2
    if: github.event_name == 'pull_request'
    with:
        recreate: true
        path: code-coverage-results.md
  ```

## Tablero Kanban

**Tablero**
![](https://media.discordapp.net/attachments/972236844907515964/977672334397808751/unknown.png?width=1920&height=325)

Además hicimos uso de los [proyectos beta de github](https://github.com/orgs/ORT-ISA2-2022S1/projects/11/views/2) los cuales nos permitieron relacionar issues con su tarjeta en el tablero, de manera que cuando un pull request es cerrado, el issue también lo es y se mueve automáticamente la pieza a la columna de waiting for review.

**Workflow al cerrar issue**
![](https://media.discordapp.net/attachments/972236844907515964/977672409022885958/unknown.png?width=1920&height=775)

En el caso de que se volviera a abrir el issue se vuelve a pasar la tarjeta a doing para dejar visible las tareas restantes del sprint.

**Workflow al reabrir issue**
![](https://media.discordapp.net/attachments/972236844907515964/977672463636893756/unknown.png?width=1920&height=698)

En algunos casos nos vimos limitados por la ausencia de poder crear nuestras propios "workflows" del tablero por aún estar en beta, entre estos el que solo se pueda llegar a cambiar el estado de una tarjeta y no poder ejecutar algun otro tipo de acción al detectar un cambio en el tablero.
