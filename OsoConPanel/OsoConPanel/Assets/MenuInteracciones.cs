using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MenuInteracciones : MonoBehaviour
{

    private GameObject bInteractuar;
    private GameObject bComer;
    private GameObject bAcariciar;
    private GameObject bVerInformacion;
    private GameObject bFingirMuerte;
    private GameObject bDespertar;
    private GameObject bDormir;
    private GameObject bCorrer;
    private GameObject bDeseleccionar;
    private GameObject bInfo;
    private GameObject bVolver;
    //public GameObject cjtoFrutas;


    public bool mostrarMenu = false;

    public Animator animator;

    public GameObject canvas;
    public Camera myCamera;
    public Transform animTransform;

    private int interaccion = -1;
    private bool init = false;

    void Start()
    {
        if (!init) Init();
    }

    // Update is called once per frame
    void Update()
    {
        //dejando esta linea afuera el canvas se actualiza su posision
        canvas.transform.LookAt(myCamera.transform);
        if (canvas != null && animTransform != null)
        {
            canvas.transform.position = new Vector3(animTransform.position.x + 1, animTransform.position.y + 3, animTransform.position.z);

            if (myCamera != null)
            {
                canvas.transform.LookAt(myCamera.transform);
            }
        }

        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(Botones.BOTON_R2))
        {
            if (bInfo.activeSelf)
            {
                ActionVolverVerInfo();
            }
            else
            {
                MostrarMenu(false);
                ActionDeseleccionar();
            }

        }

        if (interaccion > -1 && (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(Botones.BOTON_R1)))
        {
            MostrarMenu(false);
            bVolver.GetComponent<Button>().interactable = true;
            bDormir.GetComponent<Button>().enabled = true;

            if (interaccion == AnimacionesAnimales.ACCION_DESELECCIONAR)
            {
                ActionDeseleccionar();
            }
            if (interaccion == AnimacionesAnimales.ACCION_VOLVER_VER_INFO)
            {
                ActionVolverVerInfo();
            }
            else if (interaccion == AnimacionesAnimales.ACCION_VER_INFO)
            {
                //bInfo y bVolver estan debajo del plano al cargar la escena
                if (bInfo.transform.localPosition.y == -1000)
                {
                    bInfo.transform.localPosition = new Vector3(
                        bInfo.transform.localPosition.x,
                        37,
                        bInfo.transform.localPosition.z);
                }

                if (bVolver.transform.localPosition.y == -1000)
                {
                    bVolver.transform.localPosition = new Vector3(
                        bVolver.transform.localPosition.x,
                        -120,
                        bVolver.transform.localPosition.z);
                }

                bInfo.SetActive(true);
                bVolver.SetActive(true);
                interaccion = -1;

                // El animator name es el nombre del game object completo en unity. Ej "Low_Bear_v01", "Low_Bear_v01 (1)"
                // En las funciones de buscarInfo del animal y GetNombreAnimacion, hay que usar el nombre base (para los dos osos sería "Low_Bear_v01")
                // En esas funciones, hacer un split del animator.name, usando el espacio como caracter separador

                string info = BuscarInfo(animator.name);
                GameObject.Find("bInfo").GetComponentInChildren<Text>().text = info;
            }
            else
            {
                if (interaccion == AnimacionesAnimales.ACCION_DORMIR)
                {
                    GetComponent<EstadoAnimales>().SetDormido(animator.name, true);
                }
                else if (interaccion == AnimacionesAnimales.ACCION_DESPERTAR)
                {
                    GetComponent<EstadoAnimales>().SetDormido(animator.name, false);
                }

                if (animator != null && interaccion > -1)
                {
                    // Animaciones.Animales es el script que tiene los diccionarios (nombre de animaciones por animal, info de animales)

                    // El animator name es el nombre del game object completo en unity. Ej "Low_Bear_v01", "Low_Bear_v01 (1)"
                    // En las funciones de buscarInfo del animal y GetNombreAnimacion, hay que usar el nombre base (para los dos osos sería "Low_Bear_v01")
                    // En esas funciones, hacer un split del animator.name, usando el espacio como caracter separador

                    var nombreAnimacion = AnimacionesAnimales.GetNombreAnimacion(animator.name, interaccion);

                    if (!string.IsNullOrEmpty(nombreAnimacion))
                    {
                        if (interaccion == AnimacionesAnimales.ACCION_COMER)
                        {
                            animator.gameObject.GetComponent<comida>().enabled = true;
                        }
                        animator.Play(nombreAnimacion);

                        if (interaccion == AnimacionesAnimales.ACCION_CORRER)
                        {
                            animator.gameObject.GetComponent<Correr>().enabled = true;
                        }
                    }
                }
            }

            GetComponent<MenuInteracciones>().animator = null;
            GetComponent<MenuInteracciones>().enabled = false;
            interaccion = -1;
        }
    }

    public void ActionDeseleccionar()
    {
        interaccion = -1;
        GetComponent<MenuInteracciones>().animator = null;
        GetComponent<MenuInteracciones>().enabled = false;
    }

    public void ActionVolverVerInfo()
    {
        bInfo.SetActive(false);
        bVolver.SetActive(false);

        MostrarMenu(true);
        interaccion = -1;

        AnimacionesAnimales.mostrandoInformacionAnimal = animator.name;
    }

    public void Init()
    {
        bInteractuar = GameObject.Find(Botones.ID_BOTON_INTERACTUAR);
        bComer = GameObject.Find(Botones.ID_BOTON_COMER);
        bAcariciar = GameObject.Find(Botones.ID_BOTON_ACARICIAR);
        bVerInformacion = GameObject.Find(Botones.ID_BOTON_VER_INFORMACION);
        bFingirMuerte = GameObject.Find(Botones.ID_BOTON_FINGIR_MUERTE);
        bDespertar = GameObject.Find(Botones.ID_BOTON_DESPERTAR);
        bDormir = GameObject.Find(Botones.ID_BOTON_DORMIR);
        bCorrer = GameObject.Find(Botones.ID_BOTON_CORRER);
        bDeseleccionar = GameObject.Find(Botones.ID_BOTON_DESELECCIONAR);
        bInfo = GameObject.Find(Botones.ID_BOTON_INFO);
        bVolver = GameObject.Find(Botones.ID_BOTON_VOLVER);

        bDespertar.GetComponent<Button>().interactable = false;

        AddMenuButtonsEventTriggers();

        init = true;

        MostrarMenu(mostrarMenu);
    }

    public void SetAnimator(Animator animator)
    {
        // El animator name es el nombre del game object completo en unity. Ej "Low_Bear_v01", "Low_Bear_v01 (1)"
        // En las funciones de buscarInfo del animal y GetNombreAnimacion, hay que usar el nombre base (para los dos osos sería "Low_Bear_v01")
        // En esas funciones, hacer un split del animator.name, usando el espacio como caracter separador

        this.animator = animator.GetComponent<Animator>();
        this.animTransform = animator.transform;
    }


    public void MostrarMenu(bool mostrarMenu)
    {
        if (!init) Init();

        //var altura = 0;

        //if (mostrarMenu)
        //{
        //    if (bComer.transform.localPosition.y != 90)
        //    {
        //        altura = -8000;
        //    }
        //}
        //else
        //{
        //    if (bComer.transform.localPosition.y == 90)
        //    {
        //        altura = 8000;
        //    }
        //}

        if (mostrarMenu)
        {
            // El animator name es el nombre del game object completo en unity. Ej "Low_Bear_v01", "Low_Bear_v01 (1)"
            // En las funciones de buscarInfo del animal y GetNombreAnimacion, hay que usar el nombre base (para los dos osos sería "Low_Bear_v01")
            // En esas funciones, hacer un split del animator.name, usando el espacio como caracter separador
            var animalDormido = GetComponent<EstadoAnimales>().IsDormido(animator.name);

            bDormir.GetComponent<Button>().interactable = !animalDormido;
            bComer.GetComponent<Button>().interactable = !animalDormido;
            bAcariciar.GetComponent<Button>().interactable = !animalDormido;
            bFingirMuerte.GetComponent<Button>().interactable = !animalDormido;
            bCorrer.GetComponent<Button>().interactable = !animalDormido;

            bDespertar.GetComponent<Button>().interactable = animalDormido;
        }

        bComer.SetActive(mostrarMenu);
        bDormir.SetActive(mostrarMenu);
        bAcariciar.SetActive(mostrarMenu);
        bVerInformacion.SetActive(mostrarMenu);
        bFingirMuerte.SetActive(mostrarMenu);
        bDespertar.SetActive(mostrarMenu);
        bCorrer.SetActive(mostrarMenu);
        bDeseleccionar.SetActive(mostrarMenu);
        bInfo.SetActive(mostrarMenu);
        bVolver.SetActive(mostrarMenu);

        bInfo.SetActive(false);
        bVolver.SetActive(false);

        this.mostrarMenu = mostrarMenu;

        /*
        bComer.transform.localPosition = new Vector3(
            bComer.transform.localPosition.x,
            bComer.transform.localPosition.y + altura,
            bComer.transform.localPosition.z);

        bDormir.transform.localPosition = new Vector3(
            bDormir.transform.localPosition.x,
            bDormir.transform.localPosition.y + altura,
            bDormir.transform.localPosition.z);

        bAcariciar.transform.localPosition = new Vector3(
            bAcariciar.transform.localPosition.x,
            bAcariciar.transform.localPosition.y + altura,
            bAcariciar.transform.localPosition.z);

        bVerInformacion.transform.localPosition = new Vector3(
           bVerInformacion.transform.localPosition.x,
           bVerInformacion.transform.localPosition.y,
           bVerInformacion.transform.localPosition.z);


        bFingirMuerte.transform.localPosition = new Vector3(
           bFingirMuerte.transform.localPosition.x,
           bFingirMuerte.transform.localPosition.y + altura,
           bFingirMuerte.transform.localPosition.z);

        bDespertar.transform.localPosition = new Vector3(
            bDespertar.transform.localPosition.x,
            bDespertar.transform.localPosition.y + altura,
            bDespertar.transform.localPosition.z);

        bCorrer.transform.localPosition = new Vector3(
            bCorrer.transform.localPosition.x,
            bCorrer.transform.localPosition.y + altura,
            bCorrer.transform.localPosition.z);

        bDeseleccionar.transform.localPosition = new Vector3(
            bDeseleccionar.transform.localPosition.x,
            bDeseleccionar.transform.localPosition.y + altura,
            bDeseleccionar.transform.localPosition.z);

        bInfo.transform.localPosition = new Vector3(
             bInfo.transform.localPosition.x,
            bInfo.transform.localPosition.y ,
             bInfo.transform.localPosition.z);

        bVolver.transform.localPosition = new Vector3(
            bVolver.transform.localPosition.x,
            bVolver.transform.localPosition.y ,
            bVolver.transform.localPosition.z);
            */
    }


    #region pointer enter actions
    private void OnPointerEnter_bDormir()
    {
        interaccion = GetComponent<EstadoAnimales>().IsDormido(animator.name) ? -1 : AnimacionesAnimales.ACCION_DORMIR;
    }

    private void OnPointerEnter_bComer()
    {
        interaccion = GetComponent<EstadoAnimales>().IsDormido(animator.name) ? -1 : AnimacionesAnimales.ACCION_COMER;
    }

    private void OnPointerEnter_bAcariciar()
    {
        interaccion = GetComponent<EstadoAnimales>().IsDormido(animator.name) ? -1 : AnimacionesAnimales.ACCION_ACARICIAR; //ver si vamos a poder acariciar solo cuando esta despierto o no
    }

    private void OnPointerEnter_bVerInformacion()
    {
        interaccion = AnimacionesAnimales.ACCION_VER_INFO;
    }

    private void OnPointerEnter_bFingirMuerte()
    {
        interaccion = GetComponent<EstadoAnimales>().IsDormido(animator.name) ? -1 : AnimacionesAnimales.ACCION_FINGIR_MUERTE;
    }

    private void OnPointerEnter_bDespertar()
    {
        interaccion = GetComponent<EstadoAnimales>().IsDormido(animator.name) ? AnimacionesAnimales.ACCION_DESPERTAR : -1;
    }

    private void OnPointerEnter_bCorrer()
    {
        interaccion = GetComponent<EstadoAnimales>().IsDormido(animator.name) ? -1 : AnimacionesAnimales.ACCION_CORRER;
    }

    private void OnPointerEnter_bDeseleccionar()
    {
        interaccion = AnimacionesAnimales.ACCION_DESELECCIONAR;
    }

    private void OnPointerEnter_bInfo()
    {
        interaccion = -1;
    }
    private void OnPointerEnter_bVolver()
    {
        interaccion = AnimacionesAnimales.ACCION_VOLVER_VER_INFO;
    }
    private void OnPointerExit_botones()
    {
        interaccion = -1;
        //MostrarMenu(false);
        //GetComponent<MenuInteracciones>().enabled = false;

        //todo ver cuando desactivar este script
    }

    #endregion pointer enter actions

    private void AddEventTrigger(UnityAction action, EventTriggerType triggerType, EventTrigger eventTrigger)
    {
        // Create a new TriggerEvent and add a listener
        EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
        trigger.AddListener((eventData) => action()); // you can capture and pass the event data to the listener

        // Create and initialise EventTrigger.Entry using the created TriggerEvent
        EventTrigger.Entry entry = new EventTrigger.Entry() { callback = trigger, eventID = triggerType };

        // Add the EventTrigger.Entry to delegates list on the EventTrigger
        eventTrigger.triggers.Add(entry);
    }

    private void AddMenuButtonsEventTriggers()
    {
        var bComerEvtTrigger = bComer.GetComponent<EventTrigger>();
        var bAcariciarEvtTrigger = bAcariciar.GetComponent<EventTrigger>();
        var bVerInformacionEvtTrigger = bVerInformacion.GetComponent<EventTrigger>();
        var bFingirMuerteEvtTrigger = bFingirMuerte.GetComponent<EventTrigger>();
        var bDespertarEvtTrigger = bDespertar.GetComponent<EventTrigger>();
        var bDormirEvtTrigger = bDormir.GetComponent<EventTrigger>();
        var bCorrerEvtTrigger = bCorrer.GetComponent<EventTrigger>();
        var bDeseleccionarEvtTrigger = bDeseleccionar.GetComponent<EventTrigger>();
        var bInfoEvtTrigger = bInfo.GetComponent<EventTrigger>();
        var bVolverEvtTrigger = bVolver.GetComponent<EventTrigger>();

        AddEventTrigger(OnPointerEnter_bDormir, EventTriggerType.PointerEnter, bDormirEvtTrigger);
        AddEventTrigger(OnPointerEnter_bComer, EventTriggerType.PointerEnter, bComerEvtTrigger);
        AddEventTrigger(OnPointerEnter_bAcariciar, EventTriggerType.PointerEnter, bAcariciarEvtTrigger);
        AddEventTrigger(OnPointerEnter_bVerInformacion, EventTriggerType.PointerEnter, bVerInformacionEvtTrigger);
        AddEventTrigger(OnPointerEnter_bFingirMuerte, EventTriggerType.PointerEnter, bFingirMuerteEvtTrigger);
        AddEventTrigger(OnPointerEnter_bDespertar, EventTriggerType.PointerEnter, bDespertarEvtTrigger);
        AddEventTrigger(OnPointerEnter_bCorrer, EventTriggerType.PointerEnter, bCorrerEvtTrigger);
        AddEventTrigger(OnPointerEnter_bDeseleccionar, EventTriggerType.PointerEnter, bDeseleccionarEvtTrigger);
        AddEventTrigger(OnPointerEnter_bInfo, EventTriggerType.PointerEnter, bInfoEvtTrigger);
        AddEventTrigger(OnPointerEnter_bVolver, EventTriggerType.PointerEnter, bVolverEvtTrigger);

        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bDormirEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bComerEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bAcariciarEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bVerInformacionEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bFingirMuerteEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bDespertarEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bCorrerEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bDeseleccionarEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bInfoEvtTrigger);
        AddEventTrigger(OnPointerExit_botones, EventTriggerType.PointerExit, bVolverEvtTrigger);
    }

    public string BuscarInfo(string animal)
    {

        // El parametro animal es el nombre del game object completo en unity. Ej "Low_Bear_v01", "Low_Bear_v01 (1)"
        // En las funciones de buscarInfo del animal y GetNombreAnimacion, hay que usar el nombre base (para los dos osos sería "Low_Bear_v01")
        // En esas funciones, hacer un split, usando el espacio como caracter separador

        var nombreBaseAnimator = animal.Split(' ')[0];
        //soy solo un comentario para probar el branch
        string retorno = "";
        switch (nombreBaseAnimator)
        {
            case "Low_Bear_v01":
                retorno = "\n" +
                            "  Nombre : Oso Grizzly.\n" +
                            "  Especie : Ursidae.\n" +
                            "  Habitad : Zonas de Europa, Asia templada y norte de América.\n" +
                            "  Dieta : Son omnívoros, comen vegetacion, pero también la carroña.\n" +
                            "  Prefieren la miel pero cazan pequeños vertebrados, insectos y salmones.\n" +
                            "  Fisico : Miden entre 1 y 2,8 m de longitud total y tienen una masa de promedio\n" +
                            "  de 780 kg, Las patas son cortas y poderosas, pueden ser muy ágiles. El pelaje es\n" +
                            "  largo y espeso, y generalmente marrón o negro.\n" +
                            "  Observaciones : Una especie se considera bajo preocupación menor.\n" +
                            "  Habitos : Pasan el invierno hibernando, guardando en los tejidos adiposos un 75% de\n" +
                            "  la energía obtenida de los alimentos. Ingiere hierbas y tierra para formar un tapon\n" +
                            "  para que los alimentos se vayan amontonando, en el intestino grueso, de esta forma no\n" +
                            " deben ir al baño mientras hibernan, al despertarse de hibernar lo expulsan.\n";
                break;
            case "Low_Boar_v01":
                retorno = "\n" +
                            "  Nombre : Jabalí.\n" +
                            "  Especie : Sus scrofa.\n" +
                            "  Habitad : Su distribución original se corresponde con gran parte de Eurasia y norte de\n" +
                            "  África, ha sido introducido por el hombre en América y Oceanía.\n" +
                            "  Dieta : Son omnívoros, comen vegetacion, pero también la carroña.\n" +
                            "  Prefieren la miel pero cazan pequeños vertebrados, insectos y salmones.\n" +
                            "  Fisico : 90 cm - 160 cm de longitud total, los machos pesan entre 70 y 90 kg, las\n" +
                            "  hembras entre 40 y 65 kg (puede llegar a alcanzar los 145 kg). \n" +
                            "  Observaciones : Una especie se considera bajo preocupación menor.\n" +
                            "  Habitos : Los baños de barro desempeñan un importante papel, considerándose\n" +
                            "  que tienen varias funciones. Así aseguran su regulación térmica, ya que el jabalí\n" +
                            "  no suda al tener las glándulas sudoríparas atrofiadas.\n";
                break;
            case "Low_Fox_v01":
                retorno = "\n" +
                            "  Nombre : Zorro Rojo.\n" +
                            "  Especie : Vulpes vulpes.\n" +
                            "  Habitad : Bosques de Europa, Asia, norte de América y Australia.\n" +
                            "  Dieta : Invertebrados(como los insectos, lombrices, cangrejos y moluscos) y pequeños\n" +
                            "  mamíferos (como roedores, conejos y topos), aves, huevos, anfibios, reptiles y peces.\n" +
                            "  Fisico : pesan de 3.6 a 7.6 kg. La longitud va de 46 a 90 cm y con una cola de unos 55cm.\n" +
                            "  Observaciones : Una especie se considera bajo preocupación menor. En cautividad pueden \n" +
                            "  vivir hasta los doce años, pero en la naturaleza no suelen sobrepasar los tres.\n" +
                            "  Son cazados por su piel para hacer todo tipo de prendas.\n" +
                            "  Habitos : Están más activos al anochecer, generalmente son cazadores solitarios. Si \n" +
                            "  consigue más comida de la que puede comer, la enterrará para más tarde. Viven en guaridas,\n" +
                            "  para dar a luz, criar a los recién nacidos y para almacenar comida.\n";
                break;
            case "Low_Coyote_v01":
                retorno = "\n" +
                            "  Nombre : Coyote.\n" +
                            "  Especie : Canis latrans.\n" +
                            "  Habitad : Solo se encuentran en América del Norte, América Central y recientemente\n" +
                            "  América del Sur( desde Canadá hasta Colombia).\n" +
                            "  Dieta : Es omnívoro, y se adapta a las fuentes disponibles, incluyendo frutas, hierbas y\n" +
                            "  otros vegetales. Cazan solos, mamíferos pequeños (EJ. musarañas) o pequeños insectos. \n" +
                            "  Fisico : Mide menos de 60 cm de altura, y su color varía desde el gris hasta el canela,\n" +
                            "  a veces con un tinte rojizo. Las orejas y el hocico del coyote parecen largos en relación\n" +
                            "  al tamaño de su cabeza. Pesa entre 10 y 25 kg, promediando 15\n" +
                            "  Observaciones : Una especie se considera bajo preocupación menor.\n" +
                            "  Habitos : Cazan solos o en parejas monógamas, tienen camadas de 4 a 6 cachorros. \n" +
                            "  El aullido es engañoso debido a las características del sonido, puede parecer que el coyote\n" +
                            "  está en un lugar, cuando realmente se encuentra en otra parte\n";
                break;
            case "Low_Moose_bull_v01":
                retorno = "\n" +
                            "  Nombre : Alces alces.\n" +
                            "  Especie : Cervidae.\n" +
                            "  Sexo : Macho.\n" +
                            "  Habitad : Bosques de Rusia, Polonia, República Checa, Alemania, Alaska, Canadá y el\n" +
                            "  norte de los Estados Unidos.\n" +
                            "  Dieta : Es herbívoro, alimentándose de hojas, ramas de árboles y arbustos, corteza de los\n" +
                            "  árboles, así como de plantas acuáticas, pudien bucear en su busqueda.\n" +
                            "  Fisico : Altura de 1,50 a 2,15 m (con cornamenta 2,50 a 3,50 m), peso de 350 a 450 kgl y\n" +
                            "  largo del cuerpo de 2,40 a 3,10 m.\n" +
                            "  Observaciones : Una especie se considera bajo preocupación menor.\n" +
                            "  Los alces se orientan sobre todo por el oído y el olfato; su vista es bastante débil." +
                            "  Habitos : Se reagrupan en pequeños rebaños que comprenden de 5 a 10 individuos. Los alces\n" +
                            "  permanecen fieles a sus territorios, que por otra parte no defienden de ningún modo.\n";
                break;
            case "Low_Moose_cow_v01":
                retorno = "\n" +
                             "  Nombre : Alces alces.\n" +
                             "  Especie : Cervidae.\n" +
                             "  Sexo : Hembra.\n" +
                             "  Habitad : Bosques de Rusia, Polonia, República Checa, Alemania, Alaska, Canadá y el\n" +
                             "  norte de los Estados Unidos.\n" +
                             "  Dieta : Es herbívoro, alimentándose de hojas, ramas de árboles y arbustos, corteza de los\n" +
                             "  árboles, así como de plantas acuáticas, pudien bucear en su busqueda.\n" +
                             "  Fisico : Altura de 1,50 a 2,15 m (no tienen astas), peso de 350 a 450 kgl y\n" +
                             "  largo del cuerpo de 2,40 a 3,10 m.\n" +
                             "  Observaciones : Una especie se considera bajo preocupación menor.\n" +
                             "  Los alces se orientan sobre todo por el oído y el olfato; su vista es bastante débil." +
                             "  Habitos : Se reagrupan en pequeños rebaños que comprenden de 5 a 10 individuos. Los alces\n" +
                             "  permanecen fieles a sus territorios, que por otra parte no defienden de ningún modo.\n";
                break;
            case "Low_PolarBear_v01":
                retorno = "\n" +
                           "  Nombre : Oso Polar.\n" +
                           "  Especie : Ursidae.\n" +
                           "  Habitad : Zona polar y heladas  como el Artico.\n" +
                           "  Dieta : Se alimenta de animales árticos, como crías de focas y renos.\n" +
                           "  No toman agua, ya que en su ambiente es salada y ácida, lo reemplazan\n" +
                           "  con la sangre de sus presas.\n" +
                           "  Fisico : Tienen una gruesa capa de grasa subcutánea y un denso pelaje,\n" +
                           "  que no es blanco, sino translúcido (pelos huecos, al estar llenos de\n " +
                           "  aire, son un buen aislante térmico).\n" +
                           "  Observaciones : Su numero se ha reducido en al menos un 30 % debido a la caza.\n" +
                           "  Habitos : Solo las hembras preñadas buscan refugio (aunque no hibernan), dando a\n" +
                           "  luz una o dos crías. Al nacer pesan 700 g, no tienen ningún diente, son ciegas\n" +
                           "  aprendiendo a buscar comida y a resguardarse de los machos adultos.\n";
                break;
            case "Low_Hare_v01":
                retorno = "\n" +
                              "  Nombre : Conejo Comun.\n" +
                              "  Especie : Oryctolagus Cuniculus.\n" +
                              "  Habitad : Europa, Rusia, Estados Unidos, Chile, Australia (donde son una la plaga ).\n" +
                              "  Dieta : Es herbívoro, ingiere plantas, arbustos, matorrales,  raíces, semillas y bulbos.\n" +
                              "  Fisico : El conejo salvaje mide de 34 a 50 cm, las orejas miden de 4 a 8 cm. Su peso varía\n" +
                              "  de 1,2 a 2,5 kg. Posee una piel de color pardo para evitar a sus depredadores\n" +
                              "  Observaciones : Los dientes de un conejo (sus incisivos, crecen sin cesar), debe\n" +
                              "  desgastarlos con el fin de evitar que se vuelvan demasiado largos (lo que podría herirle).\n" +
                              "  Son cazadas por zorros, gatos salvajes, águilas (entre otros depredadores).\n" +
                              "  Habitos : Animal de hábitos nocturnos y crepusculares. Son muy silenciosos pero emiten\n" +
                              "  fuertes chillidos cuando están asustados o heridos.Golpean el suelo con sus patas traseras,\n" +
                              "  y lo pueden hacer varias veces dependiendo de lo exaltados que estén, cuando se enfadan.\n";
                break;
            case "Low_doe_v01":
                retorno = "\n" +
                              "  Nombre : Ciervo o Venado.\n" +
                              "  Especie : Cervidae.\n" +
                              "  Sexo : Hembra.\n" +
                              "  Habitad : Bosques de Europa, Asia, América, norte de África y algunas zonas árticas.\n" +
                              "  Dieta : Es herbívoro, alimentándose de hojas, ramas de árboles y arbustos, corteza de los\n" +
                              "  árboles, así como de plantas acuáticas, pudien bucear en su busqueda.\n" +
                              "  Fisico : Altura de 1,30 a 1,90 m (no tienen astas), peso entre 30 y 200 kg.\n" +
                              "  largo del cuerpo de 1,60 a 2,00 m.\n" +
                              "  Observaciones : Preocupacion menor. Es victima de la caza deportiva. El ciervo común\n" +
                              "  es presa de múltiples carnívoros (linces, lobos, osos, leopardos y pumas). Los las crias\n" +
                              "  son cazadas por zorros, gatos salvajes y águilas.\n" +
                              "  Los venados se orientan sobre todo por el oído y el olfato; su vista es bastante débil." +
                              "  Habitos : Se reagrupan en pequeños rebaños que comprenden de 5 a 10 individuos.\n";
                break;
            case "Low_Stag_v01":
                retorno = "\n" +
                              "  Nombre : Ciervo o Venado.\n" +
                              "  Especie : Cervidae.\n" +
                              "  Sexo : Macho.\n" +
                              "  Habitad : Bosques de Europa, Asia, América, norte de África y algunas zonas árticas.\n" +
                              "  Dieta : Es herbívoro, alimentándose de hojas, ramas de árboles y arbustos, corteza de los\n" +
                              "  árboles, así como de plantas acuáticas, pudien bucear en su busqueda.\n" +
                              "  Fisico : Altura de 1,50 a 2,10 m (con astas), peso entre 30 y 200 kg.\n" +
                              "  largo del cuerpo de 1,60 a 2,50 m.\n" +
                              "  Observaciones : Preocupacion menor. Es victima de la caza deportiva. El ciervo común\n" +
                              "  es presa de múltiples carnívoros (linces, lobos, osos, leopardos y pumas). Los las crias\n" +
                              "  son cazadas por zorros, gatos salvajes y águilas.\n" +
                              "  Los venados se orientan sobre todo por el oído y el olfato; su vista es bastante débil." +
                              "  Habitos : Se reagrupan en pequeños rebaños que comprenden de 5 a 10 individuos.\n";
                break;
            case "Horse":
                retorno = "\n" +
                            "  Nombre : Caballo .\n" +
                            "  Especie : Equus ferus caballus.\n" +
                            "  Habitad : Cualquier lugar con clima calido y templado,Ej. Estados Unidos, China, México,\n" +
                            "  Brasil, Argentina, Colombia, Rusia, Kazajistán, Rumania, Alemania, Francia, etc.\n" +
                            "  Dieta : Son herbívoros, con una dieta de hierba y otros materiales vegetales\n" +
                            "  Fisico : Altura de 1,40 a 1,80 metros, con un peso de 380kg a 1000kg\n" +
                            "  Observaciones : Se usan para practicas deportivas, desfiles, para terapia de chicos con\n" +
                            "  capacidades distintas y eran usados como medio de transporte y herramientas militares.\n" +
                            "  Habitos : Suelen ser curiosos, y cuando se asustan suelen investigar sobre la causa de\n" +
                            "  su miedo y no siempre huyen. Han desarrollado velocidad, agilidad, resistencia y estado de\n" +
                            "  alerta. Aunque por la cría selectiva algunas razas son más dóciles.\n" +
                            "  Son animales sociales, establecen vínculos con individuos de su especie y con otros animales,\n" +
                            "  incluidos los humanos";
                break;
            case "Elephant":
                retorno = "\n" +
                            "  Nombre : Elefante africano de Sabana.\n" +
                            "  Especie : Proboscídeos.\n" +
                            "  Habitad : Pequeñas zonas de Africa.\n" +
                            "  Dieta : Son animales herbívoros, comen hierbas y hojas de árboles o arbustos.\n" +
                            "  Fisico : Alcanzan 6 a 7 metros de longitud y de 3 a 3,5 metros de altura,\n" +
                            "  con un peso de 5,4 a 6 toneladas. Poseen 2 colmillos en la mandíbula superior\n" +
                            "  Observaciones : Una especie se considera vulnerable. Se ha perseguido por sus valiosos\n" +
                            "  colmillos. Por suerte, goza actualmente de proteccion, los gobiernos africanos imponen\n" +
                            "  cada vez penas más duras contra el furtivismo.​ Los cazadores que matan a estos animales\n" +
                            "  tienen que pagar una multa de 10.000 € y se les retira la licencia de caza.\n" +
                            "  Habitos : Las manadas están formadas por hembras emparentadas y sus crías, dirigidas por\n" +
                            "  la hembra de mayor edad. Las acompaña algún macho adulto, los machos suelen llevar una \n" +
                            "  vida solitaria, no obstante, tampoco se alejan en exceso de su familia y la reconocen \n" +
                            "  perfectamente cuando vuelven a encontrarla.\n";
                break;
            case "Giraffe":
                retorno = "\n" +
                          "  Nombre : Jirafa.\n" +
                          "  Especie : Giraffa camelopardalis.\n" +
                          "  Habitad : De Africa, se extiende de Chad( norte) hasta Sudáfrica, y Niger.\n" +
                          "  Dieta : Las ramas de los árboles, arbustos, hierbas y frutas.\n" +
                          "  Fisico : Las jirafas adultas pueden alcanzar una altura de 5–6 m (los machos\n" +
                          "  adultos son más grandes que las hembras).​ Un peso promedio de 1192 kg(macho)\n" +
                          "  y 828 kg(hembra). \n" +
                          "  Observaciones : clasificarla como una especie vulnerable, aunque se observo\n" +
                          "  una disminución de la población de hasta el 40 % en el período 1985-2015.\n" +
                          "  Habitos : Tienen pocos vínculos sociales fuertes y las agrupaciones suelen\n" +
                          "  cambiar de miembros cada pocas horas, los más estables están compuestos de\n" +
                          "  las madres y sus crías. Las jirafas no son territoriales.\n";
                break;
            case "Wolf":
                retorno = "\n" +
                          "  Nombre : Lobo.\n" +
                          "  Especie : Canis Lupus.\n" +
                          "  Habitad : Norteamérica, Eurasia y el Oriente Medio.\n" +
                          "  Dieta : Carne de otros animales, como cerdos, ciervos, cabras, ovejas\n" +
                          "  pueden comer animales marinos, como foca o pescado.\n" +
                          "  Fisico : La altura varía entre los 60 y los 90 centímetros hasta el \n" +
                          "  hombro, y tienen un peso de entre 32 y 70 kilos.\n" +
                          "  Observaciones : Especie poco amenazada. son cazados por ser una amenaza\n" +
                          "  para el ganado y por deporte.\n" +
                          "  Habitos : Se organizan en manadas(de esto depende el exito a la hora de\n" +
                          "  cazar), la manada la lideran dos individuos: el macho reproductor y la\n" +
                          "  hembra reproductora.\n";
                break;
            case "Penguin":
                retorno = "\n" +
                         "  Nombre : Pingüino.\n" +
                         "  Especie : Spheniscidae.\n" +
                         "  Habitad : Viajan por las costas de la Antártida, Nueva Zelanda, sur de\n" +
                         "  Australia, Sudáfrica, Perú, Chile y la Patagonia Argentina.\n" +
                         "  Dieta : Se alimentan de peces y cefalópodos o plancton\n" +
                         "  Fisico : Aves no voladoras adaptadas al buceo propulsado por las alas.\n" +
                         "  El tiempo maximo bajo el agua sin respirar es de 18 minutos. Corriendo\n" +
                         "  alcanzan velocidades hasta 60 km/h, su vel. normal es de entre 5 a 10km/h.\n" +
                         "  Observaciones : Especie amenazadas o vulnerables.\n" +
                         "  Habitos : Los pingüinos se comunican a través de su graznido, normalmente\n" +
                         "  solo tienen un pichon. Sus nidos son sencillos y algunas veces anidan galerías\n" +
                         "  subterráneas.\n";
                break;
            case "Spider":
                retorno = "\n" +
                         "  Nombre : Araña  del Desierto.\n" +
                         "  Especie : Cerbalus aravensis.\n" +
                         "  Habitad : Dunas de Samaria, en la zona desértica de Aravá (Israel).\n" +
                         "  Dieta : Su alimento habitual son los insectos y otras arañas, pero algunas se\n" +
                         "  han visto comiendo ciempiés, cochinillas, e incluso pequeñas lagartijas.\n" +
                         "  Fisico : Su tamaño pueden alcanzar los 14 cm de longitud, convirtiéndola en la\n" +
                         "  araña más grande en su clase en Oriente Medio.\n" +
                         "  Observaciones : La araña se encuentra en peligro de extinción. Su hábitat que está\n" +
                         "  en peligro de desaparecer ya que es un reducto que, debido a la ocupación territorial\n" +
                         "  del humano, es usado para la agricultura.\n" +
                         "  Habitos : cuando las arañas pelean entre ellas, si reciben una picadura en una\n" +
                         "  extremidad estás se la amputan para evitar que el veneno llegue al resto del cuerpo.\n";
                break;
            case "Snake":
                retorno = "\n" +
                         "  Nombre : Cobra egipcia.\n" +
                         "  Especie : Naja haje.\n" +
                         "  Habitad : En desiertos y semidesiertos pastizales, en África del Norte.\n" +
                         "  Dieta : Se alimenta de ratas, ratones, lagartijas y pájaros. Utiliza veneno\n" +
                         "  inyectado a través de sus colmillos retráctiles para matar y digerir a su presa.\n" +
                         "  Fisico : Esta cobra puede medir hasta 2,5 metros de longitud.\n" +
                         "  Observaciones : La mayoría de las mordeduras ocurren cuando la serpiente de\n" +
                         "  cascabel se pisa accidentalmente o es intencionalmente acosada.\n" +
                         "  Habitos : Esta serpiente es muy territorial, atacando a cualquier amenaza para\n" +
                         "  su territorio. Las hembras suelen poner entre 8 y 20 huevos en cada puesta. Los\n" +
                         "  huevos eclosionan en un período de incubación de 60 días.\n";
                break;
            default:
                retorno = "nada";
                break;
        }

        return retorno;
    }

    public void OcultarPanelInfo(string nombreAnimal)
    {
        if (AnimacionesAnimales.mostrandoInformacionAnimal != nombreAnimal && bInfo != null && bInfo.activeSelf)
        {
            bInfo.SetActive(false);
            bVolver.SetActive(false);
        }

        this.enabled = false;

    }
}