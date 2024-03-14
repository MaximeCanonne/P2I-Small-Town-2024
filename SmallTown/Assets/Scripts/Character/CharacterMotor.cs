using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class CharacterMotor : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;
    public VectorValue startingPosition;

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