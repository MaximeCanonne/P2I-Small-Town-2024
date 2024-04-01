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
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 4;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 4;
        }
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidBody.MovePosition(transform.position + change*speed*Time.deltaTime);
    }
}