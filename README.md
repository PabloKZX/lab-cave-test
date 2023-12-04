# Prueba Pablo Martínez
## Implementación
### Archivos modificados:
##### Prefabs
 - `KartClassic_Player.prefab`
 - `GameManager.prefab`
#### Scripts
 - `TimeDisplay.cs`
 - `TimeManager.cs`
 #### Escenas
 - `IntroMenu.unity`
 - `MainScene.unity`
 
 ### Añadido al proyecto
 - He añadido DoTween para añadir alguna animación a la interfaz
 - #### Prefabs (Añadido en `Assets/Karting/Prefabs/LabCaveTest`):
	 - `Coin.prefab`
	 - `CollectableSpawner.prefab`
	 - `CollectableSpawnerGroup.prefab`
 - #### Scripts (Añadido en `Assets/Karting/Scripts/LabCaveTest):
 - `RotateAnimation.cs`
 - `ScaleAnimation.cs`
 - `PlayerModel.cs`
 - `PlayerModelProvider.cs`
 - `CoinCollector.cs`
 - `Collectable.cs`
 - `CollectableSpawner.cs`
 - `ICollector.cs`
 - `BestTimeUIController.cs`
 - `CollectableDisplay.cs`
 - `DisplaysManager.cs`
 - `DisplayType.cs`
 - `IUpdateDisplayEventListener.cs`
 - `NewBestTimeController.cs`
 - `TotalCoinsUIController.cs`
 - `TimeUtils.cs`

## Preguntas
 #### Si en vez de tener un template de Unity hubieras tenido que crear tu el proyecto, cómo lo hubieras organizado a nivel de carpeta y estructura? ¿Qué hubieras cambiado o hecho diferente?
 La estructura de carpetas como tal no considero que esté mal para el tamaño del proyecto. Para un proyecto más grande intentaría crear una jerarquía carpetas por "Features" en la que cada una tenga sus scripts, sus UIs, sus prefabs etc en vez de tenerlo todo separado.
 
Esto también ayudaría a tener las cosas separadas en distintos Assemblies para que la compilación del juego no se vuelva eterna a medida que crece.

 #### Si se te hubiera pedido almacenar las puntuaciones de manera persistente (en vez de localmente) a nivel de id de usuario, ¿qué servicios hubieras usado?
 Habría varias maneras de hacerlo:
 - La manera de hacerlo "rápido y mal" sería guardar las cosas usando PlayerPrefs, pero esto no es ideal porque un usuario avispado podría buscar el archivo y cambiar los datos fácilmente. 
 - Otra manera sería tener un tipo de archivo de guardado propio encriptado que se guarde en el dispositivo, que para juegos de un jugador o en los que hacer trampas no tenga repercusión debería de ser suficiente.
 - La manera más segura de hacerlo (y la que seguramente más tiempo llevaría) sería guardar los datos en una base de datos externa, y descargar el modelo del jugador al cargar el juego.
 - Y seguramente haya más maneras que ahora mismo no se me están ocurriendo.

####  Si se te hubiera pedido localizar el juego a varios idiomas, ¿cómo lo habrías hecho?
Idealmente querríamos que la gente de Localización tenga su documento aparte donde van haciendo todas las localizaciones. Eso conlleva que todos los textos tendrían que estar identificados con una clave, y descargar en el login el documento de localizaciones.

Lo mejor sería crear un componente para añadir a los textos que tenga como parámetro una clave y un texto por defecto, y que cuando se enseñe en pantalla busque la localización correspondiente con la clave, y si no encuentra nada que ponga el texto por defecto.

A nivel de crear textos en código habría que crear una clase nueva que acepte una clave de localización y acepte parámetros, de manera que se puedan crear estructuras así:
~~~
// Si el texto es algo como: 
// Attack Damage: +5% 
// querríamos que las localizaciones tuviesen esta pinta:
// AttackDamage: +{0}%
// y a nivel de codigo sería

_attackText.Localize("tid_attack_damage").AddParam(_attackValue);
~~~

### ¿Dónde y cómo implementarías compras en la aplicación? ¿Qué servicios conoces o utilizarías para ello?
Añadiría una tienda en la que entre carreras pudieses comprar cosméticos, mejores, corredores, coches, etc. Si el juego fuese multijugador competitivo, crearía un sistema de ligas que incentive a los usuarios quedar en mejores posiciones y para ello necesite mejores coches y corredores.

Es cierto que siempre he trabajado con sistemas de compras propios, y no he utilizado cosas 3rd party. Sé que Unity tiene el sistema de Unity IAP pero no lo he utilizado nunca.

#### Si tuvieras que monetizar el juego a través de anuncios, ¿cómo lo harías o qué estrategia seguirías? ¿Qué servicios de anuncios conoces para poder monetizar la aplicación?
Ofrecería al usuario ver anuncios para conseguir mejorar temporales. Tal vez se podría ofrecer una recompensa diaria por ver un anuncio, o duplicar las recompensas de una carrera. Otra opción sería añadir anuncios intersticiales al juego, que salten cuando el jugador realiza ciertas acciones.

También se podrían añadir banners al juego o añadir publicidad integrada de marcas en los guardarrailes o en carteles publicitarios por el mapa.

Aunque me suenan varios (AdMob, UnityAds y AppLovin) el único con el que tengo experiencia real es IronSource.

