using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Interactive // D�clare la classe BoundedNPC h�ritant de la classe Interactive
{
    private Vector3 directionVector; // Vecteur de direction du d�placement du PNJ
    private Transform myTransform; // R�f�rence � la transformation du PNJ
    public float speed; // Vitesse de d�placement du PNJ
    private Rigidbody2D myRigidbody; // R�f�rence au Rigidbody2D du PNJ
    private Animator anim; // R�f�rence � l'Animator du PNJ
    public Collider2D bounds; // Zone de collision d�limitant le d�placement du PNJ

    private bool isMoving; // Indique si le PNJ est en mouvement
    public float minMoveTime; // Temps minimum de d�placement
    public float maxMoveTime; // Temps maximum de d�placement
    private float moveTimeSeconds; // Temps de d�placement actuel
    public float minWaitTime; // Temps minimum d'attente
    public float maxWaitTime; // Temps maximum d'attente
    private float waitTimeSeconds; // Temps d'attente actuel

    // Start is called before the first frame update
    void Start() // M�thode appel�e au d�marrage
    {
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime); // Initialise le temps de d�placement
        waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime); // Initialise le temps d'attente
        anim = GetComponent<Animator>(); // R�cup�re le composant Animator
        myTransform = GetComponent<Transform>(); // R�cup�re la transformation du PNJ
        myRigidbody = GetComponent<Rigidbody2D>(); // R�cup�re le Rigidbody2D du PNJ
        ChangeDirection(); // Initialise la direction de d�placement du PNJ
    }

    // Update is called once per frame
    public override void Update() // M�thode appel�e � chaque frame
    {
        base.Update(); // Appelle la m�thode Update de la classe de base (Interactive)
        if (isMoving) // Si le PNJ est en mouvement
        {
            moveTimeSeconds -= Time.deltaTime; // D�cr�mente le temps de d�placement
            if (moveTimeSeconds <= 0) // Si le temps de d�placement est �coul�
            {
                moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime); // R�initialise le temps de d�placement
                isMoving = false; // Arr�te le d�placement du PNJ
            }
        }
        if (!playerInRange) // Si le joueur n'est pas � proximit�
        {
            Move(); // Fait bouger le PNJ
        }
        else // Si le joueur est � proximit�
        {
            waitTimeSeconds -= Time.deltaTime; // D�cr�mente le temps d'attente
            if (waitTimeSeconds <= 0) // Si le temps d'attente est �coul�
            {
                ChooseDifferentDirection(); // Choisit une nouvelle direction de d�placement
                isMoving = true; // D�marre le mouvement du PNJ
                waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime); // R�initialise le temps d'attente
            }
        }
    }

    private void ChooseDifferentDirection() // M�thode pour choisir une nouvelle direction de d�placement diff�rente
    {
        Vector3 temp = directionVector; // Stocke temporairement l'ancienne direction
        ChangeDirection(); // Choisit une nouvelle direction de d�placement
        int loops = 0; // Compteur pour �viter une boucle infinie
        while (temp == directionVector && loops < 100) // Tant que la direction reste la m�me et que le compteur n'a pas atteint 100
        {
            loops++; // Incr�mente le compteur
            ChangeDirection(); // Choisit une nouvelle direction de d�placement
        }
    }

    private void Move() // M�thode pour d�placer le PNJ
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime; // Calcule la nouvelle position du PNJ
        if (bounds.bounds.Contains(temp)) // Si la nouvelle position est � l'int�rieur de la zone de collision
        {
            myRigidbody.MovePosition(temp); // D�place le PNJ vers la nouvelle position
        }
        else // Si la nouvelle position est en dehors de la zone de collision
        {
            ChangeDirection(); // Choisit une nouvelle direction de d�placement
        }
    }

    void ChangeDirection() // M�thode pour changer la direction de d�placement du PNJ
    {
        int direction = Random.Range(0, 4); // G�n�re un nombre al�atoire entre 0 (inclus) et 4 (exclus)
        switch (direction) // S�lectionne une direction en fonction du nombre al�atoire
        {
            case 0: // Si le nombre est 0
                directionVector = Vector3.right; // D�place le PNJ vers la droite
                break;
            case 1: // Si le nombre est 1
                directionVector = Vector3.up; // D�place le PNJ vers le haut
                break;
            case 2: // Si le nombre est 2
                directionVector = Vector3.left; // D�place le PNJ vers la gauche
                break;
            case 3: // Si le nombre est 3
                directionVector = Vector3.down; // D�place le PNJ vers le bas
                break;
            default: // Pour tout autre nombre
                break;
        }
        UpdateAnimation(); // Met � jour l'animation du PNJ en fonction de la nouvelle direction
    }

    void UpdateAnimation() // M�thode pour mettre � jour l'animation du PNJ en fonction de sa direction de d�placement
    {
        anim.SetFloat("MoveX", directionVector.x); // Met � jour le param�tre "MoveX" de l'Animator avec la composante x de la direction
        anim.SetFloat("MoveY", directionVector.y); // Met � jour le param�tre "MoveY" de l'Animator avec la composante y de la direction
    }

    private void OnCollisionEnter2D(Collision2D other) // M�thode appel�e lorsqu'une collision se produit avec un autre objet
    {
        ChooseDifferentDirection(); // Choisit une nouvelle direction de d�placement
    }
}