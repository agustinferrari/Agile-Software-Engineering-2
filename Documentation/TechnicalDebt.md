# Análisis deuda técnica
###### tags: `Sprint 1`
## Análisis con NDepend
Para analizar la deuda técnica del proyecto utilizamos la herramienta NDepend junto a estadísticas de Visual Studio sobre los tests.
En un principio notamos que la cobertura de código descrita en la documentación coincidía con el de Visual Studio pero en NDepend este no era el mismo. Asumimos que esto es porque NDepend no toma en cuenta los tags de ignorar partes de código para la cobertura.
 
### Métricas
 
![](https://media.discordapp.net/attachments/972236844907515964/972256993169535026/unknown.png?width=549&height=459)
 
Está gráfica compara las métricas de inestabilidad contra abstracción con el objetivo de mostrar aquellos paquetes que se alejan de la secuencia principal (métrica de distancia normalizada) con el fin de identificarlos y modificarlos si es necesario.
 
Los paquetes que se encuentran sobre la secuencia principal son:
- ServiceRegistration
- ImporterInterface
- BusinessLogic
- DataAccess
- JSONImporter
 
Dentro de la Zone of Pain encontramos a los paquetes:
- Exceptions
- Domain
 
Como se menciona en la documentación provista, estas métricas son esperables por priorizar CRP (Common Reuse Principle).
 
En particular, el paquete de Exceptions resulta en una cohesión relacional H de 0 por priorizar CRP antes de CCP (Common Closure Principle) y esto también se menciona en la documentación.
 
Ambos paquetes rompen el principio de SAP (Stable Abstractions Principle) por ser estables pero poco abstractos. Esto implica que muchos dependen de estos y que son concretos, lo cual un cambio en estos se propagaría en gran parte del proyecto.
 
Casi al otro extremo, siendo muy abstracto y medio estable, se encuentran los paquetes:
* DataAccessInterface
* BusinessLogicInterface
 
Encontramos que podrían tener mejor métrica si se eliminaran dependencias innecesarias a otros paquetes, ya que estas dependencias los hacen menos estables.
* DataAccessInterface depende de Exceptions y no es usado ya que no incluye implementación, sino que solo interfaces.
* BusinessLogicInterface depende de ImporterInterface que al igual que las excepciones en DataAccessInterface, no usan usadas por no implementar código.
 
Con respecto a principios, se rompe el SDP (Stable Dependency Principle) en la dependencia de ServiceRegistration a BusinessLogic, ya que se pasa de un paquete más estable a uno menos estable.
 
**Dependencia de ServiceRegistration a BusinessLogic**
![](https://media.discordapp.net/attachments/972236844907515964/972255085503578193/unknown.png?width=960&height=413)
 
**Métricas ServiceRegistration**
![](https://media.discordapp.net/attachments/972236844907515964/972256108888600658/unknown.png)
 
**Métricas BusinessLogic**
![](https://cdn.discordapp.com/attachments/972236844907515964/972256195106717726/unknown.png)
 
 
### Deuda técnica según NDepend
![](https://media.discordapp.net/attachments/972236844907515964/972245213110218802/unknown.png)
 
Utilizando la métrica de deuda técnica de NDepend, se podría sacar la conclusión de que es baja por el rating A, teniendo una deuda de 3 días y 5 horas, un interés anual de 1 día y 5 horas, y un breaking point de 2 años y tres meses.
 
Lo que esto nos dice es cuánto tiempo debemos dedicarle a refactor del código existente, para evitar que en 2 años ya no sea eficiente trabajar sobre este.
 
La forma en que NDepend calcula esta métrica es utilizando factores del estilo de linters, además de cobertura de código, entre otros. Por ejemplo:
- La falta de cobertura de testing en los equals de entidades de dominio
- Nombres de métodos con Try deberían devolver booleanos en vez de ser void
 
Esto no quita que algunas reglas según NDepend se rompan, pero en el contexto del proyecto son decisiones tomadas que tendrían sentido, por ejemplo:
- Se advierte de clases con muchos métodos al usar el patrón fachada
- Se advierte de constructores de clases no utilizados, pero es por reflection que usado fuera del proyecto.
 
En la siguiente foto se muestra reglas de NDepend que no fueron respetadas y la deuda
![](https://media.discordapp.net/attachments/972236844907515964/972251201074765915/unknown.png?width=960&height=443)
 
## Análisis de código y material recibido:
 
El análisis de código y material recibido fue efectuado continuamente a medida que se desarrollaba el proyecto y no en una instancia específica en un principio.
Luego decidimos hacer una instancia de 30 minutos para hacer un análisis de código y reportar todos los issues que encontremos.
Esto nos permitió poder reportar errores o incoherencias a medida que las encontrábamos, algunos de los principales fueron:
 
#### Generales:
- No se detalla ningún estándar de codificación utilizado.
- Manejo de errores en diferentes lenguajes [#23](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/23) y [#31](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/31)
- Diferentes puertos de conexión configurados para conexión entre backend y frontend [#16](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/16)
- Ausencia de límite de columnas dificulta legibilidad [#108](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/108)
 
### Backend:
- Comentarios innecesarios [#112](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/112)
- Números mágicos [#111](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/111)
- DLLs y datos de prueba de importadores en paquete WebApi [#109](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/109)
- Tests no incluidos (No tienen TestMethod por lo cual no se ejecutan) [#43](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/43)
- Dependencias de paquetes innecesarias en backend [#13](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/13)
- Datos innecesarios en la base de datos [#34](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/34)
- Espacios en blanco innecesarios en código [#110](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/110)
 
### Frontend:
- Enumeradores usan capitalización inconvencional para nombres de variables [#107](https://github.com/ORT-ISA2-2022S1/obligatorio-decuadra_ferrari_meerhoff/issues/107)

