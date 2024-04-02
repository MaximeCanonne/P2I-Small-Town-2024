using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : Interactive // Déclare la classe BoundedNPC héritant de la classe Interactive
{
    private Vector3 directionVector; // Vecteur de direction du déplacement du PNJ
    private Transform myTransform; // Référence à la transformation du PNJ
    public float speed; // Vitesse de déplacement du PNJ
    private Rigidbody2D myRigidbody; // Référence au Rigidbody2D du PNJ
    private Animator anim; // Référence à l'Animator du PNJ
    public Collider2D bounds; // Zone de collision délimitant le déplacement du PNJ

    private bool isMoving; // Indique si le PNJ est en mouvement
    public float minMoveTime; // Temps minimum de déplacement
    public float maxMoveTime; // Temps maximum de déplacement
    private float moveTimeSeconds; // Temps de déplacement actuel
    public float minWaitTime; // Temps minimum d'attente
    public float maxWaitTime; // Temps maximum d'attente
    private float waitTimeSeconds; // Temps d'attente actuel

    // Start is called before the first frame update
    void Start() // Méthode appelée au démarrage
    {
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime); // Initialise le temps de déplacement
        waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime); // Initialise le temps d'attente
        anim = GetComponent<Animator>(); // Récupère le composant Animator
        myTransform = GetComponent<Transform>(); // Récupère la transformation du PNJ
        myRigidbody = GetComponent<Rigidbody2D>(); // Récupère le Rigidbody2D du PNJ
        ChangeDirection(); // Initialise la direction de déplacement du PNJ
    }

    // Update is called once per frame
    public override void Update() // Méthode appelée à chaque frame
    {
        base.Update(); // Appelle la méthode Update de la classe de base (Interactive)
        if (isMoving) // Si le PNJ est en mouvement
        {
            moveTimeSeconds -= Time.deltaTime; // Décrémente le temps de déplacement
            if (moveTimeSeconds <= 0) // Si le temps de déplacement est écoulé
            {
                moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime); // Réinitialise le temps de déplacement
                isMoving = false; // Arrête le déplacement du PNJ
            }
        }
        if (!playerInRange) // Si le joueur n'est pas à proximité
        {
            Move(); // Fait bouger le PNJ
        }
        else // Si le joueur est à proximité
        {
            waitTimeSeconds -= Time.deltaTime; // Décrémente le temps d'attente
            if (waitTimeSeconds <= 0) // Si le temps d'attente est écoulé
            {
                ChooseDifferentDirection(); // Choisit une nouvelle direction de déplacement
                isMoving = true; // Démarre le mouvement du PNJ
                waitTimeSeconds = Random.Range(minMoveTime, maxMoveTime); // Réinitialise le temps d'attente
            }
        }
    }

    private void ChooseDifferentDirection() // Méthode pour choisir une nouvelle direction de déplacement différente
    {
        Vector3 temp = directionVector; // Stocke temporairement l'ancienne direction
        ChangeDirection(); // Choisit une nouvelle direction de déplacement
        int loops = 0; // Compteur pour éviter une boucle infinie
        while (temp == directionVector && loops < 100) // Tant que la direction reste la même et que le compteur n'a pas atteint 100
        {
            loops++; // Incrémente le compteur
            ChangeDirection(); // Choisit une nouvelle direction de déplacement
        }
    }

    private void Move() // Méthode pour déplacer le PNJ
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime; // Calcule la nouvelle position du PNJ
        if (bounds.bounds.Contains(temp)) // Si la nouvelle position est à l'intérieur de la zone de collision
        {
            myRigidbody.MovePosition(temp); // Déplace le PNJ vers la nouvelle position
        }
        else // Si la nouvelle position est en dehors de la zone de collision
        {
            ChangeDirection(); // Choisit une nouvelle direction de déplacement
        }
    }

    void ChangeDirection() // Méthode pour changer la direction de déplacement du PNJ
    {
        int direction = Random.Range(0, 4); // Génère un nombre aléatoire entre 0 (inclus) et 4 (exclus)
        switch (direction) // Sélectionne une direction en fonction du nombre aléatoire
        {
            case 0: // Si le nombre est 0
                directionVector = Vector3.right; // Déplace le PNJ vers la droite
                break;
            case 1: // Si le nombre est 1
                directionVector = Vector3.up; // Déplace le PNJ vers le haut
                break;
            case 2: // Si le nombre est 2
                directionVector = Vector3.left; // Déplace le PNJ vers la gauche
                break;
            case 3: // Si le nombre est 3
                directionVector = Vector3.down; // Déplace le PNJ vers le bas
                break;
            default: // Pour tout autre nombre
                break;
        }
        UpdateAnimation(); // Met à jour l'animation du PNJ en fonction de la nouvelle direction
    }

    void UpdateAnimation() // Méthode pour mettre à jour l'animation du PNJ en fonction de sa direction de déplacement
    {
        anim.SetFloat("MoveX", directionVector.x); // Met à jour le paramètre "MoveX" de l'Animator avec la composante x de la direction
        anim.SetFloat("MoveY", directionVector.y); // Met à jour le paramètre "MoveY" de l'Animator avec la composante y de la direction
    }

    private void OnCollisionEnter2D(Collision2D other) // Méthode appelée lorsqu'une collision se produit avec un autre objet
    {
        ChooseDifferentDirection(); // Choisit une nouvelle direction de déplacement
    }
}