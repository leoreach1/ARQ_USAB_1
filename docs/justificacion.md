# Identificación y justificación de los patrones

## Ejercicio 1 – Sistema de personalización de automóviles

**Tipo de patrón:** Creacional. **Patrón seleccionado:** Builder.

**Contexto y decisión.** Un automóvil tiene muchas opciones (motor, color, llantas, sistema de sonido, interiores, techo solar, GPS) y casi todas son opcionales. Un constructor con siete parámetros, o una sobrecarga por cada combinación, produce el "constructor telescópico": llamadas ilegibles y fáciles de equivocar. Se selecciona Builder para separar la construcción paso a paso (`AutomovilBuilder`) de la representación final (`Automovil`).

**Cómo cumple el escenario.** Cada método `Set…` o `Con…` guarda una opción y devuelve el mismo builder, lo que permite encadenar llamadas (interfaz fluida). El builder trae valores de fábrica, así que cualquier opción puede omitirse sin crear subclases. `Build()` entrega un `Automovil` cuyas propiedades solo tienen `get`; el compilador de C# impide modificarlas después (error CS0200). El constructor de `Automovil` es `internal`, por lo que un cliente no puede crear un automóvil saltándose el builder, y el builder rechaza opciones vacías, de modo que no es posible obtener un objeto en estado inválido.

**Atributos de calidad (ISO/IEC 25010).** Mantenibilidad: agregar una opción nueva es agregar una propiedad y un método, sin tocar a los clientes existentes. Fiabilidad: la inmutabilidad elimina cambios accidentales sobre un pedido ya configurado.

**Trade-offs y alternativa descartada.** El costo es una clase adicional que repite los atributos del producto. Se descartó Abstract Factory porque resuelve familias de productos relacionados, no la configuración opcional de un único objeto; y se descartaron los parámetros opcionales del constructor porque no ofrecen un punto único de validación ni la lectura fluida.

## Ejercicio 2 – Gestión de notificaciones multiplataforma

**Tipo de patrón:** Estructural. **Patrón seleccionado:** Bridge.

**Contexto y decisión.** El sistema varía en dos dimensiones independientes: el tipo de notificación (mensaje, alerta, advertencia, confirmación) y la plataforma donde se muestra (web, móvil, escritorio). Con herencia simple harían falta 4 × 3 = 12 clases, y cada tipo o plataforma nueva multiplicaría el número. Bridge separa la abstracción (`Notificacion`) de la implementación (`IPlataformaVisualizacion`) y las une por composición, con lo que el crecimiento pasa de multiplicativo (N × M) a aditivo (N + M): 4 + 3 = 7 clases.

**Cómo cumple el escenario.** `Notificacion` recibe la plataforma por constructor y le delega la visualización con `Renderizar(titulo, cuerpo)`. Cada subclase solo define la semántica de su tipo (título y prefijo). `CambiarPlataforma` permite que la misma notificación pase de web a móvil en tiempo de ejecución, sin crear un objeto nuevo.

**Atributos de calidad y principios.** Modificabilidad y extensibilidad: una plataforma nueva (por ejemplo, reloj inteligente) no toca ninguna notificación, y un tipo nuevo no toca ninguna plataforma (principio abierto/cerrado). La abstracción depende de una interfaz y no de clases concretas (inversión de dependencias).

**Trade-offs y alternativa descartada.** Bridge agrega una indirección y obliga a que todas las plataformas compartan un contrato común (`Renderizar`), lo que puede limitar capacidades exclusivas de alguna. Se descartó Strategy porque modela un algoritmo intercambiable dentro de una sola clase, mientras que aquí hay dos jerarquías completas que evolucionan por separado; y Adapter, porque sirve para compatibilizar interfaces ya existentes, no para diseñar la separación desde el inicio.

## Ejercicio 3 – Aplicación de chat grupal

**Tipo de patrón:** Comportamiento. **Patrón seleccionado:** Mediator.

**Contexto y decisión.** Si cada participante de un chat se comunicara directamente con los demás, se formaría un grafo completo de dependencias, con N(N−1)/2 enlaces, y cada ingreso o salida obligaría a actualizar a todos. Mediator introduce `IChatMediator` y su implementación `SalaChatMediator`, que centraliza el registro de participantes y el enrutamiento de mensajes: la topología pasa de malla a estrella.

**Cómo cumple el escenario.** Un `Usuario` solo conoce la interfaz del mediador. Al llamar `Enviar`, el usuario invoca `EnviarMensaje(mensaje, this)` y la sala entrega el mensaje a todos los miembros excepto al emisor. `RegistrarUsuario` y `EliminarUsuario` agregan o retiran participantes en tiempo de ejecución sin modificar a los demás; un usuario retirado deja de recibir mensajes y la sala descarta los que intente enviar.

**Atributos de calidad (ISO/IEC 25010).** Bajo acoplamiento entre colegas y alta cohesión de `Usuario`, que solo emite y recibe. Modificabilidad: las reglas de comunicación viven en un único lugar.

**Trade-offs y alternativa descartada.** Concentrar la coordinación en `SalaChatMediator` puede convertirlo en un objeto monolítico si crecen las reglas (moderación, persistencia), por lo que su responsabilidad debe mantenerse acotada al enrutamiento. Se descartó Observer puro porque todos los usuarios son a la vez emisores y receptores: cada uno tendría que mantener suscripciones cruzadas con los demás y el acoplamiento entre pares se conservaría.

## Referencias

Bass, L., Clements, P., & Kazman, R. (2021). *Software architecture in practice* (4th ed.). Addison-Wesley Professional.

Gamma, E., Helm, R., Johnson, R., & Vlissides, J. (1994). *Design patterns: Elements of reusable object-oriented software*. Addison-Wesley.

International Organization for Standardization. (2011). *Systems and software engineering — Systems and software Quality Requirements and Evaluation (SQuaRE) — System and software quality models* (ISO/IEC 25010:2011).
