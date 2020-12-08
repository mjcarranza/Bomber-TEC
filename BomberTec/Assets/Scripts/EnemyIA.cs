using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;

public class EnemyIA : MonoBehaviour
{
    /*
     * Global variables
     */
    public float speed = 100f;
    public float nextWayPointDistance = 3f;
    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;
    Seeker seekerP, seeker2, seeker3, seeker4, seeker5, seeker6, seeker7;
    Rigidbody2D rb;
    public NavMeshAgent agent;
    public LayerMask whatIsGround, whatIsPlayer;
    // Walking variables
    public Vector2 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    // Chasing powerups
    public bool powerUpInSightRange;
    // Destroying obstacles
    public bool obstNear;
    // Attacking variables
    public float timeBetweenAttacks;
    public bool playerInSightRange, playerInAttackRange;
    // States
    enum BehaviourType { pasive, chase, attack}

    BehaviourType behaviour = BehaviourType.pasive;
    float enterChaseingZone = 5f;
    float leaveChaseingZone = 7f;
    float enterAttackZone = 2f;
    float enemyDistance;

    // Tarnsforms
    public Transform player;
    public Transform enemy2;
    public Transform enemy3;
    public Transform enemy4;
    public Transform enemy5;
    public Transform enemy6;
    public Transform enemy7;

    public Transform bomb;
    public Transform obstacle;
    public Transform powerUp;
    
    
    

    /*
     * Start is called the fist frame update
     */
    void Start()
    {
        seekerP = GetComponent<Seeker>();
        seeker2 = GetComponent<Seeker>();
        seeker3 = GetComponent<Seeker>();
        seeker4 = GetComponent<Seeker>();
        seeker5 = GetComponent<Seeker>();
        seeker6 = GetComponent<Seeker>();
        seeker7 = GetComponent<Seeker>();

        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }
    /*
     * Fuction to update the path to any object
     */
    void UpdatePath()
    {
        // for player
        seekerP.StartPath(rb.position, player.position, OnPathComplete);
        // for enemy 2
        seeker2.StartPath(rb.position, enemy2.position, OnPathComplete);
        // for enemy 3
        seeker3.StartPath(rb.position, enemy3.position, OnPathComplete);
        // for enemy 4
        seeker4.StartPath(rb.position, enemy4.position, OnPathComplete);
        // for enemy 5
        seeker5.StartPath(rb.position, enemy5.position, OnPathComplete);
        // for enemy 6
        seeker6.StartPath(rb.position, enemy6.position, OnPathComplete);
        // for enemy 6
        seeker7.StartPath(rb.position, enemy7.position, OnPathComplete);

        /*
        if (seeker6.IsDone())
        {
            seeker6.StartPath(rb.position, enemy6.position, OnPathComplete);
        }*/

    }
    /*
     * Function gets if the path to the object is stablished
     */
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    /*
     * Update is called once per frame
     */
    void Update()
    {
        /*
         * If there is not path to follow
         */
        if (path == null)
        {
            return;
        }
        /*
         * if there is a path to follow
         */
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        /*
         * adding movement force
         */
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
    }
    /*
     * Itializing variables
     */
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    /*
    // hacer funcion de probabilidad
    private void Porbablity()
    {

    }
    */
    /*
     * Function to attack enemy
     */
    /*
    private void Attack()
    {

    }
    /*
     * Function to chase enemy
     */
    /*
    private void Chase()
    {

    }*/




    /*
        // check for the attack range
        playerInSightRange = Physics.CeckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CeckSphere(transform.position, attackRange, whatIsPlayer); 

        // estos condicionales deberian de estar dentro de la funcion de probabilidad. y las condiciones        
        //     deberian de ir de acuerdo a la probabilidad.
        // cada condicional va a ser un bloque de codigo que va a enviar un numero que representa el 
        // porcentaje de probabilidad de realizar esa accion 

        // si ninguno de los caracteres se encuentra dentro del rango de ataque ni el rango de vista //
        if (!playerInSightRange && !playerInAttackRange)
        {
            // do nothing, just walk
        }
        // si al menos un caracter se encuentra dentro del rango de vista //
        if (playerInSightRange && !playerInAttackRange)
        {
            // follow the character using A*
            // llamar a la funcion de probabilidad y pasarle la distancia a la que se encuentra del enemigo
        }
        // si al menos un caracter se encuentra dentro del rango de ataque //
        if (playerInSightRange && playerInAttackRange)
        {
            // place a bomb near it the character
            // llamar a la funcion de probabilidad y pasarle la distancia a la que se encuentra del enemigo
            // esta condicion deberia estar dentro de la de vista
        }
        // si al menos un power up se encuentra a la vista //
        if (powerUpInSightRange)
        {
            // find it with A*
            // llamar a la funcion de probabilidad y pasarle la distancia a la que se encuentra del power up
        }
        // si al menos un obstaculo se encuentra dentro del rango de ataque //
        if (powerUpInSightRange)
        {
            // place near it with A* and place a bomb
            // llamar a la funcion de probabilidad y pasarle la distancia a la que se encuentra de los bloques 
        }
        */






    /*
     *  Los genes resultan ser porcentajes, es decir que el personaje va a tener
     *  probabilidad de escoger la acción a ejecutar, mientras mayor sea el porcentaje de la acción, mayor va a ser la
     *  probabilidad de ejecutarla. Entre estos tenemos:
     *  ● Probabilidad de esconderse.
     *  ● Probabilidad de buscar power up.
     *  ● Probabilidad de buscar enemigos.
     *  ● Probabilidad de dejar una bomba.
     *  Nota: Estos valores deben sumar en su totalidad un 100%.
     *  
     *  Ejemplo:
     *  ● Probabilidad de esconderse       = 25%
     *  ● Probabilidad de buscar power up  = 60%
     *  ● Probabilidad de buscar enemigos  = 5%
     *  ● Probabilidad de dejar una bomba  = 10%
     *                               Total = 100%
     */

    /*
     * Movimiento de la IA
     * 
     * Dependiendo de las probabilidades anteriores, deberá calcular una ruta a seguir hacia el enemigo, power up o
     * escondite más cercano, para esto se usará A*.
     */



    /*
     * Para el algoritmo genético:
     * 
     * inicio
     * generar poblacion inicial 
     * buscar al mejor adaptado y ver su grado de adaptación
     * seleccion de parejas
     * torneo
     * los ganadores se pueden clonar
     * cruce aleatorio de genes entre los mas adaptados 
     * mutación de los cruces
     * 
     */



    /*
     * Power Ups:
     * Son de un único uso, aparecerán en el mapa de manera aleatoria cada cierto tiempo.
     * ● Bomba Cruz: En lugar de explotar por radio. Estas explotan en cruz hasta pegar con una pared.
     * ● Curaciones: Cura al que lo agarre un poco de vida.
     * ● Escudo: Permite recibir un golpe de bomba sin recibir daño.
     * ● Zapato: Permite patear bombas lejos del personaje.
     * 
     * Para la busca de los power ups puedo hacer que si el jugador se encuentra a cierto radio del objeto con el power up 
     * entonces este busque la ruta más corta hacia dicho objeto con A*
     * 
     * Del mismo modo para cuando el jugador está dentro del radio de explosion de una bomba, solo que en este caso
     * en lugar de encontrar la ruta mas cota para llegar al objeto, se utiliza A* para encontrar la ruta más corta para salir
     * de ese radio de explosion
     */
}
