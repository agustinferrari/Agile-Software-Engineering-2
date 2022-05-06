# Análisis deuda técnica
## Análisis con NDepend
Para analizar la deuda técnica del proyecto utilizamos la herramienta de NDepend junto a estádisticas de Visual Studio sobre los tests.
En un principio notamos que el code coverage descrito en la documentación coincidía con el de Visual Studio pero en NDepend este no era el mismo. Asumimos que esto es porque NDepend no toma en cuenta los tags de ignorar partes de código para el code coverage.

### Métricas

![](https://media.discordapp.net/attachments/972236844907515964/972256993169535026/unknown.png?width=549&height=459)

Está gráfica compara las métricas de Inestabilidad contra abstracción con el objetivo de mostrar aquellos paquetes que se alejan de la secuencia principal (métrica de distancia normalizada) con el fin de identificarlos y modificarlos si es necesario.

Los paquetes que se encuentran sobre la secuencia principal son:
- ServiceRegistration
- ImporterInterface
- BusinessLogic
- DataAccess
- JSONImporter

Dentro de la Zone of Pain, es decir encontramos a los paquetes:
- Exceptions
- Domain

Como se menciona en la documentación, estas métricas son esperables por priorizar CRP (Common Reuse Principle).

En particular el paquete de exceptions resulta en una cohesión relacional H de 0 por priorizar CRP antes de CCP (Common Closure Principle) y esto también se menciona en la documentación.

Ambos paquetes rompen el principio de SAP (Stable Abstractions Principle) por ser estables pero poco abstractos. Esto implica que muchos dependen de estos pero que son concretos, lo cual un cambio en estos se propagaría por gran parte del proyecto.

Casi al otro extremo, siendo muy abstracto y medio estable, se encuentran los paquetes:
* DataAccessInterface
* BusinessLogicInterface

Encontramos que podrían tener mejor métrica si se elimináran dependencias innecesarias a otros paquetes, ya que estas dependencias los hacen menos estables.
* DataAccessInterface depende de Exceptions y no es usado ya que no incluye implementación, sino solo interfaces.
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

Utilizando la métrica de deuda técnica de NDepend, se podría sacar la conclusión de que es baja, por el rating A, teniendo una deuda de 3 dias y 5 horas, un interes anual de 1 día y 5 horas, y breaking point de 2 años y tres meses. 

Lo que esto nos dice es cuánto tiempo debemos dedicarle a refactor del código existente, para evitar que en 2 años ya no se eficiente trabajar sobre este.

La forma en que NDepend calcula está métrica, es utilizando factores del estilo de linters además de covertura de código entre otros. Por ejemplo:
- La falta de cobertura de testing en los equals de entidades de dominio
- Nombres de métodos con Try deberían devolver booleanos en vez de ser void

Esto no quita que algunas reglas según NDepend se rompen, pero en el contexto del proyecto son decisiones tomadas que tendrían sentido, por ejemplo:
- Se advierta de clases con muchos métodos al usar el patrón fachada
- Se advierte de constructores de clases no utilizados, pero es por reflection que usado fuera del proyecto.


En la siguiente foto se muestra reglas de NDepend que no fueron respetadas y la deuda 
![](https://media.discordapp.net/attachments/972236844907515964/972251201074765915/unknown.png?width=960&height=443)

