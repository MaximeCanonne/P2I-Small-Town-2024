using UnityEngine;
public class CharacterMotor : MonoBehaviour
{
    public float speed; // Vitesse
    private Rigidbody2D myRigidBody; // Personnage
    private Vector3 change; // Vecteur (le z est constamment nul) qui contient les d�placements entr�s en direct par le joueur
    private Animator animator; // Interface de contr�le du personnage qui fait le lien entre les d�placements et l'animation
    public VectorValue startingPosition; // Valeur de d�part du personnage

    public static CharacterMotor Instance;

    private void Start()
    {
        animator = GetComponent<Animator>(); // R�cup�ration du composant Animator attach� au GameObject
        myRigidBody = GetComponent<Rigidbody2D>(); // R�cup�ration du composant Rigidbody2D attach� au GameObject
        animator.SetFloat("moveX", 0); // Initialisation de la variable "moveX" de l'Animator � 0
        animator.SetFloat("moveY", -1); // Initialisation de la variable "moveY" de l'Animator � -1
        transform.position = startingPosition.initialValue; // Positionnement du GameObject � la position initiale d�finie dans startingPosition
    }

    void Update()
    {
        change = Vector3.zero; // R�initialisation du vecteur de d�placement
        change.x = Input.GetAxisRaw("Horizontal"); // D�tection de l'entr�e horizontale du joueur
        change.y = Input.GetAxisRaw("Vertical"); // D�tection de l'entr�e verticale du joueur
        UpdateAnimationAndMove(); // Appel de la fonction pour mettre � jour l'animation et le d�placement
        if (Input.GetKeyDown(KeyCode.LeftShift)) // Si la touche Shift gauche est enfonc�e
        {
            speed = speed * 4;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) // Si la touche Shift gauche est rel�ch�e
        {
            speed = speed / 4;
        }
    }

    void UpdateAnimationAndMove() // Fonction pour mettre � jour l'animation et le d�placement
    {
        if (change != Vector3.zero) // Si le vecteur de d�placement n'est pas nul
        {
            MoveCharacter(); // Appel de la fonction pour d�placer le personnage
            animator.SetFloat("moveX", change.x); // Mise � jour de la variable "moveX" de l'Animator
            animator.SetFloat("moveY", change.y); // Mise � jour de la variable "moveY" de l'Animator
            animator.SetBool("moving", true); // Activation de l'animation de d�placement
        }
        else // Si le vecteur de d�placement est nul
        {
            animator.SetBool("moving", false); // D�sactivation de l'animation de d�placement
        }
    }

    void MoveCharacter() // Fonction pour d�placer le personnage
    {
        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime); // D�placement du personnage selon le vecteur de d�placement et la vitesse
    }
}