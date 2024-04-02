using UnityEngine;
public class CharacterMotor : MonoBehaviour
{
    public float speed; // Vitesse
    private Rigidbody2D myRigidBody; // Personnage
    private Vector3 change; // Vecteur (le z est constamment nul) qui contient les déplacements entrés en direct par le joueur
    private Animator animator; // Interface de contrôle du personnage qui fait le lien entre les déplacements et l'animation
    public VectorValue startingPosition; // Valeur de départ du personnage

    public static CharacterMotor Instance;

    private void Start()
    {
        animator = GetComponent<Animator>(); // Récupération du composant Animator attaché au GameObject
        myRigidBody = GetComponent<Rigidbody2D>(); // Récupération du composant Rigidbody2D attaché au GameObject
        animator.SetFloat("moveX", 0); // Initialisation de la variable "moveX" de l'Animator à 0
        animator.SetFloat("moveY", -1); // Initialisation de la variable "moveY" de l'Animator à -1
        transform.position = startingPosition.initialValue; // Positionnement du GameObject à la position initiale définie dans startingPosition
    }

    void Update()
    {
        change = Vector3.zero; // Réinitialisation du vecteur de déplacement
        change.x = Input.GetAxisRaw("Horizontal"); // Détection de l'entrée horizontale du joueur
        change.y = Input.GetAxisRaw("Vertical"); // Détection de l'entrée verticale du joueur
        UpdateAnimationAndMove(); // Appel de la fonction pour mettre à jour l'animation et le déplacement
        if (Input.GetKeyDown(KeyCode.LeftShift)) // Si la touche Shift gauche est enfoncée
        {
            speed = speed * 4;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) // Si la touche Shift gauche est relâchée
        {
            speed = speed / 4;
        }
    }

    void UpdateAnimationAndMove() // Fonction pour mettre à jour l'animation et le déplacement
    {
        if (change != Vector3.zero) // Si le vecteur de déplacement n'est pas nul
        {
            MoveCharacter(); // Appel de la fonction pour déplacer le personnage
            animator.SetFloat("moveX", change.x); // Mise à jour de la variable "moveX" de l'Animator
            animator.SetFloat("moveY", change.y); // Mise à jour de la variable "moveY" de l'Animator
            animator.SetBool("moving", true); // Activation de l'animation de déplacement
        }
        else // Si le vecteur de déplacement est nul
        {
            animator.SetBool("moving", false); // Désactivation de l'animation de déplacement
        }
    }

    void MoveCharacter() // Fonction pour déplacer le personnage
    {
        myRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime); // Déplacement du personnage selon le vecteur de déplacement et la vitesse
    }
}